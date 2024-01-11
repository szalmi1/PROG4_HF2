// <copyright file="IOwnerManageCar.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRental.Logic
{
    using System.Collections.Generic;

    /// <summary>
    /// Methods for Owners, to manage car.
    /// </summary>
    public interface IOwnerManageCar
    {
        /// <summary>
        /// Method, to "Register" new car, as an Owner.
        /// </summary>
        /// <param name="newCar">The newCars data.</param>
        /// <param name="id">the newCars owner id.</param>
        void AddCar(IList<string> newCar, int? id);

        /// <summary>
        /// Method, to "Fix" a car, as an Owner.
        /// </summary>
        /// <param name="id">Car's ID.</param>
        void FixCar(int id);

        /// <summary>
        /// Method, to "Sell" a car, as an Owner.
        /// </summary>
        /// <param name="id">Car's ID.</param>
        /// <param name="newOwner">New owner's ID.</param>
        void SellCar(int id, int? newOwner);

        /// <summary>
        /// Creates an <see cref="IDictionary{TKey, TValue}"></see>, filled by Cars need to fix.
        /// </summary>
        /// <param name="id"> Owner ID.</param>
        /// <returns><see cref="IDictionary{TKey, TValue}"></see> TKey: Car ID, TValue: Car.ToString().</returns>
        IDictionary<int, string> CarNeedFix(int id);

        /// <summary>
        /// Creates an <see cref="IDictionary{TKey, TValue}"></see>, filled by Cars available, or not available.
        /// </summary>
        /// <param name="id"> Owner ID.</param>
        /// <param name="availableOrUnavailable">Available(true) or Unavailable(false).</param>
        /// <returns><see cref="IDictionary{TKey, TValue}"></see> TKey: Car ID, TValue: Car.ToString().</returns>
        IDictionary<int, string> CarAvailable(int id, bool availableOrUnavailable = true);
    }
}
