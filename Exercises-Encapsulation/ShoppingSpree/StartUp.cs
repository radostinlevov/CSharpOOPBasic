using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingSpree.Models;

namespace ShoppingSpree
{
    class StartUp
    {
        static void Main()
        {
            var people = new Dictionary<string, Person>();
            var products = new Dictionary<string, Product>();

            try
            {
                string[] allPeople = Console.ReadLine().Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var human in allPeople)
                {
                    string[] humanInfo = human.Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                    string name = humanInfo[0];
                    decimal money = decimal.Parse(humanInfo[1]);

                    Person person = new Person(name, money);
                    people.Add(name, person);
                }


                string[] allProducts = Console.ReadLine().Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var making in allProducts)
                {
                    string[] makingInfo = making.Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                    string name = makingInfo[0];
                    decimal cost = decimal.Parse(makingInfo[1]);

                    Product product = new Product(name, cost);
                    products.Add(name, product);
                }
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
                return;
            }

            string line = Console.ReadLine();

            while (line != "END")
            {
                string[] lineTokens = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string personName = lineTokens[0];
                string productName = lineTokens[1];

                Person currentPerson = people[personName];
                Product currentProduct = products[productName];

                try
                {
                    currentPerson.BuyProduct(currentPerson, currentProduct);
                    Console.WriteLine($"{personName} bought {productName}");
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }

                line = Console.ReadLine();
            }

          people.Values.ToList().ForEach(p => Console.WriteLine(p));
        }
    }
}
