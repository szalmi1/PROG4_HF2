// <copyright file="Car.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRental.Data
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Car public class.
    /// </summary>
    [Table("Cars")]
    public class Car
    {
        /// <summary>
        /// Gets or sets CarId.
        /// </summary>
        /// <returns><see cref="int"/>. </returns>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CarId { get; set; }

        /// <summary>
        /// Gets or sets Manufacturer.
        /// </summary>
        /// <returns><see cref="string"/>. </returns>
        [Required]
        [MaxLength(30)]
        public string Manufacturer { get; set; }

        /// <summary>
        /// Gets or sets Model.
        /// </summary>
        /// <returns><see cref="string"/>. </returns>
        [Required]
        [MaxLength(30)]
        public string Model { get; set; }

        /// <summary>
        /// Gets or sets Class.
        /// </summary>
        /// <returns><see cref="string"/>. </returns>
        [Required]
        [MaxLength(20)]
        public string Class { get; set; }

        /// <summary>
        /// Gets or sets Production.
        /// </summary>
        /// <returns><see cref="DateTime"/>. </returns>
        [Required]
        public DateTime Production { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether IsOperational or not.
        /// </summary>
        /// <returns><see cref="bool"/>. </returns>
        [Required]
        public bool IsOperational { get; set; }

        /// <summary>
        ///  Gets or sets reference for Owner object.
        /// </summary>
        [NotMapped]
        public virtual Owner Owner { get; set; }

        /// <summary>
        /// Gets or sets OwnerId.
        /// </summary>
        /// <returns>Nullable <see cref="int"/>. </returns>
        [ForeignKey(nameof(Owner))]
        [AllowNull]
        public int? OwnerId { get; set; }

        /// <summary>
        /// Gets or sets reference for Rental object.
        /// </summary>
        [NotMapped]
        public virtual Rental Rental { get; set; }

        /// <summary>
        /// Gets or sets RentalId.
        /// </summary>
        /// <returns>Nullable <see cref="int"/>. </returns>
        [ForeignKey(nameof(Rental))]
        [AllowNull]
        public int? RentalId { get; set; }

        /// <summary>
        /// Overrides ToString(), with special string.
        /// </summary>
        /// <returns><see cref="string"/>. </returns>
        public override string ToString()
        {
            return $"{(this.Manufacturer + " " + this.Model).PadRight(45)}" +
            $"{("Class: " + this.Class).PadRight(50) + "\n"}" +
            $"{("    Production: " + this.Production.ToString("yyyy")).PadRight(49)}" +
            $"{("Operational: " + (this.IsOperational ? "Working" : "Service required")).PadRight(50)}\n";
        }
    }
}