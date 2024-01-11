// <copyright file="IOwnerModify.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRental.Logic
{
    /// <summary>
    /// Setters for Owner specific data.
    /// </summary>
    public interface IOwnerModify : IUserModify
    {
        /// <summary>
        /// Sets the RentalCompany of the Owner.
        /// </summary>
        /// <param name="input">New RentalCompany.</param>
        /// <param name="id">Owner ID.</param>
        void ChangeRentalCompany(string input, int id);

        /// <summary>
        /// Sets the Location of the Owner.
        /// </summary>
        /// <param name="input">New Location.</param>
        /// <param name="id">Owner ID.</param>
        void ChangeLocation(string input, int id);
    }
}
