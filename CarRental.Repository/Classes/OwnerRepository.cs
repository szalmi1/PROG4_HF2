// <copyright file="OwnerRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRental.Repository
{
    using System;
    using System.Linq;
    using CarRental.Data;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// OwnerRepository class.
    /// </summary>
    public class OwnerRepository : RepositoryBase<Owner>, IOwnerRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OwnerRepository"/> class.
        /// </summary>
        /// <param name="ctx">DBContext.</param>
        public OwnerRepository(DbContext ctx)
            : base(ctx)
        {
        }

        /// <summary>
        /// Adds a new <see cref="Contractor"/> to the Contractor table by reaching Data Layer.
        /// </summary>
        /// <param name="firstName">Owner's first name.</param>
        /// <param name="lastName">Owner's last name.</param>
        /// <param name="birthDate">Owner's birth date.</param>
        /// <param name="phoneNumber">Owner's phone number.</param>
        /// <param name="rentalCompany">Owner's rental company.</param>
        /// <param name="location">Owner's, location.</param>
        public void Add(string firstName, string lastName, DateTime birthDate, string phoneNumber, string rentalCompany, string location)
        {
            var owner = new Owner() { FirstName = firstName, LastName = lastName, BirthDate = birthDate, PhoneNumber = phoneNumber, RentalCompany = rentalCompany, Location = location };
            this.Add(owner);
        }

        /// <summary>
        /// Gets the Owner object by ID.
        /// </summary>
        /// <param name="id">ID.</param>
        /// <returns>Owner by id.</returns>
        public override Owner GetOne(int id)
        {
            return this.GetAll().SingleOrDefault(x => x.OwnerId == id);
        }
    }
}