using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace RefsANDValues
{
    public class Enemy
    {
        public int I;
    }

    public class float3
    {
        public float x;
        public float y;
        public float z;
    }
    public class Vertex
    {
        public float3 Position;
        public float3 Normal;
        public float3 UVW;
    }

    

    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Vertex[] VertexArray = new Vertex[1000000];

            for (int i = 0; i < VertexArray.Length; i++)
            {
                VertexArray[i] = new Vertex
                {
                    Position = new float3 { x = i, y = i, z = i },
                    Normal = new float3 { x = i, y = i, z = i },
                    UVW = new float3 { x = i, y = i, z = i }
                };


            }
            Console.WriteLine(stopwatch.ElapsedMilliseconds);
            //SIZEOF


            //int[] array = {1,2,3};


            /// Ziemlich performancelastig , kann aber vorteile haben
            //Enemy[] Nazis = { new Enemy { I = 1 }, new Enemy { I = 2 }, new Enemy { I = 3 } };

            //Console.WriteLine(Nazis[0].I);

            /*

            int i = 42;
            object o = i;
            int j = (int)o;

            if (o.Equals(i))
            {
                Console.WriteLine(true);
            }

            Console.WriteLine("o: " + o);

            */

            /*
            Enemy a = new Enemy {I = 3};
            Enemy b = a;
            a.I = 4;


            
            /// bei Class ist es true bei Struct ist es false
            if (a.Equals(b))
            {
                Console.WriteLine("true a:" + a.I + " b: " + b.I);
            }
            else
            {
                Console.WriteLine("false a:" + a.I + " b: " + b.I);
            }

            Console.WriteLine("a:" + a.I + " b: " + b.I);
            */

            Console.ReadLine();
        }
    }
}
