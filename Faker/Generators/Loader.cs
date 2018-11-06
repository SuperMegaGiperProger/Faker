using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Faker.Generators
{
    public class Loader
    {
        public static Dictionary<Type, IGenerator> GetGeneratorsDict(string path)
        {
            var loader = new Loader(path);
            loader.Load();
            return loader.GetGeneratorsDictionary();
        }
        
        private string _path;
        private IEnumerable<IGenerator> Generators;

        public Loader(string path) => _path = path;

        public void Load()
        {
            Generators = GetGenerators();
        }

        public Dictionary<Type, IGenerator> GetGeneratorsDictionary()
        {
            return Generators.ToDictionary(generator => generator.GeneratedType);
        }

        public IEnumerable<IGenerator> GetGenerators()
        {
            var generatorTypes = GetGeneratorTypes();
            
            return generatorTypes.Select(type => Activator.CreateInstance(type) as IGenerator);
        }

        private string[] GetDllFilePaths()
        {
            return Directory.Exists(_path) ? Directory.GetFiles(_path, "*.dll") : new string[] { };
        }

        private IEnumerable<Assembly> GetAssemblies()
        {
            var dllFilePaths = GetDllFilePaths();

            ICollection<Assembly> assemblies = new List<Assembly>(dllFilePaths.Length);
            foreach (var dllFilePath in dllFilePaths)
            {
                assemblies.Add(Assembly.LoadFile(dllFilePath));
            }

            return assemblies;
        }

        private IEnumerable<Type> GetGeneratorTypes()
        {
            var assemblies = GetAssemblies();
            var generatorInterface = typeof(IGenerator);

            var generatorTypes = new List<Type>();
            foreach (var assembly in assemblies)
            {
                if (assembly == null) continue;

                bool IsGenerator(Type type) => !type.IsInterface && !type.IsAbstract &&
                                               type.GetInterface(generatorInterface.FullName) != null;

                var generatorTypesInAssembly = assembly.GetTypes().Where(IsGenerator);

                generatorTypes.AddRange(generatorTypesInAssembly);
            }

            return generatorTypes;
        }
    }
}