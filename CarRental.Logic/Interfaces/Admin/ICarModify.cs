// <copyright file="ICarModify.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRental.Logic
{
    using System;

    /// <summary>
    /// Setters for Car.
    /// </summary>
    public interface ICarModify
    {
        /// <summary>
        /// Sets the Manufacturer of the Car.
        /// </summary>
        /// <param name="newManufacturer">New Manufacturer.</param>
        /// <param name="id">Car's ID.</param>
        void ChangeManufacturer(string newManufacturer, int id);

        /// <summary>
        /// Sets the Model of the Car.
        /// </summary>
        /// <param name="newModel">New Model.</param>
        /// <param name="id">Car's ID.</param>
        void ChangeModel(string newModel, int id);

        /// <summary>
        /// Sets the Class of the Car.
        /// </summary>
        /// <param name="newClass">New Class.</param>
        /// <param name="id">Car's ID.</param>
        void ChangeClass(string newClass, int id);

        /// <summary>
        /// Sets the Production of the Car.
        /// </summary>
        /// <param name="newProduction">New Production.</param>
        /// <param name="id">Car's ID.</param>
        void ChangeProduction(DateTime newProduction, int id);

        /// <summary>
        /// Changes the IsOperational of the Car.
        /// </summary>
        /// <param name="id">Car's ID.</param>
        void ChangeIsOperational(int id);

        /// <summary>
        /// Changes the Owner of the Car.
        /// </summary>
        /// <param name="id">Car's ID.</param>
        /// <param name="oldOwner"> ID of oldOwner.</param>
        /// <param name="newOwner">ID of newOwner.</param>
        void ChangeOwner(int id, int oldOwner, int? newOwner);
    }
}
