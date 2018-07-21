using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace Calculator
{
    /// <summary>
    ///  Aufgabe ! 2te dll mit meheren operatornen /  % / kleinster teiler / größter nenner
    /// </summary>
    public interface IOperator
    {
        char Symbol { get; }
        int Operate(int left, int right);
    }

    //[CalculatorPlugIn('+')] ???
    public class PulsOp : IOperator
    {
        public char Symbol => '+';

        public int Operate(int left, int right)
        {
            return left + right;
        }
    }
    public class MinusOp : IOperator
    {
        public char Symbol => '-';

        public int Operate(int left, int right)
        {
            return left - right;
        }
    }
    public class MultiOp : IOperator
    {
        public char Symbol => '*';

        public int Operate(int left, int right)
        {
            return left * right;
        }
    }
    public class DiviOp : IOperator
    {
        public char Symbol => '/';

        public int Operate(int left, int right)
        {
            return left / right;
        }
    }
                    


    /// <summary>
    /// Dependency Injection
    /// </summary>

    public class Calculator
    {
        public List<IOperator> Operators;

        public string Calculate(string command)
        {
            int opInx = FindFirstNonDigit(command);

            if(opInx < 0)
            {
                return "No Operator specified";
            }

            char opSymbol = command[opInx];
            int left, right;

            try
            {
                left = int.Parse(command.Substring(0, opInx));
                right = int.Parse(command.Substring(opInx + 1));

            }
            catch (Exception)
            {
                return "NULLshit";
            }

            foreach(var op in Operators)
            {
                if(op.Symbol == opSymbol)
                {
                    return op.Operate(left, right).ToString();
                }
            }

            return "Unknown Operator";
        }

        private static int FindFirstNonDigit(string command)
        {
            for(int i = 0; i < command.Length; i++)
            {
                if(!char.IsDigit(command[i]))
                {
                    return i;
                }
                
            }
            return -1;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Calculator calc = new Calculator();
            calc.Operators = new List<IOperator>();

            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            foreach (var fileName in Directory.GetFiles(path))
            {
                Assembly asm = null;
                try
                {
                    asm = Assembly.LoadFrom(fileName);
                }
                catch
                {
                    
                }
                
                if(asm != null)
                {
                    foreach(Type type in asm.GetTypes())
                    {
                        if (typeof(IOperator).IsAssignableFrom(type))
                        {
                            // Found a tyoe in asm that implements IOperator . hooray
                            ConstructorInfo constructor = type.GetConstructor(new Type[0]);
                            if(constructor != null)
                            {
                                calc.Operators.Add((IOperator)constructor.Invoke(new Object[0]));
                            }
                        }
                    }
                }
            }
            
            //calc.Operators = new List<IOperator> { new PulsOp(), new MinusOp(), new MultiOp(), new DiviOp()};

            string commandline;
            Console.WriteLine("hello to clac");
            while (true)
            {
                commandline = Console.ReadLine();
                if (commandline.ToLower() == "break")
                {
                    break;
                }
                Console.WriteLine(calc.Calculate(commandline));
            }

            Console.ReadLine();
        }
    }
}
