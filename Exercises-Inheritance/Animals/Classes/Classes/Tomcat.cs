using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals.Classes.Classes
{
    public class Tomcat : Cat
    {
        public Tomcat(string name, int age) : base(name, age)
        {
            base.Gender = "Male";
        }

        public override string ProduceSound()
        {
            return "Give me one million b***h";
        }
    }
}
