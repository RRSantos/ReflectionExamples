using System;
using System.Reflection;
using System.Collections.Generic;

namespace Logging
{
    class Program
    {
        static string getObjectPropertiesAndValues(object o)
        {
            PropertyInfo[] propsInfo = o.GetType().GetProperties();
            List<string> allProps = new List<string>();
            foreach (PropertyInfo pInfo in propsInfo)
            {
                allProps.Add($" {pInfo.Name}:{pInfo.GetValue(o)} ");
            }
            string result = "{" + String.Join(',', allProps) + "}";
            return result;
        }

        static void Log(object o)
        {
            string actualDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string logData = getObjectPropertiesAndValues(o);
            Console.WriteLine($"[{actualDateTime}]Log: {logData}");
        }

        static void Main(string[] args)
        {
            Person p1 = new Person(1, "Richard", new DateTime(1995, 06, 21));
            Person p2 = new Person(7, "Lory", new DateTime(2006, 04, 18));

            Vehicle v1 = new Vehicle(4, "Peugeot", 2012);
            Vehicle v2 = new Vehicle(2, "Honda", 2017);

            Console.WriteLine("Logging Person:\n---------------------------------");
            Log(p1);
            Log(p2);
            Console.WriteLine("Logging Vehicle:\n---------------------------------");
            Log(v1);
            Log(v2);
        }
    }
}
