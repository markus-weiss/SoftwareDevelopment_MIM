using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lession_2._2
{

    class Program
    {
        static void Main(string[] args)
        {
            N someA = new M();
            someA.DoSomething();


            Circle C = new Circle();
            Console.WriteLine(C.CalculateArea(2));

            Rect R = new Rect();
            Console.WriteLine(R.CalculateArea(2, 5));

            Cube cube = new Cube();
            Console.WriteLine(cube.CalculateArea(5,5,5));

            Sphere sphere = new Sphere();
            Console.WriteLine(sphere.CalculateArea(5));





            Console.ReadLine();


        }
    }

    /// Vererbung
    /// B hat alles was A auch hat
    /// 

    public class A
    {
        public string bla;
        public int blabla;

    }

    public class B : A
    {
        public string blablabla;

    }

    ///Polymorphie
    /// ist eine Methode einer classe virtual kann sie mit override überschrieben Werden
    /// 

    public class N
    {

        public virtual void DoSomething()
        {
            Console.WriteLine("asdf");
        }
    }

    public class M : N
    {
        public override void DoSomething()
        {
            Console.WriteLine("M : N");
        }
    }

    /// Implementierungsloser Elterntyp
    /// abstact = rumlose Methode 
    /// Alle Methoden müssen damit gekennzeichnet sein

    public abstract class Shape2D
    {
        public string name = "asdf";
        public abstract double CalculateArea(); // Polymorphe methode
    }

    public class Rect : Shape2D
    {
        
        public int height;
        public int width;

        public override double CalculateArea()
        {
            throw new NotImplementedException();
        }

        /*
        public override double CalculateArea(int a , int b)
        {
            return a * b;
        }
        */
    }

    public class Circle
    {
        public int radius;

        public double CalculateArea(int r)
        {
            return r * r * 3.14f;
        }

    }

    /// Interfaces
    /// sind in einer class aschlschpeilich abstract anteile kann man interface schreiben
    /// Eine Class kann mehrere Interface haben aber nur von einer klasse Erben 
    /// auch bei Struct möglich
    /// Methoden immer virtual

    public interface Shape3D
    {
        double CalculateArea(); // Polymorphe methode
    }

    public class Cube : Shape3D
    {
        public int height;
        public int width;
        public int lenght;



        public double CalculateArea()
        {
            //return /*a * b * c*/true;
        }

    }

    public class Sphere
    {
        public int radius;

        public double CalculateArea(int r)
        {
            return 4/3 * 3.1415f * (r * r * r);
        }

    }


}
