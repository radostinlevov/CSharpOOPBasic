using System;

namespace Animals.Classes.Classes
{
    public abstract class Animal
    {
        private string name;
        private int age;
        private string gender;
        
        protected Animal(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        protected Animal(string name, int age, string gender) : this(name, age)
        {
            this.Gender = gender;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            protected set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid input!");
                }
                this.name = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }
            protected set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Invalid input!");
                }
                this.age = value;
            }
        }

        public string Gender
        {
            get
            {
                return this.gender;
            }
            protected set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid input!");
                }
                this.gender = value;
            }
        }

        public abstract string ProduceSound();
    }
}
