using System;
using System.Text.RegularExpressions;

namespace _9_1_kostruktory {
	public enum Gender {
		Mężczyzna,
		Kobieta,
		Inna
	}

	public class Person {
		// pola klasy Person
		private string _firstName; // pole prywatne
		private string _lastName; // pole prywatne

		//włąściwość przechowująca komunikat o błędzie
		public string ErrorMessage { get; private set; }
		//właściwość sprawdzająca, czy obiek jest poprawny (brak błędów)
		public bool IsValid => string.IsNullOrEmpty(ErrorMessage);

		//właściwości imienia z walidacją


		//właściwości klasy Person
		public string FirstName // właściwość publiczna
		{
			get { return _firstName; }

			set {
			if (string.IsNullOrWhiteSpace(value)) {
				ErrorMessage = "Błąd! Imie nie może być puste";
				return;
			}
			ErrorMessage = null;
			_firstName = value;
			}
		}

		//właściwość dla nazwiska z walidacją
		public string LastName {
			get { return _lastName; }
			set {
			if (!IsValidName(value)) {
			ErrorMessage = "Błąd! Może zawierać tylko litery oraz spacje";
			return;
			}
			ErrorMessage = null;
			_lastName = value;
			}
		}

		//metoda walidująca nazwisko
		private bool IsValidName(string value) {
		return Regex.IsMatch(value, @"^[a-zA-ZąćęłńóśźżĄĆĘŁŃÓŚŹŻ\s-]+$");
		}

		public DateTime DateOfBirth { get; set; }
		public Gender PersonGender { get; set; }

		//właściowość obliczająca wiek na podstawie daty urodzenia
		public int Age {
			get {
			DateTime today = DateTime.Today;
			int age = today.Year - DateOfBirth.Year;

			//sprawdzamy, czy osoba miała urodziny w tym roku
			if (DateOfBirth.Date > today.AddYears(-age)) {
			age--;
			}

			return age;
			}
		}

		//konstruktor domyślny
		public Person() {
		FirstName = "Janusz";
		LastName = "Nowak";
		DateOfBirth = new DateTime(2001, 1, 10); //domyślna data urodzenia
		PersonGender = Gender.Mężczyzna;
		}

		//konstruktor z jednym parametrem: imię
		public Person(string firstName) {
		if (string.IsNullOrWhiteSpace(firstName))
			throw new ArgumentException("Imię nie może być puste");

		FirstName = firstName;
		LastName = "Nieznane";
		DateOfBirth = DateTime.MinValue;
		PersonGender = Gender.Inna;

		Console.WriteLine("Wywołano konstruktor z jednym parametrem");
		}

		//konstruktor z dwoma parametrami
		public Person(string firstName, string lastName) : this(firstName) {
		if (string.IsNullOrWhiteSpace(lastName))
			throw new ArgumentException("Nazwisko nie może być puste");

		LastName = lastName;

		Console.WriteLine("Wywołano konstruktor z dwoma parametrami");
		}

		//konstruktor z trzema parametrami
		public Person(string firstName, string lastName, Gender gender) {
		FirstName = firstName;
		LastName = lastName;
		PersonGender = gender;
		}

		//konstruktor parametryczny
		public Person(string firstName, string lastName, DateTime dateOfBirth, Gender gender) {
		if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
			throw new ArgumentException("Imię i nazwisko nie mogą być puste");

		if (dateOfBirth > DateTime.Now)
			throw new ArgumentException("Data urodzenia nie może być w przyszłości");

		FirstName = firstName;
		LastName = lastName;
		DateOfBirth = dateOfBirth;
		PersonGender = gender;
		}

		//konstruktor kopiujący
		public Person(Person other) {
		if (other == null)
			throw new ArgumentNullException(nameof(other));

		FirstName = other.FirstName;
		LastName = other.LastName;
		DateOfBirth = other.DateOfBirth;
		PersonGender = other.PersonGender;
		}

		public void DisplayInformation() {
			if (IsValid) {
				Console.WriteLine("Imię: {0}, nazwisko: {1}, Data urodzenia: {2:yyyy-MM-dd}, wiek: {3}, płeć: {4}", FirstName, LastName, DateOfBirth, Age, PersonGender);

			} else {
				Console.WriteLine(ErrorMessage);
			}
		}

