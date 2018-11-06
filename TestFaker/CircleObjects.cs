using Xunit;

namespace TestFaker
{
    class ClassA
    {
        public string Str;
        public ClassB B1;
        public ClassB B2;
    }

    class ClassB
    {
        public string Str;
        public ClassA A;
    }
    
    public class CircleObjects
    {
        [Fact]
        public void InitializeCycleFieldsWithNull()
        {
            var obj = Concerns.TestHelpers.GetFaker().Create<ClassA>();
            
            Assert.NotNull(obj.B1);
            Assert.NotNull(obj.B2);
            Assert.Null(obj.B1.A);
            Assert.Null(obj.B2.A);
            
            Assert.NotNull(obj.Str);
            Assert.NotNull(obj.B1.Str);
            Assert.NotNull(obj.B2.Str);
            
            Assert.IsType<ClassA>(obj);
            Assert.IsType<ClassB>(obj.B1);
            Assert.IsType<ClassB>(obj.B2);
        }
    }
}