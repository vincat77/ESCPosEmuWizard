using System.Collections;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using ESCPosEmuWizard;
namespace ESCPosEmuWizard
{
  public static class EscPosPrinterDriverHelpers
  {

    public static void Start2()
    {
      var port = 9100; // Porta TCP/IP per la stampa di rete
      var listener = new TcpListener(IPAddress.Any, port);
      listener.Start();
      Console.WriteLine($"Driver di stampa ESC/POS in ascolto sulla porta {IPAddress.Any}:{port}...");

      while (true)
      {
        TcpClient client = listener.AcceptTcpClient();
        NetworkStream stream = client.GetStream();
        Console.WriteLine("----------------------------------------------------------------------");
        Console.WriteLine($"Client connesso da {client.Client.RemoteEndPoint}.");
        try
        {
          using (var ms = new MemoryStream())
          {
            byte[] buffer = new byte[1024];
            int bytesRead;
            // Continua a leggere fino a quando ci sono dati nel flusso
            while (stream.DataAvailable)
            {
              Console.WriteLine($"\tstream.DataAvailable {stream.DataAvailable}.");
              bytesRead = stream.Read(buffer, 0, buffer.Length);
              Console.WriteLine($"\tbytesRead=>{bytesRead}.");
              ms.Write(buffer, 0, bytesRead);
              var rawData = ms.ToArray();
              Console.WriteLine($"\trawData =>{string.Join("", rawData.Select(b => b.ToString("X2") +" "))}");
              InterpretRawData(rawData, stream);
              Console.WriteLine($"\tInterpretRawData");
              ms.SetLength(0);
            }
          }
        }
        catch (IOException ex)
        {
          Console.WriteLine($"Errore di comunicazione: {ex.Message}");
        }

        client.Close();
        Console.WriteLine("Client disconnesso.");
      }
    }

    private static string FormatText(char character, bool bold, bool underline, int alignment)
    {
      var formattedText = character.ToString();

      if (bold)
      {
        formattedText = $"**{formattedText}**"; // Simula il grassetto
      }

      if (underline)
      {
        formattedText = $"__{formattedText}__"; // Simula la sottolineatura
      }

      if (alignment == 1) // Center
      {
        formattedText = formattedText.PadLeft((Console.WindowWidth + formattedText.Length) / 2).PadRight(Console.WindowWidth);
      }
      else if (alignment == 2) // Right
      {
        formattedText = formattedText.PadLeft(Console.WindowWidth);
      }

      return formattedText;
    }

    private static void InterpretRawData(byte[] data, NetworkStream stream)
    {
      var i = 0;
      Console.WriteLine("data.Length=>" + data.Length);
      while (i < data.Length)
      {
        var currentByte = data[i];
        Console.WriteLine("COMANDO=>" + currentByte.ToString("X2"));
        switch (currentByte)
        {
          case EscPosMainCommands.ESC:
            i += ProcessCommandESC(data);
            Console.WriteLine("ProcessCommandESC"+i);
            break;

          case EscPosMainCommands.GS:
            i += ProcessCommandGS(data, i);
            break;

          case EscPosMainCommands.DLE:
            i += ProcessCommandDLE(data, stream,i );
            Console.WriteLine("ProcessCommandDLE" + i);
            break;

          case EscPosMainCommands.FS:
            Console.Write("FS");
            break;


          default:
            Console.Write("NESSUN COMANDO");
            break;
        }

        i++;
      }

    }

    private static int ProcessCommandDLE(byte[] data, NetworkStream stream, int startCommandFrom)
    {
      var verb = data[startCommandFrom+1];
      switch (verb)
      {
        case 0x4 when EscPosCommandsDLE.RequestPrinterStatus[1] == verb:
          Console.WriteLine("Richiesta stato stampante.");
          stream.Write(EscPosCommandsDLE.TransmitStatus, 0, EscPosCommandsDLE.TransmitStatus.Length);
          Console.WriteLine("Risposta statostampante.");
          return EscPosCommandsDLE.RequestPrinterStatus.Length - 1;

      }

      Console.WriteLine("NON INTERPRETATO" +verb.ToString("X2"));
      return 1;
    }

