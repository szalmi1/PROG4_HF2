// <copyright file="IUserModify.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRental.Logic
{
    using System;

    /// <summary>
    /// Setters for person specific data.
    /// </summary>
    public interface IUserModify
    {
        /// <summary>
        /// Changes the FirstName of object.
        /// </summary>
        /// <param name="input"> The new FirstName.</param>
        /// <param name="id">ID of object.</param>
        void ChangeFirstName(string input, int id);

        /// <summary>
        /// Changes the LastName of object.
        /// </summary>
        /// <param name="input"> The new LastName.</param>
        /// <param name="id">ID of object.</param>
        void ChangeLastName(string input, int id);

        /// <summary>
        /// Changes the BirthDate of object.
        /// </summary>
        /// <param name="input"> The new BirthDate.</param>
        /// <param name="id">ID of object.</param>
        void ChangeBirthDate(DateTime input, int id);

        /// <summary>
        /// Changes the PhoneNumbere of object.
        /// </summary>
        /// <param name="input"> The new PhoneNumber.</param>
        /// <param name="id">ID of object.</param>
        void ChangePhoneNumber(string input, int id);
    }
}
