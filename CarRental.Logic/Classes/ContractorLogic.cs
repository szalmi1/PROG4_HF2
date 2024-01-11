// <copyright file="ContractorLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRental.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CarRental.Repository;

    /// <summary>
    /// ContractorLogic, for operations, what Contractors have to access.
    /// </summary>
    public class ContractorLogic : IContractorShow, IContractorGet, IContractorModify, IContractorManageRental
    {
        private IContractorRepository contractorRepo;
        private IRentalRepository rentalRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContractorLogic"/> class.
        /// Sets necessary repositories, to work with.
        /// </summary>
        /// <param name="contractorRepo">Contractor Repository.</param>
        /// <param name="rentalRepo">Rental Repository.</param>
        public ContractorLogic(IContractorRepository contractorRepo, IRentalRepository rentalRepo)
        {
            this.contractorRepo = contractorRepo;
            this.rentalRepo = rentalRepo;
            this.CurrentId = 0;
            this.CurrentRental = 0;
        }

        /// <summary>
        /// Gets or sets the current ID of Contractors.
        /// </summary>
        public int CurrentId { get; set; }

        /// <summary>
        /// Gets or sets the current ID of Contractor's rental.
        /// </summary>
        public int CurrentRental { get; set; }

        /// <inheritdoc/>
        public KeyValuePair<int, string> GetContractor(int id)
        {
            var contractor = this.contractorRepo.GetOne(id);
            return new KeyValuePair<int, string>(contractor.ContractorId, contractor.ToString());
        }

        /// <inheritdoc/>
        public IDictionary<int, string> ContractorList()
        {
            Dictionary<int, string> temp = new Dictionary<int, string>();
            foreach (var rental in this.contractorRepo.GetAll())
            {
                temp.Add(rental.ContractorId, rental.ToString());
            }

            return temp.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
        }

        /// <inheritdoc/>
        public IDictionary<int, string> RentalList(int id = 0)
        {
            Dictionary<int, string> temp = new Dictionary<int, string>();
            if (id < 1)
            {
                foreach (var rental in this.rentalRepo.GetAll())
                {
                    temp.Add(rental.RentalId, rental.ToString());
                }
            }
            else
            {
                foreach (var rental in this.rentalRepo.GetAll().Where(x => x.ContractorId == id))
                {
                    temp.Add(rental.RentalId, rental.ToString());
                }
            }

            return temp.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
        }

        /// <inheritdoc/>
        public IDictionary<int, string> UnpaidRentals(int id)
        {
            Dictionary<int, string> temp = new Dictionary<int, string>();
            if (id > 0)
            {
                foreach (var rental in this.rentalRepo.GetAll().Where(x => x.Paid == false).Where(x => x.ContractorId == id))
                {
                    temp.Add(rental.RentalId, rental.ToString());
                }
            }

            return temp.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
        }

        /// <inheritdoc/>
        public string GetFirstName(int id)
        {
            return this.contractorRepo.GetOne(id).FirstName;
        }

        /// <inheritdoc/>
        public string GetLastName(int id)
        {
            return this.contractorRepo.GetOne(id).LastName;
        }

        /// <inheritdoc/>
        public DateTime GetBirthDate(int id)
        {
            return this.contractorRepo.GetOne(id).BirthDate;
        }

        /// <inheritdoc/>
        public string GetPhoneNumber(int id)
        {
            return this.contractorRepo.GetOne(id).PhoneNumber;
        }

        /// <inheritdoc/>
        public string GetAddress(int id)
        {
            return this.contractorRepo.GetOne(id).City;
        }

        /// <inheritdoc/>
        public string GetEmail(int id)
        {
            return this.contractorRepo.GetOne(id).Email;
        }

        /// <inheritdoc/>
        public void ChangeFirstName(string input, int id)
        {
            var op = this.contractorRepo.GetOne(id);
            op.FirstName = input;
            this.contractorRepo.Save();
        }

        /// <inheritdoc/>
        public void ChangeLastName(string input, int id)
        {
            var op = this.contractorRepo.GetOne(id);
            op.LastName = input;
            this.contractorRepo.Save();
        }

        /// <inheritdoc/>
        public void ChangeBirthDate(DateTime input, int id)
        {
            var op = this.contractorRepo.GetOne(id);
            op.BirthDate = input;
            this.contractorRepo.Save();
        }

        /// <inheritdoc/>
        public void ChangePhoneNumber(string input, int id)
        {
            var op = this.contractorRepo.GetOne(id);
            op.PhoneNumber = input;
            this.contractorRepo.Save();
        }

        /// <inheritdoc/>
        public void ChangeAddress(string address, int id)
        {
            var op = this.contractorRepo.GetOne(id);
            op.City = address;
            this.contractorRepo.Save();
        }

        /// <inheritdoc/>
        public void ChangeEmail(string email, int id)
        {
            var op = this.contractorRepo.GetOne(id);
            op.Email = email;
            this.contractorRepo.Save();
        }

        /// <inheritdoc/>
        public void AddRental(IList<string> newRental, int? id = null, int? carId = null)
        {
            if (newRental != null && newRental.Count == 2)
            {
                this.rentalRepo.Add(
                FormatLogic.FormatDate(newRental[0]),
                FormatLogic.FormatDate(newRental[1]),
                id,
                carId);
            }
        }

        /// <inheritdoc/>
        public void ExtendRental(int id, int days)
        {
            if (id > 0)
            {
                this.rentalRepo.GetOne(id).End.AddDays(days);
                this.contractorRepo.Save();
            }
        }

        /// <inheritdoc/>
        public void ReturnCar(int id)
        {
            if (id > 0)
            {
                this.rentalRepo.GetOne(id).CarReturned = true;
                this.contractorRepo.Save();
            }
        }

        /// <inheritdoc/>
        public void PayRental(int id)
        {
            if (id > 0)
            {
                this.rentalRepo.GetOne(id).Paid = true;
                this.contractorRepo.Save();
            }
        }
    }
}
