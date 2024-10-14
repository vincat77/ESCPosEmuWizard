namespace ESCPosEmuWizard
{
  internal static class EscPosCommandsGS
  {

    /// <summary>
    /// Cut paper (full cut) - GS V 0
    /// Executes a full cut of the paper.
    /// </summary>
    public static readonly byte[] CutPaperFull = new byte[] { EscPosMainCommands.GS, 0x56, 0x00 };



    /// <summary>
    /// Cut paper (partial cut) - GS V 1
    /// Executes a partial cut of the paper.
    /// </summary>
    public static readonly byte[] CutPaperPartial = new byte[] { EscPosMainCommands.GS, 0x56, 0x01 };

    /// <summary>
    /// Set font size to normal - GS ! 0
    /// Sets the font size to normal.
    /// </summary>
    public static readonly byte[] FontSizeNormal = new byte[] { EscPosMainCommands.GS, 0x21, 0x00 };


    /// <summary>
    /// Set font size to double width - GS ! 32
    /// Sets the font size to double width.
    /// </summary>
    public static readonly byte[] FontSizeDoubleWidth = new byte[] { EscPosMainCommands.GS, 0x21, 0x20 };

    /// <summary>
    /// Set font size to double height and width - GS ! 48
    /// Sets the font size to double height and width.
    /// </summary>
    public static readonly byte[] FontSizeDoubleHeightWidth = new byte[] { EscPosMainCommands.GS, 0x21, 0x30 };

    /// <summary>
    /// Print a barcode - GS k
    /// Prints a barcode (requires additional data encoding).
    /// </summary>
    public static readonly byte[] PrintBarcode = new byte[] { EscPosMainCommands.GS, 0x6B };

    /// <summary>
    /// Print a QR code - GS ( k
    /// Prints a QR code (requires additional data encoding).
    /// </summary>
    public static readonly byte[] PrintQRCode = new byte[] { EscPosMainCommands.GS, 0x28, 0x6B };

    /// <summary>
    /// Feed and cut paper - GS V B n
    /// Feeds the paper and executes a cut.
    /// </summary>
    public static readonly byte[] FeedAndCut = new byte[] { EscPosMainCommands.GS, 0x56, 0x42, 0x00 };

    /// <summary>
    /// Set printing density - ESC GS *
    /// Example: max density.
    /// </summary>
    public static readonly byte[] SetPrintDensity = new byte[] { EscPosMainCommands.GS, 0x7C, 0x07 };

    /// <summary>
    /// Print raster image (start of image data) - GS v 0
    /// Prints a raster image (requires additional data encoding).
    /// </summary>
    public static readonly byte[] PrintRasterImage = new byte[] { EscPosMainCommands.GS, 0x76, 0x30, 0x00 };

    /// <summary>
    /// Enable inverted printing - GS B 1
    /// Enables inverted printing (black background, white text).
    /// </summary>
    public static readonly byte[] EnableInvertedPrinting = new byte[] { EscPosMainCommands.GS, 0x42, 0x01 };

    /// <summary>
    /// Disable inverted printing - GS B 0
    /// Disables inverted printing.
    /// </summary>
    public static readonly byte[] DisableInvertedPrinting = new byte[] { EscPosMainCommands.GS, 0x42, 0x00 };

    /// <summary>
    /// Set character size - GS ! n
    /// Example: set to double width and height.
    /// </summary>
    public static readonly byte[] SetCharacterSizeDoubleWidthHeight = new byte[] { EscPosMainCommands.GS, 0x21, 0x11 };

    /// <summary>
    /// Turn white/black reverse printing mode on - GS B 1
    /// Turns on reverse printing (white text on black background).
    /// </summary>
    public static readonly byte[] ReversePrintingOn = new byte[] { EscPosMainCommands.GS, 0x42, 0x01 };

    /// <summary>
    /// Turn white/black reverse printing mode off - GS B 0
    /// Turns off reverse printing.
    /// </summary>
    public static readonly byte[] ReversePrintingOff = new byte[] { EscPosMainCommands.GS, 0x42, 0x00 };

    /// <summary>
    /// Set font size to double height - GS ! 16
    /// Sets the font size to double height.
    /// </summary>
    public static readonly byte[] FontSizeDoubleHeight = new byte[] { EscPosMainCommands.GS, 0x21, 0x10 };

    /// <summary>
    /// Set NV Bit Image - GS v 0
    /// Sets the NV bit image for printing.
    /// </summary>
    public static readonly byte[] SetNVBitImage = new byte[] { EscPosMainCommands.GS, 0x76, 0x30 };

    /// <summary>
    /// Set Cut Mode and Cut Paper - GS V
    /// Sets the cut mode and cuts the paper.
    /// </summary>
    public static readonly byte[] CutPaper = new byte[] { EscPosMainCommands.GS, 0x56 };

    /// <summary>
    /// Execute Test Print - GS ( A
    /// Executes a test print.
    /// </summary>
    public static readonly byte[] ExecuteTestPrint = new byte[] { EscPosMainCommands.GS, 0x28, 0x41 };



    /// <summary>
    /// Select HRI Character Print Position - GS H
    /// Selects the print position of HRI characters for barcodes.
    /// </summary>
    public static readonly byte[] SelectHRICharacterPrintPosition = new byte[] { EscPosMainCommands.GS, 0x48 };

    /// <summary>
    /// Set Barcode Height - GS h
    /// Sets the height of the barcode.
    /// </summary>
    public static readonly byte[] SetBarcodeHeight = new byte[] { EscPosMainCommands.GS, 0x68 };



    /// <summary>
    /// Set Bar Code Height - GS h n
    /// Sets the height of the bar code in dots.
    /// Example: n = 162 sets the height to 162 dots.
    /// </summary>
    public static readonly byte[] SetBarCodeHeight = new byte[] { EscPosMainCommands.GS, 0x68, 0xA2 };

    /// <summary>
    /// Set Barcode Width - GS w
    /// Sets the width of the barcode.
    /// </summary>
    public static readonly byte[] SetBarcodeWidth = new byte[] { EscPosMainCommands.GS, 0x77 };



    /// <summary>
    /// Print PDF417 Barcode - GS k
    /// Prints a PDF417 barcode.
    /// </summary>
    public static readonly byte[] PrintPDF417 = new byte[] { EscPosMainCommands.GS, 0x6B, 0x65 };


    /// <summary>
    /// Enable/Disable Automatic Status Back (ASB) - GS a
    /// Enables or disables Automatic Status Back (ASB).
    /// </summary>
    public static readonly byte[] EnableDisableASB = new byte[] { EscPosMainCommands.GS, 0x61 };



    /// <summary>
    /// Print Downloaded Bit Image - GS /
    /// Prints a previously defined downloaded bit image.
    /// </summary>
    public static readonly byte[] PrintDownloadedBitImage = new byte[] { EscPosMainCommands.GS, 0x2F };

    /// <summary>
    /// Start/End Macro Definition - GS :
    /// Starts or ends the definition of a macro.
    /// </summary>
    public static readonly byte[] StartEndMacroDefinition = new byte[] { EscPosMainCommands.GS, 0x3A };

    /// <summary>
    /// Execute Macro - GS ^
    /// Executes a defined macro.
    /// </summary>
    public static readonly byte[] ExecuteMacro = new byte[] { EscPosMainCommands.GS, 0x5E };

    /// <summary>
    /// Define and Select Memory Switch Settings - GS ( A n
    /// Defines and selects the memory switch settings.
    /// </summary>
    public static readonly byte[] DefineSelectMemorySwitchSettings = new byte[] { EscPosMainCommands.GS, 0x28, 0x41 };

    /// <summary>
    /// Set Horizontal and Vertical Motion Unit - GS P nL nH
    /// Sets the horizontal and vertical motion units.
    /// </summary>
    public static readonly byte[] SetHorizontalAndVerticalMotionUnit = new byte[] { EscPosMainCommands.GS, 0x50 };

    /// <summary>
    /// Start Macro Definition - GS :
    /// Starts the macro definition.
    /// </summary>
    public static readonly byte[] StartMacroDefinition = new byte[] { EscPosMainCommands.GS, 0x3A };


    /// <summary>
    /// Select PDF417 Symbol - GS k 0
    /// Selects PDF417 symbol for printing.
    /// </summary>
    public static readonly byte[] SelectPDF417Symbol = new byte[] { EscPosMainCommands.GS, 0x6B, 0x30 };

    /// <summary>
    /// Select DataMatrix Symbol - GS k 8
    /// Selects DataMatrix symbol for printing.
    /// </summary>
    public static readonly byte[] SelectDataMatrixSymbol = new byte[] { EscPosMainCommands.GS, 0x6B, 0x38 };

    /// <summary>
    /// Select MaxiCode Symbol - GS k 9
    /// Selects MaxiCode symbol for printing.
    /// </summary>
    public static readonly byte[] SelectMaxiCodeSymbol = new byte[] { EscPosMainCommands.GS, 0x6B, 0x39 };

    /// <summary>
    /// Print a Graphic Symbol - GS ( L
    /// Prints a graphical symbol like a logo.
    /// </summary>
    public static readonly byte[] PrintGraphicSymbol = new byte[] { EscPosMainCommands.GS, 0x28, 0x4C };

    /// <summary>
    /// Set Paper Feed Length - GS f n
    /// Sets the paper feed length in inches.
    /// </summary>
    public static readonly byte[] SetPaperFeedLength = new byte[] { EscPosMainCommands.GS, 0x66 };


    /// <summary>
    /// Select Barcode Type - GS k m d1...dk NUL
    /// Selects the type of barcode to print.
    /// </summary>
    public static readonly byte[] SelectBarcodeType = new byte[] { EscPosMainCommands.GS, 0x6B };

    /// <summary>
    /// Select QR Code Type - GS ( k
    /// Selects the type of QR code to print.
    /// </summary>
    public static readonly byte[] SelectQRCodeType = new byte[] { EscPosMainCommands.GS, 0x28, 0x6B };

    /// <summary>
    /// Set Motion Units - GS P nL nH
    /// Sets the horizontal and vertical motion units.
    /// </summary>
    public static readonly byte[] SetMotionUnits = new byte[] { EscPosMainCommands.GS, 0x50 };

    /// <summary>
    /// Enable Reverse Printing - GS B 1
    /// Enables reverse printing (white text on black background).
    /// </summary>
    public static readonly byte[] EnableReversePrinting = new byte[] { EscPosMainCommands.GS, 0x42, 0x01 };

    /// <summary>
    /// Disable Reverse Printing - GS B 0
    /// Disables reverse printing.
    /// </summary>
    public static readonly byte[] DisableReversePrinting = new byte[] { EscPosMainCommands.GS, 0x42, 0x00 };




    /// <summary>
    /// Select HRI Character Font - GS f n
    /// Selects the font for Human Readable Interpretation (HRI) characters in barcodes.
    /// </summary>
    public static readonly byte[] SelectHRICharacterFont = new byte[] { EscPosMainCommands.GS, 0x66 };

    /// <summary>
    /// Set QR Code Model - GS ( k
    /// Sets the model of the QR code.
    /// </summary>
    public static readonly byte[] SetQRCodeModel = new byte[] { EscPosMainCommands.GS, 0x28, 0x6B };

    /// <summary>
    /// Set QR Code Module Size - GS ( k
    /// Sets the module size of the QR code.
    /// </summary>
    public static readonly byte[] SetQRCodeModuleSize = new byte[] { EscPosMainCommands.GS, 0x28, 0x6B };

    /// <summary>
    /// Set QR Code Error Correction Level - GS ( k
    /// Sets the error correction level of the QR code.
    /// </summary>
    public static readonly byte[] SetQRCodeErrorCorrectionLevel = new byte[] { EscPosMainCommands.GS, 0x28, 0x6B };

    /// <summary>
    /// Store QR Code Data - GS ( k
    /// Stores data for QR code in the symbol storage area.
    /// </summary>
    public static readonly byte[] StoreQRCodeData = new byte[] { EscPosMainCommands.GS, 0x28, 0x6B };

    /// <summary>
    /// Print Stored QR Code Data - GS ( k
    /// Prints the QR code stored in the symbol storage area.
    /// </summary>
    public static readonly byte[] PrintStoredQRCodeData = new byte[] { EscPosMainCommands.GS, 0x28, 0x6B };

    /// <summary>
    /// Set Printing Area Width - GS ( W
    /// Configures the width of the printing area.
    /// </summary>
    public static readonly byte[] SetPrintingAreaWidth = new byte[] { EscPosMainCommands.GS, 0x28, 0x57 };

    /// <summary>
    /// Set PDF417 Parameters - GS ( k
    /// Sets parameters for PDF417 barcode.
    /// </summary>
    public static readonly byte[] SetPDF417Parameters = new byte[] { EscPosMainCommands.GS, 0x28, 0x6B };

    /// <summary>
    /// Set DataMatrix Parameters - GS ( k
    /// Sets parameters for DataMatrix barcode.
    /// </summary>
    public static readonly byte[] SetDataMatrixParameters = new byte[] { EscPosMainCommands.GS, 0x28, 0x6B };

    /// <summary>
    /// Set MaxiCode Parameters - GS ( k
    /// Sets parameters for MaxiCode symbol.
    /// </summary>
    public static readonly byte[] SetMaxiCodeParameters = new byte[] { EscPosMainCommands.GS, 0x28, 0x6B };

    /// <summary>
    /// Store Data in Symbol Storage Area (PDF417) - GS ( k
    /// Stores data for PDF417 in the symbol storage area.
    /// </summary>
    public static readonly byte[] StorePDF417Data = new byte[] { EscPosMainCommands.GS, 0x28, 0x6B };

    /// <summary>
    /// Print Stored PDF417 Data - GS ( k
    /// Prints the PDF417 code stored in the symbol storage area.
    /// </summary>
    public static readonly byte[] PrintStoredPDF417Data = new byte[] { EscPosMainCommands.GS, 0x28, 0x6B };


    /// <summary>
    /// Set Barcode Print Position - GS H n
    /// Sets the print position of HRI characters for barcodes.
    /// </summary>
    public static readonly byte[] SetBarcodePrintPosition = new byte[] { EscPosMainCommands.GS, 0x48 };

    /// <summary>
    /// Set Character Size - GS ! n
    /// Sets the character size.
    /// n = (height multiplier << 4) | width multiplier
    /// </summary>
    public static readonly byte[] SetCharacterSize = new byte[] { EscPosMainCommands.GS, 0x21 };

    /// <summary>
    /// Select/Cancel Inverted Printing Mode - GS B n
    /// Enables or disables inverted printing (white on black).
    /// n = 0: Inverted mode off
    /// n = 1: Inverted mode on
    /// </summary>
    public static readonly byte[] SetInvertedPrintingMode = new byte[] { EscPosMainCommands.GS, 0x42 };


    /// <summary>
    /// Set Smooth Printing Mode - GS b n
    /// Enables or disables smooth (smoothing) mode.
    /// n = 0: Smooth mode off
    /// n = 1: Smooth mode on
    /// </summary>
    public static readonly byte[] SetSmoothPrintingMode = new byte[] { EscPosMainCommands.GS, 0x62 };

    /// <summary>
    /// Set Printing Position for HRI Characters - GS H n
    /// Sets the printing position of Human Readable Interpretation (HRI) characters.
    /// n = 0: Not printed
    /// n = 1: Above the barcode
    /// n = 2: Below the barcode
    /// n = 3: Both above and below the barcode
    /// </summary>
    public static readonly byte[] SetHRIPrintingPosition = new byte[] { EscPosMainCommands.GS, 0x48 };

    /// <summary>
    /// Set HRI Character Font - GS f n
    /// Sets the font of HRI characters.
    /// n = 0: Font A
    /// n = 1: Font B
    /// </summary>
    public static readonly byte[] SetHRIFont = new byte[] { EscPosMainCommands.GS, 0x66 };


    /// <summary>
    /// Set Barcode Type and Print - GS k m d1...dk NUL
    /// Sets the barcode type and prints it.
    /// </summary>
    public static readonly byte[] SetBarcodeTypeAndPrint = new byte[] { EscPosMainCommands.GS, 0x6B };

    /// <summary>
    /// Enable/Disable Automatic Status Back (ASB) - GS a n
    /// Enables or disables Automatic Status Back (ASB).
    /// </summary>
    public static readonly byte[] EnableDisableAutomaticStatusBack = new byte[] { EscPosMainCommands.GS, 0x61 };



    /// <summary>
    /// Transmit Key Code - GS ( A pL pH 01 00
    /// Transmits the key code when a key is pressed.
    /// </summary>
    public static readonly byte[] TransmitKeyCode = new byte[] { EscPosMainCommands.GS, 0x28, 0x41 };

    /// <summary>
    /// Set Motion Unit - GS P x y
    /// Sets the horizontal and vertical motion units.
    /// </summary>
    public static readonly byte[] SetMotionUnit = new byte[] { EscPosMainCommands.GS, 0x50 };

    /// <summary>
    /// Set Left Margin - GS L nL nH
    /// Sets the left margin.
    /// </summary>
    public static readonly byte[] SetLeftMargin = new byte[] { EscPosMainCommands.GS, 0x4C };

    /// <summary>
    /// Set Printable Area Width - GS W nL nH
    /// Sets the width of the printable area.
    /// </summary>
    public static readonly byte[] SetPrintableAreaWidth = new byte[] { EscPosMainCommands.GS, 0x57 };

    /// <summary>
    /// Set Absolute Vertical Print Position in Page Mode - GS $ nL nH
    /// Sets the absolute vertical print position in page mode.
    /// </summary>
    public static readonly byte[] SetAbsoluteVerticalPrintPositionInPageMode = new byte[] { EscPosMainCommands.GS, 0x24 };

    /// <summary>
    /// Set Relative Vertical Print Position in Page Mode - GS \ nL nH
    /// Sets the relative vertical print position in page mode.
    /// </summary>
    public static readonly byte[] SetRelativeVerticalPrintPositionInPageMode = new byte[] { EscPosMainCommands.GS, 0x5C };

    /// <summary>
    /// Set Horizontal and Vertical Motion Units - GS P x y
    /// Sets the horizontal and vertical motion units.
    /// </summary>
    public static readonly byte[] SetHorizontalVerticalMotionUnits = new byte[] { EscPosMainCommands.GS, 0x50 };

    /// <summary>
    /// Define Downloaded Bit Image - GS * x y [d]...
    /// Defines a downloaded bit image.
    /// </summary>
    public static readonly byte[] DefineDownloadedBitImage = new byte[] { EscPosMainCommands.GS, 0x2A };



    /// <summary>
    /// Set Print Area Width - GS W nL nH
    /// Sets the width of the print area.
    /// </summary>
    public static readonly byte[] SetPrintAreaWidth = new byte[] { EscPosMainCommands.GS, 0x57 };

    /// <summary>
    /// Turn Smoothing Mode On/Off - GS b n
    /// Enables or disables smoothing mode for bit images and downloaded bit images.
    /// n = 0: Smoothing mode off
    /// n = 1: Smoothing mode on
    /// </summary>
    public static readonly byte[] TurnSmoothingMode = new byte[] { EscPosMainCommands.GS, 0x62 };


    /// <summary>
    /// Transmit Printer ID - GS I n
    /// Transmits the printer ID.
    /// </summary>
    public static readonly byte[] TransmitPrinterID = new byte[] { EscPosMainCommands.GS, 0x49 };
  }
}
