using System;
using System.Collections.Generic;
using System.Linq;

namespace Episode1.Models
{
    public class Enumerations
    {
        public void test()
        {

            var items = GetItems();
            var tools = items.Where(x => x.Category == "Tools");

/*            var toolsQuery = from tool in tools
                where tool.Category == "Tools"
                select tool;*/
            var numbers = Enumerable.Range(1, 10);
            var max = numbers.Max();
            var sum = numbers.Sum();
            var axe = tools.First(x => x.Name == "Axe");
            var totalPriceOfTools = tools.Sum(x => x.Price);
            var food = items.Where(x => x.Category == "Food");
            var foodAndTools = tools.Union(food);

            var query = items.Where(x => x.CreatedAt >= DateTime.UtcNow.AddDays(-10))
                .Where(x => x.Price > 300)
                .Skip(1)
                .Take(2)
                .OrderBy(x => x.Price)
                .Select(x => new {x.Name, x.Price});

            var groupedItems = items.GroupBy(x => x.Category);
            var dictionary = query.ToDictionary(x => x.Name, x => x.Price);


        }
        




        public IEnumerable<Item> GetItems()
        {
            yield return new Item("Axe", "Tools", 250, DateTime.UtcNow.AddDays(-15));
            yield return new Item("Axe", "Tools", 300, DateTime.UtcNow.AddDays(-10));
            yield return new Item("Ball", "Sport", 60, DateTime.UtcNow.AddDays(-7));
            yield return new Item("Monitor", "Electronics", 800, DateTime.UtcNow.AddDays(-20));
            yield return new Item("Car", "Vehicle", 20000, DateTime.UtcNow.AddDays(-5));
            yield return new Item("Bike", "Vehicle", 1500, DateTime.UtcNow.AddDays(-10));
            yield return new Item("Notebook", "Electronics", 3000, DateTime.UtcNow.AddDays(-1));
            yield return new Item("Mouse", "Animal", 200, DateTime.UtcNow.AddDays(-5));
            yield return new Item("Pizza", "Food", 40, DateTime.UtcNow.AddDays(-2));
            yield return new Item("Dog", "Animal", 1000, DateTime.UtcNow.AddDays(-3));
            yield return new Item("Burger", "Food", 30, DateTime.UtcNow.AddDays(-5));
        }
    }

    public class Item
    {        
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public string Category { get; protected set; }
        public decimal Price { get;protected set; }
        public DateTime CreatedAt { get; protected set; }

        public Item(string name, string category, decimal price, DateTime createdAt)
        {
            Id = Guid.NewGuid();
            Name = name;
            Category = category;
            Price = price;
            CreatedAt = createdAt;
        }
    }
}