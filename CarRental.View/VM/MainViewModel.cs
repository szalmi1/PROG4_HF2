// <copyright file="MainViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRental.View.VM
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using CarRental.View.BL;
    using CarRental.View.DATA;
    using CommonServiceLocator;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;

    /// <summary>
    /// MainWindowModel.
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private ICarLogic carLogic;
        private Car carSelected;
        private Factory factory;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// </summary>
        /// <param name="logic">IOwnerLogic.</param>
        /// <param name="factory">.</param>
        public MainViewModel(ICarLogic logic, Factory factory)
        {
            this.carLogic = logic;
            this.factory = factory;
            Cars = new ObservableCollection<Car>();

            if (factory != null)
            {
                IDictionary<int, string> cars = factory.Owner.CarList();
                if (IsInDesignMode)
                {
                    foreach (var car in factory.Owner.CarList())
                    {
                        Car newCar = new Car();
                        newCar.Manufacturer = factory.Admin.GetManufacturer(car.Key);
                        newCar.Model = factory.Admin.GetModel(car.Key);
                        newCar.Class = factory.Admin.GetClass(car.Key);
                        newCar.Production = factory.Admin.GetProduction(car.Key);
                        newCar.IsOperational = factory.Admin.GetIsOperational(car.Key);
                        newCar.Id = car.Key;
                        newCar.OwnerId = factory.Owner.GetOwner(car.Key).Key;
                        this.Cars.Add(newCar);
                    }
                }
                else
                {
                    foreach (var car in cars)
                    {
                        Car newCar = new Car();
                        newCar.Manufacturer = factory.Admin.GetManufacturer(car.Key);
                        newCar.Model = factory.Admin.GetModel(car.Key);
                        newCar.Class = factory.Admin.GetClass(car.Key);
                        newCar.Production = factory.Admin.GetProduction(car.Key);
                        newCar.IsOperational = factory.Admin.GetIsOperational(car.Key);
                        newCar.Id = car.Key;
                        newCar.OwnerId = factory.Owner.GetOwner(car.Key).Key;
                        this.Cars.Add(newCar);
                    }
                }
            }

            AddCmd = new RelayCommand(() => this.carLogic.AddCar(Cars));
            ModCmd = new RelayCommand(() => this.carLogic.ModCar(CarSelected));
            DelCmd = new RelayCommand(() => this.carLogic.DelCar(Cars, CarSelected));
            ExiCmd = new RelayCommand(() => Environment.Exit(0));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// </summary>
        public MainViewModel()
            : this(IsInDesignModeStatic ? null : ServiceLocator.Current.GetInstance<ICarLogic>(), IsInDesignModeStatic ? null : ServiceLocator.Current.GetInstance<Factory>())
        {
        }

        /// <summary>
        /// Gets or sets Car.
        /// </summary>
        public Car CarSelected
        {
            get { return carSelected; }
            set { Set(ref carSelected, value); }
        }

        /// <summary>
        /// Gets car collection.
        /// </summary>
        public ObservableCollection<Car> Cars { get; private set; }

        /// <summary>
        /// Gets add command.
        /// </summary>
        public ICommand AddCmd { get; private set; }

        /// <summary>
        /// Gets modify command.
        /// </summary>
        public ICommand ModCmd { get; private set; }

        /// <summary>
        /// Gets delete command.
        /// </summary>
        public ICommand DelCmd { get; private set; }

        /// <summary>
        /// Gets delete command.
        /// </summary>
        public ICommand ExiCmd { get; private set; }
    }
}
