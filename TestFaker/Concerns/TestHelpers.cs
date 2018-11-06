using System.Reflection;
using Xunit;

namespace TestFaker.Concerns
{
    public static class TestHelpers
    {
        public static Faker.Faker GetFaker()
        {
            return new Faker.Faker("../../../config.yml");
        }
        
        public static void AssertPublicPropertiesNotEmpty<T>(T result)
        {
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var property in properties)
            {
                if (property.CanWrite && property.CanRead) Assert.NotNull(property.GetValue(result));
            }
        }

        public static void AssertPublicFieldsNotEmpty<T>(T result)
        {
            var fields = typeof(T).GetFields(BindingFlags.Public | BindingFlags.Instance);

            foreach (var field in fields)
            {
                Assert.NotNull(field.GetValue(result));
            }
        }

        public static void AssertNotEmptyPublicPropertyExists<T>(T obj)
        {
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            
            if (properties.Length > 0) Assert.Contains(properties, prop => prop.GetValue(obj) != null);
        }

        public static void AssertNotEmptyPublicFieldsExists<T>(T obj)
        {
            var fields = typeof(T).GetFields(BindingFlags.Public | BindingFlags.Instance);
            
            if (fields.Length > 0) Assert.Contains(fields, field => field.GetValue(obj) != null);
        }
    }
}