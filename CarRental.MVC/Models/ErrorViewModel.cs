// <copyright file="ErrorViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRental.MVC.Models
{
    /// <summary>
    /// ErrorViewModel.
    /// </summary>
    public class ErrorViewModel
    {
        /// <summary>
        /// Gets or sets Request id.
        /// </summary>
        public string RequestId { get; set; }

        /// <summary>
        /// Gets a value indicating whether ShowRequestId.
        /// </summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(this.RequestId);
    }
}
