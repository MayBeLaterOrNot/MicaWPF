﻿using System.Windows.Data;

namespace MicaWPF.Extension.Converters;
public class ProgressThicknessConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        return value is double height ? height / 8 : (object)12.0d;
    }

    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
