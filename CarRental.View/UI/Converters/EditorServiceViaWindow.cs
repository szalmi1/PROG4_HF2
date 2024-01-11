// <copyright file="EditorServiceViaWindow.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRental.View.UI
{
    using CarRental.View.BL;
    using CarRental.View.DATA;

    /// <inheritdoc/>
    public class EditorServiceViaWindow : IEditorService
    {
        /// <summary>
        /// Edits car.
        /// </summary>
        /// <param name="c">Car.</param>
        /// <returns>True or false, if the edit was successful.</returns>
        public bool EditCar(Car c)
        {
            EditorWindow win = new EditorWindow(c);
            return win.ShowDialog() ?? false;
        }
    }
}
