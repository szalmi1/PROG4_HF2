// <copyright file="Contractor.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRental.Data
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Contractor class.
    /// </summary>
    [Table("Contractors")]
    public class Contractor
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Contractor"/> class.
        /// Creating the HashSet for the Rentals.
        /// </summary>
        public Contractor()
        {
            this.Rentals = new HashSet<Rental>();
        }

        /// <summary>
        /// Gets or sets ContractorId.
        /// </summary>
        /// <returns><see cref="int"/>. </returns>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ContractorId { get; set; }

        /// <summary>
        /// Gets or sets FirstName.
        /// </summary>
        /// <returns><see cref="string"/>. </returns>
        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets LastName.
        /// </summary>
        /// <returns><see cref="string"/>. </returns>
        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets BirthDate.
        /// </summary>
        /// <returns><see cref="DateTime"/>. </returns>
        [Required]
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Gets or sets PhoneNumber.
        /// </summary>
        /// <returns><see cref="string"/>. </returns>
        [Required]
        [MaxLength(15)]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets Address.
        /// </summary>
        /// <returns><see cref="string"/>. </returns>
        [Required]
        [MaxLength(50)]
        public string City { get; set; }

        /// <summary>
        /// Gets or sets Email.
        /// </summary>
        /// <returns><see cref="string"/>. </returns>
        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

        /// <summary>
        /// Gets Rentals.
        /// </summary>
        /// <returns><see cref="ICollection"/> of <see cref="Rental"/>. </returns>
        [NotMapped]
        public virtual ICollection<Rental> Rentals { get; }

        /// <summary>
        /// Gets a value indicating whether Contractor has any Rentals.
        /// </summary>
        /// <returns><see cref="bool"/>. </returns>
        [NotMapped]
        public bool HasRentals
        {
            get { return this.Rentals != null && this.Rentals.Count > 0; }
        }

        /// <summary>
        /// Overrides ToString(), with special string.
        /// </summary>
        /// <returns><see cref="string"/>. </returns>
        public override string ToString()
        {
            return $"{(this.FirstName + " " + this.LastName).PadRight(45)}" +
            $"{("Address: " + this.City).PadRight(50) + "\n"}" +
            $"{("    Email: " + this.Email).PadRight(49)}" +
            $"{("Birthdate: " + this.BirthDate.ToString("yyyy. MM. dd")).PadRight(50)}\n";
        }
    }
}