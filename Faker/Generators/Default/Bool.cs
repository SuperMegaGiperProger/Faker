using System;

namespace Faker.Generators.Default
{
    public class Bool : PrimitiveGenerator
    {
        public override Type GeneratedType => typeof(bool);

        protected override object GenerateValue()
        {
            return _random.NextDouble() >= 0.5;
        }
    }
}