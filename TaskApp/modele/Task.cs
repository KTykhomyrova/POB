using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskApp.modele {
    public enum PriorityLevel {
        Niski,
        Sredni,
        Wysoki
    }
    public class Task {
        //prywatne pola
        private string _title;
        private string _description;
        private DateTime _dueDate;
        private bool _isCompleted;
        private PriorityLevel _priority;

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

        public PriorityLevel Priority 
        {
            get { return _priority; }
            set 
            { 
                if(!Enum.IsDefined(typeof(PriorityLevel), value)) 
                {
                    throw new ArgumentException($"Priorytet: '{value}' nie jest dozwolony. Dozwolone pryorytety: {string.Join(", ", Enum.GetNames(typeof (PriorityLevel)))}");
                }
                _priority = value; 
            }
        }

        //konstruktor domyslny
        public Task() 
        {
            _title = "nieokreslony tytul";
            _description = "brak opisu";
            _dueDate = DateTime.Now.AddDays(1);
            _isCompleted = false;
            _priority = PriorityLevel.Sredni;
        }
            
        //konstruktor parametryczny
        public Task(string title, string description, DateTime dueDate, bool isCopleted, PriorityLevel priority) {
            _title = title;
            _description = description;
            _dueDate = dueDate;
            _isCompleted = isCopleted;
            _priority = priority;
        }

        public void DisplayInfo() {
            Console.WriteLine($"Zadaine: {Title}\nOpis: {Description}\nTermin wykonania: {DueDate}\nZakończone: {IsCompleted}\n Priority level: {Priority}");
            Console.WriteLine();
        }
    }  
}
