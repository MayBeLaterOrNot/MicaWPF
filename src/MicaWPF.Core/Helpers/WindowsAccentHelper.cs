﻿// <copyright file="WindowsAccentHelper.cs" company="Zircon Technology">
// This software is distributed under the MIT license and its code is open-source and free for use, modification, and distribution.
// </copyright>

using System.Windows.Media;
using MicaWPF.Core.Interop;
using MicaWPF.Core.Models;
using Microsoft.Win32;

namespace MicaWPF.Core.Helpers;

/// <summary>
/// Helper method for getting windows accent.
/// </summary>
public class WindowsAccentHelper
{
    protected const string _registryKeyPath = @"Software\Microsoft\Windows\DWM";
    protected const string _registryValueName = "ColorPrevalence";

    /// <summary>
    /// Determines whether the title bar and window borders are accented.
    /// </summary>
    /// <returns>
    /// Returns a boolean indicating if the title bar and window borders are accented.
    /// </returns>
    public virtual bool AreTitleBarAndBordersAccented()
    {
        using var key = Registry.CurrentUser.OpenSubKey(_registryKeyPath);
        var registryValueObject = key?.GetValue(_registryValueName);

        if (registryValueObject == null)
        {
            return false;
        }

        var registryValue = (int)registryValueObject;

        return registryValue > 0;
    }

    /// <summary>
    /// Retrieves the current Windows accent colors.
    /// </summary>
    /// <returns>
    /// Returns an <see cref="AccentColors"/> object containing the current Windows accent colors.
    /// </returns>
    public virtual AccentColors GetAccentColor()
    {
        InteropMethods.DwmGetColorizationParameters(out var colors);
        return new(ParseColor(colors.clrColor), default, default, default, default, default, default, true);
    }

    protected static Color ParseColor(uint color)
    {
        var opaque = true;

        return Color.FromArgb(
            (byte)(opaque ? 255 : color >> 24 & 0xff),
            (byte)(color >> 16 & 0xff),
            (byte)(color >> 8 & 0xff),
            (byte)((byte)color & 0xff));
    }
}
