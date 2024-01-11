// <copyright file="IOwnerGet.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRental.Logic
{
    /// <summary>
    /// Getters for owner specific data.
    /// </summary>
    public interface IOwnerGet : IUserGet
    {
        /// <summary>
        /// Gets the RentalCompany of the object.
        /// </summary>
        /// <param name="id">ID of object.</param>
        /// <returns>RentalCompany: <see cref="string"/>.</returns>
        string GetRentalCompany(int id);

        /// <summary>
        /// Gets the Location of the object.
        /// </summary>
        /// <param name="id">ID of object.</param>
        /// <returns>Location: <see cref="string"/>.</returns>
        string GetLocation(int id);
    }
}
