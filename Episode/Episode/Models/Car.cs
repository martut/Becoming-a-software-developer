using System;
using System.Collections.Generic;

namespace Episode1.Models
{
    public abstract class Car
    {
        public double Speed { get; protected set; } = 100;
        public double Acceleration { get; set; } = 10;
        

        public void Start()
        {
            Console.WriteLine("Turning on the engine.");
            Console.WriteLine($"Running at: {Speed.ToString()} km/h. ");
        }

        public void Stop()
        {
            Console.WriteLine("Stopping the car.");
        }

        public virtual void Accelerate()
        {
            Console.WriteLine("Accelerating ...");
            Speed += Acceleration;
            Console.WriteLine($"Running at: {Speed.ToString()} km/h. ");
            
        }

        public abstract void Boost();

    }


    public class Track : Car
    {
        public override void Accelerate()
        {
            Console.WriteLine("Accelerating a track car ...");
            base.Accelerate();
        }

        public override void Boost()
        {
            Console.WriteLine("Boosting a track car ...");
            Speed += 50;
            Console.WriteLine($"Running the track car at: {Speed.ToString()} km/h. ");
        }
    }
    
    public class SportCar : Car
    {
        public override void Accelerate()
        {
            Console.WriteLine("Accelerating a sport car ...");
            Speed += Acceleration;
            Console.WriteLine($"Running the sport car at: {Speed.ToString()} km/h. ");
        }

        public override void Boost()
        {
            Console.WriteLine("Boosting a sport car ...");
            Speed += 100;
            Console.WriteLine($"Running the sport car at: {Speed.ToString()} km/h. ");        }
    }

    public class Race 
    {
        public void Begin()
        {
            Track track = new Track();
            SportCar sportCar = new SportCar();
            
             List<Car> cars = new List<Car>
             {
                 sportCar,track
             };

             foreach (var car in cars)
             {
                 car.Start();
                 car.Accelerate();
                 car.Boost();
             }
        }
    }
}