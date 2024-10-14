using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ESCPosEmuWizard
{
  internal class EscPosPrinterDriver
  {
    private static void Main(string[] args)
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
          InterpretRawData(rawData);
        }

        client.Close();
      }
    }

    private static void InterpretRawData(byte[] data)
    {



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
      var nextByte = data[++i];
      switch (nextByte)
      {
        case 0x40:
          writer.WriteLine("Stampante inizializzata.");
          break;
        case 0x64:
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
  }
}
