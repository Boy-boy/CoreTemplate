﻿using Core.Ddd.Domain.Entities;
using System.Diagnostics.Contracts;

namespace Demo.Domain.Entities
{
    public class Students : AggregateRoot<string>
    {
        public Students(string name, int age)
        {
            Name = name;
            Age = age;
            AddEvent(new Core.Ddd.Domain.Events.AggregateRootEvent { });


        }
        public string Name { get; protected set; }

        public int Age { get; protected set; }


    }
}