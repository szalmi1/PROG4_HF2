// <copyright file="RelationLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRental.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using CarRental.Repository;

    /// <summary>
    /// RelationLogic, for complex LINQ joins.
    /// </summary>
    public class RelationLogic : IRelation
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RelationLogic"/> class.
        /// </summary>
        /// <param name="owner">Owner Repository.</param>
        /// <param name="car">Car Repository.</param>
        /// <param name="contractor">Contractor Repository.</param>
        /// <param name="rental">Rental Repository.</param>
        public RelationLogic(IOwnerRepository owner, ICarRepository car, IContractorRepository contractor, IRentalRepository rental)
        {
            this.Owner = owner;
            this.Car = car;
            this.Contractor = contractor;
            this.Rental = rental;
        }

        private IOwnerRepository Owner { get; set; }

        private ICarRepository Car { get; set; }

        private IContractorRepository Contractor { get; set; }

        private IRentalRepository Rental { get; set; }

        /// <inheritdoc/>
        public IDictionary<int, string> NeedToReturn(int contractorId)
        {
            var q1 = from contractor in this.Contractor.GetAll()
                     where contractor.ContractorId == contractorId
                     select contractor;

            var q2 = from rental in this.Rental.GetAll()
                     join contractor in q1 on rental.ContractorId equals contractor.ContractorId
                     where contractor.ContractorId == rental.ContractorId
                     select rental;

            var q3 = from car in this.Car.GetAll()
                     join rental in q2 on car.CarId equals rental.CarId
                     where rental.CarReturned == false
                     select new
                     {
                         id = rental.RentalId,
                         data = car.ToString(),
                     };

            IDictionary<int, string> output = new Dictionary<int, string>();

            foreach (var item in q3)
            {
                output.Add(item.id, item.data);
            }

            return output;
        }

        /// <inheritdoc/>
        public IDictionary<int, string> WhereAreMyCars(int ownerId)
        {
            List<string> list = new List<string>();
            var q1 = from car in this.Car.GetAll()
                        where car.OwnerId == ownerId
                        select car;

            var q2 = from rental in this.Rental.GetAll()
                        join car in q1 on rental.RentalId equals car.RentalId
                        select new
                        {
                            carId = car.CarId,
                            contractorId = rental.ContractorId,
                            rentalId = rental.RentalId,
                            carName = car.Manufacturer + " " + car.Model,
                            rentalEnds = rental.End,
                        };

            var q3 = from contractor in this.Contractor.GetAll()
                        join rental in q2 on contractor.ContractorId equals rental.contractorId
                        select new
                        {
                            carId = rental.carId,
                            contractorName = contractor.FirstName + " " + contractor.LastName,
                            contractorLocation = contractor.City,
                            carName = rental.carName,
                            daysRemaining = (int)(rental.rentalEnds - DateTime.Now).TotalDays,
                        };

            IDictionary<int, string> output = new Dictionary<int, string>();

            foreach (var item in q3)
            {
                var data = $"{item.carName.PadRight(45)}" +
                            $"{("Rented by: " + item.contractorName).PadRight(50) + "\n"}" +
                            $"{("    Location: " + item.contractorLocation).PadRight(49)}" +
                            $"{("Remaining: " + item.daysRemaining).PadRight(50)}\n";
                output.Add(item.carId, data);
            }

            return output;
        }

        /// <inheritdoc/>
        public IDictionary<int, string> NearbyRentables(int contractorId)
        {
            var q1 = from car in this.Car.GetAll()
                        where car.RentalId == null
                        select car;

            var q2 = from owner in this.Owner.GetAll()
                        join car in q1 on owner.OwnerId equals car.OwnerId
                        select new
                        {
                            carId = car.CarId,
                            carName = car.Manufacturer + " " + car.Model,
                            carProduction = car.Production.ToString("yyyy."),
                            location = owner.Location,
                        };

            var q3 = from contractor in this.Contractor.GetAll()
                        join owner in q2 on contractor.City equals owner.location
                        where contractor.ContractorId == contractorId
                        select owner;

            IDictionary<int, string> output = new Dictionary<int, string>();

            foreach (var item in q3)
            {
                var data = $"{item.carName.PadRight(45)}" +
                            $"{("Production:" + item.carProduction).PadRight(50) + "\n"}" +
                            $"{("    Location: " + item.location).PadRight(49)}" +
                            $"{"For rent: YES ".PadRight(50)}\n";
                output.Add(item.carId, data);
            }

            return output;
        }

        /// <summary>
        /// Starts an async Task, with NeedToReturn() method.
        /// </summary>
        /// <param name="contractorId">Parameter for NeedToReturn().</param>
        /// <returns>Task, with IDictionary(int, string) result.</returns>
        public Task<IDictionary<int, string>> NeedToReturnAsync(int contractorId)
        {
            return Task.Run(() => this.NeedToReturn(contractorId));
        }

        /// <summary>
        /// Starts an async Task, with WhereAreMyCars() method.
        /// </summary>
        /// <param name="ownerId">Parameter for NeedToReturn().</param>
        /// <returns>Task, with IDictionary(int, string) result.</returns>
        public Task<IDictionary<int, string>> WhereAreMyCarsAsync(int ownerId)
        {
            return Task.Run(() => this.WhereAreMyCars(ownerId));
        }

        /// <summary>
        /// Starts an async Task, with NearbyRentables() method.
        /// </summary>
        /// <param name="contractorId">Parameter for NeedToReturn().</param>
        /// <returns>Task, with IDictionary(int, string) result.</returns>
        public Task<IDictionary<int, string>> NearbyRentablesAsync(int contractorId)
        {
            return Task.Run(() => this.NearbyRentables(contractorId));
        }
    }
}
