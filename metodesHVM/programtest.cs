using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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
                    //ataca el barbar
                    character = "B";
                    break;
                case 3:
                    //ataca la maga
                    character = "M";
                    break;
                case 4:
                    //ataca el druida
                    character = "D";
                    break;
            }

            return character;
        }
        public static int criticOrFail()
        {
            /*per condensar en una funcio la posibilitat de critic o fallar l'atac, he fet un numero aleatori
            del 1 al 20, en dos casos possibles retorna critic ja que 2/20 = 10% pero nomes en un retorna falla(i nomes si no fa critic)
            ja que 1/20 = 5%.*/

            int critFailValidator;
            Random random = new Random();
            critFailValidator = random.Next(1, 21);
            if (critFailValidator ==  5 || critFailValidator == 6)
            {
                return 1;

            }
            if(critFailValidator == 7)
            {
                return 2;
            }
            return 0;
            

        }
        public static double Attack(double dmg, double dmgReduction)
        {
            const string fail = "El atac ha fallat, fent 0 de mal!";
            const string crit = "El atac ha sigut un impacte critic! ha fet el doble de mal!";
            if (criticOrFail() == 1) 
            {
                Console.WriteLine(crit);
                dmg *= 2;
                return (dmg - dmg*(dmgReduction/100));
            }
            if (criticOrFail() == 2)
            {
                Console.WriteLine(fail);
               return 0;
            }
            return (dmg - dmg * (dmgReduction / 100));
        }
        public static double Defense(double dmgReduction)
        {
            return dmgReduction *= 2;
        }
        public static bool checkUltCharge(int ultCounter)
        {
            if (ultCounter < 5)
            {
                return false;
            }
            return true;
        }
        public static bool archerUlt()
        {
            return true;
        }
        public static double mageUlt(double dmg)
        {
            return (3 * dmg);
        }
        public static double DruidUlt(double Hp, double maxHp)
        {
            if ((Hp + 500) > maxHp && Hp > 0)
            {
                return maxHp;
            }
            else if (Hp > 0)
            {
                return Hp + 500;
            }
            return 0;
        }
    }
}
