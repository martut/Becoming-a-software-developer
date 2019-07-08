using System;
using Episode1.Models;

namespace Episode1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Order order1 = new Order(1, 100);
            User user = new User("email@email.com", "secret");
        }
    }
}