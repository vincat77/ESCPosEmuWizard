namespace ESCPosEmuWizard
{
  public static class EscPosCommands
  {
    public const int ESC = 0x1B;
    public const int DLE = 0x10;
    public const int GS = 0x1D;
    public const int FS = 0x1C;


    /// <summary>
    /// Clear Buffer - DLE DC4 8
    /// Clears the printer's buffer(s).
    /// </summary>
    public static readonly byte[] ClearBuffer = new byte[] { DLE, 0x14, 0x08 };

    /// <summary>
    /// Transmit Specified Status - DLE DC4 7
    /// Transmits the specified status in real time.
    /// </summary>
    public static readonly byte[] TransmitSpecifiedStatus = new byte[] { DLE, 0x14, 0x07 };

    /// <summary>
    /// Set absolute print position - ESC $
    /// Sets the absolute print position.
    /// </summary>
    public static readonly byte[] SetAbsolutePrintPosition = new byte[] { ESC, 0x24 };

    /// <summary>
    /// Set relative print position - ESC \
    /// Sets the relative print position to the current position.
    /// </summary>
    public static readonly byte[] SetRelativePrintPosition = new byte[] { ESC, 0x5C };

    /// <summary>
    /// Horizontal Tab - HT
    /// Inserts a horizontal tab.
    /// </summary>
    public static readonly byte[] HorizontalTab = new byte[] { 0x09 };

    /// <summary>
    /// Carriage Return - CR
    /// Prints and returns to the beginning of the current line.
    /// </summary>
    public static readonly byte[] CarriageReturn = new byte[] { 0x0D };

    /// <summary>
    /// Form Feed - FF
    /// Ends the job in standard mode or returns to standard mode in page mode.
    /// </summary>
    public static readonly byte[] FormFeed = new byte[] { 0x0C };

    /// <summary>
    /// Cut paper (full cut) - GS V 0
    /// Executes a full cut of the paper.
    /// </summary>
    public static readonly byte[] CutPaperFull = new byte[] { GS, 0x56, 0x00 };




    /// <summary>
    /// Reset command - ESC @
    /// Resets the printer to its initial state.
    /// </summary>
    public static readonly byte[] InitializePrinter = new byte[] { ESC, 0x40 };

    /// <summary>
    /// Line feed (advance paper by one line) - LF
    /// Advances the paper by one line.
    /// </summary>
    public static readonly byte[] LineFeed = new byte[] { 0x0A };



    /// <summary>
    /// Cut paper (partial cut) - GS V 1
    /// Executes a partial cut of the paper.
    /// </summary>
    public static readonly byte[] CutPaperPartial = new byte[] { GS, 0x56, 0x01 };

    /// <summary>
    /// Bold text on - ESC E 1
    /// Enables bold text.
    /// </summary>
    public static readonly byte[] TextBoldOn = new byte[] { ESC, 0x45, 0x01 };

    /// <summary>
    /// Bold text off - ESC E 0
    /// Disables bold text.
    /// </summary>
    public static readonly byte[] TextBoldOff = new byte[] { ESC, 0x45, 0x00 };

    /// <summary>
    /// Underline text on - ESC - 1
    /// Enables underlined text.
    /// </summary>
    public static readonly byte[] TextUnderlineOn = new byte[] { ESC, 0x2D, 0x01 };

    /// <summary>
    /// Underline text off - ESC - 0
    /// Disables underlined text.
    /// </summary>
    public static readonly byte[] TextUnderlineOff = new byte[] { ESC, 0x2D, 0x00 };

    /// <summary>
    /// Align text to the left - ESC a 0
    /// Aligns text to the left.
    /// </summary>
    public static readonly byte[] AlignLeft = new byte[] { ESC, 0x61, 0x00 };

    /// <summary>
    /// Align text to the center - ESC a 1
    /// Aligns text to the center.
    /// </summary>
    public static readonly byte[] AlignCenter = new byte[] { ESC, 0x61, 0x01 };

    /// <summary>
    /// Align text to the right - ESC a 2
    /// Aligns text to the right.
    /// </summary>
    public static readonly byte[] AlignRight = new byte[] { ESC, 0x61, 0x02 };

    /// <summary>
    /// Set font size to normal - GS ! 0
    /// Sets the font size to normal.
    /// </summary>
    public static readonly byte[] FontSizeNormal = new byte[] { GS, 0x21, 0x00 };


    /// <summary>
    /// Set font size to double width - GS ! 32
    /// Sets the font size to double width.
    /// </summary>
    public static readonly byte[] FontSizeDoubleWidth = new byte[] { GS, 0x21, 0x20 };

    /// <summary>
    /// Set font size to double height and width - GS ! 48
    /// Sets the font size to double height and width.
    /// </summary>
    public static readonly byte[] FontSizeDoubleHeightWidth = new byte[] { GS, 0x21, 0x30 };

    /// <summary>
    /// Print a barcode - GS k
    /// Prints a barcode (requires additional data encoding).
    /// </summary>
    public static readonly byte[] PrintBarcode = new byte[] { GS, 0x6B };

    /// <summary>
    /// Print a QR code - GS ( k
    /// Prints a QR code (requires additional data encoding).
    /// </summary>
    public static readonly byte[] PrintQRCode = new byte[] { GS, 0x28, 0x6B };

    /// <summary>
    /// Request printer status - DLE EOT 1
    /// Requests the current printer status.
    /// </summary>
    public static readonly byte[] RequestPrinterStatus = new byte[] { DLE, 0x04, 0x01 };

    /// <summary>
    /// Feed and cut paper - GS V B n
    /// Feeds the paper and executes a cut.
    /// </summary>
    public static readonly byte[] FeedAndCut = new byte[] { GS, 0x56, 0x42, 0x00 };

    /// <summary>
    /// Set printing density - ESC GS *
    /// Example: max density.
    /// </summary>
    public static readonly byte[] SetPrintDensity = new byte[] { GS, 0x7C, 0x07 };

    /// <summary>
    /// Print raster image (start of image data) - GS v 0
    /// Prints a raster image (requires additional data encoding).
    /// </summary>
    public static readonly byte[] PrintRasterImage = new byte[] { GS, 0x76, 0x30, 0x00 };

    /// <summary>
    /// Open cash drawer (pulse to kick-out connector pin 2) - ESC p 0
    /// Sends a pulse to open the cash drawer (pin 2).
    /// </summary>
    public static readonly byte[] OpenCashDrawerPin2 = new byte[] { ESC, 0x70, 0x00, 0x19, 0xFA };

    /// <summary>
    /// Open cash drawer (pulse to kick-out connector pin 5) - ESC p 1
    /// Sends a pulse to open the cash drawer (pin 5).
    /// </summary>
    public static readonly byte[] OpenCashDrawerPin5 = new byte[] { ESC, 0x70, 0x01, 0x19, 0xFA };

    /// <summary>
    /// Enable double-strike mode - ESC G 1
    /// Enables double-strike mode for bold printing.
    /// </summary>
    public static readonly byte[] EnableDoubleStrike = new byte[] { ESC, 0x47, 0x01 };

    /// <summary>
    /// Disable double-strike mode - ESC G 0
    /// Disables double-strike mode.
    /// </summary>
    public static readonly byte[] DisableDoubleStrike = new byte[] { ESC, 0x47, 0x00 };

    /// <summary>
    /// Enable inverted printing - GS B 1
    /// Enables inverted printing (black background, white text).
    /// </summary>
    public static readonly byte[] EnableInvertedPrinting = new byte[] { GS, 0x42, 0x01 };

    /// <summary>
    /// Disable inverted printing - GS B 0
    /// Disables inverted printing.
    /// </summary>
    public static readonly byte[] DisableInvertedPrinting = new byte[] { GS, 0x42, 0x00 };

    /// <summary>
    /// Feed n lines - ESC d n
    /// Example: feed 5 lines.
    /// </summary>
    public static readonly byte[] FeedNLines = new byte[] { ESC, 0x64, 0x05 };

    /// <summary>
    /// Reverse paper feed - ESC e n
    /// Example: reverse feed 3 lines.
    /// </summary>
    public static readonly byte[] ReverseFeedNLines = new byte[] { ESC, 0x65, 0x03 };

    /// <summary>
    /// Set character size - GS ! n
    /// Example: set to double width and height.
    /// </summary>
    public static readonly byte[] SetCharacterSizeDoubleWidthHeight = new byte[] { GS, 0x21, 0x11 };

    /// <summary>
    /// Set line spacing to default - ESC 2
    /// Sets the line spacing to default.
    /// </summary>
    public static readonly byte[] SetLineSpacingDefault = new byte[] { ESC, 0x32 };

    /// <summary>
    /// Set line spacing to 24 dots - ESC 3 n
    /// Example: line spacing of 24 dots.
    /// </summary>
    public static readonly byte[] SetLineSpacing24Dots = new byte[] { ESC, 0x33, 0x18 };

    /// <summary>
    /// Cancel print data in page mode - ESC FF
    /// Cancels all print data in page mode.
    /// </summary>
    public static readonly byte[] CancelPrintData = new byte[] { ESC, 0x0C };

    /// <summary>
    /// Set text color to black - ESC r 0
    /// Sets the text color to black.
    /// </summary>
    public static readonly byte[] SetTextColorBlack = new byte[] { ESC, 0x72, 0x00 };

    /// <summary>
    /// Set text color to red - ESC r 1
    /// Sets the text color to red (if the printer supports dual-color printing).
    /// </summary>
    public static readonly byte[] SetTextColorRed = new byte[] { ESC, 0x72, 0x01 };

    /// <summary>
    /// Select character code table - ESC t n
    /// Selects the character code table.
    /// Example: n = 0 for PC437 (USA, Standard Europe).
    /// </summary>
    public static readonly byte[] SelectCharacterCodeTable = new byte[] { ESC, 0x74, 0x00 };

    /// <summary>
    /// Turn white/black reverse printing mode on - GS B 1
    /// Turns on reverse printing (white text on black background).
    /// </summary>
    public static readonly byte[] ReversePrintingOn = new byte[] { GS, 0x42, 0x01 };

    /// <summary>
    /// Turn white/black reverse printing mode off - GS B 0
    /// Turns off reverse printing.
    /// </summary>
    public static readonly byte[] ReversePrintingOff = new byte[] { GS, 0x42, 0x00 };

    /// <summary>
    /// Set font size to double height - GS ! 16
    /// Sets the font size to double height.
    /// </summary>
    public static readonly byte[] FontSizeDoubleHeight = new byte[] { GS, 0x21, 0x10 };

    /// <summary>
    /// Transmit real-time status - DLE EOT
    /// Transmits the real-time status of the printer.
    /// </summary>
    public static readonly byte[] TransmitRealTimeStatus = new byte[] { DLE, 0x04 };



    /// <summary>
    /// Transmit printer status - ESC r
    /// Transmits the current printer status.
    /// </summary>
    public static readonly byte[] TransmitPrinterStatus = new byte[] { ESC, 0x72 };

    /// <summary>
    /// Print and feed paper - ESC J
    /// Feeds paper by `n` units after printing.
    /// </summary>
    public static readonly byte[] PrintAndFeedPaper = new byte[] { ESC, 0x4A };

    /// <summary>
    /// Sound Buzzer - ESC B
    /// Sounds the buzzer for a specific duration.
    /// </summary>
    public static readonly byte[] SoundBuzzer = new byte[] { ESC, 0x42 };

    /// <summary>
    /// Generate Pulse - ESC p
    /// Generates a pulse to open a cash drawer or similar device.
    /// </summary>
    public static readonly byte[] GeneratePulse = new byte[] { ESC, 0x70 };

    /// <summary>
    /// Enable/Disable Panel Buttons - ESC c 5
    /// Enables or disables the panel buttons.
    /// </summary>
    public static readonly byte[] EnableDisablePanelButtons = new byte[] { ESC, 0x63, 0x35 };





    /// <summary>
    /// Partial Cut Paper (One Point Left Uncut) - ESC i
    /// Executes a partial cut of the paper, leaving one point uncut.
    /// </summary>
    public static readonly byte[] PartialCutPaperOnePoint = new byte[] { ESC, 0x69 };

    /// <summary>
    /// Partial Cut Paper (Three Points Left Uncut) - ESC m
    /// Executes a partial cut of the paper, leaving three points uncut.
    /// </summary>
    public static readonly byte[] PartialCutPaperThreePoints = new byte[] { ESC, 0x6D };

    /// <summary>
    /// Select Bit-Image Mode - ESC *
    /// Selects the bit-image mode for printing images.
    /// </summary>
    public static readonly byte[] SelectBitImageMode = new byte[] { ESC, 0x2A };

    /// <summary>
    /// Set NV Bit Image - GS v 0
    /// Sets the NV bit image for printing.
    /// </summary>
    public static readonly byte[] SetNVBitImage = new byte[] { GS, 0x76, 0x30 };

    /// <summary>
    /// Set Paper Sensors to Output Paper-End Signals - ESC c 3
    /// Sets the paper sensors to output signals when the paper is finished.
    /// </summary>
    public static readonly byte[] SetPaperSensors = new byte[] { ESC, 0x63, 0x33 };

    /// <summary>
    /// Execute Power-off Sequence - DLE DC4 2
    /// Executes the printer's power-off sequence.
    /// </summary>
    public static readonly byte[] ExecutePowerOff = new byte[] { DLE, 0x14, 0x02 };

    /// <summary>
    /// Set Horizontal Tab Positions - ESC D
    /// Sets horizontal tab positions.
    /// </summary>
    public static readonly byte[] SetHorizontalTabPositions = new byte[] { ESC, 0x44 };


    /// <summary>
    /// Select Font A/B/C - ESC M
    /// Selects a font (A, B, or C).
    /// </summary>
    public static readonly byte[] SelectFont = new byte[] { ESC, 0x4D };

    /// <summary>
    /// Turn Upside-Down Mode On/Off - ESC {
    /// Enables or disables upside-down printing.
    /// </summary>
    public static readonly byte[] UpsideDownMode = new byte[] { ESC, 0x7B };

    /// <summary>
    /// Set Character Spacing - ESC SP
    /// Sets the spacing between characters.
    /// </summary>
    public static readonly byte[] SetCharacterSpacing = new byte[] { ESC, 0x20 };

    /// <summary>
    /// Set Cut Mode and Cut Paper - GS V
    /// Sets the cut mode and cuts the paper.
    /// </summary>
    public static readonly byte[] CutPaper = new byte[] { GS, 0x56 };

    /// <summary>
    /// Select Page Mode - ESC L
    /// Selects page mode for printing.
    /// </summary>
    public static readonly byte[] SelectPageMode = new byte[] { ESC, 0x4C };

    /// <summary>
    /// Select Standard Mode - ESC S
    /// Returns to standard printing mode.
    /// </summary>
    public static readonly byte[] SelectStandardMode = new byte[] { ESC, 0x53 };

    /// <summary>
    /// Set Print Area in Page Mode - ESC W
    /// Sets the printing area in page mode.
    /// </summary>
    public static readonly byte[] SetPrintAreaInPageMode = new byte[] { ESC, 0x57 };



    /// <summary>
    /// Transmit Paper-End Sensor Status - ESC v
    /// Transmits the status of the paper-end sensors.
    /// </summary>
    public static readonly byte[] TransmitPaperEndSensorStatus = new byte[] { ESC, 0x76 };

    /// <summary>
    /// Execute Test Print - GS ( A
    /// Executes a test print.
    /// </summary>
    public static readonly byte[] ExecuteTestPrint = new byte[] { GS, 0x28, 0x41 };



    /// <summary>
    /// Select HRI Character Print Position - GS H
    /// Selects the print position of HRI characters for barcodes.
    /// </summary>
    public static readonly byte[] SelectHRICharacterPrintPosition = new byte[] { GS, 0x48 };

    /// <summary>
    /// Set Barcode Height - GS h
    /// Sets the height of the barcode.
    /// </summary>
    public static readonly byte[] SetBarcodeHeight = new byte[] { GS, 0x68 };

    /// <summary>
    /// Set Barcode Width - GS w
    /// Sets the width of the barcode.
    /// </summary>
    public static readonly byte[] SetBarcodeWidth = new byte[] { GS, 0x77 };



    /// <summary>
    /// Print PDF417 Barcode - GS k
    /// Prints a PDF417 barcode.
    /// </summary>
    public static readonly byte[] PrintPDF417 = new byte[] { GS, 0x6B, 0x65 };


    /// <summary>
    /// Enable/Disable Automatic Status Back (ASB) - GS a
    /// Enables or disables Automatic Status Back (ASB).
    /// </summary>
    public static readonly byte[] EnableDisableASB = new byte[] { GS, 0x61 };



    /// <summary>
    /// Print Downloaded Bit Image - GS /
    /// Prints a previously defined downloaded bit image.
    /// </summary>
    public static readonly byte[] PrintDownloadedBitImage = new byte[] { GS, 0x2F };

    /// <summary>
    /// Start/End Macro Definition - GS :
    /// Starts or ends the definition of a macro.
    /// </summary>
    public static readonly byte[] StartEndMacroDefinition = new byte[] { GS, 0x3A };

    /// <summary>
    /// Execute Macro - GS ^
    /// Executes a defined macro.
    /// </summary>
    public static readonly byte[] ExecuteMacro = new byte[] { GS, 0x5E };

    /// <summary>
    /// Select Kanji Character Mode - FS &
    /// Selects Kanji character mode.
    /// </summary>
    public static readonly byte[] SelectKanjiCharacterMode = new byte[] { FS, 0x26 };

    /// <summary>
    /// Cancel Kanji Character Mode - FS .
    /// Cancels Kanji character mode.
    /// </summary>
    public static readonly byte[] CancelKanjiCharacterMode = new byte[] { FS, 0x2E };

    /// <summary>
    /// Set Kanji Character Spacing - FS S
    /// Sets the spacing between Kanji characters.
    /// </summary>
    public static readonly byte[] SetKanjiCharacterSpacing = new byte[] { FS, 0x53 };

    /// <summary>
    /// Turn Quadruple-Size Mode for Kanji Characters On/Off - FS W
    /// Turns on or off quadruple-size mode for Kanji characters.
    /// </summary>
    public static readonly byte[] QuadrupleSizeKanjiCharacters = new byte[] { FS, 0x57 };

    /// <summary>
    /// Define User-Defined Kanji Characters - FS 2
    /// Defines user-defined Kanji characters.
    /// </summary>
    public static readonly byte[] DefineUserDefinedKanjiCharacters = new byte[] { FS, 0x32 };

    /// <summary>
    /// Cancel User-Defined Kanji Characters - FS ?
    /// Cancels user-defined Kanji characters.
    /// </summary>
    public static readonly byte[] CancelUserDefinedKanjiCharacters = new byte[] { FS, 0x3F };

    /// <summary>
    /// Enable/Disable Panel Button Status Transmission - ESC c 4
    /// Enables or disables the panel button status transmission.
    /// </summary>
    public static readonly byte[] EnableDisablePanelButtonStatusTransmission = new byte[] { ESC, 0x63, 0x34 };

    /// <summary>
    /// Select Paper Sensor to Stop Printing - ESC c 4
    /// Selects the paper sensor that will stop printing.
    /// </summary>
    public static readonly byte[] SelectPaperSensorToStopPrinting = new byte[] { ESC, 0x63, 0x34 };

    /// <summary>
    /// Select Paper Sensors to Output Paper-End Signals - ESC c 3
    /// Selects which paper sensors output paper-end signals.
    /// </summary>
    public static readonly byte[] SelectPaperSensorsToOutputPaperEndSignals = new byte[] { ESC, 0x63, 0x33 };

    /// <summary>
    /// Select International Character Set - ESC R
    /// Selects the international character set.
    /// </summary>
    public static readonly byte[] SelectInternationalCharacterSet = new byte[] { ESC, 0x52 };

    /// <summary>
    /// Set Print Direction in Page Mode - ESC T n
    /// Sets the print direction in page mode.
    /// </summary>
    public static readonly byte[] SetPrintDirectionInPageMode = new byte[] { ESC, 0x54 };

    /// <summary>
    /// Select Printing Color - ESC r n
    /// Selects the printing color.
    /// </summary>
    public static readonly byte[] SelectPrintingColor = new byte[] { ESC, 0x72 };

    /// <summary>
    /// Set Character Code System - FS C n
    /// Sets the character code system.
    /// </summary>
    public static readonly byte[] SetCharacterCodeSystem = new byte[] { FS, 0x43 };

    /// <summary>
    /// Enable/Disable Automatic Line Feed - ESC 4
    /// Enables or disables automatic line feed.
    /// </summary>
    public static readonly byte[] EnableDisableAutomaticLineFeed = new byte[] { ESC, 0x34 };

    /// <summary>
    /// Define and Select Memory Switch Settings - GS ( A n
    /// Defines and selects the memory switch settings.
    /// </summary>
    public static readonly byte[] DefineSelectMemorySwitchSettings = new byte[] { GS, 0x28, 0x41 };

    /// <summary>
    /// Set Horizontal and Vertical Motion Unit - GS P nL nH
    /// Sets the horizontal and vertical motion units.
    /// </summary>
    public static readonly byte[] SetHorizontalAndVerticalMotionUnit = new byte[] { GS, 0x50 };

    /// <summary>
    /// Start Macro Definition - GS :
    /// Starts the macro definition.
    /// </summary>
    public static readonly byte[] StartMacroDefinition = new byte[] { GS, 0x3A };


    /// <summary>
    /// Select PDF417 Symbol - GS k 0
    /// Selects PDF417 symbol for printing.
    /// </summary>
    public static readonly byte[] SelectPDF417Symbol = new byte[] { GS, 0x6B, 0x30 };

    /// <summary>
    /// Select DataMatrix Symbol - GS k 8
    /// Selects DataMatrix symbol for printing.
    /// </summary>
    public static readonly byte[] SelectDataMatrixSymbol = new byte[] { GS, 0x6B, 0x38 };

    /// <summary>
    /// Select MaxiCode Symbol - GS k 9
    /// Selects MaxiCode symbol for printing.
    /// </summary>
    public static readonly byte[] SelectMaxiCodeSymbol = new byte[] { GS, 0x6B, 0x39 };

    // --------------------------------

    /// <summary>
    /// Select Double-Width Mode - ESC W
    /// Sets the printing mode to double width.
    /// </summary>
    public static readonly byte[] SelectDoubleWidthMode = new byte[] { ESC, 0x57 };

    /// <summary>
    /// Control Beep or Buzzer - ESC BEL
    /// Activates the beep or buzzer on the printer.
    /// </summary>
    public static readonly byte[] ControlBeepOrBuzzer = new byte[] { 0x07 };



    /// <summary>
    /// Set Bar Code Height - GS h n
    /// Sets the height of the bar code in dots.
    /// Example: n = 162 sets the height to 162 dots.
    /// </summary>
    public static readonly byte[] SetBarCodeHeight = new byte[] { GS, 0x68, 0xA2 };

    /// <summary>
    /// Print a Graphic Symbol - GS ( L
    /// Prints a graphical symbol like a logo.
    /// </summary>
    public static readonly byte[] PrintGraphicSymbol = new byte[] { GS, 0x28, 0x4C };

    /// <summary>
    /// Select Print Mode - ESC ! n
    /// Selects a print mode (standard, emphasized, double height, etc.)
    /// Example: n = 1 selects emphasized mode.
    /// </summary>
    public static readonly byte[] SelectPrintMode = new byte[] { ESC, 0x21, 0x01 };


    /// <summary>
    /// Select or Cancel Left Margin for Printing - ESC <
    /// – Selects or cancels left margin.
    /// </summary>
    public static readonly byte[] SelectCancelLeftMargin = new byte[] { ESC, 0x3C };

    /// <summary>
    /// Enable/Disable Printing - ESC =
    /// – Enables or disables the printer's data reception.
    /// </summary>
    public static readonly byte[] EnableDisablePrinting = new byte[] { ESC, 0x3D };

    /// <summary>
    /// Select NV Bit Image and Print - FS q
    /// – Selects an NV bit image and prints it.
    /// </summary>
    public static readonly byte[] SelectNVBitImageAndPrint = new byte[] { FS, 0x71 };

    // Requests the ink status in real time.
    // </summary>
    public static readonly byte[] TransmitRealTimeInkStatus = new byte[] { ESC, 0x63, 0x04 };

    /// <summary>
    /// Select a character code system - FS C n
    /// Selects the character code system.
    /// </summary>
    public static readonly byte[] SelectCharacterCodeSystem = new byte[] { FS, 0x43 };

    /// <summary>
    /// Transmit real-time request for operator panel - ESC u
    /// Requests the status of the operator panel in real time.
    /// </summary>
    public static readonly byte[] TransmitOperatorPanelStatus = new byte[] { ESC, 0x75 };

    /// <summary>
    /// Download Custom Graphic Data - ESC ( c
    /// Downloads custom graphic data to the printer.
    /// </summary>
    public static readonly byte[] DownloadCustomGraphicData = new byte[] { ESC, 0x28, 0x63 };

    /// <summary>
    /// Partial Cut Command with Parameter - ESC i n
    /// Executes a partial cut with a parameter.
    /// </summary>
    public static readonly byte[] PartialCutWithParameter = new byte[] { ESC, 0x69 };

    /// <summary>
    /// NV Graphics Printing - FS q n
    /// Prints NV graphics stored in the printer.
    /// </summary>
    public static readonly byte[] NVGraphicsPrinting = new byte[] { FS, 0x71 };

    /// <summary>
    /// Enable/Disable Automatic Line Feed after each line - ESC 3 n
    /// Sets automatic line feed on or off.
    /// </summary>
    public static readonly byte[] EnableAutomaticLineFeedAfterLine = new byte[] { ESC, 0x33 };

    /// <summary>
    /// Set Character Font - ESC M n
    /// Sets character font style (Font A, B, or C).
    /// </summary>
    public static readonly byte[] SetCharacterFont = new byte[] { ESC, 0x4D };

    /// <summary>
    /// Set Paper Feed Length - GS f n
    /// Sets the paper feed length in inches.
    /// </summary>
    public static readonly byte[] SetPaperFeedLength = new byte[] { GS, 0x66 };


    /// <summary>
    /// Select Barcode Type - GS k m d1...dk NUL
    /// Selects the type of barcode to print.
    /// </summary>
    public static readonly byte[] SelectBarcodeType = new byte[] { GS, 0x6B };

    /// <summary>
    /// Select QR Code Type - GS ( k
    /// Selects the type of QR code to print.
    /// </summary>
    public static readonly byte[] SelectQRCodeType = new byte[] { GS, 0x28, 0x6B };



    /// <summary>
    /// Manage NV Images - FS q
    /// Manages NV images for storing and printing.
    /// </summary>
    public static readonly byte[] ManageNVImages = new byte[] { FS, 0x71 };

    /// <summary>
    /// Set Top Margin - ESC R n
    /// Sets the top margin for printing.
    /// </summary>
    public static readonly byte[] SetTopMargin = new byte[] { ESC, 0x52 };

    /// <summary>
    /// Set Motion Units - GS P nL nH
    /// Sets the horizontal and vertical motion units.
    /// </summary>
    public static readonly byte[] SetMotionUnits = new byte[] { GS, 0x50 };

    /// <summary>
    /// Enable Reverse Printing - GS B 1
    /// Enables reverse printing (white text on black background).
    /// </summary>
    public static readonly byte[] EnableReversePrinting = new byte[] { GS, 0x42, 0x01 };

    /// <summary>
    /// Disable Reverse Printing - GS B 0
    /// Disables reverse printing.
    /// </summary>
    public static readonly byte[] DisableReversePrinting = new byte[] { GS, 0x42, 0x00 };


    /// <summary>
    /// Select/Cancel User-Defined Character Set - ESC % n
    /// Selects or cancels the user-defined character set.
    /// n = 0: Cancel user-defined character set
    /// n = 1: Select user-defined character set
    /// </summary>
    public static readonly byte[] SelectCancelUserDefinedCharacterSet = new byte[] { ESC, 0x25 };



    /// <summary>
    /// Set Print Area Width - GS W nL nH
    /// Sets the width of the print area.
    /// </summary>
    public static readonly byte[] SetPrintAreaWidth = new byte[] { GS, 0x57 };

    /// <summary>
    /// Set Right-Side Character Spacing - ESC ( C
    /// Sets the right-side character spacing.
    /// </summary>
    public static readonly byte[] SetRightSideCharacterSpacing = new byte[] { ESC, 0x28, 0x43 };

    /// <summary>
    /// Real-Time Request to Printer - DLE ENQ n
    /// Requests the printer to send its status in real-time.
    /// </summary>
    public static readonly byte[] RealTimeRequestToPrinter = new byte[] { DLE, 0x05 };




    /// <summary>
    /// Select HRI Character Font - GS f n
    /// Selects the font for Human Readable Interpretation (HRI) characters in barcodes.
    /// </summary>
    public static readonly byte[] SelectHRICharacterFont = new byte[] { GS, 0x66 };

    /// <summary>
    /// Set QR Code Model - GS ( k
    /// Sets the model of the QR code.
    /// </summary>
    public static readonly byte[] SetQRCodeModel = new byte[] { GS, 0x28, 0x6B };

    /// <summary>
    /// Set QR Code Module Size - GS ( k
    /// Sets the module size of the QR code.
    /// </summary>
    public static readonly byte[] SetQRCodeModuleSize = new byte[] { GS, 0x28, 0x6B };

    /// <summary>
    /// Set QR Code Error Correction Level - GS ( k
    /// Sets the error correction level of the QR code.
    /// </summary>
    public static readonly byte[] SetQRCodeErrorCorrectionLevel = new byte[] { GS, 0x28, 0x6B };

    /// <summary>
    /// Store QR Code Data - GS ( k
    /// Stores data for QR code in the symbol storage area.
    /// </summary>
    public static readonly byte[] StoreQRCodeData = new byte[] { GS, 0x28, 0x6B };

    /// <summary>
    /// Print Stored QR Code Data - GS ( k
    /// Prints the QR code stored in the symbol storage area.
    /// </summary>
    public static readonly byte[] PrintStoredQRCodeData = new byte[] { GS, 0x28, 0x6B };

    /// <summary>
    /// Define NV Bit Image - FS q
    /// Defines a non-volatile (NV) bit image.
    /// </summary>
    public static readonly byte[] DefineNVBitImage = new byte[] { FS, 0x71 };

    /// <summary>
    /// Print NV Bit Image - FS p n m
    /// Prints a defined NV bit image.
    /// </summary>
    public static readonly byte[] PrintNVBitImage = new byte[] { FS, 0x70 };

    /// <summary>
    /// Set Printing Area Width - GS ( W
    /// Configures the width of the printing area.
    /// </summary>
    public static readonly byte[] SetPrintingAreaWidth = new byte[] { GS, 0x28, 0x57 };

    /// <summary>
    /// Set PDF417 Parameters - GS ( k
    /// Sets parameters for PDF417 barcode.
    /// </summary>
    public static readonly byte[] SetPDF417Parameters = new byte[] { GS, 0x28, 0x6B };

    /// <summary>
    /// Set DataMatrix Parameters - GS ( k
    /// Sets parameters for DataMatrix barcode.
    /// </summary>
    public static readonly byte[] SetDataMatrixParameters = new byte[] { GS, 0x28, 0x6B };

    /// <summary>
    /// Set MaxiCode Parameters - GS ( k
    /// Sets parameters for MaxiCode symbol.
    /// </summary>
    public static readonly byte[] SetMaxiCodeParameters = new byte[] { GS, 0x28, 0x6B };

    /// <summary>
    /// Store Data in Symbol Storage Area (PDF417) - GS ( k
    /// Stores data for PDF417 in the symbol storage area.
    /// </summary>
    public static readonly byte[] StorePDF417Data = new byte[] { GS, 0x28, 0x6B };

    /// <summary>
    /// Print Stored PDF417 Data - GS ( k
    /// Prints the PDF417 code stored in the symbol storage area.
    /// </summary>
    public static readonly byte[] PrintStoredPDF417Data = new byte[] { GS, 0x28, 0x6B };


    /// <summary>
    /// Set Barcode Print Position - GS H n
    /// Sets the print position of HRI characters for barcodes.
    /// </summary>
    public static readonly byte[] SetBarcodePrintPosition = new byte[] { GS, 0x48 };

    /// <summary>
    /// Set Underline Mode - ESC - n
    /// Sets underline mode for text.
    /// n = 0: Underline mode off
    /// n = 1: Underline mode 1 dot width
    /// n = 2: Underline mode 2 dot width
    /// </summary>
    public static readonly byte[] SetUnderlineMode = new byte[] { ESC, 0x2D };

    /// <summary>
    /// Set Emphasized Mode - ESC E n
    /// Sets emphasized (bold) mode for text.
    /// n = 0: Emphasized mode off
    /// n = 1: Emphasized mode on
    /// </summary>
    public static readonly byte[] SetEmphasizedMode = new byte[] { ESC, 0x45 };

    /// <summary>
    /// Set Double Strike Mode - ESC G n
    /// Sets double-strike mode for text.
    /// n = 0: Double-strike mode off
    /// n = 1: Double-strike mode on
    /// </summary>
    public static readonly byte[] SetDoubleStrikeMode = new byte[] { ESC, 0x47 };

    /// <summary>
    /// Set Font - ESC M n
    /// Selects a font (A, B, or C).
    /// n = 0: Font A
    /// n = 1: Font B
    /// n = 2: Font C
    /// </summary>
    public static readonly byte[] SetFont = new byte[] { ESC, 0x4D };

    /// <summary>
    /// Set Character Size - GS ! n
    /// Sets the character size.
    /// n = (height multiplier << 4) | width multiplier
    /// </summary>
    public static readonly byte[] SetCharacterSize = new byte[] { GS, 0x21 };

    /// <summary>
    /// Set Upside-Down Printing Mode - ESC { n
    /// Enables or disables upside-down printing.
    /// n = 0: Upside-down mode off
    /// n = 1: Upside-down mode on
    /// </summary>
    public static readonly byte[] SetUpsideDownPrinting = new byte[] { ESC, 0x7B };

    /// <summary>
    /// Select/Cancel Inverted Printing Mode - GS B n
    /// Enables or disables inverted printing (white on black).
    /// n = 0: Inverted mode off
    /// n = 1: Inverted mode on
    /// </summary>
    public static readonly byte[] SetInvertedPrintingMode = new byte[] { GS, 0x42 };


    /// <summary>
    /// Set Smooth Printing Mode - GS b n
    /// Enables or disables smooth (smoothing) mode.
    /// n = 0: Smooth mode off
    /// n = 1: Smooth mode on
    /// </summary>
    public static readonly byte[] SetSmoothPrintingMode = new byte[] { GS, 0x62 };

    /// <summary>
    /// Set Character Code Table - ESC t n
    /// Selects a character code table.
    /// n = code table number (0-255)
    /// </summary>
    public static readonly byte[] SetCharacterCodeTable = new byte[] { ESC, 0x74 };




    /// <summary>
    /// Transmit Status - DLE EOT n
    /// Transmits the selected printer status.
    /// n = 1: Printer status
    /// n = 2: Offline status
    /// n = 3: Error status
    /// n = 4: Paper roll sensor status
    /// </summary>
    public static readonly byte[] TransmitStatus = new byte[] { DLE, 0x04 };

    /// <summary>
    /// Turn 90-Degree Clockwise Rotation Mode On/Off - ESC V n
    /// Turns 90-degree clockwise rotation mode on or off.
    /// n = 0: Rotation mode off
    /// n = 1: Rotation mode on
    /// </summary>
    public static readonly byte[] Turn90DegreeRotationMode = new byte[] { ESC, 0x56 };



    /// <summary>
    /// Turn Unidirectional Print Mode On/Off - ESC U n
    /// Turns unidirectional print mode on or off.
    /// n = 0: Unidirectional mode off (bidirectional printing)
    /// n = 1: Unidirectional mode on
    /// </summary>
    public static readonly byte[] TurnUnidirectionalPrintMode = new byte[] { ESC, 0x55 };

    /// <summary>
    /// Select Peripheral Device - ESC = n
    /// Selects or deselects the printer.
    /// n = 0: Deselect printer
    /// n = 1: Select printer
    /// </summary>
    public static readonly byte[] SelectPeripheralDevice = new byte[] { ESC, 0x3D };

    /// <summary>
    /// Cancel All Horizontal Tab Positions - ESC D NUL
    /// Cancels all horizontal tab positions.
    /// </summary>
    public static readonly byte[] CancelAllHorizontalTabPositions = new byte[] { ESC, 0x44, 0x00 };

    /// <summary>
    /// Set Vertical Tab Positions - ESC B n1 ... nk NUL
    /// Sets vertical tab positions.
    /// </summary>
    public static readonly byte[] SetVerticalTabPositions = new byte[] { ESC, 0x42 };

    /// <summary>
    /// Cancel All Vertical Tab Positions - ESC B NUL
    /// Cancels all vertical tab positions.
    /// </summary>
    public static readonly byte[] CancelAllVerticalTabPositions = new byte[] { ESC, 0x42, 0x00 };

    /// <summary>
    /// Turn Emphasized Mode On/Off - ESC E n
    /// Enables or disables emphasized (bold) mode.
    /// n = 0: Emphasized mode off
    /// n = 1: Emphasized mode on
    /// </summary>
    public static readonly byte[] TurnEmphasizedMode = new byte[] { ESC, 0x45 };

    /// <summary>
    /// Turn Double-Strike Mode On/Off - ESC G n
    /// Enables or disables double-strike mode.
    /// n = 0: Double-strike mode off
    /// n = 1: Double-strike mode on
    /// </summary>
    public static readonly byte[] TurnDoubleStrikeMode = new byte[] { ESC, 0x47 };

    /// <summary>
    /// Turn Underline Mode On/Off - ESC - n
    /// Enables or disables underline mode.
    /// n = 0: Underline mode off
    /// n = 1: Underline mode with 1-dot width
    /// n = 2: Underline mode with 2-dot width
    /// </summary>
    public static readonly byte[] TurnUnderlineMode = new byte[] { ESC, 0x2D };

    /// <summary>
    /// Set Default Line Spacing - ESC 2
    /// Sets line spacing to the default value (approximately 4.23mm).
    /// </summary>
    public static readonly byte[] SetDefaultLineSpacing = new byte[] { ESC, 0x32 };

    /// <summary>
    /// Turn Upside-Down Printing Mode On/Off - ESC { n
    /// Enables or disables upside-down printing.
    /// n = 0: Upside-down mode off
    /// n = 1: Upside-down mode on
    /// </summary>
    public static readonly byte[] TurnUpsideDownMode = new byte[] { ESC, 0x7B };

    /// <summary>
    /// Turn Smoothing Mode On/Off - GS b n
    /// Enables or disables smoothing mode for bit images and downloaded bit images.
    /// n = 0: Smoothing mode off
    /// n = 1: Smoothing mode on
    /// </summary>
    public static readonly byte[] TurnSmoothingMode = new byte[] { GS, 0x62 };

    /// <summary>
    /// Set Left Alignment - ESC a 0
    /// Aligns all data to the left.
    /// </summary>
    public static readonly byte[] SetLeftAlignment = new byte[] { ESC, 0x61, 0x00 };

    /// <summary>
    /// Set Center Alignment - ESC a 1
    /// Centers all data.
    /// </summary>
    public static readonly byte[] SetCenterAlignment = new byte[] { ESC, 0x61, 0x01 };

    /// <summary>
    /// Set Right Alignment - ESC a 2
    /// Aligns all data to the right.
    /// </summary>
    public static readonly byte[] SetRightAlignment = new byte[] { ESC, 0x61, 0x02 };

    /// <summary>
    /// Set Printing Position for HRI Characters - GS H n
    /// Sets the printing position of Human Readable Interpretation (HRI) characters.
    /// n = 0: Not printed
    /// n = 1: Above the barcode
    /// n = 2: Below the barcode
    /// n = 3: Both above and below the barcode
    /// </summary>
    public static readonly byte[] SetHRIPrintingPosition = new byte[] { GS, 0x48 };

    /// <summary>
    /// Set HRI Character Font - GS f n
    /// Sets the font of HRI characters.
    /// n = 0: Font A
    /// n = 1: Font B
    /// </summary>
    public static readonly byte[] SetHRIFont = new byte[] { GS, 0x66 };


    /// <summary>
    /// Set Barcode Type and Print - GS k m d1...dk NUL
    /// Sets the barcode type and prints it.
    /// </summary>
    public static readonly byte[] SetBarcodeTypeAndPrint = new byte[] { GS, 0x6B };

    /// <summary>
    /// Enable/Disable Automatic Status Back (ASB) - GS a n
    /// Enables or disables Automatic Status Back (ASB).
    /// </summary>
    public static readonly byte[] EnableDisableAutomaticStatusBack = new byte[] { GS, 0x61 };

    /// <summary>
    /// Set Bit Image Mode - ESC * m nL nH [d]...
    /// Sets the bit image mode for printing graphics.
    /// </summary>
    public static readonly byte[] SetBitImageMode = new byte[] { ESC, 0x2A };








    /// <summary>
    /// Set Paper Sensor(s) to Stop Printing - ESC c 3 n
    /// Selects which paper sensor(s) stop printing when a paper end is detected.
    /// </summary>
    public static readonly byte[] SetPaperSensorsToStopPrinting = new byte[] { ESC, 0x63, 0x33 };

    /// <summary>
    /// Set Paper Sensor(s) to Output Paper-End Signals - ESC c 4 n
    /// Selects which paper sensor(s) output a paper-end signal.
    /// </summary>
    public static readonly byte[] SetPaperSensorsToOutputPaperEndSignals = new byte[] { ESC, 0x63, 0x34 };

    /// <summary>
    /// Select Peripheral Device to which Status is Transmitted - ESC c 5 n
    /// Selects the peripheral device whose status is transmitted.
    /// </summary>
    public static readonly byte[] SelectPeripheralDeviceForStatusTransmission = new byte[] { ESC, 0x63, 0x35 };


    /// <summary>
    /// Transmit Printer ID - GS I n
    /// Transmits the printer ID.
    /// </summary>
    public static readonly byte[] TransmitPrinterID = new byte[] { GS, 0x49 };



    /// <summary>
    /// Transmit Key Code - GS ( A pL pH 01 00
    /// Transmits the key code when a key is pressed.
    /// </summary>
    public static readonly byte[] TransmitKeyCode = new byte[] { GS, 0x28, 0x41 };

    /// <summary>
    /// Set Motion Unit - GS P x y
    /// Sets the horizontal and vertical motion units.
    /// </summary>
    public static readonly byte[] SetMotionUnit = new byte[] { GS, 0x50 };

    ///// <summary>
    ///// Transmit Status - GS r n
    ///// Transmits the specified status.
    ///// </summary>
    // public static readonly byte[] TransmitStatus = new byte[] { 0x1D, 0x72 };

    /// <summary>
    /// Select Double-Strike Mode - ESC G n
    /// Turns double-strike mode on or off.
    /// n = 0: Off
    /// n = 1: On
    /// </summary>
    public static readonly byte[] SelectDoubleStrikeMode = new byte[] { ESC, 0x47 };

    /// <summary>
    /// Set Left Margin - GS L nL nH
    /// Sets the left margin.
    /// </summary>
    public static readonly byte[] SetLeftMargin = new byte[] { GS, 0x4C };

    /// <summary>
    /// Set Printable Area Width - GS W nL nH
    /// Sets the width of the printable area.
    /// </summary>
    public static readonly byte[] SetPrintableAreaWidth = new byte[] { GS, 0x57 };

    /// <summary>
    /// Select Print Mode(s) - ESC ! n
    /// Selects print mode(s) like emphasized, double-height, double-width, etc.
    /// </summary>
    public static readonly byte[] SelectPrintModes = new byte[] { ESC, 0x21 };


    ////// <summary>
    ////// Set Print Density - GS E n
    ////// Sets the print density and darkness.
    ////// </summary>
    // public static readonly byte[] SetPrintDensity = new byte[] { 0x1D, 0x45 };



    /// <summary>
    /// Define User-Defined Characters - ESC & y c1 c2 [d]...
    /// Defines user-defined characters.
    /// </summary>
    public static readonly byte[] DefineUserDefinedCharacters = new byte[] { ESC, 0x26 };


    /// <summary>
    /// Cancel User-Defined Characters - ESC ? n
    /// Cancels user-defined characters.
    /// </summary>
    public static readonly byte[] CancelUserDefinedCharacters = new byte[] { ESC, 0x3F };


    /// <summary>
    /// Select Print Direction in Page Mode - ESC T n
    /// Selects the print direction in page mode.
    /// </summary>
    public static readonly byte[] SelectPrintDirectionInPageMode = new byte[] { ESC, 0x54 };

    /// <summary>
    /// Set Printing Area in Page Mode - ESC W xL xH yL yH dxL dxH dyL dyH
    /// Sets the printing area in page mode.
    /// </summary>
    public static readonly byte[] SetPrintingAreaInPageMode = new byte[] { ESC, 0x57 };

    /// <summary>
    /// Set Absolute Vertical Print Position in Page Mode - GS $ nL nH
    /// Sets the absolute vertical print position in page mode.
    /// </summary>
    public static readonly byte[] SetAbsoluteVerticalPrintPositionInPageMode = new byte[] { GS, 0x24 };

    /// <summary>
    /// Set Relative Vertical Print Position in Page Mode - GS \ nL nH
    /// Sets the relative vertical print position in page mode.
    /// </summary>
    public static readonly byte[] SetRelativeVerticalPrintPositionInPageMode = new byte[] { GS, 0x5C };

    /// <summary>
    /// Set Horizontal and Vertical Motion Units - GS P x y
    /// Sets the horizontal and vertical motion units.
    /// </summary>
    public static readonly byte[] SetHorizontalVerticalMotionUnits = new byte[] { GS, 0x50 };

    /// <summary>
    /// Define Downloaded Bit Image - GS * x y [d]...
    /// Defines a downloaded bit image.
    /// </summary>
    public static readonly byte[] DefineDownloadedBitImage = new byte[] { GS, 0x2A };

    /// <summary>
    /// Enable/Disable Real-Time Command Responses - DLE DC4 n m t
    /// Controls the real-time command responses.
    /// </summary>
    public static readonly byte[] EnableDisableRealTimeCommandResponses = new byte[] { DLE, 0x14 };

    /// <summary>
    /// Generate Pulse - DLE DC4 n m t
    /// Generates a pulse for the specified device.
    /// </summary>
    public static readonly byte[] GeneratePulseDLE = new byte[] { DLE, 0x14 };

    /// <summary>
    /// Set Vertical Tab - VT
    /// Moves the print position to the next vertical tab position.
    /// </summary>
    public static readonly byte[] VerticalTab = new byte[] { 0x0B };



    /// <summary>
    /// Transmit Paper Sensor Status - ESC v
    /// Transmits the status of the paper sensors.
    /// </summary>
    public static readonly byte[] TransmitPaperSensorStatus = new byte[] { ESC, 0x76 };

    /// <summary>
    /// Transmit Peripheral Device Status - ESC u n
    /// Transmits the status of a connected peripheral device.
    /// </summary>
    public static readonly byte[] TransmitPeripheralDeviceStatus = new byte[] { ESC, 0x75 };

    /// <summary>
    /// Transmit Real-Time Request to Printer - DLE ENQ n
    /// Requests the printer status in real time.
    /// </summary>
    public static readonly byte[] TransmitRealTimeRequestToPrinter = new byte[] { DLE, 0x05 };

    /// <summary>
    /// Cancel Print Data in Page Mode - CAN
    /// Cancels the data in page mode.
    /// </summary>
    public static readonly byte[] CancelPrintDataInPageMode = new byte[] { 0x18 };

    /// <summary>
    /// Enable/Disable Automatic Line Feed - ESC 4 / ESC 5
    /// Enables or disables the automatic line feed.
    /// </summary>
    public static readonly byte[] EnableAutomaticLineFeed = new byte[] { ESC, 0x34 };
    public static readonly byte[] DisableAutomaticLineFeed = new byte[] { ESC, 0x35 };


  }
}
