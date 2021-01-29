using System;
using System.Collections.Generic;
using System.Linq;

namespace ContactList
{
    class Program

    {
        public static List<Person> People = new List<Person>();
        static void Main(string[] args)
        {

            string command = "";

            while (command != "exit")
            {
                //Console.Clear();
                Console.WriteLine("==== Natalya's Contact List ====");
                Console.WriteLine("\n Please enter command (add, remove, display, update, find):");

                command = Console.ReadLine().ToLower();

                switch (command)
                {
                    case "add":
                        AddPerson();
                        break;
                    case "remove":
                        RemovePerson();
                        break;
                    case "display":
                        DisplayPeople();
                        break;
                    case "update":
                        UpdateInfo();
                        break;
                    case "find":
                        FindContact();
                        break;
                    
                }
            }



        }

      
        private static Person FindContact()
        {
            Console.WriteLine("Enter the first name of the person you want to find in the contact list");
            string firstName = Console.ReadLine();
            Person person = People.FirstOrDefault(x => x.FirstName.ToLower() == firstName.ToLower());

            if (People.Count == 0)
            {
                Console.WriteLine("Your Contact List is empty. Press any key to continue.");
                Console.ReadKey();
                return null;
            }
            else {
                Console.WriteLine("Person is found!");
                PrintPerson(person);
                
            }
            return person;

           
                       }



        private static void DisplayPeople()
        {
            if (People.Count == 0)
            {
                Console.WriteLine("Your Contact List is empty. Press any key to continue.");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("Here are the current people in your contact list:\n");
            foreach (var person in People)
            {
                PrintPerson(person);
            }
            Console.WriteLine("\n Press any key to continue.");
            Console.ReadKey();

        }

        private static void RemovePerson()
        {
            Console.WriteLine("Enter the first name of the person you want to remove from the contact list");
            string firstName = Console.ReadLine();
            Person person = People.FirstOrDefault(x => x.FirstName.ToLower() == firstName.ToLower());

            if (person == null)
            {
                Console.WriteLine("That person could not be found. Press any key to continue");
                Console.ReadKey();
                return;

            }
            {
                Console.WriteLine("Are you sure you want to remove this person from the list?");
                PrintPerson(person);

                if (Console.ReadKey().Key == ConsoleKey.Y)
                {
                    People.Remove(person);
                    Console.WriteLine("Person is removed. Press any key to continue");
                    Console.ReadKey();

                }
            }

        }


        private static void PrintPerson(Person person)
        {
            Console.WriteLine("First Name: " + person.FirstName);
            Console.WriteLine("Last Name: " + person.LastName);
            Console.WriteLine("Phone Number: " + person.PhoneNumber);
            Console.WriteLine("Email: " + person.Email);
            Console.WriteLine("-------------------");


        }


        private static void AddPerson()
        {

            Person person = new Person();
        
            Console.Write("Enter First Name: ");
            person.FirstName = Console.ReadLine();

            Console.Write("Enter Last Name: ");
            person.LastName = Console.ReadLine();

            Console.Write("Enter Phone Number: ");
            person.PhoneNumber = Console.ReadLine();

            Console.Write("Enter Email: ");
            person.Email = Console.ReadLine();
            
            People.Add(person);

            Console.WriteLine("The person is added to the contact list\n");

        }

        private int FindContact(Person person)
        {
            int result = People.IndexOf(person);
            return result;
        }

        private static void UpdateInfo()
        {
            // we're searching contact in the list

            Console.WriteLine("Enter the first name of the person you want to update the information");
            string firstName = Console.ReadLine();
            Person person = People.FirstOrDefault(x => x.FirstName.ToLower() == firstName.ToLower());

            if (person == null)
            {
                Console.WriteLine("That person could not be found. Press any key to continue");
                Console.ReadKey();
                return;

            }

            {
                Console.WriteLine("Are you sure you want to update this person's information (Y / N) ");
                PrintPerson(person);

                if (Console.ReadKey().Key == ConsoleKey.Y)
                {
                    Console.WriteLine("\nYou choose option Yes");

                    Console.Write("Enter First Name:");
                    person.FirstName = Console.ReadLine();

                    Console.Write("Enter Last Name:");
                    person.LastName = Console.ReadLine();

                    Console.Write("Enter Phone Number:");
                    person.PhoneNumber = Console.ReadLine();

                    Console.Write("Enter Email:");
                    person.Email = Console.ReadLine();

                    
                    Console.WriteLine("\nUpdate successful and new person added to the contact list");
                    //PrintPerson(person); - is one of the options how to display information
                    Console.WriteLine(person);

                }


            }


        }
    }

    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public Person(string FirstName, string LastName, string PhoneNumber, string Email) { 
        
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.PhoneNumber = PhoneNumber;
            this.Email = Email;
        }

        public Person()
        {
        }

        public override string ToString()
        {
            return $"First name: {this.FirstName},\nLast name: {this.LastName},\nPhoneNumber: {this.PhoneNumber},\nEmail: {this.Email}\n";
        }
    }


}



