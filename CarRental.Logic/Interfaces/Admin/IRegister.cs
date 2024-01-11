// <copyright file="IRegister.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRental.Logic
{
    using System.Collections.Generic;

    /// <summary>
    /// Class to register new data.
    /// </summary>
    public interface IRegister
    {
        /// <summary>
        /// "Register" new Owner.
        /// </summary>
        /// <param name="input"> All of the required data of Owner.</param>
        void AddOwner(IList<string> input);

        /// <summary>
        /// "Register" new Car.
        /// </summary>
        /// <param name="input"> All of the required data of Car.</param>
        /// <param name="owner"> Owner ID of Car.</param>
        void AddCar(IList<string> input, int? owner);

        /// <summary>
        /// "Register" new Contractor.
        /// </summary>
        /// <param name="input"> All of the required data of Contractor.</param>
        void AddContractor(IList<string> input);

        /// <summary>
        /// "Register" new Owner.
        /// </summary>
        /// <param name="input"> All of the required data of Owner.</param>
        /// <param name="contractor"> Contractor ID of Rental.</param>
        /// <param name="car"> Car ID of Rental.</param>
        void AddRental(IList<string> input, int? contractor, int? car);
    }
}
