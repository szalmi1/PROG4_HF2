// <copyright file="IRelation.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRental.Logic
{
    using System.Collections.Generic;

    /// <summary>
    /// Interface of RelationLogic methods.
    /// </summary>
    public interface IRelation
    {
        /// <summary>
        /// Creates a <see cref="Dictionary{TKey, TValue}"/> of Cars need to return.
        /// </summary>
        /// <param name="contractorId">Contractor's ID.</param>
        /// <returns><see cref="Dictionary{TKey, TValue}"/>TKey: Rentals id, with the Car, need to return. TValue: necessary informations.</returns>
        IDictionary<int, string> NeedToReturn(int contractorId);

        /// <summary>
        /// Creates a <see cref="Dictionary{TKey, TValue}"/> of Car is in a rental.
        /// </summary>
        /// <param name="ownerId">Contractor's ID.</param>
        /// <returns><see cref="Dictionary{TKey, TValue}"/>TKey: Car's id. TValue: necessary informations.</returns>
        IDictionary<int, string> WhereAreMyCars(int ownerId);

        /// <summary>
        /// Creates a <see cref="Dictionary{TKey, TValue}"/> of Cars need to return.
        /// </summary>
        /// <param name="contractorId">Contractor's ID.</param>
        /// <returns><see cref="Dictionary{TKey, TValue}"/>TKey: Car's id, which is rentable. TValue: necessary informations.</returns>
        IDictionary<int, string> NearbyRentables(int contractorId);
    }
}
