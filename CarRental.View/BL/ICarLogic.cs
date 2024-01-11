// <copyright file="ICarLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRental.View.BL
{
    using System.Collections.Generic;
    using CarRental.View.DATA;

    /// <summary>
    /// Car logic.
    /// </summary>
    public interface ICarLogic
    {
        /// <summary>
        /// AddCar operation.
        /// </summary>
        /// <param name="list">CarList.</param>
        void AddCar(IList<Car> list);

        /// <summary>
        /// ModCar operation.
        /// </summary>
        /// <param name="car">Car.</param>
        void ModCar(Car car);

        /// <summary>
        /// DelCar operation.
        /// </summary>
        /// <param name="list">Car list.</param>
        /// <param name="car">Car.</param>
        void DelCar(IList<Car> list, Car car);

        /// <summary>
        /// Get all Cars operation.
        /// </summary>
        /// <returns>List of Cars.</returns>
        IList<Car> GetAllCars();
    }
}
