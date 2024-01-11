// <copyright file="ManageLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRental.Logic
{
    using System;
    using System.Collections.Generic;
    using CarRental.Repository;

    /// <summary>
    /// ManageLogic, to create new data. Parent class for AdminLogic.
    /// </summary>
    public class ManageLogic : IRegister, IDelete
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ManageLogic"/> class.
        /// </summary>
        /// <param name="owner"> Owner Repository.</param>
        /// <param name="car">Car Repository.</param>
        /// <param name="contractor">Contractor Repository.</param>
        /// <param name="rental">Rental Repository.</param>
        public ManageLogic(IOwnerRepository owner, ICarRepository car, IContractorRepository contractor, IRentalRepository rental)
        {
            this.OwnerRepo = owner;
            this.CarRepo = car;
            this.ContractorRepo = contractor;
            this.RentalRepo = rental;
        }

        /// <summary>
        /// Gets or sets Owner Repository, required to create, delete Owners.
        /// </summary>
        protected IOwnerRepository OwnerRepo { get; set; }

        /// <summary>
        /// Gets or sets Car Repository, required to create, delete Cars.
        /// </summary>
        protected ICarRepository CarRepo { get; set; }

        /// <summary>
        /// Gets or sets Contractor Repository, required to create, delete Contractors.
        /// </summary>
        protected IContractorRepository ContractorRepo { get; set; }

        /// <summary>
        /// Gets or sets Rental Repository, required to create, delete Rentals.
        /// </summary>
        protected IRentalRepository RentalRepo { get; set; }

        /// <inheritdoc/>
        public void AddOwner(IList<string> input)
        {
            try
            {
                if (input != null && input.Count == 6)
                {
                    var in1 = FormatLogic.FormatString(input[0], 20, true);
                    var in2 = FormatLogic.FormatString(input[1], 20, true);
                    var in3 = FormatLogic.FormatDate(input[2]);
                    var in4 = FormatLogic.FormatPhoneNumber(input[3]);
                    var in5 = FormatLogic.FormatString(input[4], 50, true);
                    var in6 = FormatLogic.FormatString(input[0], 20, true);

                    this.OwnerRepo.Add(in1, in2, in3, in4, in5, in6);
                }
                else
                {
                    throw new ArgumentException("Invalid input");
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.ToString());
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        /// <inheritdoc/>
        public void AddCar(IList<string> input, int? owner = null)
        {
            try
            {
                if (input != null && input.Count == 5)
                {
                        var in1 = FormatLogic.FormatString(input[0], 20, true);
                        var in2 = FormatLogic.FormatString(input[1], 20, true);
                        var in3 = FormatLogic.FormatString(input[2], 20, true);
                        var in4 = FormatLogic.FormatDate(input[3]);
                        var in5 = FormatLogic.FormatBool(input[4]);
                        this.CarRepo.Add(in1, in2, in3, in4, in5, owner);
                }
                else
                {
                    throw new ArgumentException("Invalid input");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        /// <inheritdoc/>
        public void AddContractor(IList<string> input)
        {
            try
            {
                if (input != null && input.Count == 6)
                {
                    var in1 = FormatLogic.FormatString(input[0], 20, true);
                    var in2 = FormatLogic.FormatString(input[1], 20, true);
                    var in3 = FormatLogic.FormatDate(input[2]);
                    var in4 = FormatLogic.FormatPhoneNumber(input[3]);
                    var in5 = FormatLogic.FormatString(input[4], 20, true);
                    var in6 = FormatLogic.FormatEmail(input[5], 20);

                    this.ContractorRepo.Add(in1, in2, in3, in4, in5, in6);
                }
                else
                {
                    throw new ArgumentException("Invalid input");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        /// <inheritdoc/>
        public void AddRental(IList<string> input, int? contractor = null, int? car = null)
        {
            try
            {
                if (input != null && input.Count == 2)
                {
                    var in1 = FormatLogic.FormatDate(input[0]);
                    var in2 = FormatLogic.FormatDate(input[1]);

                    this.RentalRepo.Add(in1, in2, contractor, car);
                }
                else
                {
                    throw new ArgumentException("Invalid input");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        #region IDelete

        /// <inheritdoc/>
        public void DeleteOwner(int id)
        {
            this.OwnerRepo.Delete(id);
        }

        /// <inheritdoc/>
        public void DeleteCar(int id)
        {
            this.CarRepo.Delete(id);
        }

        /// <inheritdoc/>
        public void DeleteContractor(int id)
        {
            this.ContractorRepo.Delete(id);
        }

        /// <inheritdoc/>
        public void DeleteRental(int id)
        {
            this.RentalRepo.Delete(id);
        }
        #endregion
    }
}
