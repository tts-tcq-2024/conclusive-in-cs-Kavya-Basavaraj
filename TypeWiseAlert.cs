using System;
using System.Collections.Generic;

public class TypeWiseAlert
{
    public enum BreachType
    {
        NORMAL,
        TOO_LOW,
        TOO_HIGH
    }

   


    public interface IAlertSender
    {
        void Send(BreachType breachType);
    }

    public class ControllerAlert : IAlertSender
    {
        public void Send(BreachType breachType)
        {
            const ushort header = 0xfeed;
            Console.WriteLine($"{header} : {breachType}\n");
        }
    }

    public class EmailAlert : IAlertSender
    {
        private readonly string recepient = "a.b@c.com";

        public void Send(BreachType breachType)
        {
            if (breachType == BreachType.NORMAL)
            {
                return;
            }

            Console.WriteLine($"To: {recepient}\n");
            string message = breachType == BreachType.TOO_LOW
                ? "Hi, the temperature is too low\n"
                : "Hi, the temperature is too high\n";

            Console.WriteLine(message);
        }
    }

    public static BreachType InferBreach(double value, double lowerLimit, double upperLimit)
    {
        if (value < lowerLimit)
        {
            return BreachType.TOO_LOW;
        }
        if (value > upperLimit)
        {
            return BreachType.TOO_HIGH;
        }
        return BreachType.NORMAL;
    }

  

}
