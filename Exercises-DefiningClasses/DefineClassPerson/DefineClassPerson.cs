using System;
using System.Reflection;

namespace DefineClassPerson
{
    public class Person
    {
        public string name;
        public int age;
    }
    public class DefineClass
    {
        public static void Main()
        {
            Type personType = typeof(Person);
            FieldInfo[] fields = personType.GetFields(BindingFlags.Public | BindingFlags.Instance);
            Console.WriteLine(fields.Length);
        }
    }
}