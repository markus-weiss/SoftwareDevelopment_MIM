using System;
using System.Threading;

public static class Calculator
{
	public static int SomeLenghtCalculation()
    {
   
        for (int i = 0; i < 100; i++)
        {
            // Simluiere Längliche Berechnung
            Thread.Sleep(100);
        }
        return 42;
        
    }
}
