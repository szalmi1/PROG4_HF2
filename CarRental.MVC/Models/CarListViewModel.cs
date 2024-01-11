// <copyright file="CarListViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRental.MVC.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// CarListViewModel.
    /// </summary>
    public class CarListViewModel
    {
        /// <summary>
        /// Gets or sets the list of the cars.
        /// </summary>
        public List<Car> ListOfCars { get; set; }

        /// <summary>
        /// Gets or sets the selected car.
        /// </summary>
        public Car EditedCar { get; set; }
    }
}
