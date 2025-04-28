using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskApp.modele {
    public class Task {
        //prywatne pola
        private string _title;
        private string _description;
        private DateTime _dueDate;
        private bool _isCompleted;

        //właściwości z walidacją
        public string Title {
            get { return _title; }
            set {
                if (string.IsNullOrWhiteSpace(value)) {
                    throw new ArgumentException("Tytuł zadania nie może być pusty");
                }
                _title = value;
            }
        }

        public string Description {
            get { return _description; }
            set {
                if (string.IsNullOrWhiteSpace(value)) {
                    throw new ArgumentException("Tytuł zadania nie może być pusty");
                }
                _description = value;
            }
        }

        public DateTime DueDate {
            get { return _dueDate; }
            set {
                if (value < DateTime.Now) {
                    throw new ArgumentException("Data twykonania nie może być w przyszłości");
                }
                _dueDate = value;
            }
        }

        public bool IsCompleted {
            get { return _isCompleted; }
            set { _isCompleted = value; }
        }

        //konstruktor domyslny
        public Task() 
        {
            _title = "nieokreslony tytul";
            _description = "brak opisu";
            _dueDate = DateTime.Now.AddDays(1);
            _isCompleted = false;
        }
            
        //konstruktor parametryczny
        public Task(string title, string description, DateTime dueDate, bool isCopleted) {
            _title = title;
            _description = description;
            _dueDate = dueDate;
            _isCompleted = isCopleted;
        }

        public void DisplayInfo() {
            Console.WriteLine($"Zadaine: {Title}\nOpis: {Description}\nTermin wykonania: {DueDate}\nZakończone: {IsCompleted}");
            Console.WriteLine();
        }
    }  
}
