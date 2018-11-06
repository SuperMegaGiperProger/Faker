using System;

namespace Faker.Generators
{
    public interface ICollectionGenerator : IGenerator
    {
        Type GetGeneratedType<T>();
        object Generate<T>();
    }
}