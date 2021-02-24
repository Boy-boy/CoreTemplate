using System;
using Core.Ddd.Domain.Entities;
using Demo.Domain.Events;

namespace Demo.Domain.Entities
{
    public class Students : AggregateRoot<string>
    {
        public Students(string name, int age)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
            Age = age;
            AddEvent(new StudentAddEvent());
        }
        public string Name { get; protected set; }

        public int Age { get; protected set; }
    }
}
