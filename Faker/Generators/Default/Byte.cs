using System;

namespace Faker.Generators.Default
{
    public class Byte : PrimitiveGenerator
    {
        public override Type GeneratedType => typeof(byte);

        protected override object GenerateValue()
        {
            return _random.Next(byte.MinValue, byte.MaxValue);
        }
    }
}