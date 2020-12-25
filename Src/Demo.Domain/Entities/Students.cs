using Core.Ddd.Domain.Entities;

namespace Demo.Domain.Entities
{
    public class Students : AggregateRoot<string>
    {
        public Students(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public string Name { get; protected set; }

        public int Age { get; protected set; }


    }
}
