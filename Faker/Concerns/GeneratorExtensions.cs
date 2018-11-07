using System;
using System.Collections;
using Faker.Generators;

namespace Faker.Concerns
{
    public static class GeneratorExtensions
    {
        public static ICollection GenerateCollection(this IGenerator generator, Type collectionType)
        {
            return (generator as ICollectionGenerator)?.Generate(collectionType.GetGenericArguments()[0]);
        }
    }
}