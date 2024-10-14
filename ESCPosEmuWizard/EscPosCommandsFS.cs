namespace ESCPosEmuWizard
{
  internal static class EscPosCommandsFS
  {



    /// <summary>
    /// Transmit Paper-End Sensor Status - ESC v
    /// Transmits the status of the paper-end sensors.
    /// </summary>
    public static readonly byte[] TransmitPaperEndSensorStatus = new byte[] { EscPosMainCommands.ESC, 0x76 };

    /// <summary>
    /// Select Kanji Character Mode - FS &
    /// Selects Kanji character mode.
    /// </summary>
    public static readonly byte[] SelectKanjiCharacterMode = new byte[] { EscPosMainCommands.FS, 0x26 };

    /// <summary>
    /// Cancel Kanji Character Mode - FS .
    /// Cancels Kanji character mode.
    /// </summary>
    public static readonly byte[] CancelKanjiCharacterMode = new byte[] { EscPosMainCommands.FS, 0x2E };

    /// <summary>
    /// Set Kanji Character Spacing - FS S
    /// Sets the spacing between Kanji characters.
    /// </summary>
    public static readonly byte[] SetKanjiCharacterSpacing = new byte[] { EscPosMainCommands.FS, 0x53 };

    /// <summary>
    /// Turn Quadruple-Size Mode for Kanji Characters On/Off - FS W
    /// Turns on or off quadruple-size mode for Kanji characters.
    /// </summary>
    public static readonly byte[] QuadrupleSizeKanjiCharacters = new byte[] { EscPosMainCommands.FS, 0x57 };

    /// <summary>
    /// Define User-Defined Kanji Characters - FS 2
    /// Defines user-defined Kanji characters.
    /// </summary>
    public static readonly byte[] DefineUserDefinedKanjiCharacters = new byte[] { EscPosMainCommands.FS, 0x32 };

    /// <summary>
    /// Cancel User-Defined Kanji Characters - FS ?
    /// Cancels user-defined Kanji characters.
    /// </summary>
    public static readonly byte[] CancelUserDefinedKanjiCharacters = new byte[] { EscPosMainCommands.FS, 0x3F };

    /// <summary>
    /// Set Character Code System - FS C n
    /// Sets the character code system.
    /// </summary>
    public static readonly byte[] SetCharacterCodeSystem = new byte[] { EscPosMainCommands.FS, 0x43 };

    /// <summary>
    /// Select NV Bit Image and Print - FS q
    /// – Selects an NV bit image and prints it.
    /// </summary>
    public static readonly byte[] SelectNVBitImageAndPrint = new byte[] { EscPosMainCommands.FS, 0x71 };

    /// <summary>
    /// Select a character code system - FS C n
    /// Selects the character code system.
    /// </summary>
    public static readonly byte[] SelectCharacterCodeSystem = new byte[] { EscPosMainCommands.FS, 0x43 };

    /// <summary>
    /// NV Graphics Printing - FS q n
    /// Prints NV graphics stored in the printer.
    /// </summary>
    public static readonly byte[] NVGraphicsPrinting = new byte[] { EscPosMainCommands.FS, 0x71 };



    /// <summary>
    /// Manage NV Images - FS q
    /// Manages NV images for storing and printing.
    /// </summary>
    public static readonly byte[] ManageNVImages = new byte[] { EscPosMainCommands.FS, 0x71 };

    /// <summary>
    /// Define NV Bit Image - FS q
    /// Defines a non-volatile (NV) bit image.
    /// </summary>
    public static readonly byte[] DefineNVBitImage = new byte[] { EscPosMainCommands.FS, 0x71 };

    /// <summary>
    /// Print NV Bit Image - FS p n m
    /// Prints a defined NV bit image.
    /// </summary>
    public static readonly byte[] PrintNVBitImage = new byte[] { EscPosMainCommands.FS, 0x70 };
  }
}
