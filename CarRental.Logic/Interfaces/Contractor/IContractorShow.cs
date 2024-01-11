// <copyright file="IContractorShow.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRental.Logic
{
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Methods to list, return contractor specific data.
    /// </summary>
    public interface IContractorShow
    {
        /// <summary>
        /// Method, to show rental's contractor.
        /// </summary>
        /// <param name="id">Rental ID.</param>
        /// <returns>Key: ContractorId, Value: Contractor.ToString().</returns>
        KeyValuePair<int, string> GetContractor(int id);

        /// <summary>
        /// Method, to list contractors.
        /// </summary>
        /// <returns><see cref="IDictionary"/> where: Keys: Contractors ID, Values: Contractor.ToString().</returns>
        IDictionary<int, string> ContractorList();

        /// <summary>
        /// Method, to list contractors rentals.
        /// </summary>
        /// <param name="id">Contractor ID.</param>
        /// <returns><see cref="IDictionary"/> where: Keys: Rentals ID, Values: Rental.ToString().</returns>
        IDictionary<int, string> RentalList(int id);
    }
}
