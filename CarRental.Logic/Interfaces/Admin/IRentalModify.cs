// <copyright file="IRentalModify.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRental.Logic
{
    using System;

    /// <summary>
    /// Setters for Rental, used by Admin.
    /// </summary>
    public interface IRentalModify
    {
        /// <summary>
        /// Changes Start of the Rental.
        /// </summary>
        /// <param name="input"> New Start.</param>
        /// <param name="id">Rental ID.</param>
        void ChangeStart(DateTime input, int id);

        /// <summary>
        /// Changes End of the Rental.
        /// </summary>
        /// <param name="input"> New End.</param>
        /// <param name="id">Rental ID.</param>
        void ChangeEnd(DateTime input, int id);

        /// <summary>
        /// Changes Paid of the Rental.
        /// </summary>
        /// <param name="id">Rental ID.</param>
        void ChangePaid(int id);

        /// <summary>
        /// Changes CarReturned of the Rental.
        /// </summary>
        /// <param name="id">Rental ID.</param>
        void ChangeCarReturned(int id);

        /// <summary>
        /// Changes Car of the Rental.
        /// </summary>
        /// <param name="car">New Car's ID.</param>
        /// <param name="id">Rental ID.</param>
        void ChangeCar(int car, int id);

        /// <summary>
        /// Changes Contractor of the Rental.
        /// </summary>
        /// <param name="contractor"> New Contractor.</param>
        /// <param name="id">Rental ID.</param>
        void ChangeContractor(int contractor, int id);
    }
}
