using System;
using Faker.Generators.Default;

namespace GeneratorPlugins
{
    public class Float : PrimitiveGenerator
    {
        public override Type GeneratedType => typeof(float);

        protected override object GenerateValue()
        {
            return _random.NextDouble() * _random.Next();
        }
    }
}