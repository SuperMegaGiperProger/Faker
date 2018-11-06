using System;
using System.Linq;
using System.Reflection;

namespace Faker.Concerns
{
    public class DtoInitializer
    {
        private DtoInitController _controller;
        private Generators.Builder _generatorBuilder;

        public DtoInitializer(Type type, Generators.Builder generatorBuilder)
        {
            _generatorBuilder = generatorBuilder;
            _controller = new DtoInitController(type);
        }

        public object Create()
        {
            var constructor = _controller.Constructor();

            if (constructor == null) return null;
            
            var param = GetConstructorParameterValues(constructor);
            var obj = constructor.Invoke(param);

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
            var value = _generatorBuilder.Get(type).Generate();
            
            if (value == null && type.IsDto()) value = new DtoInitializer(type, _generatorBuilder).Create();

            return value;
        }
    }
}