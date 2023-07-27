using System;

namespace TemperatureSpace
{
    /// <summary>
    /// This is a Network stub. In real world this would be communicating with 
    /// different systems on network that handle an alert. 
    /// Example:
    /// - communicates with an alarming system that triggers a siren, 
    /// - communicates with the system that sendsout a radio distress/emergency/safety message 
    /// </summary>
    internal class NetworkStub
    {
        internal static int codeOk = 200;
        internal static int codeNotOk = 500;

        internal static int SendAlert(float celcius, float thresholdInC)
        {
            // Return code 200 when successful in alerting on network
            // Return code 500 for if failed in alerting on network
            if (isBreached(celcius, thresholdInC))
            {
                Console.WriteLine("ALERT: Temperature is {0} celcius, Threshold: {1} celcius",
                celcius, thresholdInC);
            }
            // stub code always returns success
            return codeOk;
        }

        private static bool isBreached(float temp, float threshold)
        {
            return temp > threshold;
        }
    }
}
