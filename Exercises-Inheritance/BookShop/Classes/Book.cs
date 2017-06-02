using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Classes
{
    public class Book
    {
        private string author;
        private string title;
        private double price;

        public Book(String author, String title, double price)
        {
            this.SetAuthor(author);
            this.SetTitle(title);
            this.SetPrice(price);
        }

        public virtual string Author
        {
            get
            {
                return this.author;
            }
            protected set
            {
                string[] authorTokens = value.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (authorTokens.Length > 1)
                {
                    string lastName = authorTokens[1];
                    char firstChar = lastName.First();

                    if (Char.IsDigit(firstChar))
                    {
                        throw new ArgumentException("Author not valid!");
                    }
                }
                this.author = value;
            }
        }

        public virtual string Title
        {
            get
            {
                return this.title;
            }
            protected set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Title not valid!");
                }
                this.title = value;
            }
        }

        public virtual double Price
        {
            get
            {
                return this.price;
            }
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price not valid!");
                }
                this.price = value;
            }
        }

        private void SetPrice(double price)
        {
            this.Price = price;
        }

        private void SetTitle(string title)
        {
            this.Title = title;
        }

        private void SetAuthor(string author)
        {
            this.Author = author;
        }

        public override string ToString()
        {
           StringBuilder sb = new StringBuilder();
            sb.Append("Type: ").Append(this.GetType().Name)
                .Append(Environment.NewLine)
                .Append("Title: ").Append(this.Title)
                .Append(Environment.NewLine)
                .Append("Author: ").Append(this.Author)
                .Append(Environment.NewLine)
                .Append("Price: ").Append($"{this.Price:f1}")
                .Append(Environment.NewLine);

            return sb.ToString();
        }
    }
}
