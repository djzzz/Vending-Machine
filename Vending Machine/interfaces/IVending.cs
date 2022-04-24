using System;
using System.Collections.Generic;
using System.Text;

namespace Vending_Machine
{
    interface IVending
    {
        public User User { get; set; }
        public MoneyHandler MoneyHandler { get;  }
        public List<Product> Products { get;  }

        public bool Purchase(int id);
        public List<Product> ShowAll();
        public bool InsertMoney(int amount);
        public int EndTransaction();
    }
}
