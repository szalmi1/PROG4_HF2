// <copyright file="App.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRental.View
{
    using System.Windows;
    using CarRental.View.BL;
    using CarRental.View.UI;
    using CommonServiceLocator;
    using GalaSoft.MvvmLight.Messaging;

    /// <summary>
    /// Interaction logic for App.xaml.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class.
        /// </summary>
        public App()
        {
            ServiceLocator.SetLocatorProvider(() => MyIoc.Instance);

            MyIoc.Instance.Register<IEditorService, EditorServiceViaWindow>();
            MyIoc.Instance.Register<IMessenger>(() => Messenger.Default);
            MyIoc.Instance.Register<ICarLogic, CarLogic>();
            MyIoc.Instance.Register<Factory, Factory>();
        }
    }
}
