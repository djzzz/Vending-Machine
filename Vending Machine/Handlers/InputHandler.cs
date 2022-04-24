using System;
using System.Collections.Generic;
using System.Text;

namespace Vending_Machine
{
    class InputHandler
    {
        static public int InputToInt(string startMessage, string Failmessage)
        {
            int result = -1;
            bool sucess = false;
            Console.WriteLine(startMessage);

            while (!sucess)
            {
                sucess = int.TryParse(Console.ReadLine(), out result);
                if(sucess == false)
                {
                    Console.WriteLine(Failmessage);
                }
            }
            return result;
        }
        static public string inputToString(string startMessage)
        {
            Console.WriteLine(startMessage);
            return Console.ReadLine();
        }
        static public int InputToIntWithRange(string startMessage, string Failmessage, int max, int min)
        {
            int result = -1;

            bool sucess = false;
            Console.WriteLine(startMessage);

            while (!sucess)
            {

                sucess = int.TryParse(Console.ReadLine(), out result);
                if (max < result || min > result)
                {
                    sucess = false;
                }
                if (sucess == false)
                {
                    Console.WriteLine(Failmessage);
                }
            }
            return result;
        }
        
    }
}
