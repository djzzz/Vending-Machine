using System;
using System.Collections.Generic;
using System.Text;

namespace Vending_Machine
{
    class Hat : Product
    {
        public Hat(string name, string desc, int price)
        {
            this.name = name;
            this.desc = desc;
            this.price = price;
        }
        public override void Examine()
        {
            Console.WriteLine($"{name} {desc} that cost {price}kr");
        }
        public override void Use()
        {
            Console.WriteLine("try my on if you dare if fit on your head");
        }
    }
}
