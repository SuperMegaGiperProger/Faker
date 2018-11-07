using System;
using System.Collections;

namespace Faker.Generators
{
    public interface ICollectionGenerator : IGenerator
    {
        ICollection Generate(Type type);
    }
}