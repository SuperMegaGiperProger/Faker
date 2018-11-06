using System;
using System.Collections.Generic;

namespace TestFaker.TestObjects
{
    public class FlatDtoClassWithConstructorWithParameters
    {
        public bool a;
        public byte b;
        public char c;
        public DateTime d;
        public double e;
        public int f;
        public List<int> g;
        public string h;

        public FlatDtoClassWithConstructorWithParameters(string stringField)
        {
            h = stringField;
        }
    }
}