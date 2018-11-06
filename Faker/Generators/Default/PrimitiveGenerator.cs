using System;

namespace Faker.Generators.Default
{
    public abstract class PrimitiveGenerator : IGenerator
    {
        public abstract Type GeneratedType { get; }
        protected Random _random;

        protected virtual object DefaultValue => Activator.CreateInstance(GeneratedType);
        protected virtual object MinValue => GeneratedType.GetField("MinValue").GetValue(null);
        protected virtual object MaxValue => GeneratedType.GetField("MaxValue").GetValue(null);

        protected PrimitiveGenerator()
        {
            _random = new Random();
        }

        public object Generate()
        {
            return Convert.ChangeType(GenerateValue(), GeneratedType);
        }

        protected virtual object GenerateValue()
        {
            if (DefaultValue == MinValue) return GenerateAfterDefaultValue();
            if (DefaultValue == MaxValue) return GenerateBeforeDefaultValue();
            
            return _random.Next(0, 1) == 1 ? GenerateBeforeDefaultValue() : GenerateAfterDefaultValue();
        }
        
        protected virtual object GenerateBeforeDefaultValue()
        {
            return _random.Next((int) MinValue, (int) DefaultValue - 1);
        }
        
        protected virtual object GenerateAfterDefaultValue()
        {
            return _random.Next((int) DefaultValue + 1, (int) MaxValue);
        }
    }
}