    private static int ProcessCommandESC(byte[] data)
    {
      if (data.Length < 2)
      {
        Console.WriteLine("Incomplete ESC command.");
        return int.MaxValue;
      }

      var verb = data[1];

      switch (verb)
      {

        case 0x24 when EscPosCommandsESC.SetAbsolutePrintPosition[1] == verb:
          Console.WriteLine("SetAbsolutePrintPosition");
          return EscPosCommandsESC.SetAbsolutePrintPosition.Length - 1;

        case 0x5C when EscPosCommandsESC.SetRelativePrintPosition[1] == verb:
          Console.WriteLine("SetRelativePrintPosition");
          return EscPosCommandsESC.SetRelativePrintPosition.Length - 1;

        case 0x09 when EscPosCommandsESC.HorizontalTab[0] == verb:
          Console.WriteLine("HorizontalTab");
          return EscPosCommandsESC.HorizontalTab.Length - 1;
          break;

        case 0x0D when EscPosCommandsESC.CarriageReturn[0] == verb:
          Console.WriteLine("CarriageReturn");
          return EscPosCommandsESC.CarriageReturn.Length - 1;
          break;

        case 0x0C when EscPosCommandsESC.FormFeed[0] == verb:
          Console.WriteLine("FormFeed");
          return EscPosCommandsESC.FormFeed.Length - 1;
          break;

        case 0x0A when EscPosCommandsESC.LineFeed[0] == verb:
          Console.WriteLine("LineFeed");
          return EscPosCommandsESC.LineFeed.Length - 1;
          break;

        case 0x40 when EscPosCommandsESC.InitializePrinter[1] == verb:
          Console.WriteLine("Stampante inizializzata.");
          return EscPosCommandsESC.InitializePrinter.Length - 1;
          break;

        case 0x45 when EscPosCommandsESC.TextBoldOn[1] == verb:
          Console.WriteLine("TextBoldOn");
          return EscPosCommandsESC.TextBoldOn.Length - 1;
          break;

        case 0x45 when EscPosCommandsESC.TextBoldOff[1] == verb:
          Console.WriteLine("TextBoldOff");
          return EscPosCommandsESC.TextBoldOff.Length - 1;
          break;

        case 0x2D when EscPosCommandsESC.TextUnderlineOn[1] == verb:
          Console.WriteLine("TextUnderlineOn");
          return EscPosCommandsESC.TextUnderlineOn.Length - 1;
          break;

        case 0x2D when EscPosCommandsESC.TextUnderlineOff[1] == verb:
          Console.WriteLine("TextUnderlineOff");
          return EscPosCommandsESC.TextUnderlineOff.Length - 1;
          break;

        case 0x61 when EscPosCommandsESC.AlignLeft[1] == verb:
          Console.WriteLine("AlignLeft");
          return EscPosCommandsESC.AlignLeft.Length - 1;
          break;

        case 0x61 when EscPosCommandsESC.AlignCenter[1] == verb:
          Console.WriteLine("AlignCenter");
          return EscPosCommandsESC.AlignCenter.Length - 1;
          break;

        case 0x61 when EscPosCommandsESC.AlignRight[1] == verb:
          Console.WriteLine("AlignRight");
          return EscPosCommandsESC.AlignRight.Length - 1;
          break;

        case 0x70 when EscPosCommandsESC.OpenCashDrawerPin2[1] == verb:
          Console.WriteLine("OpenCashDrawerPin2");
          return EscPosCommandsESC.OpenCashDrawerPin2.Length - 1;
          break;

        case 0x70 when EscPosCommandsESC.OpenCashDrawerPin5[1] == verb:
          Console.WriteLine("OpenCashDrawerPin5");
          return EscPosCommandsESC.OpenCashDrawerPin5.Length - 1;
          break;

        case 0x47 when EscPosCommandsESC.EnableDoubleStrike[1] == verb:
          Console.WriteLine("EnableDoubleStrike");
          return EscPosCommandsESC.EnableDoubleStrike.Length - 1;
          break;

        case 0x47 when EscPosCommandsESC.DisableDoubleStrike[1] == verb:
          Console.WriteLine("DisableDoubleStrike");
          return EscPosCommandsESC.DisableDoubleStrike.Length - 1;
          break;

        case 0x64 when EscPosCommandsESC.FeedNLines[1] == verb:
          Console.WriteLine("FeedNLines");
          return EscPosCommandsESC.FeedNLines.Length - 1;
          break;

        case 0x65 when EscPosCommandsESC.ReverseFeedNLines[1] == verb:
          Console.WriteLine("ReverseFeedNLines");
          return EscPosCommandsESC.ReverseFeedNLines.Length - 1;
          break;

        case 0x32 when EscPosCommandsESC.SetLineSpacingDefault[1] == verb:
          Console.WriteLine("SetLineSpacingDefault");
          return EscPosCommandsESC.SetLineSpacingDefault.Length - 1;
          break;

        case 0x33 when EscPosCommandsESC.SetLineSpacing24Dots[1] == verb:
          Console.WriteLine("SetLineSpacing24Dots");
          return EscPosCommandsESC.SetLineSpacing24Dots.Length - 1;
          break;

        case 0x0C when EscPosCommandsESC.CancelPrintData[1] == verb:
          Console.WriteLine("CancelPrintData");
          return EscPosCommandsESC.CancelPrintData.Length - 1;
          break;

        case 0x72 when EscPosCommandsESC.SetTextColorBlack[1] == verb:
          Console.WriteLine("SetTextColorBlack");
          return EscPosCommandsESC.SetTextColorBlack.Length - 1;
          break;

        case 0x72 when EscPosCommandsESC.SetTextColorRed[1] == verb:
          Console.WriteLine("SetTextColorRed");
          return EscPosCommandsESC.SetTextColorRed.Length - 1;
          break;

        case 0x74 when EscPosCommandsESC.SelectCharacterCodeTable[1] == verb:
          Console.WriteLine("SelectCharacterCodeTable");
          return EscPosCommandsESC.SelectCharacterCodeTable.Length - 1;
          break;

        case 0x4A when EscPosCommandsESC.PrintAndFeedPaper[1] == verb:
          Console.WriteLine("PrintAndFeedPaper");
          return EscPosCommandsESC.PrintAndFeedPaper.Length - 1;
          break;

        case 0x42 when EscPosCommandsESC.SoundBuzzer[1] == verb:
          Console.WriteLine("SoundBuzzer");
          return EscPosCommandsESC.SoundBuzzer.Length - 1;
          break;

        case 0x70 when EscPosCommandsESC.GeneratePulse[1] == verb:
          Console.WriteLine("GeneratePulse");
          return EscPosCommandsESC.GeneratePulse.Length - 1;
          break;

        case 0x63 when EscPosCommandsESC.EnableDisablePanelButtons[1] == verb:
          Console.WriteLine("EnableDisablePanelButtons");
          return EscPosCommandsESC.EnableDisablePanelButtons.Length - 1;
          break;

        case 0x69 when EscPosCommandsESC.PartialCutPaperOnePoint[1] == verb:
          Console.WriteLine("PartialCutPaperOnePoint");
          return EscPosCommandsESC.PartialCutPaperOnePoint.Length - 1;
          break;

        case 0x6D when EscPosCommandsESC.PartialCutPaperThreePoints[1] == verb:
          Console.WriteLine("PartialCutPaperThreePoints");
          return EscPosCommandsESC.PartialCutPaperThreePoints.Length - 1;
          break;

        case 0x2A when EscPosCommandsESC.SelectBitImageMode[1] == verb:
          Console.WriteLine("SelectBitImageMode");
          return EscPosCommandsESC.SelectBitImageMode.Length - 1;
          break;

        case 0x63 when EscPosCommandsESC.SetPaperSensors[1] == verb:
          Console.WriteLine("SetPaperSensors");
          return EscPosCommandsESC.SetPaperSensors.Length - 1;
          break;

        case 0x44 when EscPosCommandsESC.SetHorizontalTabPositions[1] == verb:
          Console.WriteLine("SetHorizontalTabPositions");
          return EscPosCommandsESC.SetHorizontalTabPositions.Length - 1;
          break;

        case 0x4D when EscPosCommandsESC.SelectFont[1] == verb:
          Console.WriteLine("SelectFont");
          return EscPosCommandsESC.SelectFont.Length - 1;
          break;

        case 0x7B when EscPosCommandsESC.UpsideDownMode[1] == verb:
          Console.WriteLine("UpsideDownMode");
          return EscPosCommandsESC.UpsideDownMode.Length - 1;
          break;

        case 0x20 when EscPosCommandsESC.SetCharacterSpacing[1] == verb:
          Console.WriteLine("SetCharacterSpacing");
          return EscPosCommandsESC.SetCharacterSpacing.Length - 1;
          break;

        case 0x4C when EscPosCommandsESC.SelectPageMode[1] == verb:
          Console.WriteLine("SelectPageMode");
          return EscPosCommandsESC.SelectPageMode.Length - 1;
          break;

        case 0x53 when EscPosCommandsESC.SelectStandardMode[1] == verb:
          Console.WriteLine("SelectStandardMode");
          return EscPosCommandsESC.SelectStandardMode.Length - 1;
          break;

        case 0x57 when EscPosCommandsESC.SetPrintAreaInPageMode[1] == verb:
          Console.WriteLine("SetPrintAreaInPageMode");
          return EscPosCommandsESC.SetPrintAreaInPageMode.Length - 1;
          break;

        case 0x63 when EscPosCommandsESC.EnableDisablePanelButtonStatusTransmission[1] == verb:
          Console.WriteLine("EnableDisablePanelButtonStatusTransmission");
          return EscPosCommandsESC.EnableDisablePanelButtonStatusTransmission.Length - 1;
          break;

        case 0x52 when EscPosCommandsESC.SelectInternationalCharacterSet[1] == verb:
          Console.WriteLine("SelectInternationalCharacterSet");
          return EscPosCommandsESC.SelectInternationalCharacterSet.Length - 1;
          break;

        case 0x54 when EscPosCommandsESC.SetPrintDirectionInPageMode[1] == verb:
          Console.WriteLine("SetPrintDirectionInPageMode");
          return EscPosCommandsESC.SetPrintDirectionInPageMode.Length - 1;
          break;

        case 0x34 when EscPosCommandsESC.EnableDisableAutomaticLineFeed[1] == verb:
          Console.WriteLine("EnableDisableAutomaticLineFeed");
          return EscPosCommandsESC.EnableDisableAutomaticLineFeed.Length - 1;
          break;

        case 0x57 when EscPosCommandsESC.SelectDoubleWidthMode[1] == verb:
          Console.WriteLine("SelectDoubleWidthMode");
          return EscPosCommandsESC.SelectDoubleWidthMode.Length - 1;
          break;

        case 0x07 when EscPosCommandsESC.ControlBeepOrBuzzer[0] == verb:
          Console.WriteLine("ControlBeepOrBuzzer");
          return EscPosCommandsESC.ControlBeepOrBuzzer.Length - 1;
          break;

        case 0x21 when EscPosCommandsESC.SelectPrintMode[1] == verb:
          Console.WriteLine("SelectPrintMode");
          return EscPosCommandsESC.SelectPrintMode.Length - 1;
          break;

        case 0x3C when EscPosCommandsESC.SelectCancelLeftMargin[1] == verb:
          Console.WriteLine("SelectCancelLeftMargin");
          return EscPosCommandsESC.SelectCancelLeftMargin.Length - 1;
          break;

        case 0x3D when EscPosCommandsESC.EnableDisablePrinting[1] == verb:
          Console.WriteLine("EnableDisablePrinting");
          return EscPosCommandsESC.EnableDisablePrinting.Length - 1;
          break;

        case 0x63 when EscPosCommandsESC.TransmitRealTimeInkStatus[1] == verb:
          Console.WriteLine("TransmitRealTimeInkStatus");
          return EscPosCommandsESC.TransmitRealTimeInkStatus.Length - 1;
          break;

        case 0x75 when EscPosCommandsESC.TransmitOperatorPanelStatus[1] == verb:
          Console.WriteLine("TransmitOperatorPanelStatus");
          return EscPosCommandsESC.TransmitOperatorPanelStatus.Length - 1;
          break;

        case 0x28 when EscPosCommandsESC.DownloadCustomGraphicData[1] == verb:
          Console.WriteLine("DownloadCustomGraphicData");
          return EscPosCommandsESC.DownloadCustomGraphicData.Length - 1;
          break;

        case 0x69 when EscPosCommandsESC.PartialCutWithParameter[1] == verb:
          Console.WriteLine("PartialCutWithParameter");
          return EscPosCommandsESC.PartialCutWithParameter.Length - 1;
          break;

        case 0x33 when EscPosCommandsESC.EnableAutomaticLineFeedAfterLine[1] == verb:
          Console.WriteLine("EnableAutomaticLineFeedAfterLine");
          return EscPosCommandsESC.EnableAutomaticLineFeedAfterLine.Length - 1;
          break;

        case 0x4D when EscPosCommandsESC.SetCharacterFont[1] == verb:
          Console.WriteLine("SetCharacterFont");
          return EscPosCommandsESC.SetCharacterFont.Length - 1;
          break;

        case 0x52 when EscPosCommandsESC.SetTopMargin[1] == verb:
          Console.WriteLine("SetTopMargin");
          return EscPosCommandsESC.SetTopMargin.Length - 1;
          break;

        case 0x25 when EscPosCommandsESC.SelectCancelUserDefinedCharacterSet[1] == verb:
          Console.WriteLine("SelectCancelUserDefinedCharacterSet");
          return EscPosCommandsESC.SelectCancelUserDefinedCharacterSet.Length - 1;
          break;

        case 0x28 when EscPosCommandsESC.SetRightSideCharacterSpacing[1] == verb:
          Console.WriteLine("SetRightSideCharacterSpacing");
          return EscPosCommandsESC.SetRightSideCharacterSpacing.Length - 1;
          break;

        case 0x2D when EscPosCommandsESC.SetUnderlineMode[1] == verb:
          Console.WriteLine("SetUnderlineMode");
          return EscPosCommandsESC.SetUnderlineMode.Length - 1;
          break;

        case 0x45 when EscPosCommandsESC.SetEmphasizedMode[1] == verb:
          Console.WriteLine("SetEmphasizedMode");
          return EscPosCommandsESC.SetEmphasizedMode.Length - 1;
          break;

        case 0x47 when EscPosCommandsESC.SetDoubleStrikeMode[1] == verb:
          Console.WriteLine("SetDoubleStrikeMode");
          return EscPosCommandsESC.SetDoubleStrikeMode.Length - 1;
          break;

        case 0x4D when EscPosCommandsESC.SetFont[1] == verb:
          Console.WriteLine("SetFont");
          return EscPosCommandsESC.SetFont.Length - 1;
          break;

        case 0x7B when EscPosCommandsESC.SetUpsideDownPrinting[1] == verb:
          Console.WriteLine("SetUpsideDownPrinting");
          return EscPosCommandsESC.SetUpsideDownPrinting.Length - 1;
          break;

        case 0x74 when EscPosCommandsESC.SetCharacterCodeTable[1] == verb:
          Console.WriteLine("SetCharacterCodeTable");
          return EscPosCommandsESC.SetCharacterCodeTable.Length - 1;
          break;

        case 0x56 when EscPosCommandsESC.Turn90DegreeRotationMode[1] == verb:
          Console.WriteLine("Turn90DegreeRotationMode");
          return EscPosCommandsESC.Turn90DegreeRotationMode.Length - 1;
          break;

        case 0x55 when EscPosCommandsESC.TurnUnidirectionalPrintMode[1] == verb:
          Console.WriteLine("TurnUnidirectionalPrintMode");
          break;

        case 0x3D when EscPosCommandsESC.SelectPeripheralDevice[1] == verb:
          return EscPosCommandsESC.SelectPeripheralDevice.Length - 1;
          Console.WriteLine("SelectPeripheralDevice");
          break;

        case 0x44 when EscPosCommandsESC.CancelAllHorizontalTabPositions[1] == verb:
          return EscPosCommandsESC.CancelAllHorizontalTabPositions.Length - 1;
          Console.WriteLine("CancelAllHorizontalTabPositions");
          break;

        case 0x42 when EscPosCommandsESC.SetVerticalTabPositions[1] == verb:
          Console.WriteLine("SetVerticalTabPositions");
          return EscPosCommandsESC.SetVerticalTabPositions.Length - 1;
          break;

        case 0x42 when EscPosCommandsESC.CancelAllVerticalTabPositions[1] == verb:
          Console.WriteLine("CancelAllVerticalTabPositions");
          return EscPosCommandsESC.CancelAllVerticalTabPositions.Length - 1;
          break;

        case 0x45 when EscPosCommandsESC.TurnEmphasizedMode[1] == verb:
          Console.WriteLine("TurnEmphasizedMode");
          return EscPosCommandsESC.TurnEmphasizedMode.Length - 1;
          break;

        case 0x47 when EscPosCommandsESC.TurnDoubleStrikeMode[1] == verb:
          Console.WriteLine("TurnDoubleStrikeMode");
          return EscPosCommandsESC.TurnDoubleStrikeMode.Length - 1;
          break;

        case 0x2D when EscPosCommandsESC.TurnUnderlineMode[1] == verb:
          Console.WriteLine("TurnUnderlineMode");
          return EscPosCommandsESC.TurnUnderlineMode.Length - 1;
          break;

        case 0x32 when EscPosCommandsESC.SetDefaultLineSpacing[1] == verb:
          Console.WriteLine("SetDefaultLineSpacing");
          return EscPosCommandsESC.SetDefaultLineSpacing.Length - 1;
          break;

        case 0x7B when EscPosCommandsESC.TurnUpsideDownMode[1] == verb:
          Console.WriteLine("TurnUpsideDownMode");
          return EscPosCommandsESC.TurnUpsideDownMode.Length - 1;
          break;

        case 0x61 when EscPosCommandsESC.SetLeftAlignment[1] == verb:
          Console.WriteLine("SetLeftAlignment");
          return EscPosCommandsESC.SetLeftAlignment.Length - 1;
          break;

        case 0x61 when EscPosCommandsESC.SetCenterAlignment[1] == verb:
          Console.WriteLine("SetCenterAlignment");
          return EscPosCommandsESC.SetCenterAlignment.Length - 1;
          break;

        case 0x61 when EscPosCommandsESC.SetRightAlignment[1] == verb:
          Console.WriteLine("SetRightAlignment");
          return EscPosCommandsESC.SetRightAlignment.Length - 1;
          break;

        case 0x2A when EscPosCommandsESC.SetBitImageMode[1] == verb:
          Console.WriteLine("SetBitImageMode");
          return EscPosCommandsESC.SetBitImageMode.Length - 1;
          break;

        case 0x63 when EscPosCommandsESC.SetPaperSensorsToStopPrinting[1] == verb:
          Console.WriteLine("SetPaperSensorsToStopPrinting");
          return EscPosCommandsESC.SetPaperSensorsToStopPrinting.Length - 1;
          break;

        case 0x63 when EscPosCommandsESC.SetPaperSensorsToOutputPaperEndSignals[1] == verb:
          Console.WriteLine("SetPaperSensorsToOutputPaperEndSignals");
          return EscPosCommandsESC.SetPaperSensorsToOutputPaperEndSignals.Length - 1;
          break;

        case 0x63 when EscPosCommandsESC.SelectPeripheralDeviceForStatusTransmission[1] == verb:
          Console.WriteLine("SelectPeripheralDeviceForStatusTransmission");
          return EscPosCommandsESC.SelectPeripheralDeviceForStatusTransmission.Length - 1;
          break;


        default:
          Console.WriteLine($"Unknown ESC command: 0x{verb:X2}");
          break;
      }

      return 1;
    }

    private static int ProcessCommandGS(byte[] data, int i)
    {
      var nextByte = data[1];
      if (nextByte == 0x56)
      {
        Console.WriteLine("--- Carta tagliata (totale) ---");
      }
      else if (nextByte == 0x6B)
      {
        var barcodeType = data[2];
        var barcodeLength = data[3];
        var barcode = Encoding.ASCII.GetString(data, i + 1, barcodeLength);
        Console.WriteLine($"[Codice a barre ({barcodeType}): {barcode}]");
        i += barcodeLength;
      }

      return i;
    }
  }
}
