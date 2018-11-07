using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Faker.Concerns
{
    public class DtoInitializer
    {
        private Type _type;
        private DtoInitController _controller;
        private Generators.Builder _generatorBuilder;
        private ISet<Type> _previousTypes;

        public DtoInitializer(Type type, Generators.Builder generatorBuilder, ISet<Type> previousTypes = null)
        {
            _type = type;
            _previousTypes = previousTypes ?? new HashSet<Type>();
            _generatorBuilder = generatorBuilder;
            _controller = new DtoInitController(type);
        }

        public object Create()
        {
            _previousTypes.Add(_type);

            var obj = InitializeObject();

            _previousTypes.Remove(_type);

            return obj;
        }

        private object InitializeObject()
        {
            var constructor = _controller.Constructor();

            if (constructor == null) return null;

            var obj = constructor.Invoke(GetConstructorParameterValues(constructor));

            if (_controller.ToFillFields())
            {
                FillFields(obj);
                FillProperties(obj);
            }

            return obj;
        }

        private object[] GetConstructorParameterValues(ConstructorInfo constructor)
        {
            return constructor.GetParameters().Select(GenerateValue).ToArray();
        }

        private void FillFields(object obj)
        {
            foreach (var field in _controller.Fields())
            {
                var value = GenerateValue(field);
                if (value != null) field.SetValue(obj, value);
            }
        }

        private void FillProperties(object obj)
        {
            foreach (var property in _controller.Properties())
            {
                var value = GenerateValue(property);
                if (value != null) property.SetValue(obj, value);
            }
        }

        private object GenerateValue(ParameterInfo param)
        {
            return GenerateValue(param.ParameterType);
        }

        private object GenerateValue(FieldInfo field)
        {
            return GenerateValue(field.FieldType);
        }

        private object GenerateValue(PropertyInfo prop)
        {
            return GenerateValue(prop.PropertyType);
        }

        private object GenerateValue(Type type)
        {
            var value = type.IsCollection()
                ? _generatorBuilder.Get(type.GetGenericTypeDefinition()).GenerateCollection(type)
                : _generatorBuilder.Get(type).Generate();

            if (value == null && type.IsDto() && !_previousTypes.Contains(type))
            {
                value = new DtoInitializer(type, _generatorBuilder, _previousTypes).Create();
            }

            return value;
        }
    }
}