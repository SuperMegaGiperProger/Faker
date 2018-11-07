using System;
using System.Collections;
using System.Linq;
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

        public static void AssertValuesFilled<T>(T result, string[] excluded = null)
        {
            excluded = excluded ?? new string[] {};
            
            AssertPublicFieldsNotEmpty(result, excluded);
            AssertPublicPropertiesNotEmpty(result, excluded);
            AssertPublicFieldsNotDefault(result);
            AssertPublicPropertiesNotDefault(result);
        }
        
        public static void AssertPublicPropertiesNotEmpty<T>(T result, string[] excludedProperties)
        {
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var property in properties)
            {
                if (!excludedProperties.Contains(property.Name) && property.CanWrite && property.CanRead)
                {
                    Assert.NotNull(property.GetValue(result));
                }
            }
        }

        public static void AssertPublicFieldsNotEmpty<T>(T result, string[] excludedFields)
        {
            var fields = typeof(T).GetFields(BindingFlags.Public | BindingFlags.Instance);

            foreach (var field in fields)
            {
                if(!excludedFields.Contains(field.Name)) Assert.NotNull(field.GetValue(result));
            }
        }
        
        public static void AssertPublicPropertiesNotDefault<T>(T result)
        {
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var property in properties)
            {
                if (!property.CanWrite || !property.CanRead) continue;
                
                var type = property.PropertyType;
                var value = property.GetValue(result);
                
                if (type.IsPrimitive) Assert.NotEqual(DefaultValue(type), value);
                
                if (typeof(ICollection).IsAssignableFrom(type)) AssertCollectionFilled(value as ICollection);
            }
        }

        public static void AssertPublicFieldsNotDefault<T>(T result)
        {
            var fields = typeof(T).GetFields(BindingFlags.Public | BindingFlags.Instance);

            foreach (var field in fields)
            {
                var type = field.FieldType;
                var value = field.GetValue(result);
                
                if (type.IsPrimitive) Assert.NotEqual(DefaultValue(type), value);
                
                if (typeof(ICollection).IsAssignableFrom(type)) AssertCollectionFilled(value as ICollection);
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

        public static void AssertCollectionFilled(ICollection collection)
        {
            Assert.True(collection.Count > 0);
            
            foreach (var item in collection)
            {
                var type = item.GetType();
                
                if (type.IsPrimitive) Assert.NotEqual(DefaultValue(type), item);
            }
        }

        public static object DefaultValue(Type type)
        {
            return type.IsPrimitive ? Activator.CreateInstance(type) : null;
        }
    }
}