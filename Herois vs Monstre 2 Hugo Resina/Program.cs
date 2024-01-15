using System;
using metodesHVM;
namespace heroisContraMonstres
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //programa main
            const string startFight = "1. Iniciar una nova batalla";
            const string getOut = "0. Sortir";

            int validatorFirstMenu;

            Console.WriteLine(startFight+"\n"+getOut);
            validatorFirstMenu = Convert.ToInt16(Console.ReadLine());
            if (validatorFirstMenu == 1) 
            {
                //part del programa per ficar creacio torns etc

            }
            else
            {
                //directament no entra i et dona gracies
                Console.WriteLine("gracies per jugar");
            }

        }
    }
}