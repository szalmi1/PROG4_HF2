// <copyright file="FormatLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRental.Logic
{
    using System;
    using System.Globalization;
    using System.Linq;

    /// <summary>
    /// FormatLogic, implements formatting inputs.
    /// </summary>
    public static class FormatLogic
    {
        /// <summary>
        /// Formats input as a DateTime.
        /// </summary>
        /// <param name="input">Input needs to format.</param>
        /// <returns><see cref="DateTime"/>.</returns>
        public static DateTime FormatDate(string input)
        {
            string[] formats =
            {
                "yyyy.MM.dd.", "yyyy.MM.dd",
                "yyyy. MM. dd. ", "yyyy. MM. dd",
                "yyyy.", "yyyy",
                "yyyy-MM-dd",
                "yyyy/MM/dd",
            };
            DateTime dateValue;
            try
            {
                dateValue = DateTime.ParseExact(input, formats, new CultureInfo("hu-HU"), DateTimeStyles.None);
            }
            catch (Exception)
            {
                throw new FormatException("Invalid Date format: " + input);
            }

            return dateValue;
        }

        /// <summary>
        /// Formats input as a bool.
        /// </summary>
        /// <param name="input">Input needs to format.</param>
        /// <returns><see cref="bool"/>.</returns>
        public static bool FormatBool(string input)
        {
            if (input != null && (input.ToUpper().Contains("YES") || input.ToUpper().Contains("Y")))
            {
                return true;
            }
            else if (input != null && (input.ToUpper().Contains("NO") || input.ToUpper().Contains("N")))
            {
                return false;
            }
            else
            {
                throw new FormatException("Invalid bool format: " + input);
            }
        }

        /// <summary>
        /// Formats input as a String.
        /// </summary>
        /// <param name="input">Input needs to format.</param>
        /// <param name="length">The max length allowed.</param>
        /// <param name="allowChar">Allow any non alphabetic char.</param>
        /// <returns><see cref="string"/>.</returns>
        public static string FormatString(string input, int length, bool allowChar = false)
        {
            if (input == null || (!allowChar && (input.Contains(" ") || !input.All(char.IsLetter))) || input.Length < 1 || input.Length > length)
            {
                throw new FormatException("Invalid string format: " + input);
            }
            else
            {
                input = input.First().ToString().ToUpper() + input.Substring(1);
            }

            return input;
        }

        /// <summary>
        /// Formats input as a Phonenumber (string).
        /// </summary>
        /// <param name="input">Input needs to format.</param>
        /// <returns><see cref="string"/>: PhoneNumber.</returns>
        public static string FormatPhoneNumber(string input)
        {
            if (input == null || input.Length > 11 || !input.All(char.IsDigit))
            {
                throw new FormatException("Invalid phonenumber format: " + input);
            }

            return input;
        }

        /// <summary>
        /// Formats input as an Email (string).
        /// </summary>
        /// <param name="input">Input needs to format.</param>
        /// <param name="length">The max length allowed.</param>
        /// <returns><see cref="string"/>.</returns>
        public static string FormatEmail(string input, int length)
        {
            if (input != null)
            {
                if (input.Contains('@') && input.Contains('.') && input.IndexOf('@') < input.IndexOf('.') && (input.Length - 1 - input.IndexOf('.') <= 3) && input.Length < length)
                {
                    if (input.IndexOf('@') < input.IndexOf('.') && (input.Length - 1 - input.IndexOf('.') <= 3))
                    {
                        return input;
                    }
                    else
                    {
                        throw new FormatException("Invalid Email  format: " + input);
                    }
                }
                else
                {
                    throw new FormatException("Invalid Email  format: " + input);
                }
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
