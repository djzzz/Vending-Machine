using System;
using System.Collections.Generic;
using System.Text;

namespace Vending_Machine
{
    abstract class Product
    {
        protected string name;
        protected string desc;
        protected int price;
        public int Price { get { return price; } }
        public string Name { get { return name; } }
        public string Desc { get { return desc; } }
        public abstract void Examine();
        public abstract void Use();
    }
}
