using System;
using Faker.Generators.Default;

namespace GeneratorPlugins
{
    public class Float : PrimitiveGenerator
    {
        public override Type GeneratedType => typeof(float);
        
        private const double MIN_MODULE = 0.000001;

        protected override object GenerateValue()
        {
            var sign = _random.Next(0, 1) == 1 ? 1 : -1;
            var positiveIntValue = _random.Next(1, int.MaxValue);
            var floatPart = _random.NextDouble() + MIN_MODULE;
            
            return (float) (sign * positiveIntValue * floatPart);
        }
    }
}