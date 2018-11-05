using Faker.Concerns;

namespace Faker
{
    public class Faker : IFaker
    {
        private Config _config;

        public Faker(string configPath)
        {
            _config = new Config(configPath);
        }

        public T Create<T>() where T : class
        {
            if (!Concerns.DtoChecker.IsDto(typeof(T))) return null;
            
            return null;
        }
    }
}