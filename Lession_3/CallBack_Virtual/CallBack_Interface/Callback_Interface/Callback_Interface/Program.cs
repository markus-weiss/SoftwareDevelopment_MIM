using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Callback_Interface
{
    // Class wird zu interface
    public interface IProgressReporter
    {   // public , virtual, {}, fallen weg
        void ReportProgress(int percentDone);
    }

    public static class Calculator
    {
        public static int SomeLengthyCalculation(IProgressReporter pr)
        {
            for (int i = 0; i < 100; i++)
            {
                // Sleep 1/10 second - simulates a step in the calculation
                Thread.Sleep(100);

                pr.ReportProgress(i);
            }
            return 42;
        }
    }


    //  ^
    //  |    Implementation of Calculation. Implementors don't know anything about
    //  |    the context their code is called in (language, UI-System, etc.).
    ///////////////////////////////////////////////////////////////////////////////////////////
    //  |    User Code using the Calculation. User code cannot change the calculation's 
    //  |    implementation but needs to report the progress to the user.
    //  V

    public class UserProgressReporter : IProgressReporter
    {
        public void ReportProgress(int percentDone)
        {
            Console.WriteLine($"Calculating. {percentDone}% already done.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting the calculation");
            var result = Calculator.SomeLengthyCalculation(new UserProgressReporter());
            Console.WriteLine($"The result is: {result}.");

            Console.ReadKey();
        }
    }
}
