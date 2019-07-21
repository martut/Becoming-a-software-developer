using System;
using System.Collections.Generic;
using System.Linq;

namespace Episode1.Models
{
    public class Enumerations
    {
        public void test()
        {
            var numbersList = Enumerable.Range(1, 100).ToList();
            IEnumerable<int> Numbers = GetNumbers();
            foreach (var number in Numbers)
            {
                Console.WriteLine(number);
            }
        }

        public IEnumerable<int> GetNumbers()
        {
            yield return 1;
            yield return 2;
            yield return 3;
            yield return 4;
            yield return 5;
        }
        
    }
}