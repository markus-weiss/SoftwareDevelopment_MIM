using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Reflections
{
    /// <summary>
    /// Lektion  05 Reflections "Decompiler, Attribute, Dependecy, Injection"
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class ClassInfoAttribute : Attribute
    {

    }

    [AttributeUsage(AttributeTargets.Field)]
    public class FieldInfoAttribute : Attribute
    {

    }
    [AttributeUsage(AttributeTargets.Parameter)]
    public class ParamInfoAttribute : Attribute
    {

    }

    public class MethodInfoAttribute : Attribute
    {

    }



    [ClassInfo]
    class Person
    {
        [FieldInfo]
        public string Name;
        public int Age;

        [Obsolete("Give (int a)",false)]
        public void DoSomeThing()
        {

        }

        [MethodInfo]
        public void DoSomeThing(int a)
        {

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            /*
            int i = 42;
            string str = "Hallo";
            */
            Person person = new Person { Name = "Horst", Age = 66 };

            person.DoSomeThing();
            person.DoSomeThing(10);


            Assembly asm = Assembly.GetExecutingAssembly();
            asm.GetTypes();
            Type[] typen = asm.GetTypes();

            foreach(Type typ in typen)
            {
                PrintType(typ);
            }

            

            Console.WriteLine("Press any key to break");
            Console.ReadLine();
        }

        /////////////////////////////////////////////////////////

        static void PrintObject(object ob)
        {

            Type typ = ob.GetType();
            Console.WriteLine(typ);
        }
        static void PrintType(Type typ)
        {
            Console.WriteLine("class " + typ.Name + " \n" + "{");   

            if (typ.IsClass)
            {
                FieldInfo[] fields = typ.GetFields();
                foreach(FieldInfo field in fields)
                {
                    Console.WriteLine(field.FieldType.Name + " " + field.Name + ";");
                }
            }
            Console.WriteLine(typ.Name + "}");
        }
    }
}
