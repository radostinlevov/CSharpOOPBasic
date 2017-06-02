using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSpree.Models
{
    class Person
    {
        private string name;
        private decimal money;
        private List<Product> bagOfProducts;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            bagOfProducts = new List<Product>();
        }

        public List<Product> BagOfProducts {
            get
            {
                return this.bagOfProducts;
            }
            private set { this.bagOfProducts = value; }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"{nameof(this.Name)} cannot be empty");
                }
                this.name = value;
            }
        }

        public decimal Money
        {
            get
            {
                return this.money;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"{nameof(this.Money)} cannot be negative");
                }
                this.money = value;
            }
        }

        public void BuyProduct(Person person, Product product)
        {
            if (person.Money < product.Money)
            {
                throw new InvalidOperationException($"{person.Name} can't afford {product.Name}");
            }
            else
            {
                person.Money -= product.Money;
                BagOfProducts.Add(product);
            }
        }

        public override string ToString()
        {
            if (BagOfProducts.Count == 0)
            {
               return $"{this.Name} - Nothing bought";
            }
            else
            {
               return $"{this.Name} - {string.Join(", ", this.BagOfProducts.Select(p => p.Name))}";
            }
        }
    }
}

