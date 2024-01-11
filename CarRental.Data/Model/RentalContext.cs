// <copyright file="RentalContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRental.Data
{
    using System;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// RentalContext class.
    /// </summary>
    public class RentalContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RentalContext"/> class.
        /// </summary>
        public RentalContext()
        {
                this.Database.EnsureCreated();
        }

        /// <summary>
        /// Gets or sets Owners.
        /// </summary>
        /// <returns>DataBase set of <see cref="Owner"/>. </returns>
        public virtual DbSet<Owner> Owners { get; set; }

        /// <summary>
        /// Gets or sets Cars.
        /// </summary>
        /// <returns>DataBase set of <see cref="Car"/>. </returns>
        public virtual DbSet<Car> Cars { get; set; }

        /// <summary>
        /// Gets or sets Contractors.
        /// </summary>
        /// <returns>DataBase set of <see cref="Contractor"/>. </returns>
        public virtual DbSet<Contractor> Contractors { get; set; }

        /// <summary>
        /// Gets or sets Rentals.
        /// </summary>
        /// <returns>DataBase set of <see cref="Rental"/>. </returns>
        public virtual DbSet<Rental> Rentals { get; set; }

        /// <summary>
        /// Configures the access of the Database.
        /// </summary>
        /// <param name="optionsBuilder">Options builder.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder != null)
            {
                if (!optionsBuilder.IsConfigured)
                {
                    optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = |DataDirectory|\CarRentalDatabase.mdf; Integrated Security = True");
                }
            }
            else
            {
                throw new ArgumentNullException(nameof(optionsBuilder));
            }
        }

        /// <summary>
        /// Creating the tables of the Database.
        /// </summary>
        /// <param name="modelBuilder">Model builder.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Generate data = new Generate(20, 50, 25, 15);
            if (modelBuilder != null)
            {
                modelBuilder.Entity<Car>(entity =>
                {
                    entity.HasOne(car => car.Owner)
                        .WithMany(owner => owner.Cars)
                        .HasForeignKey(car => car.OwnerId)
                        .OnDelete(DeleteBehavior.SetNull);
                });
                modelBuilder.Entity<Rental>(entity =>
                {
                    entity.HasOne(rental => rental.Contractor)
                        .WithMany(contractor => contractor.Rentals)
                        .HasForeignKey(rental => rental.ContractorId)
                        .OnDelete(DeleteBehavior.SetNull);
                });
            }
            else
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }

            modelBuilder.Entity<Owner>().HasData(data.Owners);
            modelBuilder.Entity<Car>().HasData(data.Cars);
            modelBuilder.Entity<Contractor>().HasData(data.Contractors);
            modelBuilder.Entity<Rental>().HasData(data.Rentals);
        }
    }
}