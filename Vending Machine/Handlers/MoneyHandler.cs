using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vending_Machine
{
    class MoneyHandler
    {
        private int kroners = 0;
        private int[] allowedAmounts = { 1, 5, 10, 20, 50, 100, 500, 1000, 5000 };
        public int Kroners { get { return kroners; } }
        public int[] AllowedAmounts { get { return allowedAmounts; } }

        public bool Addkroners(int amount)
        {
            if(allowedAmounts.Contains(amount))
            {
                kroners += amount;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Charge(int amount)
        {
            if(kroners >= amount)
            {
                kroners -= amount;
                return true;
            }
            return false;
        }
        public int kronorsBack()
        {
            int amount = kroners;
            kroners = 0;
            return amount;
        }
    }
}
