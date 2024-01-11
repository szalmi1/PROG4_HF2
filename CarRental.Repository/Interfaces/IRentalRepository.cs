// <copyright file="IRentalRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRental.Repository
{
    using System;
    using CarRental.Data;

    /// <summary>
    /// IRentalRepository interface.
    /// </summary>
    public interface IRentalRepository : IRepository<Rental>
    {
        /// <summary>
        /// Adds a new <see cref="Rental"/> to the Rental table by reaching Data Layer.
        /// </summary>
        /// <param name="startDate">Owner's first name.</param>
        /// <param name="endDate">Owner's last name.</param>
        /// <param name="contractorId">Owner's birth date.</param>
        /// <param name="carId">Owner's phone number.</param>
        void Add(DateTime startDate, DateTime endDate, int? contractorId = null, int? carId = null);

        /// <summary>
        /// Gets the Rental object by ID.
        /// </summary>
        /// <param name="id">ID.</param>
        /// <returns>Rental by id.</returns>
        new Rental GetOne(int id);

        // void Set(int id, Rental newRental);
    }
}