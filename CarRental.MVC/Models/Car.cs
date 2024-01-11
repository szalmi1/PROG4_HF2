// <copyright file="Car.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRental.MVC.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    /// <summary>
    /// Owner.
    /// </summary>
    public class Car
    {
            /// <summary>
            /// Gets or sets Id.
            /// </summary>
            [Display(Name = "Car ID")]
            public int Id { get; set; }

            /// <summary>
            /// Gets or sets manufacturer.
            /// </summary>
            [Display(Name = "Manufacturer")]
            [Required]
            public string Manufacturer { get; set; }

            /// <summary>
            /// Gets or sets Model.
            /// </summary>
            [Display(Name = "Model")]
            [Required]
            public string Model { get; set; }

            /// <summary>
            /// Gets or sets class.
            /// </summary>
            [Display(Name = "Class")]
            public string Class { get; set; }

            /// <summary>
            /// Gets or sets Date.
            /// </summary>
            [Display(Name = "Production")]
            [DisplayFormat(DataFormatString = "{0:yyyy}")]
            [Required]
            public DateTime Production { get; set; }

            /// <summary>
            /// Gets or sets a value indicating whether isOperational.
            /// </summary>
            [Display(Name = "Operational?")]
            public bool IsOperational { get; set; }

            /// <summary>
            /// Gets or sets a value of ownerId.
            /// </summary>
            [Display(Name = "Owner ID")]
            public int? OwnerId { get; set; }

            /// <summary>
            /// Copies a Car into another.
            /// </summary>
            /// <param name="other">Other car.</param>
            public void CopyFrom(Car other)
            {
                this.GetType().GetProperties().ToList().ForEach(
                property => property.SetValue(this, property.GetValue(other)));
            }
    }
}
