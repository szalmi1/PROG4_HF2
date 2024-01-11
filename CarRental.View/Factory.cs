// <copyright file="Factory.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace CarRental.View
{
    using System;
    using CarRental.Data;
    using CarRental.Logic;
    using CarRental.Repository;

    /// <summary>
    /// Class, what creates all of the Logics, Repositories, Data, using Dependency Injection.
    /// </summary>
    public class Factory : IDisposable
    {
        private RentalContext ctx;

        /// <summary>
        /// Initializes a new instance of the <see cref="Factory"/> class.
        /// </summary>
        public Factory()
        {
            ctx = new RentalContext();
            OwnerRepository ownerRepo = new OwnerRepository(ctx);
            CarRepository carRepo = new CarRepository(ctx);
            ContractorRepository contractorRepo = new ContractorRepository(ctx);
            RentalRepository rentalRepo = new RentalRepository(ctx);

            this.Owner = new OwnerLogic(ownerRepo, carRepo);
            this.Contractor = new ContractorLogic(contractorRepo, rentalRepo);
            this.Admin = new AdminLogic(ownerRepo, carRepo, contractorRepo, rentalRepo);
            this.Relation = new RelationLogic(ownerRepo, carRepo, contractorRepo, rentalRepo);
            this.Manage = new ManageLogic(ownerRepo, carRepo, contractorRepo, rentalRepo);
        }

        /// <summary>
        /// Gets or sets admin Logic, for High permission level operations.
        /// </summary>
        public AdminLogic Admin { get; set; }

        /// <summary>
        /// Gets or sets owner Logic, for Normal permission level operations.
        /// </summary>
        public OwnerLogic Owner { get; set; }

        /// <summary>
        /// Gets or sets contractor Logic, for Normal permission level operations.
        /// </summary>
        public ContractorLogic Contractor { get; set; }

        /// <summary>
        /// Gets or sets relation Logic, for complex two or more table operations.
        /// </summary>
        public RelationLogic Relation { get; set; }

        /// <summary>
        /// Gets or sets manage Logic, for add and delete operations.
        /// </summary>
        public ManageLogic Manage { get; set; }

        /// <summary>
        /// Disposable interface.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose.
        /// </summary>
        /// <param name="disposing">Yes/no.</param>
        protected virtual void Dispose(bool disposing)
        {
            this.ctx.Dispose();
        }
    }
}
