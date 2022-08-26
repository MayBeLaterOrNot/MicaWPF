﻿namespace MicaWPF;

public enum ContentDialogButton 
{ 
    Primary,
    Secondary,
    Close
}

public enum RevealMode
{
    Hidden,
    Visible
}

public enum ElementPosition
{
    Left,
    Right
}

public enum WindowsTheme
{
    Light,
    Dark,
    Auto
}

public enum BackdropType
{
    None = 1,
    Mica = 2,
    Acrylic = 3,
    Tabbed = 4
}

public enum AccentBrushType
{
    Primary,
    Secondary,
    Tertiary,
    Quaternary
}

public enum TitleBarType
{
    Win32,
    WinUI
}

[Flags]
internal enum Facility
{
    Null,
    Rpc,
    Dispatch,
    Storage,
    Itf,
    Win32 = 7,
    Windows,
    Control = 10,
    Ese = 3678,
    WinCodec = 2200
}
