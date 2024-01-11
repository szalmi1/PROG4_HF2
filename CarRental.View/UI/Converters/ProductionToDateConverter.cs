// <copyright file="ProductionToDateConverter.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRental.View.UI
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Windows.Data;

    /// <summary>
    /// Converter for Date.
    /// </summary>
    public class ProductionToDateConverter : IValueConverter
    {
        /// <summary>
        /// Converts Date to Production..
        /// </summary>
        /// <param name="value">.</param>
        /// <param name="targetType">..</param>
        /// <param name="parameter">...</param>
        /// <param name="culture">....</param>
        /// <returns>Production.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime p = (DateTime)value;
            return p.Year;
        }

        /// <summary>
        /// Converts Production to date.
        /// </summary>
        /// <param name="value">.</param>
        /// <param name="targetType">..</param>
        /// <param name="parameter">...</param>
        /// <param name="culture">....</param>
        /// <returns>Date.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string input = (string)value;
            if (input.All(char.IsDigit) && int.Parse(input) <= DateTime.Now.Year + 1 && int.Parse(input) >= DateTime.Now.Year - 100)
            {
                return new DateTime(int.Parse(input), 1, 1);
            }
            else
            {
                return DateTime.Now;
            }
        }
    }
}
