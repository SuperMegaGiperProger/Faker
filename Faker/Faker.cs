namespace Faker
{
    public class Faker : IFaker
    {
        public Faker()
        {
            
        }

        public T Create<T>() where T : class
        {
            return null;
        }
    }
}