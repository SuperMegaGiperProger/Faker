using System;
using System.Reflection;

namespace Faker.Concerns
{
    public class DtoChecker
    {
        private Type _type;

        public DtoChecker(Type type) => _type = type;

        public bool IsDto()
        {
            return HasPublicFields() || HasAccessibleProperties() ||
                   (HasReadableProperties() && HasPublicConstructorWithArguments());
        }

        private bool HasPublicFields()
        {
            return _type.GetFields(BindingFlags.Public | BindingFlags.Instance).Length > 0;
        }

        private bool HasAccessibleProperties()
        {
            bool Match(PropertyInfo property) =>
                property.CanWrite && property.GetSetMethod() != null && property.CanRead;

            return Array.Exists(PublicProperties(), Match);
        }

        private bool HasReadableProperties()
        {
            return Array.Exists(PublicProperties(), property => property.CanRead);
        }

        private PropertyInfo[] PublicProperties()
        {
            return _type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
        }

        private bool HasPublicConstructorWithArguments()
        {
            return Array.Exists(PublicConstructors(), constructor => constructor.GetParameters().Length > 0);
        }

        private ConstructorInfo[] PublicConstructors()
        {
            return _type.GetConstructors(BindingFlags.Public | BindingFlags.Instance);
        }
    }
}