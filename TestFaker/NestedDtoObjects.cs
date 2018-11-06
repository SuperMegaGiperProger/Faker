using TestFaker.TestObjects;
using Xunit;

namespace TestFaker
{
    class NestedDtoClassWithoutConstructor
    {
        public string StringField;
        public FlatDtoClassWithoutConstructor NestedObject;
    }
    
    public class NestedDtoObjects
    {
        [Fact]
        public void WithoutConstructorWithParameters()
        {
            var result = Concerns.TestHelpers.GetFaker().Create<NestedDtoClassWithoutConstructor>();
            
            Assert.IsType<NestedDtoClassWithoutConstructor>(result);
            Concerns.TestHelpers.AssertPublicFieldsNotEmpty(result);
            Concerns.TestHelpers.AssertPublicPropertiesNotEmpty(result);
            
            Assert.IsType<TestObjects.FlatDtoClassWithoutConstructor>(result.NestedObject);
            Concerns.TestHelpers.AssertPublicFieldsNotEmpty(result.NestedObject);
            Concerns.TestHelpers.AssertPublicPropertiesNotEmpty(result.NestedObject);
        }
    }
}