// <copyright file="IContractorModify.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRental.Logic
{
    /// <summary>
    /// Setters for Contractor specific data.
    /// </summary>
    public interface IContractorModify : IUserModify
    {
        /// <summary>
        /// Sets the Address of the Contractor.
        /// </summary>
        /// <param name="address">New Address.</param>
        /// <param name="id">Contractor ID.</param>
        void ChangeAddress(string address, int id);

        /// <summary>
        /// Sets the Email of the Contractor.
        /// </summary>
        /// <param name="email">New Email.</param>
        /// <param name="id">Contractor ID.</param>
        void ChangeEmail(string email, int id);
    }
}
