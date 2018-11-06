using Xunit;

namespace TestFaker
{
    class ClassWithPluginFields
    {
        public float A;
        public long B { get; set; }
    }
    
    public class Plugins
    {
        [Fact]
        public void FillsValues()
        {
            var obj = Concerns.TestHelpers.GetFaker().Create<ClassWithPluginFields>();
            
            Concerns.TestHelpers.AssertValuesFilled(obj);
        }
    }
}