using System;
using System.Security.Cryptography;

namespace CPRG211_Lab1
{
    public enum RelationshipType // for Relation class Relationshp type
    {
        Brother, Sister, Mother, Father
    }
    //•	ShowRelationShip: accepts two Person objects and displays the relationship between them
    internal class Relation
    {
        //Member variables
        private static List<(Person, Person, RelationshipType)> relationships = new List<(Person, Person, RelationshipType)> ();
        private static bool relationListPopulated = false;
        private RelationshipType relationType;

        //Constructor
        public Relation(Person a, Person b, RelationshipType type) //create new relationship OBJ
        {
            // takes two Person objects and a type as args
            this.relationType = type; // set sttribute relationship type

            relationships.Add((a, b, this.relationType)); //adds info to relationships list, for lookup later
            relationListPopulated = true; // set bool to true to indicate the list is populated
        }
        public static void FindRelation(Person a, Person b) // show relation between two Person OBJ's
        {
            Console.WriteLine("Searching for relationship between "+(a.firstName)+" and "+(b.firstName)+"...\n");
            if (!relationListPopulated) // skip if no relationship OBJ exists
            {
                Console.WriteLine("\tError: There are no recorded relationships to search");
                return;
            }
            foreach (var v in relationships) // search through relationships list
            {
                if((v.Item1 == a && v.Item2 == b) || (v.Item1 == b && v.Item2 == a))
                // compares input people to entries in relationship list
                {
                    Console.WriteLine("\t"+(a.firstName)+" and "+(b.firstName)+" are "+(v.Item3)+"s.\n");
                    return; // prints relationship info if relationship found
                }
            }
            Console.WriteLine("\tNo relationship found for "+(a.firstName)+" and "+(b.firstName)+".\n");

        }
    }
    
}
