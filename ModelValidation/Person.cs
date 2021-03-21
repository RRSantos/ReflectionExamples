using System;

namespace ModelValidation
{
    class Person : BaseModel
    {
        [StringValidator(RegexPattern: @"^[\D*\s*]+$", MinLength: 5, MaxLength: 20)]
        public string Name { get; private set; }

        public int Id { get; private set; }
        public DateTime BornIn { get; private set; }

        public Person(int id, string name, DateTime bornIn)
        {
            Id = id;
            Name = name;
            BornIn = bornIn;
        }
    }
}
