// <copyright file="IContractorRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRental.Repository
{
    using System;
    using CarRental.Data;

    /// <summary>
    /// IContractorRepository interface.
    /// </summary>
    public interface IContractorRepository : IRepository<Contractor>
    {
        /// <summary>
        /// Adds a new <see cref="Contractor"/> to the Contractor table by reaching Data Layer.
        /// </summary>
        /// <param name="firstName">Contractor's firstname.</param>
        /// <param name="lastName">Contractor's lastname.</param>
        /// <param name="birthDate">Contractor's birthdate.</param>
        /// <param name="phoneNumber">Contractor's phonenumber.</param>
        /// <param name="address">Contractor's city.</param>
        /// <param name="email">Contractor's, email.</param>
        void Add(string firstName, string lastName, DateTime birthDate, string phoneNumber, string address, string email);

        /// <summary>
        /// Gets the Contractor object by ID.
        /// </summary>
        /// <param name="id">ID.</param>
        /// <returns>Contractor by id.</returns>
        new Contractor GetOne(int id);

        // void Set(int id, Contractor newContractor);
    }
}