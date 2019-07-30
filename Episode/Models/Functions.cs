using System;
using System.Threading;

namespace Episode1.Models
{
    public class Delegates
    {
        public delegate void write(string message);

        public delegate int Add(int x, int y);

        public delegate void Alert(int change);
        

        public void Test()
        {
            write writer = WriteMessage;
            Add adder = AddTwoNumbers;
            writer("Marcin");
            var sum = adder(1, 2);
            Console.WriteLine(sum);
            CheckTemperature(TooLowAlert,OptimalAlert,TooHighAlert);
        }


        public static void CheckTemperature(Alert tooLow, Alert optimal, Alert tooHigh)
        {
            var temperature = 10;
            var random = new Random();
            while (true)
            {
                var change = random.Next(-5, 5);
                temperature += change;
                Console.WriteLine($"Temperature is at: {temperature} c.");

                if (temperature <= 0)
                {
                    tooLow(change);
                }
                else if (temperature > 0 && temperature <= 10)
                {
                    optimal(change);
                }
                else
                {
                    tooHigh(change);
                }
                Thread.Sleep(500);
            }
        }

        public static void TooLowAlert(int change)
        {
            Console.WriteLine($"Temperature is too low (changed by {change})");
        }       
        public static void OptimalAlert(int change)
        {
            Console.WriteLine($"Temperature is optimal (changed by {change})");
        }        
        public static void TooHighAlert(int change)
        {
            Console.WriteLine($"Temperature is too high (changed by {change})");
        }

        public static int AddTwoNumbers(int x, int y)
        {
            return x + y;
        }

        public static void WriteMessage(string mes)
        {
            Console.WriteLine($"Hello! {mes}");
        }
        
        
        
        
        
    }


    public class LambdaExpressions
    {

        
        public void Test()
        {
            Action writer = () => Console.WriteLine("writing ...");
            Action<string, int> advanceWriter = (message, number) => Console.WriteLine($"{message}, {number}");
            writer();

            Func<int, int, int> adder = (x, y) => x + y;

            var sum = adder(1, 2);
            
            advanceWriter("Hello", 5);
            advanceWriter("Hello", sum);

            Action<int, string> Logger = (temperauter, message) =>
            {
                Console.WriteLine($"Temperature is at: {temperauter} c. {message}");
            };
            
            CheckTemperature(t => Logger(t,"Too low!"), t=> Logger(t, "Optimal!"), t => Logger(t, "Too High!"));
        }
        
        public static void CheckTemperature(Action<int> tooLow, Action<int> optimal, Action<int> tooHigh)
        {
            var temperature = 10;
            var random = new Random();
            while (true)
            {
                var change = random.Next(-5, 5);
                temperature += change;
                Console.WriteLine($"Temperature is at: {temperature} c.");

                if (temperature <= 0)
                {
                    tooLow(temperature);
                }
                else if (temperature > 0 && temperature <= 10)
                {
                    optimal(temperature);
                }
                else
                {
                    tooHigh(temperature);
                }
                Thread.Sleep(500);
            }
        }
        
    }

    public class StatusEventArgs : EventArgs
    {
        public string Status { get; }

        public StatusEventArgs(string status)
        {
            Status = status;
        }
    }

    public class Events
    {
        public delegate void UpdateStatus(string status);

        //public event UpdateStatus StatusUpdated;

        public EventHandler<StatusEventArgs> StatusUpdatedAgain;
        
        public void StartUpdateingStatus()
        {
            while (true)
            {
                var message = $"status, ticks {DateTime.UtcNow.Ticks}";
                StatusUpdatedAgain?.Invoke(this, new StatusEventArgs(message));
                Thread.Sleep(500);
            }
        }
    }

    public class EventSandBox
    {
        public void Test()
        {
            var events = new Events();
            events.StatusUpdatedAgain += (sender, eventArgs) =>
            {
                Console.WriteLine( eventArgs.Status);
            };
            events.StartUpdateingStatus();
                    
            
        }


        public void DisplayStatus(string message)
        {
             Console.WriteLine(message);
        }
    }
}
