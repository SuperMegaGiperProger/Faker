using TestFaker.TestObjects;
using Xunit;

namespace TestFaker
{
    public class NotDtoObjects
    {
        [Fact]
        public void WhenObjectIsNotDto()
        {
            var obj = new Faker.Faker("../../../config.yml").Create<NotDtoClass>();
            
            Assert.Null(obj);
        }
    }
}