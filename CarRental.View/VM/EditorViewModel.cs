// <copyright file="EditorViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRental.View.VM
{
    using System;
    using System.Linq;
    using CarRental.View.DATA;
    using GalaSoft.MvvmLight;

    /// <summary>
    /// EditorVM.
    /// </summary>
    public class EditorViewModel : ViewModelBase, System.IDisposable
    {
        private readonly Factory factory;
        private Car car;

        /// <summary>
        /// Initializes a new instance of the <see cref="EditorViewModel"/> class.
        /// </summary>
        public EditorViewModel()
        {
            this.factory = new Factory();
            car = new Car();
            if (IsInDesignMode)
            {
            }
        }

        /// <summary>
        /// Gets or sets the car.
        /// </summary>
        public Car Car
        {
            get
            {
                return car;
            }

            set
            {
                this.Set(ref this.car, value);
                this.car.Id = -1;
                foreach (var carId in this.factory.Owner.CarList().Keys)
                {
                    if (car.Manufacturer == factory.Admin.GetManufacturer(carId) &&
                        car.Model == factory.Admin.GetModel(carId) &&
                        car.Class == factory.Admin.GetClass(carId) &&
                        car.Production == factory.Admin.GetProduction(carId) &&
                        car.IsOperational == factory.Admin.GetIsOperational(carId))
                    {
                        this.car.Id = carId;
                        break;
                    }
                }

                if (this.car.Id == -1)
                {
                    this.car.Id = this.factory.Owner.CarList().Keys.LastOrDefault() + 1;
                }
            }
        }

        /// <summary>
        /// Fantastic dispose method.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose this.
        /// </summary>
        /// <param name="v">Yes/no.</param>
        protected virtual void Dispose(bool v)
        {
            this.factory.Dispose();
        }
    }
}