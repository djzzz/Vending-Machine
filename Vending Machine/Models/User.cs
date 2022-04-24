using System;
using System.Collections.Generic;
using System.Text;

namespace Vending_Machine
{
    class User
    {
        private int money;
        public int Money { get { return money; } }

        public string name;

        public List<Product> Inventory = new List<Product> { };

        public User(string name)
        {
            this.name = name;
            this.money = 5000;
        }
        public void AddMoney(int amount)
        {
            this.money += amount;
        }
        public bool RemoveMoney(int amount)
        {
            if(this.money - amount >= 0)
            {
                this.money -= amount;
                return true;
            }
            return false;
        }
        public void AddToInventory(Product product)
        {
            Inventory.Add(product);
        }
    }
}
