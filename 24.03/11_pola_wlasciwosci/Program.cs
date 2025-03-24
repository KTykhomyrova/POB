using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace _11_pola_wlasciwosci {

    class Car {
        //pola fields - bezposzrednie zmienne przechowujace danne
        public string brand; //pole publicznr, brak kontrolu dostepu, brak walidacji
        public string model; // brak walidacji, pole publiczne

        // Prywatne pola dla właściwości
        private int _prodactionYear;
        private decimal _price;
        private string _color;

        // Właściwości (properties) - kontrolują dostęp do dannych
        public int ProdactionYear {
            get { return _prodactionYear; }
            set {
                if (value >= 1886 && value <= DateTime.Now.Year) {
                    _prodactionYear = value;
                } else {
                    throw new ArgumentException("Rok produkcji musi być między 1886 aobbecnym rokiem");
                }
            }
        }

        public decimal Price {
            get { return _price; }
            set {
                if (value >= 0) {
                    _price = value;
                } else {
                    throw new ArgumentException("Cena nie może być ujemna");
                }
            }
        }

        public string Color { 
            get { return _color; }
            set {
                //lista dozwolonych kolorów
                string[] allowedColors = { "niebieski" , "czarny", "biały", "czerwony"};
                //if (string.IsNullOrWhiteSpace(value)) {
                //    throw new ArgumentException("Kolor nir moźe być pusty");
                //}
                //if (Array.IndexOf(allowedColors, value.ToLower()) == -1) {
                //    string allowedColorsList = "";
                //    foreach (var color in allowedColors) {
                //        allowedColorsList += color + ", ";
                //    }

                //    allowedColorsList = allowedColorsList.TrimEnd(',', ' ');
                //    throw new ArgumentException($"Kolor musi byc jednym z: {allowedColorsList}");

                //}

                
                if (Array.IndexOf(allowedColors, value.ToLower()) == -1) {
                    string allowedColorsList = string.Join(", ", allowedColors);

                    throw new ArgumentException($"Kolor musi byc jednym z: {allowedColorsList}");

                }
                _color = value.ToLower();

            }
        }

        //konstruktor domyślny
        public Car() {
            brand = "nieznana;";
            model = "Nieznany";
            _prodactionYear = DateTime.Now.Year;
            _price = 0m;
        }

        public Car(string brand, string model, int prodactionYear, decimal price) {
            this.brand = brand;
            this.model = model;
            ProdactionYear = prodactionYear; // uzycie wlasciwosci z walidacja
            Price = price; // uzycir wlasciwosci z walifdacja
        }

        public override string ToString() {
            return $"Brand: {brand}, model: {model}, rok produkcji {ProdactionYear}, price: {Price}";
        }

        public void DisplayInfo() {
            Console.WriteLine($"Brand: {brand}, model: {model}, rok produkcji {ProdactionYear}, price: {Price:C}");
        }

    }
        internal class Program {
            static void Main(string[] args) {

            //Thread.CurrentThread.CurrentUICulture = 
            //tworzenie obiektu z uzyciem konstruktora domyslnego
            Car car = new Car();

            car.brand = "Ferrari";//bezposredni dostep do pola
            car.model = "F430";//bezp. dostep do pola

            car.ProdactionYear = 2020;//uzycie wlasciwosci z wallidacja
            car.Price = 1000000.99m;

            car.DisplayInfo();
            Console.WriteLine(car.ToString());
            


            //tworzenie obiekta z wykorzystaniem konstruktora z parametrami
            Car car2 = new Car("BMW", "i5", 2022, 75000);
            car2.DisplayInfo();

            //przyklad bledu
            try {
                car2.ProdactionYear = 1800;
            } catch (Exception ex) {
                Console.WriteLine($"Błąd: {ex.Message}");
            }
            car2.ProdactionYear = 1900;
            car2.DisplayInfo();

            //przyklad blrdu - color
            try {
                car2.Color = "czarny";
                
            } catch(ArgumentException ex) {
                Console.WriteLine($"Błąd: {ex.Message}");

            }
        }
        }
    }




