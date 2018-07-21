using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Generics_1._0
{
    /*
    class MyContainerEnumerator<T> : IEnumerator<T>
    {

    }
    */

    // where := class, struct, interface, parameterlos construktor
    // IComparable sortiert
    // TODO nachholen
    class MyContainer<T> : IEnumerable<T>
    {
        T[] _theObjects;
        int _nextFreeEntry;

        // Get Kurzschreibweise
        //public int Length => _nextFreeEntry;
        public int Length       
        {
            get { return _nextFreeEntry; }
        }
        

        public MyContainer()
        {
            _theObjects = new T[2];
            _nextFreeEntry = 0;
        }

        public void Append(T item)
        {
            if (_nextFreeEntry >= _theObjects.Length)
            {
                T[] newArray = new T[_theObjects.Length * 2];
                Array.Copy(_theObjects, newArray, _theObjects.Length);
                _theObjects = newArray;
            }

            _theObjects[_nextFreeEntry] = item;
            _nextFreeEntry = _nextFreeEntry + 1;
        }


        public IEnumerator<T> GetEnumerator()
        {
            for(int index = 0; index < _nextFreeEntry; index++)
            {
                yield return _theObjects[index];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /*
        public T GetAt(int index)
        {
           return _theObjects[index];
        }
        */

        // erstellt die übergabe in [] per index schreibweise
        public T this[int index]
        {
            get
            {
                return _theObjects[index];
               // return GetAt(i);
            }
            
            set
            {
                if (index >= _theObjects.Length)
                {
                    T[] newArray = new T[index  * 2];
                    Array.Copy(_theObjects, newArray, _theObjects.Length);
                    _theObjects = newArray;
                }

                _theObjects[index] = value;
                if (index >= _nextFreeEntry)
                {
                    _nextFreeEntry = _nextFreeEntry + 1;
                }     
            }           
        }
    }

    /// <summary>
    /// //////////////////////////////////////////////////////////////////////////////////////
    /// </summary>

    class Program
    {
        static void Main(string[] args)
        {

            MyContainer<string> einContainer = new MyContainer<string>();
            einContainer[00]="0";
            einContainer[01]="1";
            einContainer[02]="2";
            einContainer[03]="3";
            einContainer[04]="4";
            einContainer[05]="5";
            einContainer[06]="6";
            einContainer[07]="7";
            einContainer[08]="8";
            einContainer[09]="9";
            // Hier in array fehl noch was ?? 
            einContainer[10]="22";


            foreach(string str in einContainer)
            {
                Console.WriteLine(str);
            }
            /*
            for (int i = 0; i < einContainer.Length; i++)
            {
                //Console.WriteLine(einContainer.GetAt(i));
                Console.WriteLine(einContainer[i]);
            }
            */
            
         /*
         MyContainer<string> stringContainer = new MyContainer<string>();
         stringContainer.Append("asdf");
         */
         /*
            ///////////////////////////////////////////////

            int[] einArray = new int[10];

            einArray[0] = 33;
            einArray[1] = 33;
            einArray[2] = 33;
            einArray[3] = 33;
            einArray[4] = 33;
            einArray[5] = 33;
            einArray[6] = 33;
            einArray[7] = 33;
            einArray[8] = 33;
            einArray[9] = 33;
            */
            /// in = ist enumeribar
            /// IEnumerable
            /// 
            ///Compiler sieht das
            /*
            foreach(int item in einArray)
            {
                Console.WriteLine(item);
            }
            */

            /// und baut daraus das
            /// 
            /*
            IEnumerator arrayEnumerator = einArray.GetEnumerator();
            while (arrayEnumerator.MoveNext())
            {              
                Console.WriteLine(arrayEnumerator.Current);
            }
            */

            /*
            for (int i = 0; i < einArray.Length; i++)
            {
                Console.WriteLine(einArray[i]);
            }
            */
            



            Console.WriteLine("TO END press any key");
            Console.ReadLine();
        }
    }


    //Container bzw. Collection Klassen
    class Person<TAlter, TOrt>
    {
        public string Name;
        public TOrt GebOrt;
        public TAlter Alter;
        // Wegen funktion fragen float int
    }
}
