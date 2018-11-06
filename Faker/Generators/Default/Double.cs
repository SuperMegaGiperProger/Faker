using System;

namespace Faker.Generators.Default
{
    public class Double : PrimitiveGenerator
    {
        public override Type GeneratedType => typeof(double);
        
        private const double MIN_MODULE = 0.000001;

        protected override object GenerateValue()
        {
            var sign = _random.Next(0, 1) == 1 ? 1 : -1;
            var positiveIntValue = _random.Next(1, int.MaxValue);
            var doublePart = _random.NextDouble() + MIN_MODULE;
            
            return sign * positiveIntValue * doublePart;
        }
    }
}