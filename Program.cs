using System;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
namespace CPRG211_Lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program Start. Hello!\n");
            //a: Create 4 person objects using information provided from assignment
            Person person1 = new Person("Ian", "Brooks", "Red", 30, true);
            Person person2 = new Person("Gina", "James", "Green", 18, false);
            Person person3 = new Person("Mike", "Briscoe", "Blue", 45, true);
            Person person4 = new Person("Mary", "Beals", "Yellow", 28, true);

            //b: Display Gina's (person2) id, name and favorite colour          
            Console.WriteLine("\n"+person2.DisplayPersonInfo());

            //c: Display all info for Mike (person3) as a list
            Console.WriteLine(person3.ToString());
            
            //d: Change Ian's (person1) fav colour to "white" and display his info as sentence
            person1.ChangeFavoriteColour("White");
            
            //e: Show Mary's (person4) age after 10 years
            person4.GetAgeInTenYears();

            //f.Create two Relation Objects that show that Gina and Mary are sisters
            //and that Ian and Mike are brothers.Then, display both relationships.
            Relation relationship1 = new Relation(person2, person4, RelationshipType.Sister);
            Relation relationship2 = new Relation(person1, person3, RelationshipType.Brother);

            //Then, display both relationships.
            Relation.FindRelation(person2, person4);
            Relation.FindRelation(person1, person3);
                       
            /* g.Add all the Person objects to a list
            !!!! added functionality to build list as Person objects are created
            in Person constructor.!!!! */

            // use list to display the following:
            //•	The average age of the people in the list
            //•	The youngest person and the oldest person
            Person.AgeInformation();

            //•	The names of the people whose first names start with M
            Person.CompareFirstLetter('M');
    
            //•	The person information of the person that likes the colour blue
            Person.CompareFavoriteColour("Blue");

            Console.WriteLine("End of program. Goodbye!");
        }
}
}
