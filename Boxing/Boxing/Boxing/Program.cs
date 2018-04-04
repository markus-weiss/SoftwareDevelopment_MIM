using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


namespace Boxing
{

    public class Complex
    {
        public double m_Re;
        public double m_Im;

        public override bool Equals(object ob)
        {
            // wenn Obj Objekt dieses Structs ist dann
            if (ob is Complex)
            {
                // UNboxe in neues Struct c
                Complex c = (Complex)ob;
                // und gib zurück ob die Werte Gleich sind
                return m_Re == c.m_Re && m_Im == c.m_Im;
            }
            else
            {
                return false;
            }
        }
        // Frägt ab ob Werte Gleich sind fals ja false falls nein True
        public override int GetHashCode()
        {
            return m_Re.GetHashCode() ^ m_Im.GetHashCode();
        }
        
    }   
    
    

    public class StructStandart{
        public float f;
    }

    class Program
    {
        static void Main(string[] args)
        {


            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            long d = GC.GetTotalMemory(true);
            Console.WriteLine("time: " + stopwatch.Elapsed + " Memory: " + d);

            Console.WriteLine(" ");
            StructStandart n = new StructStandart();
            StructStandart m = new StructStandart();
            Console.WriteLine(n.Equals(m) + " Normal Equals a gleich b ? ");
            Console.WriteLine(n.GetHashCode() + " : " + m.GetHashCode() + " Normal Hash");
            d = GC.GetTotalMemory(true);
            Console.WriteLine("time: " + stopwatch.Elapsed + " Memory: " + d);

            Console.WriteLine(" ");
            Complex a = new Complex();
            Complex b = new Complex();
            Console.WriteLine(a.Equals(b) + " Overwritten a gleich b ? ");
            Console.WriteLine(a.GetHashCode() + " : " + a.GetHashCode() + " Get Hash overwriten");
            d = GC.GetTotalMemory(true);
            Console.WriteLine("time: " + stopwatch.Elapsed + " Memory: " + d);


            //Console.WriteLine(true ^ false);

            Console.WriteLine(" ");

            //Console.WriteLine(a.Equals(b));
            //Console.WriteLine(GetHashCode());

            /// Boxing & Unboxing
            ///

            int i = 123;
            object o = i;  // implicit boxing

            try
            {
                int j = (int)o;  // attempt to unbox

                System.Console.WriteLine("Unboxing OK.");
            }
            catch (System.InvalidCastException e)
            {
                System.Console.WriteLine("{0} Error: Incorrect unboxing.", e.Message);
            }
            catch (System.NullReferenceException e)
            {
                System.Console.WriteLine("{0} Error: Null Reference Exeption.", e.Message);
            }

            

            
            int s = 123;

            object l = i;

            i = 456;

            System.Console.WriteLine("The value-type value = {0}", i);
            System.Console.WriteLine("The object-type value = {0}", o);
            

            
            int k = 123;
            // The following line boxes i.
            object t = i;

            int u = (int)o;

            Console.WriteLine(i + " " + o + " " + a);

            //nimmt 3 object Argumente 42 und true müssen geboxt werden
            //Console.WriteLine(String.Concat("Answer", 42, true));

            List<object> mixedList = new List<object>();
            mixedList.Add("First Group:");

            for (int j = 1; j < 5; j++)
            {
                // Rest the mouse pointer over j to verify that you are adding
                // an int to a list of objects. Each element j is boxed when 
                // you add j to mixedList.
                mixedList.Add(j);
            }

            // Add another string and more integers.
            mixedList.Add("Second Group:");
            for (int j = 5; j < 10; j++)
            {
                mixedList.Add(j);
            }

            foreach (var item in mixedList)
            {
                // Rest the mouse pointer over item to verify that the elements
                // of mixedList are objects.
                Console.WriteLine(item);
            }

            var sum = 0;
            for (var j = 1; j < 5; j++)
            {
                // unboxing with (int)
                sum += (int)mixedList[j] * (int)mixedList[j];
            }

            Console.WriteLine("Sum: " + sum);

    

            Console.ReadLine();

        }
    }
}
