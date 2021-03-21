using System;
using System.Reflection;

namespace BasicReflection
{
    class Program
    {
        const string TITLE_SEPARATOR = "=================================================\n\n";
        const string ACTION_SEPARATOR = "-------------------------------------------------\n";
        static void Main(string[] args)
        {
            Assembly actualAssembly = Assembly.GetExecutingAssembly();
            Console.WriteLine($"Program's informations\n{TITLE_SEPARATOR}");
            Console.WriteLine($"Assembly Fullname: {actualAssembly.FullName}");

            Console.WriteLine($"\nList of Defined Types found in this program:\n{TITLE_SEPARATOR}");
            foreach (TypeInfo t in actualAssembly.DefinedTypes)
            {
                Console.WriteLine($"\nType: {t.Name}\n{ACTION_SEPARATOR}");
                foreach (var m in t.DeclaredMembers)
                {
                    Console.WriteLine($"\t{m.MemberType} : {m.Name}");
                    if (m.MemberType == MemberTypes.Method)
                    {
                        MethodInfo mInfo = t.GetMethod(m.Name);
                        if (mInfo != null)
                        {
                            var allParams = mInfo.GetParameters();
                            if (allParams.Length <= 0)
                            {
                                Console.WriteLine($"\t - Params: <none>");
                            }
                            else
                            {

                                Console.WriteLine($"\t - Params:");
                                foreach (var p in allParams)
                                {
                                    Console.WriteLine($"\t\t{p.Name} ({p.GetType()})");
                                }
                            }
                        }
                    }
                }
            }

        }
    }
}
