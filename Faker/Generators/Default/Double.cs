using System;

namespace Faker.Generators.Default
{
    public class Double : PrimitiveGenerator
    {
        public override Type GeneratedType => typeof(double);

        protected override object GenerateValue()
        {
            return _random.NextDouble() * _random.Next();
        }
    }
}