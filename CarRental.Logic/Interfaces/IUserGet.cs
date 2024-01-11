// <copyright file="IUserGet.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRental.Logic
{
    using System;

    /// <summary>
    /// Getters for personal data.
    /// </summary>
    public interface IUserGet
    {
        /// <summary>
        /// Gets the FirstName of the object.
        /// </summary>
        /// <param name="id">ID of object.</param>
        /// <returns>FirstName: <see cref="string"/>.</returns>
        public string GetFirstName(int id);

        /// <summary>
        /// Gets the LastName of the object.
        /// </summary>
        /// <param name="id">ID of object.</param>
        /// <returns>LastName: <see cref="string"/>.</returns>
        public string GetLastName(int id);

        /// <summary>
        /// Gets the BirthDate of the object.
        /// </summary>
        /// <param name="id">ID of object.</param>
        /// <returns>BirthDate: <see cref="DateTime"/>.</returns>
        public DateTime GetBirthDate(int id);

        /// <summary>
        /// Gets the PhoneNumber of the object.
        /// </summary>
        /// <param name="id">ID of object.</param>
        /// <returns>PhoneNumber: <see cref="string"/>.</returns>
        public string GetPhoneNumber(int id);
    }
}
