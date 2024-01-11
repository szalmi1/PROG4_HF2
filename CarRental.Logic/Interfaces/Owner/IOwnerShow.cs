// <copyright file="IOwnerShow.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRental.Logic
{
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Methods to list, return owner specific data.
    /// </summary>
    public interface IOwnerShow
    {
        /// <summary>
        /// Method, to show cars owner.
        /// </summary>
        /// <param name="id">Car ID.</param>
        /// <returns>Key: OwnerId, Value: Owner.ToString().</returns>
        KeyValuePair<int, string> GetOwner(int id);

        /// <summary>
        /// Method, to list owners.
        /// </summary>
        /// <returns><see cref="IDictionary"/> where: Keys: Owners ID, Values: Owner.ToString().</returns>
        IDictionary<int, string> OwnerList();

        /// <summary>
        /// Method, to list owners car.
        /// </summary>
        /// <param name="id">Owner ID.</param>
        /// <returns><see cref="IDictionary"/> where: Keys: Cars ID, Values: Car.ToString().</returns>
        IDictionary<int, string> CarList(int id);
    }
}
