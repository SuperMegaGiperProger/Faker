using Xunit;

namespace TestFaker
{
    class ClassA
    {
        public string Str;
        public ClassB B;
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
            
            Assert.NotNull(obj.B);
            Assert.Null(obj.B.A);
            
            Assert.NotNull(obj.Str);
            Assert.NotNull(obj.B.Str);
            
            Assert.IsType<ClassA>(obj);
            Assert.IsType<ClassB>(obj.B);
        }
    }
}