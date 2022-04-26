using System;
using Xunit;
using Vending_Machine;
using System.Collections.Generic;

namespace Test_for_vending_machine
{
    public class UnitTest1
    {
        // User Model test
        [Fact]
        public void testUserName()
        {
            string name = "test";
            User user = new User(name);
            Assert.Equal(name, user.name);
        }
        [Fact]
        public void testUserStartAmount()
        {
            string name = "test";
            User user = new User(name);
            Assert.Equal(5000, user.Money);
        }
        [Fact]
        public void testUserAddMoney()
        {
            string name = "test";
            User user = new User(name);
            user.AddMoney(500);
            Assert.Equal(5500, user.Money);
        }
        [Fact]
        public void testUserRemoveMoney()
        {
            string name = "test";
            User user = new User(name);
            user.RemoveMoney(5000);
            Assert.Equal(0, user.Money);
        }
        [Fact]
        public void testUserAddToInventory()
        {
            string name = "test";
            User user = new User(name);
            VendingMachine vendingMachine = new VendingMachine(user);
            user.AddToInventory(vendingMachine.Products[0]);
            Assert.Equal(vendingMachine.Products[0], user.Inventory[0]);
        }
        [Fact]
        //Subproduct model test
        public void testSubProduct()
        {
            string name = "Tshirt";
            string desc = "Something";
            int price = 200;
            Tshirt tshirt = new Tshirt(name, desc, price);
            Assert.Equal(name, tshirt.Name);
            Assert.Equal(desc, tshirt.Desc);
            Assert.Equal(price, tshirt.Price);
        }
        //MoneyHandler
        [Fact]
        public void testInitMoneyHandler()
        {
            MoneyHandler moneyHandler = new MoneyHandler();
            Assert.Equal(0, moneyHandler.Kroners);
        }
        [Fact]
        public void testMoneyHandlerAddMoney()
        {
            MoneyHandler moneyHandler = new MoneyHandler();
            Assert.True(moneyHandler.Addkroners(500));
            Assert.False(moneyHandler.Addkroners(3));
        }
        [Fact]
        public void testMoneyHandlerChargeMoney()
        {
            MoneyHandler moneyHandler = new MoneyHandler();
            moneyHandler.Addkroners(500);
            Assert.True(moneyHandler.Charge(500));
            Assert.Equal(0, moneyHandler.Kroners);
        }
        //vending machine
        [Fact]
        public void testVendingMachineInsertMoney()
        {
            string name = "test";
            User user = new User(name);
            IVending vendingMachine = new VendingMachine(user);
            Assert.True(vendingMachine.InsertMoney(500));
            Assert.Equal(4500, user.Money);
            Assert.Equal(500, vendingMachine.MoneyHandler.Kroners);
        }
        [Fact]
        public void testVendingMachineBuyItem()
        {
            string name = "test";
            User user = new User(name);
            IVending vendingMachine = new VendingMachine(user);
            vendingMachine.InsertMoney(500);
            Assert.True(vendingMachine.Purchase(0));
            Assert.Single(user.Inventory);
            Assert.False(vendingMachine.Purchase(2));
            Assert.Single(user.Inventory);
        }
        [Fact]
        public void testVendingMachineShowAll()
        {
            string name = "test";
            User user = new User(name);
            IVending vendingMachine = new VendingMachine(user);
            List<Product> products = vendingMachine.ShowAll();
            Assert.Equal("Gucci T-shirt", products[0].Name);
            Assert.Equal("Gucci Pants", products[1].Name);
            Assert.Equal("Gucci Hat", products[2].Name);
        }
        [Fact]
        public void testVendingMachineEndtransation()
        {
            string name = "test";
            User user = new User(name);
            IVending vendingMachine = new VendingMachine(user);
            vendingMachine.InsertMoney(500);
            vendingMachine.Purchase(0);
            Assert.Equal(new List<int> { 1000, 500, 100, 100, 100 }, vendingMachine.EndTransaction());
        }
    }
}
