// <copyright file="EditorWindow.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRental.View.UI
{
    using System;
    using System.Windows;
    using CarRental.View.DATA;
    using CarRental.View.VM;

    /// <summary>
    /// Interaction logic for EditorWindow.xaml.
    /// </summary>
    public partial class EditorWindow : Window
    {
        private EditorViewModel vm;

        /// <summary>
        /// Initializes a new instance of the <see cref="EditorWindow"/> class.
        /// </summary>
        public EditorWindow()
        {
            InitializeComponent();
            vm = FindResource("VM") as EditorViewModel;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EditorWindow"/> class.
        /// </summary>
        /// <param name="newCar">Owner.</param>
        public EditorWindow(Car newCar)
            : this()
        {
            if (newCar != null)
            {
                newCar.Production = DateTime.Today;
            }

            vm.Car = newCar;
        }

        /// <summary>
        /// Gets VM.Car.
        /// </summary>
        public Car Car
        {
            get { return vm.Car; }
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
