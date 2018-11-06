using System;

namespace TestFaker.TestObjects
{
    public class FlatDtoClassWithoutConstructor
    {
        public string StringField1;
        public string StringFiled2;
        public string StringProperty1 { get; }
        public string StringProperty2 { set; private get; }
        public string StringProperty3 { private set; get; }
        public string StringProperty4 { set; get; }
        private string PrivateStringField;
        private string PrivateStringProperty { set; get; }
    }
}