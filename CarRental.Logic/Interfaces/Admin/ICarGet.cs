// <copyright file="ICarGet.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRental.Logic
{
    using System;

    /// <summary>
    /// Getters for car properties.
    /// </summary>
    public interface ICarGet
    {
        /// <summary>
        /// Gets the Manufacturer of the Car.
        /// </summary>
        /// <param name="id">Car's ID.</param>
        /// <returns><see cref="string"/>: Manufacturer.</returns>
        string GetManufacturer(int id);

        /// <summary>
        /// Gets the Model of the Car.
        /// </summary>
        /// <param name="id">Car's ID.</param>
        /// <returns><see cref="string"/>: Model.</returns>
        string GetModel(int id);

        /// <summary>
        /// Gets the Class of the Car.
        /// </summary>
        /// <param name="id">Car's ID.</param>
        /// <returns><see cref="string"/>: Class.</returns>
        string GetClass(int id);

        /// <summary>
        /// Gets the Production of the Car.
        /// </summary>
        /// <param name="id">Car's ID.</param>
        /// <returns><see cref="DateTime"/>: Production.</returns>
        DateTime GetProduction(int id);

        /// <summary>
        /// Gets the IsOperational of the Car.
        /// </summary>
        /// <param name="id">Car's ID.</param>
        /// <returns><see cref="bool"/>: IsOperational.</returns>
        bool GetIsOperational(int id);
    }
}
