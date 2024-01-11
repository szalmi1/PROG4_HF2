// <copyright file="BoolInverterConverter.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRental.View.UI
{
    using System;
    using System.Windows.Data;

    /// <summary>
    /// Bool converter for Radio button.
    /// </summary>
    public class BoolInverterConverter : IValueConverter
    {
        /// <summary>
        /// Converter.
        /// </summary>
        /// <param name="value">.</param>
        /// <param name="targetType">..</param>
        /// <param name="parameter">...</param>
        /// <param name="culture">....</param>
        /// <returns>value.</returns>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is bool boolean)
            {
                return !boolean;
            }

            return value;
        }

        /// <summary>
        /// Convert back.
        /// </summary>
        /// <param name="value">.</param>
        /// <param name="targetType">..</param>
        /// <param name="parameter">...</param>
        /// <param name="culture">....</param>
        /// <returns>value.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is bool boolean)
            {
                return !boolean;
            }

            return value;
        }
    }
}
