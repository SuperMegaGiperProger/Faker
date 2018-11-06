using System;
using System.Collections.Generic;

namespace Faker.Generators.Default
{
    public class ListGen : ICollectionGenerator
    {
        public Type GeneratedType => typeof(List<object>);
        public Type GetGeneratedType<T>() => typeof(List<T>);

        private Generators.Builder _generatorsBuilder;
        private Random _random;

        private const int MIN_LENGTH = 3;
        private const int MAX_LENGTH = 10;

        public ListGen(Generators.Builder builder)
        {
            _generatorsBuilder = builder;
            _random = new Random();
        }
        
        public object Generate() => new List<object>();

        public object Generate<T>()
        {
            var length = _random.Next(MIN_LENGTH, MAX_LENGTH);
            var generator = _generatorsBuilder.Get(typeof(T));

            var result = new List<T>();

            for (var i = 0; i < length; ++i)
            {
                result.Add((T) generator.Generate());
            }
            
            return result;
        }
    }
}