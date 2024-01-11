// <copyright file="ContractorRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRental.Repository
{
    using System;
    using System.Linq;
    using CarRental.Data;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// ContractorRepository class.
    /// </summary>
    public class ContractorRepository : RepositoryBase<Contractor>, IContractorRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContractorRepository"/> class.
        /// </summary>
        /// <param name="ctx">DBContext.</param>
        public ContractorRepository(DbContext ctx)
            : base(ctx)
        {
        }

        /// <summary>
        /// Adds a new <see cref="Contractor"/> to the Contractor table by reaching Data Layer.
        /// </summary>
        /// <param name="firstName">Contractor's firstname.</param>
        /// <param name="lastName">Contractor's lastname.</param>
        /// <param name="birthDate">Contractor's birthdate.</param>
        /// <param name="phoneNumber">Contractor's phonenumber.</param>
        /// <param name="address">Contractor's city.</param>
        /// <param name="email">Contractor's, email.</param>
        public void Add(string firstName, string lastName, DateTime birthDate, string phoneNumber, string address, string email)
        {
            var contractor = new Contractor() { FirstName = firstName, LastName = lastName, BirthDate = birthDate, PhoneNumber = phoneNumber, City = address, Email = email };
            this.Add(contractor);
        }

        /// <summary>
        /// Gets the Contractor object by ID.
        /// </summary>
        /// <param name="id">ID.</param>
        /// <returns>Contractor by id.</returns>
        public override Contractor GetOne(int id)
        {
            return this.GetAll().SingleOrDefault(x => x.ContractorId == id);
        }
    }
}