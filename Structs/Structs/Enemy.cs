using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Structs;

namespace Structs
{

    public class Enemy
    {
        public string name;
        private int a;
        private int b;
        private int c;


        public Enemy()
        {

        }



        public Enemy(string _a, int _b, int _c)
        {
            this.name = _a;
        }

        public void enemyFkt()
        {
            Console.WriteLine("Hello" + name + ", how are you doing ");
        }
    }

}
