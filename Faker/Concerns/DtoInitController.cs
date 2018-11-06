using System;
using System.Reflection;
using MoreLinq;

namespace Faker.Concerns
{
    public class DtoInitController
    {
        private Type _type;

        public DtoInitController(Type type) => _type = type;

        public bool ToFillFields()
        {
            return !_type.HasPublicConstructorWithArguments();
        }

        public ConstructorInfo Constructor()
        {
            return ToFillFields()
                ? _type.GetConstructor(Type.EmptyTypes)
                : _type.GetConstructors().MaxBy(constructor => constructor.GetParameters().Length).First();
        }

        public FieldInfo[] Fields()
        {
            return _type.PublicFields();
        }

        public PropertyInfo[] Properties()
        {
            return _type.WritableProperties();
        }
    }
}