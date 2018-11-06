using System;
using System.Collections.Generic;

namespace TestFaker.TestObjects
{
    public class FlatDtoClassWithoutConstructor
    {
        public bool a;
        public byte b;
        public char c;
        public DateTime d;
        public double e;
        public int f;
        public List<int> g;
        
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