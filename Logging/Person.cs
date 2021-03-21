using System;

namespace Logging
{
    class Person
    {
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
