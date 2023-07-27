using System;

namespace TemperatureSpace
{
    /// <summary>
    /// This is a stub for a temperature sensor. In real world this would be a 
    /// class that communicates with actual sensor. But for now
    /// we create a stub that generates random temperatures instead of reading from
    /// a hardware sensor
    /// </summary>
    internal class SensorStub
    {
        internal static float GetTemperature()
        {
            return randomTemperature();
        }

        internal static float randomTemperature(double maximum = 100, double minimum = -100)
        {
            Random random = new Random();
            return (float)(random.NextDouble() * (maximum - minimum) + minimum);
        }

    }
}