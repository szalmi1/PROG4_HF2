// <copyright file="ICarRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRental.Repository
{
    using System;
    using CarRental.Data;

    /// <summary>
    /// ICarRepository interface.
    /// </summary>
    public interface ICarRepository : IRepository<Car>
    {
        /// <summary>
        /// Adds a new <see cref="Car"/> to the Car table by reaching Data Layer.
        /// </summary>
        /// <param name="manufacturer">Cars manufacturer name.</param>
        /// <param name="model">Car model name.</param>
        /// <param name="carclass">Car class.</param>
        /// <param name="production">Car's production date.</param>
        /// <param name="isOperational">Is the car operational?.</param>
        /// <param name="ownerId">The owner's ID, can be null.</param>
        void Add(string manufacturer, string model, string carclass, DateTime production, bool isOperational, int? ownerId);

        /// <summary>
        /// Returns Car object with the given ID.
        /// </summary>
        /// <param name="id">Car's id.</param>
        /// <returns><see cref="Car"/> object.</returns>
        new Car GetOne(int id);

        // void Set(int id, Car newCar);
    }
}