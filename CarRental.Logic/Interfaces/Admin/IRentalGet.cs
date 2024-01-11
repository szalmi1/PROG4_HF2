// <copyright file="IRentalGet.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRental.Logic
{
    using System;

    /// <summary>
    /// Getters for Rental data, used by Admin.
    /// </summary>
    public interface IRentalGet
    {
        /// <summary>
        /// Gets the Start of the Rental.
        /// </summary>
        /// <param name="id">Rental ID.</param>
        /// <returns><see cref="DateTime"/>: Start.</returns>
        DateTime GetStart(int id);

        /// <summary>
        /// Gets the End of the Rental.
        /// </summary>
        /// <param name="id">Rental ID.</param>
        /// <returns><see cref="DateTime"/>: End.</returns>
        DateTime GetEnd(int id);

        /// <summary>
        /// Gets Paid of the Rental.
        /// </summary>
        /// <param name="id">Rental ID.</param>
        /// <returns><see cref="bool"/>: Paid.</returns>
        bool GetPaid(int id);

        /// <summary>
        /// Gets CarReturned of the Rental.
        /// </summary>
        /// <param name="id">Rental ID.</param>
        /// <returns><see cref="bool"/>: CarReturned.</returns>
        bool GetCarReturned(int id);

        /// <summary>
        /// Gets the Length of the Rental.
        /// </summary>
        /// <param name="id">Rental ID.</param>
        /// <returns><see cref="int"/>: Length.</returns>
        int GetLength(int id);

        /// <summary>
        /// Gets Completed of the Rental.
        /// </summary>
        /// <param name="id">Rental ID.</param>
        /// <returns><see cref="bool"/>: Completed.</returns>
        bool GetCompleted(int id);
    }
}