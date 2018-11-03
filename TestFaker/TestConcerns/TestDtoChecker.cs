using System;
using Xunit;

namespace TestFaker.TestConcerns
{
    public class TestDtoChecker
    {
        [Fact]
        public void WhenTypeHasPublicFields()
        {
            Assert.True(Result(typeof(DtoClass1)));
        }
        
        [Fact]
        public void WhenTypeHasPublicProperties()
        {
            Assert.True(Result(typeof(DtoClass2)));
        }
        
        [Fact]
        public void WhenTypeHasReadablePropertiesAndPublicConstructorWithParams()
        {
            Assert.True(Result(typeof(DtoClass3)));
        }
        
        [Fact]
        public void WhenTypeIsNotDto()
        {
            Assert.False(Result(typeof(NotDtoClass)));
        }

        private static bool Result(Type type)
        {
            return Faker.Concerns.DtoChecker.IsDto(type);
        }
        
        private class DtoClass1
        {
            public bool Field;
        }

        private class DtoClass2
        {
            public bool Property { set; get; }
        }

        private class DtoClass3
        {
            public bool Property { private set; get; }

            public DtoClass3(bool arg1) => Property = arg1;
        }

        private class NotDtoClass
        {
            private bool Field;
            public bool Property { private set; get; }
            public NotDtoClass() { }
            private NotDtoClass(bool arg1) => Property = arg1;
        }
    }
}