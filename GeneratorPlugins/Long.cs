using System;
using Faker.Generators.Default;

namespace GeneratorPlugins
{
    public class Long : PrimitiveGenerator
    {
        public override Type GeneratedType => typeof(long);

        private const double MIN_MODULE = 0.000001;
        
        protected override object GenerateBeforeDefaultValue()
        {
            return (long) ((_random.NextDouble() + MIN_MODULE) * long.MinValue);
        }
        
        protected override object GenerateAfterDefaultValue()
        {
            return (long) ((_random.NextDouble() + MIN_MODULE) * long.MaxValue);
        }
    }
}