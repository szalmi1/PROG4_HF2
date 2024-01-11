// <copyright file="CarRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRental.Repository
{
    using System;
    using System.Linq;
    using CarRental.Data;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Car Repository.
    /// </summary>
    public class CarRepository : RepositoryBase<Car>, ICarRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CarRepository"/> class.
        /// </summary>
        /// <param name="ctx">DBContext.</param>
        public CarRepository(DbContext ctx)
            : base(ctx)
        {
        }

        /// <summary>
        /// Adds a new <see cref="Car"/> to the Car table by reaching Data Layer.
        /// </summary>
        /// <param name="manufacturer">Cars manufacturer name.</param>
        /// <param name="model">Car model name.</param>
        /// <param name="carclass">Car class.</param>
        /// <param name="production">Car's production date.</param>
        /// <param name="isOperational">Is the car operational?.</param>
        /// <param name="ownerId">The owner's ID, can be null.</param>
        public void Add(string manufacturer, string model, string carclass, DateTime production, bool isOperational, int? ownerId = null)
        {
            var car = new Car() { Manufacturer = manufacturer, Model = model, Class = carclass, Production = production, IsOperational = isOperational, OwnerId = ownerId, RentalId = null };
            this.Add(car);
        }

        /// <summary>
        /// Returns Car object with the given ID.
        /// </summary>
        /// <param name="id">Car's id.</param>
        /// <returns><see cref="Car"/> object.</returns>
        public override Car GetOne(int id)
        {
            return this.GetAll().SingleOrDefault(x => x.CarId == id);
        }
    }
}