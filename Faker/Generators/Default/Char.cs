using System;

namespace Faker.Generators.Default
{
    public class Char : PrimitiveGenerator
    {
        public override Type GeneratedType => typeof(char);

        protected override object GenerateValue()
        {
            return _random.Next(char.MinValue, char.MaxValue);
        }
    }
}