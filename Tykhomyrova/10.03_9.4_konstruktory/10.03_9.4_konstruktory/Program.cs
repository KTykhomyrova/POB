using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._03_9._4_konstruktory {

    public enum Grade {
        FirstGrade,
        SecondGrade,
        ThirdGrade,
        FourthGrade,
        FifthGrade
         
    }

    public class School {
        //prywatne pola
        private string _studentName;
        private Grade _studentGrade;
        private DateOnly _birthDate;
        private DateOnly _schoolStartDate;

        //właściwości
        public string StudentName { 
            get => _studentName; 

            set {
                if (string.IsNullOrEmpty(value)) {
                    throw new ArgumentNullException("Imię nie może być puste");
                    _studentName = value;
                }
            } }


        public DateOnly BirthDate { 
            get => _birthDate;

            set {
                if (value >= DateOnly.FromDateTime(DateTime.Today)) {
                    throw new ArgumentNullException("Data urodzenia nie moze byc w przyszlosci");
                    _birthDate = value;
                }
            }
        }

        public int StudentAge {
            get {
                int age = DateOnly.FromDataTime(DateTime.Today).Year - _birthDate.Year;
                if ((DateOnly.FromDateTime(DateTime.Today).Month) < _birthDate.Month ||
                    (DateOnly.FromDateTime(DateTime.Today).Month) == _birthDate.Month &&
                    (DateOnly.FromDateTime(DateTime.Today).Month) < _birthDate.Month ) {
                    age--;
                }
                return age;
            }
        }

        public Grade StudentGrade {
            get => _studentGrade;

            set {
                if (!Enum.IsDefined(typeof(Grade), value))
                    throw new ArgumentNullException("Nieprawidłowa klasa");

                _studentGrade = value;
            }
        }

        public DateOnly SchoolStartDate {
            get=> _schoolStartDate;

            set {
                if (value > DateOnly.FormDateTime(DateTime.Today))
                    throw new ArgumentNullException("Data rozpocęcia nauki nie moze byc w przyszlosci");
                _schoolStartDate = value;
            }
        }


    }
    internal class Program {
        static void Main(string[] args) {


        }
    }
}
