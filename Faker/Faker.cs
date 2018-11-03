namespace Faker
{
    public class Faker : IFaker
    {
        public Faker() { }

        public T Create<T>() where T : class
        {
            if (!new Concerns.DtoChecker(typeof(T)).IsDto()) return null;
            
            return null;
        }
    }
}