using System;
using Episode1.Models;

namespace Episode1
{
    class Program
    {
        static void Main(string[] args)
        {
//            Console.WriteLine("Hello World!");
//            Order order1 = new Order(1, 100);
//            User user = new User("email@email.com", "secret");

            /*Race race = new Race();
            race.Begin();*/

            /*Exceptions exceptions = new Exceptions();*/

//        var lambdaExpressions = new LambdaExpressions();
//        lambdaExpressions.Test();
//
//            var eventSandBox = new EventSandBox();
//            eventSandBox.Test();

/*            var test = "abc";
            if (test.NotEmpty())
            {
                Console.WriteLine("Hello");
            }*/

            /*var enumerations = new Enumerations();
            enumerations.test();*/

            var reflections = new Attributes();
            reflections.Test();
            
        }
    }
}