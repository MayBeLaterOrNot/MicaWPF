﻿namespace MicaWPF.Services;

public class ThemeResourceDictionary : ResourceDictionary
{
}

public class ThemeService
{

    public static readonly DependencyProperty CurrentThemeDictionaryProperty =
     DependencyProperty.RegisterAttached("CurrentThemeDictionary", typeof(Uri),
     typeof(ThemeService),
     new UIPropertyMetadata(null, CurrentThemeDictionaryChanged));

    public static Uri GetCurrentThemeDictionary(DependencyObject obj)
    {
        return (Uri)obj.GetValue(CurrentThemeDictionaryProperty);
    }

    public static void SetCurrentThemeDictionary(DependencyObject obj, Uri value)
    {
        obj.SetValue(CurrentThemeDictionaryProperty, value);
    }

    private static void CurrentThemeDictionaryChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
    {
        if (obj is FrameworkElement) // works only on FrameworkElement objects
        {
            ApplyTheme(obj as FrameworkElement, GetCurrentThemeDictionary(obj));
        }
    }

    private static void ApplyTheme(FrameworkElement targetElement, Uri dictionaryUri)
    {
        if (targetElement == null)
        {
            return;
        }

        ThemeResourceDictionary themeDictionary = null;
        if (dictionaryUri != null)
        {
            themeDictionary = new ThemeResourceDictionary
            {
                Source = dictionaryUri
            };

            // add the new dictionary to the collection of merged dictionaries of the target object
            targetElement.Resources.MergedDictionaries.Insert(0, themeDictionary);
        }

        // find if the target element already has a theme applied
        var existingDictionaries =
            (from dictionary in targetElement.Resources.MergedDictionaries.OfType<ThemeResourceDictionary>()
             select dictionary).ToList();

        // remove the existing dictionaries
        foreach (var thDictionary in existingDictionaries)
        {
            if (themeDictionary == thDictionary)
            {
                continue;  // don't remove the newly added dictionary
            }

            targetElement.Resources.MergedDictionaries.Remove(thDictionary);
        }
    }
}

