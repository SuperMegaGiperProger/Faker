using System;
using System.Linq;
using System.Reflection;

namespace Faker.Concerns
{
    public static class TypeExtensions
    {
        public static bool IsDto(this Type type)
        {
            return !type.IsPrimitive && (
                       type.HasPublicFields() ||
                       type.HasAccessibleProperties() ||
                       (type.HasReadableProperties() && type.HasPublicConstructorWithArguments())
                   );
        }

        public static bool HasPublicFields(this Type type)
        {
            return type.PublicFields().Length > 0;
        }

        public static FieldInfo[] PublicFields(this Type type)
        {
            return type.GetFields(BindingFlags.Public | BindingFlags.Instance);
        }

        public static bool HasAccessibleProperties(this Type type)
        {
            bool Match(PropertyInfo property) =>
                property.CanWrite && property.GetSetMethod() != null && property.CanRead;

            return Array.Exists(type.PublicProperties(), Match);
        }

        public static bool HasReadableProperties(this Type type)
        {
            return Array.Exists(type.PublicProperties(), property => property.CanRead);
        }

        public static PropertyInfo[] WritableProperties(this Type type)
        {
            return type.PublicProperties().Where(prop => prop.CanWrite).ToArray();
        }

        public static PropertyInfo[] PublicProperties(this Type type)
        {
            return type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
        }

        public static bool HasPublicConstructorWithArguments(this Type type)
        {
            return Array.Exists(type.PublicConstructors(), constructor => constructor.GetParameters().Length > 0);
        }

        public static ConstructorInfo[] PublicConstructors(this Type type)
        {
            return type.GetConstructors(BindingFlags.Public | BindingFlags.Instance);
        }
    }
}