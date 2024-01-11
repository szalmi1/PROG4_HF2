// <copyright file="Generate.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace CarRental.Data
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.IO;

    /// <summary>
    /// Generate class to fill database with objects.
    /// </summary>
    public class Generate
    {
        /// <summary>
        /// List of firstnames, what the generator uses, to generate firstName.
        /// </summary>
        private readonly List<string> firstNameList = new List<string>();

        /// <summary>
        /// List of lastnames, what the generator uses, to generate lastName.
        /// </summary>
        private readonly List<string> lastNameList = new List<string>();

        /// <summary>
        /// List of rental companies, what the generator uses, to generate rentalCompany.
        /// </summary>
        private readonly List<string> rentalCompanyList = new List<string>();

        /// <summary>
        /// List of cities, what the generator uses, to generate city.
        /// </summary>
        private readonly List<string> cityList = new List<string>();

        /// <summary>
        /// List of cars with type, and production date, what the generator uses, to generate car with properties.
        /// </summary>
        private readonly List<string> carList = new List<string>();

        /// <summary>
        /// List of domains, what the generator uses, to generate emails.
        /// </summary>
        private readonly List<string> emailList = new List<string>();

        /// <summary>
        /// A list, what stores already assigned keys, to avoid use it again.
        /// </summary>
        private List<int> alreadyUsed = new List<int>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Generate"/> class.
        /// <para>The instance will contain <see cref="ICollection{T}"/> of <see cref="Owner"/>, <see cref="Car"/>, <see cref="Contractor"/>, <see cref="Rental"/>. </para>
        /// </summary>
        /// <param name="owner"> Defines the amount of the owners need to generate.</param>
        /// <param name="car"> Defines the amount of the cars need to generate.</param>
        /// <param name="contractor"> Defines the amount of the contractors need to generate.</param>
        /// <param name="rental"> Defines the amount of the rentals need to generate.</param>
        public Generate(int owner, int car, int contractor, int rental)
        {
            foreach (var line in ReadFile("cities.txt"))
            {
                this.cityList.Add(line);
            }

            foreach (var line in ReadFile("cars.txt"))
            {
                this.carList.Add(line);
            }

            foreach (var line in ReadFile("emails.txt"))
            {
                this.emailList.Add(line);
            }

            foreach (var line in ReadFile("firstnames.txt"))
            {
                this.firstNameList.Add(line);
            }

            foreach (var line in ReadFile("lastnames.txt"))
            {
                this.lastNameList.Add(line);
            }

            foreach (var line in ReadFile("rentalcompanies.txt"))
            {
                this.rentalCompanyList.Add(line);
            }

            Random rand = new Random();
            this.Owners = new Collection<Owner>();
            for (int i = 0; i < owner; i++)
            {
                this.Owners.Add(new Owner()
                {
                    OwnerId = i + 1,
                    FirstName = Generate.Random(this.firstNameList),
                    LastName = Generate.Random(this.lastNameList),
                    BirthDate = Generate.RandomDate(1960, 2021),
                    PhoneNumber = Generate.RandomPhone(),
                    RentalCompany = Generate.Random(this.rentalCompanyList),
                    Location = Generate.Random(this.cityList),
                });
            }

            this.Cars = new Collection<Car>();
            for (int i = 0; i < car; i++)
            {
                string[] carData = this.carList[rand.Next(0, 25)].Split(',');
                carData[3] = (int.Parse(carData[3]) + (3 - rand.Next(1, 6))).ToString();

                this.Cars.Add(new Car()
                {
                    CarId = i + 1,
                    Manufacturer = carData[0],
                    Model = carData[1],
                    Class = carData[2],
                    Production = new DateTime(int.Parse(carData[3]), 1, 1),
                    IsOperational = Generate.RandomBool(80),
                    RentalId = null,
                    OwnerId = rand.Next(1, owner + 1),
                });
            }

            this.Contractors = new Collection<Contractor>();
            for (int i = 0; i < contractor; i++)
            {
                string firstname = Generate.Random(this.firstNameList);
                string lastname = Generate.Random(this.lastNameList);
                DateTime date = Generate.RandomDate(1960, 2000);
                string email = string.Empty;
                switch (rand.Next(0, 5))
                {
                    case 0:
                        email = (firstname + "." + lastname + this.emailList[rand.Next(0, this.emailList.Count)]).ToLower();
                        break;
                    case 1:
                        email = (firstname + lastname.Substring(0, 2) + this.emailList[rand.Next(0, this.emailList.Count)]).ToLower();
                        break;
                    case 2:
                        email = (firstname + date.Year.ToString().Substring(2, 2) + this.emailList[rand.Next(0, this.emailList.Count)]).ToLower();
                        break;
                    case 3:
                        email = (lastname + rand.Next(0, 10) + this.emailList[rand.Next(0, this.emailList.Count)]).ToLower();
                        break;
                    case 4:
                        email = (firstname + "." + lastname.Substring(0, 1) + this.emailList[rand.Next(0, this.emailList.Count)]).ToLower();
                        break;
                }

                this.Contractors.Add(new Contractor()
                {
                    ContractorId = i + 1,
                    FirstName = firstname,
                    LastName = lastname,
                    BirthDate = date,
                    PhoneNumber = Generate.RandomPhone(),
                    Email = email,
                    City = Generate.Random(this.cityList),
                });
            }

            this.Rentals = new Collection<Rental>();
            for (int i = 0; i < rental; i++)
            {
                DateTime date1 = Generate.RandomDate(2018, 2021);
                DateTime date2 = Generate.RandomDate(2018, 2021);
                this.alreadyUsed.Clear();
                this.Rentals.Add(new Rental()
                {
                    RentalId = i + 1,
                    Start = date1 < date2 ? date1 : date2,
                    End = date2 < date1 ? date1 : date2,
                    Paid = Generate.RandomBool(40),
                    CarReturned = Generate.RandomBool(40),
                    ContractorId = rand.Next(1, contractor + 1),
                    CarId = this.RandomKey(car),
                });
            }
        }

        /// <summary>
        /// Gets <see cref="ICollection{T}"/> of <see cref="Owner"/> generated by <see cref="Generate"/> constructor.
        /// </summary>
        public ICollection<Owner> Owners { get; }

        /// <summary>
        /// Gets <see cref="ICollection{T}"/> of <see cref="Car"/> generated by <see cref="Generate"/> constructor.
        /// </summary>
        public ICollection<Car> Cars { get; }

        /// <summary>
        /// Gets <see cref="ICollection{T}"/> of <see cref="Contractor"/> generated by <see cref="Generate"/> constructor.
        /// </summary>
        public ICollection<Contractor> Contractors { get; }

        /// <summary>
        /// Gets <see cref="ICollection{T}"/> of <see cref="Rental"/> generated by <see cref="Generate"/> constructor.
        /// </summary>
        public ICollection<Rental> Rentals { get; }

        /// <summary>
        /// Reads in the file, line by line, and adds returns as a list.
        /// </summary>
        private static IEnumerable<string> ReadFile(string path)
        {
            var dirpath = Directory.GetParent(Environment.CurrentDirectory).FullName;
            using StreamReader reader = File.OpenText(dirpath + "\\CarRental.Data\\Model\\Generate\\" + path);
            string line = string.Empty;
            while ((line = reader.ReadLine()) != null)
            {
                yield return line;
            }
        }

        /// <summary>
        /// Selects a randon string from parameter.
        /// </summary>
        /// <param name="input">String list for the random selection.</param>
        /// <returns>A random string from the given parameter.</returns>
        private static string Random(List<string> input)
        {
            if (input != null)
            {
                Random rand = new Random();
                return input[rand.Next(0, input.Count)];
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Gives a random DateTime (from-to).
        /// </summary>
        /// <param name="from">Parameter to choose the first year to generate from.</param>
        /// <param name="to">Parameter to choose the last year to generate from.</param>
        /// <returns>A random string from the given parameter.</returns>
        private static DateTime RandomDate(int from, int to)
        {
            Random rand = new Random();
            int[] monthsLength = { 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            int year = rand.Next(from, to + 1);
            int month = rand.Next(1, 13);
            int day = rand.Next(1, monthsLength[month - 1]);
            return new DateTime(year, month, day);
        }

        /// <summary>
        /// Creates a random phonenumber.
        /// </summary>
        /// <returns>A randomly created phonenumber.</returns>
        private static string RandomPhone()
        {
            Random rand = new Random();
            string number = "06";
            string[] vendor = { "20", "30", "70" };
            number += vendor[rand.Next(0, 3)];
            for (int i = 0; i < 7; i++)
            {
                number += rand.Next(0, 10);
            }

            return number;
        }

        /// <summary>
        /// Generates a random bool.
        /// </summary>
        /// <param name="percent">The probability (percent) of "true" return.</param>
        /// <returns>True or false.</returns>
        private static bool RandomBool(int percent)
        {
            Random rand = new Random();
            return rand.Next(0, 101) < percent + 1;
        }

        /// <summary>
        /// Returns a key, not generated yet.
        /// </summary>
        /// <param name="to">String list for the random selection.</param>
        /// <returns>A <see cref="string"/> array with 4 members, containing Manufacturer, Model, Class, Production.</returns>
        private int RandomKey(int to)
        {
            Random rand = new Random();
            int output;
            do
            {
                output = rand.Next(1, to);
            }
            while (this.alreadyUsed.Contains(output));
            this.alreadyUsed.Add(output);
            return output;
        }
    }
}
