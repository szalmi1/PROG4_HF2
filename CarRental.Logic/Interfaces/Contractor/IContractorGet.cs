// <copyright file="IContractorGet.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRental.Logic
{
    /// <summary>
    /// Getters for contractor specific data.
    /// </summary>
    public interface IContractorGet : IUserGet
    {
        /// <summary>
        /// Gets the Address of the object.
        /// </summary>
        /// <param name="id">ID of object.</param>
        /// <returns>Address: <see cref="string"/>.</returns>
        string GetAddress(int id);

        /// <summary>
        /// Gets the Email of the object.
        /// </summary>
        /// <param name="id">ID of object.</param>
        /// <returns>Email: <see cref="string"/>.</returns>
        string GetEmail(int id);
    }
}
