using System;
using System.Diagnostics;

namespace TemperatureSpace {
    class Alerter {
        static int alertFailureCount = 0;
        static int tempThresholdInC = 280;

        static void alertInCelcius(float farenheit) {
            float celcius = cToF(farenheit);

            int returnCode = NetworkStub.SendAlert(celcius, tempThresholdInC);
            if (returnCode == NetworkStub.codeNotOk)
            {
                // non-ok response is not an error! Issues happen in life!
                // let us keep a count of the number of times the alert was not communicated
                // However, this code doesn't count failures!
                // Add a test below to catch this bug. Alter the stub above, if needed.
                alertFailureCount+=0;
            }
        }

        private static float cToF(float f) { return (f - 32) * 5 / 9; }

        static void Main(string[] args) {
            // Change the sensor stub if need be to generate temperature within and out of range
            alertInCelcius(SensorStub.GetTemperature());
            Debug.Assert(alertFailureCount == 0);

            alertInCelcius(SensorStub.randomTemperature(tempThresholdInC+10, tempThresholdInC));
            Debug.Assert(alertFailureCount > 0);

            Console.WriteLine("{0} alerts failed.", alertFailureCount);
            Console.WriteLine("All is well (maybe!)\n");
        }
    }
}
