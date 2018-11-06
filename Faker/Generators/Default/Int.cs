using System;

namespace Faker.Generators.Default
{
    public class Int : PrimitiveGenerator
    {
        public override Type GeneratedType => typeof(int);

        protected override object GenerateValue()
        {
            return _random.Next(int.MinValue, int.MaxValue);
        }
    }
}