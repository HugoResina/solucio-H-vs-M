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
            const string insertStat = "introdueix {0} de {1}, recorda, el valor ha de estar entre {2} i {3}:";
            const string dificultyMenu = "SELECCIONA DIFUCULTAT:\n1.-Fàcil: Agafa el valor més alt del rang d’atributs dels personatges i el més baix del monstre automàticament.\n2.-Difícil: Agafa el valor més baix del rang d’atributs dels personatges, i el més alt del monstre automàticament.\n3.-Personalitzat: L’usuari introduirà els valors manualment.\n4.-Random: El programa assignarà uns valors aleatoris a tots els atributs automàticament.\n";
            const string askChangeName = "vols canviar el nom dels teus personatges?\n1.-si\n2.-no";
            const string changeName = "introdueix els nous 4 noms, segueix el format: nom, nom, nom, nom y recorda, el ordre sera: arquera, barbar, maga i druida";
            const string getReady = "preparat per començar la batalla? prem cualsevol tecla";


            //stats
            string statStrenght = "la força ";
            string statHealth = "la vida";
            string statReduction = "la reduccio porcentual de mal";
            string roleArcher = "l'arquera";
            string roleBarbarian = "el barbar";
            string roleWizard = "la maga";
            string roleDruid = "el druida";
            string roleMonster = "el monstre";
            string newNames = "";

            int validatorFirstMenu, dificultySelector, validatorNameChange;

            int statValue, percentage_20, percentage_25, percentage_30, percentage_35, percentage_40, percentage_45, minArcherHealth, maxArcherHealth, archerDefense,
                barbarianDefense, wizardDefense, druidDefense, monsterDefense, practicArcherHealth, minArcherAttack, maxArcherAttack, practicArcherAttack, minBarbarianHealth,
                maxBarbarianHealth, practicBarbarianHealth, minBarbarianAttack, maxBarbarianAttack,practicBarbarianAttack, minWizardHealth, maxWizardHealth,
                practicWizardHealth, minWizardAttack, maxWizardAttack,practicWizardAttack, minDruidHealth, maxDruidHealth,practicDruidHealth, minDruidAttack, maxDruidAttack,
                practicDruidAttack, minMonsterHealth, maxMonsterHealth,practicMonsterHealth, minMonsterAttack, maxMonsterAttack, practicMonsterAttack;

            //dmg reduction
            percentage_20 = 20;
            percentage_25 = 25;
            percentage_30 = 30;
            percentage_35 = 35;
            percentage_40 = 40;
            percentage_45 = 45;
            //archer stats
            minArcherHealth = 1500;
            maxArcherHealth = 2000;
            minArcherAttack = 200;
            maxArcherAttack = 300;
            //barbarian stats
            minBarbarianHealth = 3000;
            maxBarbarianHealth = 3750;
            minBarbarianAttack = 150;
            maxBarbarianAttack = 250;
            //wizard stats
            minWizardHealth = 1100;
            maxWizardHealth = 1500;
            minWizardAttack = 300;
            maxWizardAttack = 400;
            //druid stats
            minDruidHealth = 2000;
            maxDruidHealth = 2500;
            minDruidAttack = 70;
            maxDruidAttack = 120;
            //monster stats
            minMonsterHealth = 7000;
            maxMonsterHealth = 10000;
            minMonsterAttack = 300;
            maxMonsterAttack = 400;

            dificultySelector = 0;

            Console.WriteLine(startFight + "\n" + getOut);
            validatorFirstMenu = Convert.ToInt16(Console.ReadLine());
            if (validatorFirstMenu == 1)
            {
                //part del programa per ficar creacio de personatges, torns etc
                //menu de dificultat
                do
                {
                    Console.WriteLine(dificultyMenu);
                    dificultySelector = Convert.ToInt16(Console.ReadLine());
                } while (!(dificultySelector == 1 || dificultySelector == 2 || dificultySelector == 3 || dificultySelector == 4));

                if (dificultySelector == 1) 
                {
                    practicArcherHealth = maxArcherHealth;
                    practicArcherAttack = maxArcherAttack;
                    archerDefense = percentage_35;
                    practicBarbarianHealth = maxBarbarianHealth;
                    practicBarbarianAttack = maxBarbarianAttack;
                    barbarianDefense = percentage_45;
                    practicWizardHealth = maxWizardHealth;
                    practicWizardAttack = maxWizardAttack;
                    wizardDefense = percentage_35;
                    practicDruidHealth = maxDruidHealth;
                    practicDruidAttack = maxDruidAttack;
                    druidDefense = percentage_40;

                    practicMonsterHealth = minMonsterHealth;
                    practicMonsterAttack = minMonsterAttack;
                    monsterDefense = percentage_20;


                }
                if (dificultySelector == 2)
                {
                    practicArcherHealth = minArcherHealth;
                    practicArcherAttack = minArcherAttack;
                    archerDefense = percentage_25;
                    practicBarbarianHealth = minBarbarianHealth;
                    practicBarbarianAttack = minBarbarianAttack;
                    barbarianDefense = percentage_35;
                    practicWizardHealth = minWizardHealth;
                    practicWizardAttack = minWizardAttack;
                    wizardDefense = percentage_20;
                    practicDruidHealth = minDruidHealth;
                    practicDruidAttack = minDruidAttack;
                    druidDefense = percentage_25;

                    practicMonsterHealth = maxMonsterHealth;
                    practicMonsterAttack = maxMonsterAttack;
                    monsterDefense = percentage_30;
                }
                if (dificultySelector == 3)
                {

                    //stats Arquera
                    do
                    {
                        Console.WriteLine(insertStat, statHealth, roleArcher, minArcherHealth, maxArcherHealth);
                        statValue = Convert.ToInt32(Console.ReadLine());
                    } while (!C1HVM.createStat(minArcherHealth, maxArcherHealth, statValue));
                    practicArcherHealth = statValue;
                    Console.Clear();
                    do
                    {
                        Console.WriteLine(insertStat, statStrenght, roleArcher, minArcherAttack, maxArcherAttack);
                        statValue = Convert.ToInt32(Console.ReadLine());
                    } while (!C1HVM.createStat(minArcherAttack, maxArcherAttack, statValue));
                    practicArcherAttack = statValue;
                    Console.Clear();
                    do
                    {
                        Console.WriteLine(insertStat, statReduction, roleArcher, percentage_25, percentage_35);
                        statValue = Convert.ToInt32(Console.ReadLine());
                    } while (!C1HVM.createStat(percentage_25, percentage_35, statValue));
                    archerDefense = statValue;
                    Console.Clear();


                    //stats Barbar

                    do
                    {
                        Console.WriteLine(insertStat, statHealth, roleBarbarian, minBarbarianHealth, maxBarbarianHealth);
                        statValue = Convert.ToInt32(Console.ReadLine());
                    } while (!C1HVM.createStat(minBarbarianHealth, maxBarbarianHealth, statValue));
                    practicBarbarianHealth = statValue;
                    Console.Clear();
                    do
                    {
                        Console.WriteLine(insertStat, statStrenght, roleBarbarian, minBarbarianAttack, maxBarbarianAttack);
                        statValue = Convert.ToInt32(Console.ReadLine());
                    } while (!C1HVM.createStat(minBarbarianAttack, maxBarbarianAttack, statValue));
                    practicBarbarianAttack = statValue;
                    Console.Clear();
                    do
                    {
                        Console.WriteLine(insertStat, statReduction, roleBarbarian, percentage_35, percentage_45);
                        statValue = Convert.ToInt32(Console.ReadLine());
                    } while (!C1HVM.createStat(percentage_35, percentage_45, statValue));
                    barbarianDefense = statValue;
                    Console.Clear();


                    //stats maga


                    do
                    {
                        Console.WriteLine(insertStat, statHealth, roleWizard, minWizardHealth, maxWizardHealth);
                        statValue = Convert.ToInt32(Console.ReadLine());
                    } while (!C1HVM.createStat(minWizardHealth, maxWizardHealth, statValue));
                    practicWizardHealth = statValue;
                    Console.Clear();
                    do
                    {
                        Console.WriteLine(insertStat, statStrenght, roleWizard, minWizardAttack, maxWizardAttack);
                        statValue = Convert.ToInt32(Console.ReadLine());
                    } while (!C1HVM.createStat(minWizardAttack, maxWizardAttack, statValue));
                    practicWizardAttack = statValue;
                    Console.Clear();
                    do
                    {
                        Console.WriteLine(insertStat, statReduction, roleWizard, percentage_20, percentage_35);
                        statValue = Convert.ToInt32(Console.ReadLine());
                    } while (!C1HVM.createStat(percentage_20, percentage_35, statValue));
                    wizardDefense = statValue;
                    Console.Clear();

                    //stats druida

                    do
                    {
                        Console.WriteLine(insertStat, statHealth, roleDruid, minDruidHealth, maxDruidHealth);
                        statValue = Convert.ToInt32(Console.ReadLine());
                    } while (!C1HVM.createStat(minDruidHealth, maxDruidHealth, statValue));
                    practicDruidHealth = statValue;
                    Console.Clear();
                    do
                    {
                        Console.WriteLine(insertStat, statStrenght, roleDruid, minDruidAttack, maxDruidAttack);
                        statValue = Convert.ToInt32(Console.ReadLine());
                    } while (!C1HVM.createStat(minDruidAttack, maxDruidAttack, statValue));
                    practicDruidAttack = statValue;
                    Console.Clear();
                    do
                    {
                        Console.WriteLine(insertStat, statReduction, roleDruid, percentage_25, percentage_40);
                        statValue = Convert.ToInt32(Console.ReadLine());
                    } while (!C1HVM.createStat(percentage_25, percentage_40, statValue));
                    druidDefense = statValue;
                    Console.Clear();

                    //stats monstre

                    do
                    {
                        Console.WriteLine(insertStat, statHealth, roleMonster, minMonsterHealth, maxMonsterHealth);
                        statValue = Convert.ToInt32(Console.ReadLine());
                    } while (!C1HVM.createStat(minMonsterHealth, maxMonsterHealth, statValue));
                    practicMonsterHealth = statValue;
                    Console.Clear();
                    do
                    {
                        Console.WriteLine(insertStat, statStrenght, roleMonster, minMonsterAttack, maxMonsterAttack);
                        statValue = Convert.ToInt32(Console.ReadLine());
                    } while (!C1HVM.createStat(minMonsterAttack, maxMonsterAttack, statValue));
                    practicMonsterAttack = statValue;
                    Console.Clear();
                    do
                    {
                        Console.WriteLine(insertStat, statReduction, roleMonster, percentage_20, percentage_30);
                        statValue = Convert.ToInt32(Console.ReadLine());
                    } while (!C1HVM.createStat(percentage_20, percentage_30, statValue));
                    monsterDefense = statValue;
                    Console.Clear();
                }
                if (dificultySelector == 4)
                {
                    practicArcherHealth = C1HVM.randomStat(minArcherHealth, maxArcherHealth);
                    practicArcherAttack = C1HVM.randomStat(minArcherAttack, maxArcherAttack);
                    archerDefense = C1HVM.randomStat(percentage_25, percentage_35);
                    practicBarbarianHealth = C1HVM.randomStat(minBarbarianHealth, maxBarbarianHealth);
                    practicBarbarianAttack = C1HVM.randomStat(minBarbarianAttack, maxBarbarianAttack);
                    barbarianDefense = C1HVM.randomStat(percentage_35, percentage_45);
                    practicWizardHealth = C1HVM.randomStat(minWizardHealth, maxWizardHealth);
                    practicWizardAttack = C1HVM.randomStat(minWizardAttack, maxWizardAttack);
                    wizardDefense = C1HVM.randomStat(percentage_20, percentage_35);
                    practicDruidHealth = C1HVM.randomStat(minDruidHealth, maxDruidHealth);
                    practicDruidAttack = C1HVM.randomStat(minDruidAttack, maxDruidAttack);
                    druidDefense = C1HVM.randomStat(percentage_25, percentage_40);

                    practicMonsterHealth = C1HVM.randomStat(minMonsterHealth, maxMonsterHealth);
                    practicMonsterAttack = C1HVM.randomStat(minMonsterAttack, maxMonsterAttack);
                    monsterDefense = C1HVM.randomStat(percentage_20, percentage_30);
                }
                Console.WriteLine(askChangeName);
                validatorNameChange = Convert.ToInt16(Console.ReadLine());
                if (validatorNameChange == 1)
                {
                    Console.WriteLine(changeName);
                    newNames = Console.ReadLine()?? "l'arquera, el barbar, la maga, el druida";
                    string[] characterNames = newNames.Split(", ");
                    roleArcher = characterNames[0];
                    roleBarbarian = characterNames[1];
                    roleWizard = characterNames[2];
                    roleDruid = characterNames[3];
                }
                Console.Clear();
                Console.WriteLine(getReady);
                Console.ReadKey();
                //combat

            }
            else
            {
                //directament no entra i et dona gracies
                Console.WriteLine("gracies per jugar");
            }

        }
    }
}