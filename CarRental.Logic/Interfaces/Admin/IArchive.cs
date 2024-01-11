// <copyright file="IArchive.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRental.Logic
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// IArchive interface, for Archive old Rentals.
    /// </summary>
    public interface IArchive
    {
        /// <summary>
        /// Archive rental.
        /// </summary>
        /// <param name="archivedRentalId"> ID of Rental to archive.</param>
        public void ArchiveFinished(int archivedRentalId);

        /// <summary>
        /// Using the <see cref="ArchiveFinished(int)"/> to archive all of the old Rentals.
        /// </summary>
        public void ArchiveAllFinished();

        /// <summary>
        /// Clean the old archives.
        /// </summary>
        /// <param name="days">Delete only the older than parameter, archives.</param>
        public void ClearOldArchives(int days);

        /// <summary>
        /// Creates a Dictionary of the old archives.
        /// </summary>
        /// <returns> An <see cref="IDictionary"/>, with <see cref="DateTime"/> Keys, and <see cref="string"/> Values.</returns>
        public IDictionary<DateTime, string> ShowArchived();
    }
}
