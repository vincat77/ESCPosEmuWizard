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
          if (currentByte == EscPosCommands.ESC) // ESC
          {
            var nextByte = data[++i];
            if (nextByte == 0x40) // ESC @ (Initialize Printer)
            {
              writer.WriteLine("Stampante inizializzata.");
            }
            else if (nextByte == 0x64) // ESC d n (Aggiungi righe vuote)
            {
              var linesToFeed = data[++i];
              for (var j = 0; j < linesToFeed; j++)
              {
                writer.WriteLine(); // Inserisci una riga vuota
              }
            }
            else if (nextByte == 0x69) // ESC i (Taglio parziale della carta)
            {
              writer.WriteLine("--- Carta tagliata (parziale) ---");
            }
            else if (nextByte == 0x45) // ESC E (Abilita/disabilita grassetto)
            {
              bold = data[++i] == 1;
            }
            else if (nextByte == 0x2D) // ESC - (Abilita/disabilita sottolineatura)
            {
              underline = data[++i] == 1;
            }
            else if (nextByte == 0x61) // ESC a (Allineamento del testo)
            {
              alignment = data[++i];
              var alignmentDesc = alignment == 0 ? "Sinistra" : alignment == 1 ? "Centro" : "Destra";
            }
          }
          else if (currentByte == 0x1D) // GS (Comandi grafici e codici a barre)
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
          }
          else
          {
            // Stampa carattere normale
            var formattedText = FormatText((char)currentByte, bold, underline, alignment);
            writer.Write(formattedText);
            Console.Write(formattedText);
          }

          i++;
        }
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
  }
}
