using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Structs;


namespace Structs
{
    // a struct is a value Type Variable
    // a class is a reference type Variable

    // What is a Value Type? 
    // -- Is ALWAYS going to contain a Value 
    // Live on the Stack // other things that live on the stack, include primitive data types, and references to Objects
    // NO MEMORY OVERHEAD

    //Whats is a Reference Type?
    // -- is going to come packaged with a pointer (point frrom heap to stack)
    // At any time, the reference could be null
    // Live on the Stack with reference to the Heap 
    // there is going to be Memory Overhead with reference types

    //STACKS contain pimitive data types and instances of objects (references to classes)
    //HEAP is the actual memory allocation area, defining and creating space in memory


    // When do we use structs +
    //-- use when there are going to be many instances
    // -- of when it is embedded inside a class
    //-- Make sure that the data is under 16 bits of information

    // when do we use classes
    //--if we want to have large data
    //--if we want to a lot of functionality
    //--if we want to have a default constructor



    struct Position // A value type
    {
        public int x;
        public int y;

        public Position(int initialX, int initialY)
        {
            x = initialX;
            y = initialY;
        }

    }




    public class Program
    {
        static void Main(string[] args)
        {
            //string name1 = "asdf", name2 = "asdfSDF";
            //Console.WriteLine("Name 1:{0}, Name2:{1}",name1,name2);

            // create a external class that does functionality fpr us the out main class is hoingh 

            string name;

            Console.WriteLine("Bitte Name eingeben");
            name = Console.ReadLine(); // Initialisiert

            // Zeiger(Referenzpointer) setzen im heap auf einen anderen Speicherplatz
            Enemy caveYeti = new Enemy();
            Enemy dragon = new Enemy(name, 50, 50);

            Console.WriteLine("enemy 1: " + caveYeti.name);
            Console.WriteLine("enemy 2: " + dragon.name);

            caveYeti = dragon;
            caveYeti.name = "Yeti";

            Console.WriteLine("enemy 1: " + caveYeti.name);
            Console.WriteLine("enemy 2: " + dragon.name);


            // hier Wird nicht refferenziert daher kann im nachhienein ein wert geändert werden

            Position pos1 = new Position(4, 5);
            Position pos2 = new Position(44, 55);

            pos1 = pos2;

            Console.WriteLine("Pos1.x: " + pos1.x);
            Console.WriteLine("Pos2.x: " + pos2.x);


            pos1.x = 100;

            Console.WriteLine("Pos1.x: " + pos1.x);
            Console.WriteLine("Pos2.x: " + pos2.x);

            // hält die Console auserhalb des Debug offen
            Console.ReadKey();
        }

        /*
double a, b;
double ergebnis;

Console.WriteLine("Geben sie die erste Zahl ein:");
a = Convert.ToDouble(Console.ReadLine());
Console.WriteLine("Geben sie die zweite Zahl ein:");
b = Convert.ToDouble(Console.ReadLine());

ergebnis = a / b;
*/


        /*
         *            string name1 = "markus", name2 = "penis", name3 = "vagina";

         * 
            string name; // Deklaration Call by Value
            int alter; 

            Console.WriteLine("Bitte Name eingeben");
            name = Console.ReadLine(); // Initialisiert
            Console.WriteLine("Bitte Alter eingeben");
            alter = Convert.ToInt32(Console.ReadLine());

            Console.Write("Name: " + name + " " + "Alter: " + alter);
            Console.ReadKey();//Konsole Bleibt offen

            // 5f = implizite umwandlung zum float        
         
         
         */
    }
}
