using System.Reflection;
using Xunit;

namespace TestFaker
{
    public class FlatDtoObjects
    {
        [Fact]
        public void WithConstructorWithParameters()
        {
            var result = Concerns.TestHelpers.GetFaker().Create<TestObjects.FlatDtoClassWithConstructorWithParameters>();

            Assert.IsType<TestObjects.FlatDtoClassWithConstructorWithParameters>(result);
        }

        [Fact]
        public void WithoutConstructorWithParameters()
        {
            var result = Concerns.TestHelpers.GetFaker().Create<TestObjects.FlatDtoClassWithoutConstructor>();

            Assert.IsType<TestObjects.FlatDtoClassWithoutConstructor>(result);
            Concerns.TestHelpers.AssertPublicFieldsNotEmpty(result);
            Concerns.TestHelpers.AssertPublicPropertiesNotEmpty(result);
        }
    }
}