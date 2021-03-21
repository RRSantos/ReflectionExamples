using System;
using System.Collections.Generic;

namespace ModelValidation
{
    class Program
    {
        static void ValidateModel(string modelName, BaseModel model)
        {
            Console.WriteLine($"\n--- Begin of validation of model '{modelName}''");
            IReadOnlyCollection<string> errors = model.GetValidationErrors();
            if (errors.Count > 0)
            {
                Console.WriteLine("Your model is invalid.");
                foreach (string error in errors)
                {
                    Console.WriteLine($"Error: {error}");
                }
            }
            else
            {
                Console.WriteLine("Your model is valid!");
            }
            Console.WriteLine($"--- End of validation of model '{modelName}'\n");
        }

        static void Main(string[] args)
        {

            Person p1 = new Person(2, "Maria Eduarda", DateTime.Now);
            ValidateModel(p1.Name, p1);

            Person p2 = new Person(7, "Ana", DateTime.Now.AddYears(-16));
            ValidateModel(p2.Name, p2);

            Person p3 = new Person(13, "Anacleto 23 da Souza", DateTime.Now.AddYears(-10));
            ValidateModel(p3.Name, p3);

            Person p4 = new Person(19, "Roberto de Jesus Oliveira Nascimento Pereira da Silva", DateTime.Now.AddYears(-10));
            ValidateModel(p4.Name, p4);

            Vehicle v1 = new Vehicle(4, "Uno Mille", 2012);
            ValidateModel(v1.Model, v1);

            Vehicle v2 = new Vehicle(2, "Honda Bros", 1898);
            ValidateModel(v2.Model, v2);
        }
    }
}