		public string GetFullName() {
		return $"{FirstName} {LastName}";
		}

		//nadpisanie metody ToString() do czytelnej reprezentacji obiektu
		public override string ToString() {
		return $"Osoba: {GetFullName()}, data urodzenia: {DateOfBirth:yyyy-MM-dd}, wiek: {Age}, płeć: {PersonGender}";
		}

		public static Person InputPersonData() {
		try {
		Console.Write("Podaj imię: ");
		string firstName = Console.ReadLine();


		Console.Write("Podaj nazwisko: ");
		string lastName = Console.ReadLine();

		Console.Write("Podaj datę urodzenia (RRRR-MM-DD): ");
		DateTime dateOfBirth;

		while (!DateTime.TryParse(Console.ReadLine(), out dateOfBirth)) {
		Console.Write("Błędny format! Podaj datę ponownie (RRRR-MM-DD): ");
		}

		Console.WriteLine("Wybierz płeć (1 - Mężczyzna, 2 - Kobieta, 3 - Inna): ");
		int genderChoice;
		while (!int.TryParse(Console.ReadLine(), out genderChoice) || genderChoice < 1 || genderChoice > 3) {
		Console.WriteLine("Niepoprawny wybór. WYbierz ponownie (1 - Mężczyzna, 2 - Kobieta, 3 - Inna): ");
		}

		Gender personGender = (Gender)(genderChoice - 1);

		//tworzenie i zwrócenie nowego obiektu
		Person newPerson = new Person(firstName, lastName, dateOfBirth, personGender);
		return newPerson;
		} catch (ArgumentException ex) {
		Console.WriteLine($"Błąd: {ex.Message}");
		return null;
		}

		}
	}

	internal class Program {
		static void Main(string[] args) {
		//tworzenie obiektu klasy Person przy użyciu konstruktora domyślnego
		Person person = new Person();

		//tworzenie obiektu klasy Person przy użyciu konstruktora parametrycznego
		Person personx = new Person("Janina", "Szyper", new DateTime(1935, 2, 17), Gender.Kobieta);
		Console.WriteLine(personx.Age);

		person.DisplayInformation();
		personx.DisplayInformation();

		Console.WriteLine("Imię i nazwisko: " + personx.GetFullName());
		Console.WriteLine(personx.ToString());

		/*Person newPerson = Person.InputPersonData();
		if (newPerson != null)
		{
		  Console.WriteLine("\nDane osoby:");
		  Console.WriteLine(newPerson.ToString());
		}
		else
		{
		  Console.WriteLine("\nNie udało się utworzyć osoby. Proszę spróbować ponownie");
		}*/

		/*//tylko imię
		Person person1 = new Person("Jan");
		Console.WriteLine(person1.ToString());

		//imie i nazwisko
		Person person2 = new Person("Anna", "Dwa");
		Console.WriteLine(person2.ToString());

		//imię, nazwisko, płeć
		Person person3 = new Person("Tomasz", "Trzy", Gender.Mężczyzna);
		Console.WriteLine(person3.ToString());

		Console.WriteLine("\n\nDziałanie konstruktora kopiującego");
		Person personPattern = new Person();
		personPattern.FirstName = "Franciszek";
		personPattern.LastName = "Nowak";
		personPattern.DateOfBirth = new DateTime(2022, 3, 26);
		personPattern.PersonGender = Gender.Mężczyzna;
		Console.WriteLine("Wzorcowy obiekt: " + personPattern.ToString());

		Person personCopy = new Person(personPattern);
		Console.WriteLine("Skopiowany obiekt: " + personCopy.ToString() + "\n\n");*/

		//walidacja danych
		/*Person p = new Person();
		p.FirstName = "Paweł";
		//p.FirstName = "";
		//p.LastName = "Pawlak";
		//p.LastName = "   ";
		p.LastName = "4Nowak";
		Console.WriteLine(p.ToString());*/
		Console.WriteLine("\n\n\n");
		Person p = new Person();
		p.FirstName = "";

		if (!p.IsValid) {
			Console.WriteLine(p.ErrorMessage);
		}

		p.FirstName = "Krustian";
		p.LastName = "N2owak";
		p.DisplayInformation();

		p.LastName = "Nowak";
		p.DisplayInformation();
		}
	}
}


