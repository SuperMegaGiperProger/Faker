using System;
using System.Collections.Generic;
using System.Linq;
using Faker.Generators.Default;

namespace Faker.Generators
{
    public class Builder
    {
        private Dictionary<Type, IGenerator> _generators;

        public Builder(IEnumerable<string> paths = null)
        {
            _generators = this.GetGenerators().ToDictionary(generator => generator.GeneratedType);

            if (paths != null) LoadFromPaths(paths);
        }

        public IGenerator Get(Type type)
        {
            var exists = _generators.TryGetValue(type, out var generator);
            return exists ? generator : new NullGenerator();
        }

        private void LoadFromPaths(IEnumerable<string> paths)
        {
            foreach (var path in paths)
            {
                var pathGenerators = Loader.GetGeneratorsDict(path);
                
                _generators = _generators.Union(pathGenerators).ToDictionary(pair => pair.Key, pair => pair.Value);
            }
        }
    }
}