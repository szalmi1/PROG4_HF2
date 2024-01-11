// <copyright file="Rental.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRental.Data
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Rental Class.
    /// </summary>
    [Table("Rentals")]
    public class Rental
    {
        /// <summary>
        /// Gets or sets the ID of Rental.
        /// </summary>
        /// <returns><see cref="int"/>. </returns>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RentalId { get; set; }

        /// <summary>
        /// Gets or sets the start date of the rent.
        /// </summary>
        /// <returns><see cref="DateTime"/>. </returns>
        [Required]
        public DateTime Start { get; set; }

        /// <summary>
        /// Gets or sets the end date of the rent.
        /// </summary>
        /// <returns><see cref="DateTime"/>. </returns>
        [Required]
        public DateTime End { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Paid or not.
        /// </summary>
        /// <returns><see cref="bool"/>. </returns>
        [Required]
        public bool Paid { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Car returned or not.
        /// </summary>
        /// <returns><see cref="bool"/>. </returns>
        [Required]
        public bool CarReturned { get; set; }

        /// <summary>
        /// Gets the length of the rental.
        /// </summary>
        /// <returns><see cref="int"/>. </returns>
        public int Length
        {
            get { return (int)(this.End - this.Start).TotalDays; }
        }

        /// <summary>
        /// Gets a value indicating whether Completed or not.
        /// </summary>
        /// <returns><see cref="bool"/>. </returns>
        public bool Completed
        {
            get { return this.Paid && this.CarReturned; }
        }

        /// <summary>
        /// Gets or sets Contractor.
        /// </summary>
        [NotMapped]
        public virtual Contractor Contractor { get; set; }

        /// <summary>
        /// Gets or sets ContractorId.
        /// </summary>
        /// <returns>Nullable <see cref="int"/>. </returns>
        [ForeignKey(nameof(Contractor))]
        [AllowNull]
        public int? ContractorId { get; set; }

        /// <summary>
        /// Gets or sets Car.
        /// </summary>
        [NotMapped]
        public virtual Car Car { get; set; }

        /// <summary>
        /// Gets or sets CarId.
        /// </summary>
        /// <returns>Nullable <see cref="bool"/>. </returns>
        [ForeignKey(nameof(Car))]
        [AllowNull]
        public int? CarId { get; set; }

        /// <summary>
        /// Overrides ToString(), with special string.
        /// </summary>
        /// <returns><see cref="string"/>. </returns>
        public override string ToString()
        {
            return $"{this.Start.ToString("yyyy.MM.dd.").PadRight(45)}" +
            $"{this.End.ToString("yyyy.MM.dd.").PadRight(50) + "\n"}" +
            $"{((this.Paid ? "    Paid" : "    Not paid") + (this.CarReturned ? " and car returned" : " and car isn't returned, yet.")).PadRight(49)}" +
            $"{(this.Length + "days long" + (this.Completed ? ", completed" : ", not completed")).PadRight(50)}\n";
        }
    }
}