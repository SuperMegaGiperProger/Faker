namespace TestFaker.TestObjects
{
    public class NotDtoClass
    {
        private bool Field;
        public bool Property { private set; get; }

        public NotDtoClass() {}

        private NotDtoClass(bool arg1) => Property = arg1;
    }
}