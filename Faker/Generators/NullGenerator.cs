using System;

namespace Faker.Generators
{
    public class NullGenerator : IGenerator
    {
        public Type GeneratedType => null;

        public object Generate()
        {
            return null;
        }
    }
}