using System;
using Faker.Generators.Default;

namespace GeneratorPlugins
{
    public class Long : PrimitiveGenerator
    {
        public override Type GeneratedType => typeof(long);

        protected override object GenerateValue()
        {
            return (_random.NextDouble() * 2.0 - 1.0) * long.MaxValue;
        }
    }
}