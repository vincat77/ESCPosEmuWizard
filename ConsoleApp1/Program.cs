﻿using System.Collections;
using System.Net.Sockets;
using ESCPosEmuWizard;

namespace ConsoleApp1
{
  internal class Program
  {
    public static void Main(string[] args)
    {
      for (int i = 0; i < 1000; i++)
      {
        NewMethod();

      }

      Console.ReadLine();
    }

    private static void NewMethod()
    {
      string printerIp = "127.0.0.1"; // Indirizzo IP della stampante
      int printerPort = 9100; // Porta della stampante
      byte[] initializeCommand = EscPosCommandsESC.InitializePrinter; // Comando di inizializzazione della stampante

      // Act
      using (TcpClient client = new TcpClient(printerIp, printerPort))
      {
        NetworkStream stream = client.GetStream();

        // Invia il comando di inizializzazione alla stampante
        stream.Write(initializeCommand, 0, initializeCommand.Length);
        stream.Flush();

        Console.WriteLine($"La connessione alla stampante:{client.Connected}.");
        if (true)
        {
          // Comando per richiedere lo stato della stampante
          byte[] requestStatusCommand = new byte[] { 0x10, 0x04, 0x01 }; // DLE EOT 1 - richiede lo stato del dispositivo

          // Invia il comando di richiesta di stato alla stampante
          stream.Write(requestStatusCommand, 0, requestStatusCommand.Length);
          stream.Flush();

          // Legge la risposta della stampante
          byte[] responseBuffer = new byte[1];

          using (var ms = new MemoryStream())
          {
            byte[] buffer = new byte[1024]; // Buffer di lettura (1 KB alla volta)
            int bytesRead;
            Thread.Sleep(10);
            // Continua a leggere fino a quando ci sono dati nel flusso
            // while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0 )
            while (stream.CanRead &&stream.DataAvailable )
            {

              bytesRead = stream.Read(buffer, 0, buffer.Length);
              // Scrivi i dati letti nello stream di memoria
              ms.Write(buffer, 0, bytesRead);

              // Se hai ricevuto un blocco di dati completo, puoi processarlo
              var rawData = ms.ToArray();
              Console.WriteLine(string.Join("", rawData.Select(b => b.ToString("X2"))));
              // Svuota lo svtream di memoria per il prossimo comando
              ms.SetLength(0); // Reset della memoria
            }
          }



        }

      }
    }
  }
}
