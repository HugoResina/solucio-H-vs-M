using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace metodesHVM
{
    public class C1HVM
    {
        public static bool CreateStat(int min, int max, int value)
        {
            return (value >= min && value <= max) ? true : false;
        }
        public static int RandomStat(int min, int max) 
        {
            Random random = new Random();
            return random.Next(min, max + 1);
        }
        public static int[] turnCreator() 
        {
            int[] turnsArray = { 1, 2, 3, 4 };
            Random random = new Random();

            
            for (int i = 0; i < turnsArray.Length - 1; i++)
            {
                int j = random.Next(i, turnsArray.Length);
                int temp = turnsArray[i];
                turnsArray[i] = turnsArray[j];
                turnsArray[j] = temp;
            }

            return turnsArray;
        }
        public static string turnSelector(int numero)
        {
            string character = "";

            switch (numero)
            {
                case 1:
                    //ataca la arquera
                    character = "A";
                    break;
                case 2:
                    character = "B";
                    break;
                case 3:
                    character = "M";
                    break;
                case 4:
                    character = "D";
                    break;
            }

            return character;
        }
        /*public static int Attack()
        {

        }*/
    }
}
