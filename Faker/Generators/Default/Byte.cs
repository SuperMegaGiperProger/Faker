using System;

namespace Faker.Generators.Default
{
    public class Byte : PrimitiveGenerator
    {
        public override Type GeneratedType => typeof(byte);

        protected override object GenerateValue()
        {
            return (byte) _random.Next(1, byte.MaxValue);
        }
    }
}