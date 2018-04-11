using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


/// <summary>
/// CALLBACKS  Code zusammenfassen der von anderen unabhänig aufgerufen werden kann
/// Codeübergabe
/// Delegates
/// </summary>
namespace Lession_3
{

    // Umwandlung zum Datentyp
    public delegate void ProgressReporterDelegate(int i);
    public delegate void ResultReceiverDelegate(int i);


    public class Calculator
    {
        // Kann mit event mehrere Delegates speichert
        // Jeder kann immer nur sein eigenes event wieder löschen
        public event ProgressReporterDelegate ProgressReporter;
        public event ResultReceiverDelegate  ResultReceiver;

        public void StartSomeLenghtCalculation()
        {
            new Task(DoCalculate).Start();
                
        }

        private void DoCalculate()
        { 

            for (int i = 0; i < 100; i++)
            {
                // Simluiere Längliche Berechnung
                Thread.Sleep(100);

                ProgressReporter(i);

                //Console.WriteLine(i + "% Berechnet");
            }
            ResultReceiver(42);

        }
    }

    //Library Programmierer
    //
    ////////////////////////////////////////////////////////////////////
    //
    //Anwendunsprogramierer



    

    class Program
    {
        static void ReportProgress(int i)
        {
            if (i % 10 == 0)
                Console.WriteLine(i + "% Berechnet");
        }
        static void ReportOtherProgress(int i)
        {
                Console.Write(".");
        }

        static void ReceiveResult(int i)
        {
            Console.WriteLine("Result: " + i + "");
        }

        static void Main(string[] args)
        {
            Calculator myCalculator = new Calculator();
            // mit += wird es der Liste der ProgressReportEvents hinzugefügt
            myCalculator.ProgressReporter += ReportProgress;
            myCalculator.ProgressReporter += ReportOtherProgress;

            myCalculator.ResultReceiver += ReceiveResult;
            myCalculator.StartSomeLenghtCalculation();




            Console.WriteLine("Calculation just started but not finished.");

            Console.ReadLine();
        }
    }
}
