// <copyright file="IContractorManageRental.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRental.Logic
{
    using System.Collections.Generic;

    /// <summary>
    /// Methods for Contractors, to manage rentals.
    /// </summary>
    public interface IContractorManageRental
    {
        /// <summary>
        /// Method, to "Register" new rental, as Contractor.
        /// </summary>
        /// <param name="newRental">The new rental's data.</param>
        /// <param name="id">The contractor's id.</param>
        /// <param name="carId">The car's id.</param>
        void AddRental(IList<string> newRental, int? id, int? carId);

        /// <summary>
        /// Method, to "Extend" a rental, as Contractor.
        /// </summary>
        /// <param name="id">Rental's ID.</param>
        /// <param name="days">The Extension's length in days.</param>
        void ExtendRental(int id, int days);

        /// <summary>
        /// Method, to "Return car" for a rental, as Contractor.
        /// </summary>
        /// <param name="id">Rental's ID.</param>
        void ReturnCar(int id);

        /// <summary>
        /// Method, to "Pay rental", as Contractor.
        /// </summary>
        /// <param name="id">Rentals's ID.</param>
        void PayRental(int id);

        /// <summary>
        /// Creates an <see cref="IDictionary{TKey, TValue}"></see>, filled by Rentals need to be paid.
        /// </summary>
        /// <param name="id"> Contractor ID.</param>
        /// <returns><see cref="IDictionary{TKey, TValue}"></see> TKey: Rental ID, TValue: Rental.ToString().</returns>
        IDictionary<int, string> UnpaidRentals(int id);
    }
}
