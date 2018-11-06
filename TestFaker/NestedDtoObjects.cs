using TestFaker.TestObjects;
using Xunit;

namespace TestFaker
{
    class NestedDtoClassWithoutConstructor : FlatDtoClassWithoutConstructor
    {
        public FlatDtoClassWithoutConstructor NestedObject;
    }
    
    public class NestedDtoObjects
    {
        [Fact]
        public void WithoutConstructorWithParameters()
        {
            var result = Concerns.TestHelpers.GetFaker().Create<NestedDtoClassWithoutConstructor>();
            
            Assert.IsType<NestedDtoClassWithoutConstructor>(result);
            Concerns.TestHelpers.AssertValuesFilled(result);
            
            Assert.IsType<FlatDtoClassWithoutConstructor>(result.NestedObject);
            Concerns.TestHelpers.AssertValuesFilled(result.NestedObject);
        }
    }
}