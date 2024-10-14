namespace ESCPosEmuWizard
{
  public static class EscPosCommandsESC
  {

    /// <summary>
    /// Set absolute print position - ESC $
    /// Sets the absolute print position.
    /// </summary>
    public static readonly byte[] SetAbsolutePrintPosition = new byte[] { EscPosMainCommands.ESC, 0x24 };

    /// <summary>
    /// Set relative print position - ESC \
    /// Sets the relative print position to the current position.
    /// </summary>
    public static readonly byte[] SetRelativePrintPosition = new byte[] { EscPosMainCommands.ESC, 0x5C };

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
    /// Line feed (advance paper by one line) - LF
    /// Advances the paper by one line.
    /// </summary>
    public static readonly byte[] LineFeed = new byte[] { 0x0A };


    /// <summary>
    /// Reset command - ESC @
    /// Resets the printer to its initial state.
    /// </summary>
    public static readonly byte[] InitializePrinter = new byte[] { EscPosMainCommands.ESC, 0x40 };



    /// <summary>
    /// Bold text on - ESC E 1
    /// Enables bold text.
    /// </summary>
    public static readonly byte[] TextBoldOn = new byte[] { EscPosMainCommands.ESC, 0x45, 0x01 };

    /// <summary>
    /// Bold text off - ESC E 0
    /// Disables bold text.
    /// </summary>
    public static readonly byte[] TextBoldOff = new byte[] { EscPosMainCommands.ESC, 0x45, 0x00 };

    /// <summary>
    /// Underline text on - ESC - 1
    /// Enables underlined text.
    /// </summary>
    public static readonly byte[] TextUnderlineOn = new byte[] { EscPosMainCommands.ESC, 0x2D, 0x01 };

    /// <summary>
    /// Underline text off - ESC - 0
    /// Disables underlined text.
    /// </summary>
    public static readonly byte[] TextUnderlineOff = new byte[] { EscPosMainCommands.ESC, 0x2D, 0x00 };

    /// <summary>
    /// Align text to the left - ESC a 0
    /// Aligns text to the left.
    /// </summary>
    public static readonly byte[] AlignLeft = new byte[] { EscPosMainCommands.ESC, 0x61, 0x00 };

    /// <summary>
    /// Align text to the center - ESC a 1
    /// Aligns text to the center.
    /// </summary>
    public static readonly byte[] AlignCenter = new byte[] { EscPosMainCommands.ESC, 0x61, 0x01 };

    /// <summary>
    /// Align text to the right - ESC a 2
    /// Aligns text to the right.
    /// </summary>
    public static readonly byte[] AlignRight = new byte[] { EscPosMainCommands.ESC, 0x61, 0x02 };

    /// <summary>
    /// Open cash drawer (pulse to kick-out connector pin 2) - ESC p 0
    /// Sends a pulse to open the cash drawer (pin 2).
    /// </summary>
    public static readonly byte[] OpenCashDrawerPin2 = new byte[] { EscPosMainCommands.ESC, 0x70, 0x00, 0x19, 0xFA };

    /// <summary>
    /// Open cash drawer (pulse to kick-out connector pin 5) - ESC p 1
    /// Sends a pulse to open the cash drawer (pin 5).
    /// </summary>
    public static readonly byte[] OpenCashDrawerPin5 = new byte[] { EscPosMainCommands.ESC, 0x70, 0x01, 0x19, 0xFA };

    /// <summary>
    /// Enable double-strike mode - ESC G 1
    /// Enables double-strike mode for bold printing.
    /// </summary>
    public static readonly byte[] EnableDoubleStrike = new byte[] { EscPosMainCommands.ESC, 0x47, 0x01 };

    /// <summary>
    /// Disable double-strike mode - ESC G 0
    /// Disables double-strike mode.
    /// </summary>
    public static readonly byte[] DisableDoubleStrike = new byte[] { EscPosMainCommands.ESC, 0x47, 0x00 };

    /// <summary>
    /// Feed n lines - ESC d n
    /// Example: feed 5 lines.
    /// </summary>
    public static readonly byte[] FeedNLines = new byte[] { EscPosMainCommands.ESC, 0x64, 0x05 };

    /// <summary>
    /// Reverse paper feed - ESC e n
    /// Example: reverse feed 3 lines.
    /// </summary>
    public static readonly byte[] ReverseFeedNLines = new byte[] { EscPosMainCommands.ESC, 0x65, 0x03 };

    /// <summary>
    /// Set line spacing to default - ESC 2
    /// Sets the line spacing to default.
    /// </summary>
    public static readonly byte[] SetLineSpacingDefault = new byte[] { EscPosMainCommands.ESC, 0x32 };

    /// <summary>
    /// Set line spacing to 24 dots - ESC 3 n
    /// Example: line spacing of 24 dots.
    /// </summary>
    public static readonly byte[] SetLineSpacing24Dots = new byte[] { EscPosMainCommands.ESC, 0x33, 0x18 };

    /// <summary>
    /// Cancel print data in page mode - ESC FF
    /// Cancels all print data in page mode.
    /// </summary>
    public static readonly byte[] CancelPrintData = new byte[] { EscPosMainCommands.ESC, 0x0C };

    /// <summary>
    /// Set text color to black - ESC r 0
    /// Sets the text color to black.
    /// </summary>
    public static readonly byte[] SetTextColorBlack = new byte[] { EscPosMainCommands.ESC, 0x72, 0x00 };

    /// <summary>
    /// Set text color to red - ESC r 1
    /// Sets the text color to red (if the printer supports dual-color printing).
    /// </summary>
    public static readonly byte[] SetTextColorRed = new byte[] { EscPosMainCommands.ESC, 0x72, 0x01 };

    /// <summary>
    /// Select character code table - ESC t n
    /// Selects the character code table.
    /// Example: n = 0 for PC437 (USA, Standard Europe).
    /// </summary>
    public static readonly byte[] SelectCharacterCodeTable = new byte[] { EscPosMainCommands.ESC, 0x74, 0x00 };



    /// <summary>
    /// Transmit printer status - ESC r
    /// Transmits the current printer status.
    /// </summary>
    public static readonly byte[] TransmitPrinterStatus = new byte[] { EscPosMainCommands.ESC, 0x72 };

    /// <summary>
    /// Print and feed paper - ESC J
    /// Feeds paper by `n` units after printing.
    /// </summary>
    public static readonly byte[] PrintAndFeedPaper = new byte[] { EscPosMainCommands.ESC, 0x4A };

    /// <summary>
    /// Sound Buzzer - ESC B
    /// Sounds the buzzer for a specific duration.
    /// </summary>
    public static readonly byte[] SoundBuzzer = new byte[] { EscPosMainCommands.ESC, 0x42 };

    /// <summary>
    /// Generate Pulse - ESC p
    /// Generates a pulse to open a cash drawer or similar device.
    /// </summary>
    public static readonly byte[] GeneratePulse = new byte[] { EscPosMainCommands.ESC, 0x70 };

    /// <summary>
    /// Enable/Disable Panel Buttons - ESC c 5
    /// Enables or disables the panel buttons.
    /// </summary>
    public static readonly byte[] EnableDisablePanelButtons = new byte[] { EscPosMainCommands.ESC, 0x63, 0x35 };





    /// <summary>
    /// Partial Cut Paper (One Point Left Uncut) - ESC i
    /// Executes a partial cut of the paper, leaving one point uncut.
    /// </summary>
    public static readonly byte[] PartialCutPaperOnePoint = new byte[] { EscPosMainCommands.ESC, 0x69 };

    /// <summary>
    /// Partial Cut Paper (Three Points Left Uncut) - ESC m
    /// Executes a partial cut of the paper, leaving three points uncut.
    /// </summary>
    public static readonly byte[] PartialCutPaperThreePoints = new byte[] { EscPosMainCommands.ESC, 0x6D };

    /// <summary>
    /// Select Bit-Image Mode - ESC *
    /// Selects the bit-image mode for printing images.
    /// </summary>
    public static readonly byte[] SelectBitImageMode = new byte[] { EscPosMainCommands.ESC, 0x2A };

    /// <summary>
    /// Set Paper Sensors to Output Paper-End Signals - ESC c 3
    /// Sets the paper sensors to output signals when the paper is finished.
    /// </summary>
    public static readonly byte[] SetPaperSensors = new byte[] { EscPosMainCommands.ESC, 0x63, 0x33 };

    /// <summary>
    /// Set Horizontal Tab Positions - ESC D
    /// Sets horizontal tab positions.
    /// </summary>
    public static readonly byte[] SetHorizontalTabPositions = new byte[] { EscPosMainCommands.ESC, 0x44 };


    /// <summary>
    /// Select Font A/B/C - ESC M
    /// Selects a font (A, B, or C).
    /// </summary>
    public static readonly byte[] SelectFont = new byte[] { EscPosMainCommands.ESC, 0x4D };

    /// <summary>
    /// Turn Upside-Down Mode On/Off - ESC {
    /// Enables or disables upside-down printing.
    /// </summary>
    public static readonly byte[] UpsideDownMode = new byte[] { EscPosMainCommands.ESC, 0x7B };

    /// <summary>
    /// Set Character Spacing - ESC SP
    /// Sets the spacing between characters.
    /// </summary>
    public static readonly byte[] SetCharacterSpacing = new byte[] { EscPosMainCommands.ESC, 0x20 };

    /// <summary>
    /// Select Page Mode - ESC L
    /// Selects page mode for printing.
    /// </summary>
    public static readonly byte[] SelectPageMode = new byte[] { EscPosMainCommands.ESC, 0x4C };

    /// <summary>
    /// Select Standard Mode - ESC S
    /// Returns to standard printing mode.
    /// </summary>
    public static readonly byte[] SelectStandardMode = new byte[] { EscPosMainCommands.ESC, 0x53 };

    /// <summary>
    /// Set Print Area in Page Mode - ESC W
    /// Sets the printing area in page mode.
    /// </summary>
    public static readonly byte[] SetPrintAreaInPageMode = new byte[] { EscPosMainCommands.ESC, 0x57 };

    /// <summary>
    /// Enable/Disable Panel Button Status Transmission - ESC c 4
    /// Enables or disables the panel button status transmission.
    /// </summary>
    public static readonly byte[] EnableDisablePanelButtonStatusTransmission = new byte[] { EscPosMainCommands.ESC, 0x63, 0x34 };

    /// <summary>
    /// Select Paper Sensor to Stop Printing - ESC c 4
    /// Selects the paper sensor that will stop printing.
    /// </summary>
    public static readonly byte[] SelectPaperSensorToStopPrinting = new byte[] { EscPosMainCommands.ESC, 0x63, 0x34 };

    /// <summary>
    /// Select Paper Sensors to Output Paper-End Signals - ESC c 3
    /// Selects which paper sensors output paper-end signals.
    /// </summary>
    public static readonly byte[] SelectPaperSensorsToOutputPaperEndSignals = new byte[] { EscPosMainCommands.ESC, 0x63, 0x33 };

    /// <summary>
    /// Select International Character Set - ESC R
    /// Selects the international character set.
    /// </summary>
    public static readonly byte[] SelectInternationalCharacterSet = new byte[] { EscPosMainCommands.ESC, 0x52 };

    /// <summary>
    /// Set Print Direction in Page Mode - ESC T n
    /// Sets the print direction in page mode.
    /// </summary>
    public static readonly byte[] SetPrintDirectionInPageMode = new byte[] { EscPosMainCommands.ESC, 0x54 };

    /// <summary>
    /// Select Printing Color - ESC r n
    /// Selects the printing color.
    /// </summary>
    public static readonly byte[] SelectPrintingColor = new byte[] { EscPosMainCommands.ESC, 0x72 };

    /// <summary>
    /// Enable/Disable Automatic Line Feed - ESC 4
    /// Enables or disables automatic line feed.
    /// </summary>
    public static readonly byte[] EnableDisableAutomaticLineFeed = new byte[] { EscPosMainCommands.ESC, 0x34 };

    // --------------------------------

    /// <summary>
    /// Select Double-Width Mode - ESC W
    /// Sets the printing mode to double width.
    /// </summary>
    public static readonly byte[] SelectDoubleWidthMode = new byte[] { EscPosMainCommands.ESC, 0x57 };

    /// <summary>
    /// Control Beep or Buzzer - ESC BEL
    /// Activates the beep or buzzer on the printer.
    /// </summary>
    public static readonly byte[] ControlBeepOrBuzzer = new byte[] { 0x07 };

    /// <summary>
    /// Select Print Mode - ESC ! n
    /// Selects a print mode (standard, emphasized, double height, etc.)
    /// Example: n = 1 selects emphasized mode.
    /// </summary>
    public static readonly byte[] SelectPrintMode = new byte[] { EscPosMainCommands.ESC, 0x21, 0x01 };


    /// <summary>
    /// Select or Cancel Left Margin for Printing - ESC <
    /// – Selects or cancels left margin.
    /// </summary>
    public static readonly byte[] SelectCancelLeftMargin = new byte[] { EscPosMainCommands.ESC, 0x3C };

    /// <summary>
    /// Enable/Disable Printing - ESC =
    /// – Enables or disables the printer's data reception.
    /// </summary>
    public static readonly byte[] EnableDisablePrinting = new byte[] { EscPosMainCommands.ESC, 0x3D };

    // Requests the ink status in real time.
    // </summary>
    public static readonly byte[] TransmitRealTimeInkStatus = new byte[] { EscPosMainCommands.ESC, 0x63, 0x04 };

    /// <summary>
    /// Transmit real-time request for operator panel - ESC u
    /// Requests the status of the operator panel in real time.
    /// </summary>
    public static readonly byte[] TransmitOperatorPanelStatus = new byte[] { EscPosMainCommands.ESC, 0x75 };

    /// <summary>
    /// Download Custom Graphic Data - ESC ( c
    /// Downloads custom graphic data to the printer.
    /// </summary>
    public static readonly byte[] DownloadCustomGraphicData = new byte[] { EscPosMainCommands.ESC, 0x28, 0x63 };

    /// <summary>
    /// Partial Cut Command with Parameter - ESC i n
    /// Executes a partial cut with a parameter.
    /// </summary>
    public static readonly byte[] PartialCutWithParameter = new byte[] { EscPosMainCommands.ESC, 0x69 };

    /// <summary>
    /// Enable/Disable Automatic Line Feed after each line - ESC 3 n
    /// Sets automatic line feed on or off.
    /// </summary>
    public static readonly byte[] EnableAutomaticLineFeedAfterLine = new byte[] { EscPosMainCommands.ESC, 0x33 };

    /// <summary>
    /// Set Character Font - ESC M n
    /// Sets character font style (Font A, B, or C).
    /// </summary>
    public static readonly byte[] SetCharacterFont = new byte[] { EscPosMainCommands.ESC, 0x4D };

    /// <summary>
    /// Set Top Margin - ESC R n
    /// Sets the top margin for printing.
    /// </summary>
    public static readonly byte[] SetTopMargin = new byte[] { EscPosMainCommands.ESC, 0x52 };


    /// <summary>
    /// Select/Cancel User-Defined Character Set - ESC % n
    /// Selects or cancels the user-defined character set.
    /// n = 0: Cancel user-defined character set
    /// n = 1: Select user-defined character set
    /// </summary>
    public static readonly byte[] SelectCancelUserDefinedCharacterSet = new byte[] { EscPosMainCommands.ESC, 0x25 };

    /// <summary>
    /// Set Right-Side Character Spacing - ESC ( C
    /// Sets the right-side character spacing.
    /// </summary>
    public static readonly byte[] SetRightSideCharacterSpacing = new byte[] { EscPosMainCommands.ESC, 0x28, 0x43 };

    /// <summary>
    /// Set Underline Mode - ESC - n
    /// Sets underline mode for text.
    /// n = 0: Underline mode off
    /// n = 1: Underline mode 1 dot width
    /// n = 2: Underline mode 2 dot width
    /// </summary>
    public static readonly byte[] SetUnderlineMode = new byte[] { EscPosMainCommands.ESC, 0x2D };

    /// <summary>
    /// Set Emphasized Mode - ESC E n
    /// Sets emphasized (bold) mode for text.
    /// n = 0: Emphasized mode off
    /// n = 1: Emphasized mode on
    /// </summary>
    public static readonly byte[] SetEmphasizedMode = new byte[] { EscPosMainCommands.ESC, 0x45 };

    /// <summary>
    /// Set Double Strike Mode - ESC G n
    /// Sets double-strike mode for text.
    /// n = 0: Double-strike mode off
    /// n = 1: Double-strike mode on
    /// </summary>
    public static readonly byte[] SetDoubleStrikeMode = new byte[] { EscPosMainCommands.ESC, 0x47 };

    /// <summary>
    /// Set Font - ESC M n
    /// Selects a font (A, B, or C).
    /// n = 0: Font A
    /// n = 1: Font B
    /// n = 2: Font C
    /// </summary>
    public static readonly byte[] SetFont = new byte[] { EscPosMainCommands.ESC, 0x4D };

    /// <summary>
    /// Set Upside-Down Printing Mode - ESC { n
    /// Enables or disables upside-down printing.
    /// n = 0: Upside-down mode off
    /// n = 1: Upside-down mode on
    /// </summary>
    public static readonly byte[] SetUpsideDownPrinting = new byte[] { EscPosMainCommands.ESC, 0x7B };

    /// <summary>
    /// Set Character Code Table - ESC t n
    /// Selects a character code table.
    /// n = code table number (0-255)
    /// </summary>
    public static readonly byte[] SetCharacterCodeTable = new byte[] { EscPosMainCommands.ESC, 0x74 };

    /// <summary>
    /// Turn 90-Degree Clockwise Rotation Mode On/Off - ESC V n
    /// Turns 90-degree clockwise rotation mode on or off.
    /// n = 0: Rotation mode off
    /// n = 1: Rotation mode on
    /// </summary>
    public static readonly byte[] Turn90DegreeRotationMode = new byte[] { EscPosMainCommands.ESC, 0x56 };



    /// <summary>
    /// Turn Unidirectional Print Mode On/Off - ESC U n
    /// Turns unidirectional print mode on or off.
    /// n = 0: Unidirectional mode off (bidirectional printing)
    /// n = 1: Unidirectional mode on
    /// </summary>
    public static readonly byte[] TurnUnidirectionalPrintMode = new byte[] { EscPosMainCommands.ESC, 0x55 };

    /// <summary>
    /// Select Peripheral Device - ESC = n
    /// Selects or deselects the printer.
    /// n = 0: Deselect printer
    /// n = 1: Select printer
    /// </summary>
    public static readonly byte[] SelectPeripheralDevice = new byte[] { EscPosMainCommands.ESC, 0x3D };

    /// <summary>
    /// Cancel All Horizontal Tab Positions - ESC D NUL
    /// Cancels all horizontal tab positions.
    /// </summary>
    public static readonly byte[] CancelAllHorizontalTabPositions = new byte[] { EscPosMainCommands.ESC, 0x44, 0x00 };

    /// <summary>
    /// Set Vertical Tab Positions - ESC B n1 ... nk NUL
    /// Sets vertical tab positions.
    /// </summary>
    public static readonly byte[] SetVerticalTabPositions = new byte[] { EscPosMainCommands.ESC, 0x42 };

    /// <summary>
    /// Cancel All Vertical Tab Positions - ESC B NUL
    /// Cancels all vertical tab positions.
    /// </summary>
    public static readonly byte[] CancelAllVerticalTabPositions = new byte[] { EscPosMainCommands.ESC, 0x42, 0x00 };

    /// <summary>
    /// Turn Emphasized Mode On/Off - ESC E n
    /// Enables or disables emphasized (bold) mode.
    /// n = 0: Emphasized mode off
    /// n = 1: Emphasized mode on
    /// </summary>
    public static readonly byte[] TurnEmphasizedMode = new byte[] { EscPosMainCommands.ESC, 0x45 };

    /// <summary>
    /// Turn Double-Strike Mode On/Off - ESC G n
    /// Enables or disables double-strike mode.
    /// n = 0: Double-strike mode off
    /// n = 1: Double-strike mode on
    /// </summary>
    public static readonly byte[] TurnDoubleStrikeMode = new byte[] { EscPosMainCommands.ESC, 0x47 };

    /// <summary>
    /// Turn Underline Mode On/Off - ESC - n
    /// Enables or disables underline mode.
    /// n = 0: Underline mode off
    /// n = 1: Underline mode with 1-dot width
    /// n = 2: Underline mode with 2-dot width
    /// </summary>
    public static readonly byte[] TurnUnderlineMode = new byte[] { EscPosMainCommands.ESC, 0x2D };

    /// <summary>
    /// Set Default Line Spacing - ESC 2
    /// Sets line spacing to the default value (approximately 4.23mm).
    /// </summary>
    public static readonly byte[] SetDefaultLineSpacing = new byte[] { EscPosMainCommands.ESC, 0x32 };

    /// <summary>
    /// Turn Upside-Down Printing Mode On/Off - ESC { n
    /// Enables or disables upside-down printing.
    /// n = 0: Upside-down mode off
    /// n = 1: Upside-down mode on
    /// </summary>
    public static readonly byte[] TurnUpsideDownMode = new byte[] { EscPosMainCommands.ESC, 0x7B };

    /// <summary>
    /// Set Left Alignment - ESC a 0
    /// Aligns all data to the left.
    /// </summary>
    public static readonly byte[] SetLeftAlignment = new byte[] { EscPosMainCommands.ESC, 0x61, 0x00 };

    /// <summary>
    /// Set Center Alignment - ESC a 1
    /// Centers all data.
    /// </summary>
    public static readonly byte[] SetCenterAlignment = new byte[] { EscPosMainCommands.ESC, 0x61, 0x01 };

    /// <summary>
    /// Set Right Alignment - ESC a 2
    /// Aligns all data to the right.
    /// </summary>
    public static readonly byte[] SetRightAlignment = new byte[] { EscPosMainCommands.ESC, 0x61, 0x02 };

    /// <summary>
    /// Set Bit Image Mode - ESC * m nL nH [d]...
    /// Sets the bit image mode for printing graphics.
    /// </summary>
    public static readonly byte[] SetBitImageMode = new byte[] { EscPosMainCommands.ESC, 0x2A };








    /// <summary>
    /// Set Paper Sensor(s) to Stop Printing - ESC c 3 n
    /// Selects which paper sensor(s) stop printing when a paper end is detected.
    /// </summary>
    public static readonly byte[] SetPaperSensorsToStopPrinting = new byte[] { EscPosMainCommands.ESC, 0x63, 0x33 };

    /// <summary>
    /// Set Paper Sensor(s) to Output Paper-End Signals - ESC c 4 n
    /// Selects which paper sensor(s) output a paper-end signal.
    /// </summary>
    public static readonly byte[] SetPaperSensorsToOutputPaperEndSignals = new byte[] { EscPosMainCommands.ESC, 0x63, 0x34 };

    /// <summary>
    /// Select Peripheral Device to which Status is Transmitted - ESC c 5 n
    /// Selects the peripheral device whose status is transmitted.
    /// </summary>
    public static readonly byte[] SelectPeripheralDeviceForStatusTransmission = new byte[] { EscPosMainCommands.ESC, 0x63, 0x35 };

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
    public static readonly byte[] SelectDoubleStrikeMode = new byte[] { EscPosMainCommands.ESC, 0x47 };

    /// <summary>
    /// Select Print Mode(s) - ESC ! n
    /// Selects print mode(s) like emphasized, double-height, double-width, etc.
    /// </summary>
    public static readonly byte[] SelectPrintModes = new byte[] { EscPosMainCommands.ESC, 0x21 };


    ////// <summary>
    ////// Set Print Density - GS E n
    ////// Sets the print density and darkness.
    ////// </summary>
    // public static readonly byte[] SetPrintDensity = new byte[] { 0x1D, 0x45 };



    /// <summary>
    /// Define User-Defined Characters - ESC & y c1 c2 [d]...
    /// Defines user-defined characters.
    /// </summary>
    public static readonly byte[] DefineUserDefinedCharacters = new byte[] { EscPosMainCommands.ESC, 0x26 };


    /// <summary>
    /// Cancel User-Defined Characters - ESC ? n
    /// Cancels user-defined characters.
    /// </summary>
    public static readonly byte[] CancelUserDefinedCharacters = new byte[] { EscPosMainCommands.ESC, 0x3F };


    /// <summary>
    /// Select Print Direction in Page Mode - ESC T n
    /// Selects the print direction in page mode.
    /// </summary>
    public static readonly byte[] SelectPrintDirectionInPageMode = new byte[] { EscPosMainCommands.ESC, 0x54 };

    /// <summary>
    /// Set Printing Area in Page Mode - ESC W xL xH yL yH dxL dxH dyL dyH
    /// Sets the printing area in page mode.
    /// </summary>
    public static readonly byte[] SetPrintingAreaInPageMode = new byte[] { EscPosMainCommands.ESC, 0x57 };

    /// <summary>
    /// Set Vertical Tab - VT
    /// Moves the print position to the next vertical tab position.
    /// </summary>
    public static readonly byte[] VerticalTab = new byte[] { 0x0B };



    /// <summary>
    /// Transmit Paper Sensor Status - ESC v
    /// Transmits the status of the paper sensors.
    /// </summary>
    public static readonly byte[] TransmitPaperSensorStatus = new byte[] { EscPosMainCommands.ESC, 0x76 };

    /// <summary>
    /// Transmit Peripheral Device Status - ESC u n
    /// Transmits the status of a connected peripheral device.
    /// </summary>
    public static readonly byte[] TransmitPeripheralDeviceStatus = new byte[] { EscPosMainCommands.ESC, 0x75 };

    /// <summary>
    /// Cancel Print Data in Page Mode - CAN
    /// Cancels the data in page mode.
    /// </summary>
    public static readonly byte[] CancelPrintDataInPageMode = new byte[] { 0x18 };

    /// <summary>
    /// Enable/Disable Automatic Line Feed - ESC 4 / ESC 5
    /// Enables or disables the automatic line feed.
    /// </summary>
    public static readonly byte[] EnableAutomaticLineFeed = new byte[] { EscPosMainCommands.ESC, 0x34 };
    public static readonly byte[] DisableAutomaticLineFeed = new byte[] { EscPosMainCommands.ESC, 0x35 };


  }
}
