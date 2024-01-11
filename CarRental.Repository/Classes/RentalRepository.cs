// <copyright file="RentalRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRental.Repository
{
    using System;
    using System.Linq;
    using CarRental.Data;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// RentalRepository class.
    /// </summary>
    public class RentalRepository : RepositoryBase<Rental>, IRentalRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RentalRepository"/> class.
        /// </summary>
        /// <param name="ctx">DBContext.</param>
        public RentalRepository(DbContext ctx)
        : base(ctx)
        {
        }

        /// <summary>
        /// Adds a new <see cref="Rental"/> to the Rental table by reaching Data Layer.
        /// </summary>
        /// <param name="startDate">Owner's first name.</param>
        /// <param name="endDate">Owner's last name.</param>
        /// <param name="contractorId">Owner's birth date.</param>
        /// <param name="carId">Owner's phone number.</param>
        public void Add(DateTime startDate, DateTime endDate, int? contractorId = null, int? carId = null)
        {
            var rental = new Rental() { Start = startDate, End = endDate, Paid = false, CarReturned = false, ContractorId = contractorId, CarId = carId };
            this.Add(rental);
        }

        /// <summary>
        /// Gets the Rental object by ID.
        /// </summary>
        /// <param name="id">ID.</param>
        /// <returns>Rental by id.</returns>
        public override Rental GetOne(int id)
        {
            return this.GetAll().SingleOrDefault(x => x.RentalId == id);
        }
    }
}