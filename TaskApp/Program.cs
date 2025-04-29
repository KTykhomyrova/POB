using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.modele;

namespace TaskApp {
    internal class Program {
        static void Main(string[] args) {
            TaskApp.modele.Task task1 = new TaskApp.modele.Task();

            task1.Title = "ZAdanie 1";
            task1.Description = "Opis zadania 1";
            task1.DueDate = DateTime.Now.AddDays(2);
            task1.IsCompleted = false;
            task1.Priority = PriorityLevel.Sredni;

            task1.DisplayInfo();

            TaskApp.modele.Task task2 = new TaskApp.modele.Task("Zadanie 2", "Opis zadania 2", DateTime.Now.AddDays(5), true, PriorityLevel.Sredni);
            task2.DisplayInfo();

            try 
            {
                task2.DueDate = DateTime.Now.AddDays(-5);
            } 
            catch(ArgumentException ex) 
            {
                Console.WriteLine($"Błąd: {ex.Message}");
            }

            task2.DueDate.AddDays(5);
            task2.DisplayInfo();

            try 
            {
                //task2.Priority = PriorityLevel.Niski;
                //task2.Priority = (PriorityLevel)1; //sredeni
                task2.Priority = (PriorityLevel)88; //błąd
            }
            catch(ArgumentException ex) 
            {
                Console.WriteLine($"Błąd: {ex.Message}");
            }

            task2.DisplayInfo();
        }
    }
}
