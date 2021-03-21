using System;
using System.IO;
using System.Reflection;
using System.Linq;
using AssemblyInterface;

namespace LoadAssembly
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            string assemblyDir = Path.Combine(Directory.GetCurrentDirectory(), "Assembly");
            Console.WriteLine("LoadAssembly\n--------------------------------------------------");
            Console.WriteLine($"Finding assemblies in directory '{assemblyDir}' ...");
            if (!Directory.Exists(assemblyDir))
            {

                Console.WriteLine($"Directory '{assemblyDir}' not found!\nExiting application...");
            }
            else
            {

                string[] assembliesFound = Directory.GetFiles(assemblyDir, "*.dll");
                if (assembliesFound.Length <= 0)
                {
                    Console.WriteLine("\tNo assemblies found!");
                }
                else
                {
                    string assemblyName = assembliesFound[0];
                    Console.WriteLine($"\tAssembly found: '{assemblyName}'.");
                    Assembly assembly = Assembly.LoadFile(assemblyName);
                    TypeInfo typeInfo = assembly.DefinedTypes
                        .FirstOrDefault(t => t.GetInterfaces()
                               .Any(i => i == typeof(IMyAssembly)));
                    if (typeInfo == null)
                    {
                        Console.WriteLine($"\tActual assembly does have any type that implements IMyAssembly interface.");
                    }
                    else
                    {

                        Console.WriteLine($"\tType that implements IMyAssembly interface found: {typeInfo.Name}");
                        IMyAssembly assemblyInstance = assembly.CreateInstance(typeInfo.FullName) as IMyAssembly;
                        string valueFromAssembly = assemblyInstance.GetValue();

                        Console.WriteLine($"\tType found in current assembly: '{typeInfo.Name}'.");
                        Console.WriteLine($"\tValue from assembly: '{valueFromAssembly}'.");
                    }
                }
            }
        }
    }
}
