using System.Collections.Generic;

namespace Faker.Generators.Default
{
    public static class Builder
    {
        public static IEnumerable<IGenerator> GetGenerators(this Generators.Builder genBuilder)
        {
            return new IGenerator[]
            {
                new Int(),
                new Double(),
                new Bool(),
                new Byte(),
                new Char(),
                new String(),
                new DateTimeGen(),
                new ListGen(genBuilder),
            };
        }
    }
}