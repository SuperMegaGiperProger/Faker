using System;

namespace Faker.Generators.Default
{
    public abstract class PrimitiveGenerator : IGenerator
    {
        public abstract Type GeneratedType { get; }
        protected Random _random;

        protected PrimitiveGenerator() => _random = new Random();

        public object Generate()
        {
            return Convert.ChangeType(GenerateValue(), GeneratedType);
        }

        protected abstract object GenerateValue();
    }
}