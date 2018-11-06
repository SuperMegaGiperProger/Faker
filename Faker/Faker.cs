using Faker.Concerns;
using Faker.Generators;

namespace Faker
{
    public class Faker : IFaker
    {
        private Config _config;
        private Builder _generatorsBuilder;

        public Faker(string configPath)
        {
            _config = new Config(configPath);
            _generatorsBuilder = new Builder(new[] {_config.GetValue(new[] {"generators", "plugins", "path"})});
        }

        public T Create<T>() where T : class
        {
            if (!DtoChecker.IsDto(typeof(T))) return null;

            return null;
        }
    }
}