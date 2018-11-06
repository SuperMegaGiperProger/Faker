using System;

namespace Faker.Generators
{
    public interface IGenerator
    {
        Type GeneratedType { get; }
        object Generate();
    }
}