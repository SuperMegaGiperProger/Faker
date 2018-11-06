using System;

namespace Faker.Generators.Default
{
    public class DateTimeGen : PrimitiveGenerator
    {
        public override Type GeneratedType => typeof(DateTime);

        private const int RANGE = 5 * 365;

        protected override object GenerateValue()
        {
            return DateTime.Today.AddDays(_random.Next(-RANGE, RANGE));
        }
    }
}