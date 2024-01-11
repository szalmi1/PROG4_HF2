// <copyright file="OwnerLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRental.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CarRental.Repository;

    /// <summary>
    /// OwnerLogic, for operations, what Owners have to access.
    /// </summary>
    public class OwnerLogic : IOwnerShow, IOwnerGet, IOwnerModify, IOwnerManageCar
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OwnerLogic"/> class.
        /// </summary>
        /// <param name="ownerRepo">Owner Repository.</param>
        /// <param name="carRepo">Car Repository.</param>
        public OwnerLogic(IOwnerRepository ownerRepo, ICarRepository carRepo)
        {
            this.OwnerRepo = ownerRepo;
            this.CarRepo = carRepo;
            this.CurrentId = 0;
            this.CarId = 0;
        }

        /// <summary>
        /// Gets or sets the current ID of Owners.
        /// </summary>
        public int CurrentId { get; set; }

        /// <summary>
        /// Gets or sets the current ID of Owner's car.
        /// </summary>
        public int CarId { get; set; }

        private IOwnerRepository OwnerRepo { get; set; }

        private ICarRepository CarRepo { get; set; }

        /// <inheritdoc/>
        public KeyValuePair<int, string> GetOwner(int id)
        {
            try
            {
                var ownerId = this.CarRepo.GetOne(id).OwnerId;
                var owner = this.OwnerRepo.GetOne(ownerId == null ? throw new InvalidOperationException("Nincs tulajdonos") : (int)ownerId);
                return new KeyValuePair<int, string>(owner.OwnerId, owner.ToString());
            }
            catch (System.InvalidOperationException)
            {
                return default;
            }
        }

        /// <inheritdoc/>
        public IDictionary<int, string> OwnerList()
        {
            Dictionary<int, string> temp = new Dictionary<int, string>();
            foreach (var owner in this.OwnerRepo.GetAll())
            {
                temp.Add(owner.OwnerId, owner.ToString());
            }

            return temp.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
        }

        /// <inheritdoc/>
        public IDictionary<int, string> CarList(int id = 0)
        {
            Dictionary<int, string> temp = new Dictionary<int, string>();
            if (id < 1)
            {
                foreach (var car in this.CarRepo.GetAll())
                {
                    temp.Add(car.CarId, car.ToString());
                }
            }
            else
            {
                foreach (var car in this.CarRepo.GetAll().Where(x => x.OwnerId == id))
                {
                    temp.Add(car.CarId, car.ToString());
                }
            }

            return temp.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
        }

        /// <inheritdoc/>
        public IDictionary<int, string> CarAvailable(int id = 0, bool availableOrUnavailable = true)
        {
            Dictionary<int, string> temp = new Dictionary<int, string>();
            if (id > 0)
            {
                foreach (var car in this.CarRepo.GetAll().Where(x => x.OwnerId == id).Where(x => (availableOrUnavailable == true ? x.RentalId == null : x.RentalId != null)))
                {
                    temp.Add(car.CarId, car.ToString());
                }
            }
            else
            {
                foreach (var car in this.CarRepo.GetAll().Where(x => (availableOrUnavailable == true ? x.RentalId == null : x.RentalId != null)))
                {
                    temp.Add(car.CarId, car.ToString());
                }
            }

            return temp.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
        }

        /// <inheritdoc/>
        public IDictionary<int, string> CarNeedFix(int id)
        {
            Dictionary<int, string> temp = new Dictionary<int, string>();
            if (id > 0)
            {
                foreach (var car in this.CarRepo.GetAll().Where(x => x.OwnerId == id).Where(x => x.IsOperational == false))
                {
                    temp.Add(car.CarId, car.ToString());
                }
            }

            return temp.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
        }

        /// <inheritdoc/>
        public string GetFirstName(int id)
        {
            return this.OwnerRepo.GetOne(id).FirstName;
        }

        /// <inheritdoc/>
        public string GetLastName(int id)
        {
            return this.OwnerRepo.GetOne(id).LastName;
        }

        /// <inheritdoc/>
        public DateTime GetBirthDate(int id)
        {
            return this.OwnerRepo.GetOne(id).BirthDate;
        }

        /// <inheritdoc/>
        public string GetPhoneNumber(int id)
        {
            return this.OwnerRepo.GetOne(id).PhoneNumber;
        }

        /// <inheritdoc/>
        public string GetRentalCompany(int id)
        {
            return this.OwnerRepo.GetOne(id).RentalCompany;
        }

        /// <inheritdoc/>
        public string GetLocation(int id)
        {
            return this.OwnerRepo.GetOne(id).Location;
        }

        /// <inheritdoc/>
        public void ChangeFirstName(string input, int id)
        {
            var op = this.OwnerRepo.GetOne(id);
            op.FirstName = input;
            this.OwnerRepo.Save();
        }

        /// <inheritdoc/>
        public void ChangeLastName(string input, int id)
        {
            var op = this.OwnerRepo.GetOne(id);
            op.LastName = input;
            this.OwnerRepo.Save();
        }

        /// <inheritdoc/>
        public void ChangeBirthDate(DateTime input, int id)
        {
            var op = this.OwnerRepo.GetOne(id);
            op.BirthDate = input;
            this.OwnerRepo.Save();
        }

        /// <inheritdoc/>
        public void ChangePhoneNumber(string input, int id)
        {
            var op = this.OwnerRepo.GetOne(id);
            op.PhoneNumber = input;
            this.OwnerRepo.Save();
        }

        /// <inheritdoc/>
        public void ChangeRentalCompany(string input, int id)
        {
            var op = this.OwnerRepo.GetOne(id);
            op.RentalCompany = input;
            this.OwnerRepo.Save();
        }

        /// <inheritdoc/>
        public void ChangeLocation(string input, int id)
        {
            var op = this.OwnerRepo.GetOne(id);
            op.Location = input;
            this.OwnerRepo.Save();
        }

        /// <inheritdoc/>
        public void AddCar(IList<string> newCar, int? id = 0)
        {
            if (newCar != null && newCar.Count == 5)
            {
                this.CarRepo.Add(
                FormatLogic.FormatString(newCar[0], 20),
                FormatLogic.FormatString(newCar[1], 20),
                FormatLogic.FormatString(newCar[2], 20),
                FormatLogic.FormatDate(newCar[3]),
                FormatLogic.FormatBool(newCar[4]),
                id < 1 ? this.CurrentId : id);
            }
        }

        // public void AddCar(string manufacturer, string model, string carclass, DateTime production, bool isOperational, int? ownerId = null)
        // {
        //        this.CarRepo.Add(
        //        FormatLogic.FormatString(manufacturer, 20),
        //        FormatLogic.FormatString(model, 20),
        //        FormatLogic.FormatString(carclass, 20),
        //        production,
        //        isOperational,
        //        ownerId;
        // }

        /// <summary>
        /// Add car logic.
        /// </summary>
        /// <param name="manufacturer">.</param>
        /// <param name="model">..</param>
        /// <param name="cLass">...</param>
        /// <param name="production">....</param>
        /// <param name="isoperational">.....</param>
        /// <param name="id">ownerid.</param>
        public void AddCar(string manufacturer, string model, string cLass, DateTime production, bool isoperational, int? id = null)
        {
                this.CarRepo.Add(
                FormatLogic.FormatString(manufacturer, 20),
                FormatLogic.FormatString(model, 20),
                FormatLogic.FormatString(cLass, 20),
                production,
                isoperational,
                id < 1 ? this.CurrentId : id);
        }

        /// <inheritdoc/>
        public void FixCar(int id)
        {
            if (id > 0)
            {
                this.CarRepo.GetOne(id).IsOperational = true;
                this.OwnerRepo.Save();
            }
        }

        /// <inheritdoc/>
        public void SellCar(int id, int? newOwner)
        {
            if (id > 0)
            {
                this.CarRepo.GetOne(id).OwnerId = newOwner;
                this.OwnerRepo.Save();
            }
        }
    }
}
