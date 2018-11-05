using System.IO;
using YamlDotNet.RepresentationModel;

namespace Faker.Concerns
{
    public class Config
    {
        private YamlMappingNode rootNode;

        public Config(string path)
        {
            var input = new StringReader(File.ReadAllText(path));
            var yaml = new YamlStream();
            yaml.Load(input);

            rootNode = (YamlMappingNode) yaml.Documents[0].RootNode;
        }

        public string GetValue(string[] keySequence)
        {
            if (keySequence.Length < 1) return rootNode.ToString();
            
            var node = rootNode;

            for (var i = 0; i < keySequence.Length - 1; ++i)
            {
                node = (YamlMappingNode) node.Children[new YamlScalarNode(keySequence[i])];
            }

            var lastNode = node.Children[new YamlScalarNode(keySequence[keySequence.Length - 1])];

            return lastNode.ToString();
        }
    }
}