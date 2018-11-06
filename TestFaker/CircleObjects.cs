using TestFaker.TestObjects;
using Xunit;

namespace TestFaker
{
    class ClassA : FlatDtoClassWithoutConstructor
    {
        public ClassB B1;
        public ClassB B2;
        public ClassB B3 { set; get; }
    }

    class ClassB : FlatDtoClassWithoutConstructor
    {
        public ClassA A1;
        public ClassA A2 { set; get; }
    }
    
    public class CircleObjects
    {
        [Fact]
        public void InitializeCycleFieldsWithNull()
        {
            var obj = Concerns.TestHelpers.GetFaker().Create<ClassA>();
 
            Concerns.TestHelpers.AssertValuesFilled(obj);
            
            Concerns.TestHelpers.AssertValuesFilled(obj.B1, new []{"A1", "A2"});
            Concerns.TestHelpers.AssertValuesFilled(obj.B2, new []{"A1", "A2"});
            Concerns.TestHelpers.AssertValuesFilled(obj.B3, new []{"A1", "A2"});
                                   
            Assert.Null(obj.B1.A1);
            Assert.Null(obj.B2.A1);
            Assert.Null(obj.B3.A1);
            
            Assert.Null(obj.B1.A2);
            Assert.Null(obj.B2.A2);
            Assert.Null(obj.B3.A2);

            Assert.IsType<ClassA>(obj);
            Assert.IsType<ClassB>(obj.B1);
            Assert.IsType<ClassB>(obj.B2);
            Assert.IsType<ClassB>(obj.B3);
        }
    }
}