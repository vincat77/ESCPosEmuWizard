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
        // client.ReceiveTimeout = 5000; // Imposta un timeout di 5 secondi per la lettura
        NetworkStream stream = client.GetStream();

        try
        {
          using (var ms = new MemoryStream())
          {
            byte[] buffer = new byte[1024]; // Buffer di lettura (1 KB alla volta)
            int bytesRead;

            // Continua a leggere fino a quando ci sono dati nel flusso
            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0 )
            {
              // Scrivi i dati letti nello stream di memoria
              ms.Write(buffer, 0, bytesRead);

              // Se hai ricevuto un blocco di dati completo, puoi processarlo
              var rawData = ms.ToArray();
              InterpretRawData(rawData, stream);

              // Svuota lo stream di memoria per il prossimo comando
              ms.SetLength(0); // Reset della memoria
            }


          }

          stream.Write(Encoding.ASCII.GetBytes("ALKJHLKJHLKKJ"), 0, Encoding.ASCII.GetBytes("ALKJHLKJHLKKJ").Length);
        }
        catch (IOException ex)
        {
          Console.WriteLine($"Errore di comunicazione: {ex.Message}");
        }

        client.Close();
        Console.WriteLine("Client disconnesso.");
      }
    }


    public static void Start()
    {
      var port = 9100; // Porta TCP/IP per la stampa di rete
      var listener = new TcpListener(IPAddress.Any, port);
      listener.Start();
      Console.WriteLine($"Driver di stampa ESC/POS in ascolto sulla porta {IPAddress.Any}:{port}...");

      while (true)
      {
        TcpClient client = listener.AcceptTcpClient();
        NetworkStream stream = client.GetStream();

        using (var ms = new MemoryStream())
        {
          stream.CopyTo(ms);

          var rawData = ms.ToArray();
          InterpretRawData(rawData, stream);
        }

        client.Close();
      }
    }

    public static async Task StartAsync()
    {
      var port = 9100; // Porta TCP/IP per la stampa di rete
      var listener = new TcpListener(IPAddress.Any, port);
      listener.Start();
      Console.WriteLine($"Driver di stampa ESC/POS in ascolto sulla porta {IPAddress.Any}:{port}...");

      while (true)
      {
        // Accetta connessioni TCP in modo asincrono
        TcpClient client = await listener.AcceptTcpClientAsync();
        _ = HandleClientAsync(client); // Esegui la gestione del client senza bloccare il loop principale
      }
    }

    private static async Task HandleClientAsync(TcpClient client)
    {
      Console.WriteLine($"Client connesso da {client.Client.RemoteEndPoint}.");

      using (NetworkStream stream = client.GetStream())
      using (var ms = new MemoryStream())
      {
        // Copia i dati ricevuti dal client nello stream di memoria in modo asincrono
        await stream.CopyToAsync(ms);
        var rawData = ms.ToArray();

        // Interpreta i dati grezzi (comandi ESC/POS)
        InterpretRawData(rawData, stream);
      }

      client.Close();
      Console.WriteLine("Client disconnesso.");
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
      System.Diagnostics.Debugger.Break();


      var outputFile = "PrintOutput.txt"; // Simula l'output su file
      using (var writer = new StreamWriter(outputFile, true))
      {
        var i = 0;
        bool bold = false, underline = false;
        var alignment = 0; // 0 = Left, 1 = Center, 2 = Right

        while (i < data.Length)
        {
          var currentByte = data[i];

          // Interpretazione dei comandi ESC/POS
          switch (currentByte) // ESC
          {
            case EscPosMainCommands.ESC:
              {
                ProcessCommandESC(data, writer, ref i, ref bold, ref underline, ref alignment);

                break;
              }

            case EscPosMainCommands.GS:
              {
                i = ProcessCommandGS(data, writer, i);

                break;
              }

            case EscPosMainCommands.DLE:
              {
                Console.Write("DLE");
                stream.Write(Encoding.ASCII.GetBytes("AAAAAAAAAA"), 0, Encoding.ASCII.GetBytes("AAAAAAAAAA").Length);
                Console.Write("CIIIIIIIAIIAIIIIAIAIIAIIA");
                writer.Flush();
                break;
              }

            case EscPosMainCommands.FS:
              {
                Console.Write("FS");
                break;
              }


            default:
              {
                // Stampa carattere normale
                var formattedText = FormatText((char)currentByte, bold, underline, alignment);
                writer.Write(formattedText);
                Console.Write(formattedText);
                break;
              }
          }

          i++;
        }
      }

    }

    private static void ProcessCommandESC(byte[] data, StreamWriter writer, ref int i, ref bool bold, ref bool underline, ref int alignment)
    {
      if (i + 1 >= data.Length)
      {
        Console.WriteLine("Incomplete ESC command.");
        return;
      }

      var verb = data[++i];

      switch (verb)
      {
        case 0x24 when EscPosCommandsESC.SetAbsolutePrintPosition[1] == verb:
          Console.WriteLine("SetAbsolutePrintPosition");
          break;

        case 0x5C when EscPosCommandsESC.SetRelativePrintPosition[1] == verb:
          Console.WriteLine("SetRelativePrintPosition");
          break;

        case 0x09 when EscPosCommandsESC.HorizontalTab[0] == verb:
          Console.WriteLine("HorizontalTab");
          break;

        case 0x0D when EscPosCommandsESC.CarriageReturn[0] == verb:
          Console.WriteLine("CarriageReturn");
          break;

        case 0x0C when EscPosCommandsESC.FormFeed[0] == verb:
          Console.WriteLine("FormFeed");
          break;

        case 0x0A when EscPosCommandsESC.LineFeed[0] == verb:
          Console.WriteLine("LineFeed");
          break;

        case 0x40 when EscPosCommandsESC.InitializePrinter[1] == verb:
          Console.WriteLine("Stampante inizializzata.");
          break;

        case 0x45 when EscPosCommandsESC.TextBoldOn[1] == verb:
          bold = true;
          Console.WriteLine("TextBoldOn");
          break;

        case 0x45 when EscPosCommandsESC.TextBoldOff[1] == verb:
          bold = false;
          Console.WriteLine("TextBoldOff");
          break;

        case 0x2D when EscPosCommandsESC.TextUnderlineOn[1] == verb:
          underline = true;
          Console.WriteLine("TextUnderlineOn");
          break;

        case 0x2D when EscPosCommandsESC.TextUnderlineOff[1] == verb:
          underline = false;
          Console.WriteLine("TextUnderlineOff");
          break;

        case 0x61 when EscPosCommandsESC.AlignLeft[1] == verb:
          alignment = 0;
          Console.WriteLine("AlignLeft");
          break;

        case 0x61 when EscPosCommandsESC.AlignCenter[1] == verb:
          alignment = 1;
          Console.WriteLine("AlignCenter");
          break;

        case 0x61 when EscPosCommandsESC.AlignRight[1] == verb:
          alignment = 2;
          Console.WriteLine("AlignRight");
          break;

        case 0x70 when EscPosCommandsESC.OpenCashDrawerPin2[1] == verb:
          Console.WriteLine("OpenCashDrawerPin2");
          break;

        case 0x70 when EscPosCommandsESC.OpenCashDrawerPin5[1] == verb:
          Console.WriteLine("OpenCashDrawerPin5");
          break;

        case 0x47 when EscPosCommandsESC.EnableDoubleStrike[1] == verb:
          Console.WriteLine("EnableDoubleStrike");
          break;

        case 0x47 when EscPosCommandsESC.DisableDoubleStrike[1] == verb:
          Console.WriteLine("DisableDoubleStrike");
          break;

        case 0x64 when EscPosCommandsESC.FeedNLines[1] == verb:
          Console.WriteLine("FeedNLines");
          break;

        case 0x65 when EscPosCommandsESC.ReverseFeedNLines[1] == verb:
          Console.WriteLine("ReverseFeedNLines");
          break;

        case 0x32 when EscPosCommandsESC.SetLineSpacingDefault[1] == verb:
          Console.WriteLine("SetLineSpacingDefault");
          break;

        case 0x33 when EscPosCommandsESC.SetLineSpacing24Dots[1] == verb:
          Console.WriteLine("SetLineSpacing24Dots");
          break;

        case 0x0C when EscPosCommandsESC.CancelPrintData[1] == verb:
          Console.WriteLine("CancelPrintData");
          break;

        case 0x72 when EscPosCommandsESC.SetTextColorBlack[1] == verb:
          Console.WriteLine("SetTextColorBlack");
          break;

        case 0x72 when EscPosCommandsESC.SetTextColorRed[1] == verb:
          Console.WriteLine("SetTextColorRed");
          break;

        case 0x74 when EscPosCommandsESC.SelectCharacterCodeTable[1] == verb:
          Console.WriteLine("SelectCharacterCodeTable");
          break;

        case 0x4A when EscPosCommandsESC.PrintAndFeedPaper[1] == verb:
          Console.WriteLine("PrintAndFeedPaper");
          break;

        case 0x42 when EscPosCommandsESC.SoundBuzzer[1] == verb:
          Console.WriteLine("SoundBuzzer");
          break;

        case 0x70 when EscPosCommandsESC.GeneratePulse[1] == verb:
          Console.WriteLine("GeneratePulse");
          break;

        case 0x63 when EscPosCommandsESC.EnableDisablePanelButtons[1] == verb:
          Console.WriteLine("EnableDisablePanelButtons");
          break;

        case 0x69 when EscPosCommandsESC.PartialCutPaperOnePoint[1] == verb:
          Console.WriteLine("PartialCutPaperOnePoint");
          break;

        case 0x6D when EscPosCommandsESC.PartialCutPaperThreePoints[1] == verb:
          Console.WriteLine("PartialCutPaperThreePoints");
          break;

        case 0x2A when EscPosCommandsESC.SelectBitImageMode[1] == verb:
          Console.WriteLine("SelectBitImageMode");
          break;

        case 0x63 when EscPosCommandsESC.SetPaperSensors[1] == verb:
          Console.WriteLine("SetPaperSensors");
          break;

        case 0x44 when EscPosCommandsESC.SetHorizontalTabPositions[1] == verb:
          Console.WriteLine("SetHorizontalTabPositions");
          break;

        case 0x4D when EscPosCommandsESC.SelectFont[1] == verb:
          Console.WriteLine("SelectFont");
          break;

        case 0x7B when EscPosCommandsESC.UpsideDownMode[1] == verb:
          Console.WriteLine("UpsideDownMode");
          break;

        case 0x20 when EscPosCommandsESC.SetCharacterSpacing[1] == verb:
          Console.WriteLine("SetCharacterSpacing");
          break;

        case 0x4C when EscPosCommandsESC.SelectPageMode[1] == verb:
          Console.WriteLine("SelectPageMode");
          break;

        case 0x53 when EscPosCommandsESC.SelectStandardMode[1] == verb:
          Console.WriteLine("SelectStandardMode");
          break;

        case 0x57 when EscPosCommandsESC.SetPrintAreaInPageMode[1] == verb:
          Console.WriteLine("SetPrintAreaInPageMode");
          break;

        case 0x63 when EscPosCommandsESC.EnableDisablePanelButtonStatusTransmission[1] == verb:
          Console.WriteLine("EnableDisablePanelButtonStatusTransmission");
          break;

        case 0x52 when EscPosCommandsESC.SelectInternationalCharacterSet[1] == verb:
          Console.WriteLine("SelectInternationalCharacterSet");
          break;

        case 0x54 when EscPosCommandsESC.SetPrintDirectionInPageMode[1] == verb:
          Console.WriteLine("SetPrintDirectionInPageMode");
          break;

        case 0x34 when EscPosCommandsESC.EnableDisableAutomaticLineFeed[1] == verb:
          Console.WriteLine("EnableDisableAutomaticLineFeed");
          break;

        case 0x57 when EscPosCommandsESC.SelectDoubleWidthMode[1] == verb:
          Console.WriteLine("SelectDoubleWidthMode");
          break;

        case 0x07 when EscPosCommandsESC.ControlBeepOrBuzzer[0] == verb:
          Console.WriteLine("ControlBeepOrBuzzer");
          break;

        case 0x21 when EscPosCommandsESC.SelectPrintMode[1] == verb:
          Console.WriteLine("SelectPrintMode");
          break;

        case 0x3C when EscPosCommandsESC.SelectCancelLeftMargin[1] == verb:
          Console.WriteLine("SelectCancelLeftMargin");
          break;

        case 0x3D when EscPosCommandsESC.EnableDisablePrinting[1] == verb:
          Console.WriteLine("EnableDisablePrinting");
          break;

        case 0x63 when EscPosCommandsESC.TransmitRealTimeInkStatus[1] == verb:
          Console.WriteLine("TransmitRealTimeInkStatus");
          break;

        case 0x75 when EscPosCommandsESC.TransmitOperatorPanelStatus[1] == verb:
          Console.WriteLine("TransmitOperatorPanelStatus");
          break;

        case 0x28 when EscPosCommandsESC.DownloadCustomGraphicData[1] == verb:
          Console.WriteLine("DownloadCustomGraphicData");
          break;

        case 0x69 when EscPosCommandsESC.PartialCutWithParameter[1] == verb:
          Console.WriteLine("PartialCutWithParameter");
          break;

        case 0x33 when EscPosCommandsESC.EnableAutomaticLineFeedAfterLine[1] == verb:
          Console.WriteLine("EnableAutomaticLineFeedAfterLine");
          break;

        case 0x4D when EscPosCommandsESC.SetCharacterFont[1] == verb:
          Console.WriteLine("SetCharacterFont");
          break;

        case 0x52 when EscPosCommandsESC.SetTopMargin[1] == verb:
          Console.WriteLine("SetTopMargin");
          break;

        case 0x25 when EscPosCommandsESC.SelectCancelUserDefinedCharacterSet[1] == verb:
          Console.WriteLine("SelectCancelUserDefinedCharacterSet");
          break;

        case 0x28 when EscPosCommandsESC.SetRightSideCharacterSpacing[1] == verb:
          Console.WriteLine("SetRightSideCharacterSpacing");
          break;

        case 0x2D when EscPosCommandsESC.SetUnderlineMode[1] == verb:
          Console.WriteLine("SetUnderlineMode");
          break;

        case 0x45 when EscPosCommandsESC.SetEmphasizedMode[1] == verb:
          Console.WriteLine("SetEmphasizedMode");
          break;

        case 0x47 when EscPosCommandsESC.SetDoubleStrikeMode[1] == verb:
          Console.WriteLine("SetDoubleStrikeMode");
          break;

        case 0x4D when EscPosCommandsESC.SetFont[1] == verb:
          Console.WriteLine("SetFont");
          break;

        case 0x7B when EscPosCommandsESC.SetUpsideDownPrinting[1] == verb:
          Console.WriteLine("SetUpsideDownPrinting");
          break;

        case 0x74 when EscPosCommandsESC.SetCharacterCodeTable[1] == verb:
          Console.WriteLine("SetCharacterCodeTable");
          break;

        case 0x56 when EscPosCommandsESC.Turn90DegreeRotationMode[1] == verb:
          Console.WriteLine("Turn90DegreeRotationMode");
          break;

        case 0x55 when EscPosCommandsESC.TurnUnidirectionalPrintMode[1] == verb:
          Console.WriteLine("TurnUnidirectionalPrintMode");
          break;

        case 0x3D when EscPosCommandsESC.SelectPeripheralDevice[1] == verb:
          Console.WriteLine("SelectPeripheralDevice");
          break;

        case 0x44 when EscPosCommandsESC.CancelAllHorizontalTabPositions[1] == verb:
          Console.WriteLine("CancelAllHorizontalTabPositions");
          break;

        case 0x42 when EscPosCommandsESC.SetVerticalTabPositions[1] == verb:
          Console.WriteLine("SetVerticalTabPositions");
          break;

        case 0x42 when EscPosCommandsESC.CancelAllVerticalTabPositions[1] == verb:
          Console.WriteLine("CancelAllVerticalTabPositions");
          break;

        case 0x45 when EscPosCommandsESC.TurnEmphasizedMode[1] == verb:
          Console.WriteLine("TurnEmphasizedMode");
          break;

        case 0x47 when EscPosCommandsESC.TurnDoubleStrikeMode[1] == verb:
          Console.WriteLine("TurnDoubleStrikeMode");
          break;

        case 0x2D when EscPosCommandsESC.TurnUnderlineMode[1] == verb:
          Console.WriteLine("TurnUnderlineMode");
          break;

        case 0x32 when EscPosCommandsESC.SetDefaultLineSpacing[1] == verb:
          Console.WriteLine("SetDefaultLineSpacing");
          break;

        case 0x7B when EscPosCommandsESC.TurnUpsideDownMode[1] == verb:
          Console.WriteLine("TurnUpsideDownMode");
          break;

        case 0x61 when EscPosCommandsESC.SetLeftAlignment[1] == verb:
          Console.WriteLine("SetLeftAlignment");
          break;

        case 0x61 when EscPosCommandsESC.SetCenterAlignment[1] == verb:
          Console.WriteLine("SetCenterAlignment");
          break;

        case 0x61 when EscPosCommandsESC.SetRightAlignment[1] == verb:
          Console.WriteLine("SetRightAlignment");
          break;

        case 0x2A when EscPosCommandsESC.SetBitImageMode[1] == verb:
          Console.WriteLine("SetBitImageMode");
          break;

        case 0x63 when EscPosCommandsESC.SetPaperSensorsToStopPrinting[1] == verb:
          Console.WriteLine("SetPaperSensorsToStopPrinting");
          break;

        case 0x63 when EscPosCommandsESC.SetPaperSensorsToOutputPaperEndSignals[1] == verb:
          Console.WriteLine("SetPaperSensorsToOutputPaperEndSignals");
          break;

        case 0x63 when EscPosCommandsESC.SelectPeripheralDeviceForStatusTransmission[1] == verb:
          Console.WriteLine("SelectPeripheralDeviceForStatusTransmission");
          break;

        default:
          Console.WriteLine($"Unknown ESC command: 0x{verb:X2}");
          break;
      }
    }


    private static void ProcessCommandESC1(byte[] data, StreamWriter writer, ref int i, ref bool bold, ref bool underline, ref int alignment)
    {
      if (i + 1 >= data.Length)
      {
        Console.WriteLine("Incomplete ESC command.");
        return;
      }

      var verb = data[++i];

      switch (verb)
      {
        case 1 when EscPosCommandsESC.SetAbsolutePrintPosition[1] == verb:
          {
            Console.WriteLine("SetAbsolutePrintPosition");
            break;
          }

        case 2 when EscPosCommandsESC.InitializePrinter[1] == verb:
          {
            writer.WriteLine("Stampante inizializzata.");
            break;
          }

        case 3 when EscPosCommandsESC.FeedNLines[1] == verb:
          {
            var linesToFeed = data[++i];
            for (var j = 0; j < linesToFeed; j++)
            {
              writer.WriteLine(); // Inserisci una riga vuota
            }

            break;
          }

        case 0x69:
          writer.WriteLine("--- Carta tagliata (parziale) ---");
          break;
        case 0x45:
          bold = data[++i] == 1;
          break;
        case 0x2D:
          underline = data[++i] == 1;
          break;
        case 0x61:
          {
            alignment = data[++i];
            var alignmentDesc = alignment == 0 ? "Sinistra" : alignment == 1 ? "Centro" : "Destra";
            break;
          }

      }
    }

    private static int ProcessCommandGS(byte[] data, StreamWriter writer, int i)
    {
      var nextByte = data[++i];
      if (nextByte == 0x56) // GS V (Taglio totale della carta)
      {
        writer.WriteLine("--- Carta tagliata (totale) ---");
      }
      else if (nextByte == 0x6B) // GS k (Stampa codice a barre)
      {
        var barcodeType = data[++i]; // Tipo di codice a barre
        var barcodeLength = data[++i]; // Lunghezza del codice a barre
        var barcode = Encoding.ASCII.GetString(data, i + 1, barcodeLength);
        writer.WriteLine($"[Codice a barre ({barcodeType}): {barcode}]");
        i += barcodeLength;
      }

      return i;
    }
  }
}
