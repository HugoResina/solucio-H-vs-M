using System;
using System.Data;
using metodesHVM;
namespace heroisContraMonstres
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //programa main

            //misatges
            const string startFight = "1. Iniciar una nova batalla";
            const string getOut = "0. Sortir";
            const string insertStat = "introdueix {0} de {1},recorda, el valor ha de estar entre {2} i {3}:";

            //stats
            string stat = " la força ";
            string role = " l'arquer ";
            int validatorFirstMenu, min, max, statValue;
            min = 1; 
            max = 10;
            statValue = 0;


            Console.WriteLine(startFight + "\n" + getOut);
            validatorFirstMenu = Convert.ToInt16(Console.ReadLine());
            if (validatorFirstMenu == 1)
            {
                //part del programa per ficar creacio torns etc
                do
                {

                    Console.WriteLine(insertStat, stat, role, min, max);
                    statValue = Convert.ToInt32(Console.ReadLine());
                    

                } while (C1HVM.createStat(5, 10, statValue));
            }
            else
            {
                //directament no entra i et dona gracies
                Console.WriteLine("gracies per jugar");
            }

        }
    }
}