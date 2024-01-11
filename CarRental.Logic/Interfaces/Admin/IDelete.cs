// <copyright file="IDelete.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRental.Logic
{
    /// <summary>
    /// Methods, to delete objects.
    /// </summary>
    public interface IDelete
    {
        /// <summary>
        /// Deletes Owner by ID.
        /// </summary>
        /// <param name="id">Owner ID.</param>
        void DeleteOwner(int id);

        /// <summary>
        /// Deletes Car by ID.
        /// </summary>
        /// <param name="id">Car ID.</param>
        void DeleteCar(int id);

        /// <summary>
        /// Deletes Contractor by ID.
        /// </summary>
        /// <param name="id">Contractor ID.</param>
        void DeleteContractor(int id);

        /// <summary>
        /// Deletes Rental by ID.
        /// </summary>
        /// <param name="id">Rental ID.</param>
        void DeleteRental(int id);
    }
}
