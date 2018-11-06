using System;

namespace Faker.Generators.Default
{
    public class Char : PrimitiveGenerator
    {
        public override Type GeneratedType => typeof(char);

        protected override object GenerateValue()
        {
            return (char) _random.Next(1, char.MaxValue);
        }
    }
}