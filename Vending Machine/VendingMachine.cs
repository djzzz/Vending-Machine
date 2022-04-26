using System;
using System.Collections.Generic;
using System.Text;

namespace Vending_Machine
{
    class VendingMachine : IVending
    {
        private User user;
        private MoneyHandler moneyHandler;
        private List<Product> products = new List<Product> { };

        public User User { get => user; set => this.user = User; }
        public MoneyHandler MoneyHandler { get => moneyHandler; }
        public List<Product> Products { get => products;  }

        public VendingMachine(User user)
        {
            Tshirt tshirt = new Tshirt("Gucci T-shirt", "a brown tshirt with the guzzi logo and comes with stickers", 200);
            Pants pants = new Pants("Gucci Pants", "Black lazy pants with guzzi marks on the legs", 500);
            Hat hat = new Hat("Gucci Hat", "The tipical fisher hat with white guzzi marks on", 1000);
            this.products.Add((Product)tshirt);
            this.products.Add((Product)pants);
            this.products.Add((Product)hat);
            moneyHandler = new MoneyHandler();
            this.user = user;
            
        }
        bool IVending.Purchase(int id)
        {
            if (moneyHandler.Charge(products[id].Price))
            {
                user.AddToInventory(products[id]);
                return true;
            }
            return false;
        }

        List<Product> IVending.ShowAll()
        {
            return products;
        }

        bool IVending.InsertMoney(int amount)
        {
            if (user.RemoveMoney(amount)   && moneyHandler.Addkroners(amount))
            {

                return true;
            }
            return false;
        }

        List<int> IVending.EndTransaction()
        {
            List <int> returnValues = moneyHandler.kronorsBack();
            foreach(int returnValue in returnValues)
            {
                user.AddMoney(returnValue);
            }
            
            return returnValues;
        }
    }
}
