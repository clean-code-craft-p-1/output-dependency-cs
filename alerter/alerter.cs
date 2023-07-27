using System;
using System.Diagnostics;

namespace TemperatureSpace {
    class Alerter {
        static int alertFailureCount = 0;
        static int tempThresholdInC = 280;

        static void alertInCelcius(float farenheit) {
            float celcius = FtoC(farenheit);

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

        private static float FtoC(float f) {
            return (f - 32) * 5 / 9;
        }

        static void Main(string[] args) {
            // Check if conversion is correct
            // change the test, if need be
            Debug.Assert(FtoC(33.8f) == 1f);

            // Change the sensor stub if need be to generate temperature within and out of range
            alertInCelcius(SensorStub.GetTemperature());
            Debug.Assert(alertFailureCount == 0);

            // Change the network stub if need be to test failed alert reporting
            alertInCelcius(SensorStub.randomTemperature(tempThresholdInC+10, tempThresholdInC));
            Debug.Assert(alertFailureCount > 0);

            Console.WriteLine("{0} alerts failed.", alertFailureCount);
            Console.WriteLine("All is well (maybe!)\n");
        }
    }
}
