// <copyright file="IOwnerRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRental.Repository
{
    using System;
    using CarRental.Data;

    /// <summary>
    /// IOwnerRepository interface.
    /// </summary>
    public interface IOwnerRepository : IRepository<Owner>
    {
        /// <summary>
        /// Adds a new <see cref="Contractor"/> to the Contractor table by reaching Data Layer.
        /// </summary>
        /// <param name="firstName">Owner's first name.</param>
        /// <param name="lastName">Owner's last name.</param>
        /// <param name="birthDate">Owner's birth date.</param>
        /// <param name="phoneNumber">Owner's phone number.</param>
        /// <param name="rentalCompany">Owner's rental company.</param>
        /// <param name="location">Owner's, location.</param>
        void Add(string firstName, string lastName, DateTime birthDate, string phoneNumber, string rentalCompany, string location);

        /// <summary>
        /// Gets the Owner object by ID.
        /// </summary>
        /// <param name="id">ID.</param>
        /// <returns>Owner by id.</returns>
        new Owner GetOne(int id);

        // void Set(int id, Owner newOwner);
    }
}