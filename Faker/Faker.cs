namespace Faker
{
    public class Faker : IFaker
    {
        public Faker() { }

        public T Create<T>() where T : class
        {
            if (!Concerns.DtoChecker.IsDto(typeof(T))) return null;
            
            return null;
        }
    }
}