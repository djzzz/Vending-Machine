using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("testVendingMachine")]
namespace Vending_Machine
{
    
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            //Give out menu for vending machine
            string name = InputHandler.inputToString("What is your name");
            User user = new User(name);
            IVending vendingMachine = new VendingMachine(user);

            while (!exit)
            {
                Console.WriteLine($"vending machine saldo: {vendingMachine.MoneyHandler.Kroners} kr");
                Console.WriteLine($"user saldo: {user.Money} kr");
                Console.WriteLine("1. Buy a item");
                Console.WriteLine("2. Insert money");
                Console.WriteLine("3. Use items");
                Console.WriteLine("4. End transation");
                int result = InputHandler.InputToInt("Please pick one of the alternatives in the menu", "couldnt convert it to a number");
                switch (result)
                {
                    case 1:
                        for (int i = 0; i < vendingMachine.Products.Count; i++)
                        {
                            Console.WriteLine($"{i+1}. {vendingMachine.Products[i].Name}");
                            
                        }
                        int index = InputHandler.InputToInt("Please pick one of the alternatives in the menu", "couldnt convert it to a number");
                        if (vendingMachine.Purchase(index - 1))
                        {
                            Console.WriteLine($"{vendingMachine.Products[index-1].Name} is now yours");
                        }
                        else
                        {
                            Console.WriteLine($"{vendingMachine.Products[index-1].Name} is too expensive for you");
                        }
                        
                        break;
                    case 2:
                        Console.Write("Allowed amounts are:");
                        for (int i = 0; i < vendingMachine.MoneyHandler.AllowedAmounts.Length; i++)
                        {
                            Console.Write($" {vendingMachine.MoneyHandler.AllowedAmounts[i]},");
                        }
                        Console.Write("\n");
                        int amount = InputHandler.InputToInt("Please enter amount of kronors", "couldnt convert it to a number");
                        if (vendingMachine.InsertMoney(amount))
                        {
                            Console.WriteLine("Money was added");
                        }
                        else
                        {
                            Console.WriteLine("The amount was not a valid denomination or your saldo is to low");
                            
                        }
                        break;
                    case 3:
                        for (int i = 0; i < user.Inventory.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {user.Inventory[i].Name}");

                        }
                        index = InputHandler.InputToIntWithRange("Please pick one of the alternatives in the menu", "couldnt convert it to a number", user.Inventory.Count, 1);

                        Console.WriteLine("What action");
                        Console.WriteLine("1. Examine");
                        Console.WriteLine("2. Use");
                        int action = InputHandler.InputToInt("Please pick one of the alternatives in the menu", "couldnt convert it to a number");
                        if (action == 1)
                        {
                            user.Inventory[index-1].Examine();
                        }
                        else if (action == 2)
                        {
                            user.Inventory[index-1].Use();
                            Console.WriteLine("using it ");
                        }
                        else
                        {
                            Console.WriteLine("Out of range");
                        }
                        
                        break;
                    case 4:
                        Console.WriteLine($"{vendingMachine.EndTransaction()} kr back");
                        break;
                    default:
                        Console.WriteLine($"{result} is not a alternative in the menu");
                        break;
                }
                
            }
        }
    }
}
