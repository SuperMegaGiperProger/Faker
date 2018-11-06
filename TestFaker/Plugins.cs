using Xunit;

namespace TestFaker
{
    public class Plugins
    {
        [Fact]
        public void TestPresenceOfFloatPlugin()
        {
            var builder = new Faker.Generators.Builder(new[] {"../../../../Plugins"});
            var generator = builder.Get(typeof(float));
            
            Assert.Equal(typeof(float), generator.GeneratedType);
        }
        
        [Fact]
        public void TestPresenceOfLongPlugin()
        {
            var builder = new Faker.Generators.Builder(new[] {"../../../../Plugins"});
            var generator = builder.Get(typeof(long));
            
            Assert.Equal(typeof(long), generator.GeneratedType);
        }
    }
}