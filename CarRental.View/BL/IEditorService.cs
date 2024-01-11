// <copyright file="IEditorService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRental.View.BL
{
    using CarRental.View.DATA;

    /// <summary>
    /// IEditorService.
    /// </summary>
    public interface IEditorService
    {
        /// <summary>
        /// Edit car operation.
        /// </summary>
        /// <param name="c">Car.</param>
        /// <returns>True when, success and false, if not.</returns>
        bool EditCar(Car c);
    }
}
