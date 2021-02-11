using System;

namespace state_machine_demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello State Machine Demo!");

            TrafficLight trafficLight = new TrafficLight();

            trafficLight.Dump();

            trafficLight.Push();

            trafficLight.Dump();

            trafficLight.Push();

            trafficLight.Dump();

            trafficLight.Push();

            trafficLight.Dump();

            trafficLight.Push();


            Console.WriteLine("Press Enter to exit.");
            Console.ReadLine();
        }
    }

    public static class TrafficLightExtensions
    {
        static ConsoleColor[] colors = { ConsoleColor.Green, ConsoleColor.Red, ConsoleColor.Yellow };

        public static void Dump(this TrafficLight trafficLight)
        {
            Console.ForegroundColor = colors[(int)trafficLight.State];
            Console.WriteLine(trafficLight.State);
            Console.ResetColor();
        }
    }





    public class TrafficLight
    {
        public TrafficLightState State { get; set; }

        public void Push()
        {
           if (State == TrafficLightState.Red)
           {
               State = TrafficLightState.Green;
           }
           else
           if (State == TrafficLightState.Green)
           {
                State = TrafficLightState.Red;
           }
        }

    }

    public enum TrafficLightState
    {        
        Green,
        Red,
    }

}
