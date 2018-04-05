using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /*
    public abstract class GraphicsObjects
    {
        public string name;
        // jedes unterobjekt muss diese klasse enthaltebn 
        public abstract void CalcArea();

    }
    */
    public abstract class GraphicsObjects
    {
        // jedes unterobjekt muss diese klasse enthaltebn 
        public abstract void CalcArea();

    }
    public interface EdgeObj
    {
        // jedes unterobjekt muss diese klasse enthaltebn 
        void CalcArea();

    }

    public class Rect : GraphicsObjects, EdgeObj
    {
        public float width;
        public float height;

        public abstract CalcArea()
        {

        }

        public void CalcArea()
        {
            Console.WriteLine("CalcArea Rect: " + width * height);
        }




    }
    public class Cricle : GraphicsObjects
    {
        public float radius;

        public void CalcArea()
        {
            Console.WriteLine("CalcArea Circle: " + radius * radius * 3.1415f);

        }

    }




    public class A
    {
        public string Name;
        public int Number;

        public virtual void doSome()
        {
            Console.WriteLine("Die Ausgabe von a, Name: " + Name + " Number:" + Number);
        }
    }

    public class B : A
    {
        public string Nachname;


        public override void doSome()
        {
            base.doSome();
            //Console.WriteLine("Name: " + Name + " Number: " + Number + " Nachname: " + Nachname);
            Console.WriteLine(" Nachname: " + Nachname);
        }
    }

    /*
    public class B
    {
        //aggregation
        public A a = new A { };
        public string Nachname;
    }
    */

    class Program
    {
        static void Main(string[] args)
        {
            GraphicsObjects[] stage = new GraphicsObjects[2];

            stage[0] = new Cricle { radius = 0.5f };
            stage[1] = new Rect { width = 0.5f , height = 1.0f };
            

            foreach (GraphicsObjects graphicobject in stage)
            {
                //Polymorpher aufruf
                graphicobject.CalcArea();
            }

            /*
            ///Vererbung
            A a = new A {Name = "asdf", Number = 1 };
           // a.doSome();

            B b = new B { Name = "Markus ", Nachname = "Weiß", Number = 27 };
            //b.doSome();

            A someA;
            someA = b;

            ////////////////////////////////

            someA.doSome();
            */
            Console.ReadLine();
            
        }
    }
}
