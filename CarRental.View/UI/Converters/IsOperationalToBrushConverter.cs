// <copyright file="IsOperationalToBrushConverter.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRental.View.UI
{
    using System;
    using System.Globalization;
    using System.Windows.Data;
    using System.Windows.Media;

    /// <summary>
    /// Colored background converter.
    /// </summary>
    public class IsOperationalToBrushConverter : IValueConverter
    {
        /// <summary>
        /// Convert to.
        /// </summary>
        /// <param name="value">.</param>
        /// <param name="targetType">..</param>
        /// <param name="parameter">...</param>
        /// <param name="culture">....</param>
        /// <returns>.....</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isOperational = (bool)value;
            return isOperational switch
            {
                false => Brushes.LightSalmon,
                _ => Brushes.LightGreen,
            };
        }

        /// <summary>
        /// Convert back.
        /// </summary>
        /// <param name="value">.</param>
        /// <param name="targetType">..</param>
        /// <param name="parameter">...</param>
        /// <param name="culture">....</param>
        /// <returns>.....</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
