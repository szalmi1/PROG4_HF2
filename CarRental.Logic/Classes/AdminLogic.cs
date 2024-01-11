// <copyright file="AdminLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRental.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CarRental.Repository;

    /// <summary>
    /// AdminLogic, for operations, what registered users shouldn't have to access.
    /// </summary>
    public class AdminLogic : ManageLogic, ICarGet, ICarModify, IRentalGet, IRentalModify, IArchive
    {
        private readonly string password;

        /// <summary>
        /// Initializes a new instance of the <see cref="AdminLogic"/> class.
        /// Passes references to base( ManageLogic), sets Daily admin password, creates ArchivedRentals.
        /// </summary>
        /// <param name="owner">Owner Repository.</param>
        /// <param name="car">Car Repository.</param>
        /// <param name="contractor">Contractor Repository.</param>
        /// <param name="rental">Rental Repository.</param>
        public AdminLogic(
            IOwnerRepository owner,
            ICarRepository car,
            IContractorRepository contractor,
            IRentalRepository rental)
        : base(owner, car, contractor, rental)
        {
            this.ArchivedRentals = new Dictionary<DateTime, string>();
            this.password = "Passw0rd" + DateTime.Now.Day.ToString();
        }

        /// <summary>
        /// Gets or sets an IDictionary:
        /// Key: DateTime: Start of Finished rental.
        /// Value: string: Rental.ToString().
        /// Contains Old, archived rentals.
        /// </summary>
        private IDictionary<DateTime, string> ArchivedRentals { get; set; }

        /// <summary>
        /// Login for Admins.
        /// </summary>
        /// <param name="password">The entered password.</param>
        /// <returns><see cref="bool"/>: login success or fail.</returns>
        public bool AdminLogin(string password)
        {
            return password == this.password;
        }

        #region ICarGet

        /// <inheritdoc/>
        public string GetManufacturer(int id)
        {
            return this.CarRepo.GetOne(id).Manufacturer;
        }

        /// <inheritdoc/>
        public string GetModel(int id)
        {
            return this.CarRepo.GetOne(id).Model;
        }

        /// <inheritdoc/>
        public string GetClass(int id)
        {
            return this.CarRepo.GetOne(id).Class;
        }

        /// <inheritdoc/>
        public DateTime GetProduction(int id)
        {
            return this.CarRepo.GetOne(id).Production;
        }

        /// <inheritdoc/>
        public bool GetIsOperational(int id)
        {
            return this.CarRepo.GetOne(id).IsOperational;
        }
        #endregion

        #region ICarModify

        /// <inheritdoc/>
        public void ChangeManufacturer(string newManufacturer, int id)
        {
            var op = this.CarRepo.GetOne(id);
            op.Manufacturer = newManufacturer;
            this.CarRepo.Save();
        }

        /// <inheritdoc/>
        public void ChangeModel(string newModel, int id)
        {
            var op = this.CarRepo.GetOne(id);
            op.Model = newModel;
            this.CarRepo.Save();
        }

        /// <inheritdoc/>
        public void ChangeClass(string newClass, int id)
        {
            var op = this.CarRepo.GetOne(id);
            op.Class = newClass;
            this.CarRepo.Save();
        }

        /// <inheritdoc/>
        public void ChangeProduction(DateTime newProduction, int id)
        {
            var op = this.CarRepo.GetOne(id);
            op.Production = newProduction;
            this.CarRepo.Save();
        }

        /// <inheritdoc/>
        public void ChangeIsOperational(int id)
        {
            var op = this.CarRepo.GetOne(id);
            op.IsOperational = !op.IsOperational;
            this.CarRepo.Save();
        }

        /// <inheritdoc/>
        public void ChangeOwner(int id, int oldOwner, int? newOwner)
        {
            var op = this.CarRepo.GetOne(id);
            this.OwnerRepo.GetOne(oldOwner).Cars.Remove(op);
            if (newOwner != null)
            {
                this.OwnerRepo.GetOne((int)newOwner).Cars.Add(op);
            }

            op.OwnerId = newOwner;
            this.CarRepo.Save();
        }
        #endregion

        #region IRentalGet

        /// <inheritdoc/>
        public DateTime GetStart(int id)
        {
            return this.RentalRepo.GetOne((int)id).Start;
        }

        /// <inheritdoc/>
        public DateTime GetEnd(int id)
        {
            return this.RentalRepo.GetOne(id).End;
        }

        /// <inheritdoc/>
        public bool GetPaid(int id)
        {
            return this.RentalRepo.GetOne(id).Paid;
        }

        /// <inheritdoc/>
        public bool GetCarReturned(int id)
        {
            return this.RentalRepo.GetOne(id).CarReturned;
        }

        /// <inheritdoc/>
        public int GetLength(int id)
        {
            return this.RentalRepo.GetOne(id).Length;
        }

        /// <inheritdoc/>
        public bool GetCompleted(int id)
        {
            return this.RentalRepo.GetOne(id).Completed;
        }
        #endregion

        #region IRentalModify

        /// <inheritdoc/>
        public void ChangeStart(DateTime input, int id)
        {
            var rental = this.RentalRepo.GetOne(id);
            rental.Start = input;
            this.RentalRepo.Save();
        }

        /// <inheritdoc/>
        public void ChangeEnd(DateTime input, int id)
        {
            var rental = this.RentalRepo.GetOne(id);
            rental.End = input;
            this.RentalRepo.Save();
        }

        /// <inheritdoc/>
        public void ChangePaid(int id)
        {
            var rental = this.RentalRepo.GetOne(id);
            rental.Paid = !rental.Paid;
            this.RentalRepo.Save();
        }

        /// <inheritdoc/>
        public void ChangeCarReturned(int id)
        {
            var rental = this.RentalRepo.GetOne(id);
            rental.CarReturned = !rental.CarReturned;
            this.RentalRepo.Save();
        }

        /// <inheritdoc/>
        public void ChangeCar(int car, int id)
        {
            var rental = this.RentalRepo.GetOne(id);
            rental.CarId = car;
            this.RentalRepo.Save();
        }

        /// <inheritdoc/>
        public void ChangeContractor(int contractor, int id)
        {
            var rental = this.RentalRepo.GetOne(id);
            rental.ContractorId = contractor;
            this.RentalRepo.Save();
        }
        #endregion

        #region IManage

        /// <inheritdoc/>
        public void ArchiveFinished(int archivedRentalId)
        {
            var item = this.RentalRepo.GetOne(archivedRentalId);
            if (item.Completed)
            {
                while (this.ArchivedRentals.ContainsKey(item.End))
                {
                    item.End.AddMilliseconds(1);
                }

                this.ArchivedRentals.Add(item.End, this.RentalRepo.GetOne(archivedRentalId).ToString());
                this.RentalRepo.Delete(archivedRentalId);
            }
        }

        /// <inheritdoc/>
        public void ArchiveAllFinished()
        {
            foreach (var rental in this.RentalRepo.GetAll().ToList().Where(x => x.Completed == true))
            {
                this.ArchiveFinished(rental.RentalId);
            }
        }

        /// <inheritdoc/>
        public void ClearOldArchives(int days)
        {
            var temp = this.ArchivedRentals.Where(x => (DateTime.Now - x.Key).TotalDays > days);
            foreach (var oldarchive in temp)
            {
                this.ArchivedRentals.Remove(oldarchive);
            }
        }

        /// <inheritdoc/>
        public IDictionary<DateTime, string> ShowArchived()
        {
            return this.ArchivedRentals.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
        }

        #endregion

    }
}