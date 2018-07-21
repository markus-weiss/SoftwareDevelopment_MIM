using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Threading;

namespace Übung_Klausur
{

    public class MyContainer<T> : IEnumerable<T>
    {
        private T[] _theObjects;
        private int _n;

        public MyContainer()
        {
            _theObjects = new T[2];
            _n = 0;
        }

        public void Add(T o)
        {
            // If necessary, grow the array
            if (_n == _theObjects.Length)
            {
                T[] oldArray = _theObjects;
                _theObjects = new T[2 * oldArray.Length];
                Array.Copy(oldArray, _theObjects, _n);
            }

            _theObjects[_n] = o;
            _n++;


        }

        public T GetAt(int i)
        {
            return _theObjects[i];
        }
        public void SetAt(int i, T t)
        {
            // Console.WriteLine(GetAt(i));
            _theObjects[i] = t;

            //Console.WriteLine(GetAt(i));
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < _n; i++)
            {
                yield return _theObjects[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public T this[int i]
        {
            get { return GetAt(i); }
            set { SetAt(i, value); }
        }

        public int Count
        {
            get { return _n; }
        }
    }




    class Ampel : IEnumerable
    {

        string rot = "rot";
        string gelb = "gelb";
        string gruen = "grouen";

        public IEnumerator GetEnumerator()
        {
            yield return rot;
            yield return gelb;
            yield return gruen;
        }

    }

    class Program
    {
        public static void Loading()
        {
            while (true)
            {
                Thread.Sleep(10);
                Console.Write(".");
            }
        }

        static event EventHandler OnStartDownload;

        static void Main(string[] args)
        {


            //async  ()
            //{
            //    WebClient client = new WebClient();



            //    Console.WriteLine("Start App");

            //    Thread t = new Thread(Loading);

            //    string downloadHolder = await client.DownloadStringTaskAsync(new Uri("https://samples.openweathermap.org/data/2.5/weather?q=London,uk&appid=b6907d289e10d714a6e88b30761fae22"));

            //};


            //client.DownloadStringCompleted += delegate (object o, DownloadStringCompletedEventArgs eventArgs)
            //{
            //    t.Abort(); 
            //    Console.WriteLine("End Download");
            //    Console.WriteLine(eventArgs.Result);
            //};


            //Console.WriteLine("Event Added");
            //client.DownloadStringAsync(new Uri("https://samples.openweathermap.org/data/2.5/weather?q=London,uk&appid=b6907d289e10d714a6e88b30761fae22"));
            //t.Start();

            //Console.WriteLine("Start Download");

            Console.ReadLine();
            //Group hierachyObjekt = new Group()
            //{
            //    name = "root",
            //    children = new List<HierachyObjekt>()
            //    {
            //        new Sphere()
            //        {
            //            name ="Sphere1",
            //            radius = 10

            //        },
            //        new Sphere()
            //        {
            //            name ="Sphere2",
            //            radius = 20
            //        },
            //        new Group()
            //        {
            //            name = "UnderGroup",
            //            children = new List<HierachyObjekt>()
            //            {
            //                new Cube
            //                {
            //                    name = "Cube1",
            //                    length = 2,
            //                }
            //            }
            //        }
            //    }
            //};

            //Visitor renderer = new Renderer();
            //renderer.Visit(hierachyObjekt);


            ////Creatures<MyContainer<int>> asdf = new Creatures<MyContainer<int>>();

            //MyContainer<int> myContInt = new MyContainer<int>();

            ////int a = (int) myContInt.GetAt(0);

            //MyContainer<string> myContString = new MyContainer<string>();

            //myContString.Add("a");
            ////Console.WriteLine(":");
            //myContString.Add("b");

            ////Console.WriteLine(":");
            //myContString.Add("z");

            ////Console.WriteLine(":");
            //myContString.Add("c");

            ////Console.WriteLine(":");


            //myContString[2] = ("asdf");

            //foreach (var a in myContString)
            //{
            //    Console.WriteLine("" + a);
            //}

            //Ampel ampel = new Ampel();

            //foreach (string ampelfarbe in ampel)
            //{
            //    Console.WriteLine(ampelfarbe);
            //}

            //   Console.WriteLine(myCont.Count);
        }
    }

}
