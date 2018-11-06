using System;
using System.Linq;

namespace Faker.Generators.Default
{
    public class String : PrimitiveGenerator
    {
        private const string CHARS = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        private const int MIN_LENGTH = 5;
        private const int MAX_LENGTH = 30;
        
        public override Type GeneratedType => typeof(string);

        protected override object GenerateValue()
        {
            var length = _random.Next(MIN_LENGTH, MAX_LENGTH);
            
            return new string(Enumerable.Repeat(CHARS, length).Select(s => s[_random.Next(s.Length)]).ToArray());
        }
    }
}