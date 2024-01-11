// <copyright file="Owner.cs" company="PlaceholderCompany">
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
    /// Owner class.
    /// </summary>
    [Table("Owners")]
    public class Owner
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Owner"/> class.
        /// </summary>
        public Owner()
        {
            this.Cars = new HashSet<Car>();
        }

        /// <summary>
        /// Gets or sets OwnerId.
        /// </summary>
        /// <returns><see cref="int"/>. </returns>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OwnerId { get; set; }

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
        /// Gets or sets RentalCompany.
        /// </summary>
        /// <returns><see cref="string"/>. </returns>
        [Required]
        [MaxLength(50)]
        public string RentalCompany { get; set; }

        /// <summary>
        /// Gets or sets Site.
        /// </summary>
        /// <returns><see cref="string"/>. </returns>
        [Required]
        [MaxLength(50)]
        public string Location { get; set; }

        /// <summary>
        /// Gets Cars.
        /// </summary>
        /// <returns><see cref="ICollection"/> of <see cref="Car"/>. </returns>
        public virtual ICollection<Car> Cars { get; }

        /// <summary>
        /// Overrides ToString(), with a special, formatted string.
        /// </summary>
        /// <returns><see cref="string"/>. </returns>
        public override string ToString()
        {
            return $"{(this.FirstName + " " + this.LastName).PadRight(45)}" +
            $"{("Birthdate: " + this.BirthDate.ToString("yyyy. MM. dd")).PadRight(50) + "\n"}" +
            $"{("    Company:" + this.RentalCompany).PadRight(49)}" +
            $"{("Registered: " + this.Location).PadRight(50)}\n";
        }
    }
}