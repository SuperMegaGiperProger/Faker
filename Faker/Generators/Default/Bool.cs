using System;

namespace Faker.Generators.Default
{
    public class Bool : IGenerator
    {
        public Type GeneratedType => typeof(bool);

        public object Generate()
        {
            return true;
        }
    }
}