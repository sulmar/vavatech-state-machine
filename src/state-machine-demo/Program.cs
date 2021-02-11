using Stateless;
using System;

namespace state_machine_demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello State Machine Demo!");

            TrafficLight trafficLight = new TrafficLight();

            Console.WriteLine(trafficLight.Graph);

            trafficLight.Dump();

            trafficLight.Push();

            trafficLight.Dump();

            trafficLight.Break();

            trafficLight.Dump();

            trafficLight.Push();

            trafficLight.Dump();

            trafficLight.Push();

            trafficLight.Dump();

            trafficLight.Push();
            trafficLight.Dump();

            Console.WriteLine("Press Enter to exit.");
            Console.ReadLine();
        }
    }

    public static class TrafficLightExtensions
    {
        static ConsoleColor[] colors = { ConsoleColor.Green, ConsoleColor.Red, ConsoleColor.Yellow, ConsoleColor.Blue };

        public static void Dump(this TrafficLight trafficLight)
        {
            Console.ForegroundColor = colors[(int)trafficLight.State];
            Console.WriteLine(trafficLight.State);
            Console.ResetColor();
        }
    }



    // dotnet add package Stateless

    public class TrafficLight
    {
        // public TrafficLightState State { get; set; }

        public TrafficLightState State => machine.State;


        public string Graph => Stateless.Graph.UmlDotGraph.Format(machine.GetInfo());



        private readonly StateMachine<TrafficLightState, TrafficLightTrigger> machine;

        private System.Timers.Timer timer;

        public TrafficLight()
        {
            machine = new StateMachine<TrafficLightState, TrafficLightTrigger>(TrafficLightState.Green);

            machine.Configure(TrafficLightState.Green)
                .OnEntry(() => Console.WriteLine("<xml><color>green</color></xml>"))
                .Permit(TrafficLightTrigger.Push, TrafficLightState.Yellow)
                .Permit(TrafficLightTrigger.Break, TrafficLightState.Blinking);

            machine.Configure(TrafficLightState.Yellow)
                .OnEntry(() => Console.WriteLine("<xml><color>yellow</color></xml>"))
                .OnEntry(() => timer.Start())
                .OnEntry(()=>timer.Stop())
                .Permit(TrafficLightTrigger.Push, TrafficLightState.Red)
                .Permit(TrafficLightTrigger.Break, TrafficLightState.Blinking);

            machine.Configure(TrafficLightState.Red)
                .OnEntry(() => Console.WriteLine("<xml><color>red</color></xml>"))
                .Permit(TrafficLightTrigger.Push, TrafficLightState.Green)
                .Permit(TrafficLightTrigger.Break, TrafficLightState.Blinking);

            machine.Configure(TrafficLightState.Blinking)
                .Permit(TrafficLightTrigger.Push, TrafficLightState.Red);

            timer = new System.Timers.Timer(TimeSpan.FromSeconds(5).TotalMilliseconds);
            timer.AutoReset = false;
            timer.Elapsed += Timer_Elapsed;

        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            machine.Fire(TrafficLightTrigger.ElapsedTime);
        }

        public void Push() => machine.Fire(TrafficLightTrigger.Push);

        public void Break() => machine.Fire(TrafficLightTrigger.Break);

        public bool CanPush => machine.CanFire(TrafficLightTrigger.Push);

    }

    public enum TrafficLightState
    {        
        Green,
        Red,
        Yellow,
        Blinking
    }

    public enum TrafficLightTrigger
    {
        Push,

        Break,

        ElapsedTime
    }

}
