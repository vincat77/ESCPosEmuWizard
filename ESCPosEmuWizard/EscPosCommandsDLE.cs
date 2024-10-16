namespace ESCPosEmuWizard
{
  internal static class EscPosCommandsDLE
  {

    /// <summary>
    /// Transmit Status - DLE EOT n
    /// Transmits the selected printer status.
    /// n = 1: Printer status
    /// n = 2: Offline status
    /// n = 3: Error status
    /// n = 4: Paper roll sensor status
    /// </summary>
    public static readonly byte[] TransmitStatus = new byte[] { EscPosMainCommands.DLE, 0x04 };

    /// <summary>
    /// Clear Buffer - DLE DC4 8
    /// Clears the printer's buffer(s).
    /// </summary>
    public static readonly byte[] ClearBuffer = new byte[] { EscPosMainCommands.DLE, 0x14, 0x08 };

    /// <summary>
    /// Transmit Specified Status - DLE DC4 7
    /// Transmits the specified status in real time.
    /// </summary>
    public static readonly byte[] TransmitSpecifiedStatus = new byte[] { EscPosMainCommands.DLE, 0x14, 0x07 };

    /// <summary>
    /// Request printer status - DLE EOT 1
    /// Requests the current printer status.
    /// </summary>
    public static readonly byte[] RequestPrinterStatus = new byte[] { EscPosMainCommands.DLE, 0x04, 0x01 };

    /// <summary>
    /// Execute Power-off Sequence - DLE DC4 2
    /// Executes the printer's power-off sequence.
    /// </summary>
    public static readonly byte[] ExecutePowerOff = new byte[] { EscPosMainCommands.DLE, 0x14, 0x02 };

    /// <summary>
    /// Real-Time Request to Printer - DLE ENQ n
    /// Requests the printer to send its status in real-time.
    /// </summary>
    public static readonly byte[] RealTimeRequestToPrinter = new byte[] { EscPosMainCommands.DLE, 0x05 };

    /// <summary>
    /// Generate Pulse - DLE DC4 n m t
    /// Generates a pulse for the specified device.
    /// </summary>
    public static readonly byte[] GeneratePulseDLE = new byte[] { EscPosMainCommands.DLE, 0x14 };

  }
}
