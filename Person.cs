using System;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
namespace CPRG211_Lab1
{
    internal class Person
    {
        //attribute member variables
        private static int nextID = 1; // incrementing unique personID
        internal int personID { get; }
        internal string firstName { get; }
        private string lastName;
        private string favoriteColour;
        private int age;
        private bool isWorking;
        //non attribute member variables
        private static List<Person> people = new List<Person>(); 
        private static bool listPopulated = false; // for error handling
        
        //Construtor
        public Person(string firstName, string lastName, string favoriteColour, int age, bool isWorking)
        {
            this.personID = nextID;
            this.firstName = firstName;
            this.lastName = lastName;
            this.favoriteColour = favoriteColour;
            this.age = age;
            this.isWorking = isWorking;
            nextID++; // increment ID for next OBJ
            people.Add(this); // add OBj to people list
            listPopulated = true;
            Console.WriteLine("Person: "+(this.firstName)+" created successfully."); //confirmation
        }

        //METHODS
        public string DisplayPersonInfo() //prints some OBJ info as string
        {
            //Console.WriteLine((this.personID) + ":  " + (this.firstName) + " " + (this.lastName) + "'s favorite colour is " + (this.favoriteColour)+"\n");
            return $"{this.personID}:  {this.firstName} {this.lastName}'s favorite colour is {this.favoriteColour}\n";
        }
        public override string ToString()// lists all OBJ attributes
        {
            return $"\tPerson ID: {this.personID}\n" +
                $"\tFirst name: {this.firstName}\n" +
                $"\tLast name: {this.lastName}\n" +
                $"\tFavorite Colour: {this.favoriteColour}\n" +
                $"\tAge: {this.age}\n" +
                $"\tIsWorking: {this.isWorking}\n";
        }
        public void ChangeFavoriteColour(string newColour)
        {
            if (this.favoriteColour != newColour)
            {
                this.favoriteColour = newColour; //change fav colour of this OBJ
                this.UpdatePeopleList(); // update OBJ in people list
            }
            Console.WriteLine(this.DisplayPersonInfo()); // Diplay info with new colour
        }
        public void GetAgeInTenYears() //Display OBJ age in 10 years
        {
            int addTen = this.age + 10; // adds 10 to age
            Console.WriteLine((this.personID) + ":  " + (this.firstName) + " " + (this.lastName) + "'s age in ten years will be: " + (addTen) + "\n");
        }
        public static void AgeInformation() //Average age, youngest, oldest
        {
            Console.WriteLine("Calculating age information...\n");
            if (!listPopulated)// skip if no OBJ exists
            {
                Error();
                return;
            }
            double sum = people[0].age; // sum auto set to person1 age
            Person youngest = people[0]; //to find youngest person
            Person oldest = people[0]; // to find oldest person

            if (people.Count > 1) // wont run loop if only one OBJ exists
            {
                for (int i = 1; i < people.Count; i++) // iterate remaining OBJ in list
                {
                    sum += people[i].age; // add each age to sum
                    if (people[i].age > oldest.age) //compare age to oldest
                    {
                        oldest = people[i]; // replace if age is higher
                    }
                    if (people[i].age < youngest.age) //compare to youngest
                    {
                        youngest = people[i]; // replace if age is lower
                    }
                }
            }
            double averageAge = sum / people.Count; // calculate average
            Console.WriteLine("\tThe average age is: " + (averageAge));
            Console.WriteLine("\tThe youngest person is: " + (youngest.firstName) + " (" + (youngest.age) + ")");
            Console.WriteLine("\tThe oldest person is: " + (oldest.firstName) + " (" + (oldest.age) + ")\n");
        }
        public static void CompareFirstLetter(char letter) // search OBJ by first initial
        {
            Console.WriteLine("Searching for people who's first name begins with: "+(letter)+"...\n");
            if (!listPopulated) // skip if no OBJ exists
            {
                Error();
                return;
            }
            bool found = false; // used if no match found
            foreach (Person person in people)
            {
                if (person.firstName[0] == letter) // compare first initial to search char
                {
                    Console.WriteLine(person.ToString()); // Display OBJ if match
                    found = true;
                }
            }
            if (!found) // if no mathc, show following line
            {
                Console.WriteLine("\tNo registered names begin with "+(letter)+"\n");
            }
            Console.WriteLine("\tEnd of results for names beginning with: "+(letter) + "\n");
        }                
        public static void CompareFavoriteColour(string colour) //search by fav colour
        {
            Console.WriteLine("Searching for people who's favorite colour is: " + (colour)+"...\n");
            if (!listPopulated) // Skips rest of code if no OBJ exists yet
            {
                Error();
                return;
                
            }
            bool found = false; // for use if no match found
            foreach (var person in people) // search people list entries
            {
                if (person.favoriteColour == colour) // compare OBJ to search colour
                {
                    found = true;
                    Console.WriteLine("\t"+person.DisplayPersonInfo()); ; // Print info of each match found
                }
            }
            if (!found) // if no matches found, prints the following line
            {
                Console.WriteLine("\tno one found with favorite color: "+(colour)+"\n");
                return;
            }
            Console.WriteLine("\tend of results for colour: "+(colour) + "\n");

        }
        public void UpdatePeopleList() // update people list when OBJ attribute changed
        {
            //called by methods that change attributes
            for (int i = 0; i < people.Count; i++)
            {
                if (people[i].personID == this.personID)
                {
                    people[i] = this;
                    Console.WriteLine("Person: "+(this.firstName)+" updated sucessfully.");
                    return;
                }
            }
        }        
        public static void PrintList() // sends each OBJ ToString
        {
            if (!listPopulated) //skip if no OBJ exists
            {
                Error();
                return;
            }
            foreach (var person in people)
            {
                Console.WriteLine(person.ToString());
            }
        }     
        public static void Error() // generalized error message
        {
            // just because I found myself writing this message in multiple places
            Console.WriteLine("\tError: No people entered into system");
        }
    }
}
