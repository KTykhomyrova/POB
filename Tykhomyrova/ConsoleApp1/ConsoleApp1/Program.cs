using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp1 {
    internal class Program {

        public enum AnimalType {
            Ssaki,
            Ptaki,
            Gady,
            Płazy,
            Ryby,
            Owady
        }

        public class Animal {
            private string _name;
            private int _species;
            private string _type;

            public DateTime BirthDate { get; set; }
            public string Type {
                get { return _type; }
                set {
                    if (string.IsNullOrWhiteSpace(value)) {
                        Console.WriteLine("type nie może być puste");
                        return;
                    }

                    _type = value;
                }
            }


            public string Name {
                get { return _name; }
                set {
                    if (string.IsNullOrWhiteSpace(value)) {
                        Console.WriteLine("Name nur może być puste");
                        return;
                    }

                    _name = value;
                }
            }
            public int Species {
                get { return _species; }
                set {
                    if (value < 0 || value > 6) {
                        Console.WriteLine("species nur może być puste");
                        return;
                    }

                    _species = value;
                }
            }

            public Animal() {
                Name = "Belka";
                Species = (int)AnimalType.Ssaki;
                Type = "Dog";
                BirthDate = new DateTime(02, 12, 2008);

            }

            public Animal(string name) {
                if (string.IsNullOrWhiteSpace(name))
                    throw new ArgumentException("name nie może być puste");
                Name = name;
                Species = (int)AnimalType.Ssaki;
                Type = "None";
                BirthDate = DateTime.MinValue;
            }

            public Animal(string name, int species) :this(name) {
                if (species < 0 || species > 6)
                    throw new ArgumentException ("species nur może być puste");

                Species = species;

            }

            public Animal(string name, int species, string type) {
                Name = name;
                Species = species;
                Type = type;
                BirthDate = DateTime.MinValue;
            }

            /*public Animal() {

            }*/

            public Animal(Animal other) {
                if (other == null)
                    throw new ArgumentNullException(nameof(other));

                Name = other.Name;
                Species = other.Species;
                Type = other.Type;
                BirthDate = other.BirthDate;
            }

            public override string ToString() {
                return $"Nazwa: {0}, Typ: {1}, Species: {2}, Data urodzenia: {BirthDate: dd-mm-yyyy}";
            }


            public void InputAnimalData() {
                try {
                    Console.WriteLine("Podaj name: ");
                    string name = Console.ReadLine();


                    Console.WriteLine("Poday type: ");
                    string type = Console.ReadLine();

                    Console.WriteLine("POdaj datę urodzenia: ");
                    DataTime BirthDate;
                } catch {

                }
            }

            public int Age {
                get {
                    DateTime today = DateTime.Today;
                    int age = today.Year - BirthDate.Year;
                    if (BirthDate.Date > today.AddYears(-age)) {
                        age--;
                    }

                    return age;
                }
            }

            static void Main(string[] args) {

            }
        }
    }
}
