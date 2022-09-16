﻿using MicaWPF.DependencyInjection.Options;
using MicaWPF.Events;
using MicaWPF.Models;
using MicaWPF.Services;
using System.Windows;

namespace MicaWPF.DependencyInjection.Services;
internal sealed class ThemeServiceDI : IThemeService
{
    private readonly MicaWPFOptions _options;
    public IWeakEvent<WindowsTheme> ThemeChanged => ThemeService.Current.ThemeChanged;

    public ThemeServiceDI(MicaWPFOptions options)
    {
        _options = options;
        ThemeService.Current.IsThemeAware = _options.IsThemeAware;
        _ = ThemeService.Current.ChangeTheme(_options.Theme);
    }

    public WindowsTheme CurrentTheme => ThemeService.Current.CurrentTheme;

    public bool IsThemeAware { get => ThemeService.Current.IsThemeAware; set => ThemeService.Current.IsThemeAware = value; }

    public ICollection<MicaEnabledWindow> MicaEnabledWindows => ThemeService.Current.MicaEnabledWindows;

    public WindowsTheme ChangeTheme(WindowsTheme windowsTheme = WindowsTheme.Auto)
    {
        return ThemeService.Current.ChangeTheme(windowsTheme);
    }

    public void EnableBackdrop(Window window, BackdropType micaType = BackdropType.Mica)
    {
        ThemeService.Current.EnableBackdrop(window, micaType);
    }
}
