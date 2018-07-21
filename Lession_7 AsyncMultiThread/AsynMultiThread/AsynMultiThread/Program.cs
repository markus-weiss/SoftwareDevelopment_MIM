using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsynMultiThread;
using System.Collections;

namespace AsynMultiThread
{
    /// <summary>
    ///  Async MultiThreading
    ///  Auf verschiendenen CPUs arbeiten#
    ///  
    ///  Asynchonus Programming Patterns
    /// </summary>


    class A
    {
        public void DoThis()
        {
            Console.WriteLine("DoA");
        }
        public virtual void VDoThis()
        {

            Console.WriteLine("DoAV");
        }
    }

    class B : A
    {

        public void  DoThis()
        {


            Console.WriteLine("DoB");
        }
        public override void VDoThis()
        {

            Console.WriteLine("DoBV");
        }

    }

    public delegate void  OnDamage(int damageAmount);

    public delegate bool OnAction();

    class Interaktion
    {
        public void ThereIsAnAction(OnAction a)
        {
            if (true)
            {
                a();
            }
    
        }
    }

    class ListenToAktion
    {
        //public void Listening()
        //{
        //    ThereIsAnAction({
        //    return true;
        //} delegate
        //    {

        //    })
        //}

        //public bool OnActionHered()
        
    }



    static class Monster
    {
        static int armor = 10;
        public static void damaged(int damageAmount, OnDamage reflectDamage, OnDamage burnMana)
        {

       
        }

        //static IEnumerator Dot()
        //{
        //    yield return
        //             reflectDamage(damageAmount - armor);
        //    burnMana(1);
        //}
    }

    class Player
    {
        int health = 100;
        int mana = 100;
        public void hit()
        {
            Monster.damaged(30, damaged, manaBurn);
            Console.WriteLine("hitted");
        }

        public void manaBurn(int x)
        {
            mana -= x;
        }

        public void damaged(int x)
        {
            health -= x;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            

            //for (int i = 0; i < 100;i++)
            //{
            //    Thread.Sleep(100);
            //    Console.Write(".");
            //}

            //string a = "Hello";
            //string b = "Hello";

            //int i = 42;
            //object o = i;
            //o = 43;
            //int j = (int)o;
            //j = 10;
            //Console.WriteLine("i is: " + i + "; o is: " + o + "; j is: " + j);

            //Console.WriteLine(a == b + ": " + a === b);
            //B a = new B();

            //a.DoThis();
            //a.VDoThis();


            //Cube c = new Cube(1,1);
            //c.Square();
            //c.move(2);


            //Console.ReadLine();

            //Asyncronous Asy = new Asyncronous();

            //Asy.GetInputString();
        }
    }

    class Asyncronous : A, IMoving
    {
        public void Asyncro()
        {

        }

        public bool isReading;

        public string GetInputString()
        {
            return Console.ReadLine();
        }

        public void move(float vel)
        {
            throw new NotImplementedException();
        }

        public float getMove()
        {
            throw new NotImplementedException();
        }
    }


    interface IMoving
    {
        void move(float vel);
        float getMove();
    }

    public abstract class MoveableObject
    {
        public int a = 1;
        public abstract float Square();
        

    }

    struct Test
    {
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            object test;
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return "Penis";
        }
    }

    class Cube : MoveableObject , IMoving
    {
        public float leght, width;

        public Cube(float leght, float width)
        {
            this.leght = leght;
            this.width = width;
        }

        public float getMove()
        {
            throw new NotImplementedException();
        }

        public void move(float vel)
        {
            throw new NotImplementedException();
        }

        public override float Square()
        {
            return leght * width;
        }
    }

}