using System;
using System.Data;
using System.Timers;
using metodesHVM;
namespace heroisContraMonstres
{
    public class Program
    {
        public static void Main(string[] args)
        {
           
            const string startFight = "1. Iniciar una nova batalla";
            const string getOut = "0. Sortir";
            const string insertStat = "introdueix {0} de {1}, recorda, el valor ha de estar entre {2} i {3}:";
            const string dificultyMenu = "SELECCIONA DIFUCULTAT:\n1.-Fàcil: Agafa el valor més alt del rang d’atributs dels personatges i el més baix del monstre automàticament.\n2.-Difícil: Agafa el valor més baix del rang d’atributs dels personatges, i el més alt del monstre automàticament.\n3.-Personalitzat: L’usuari introduirà els valors manualment.\n4.-Random: El programa assignarà uns valors aleatoris a tots els atributs automàticament.\n";
            const string askChangeName = "vols canviar el nom dels teus personatges?\n1.-si\n2.-no";
            const string changeName = "introdueix els nous 4 noms, segueix el format: nom, nom, nom, nom y recorda, el ordre sera: arquera, barbar, maga i druida";
            const string getReady = "preparat per començar la batalla? prem cualsevol tecla";
            const string chooseAction = "que fara {0}?\n1.- Atacar\n2.- Defensar-se\n3.- Habilitat especial";
            const string ultNoReady = "la habilitat definitiva no esta preparada, falten ";
            const string turns = " torns";
            const string attackMsg = "{0} ataca a {1} i li treu {2} punts de vida, al monstre li queden {3}/{4} punts de vida";
            const string defense = "{0} ha decidit protegir-se, fins el proxim torn la seva reducció de mal sera el doble";
            const string msgArcherUlt = "{0} fa servir la seva habilitat definitiva, el monstre no atacara durant dos torns";
            const string msgBarbarianUlt = "{0} fa servir la seva habilitat definitiva, durant dos torns no rebra mal";
            const string msgWizardUlt = "{0} fa servir la seva habilitat definitiva, fa un atac que fara el triple del seu mal";
            const string msgDruidUlt = "{0} fa servir la seva habilitat definitiva, curara 500 de vida a tots els herois";
            const string dead = "{0} esta mort@, no pot prendre acció";
            const string stuned = "el monstre no ataca, ja que esta paralitzat per la habilitat de la arquera";
            const string barbarianHability = "el barbar no pateix mal degut a la seva habilitat";
            const string monsterWin = "el monstre ha vençut als herois";
            const string herosWin = "els herois han vençut al monstre";
            const string replay = "vols tornar a jugar?\n1.-si\n2.-no";
            const string mistakeDone = "has comés un error, et queden aquests intents: ";

           
            string statStrenght = "la força ";
            string statHealth = "la vida";
            string statReduction = "la reduccio porcentual de mal";
            string roleArcher = "l'arquera";
            string roleBarbarian = "el barbar";
            string roleWizard = "la maga";
            string roleDruid = "el druida";
            string roleMonster = "el monstre";
            string newNames = "";

            bool validAnswer = false;
            bool archerUlt = false;
            bool barbarianUlt = false;
            bool archerHasDefensed = false;
            bool barbarianHasDefensed = false;
            bool wizardHasDefensed = false;
            bool druidHasDefensed = false;
            bool threeErrors = false;

            int statValue,replayValidator, validatorFirstMenu, dificultySelector, validatorNameChange, actionValidator, errors, counterArcherUlt, counterBarbarianUlt, counterWizardUlt, counterDruidUlt, stunCounter;

            double practicArcherHealth,monsterDmg, archerDefense, barbarianDefense, wizardDefense, druidDefense, monsterDefense, practicArcherAttack, practicWizardHealth, practicBarbarianHealth, practicBarbarianAttack, practicWizardAttack, practicDruidHealth, practicDruidAttack, practicMonsterHealth, practicMonsterAttack;

            practicArcherHealth = 0;
            archerDefense = 0;
            barbarianDefense = 0;
            wizardDefense = 0;
            druidDefense = 0;
            monsterDefense = 0;
            practicArcherAttack = 0;
            practicWizardHealth = 0;
            practicBarbarianHealth = 0;
            practicBarbarianAttack = 0;
            practicWizardAttack = 0;
            practicDruidHealth = 0;
            practicDruidAttack = 0;
            practicMonsterHealth = 0;
            practicMonsterAttack = 0;
            errors = 0;
            counterArcherUlt = 1;
            counterBarbarianUlt = 1;
            counterDruidUlt = 1;
            counterWizardUlt = 1;
            monsterDmg = 0;
            stunCounter = 0;
            replayValidator = 0;

          
            const int percentage_20 = 20;
            const int percentage_25 = 25;
            const int percentage_30 = 30;
            const int percentage_35 = 35;
            const int percentage_40 = 40;
            const int percentage_45 = 45;
           
            const int minArcherHealth = 1500;
            const int maxArcherHealth = 2000;
            const int minArcherAttack = 200;
            const int maxArcherAttack = 300;
            practicArcherHealth = 0;
            
            const int minBarbarianHealth = 3000;
            const int maxBarbarianHealth = 3750;
            const int minBarbarianAttack = 150;
            const int maxBarbarianAttack = 250;
            practicBarbarianHealth = 0;
           
            const int minWizardHealth = 1100;
            const int maxWizardHealth = 1500;
            const int minWizardAttack = 300;
            const int maxWizardAttack = 400;
            practicWizardHealth = 0;
          
            const int minDruidHealth = 2000;
            const int maxDruidHealth = 2500;
            const int minDruidAttack = 70;
            const int maxDruidAttack = 120;
            practicDruidHealth = 0;
          
            const int minMonsterHealth = 7000;
            const int maxMonsterHealth = 10000;
            const int minMonsterAttack = 300;
            const int maxMonsterAttack = 400;
            practicMonsterHealth = 0;

            dificultySelector = 0;

            Console.WriteLine(startFight + "\n" + getOut);
            validatorFirstMenu = Convert.ToInt16(Console.ReadLine());
            if (validatorFirstMenu == 1)
            {
               
                do
                {
                    replayValidator = 0;
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

                       
                        do
                        {
                            Console.WriteLine(insertStat, statHealth, roleArcher, minArcherHealth, maxArcherHealth);
                            statValue = Convert.ToInt32(Console.ReadLine());
                            if(!C1HVM.CreateStat(minArcherHealth, maxArcherHealth, statValue))
                            {
                                Console.WriteLine(mistakeDone + (2 - errors));
                                errors++;
                            }
                            if (errors == 3)
                            {
                                threeErrors = true;
                            }
                        } while (!C1HVM.CreateStat(minArcherHealth, maxArcherHealth, statValue) && !threeErrors);

                        practicArcherHealth = statValue;
                        errors = 0;
                        
                        Console.Clear();
                        if (!threeErrors)
                        {
                            do
                            {
                                Console.WriteLine(insertStat, statStrenght, roleArcher, minArcherAttack, maxArcherAttack);
                                statValue = Convert.ToInt32(Console.ReadLine());
                                if (!C1HVM.CreateStat(minArcherAttack, maxArcherAttack, statValue) )
                                {
                                    Console.WriteLine(mistakeDone + (2 - errors));
                                    errors++;
                                }
                                if (errors == 3)
                                {
                                    threeErrors = true;
                                }
                            } while (!C1HVM.CreateStat(minArcherAttack, maxArcherAttack, statValue) && !threeErrors);
                        }
                        practicArcherAttack = statValue;
                        errors = 0;
                        Console.Clear();
                        if (!threeErrors)
                        {
                            do
                            {
                                Console.WriteLine(insertStat, statReduction, roleArcher, percentage_25, percentage_35);
                                statValue = Convert.ToInt32(Console.ReadLine());
                                if (!C1HVM.CreateStat(percentage_25, percentage_35, statValue))
                                {
                                    Console.WriteLine(mistakeDone + (2 - errors));
                                    errors++;
                                }
                                if (errors == 3)
                                {
                                    threeErrors = true;
                                }
                            } while (!C1HVM.CreateStat(percentage_25, percentage_35, statValue) && !threeErrors);
                        }
                        archerDefense = statValue;
                        errors = 0;
                        Console.Clear();


                      
                        if (!threeErrors)
                        {
                            do
                            {
                                Console.WriteLine(insertStat, statHealth, roleBarbarian, minBarbarianHealth, maxBarbarianHealth);
                                statValue = Convert.ToInt32(Console.ReadLine());
                                if (!C1HVM.CreateStat(minBarbarianHealth, maxBarbarianHealth, statValue))
                                {
                                    Console.WriteLine(mistakeDone + (2 - errors));
                                    errors++;
                                }
                                if (errors == 3)
                                {
                                    threeErrors = true;
                                }
                            } while (!C1HVM.CreateStat(minBarbarianHealth, maxBarbarianHealth, statValue) && !threeErrors);
                        }
                        practicBarbarianHealth = statValue;
                        errors = 0;
                        Console.Clear();
                        if (!threeErrors)
                        {
                            do
                            {
                                Console.WriteLine(insertStat, statStrenght, roleBarbarian, minBarbarianAttack, maxBarbarianAttack);
                                statValue = Convert.ToInt32(Console.ReadLine());
                                if (!C1HVM.CreateStat(minBarbarianAttack, maxBarbarianAttack, statValue))
                                {
                                    Console.WriteLine(mistakeDone + (2 - errors));
                                    errors++;
                                }
                                if (errors == 3)
                                {
                                    threeErrors = true;
                                }
                            } while (!C1HVM.CreateStat(minBarbarianAttack, maxBarbarianAttack, statValue) && !threeErrors);
                        }
                        practicBarbarianAttack = statValue;
                        errors = 0;
                        Console.Clear();
                        if (!threeErrors)
                        {
                            do
                            {
                                Console.WriteLine(insertStat, statReduction, roleBarbarian, percentage_35, percentage_45);
                                statValue = Convert.ToInt32(Console.ReadLine());
                                if (!C1HVM.CreateStat(percentage_35, percentage_45, statValue))
                                {
                                    Console.WriteLine(mistakeDone + (2 - errors));
                                    errors++;
                                }
                                if (errors == 3)
                                {
                                    threeErrors = true;
                                }
                            } while (!C1HVM.CreateStat(percentage_35, percentage_45, statValue) && !threeErrors);
                        }
                        barbarianDefense = statValue;
                        errors = 0;
                        Console.Clear();


                       

                        if (!threeErrors)
                        {
                            do
                            {
                                Console.WriteLine(insertStat, statHealth, roleWizard, minWizardHealth, maxWizardHealth);
                                statValue = Convert.ToInt32(Console.ReadLine());
                                if (!C1HVM.CreateStat(minWizardHealth, maxWizardHealth, statValue))
                                {
                                    Console.WriteLine(mistakeDone + (2 - errors));
                                    errors++;
                                }
                                if (errors == 3)
                                {
                                    threeErrors = true;
                                }
                            } while (!C1HVM.CreateStat(minWizardHealth, maxWizardHealth, statValue) && !threeErrors);
                        }
                        practicWizardHealth = statValue;
                        errors = 0;
                        Console.Clear();
                        if (!threeErrors)
                        {
                            do
                            {
                                Console.WriteLine(insertStat, statStrenght, roleWizard, minWizardAttack, maxWizardAttack);
                                statValue = Convert.ToInt32(Console.ReadLine());
                                if (!C1HVM.CreateStat(minWizardAttack, maxWizardAttack, statValue))
                                {
                                    Console.WriteLine(mistakeDone + (2 - errors));
                                    errors++;
                                }
                                if (errors == 3)
                                {
                                    threeErrors = true;
                                }
                            } while (!C1HVM.CreateStat(minWizardAttack, maxWizardAttack, statValue) && !threeErrors);
                        }
                        practicWizardAttack = statValue;
                        errors = 0;
                        Console.Clear();
                        if (!threeErrors)
                        {
                            do
                            {
                                Console.WriteLine(insertStat, statReduction, roleWizard, percentage_20, percentage_35);
                                statValue = Convert.ToInt32(Console.ReadLine());
                                if (!C1HVM.CreateStat(percentage_20, percentage_35, statValue))
                                {
                                    Console.WriteLine(mistakeDone + (2 - errors));
                                    errors++;
                                }
                                if (errors == 3)
                                {
                                    threeErrors = true;
                                }
                            } while (!C1HVM.CreateStat(percentage_20, percentage_35, statValue) && !threeErrors);
                        }
                        wizardDefense = statValue;
                        errors = 0;
                        Console.Clear();

                       
                        if (!threeErrors)
                        {
                            do
                            {
                                Console.WriteLine(insertStat, statHealth, roleDruid, minDruidHealth, maxDruidHealth);
                                statValue = Convert.ToInt32(Console.ReadLine());
                                if (!C1HVM.CreateStat(minDruidHealth, maxDruidHealth, statValue))
                                {
                                    Console.WriteLine(mistakeDone + (2 - errors));
                                    errors++;
                                }
                                if (errors == 3)
                                {
                                    threeErrors = true;
                                }
                            } while (!C1HVM.CreateStat(minDruidHealth, maxDruidHealth, statValue) && !threeErrors);
                        }
                        practicDruidHealth = statValue;
                        errors = 0;
                        Console.Clear();
                        if (!threeErrors)
                        {
                            do
                            {
                                Console.WriteLine(insertStat, statStrenght, roleDruid, minDruidAttack, maxDruidAttack);
                                statValue = Convert.ToInt32(Console.ReadLine());
                                if (!C1HVM.CreateStat(minDruidAttack, maxDruidAttack, statValue))
                                {
                                    Console.WriteLine(mistakeDone + (2 - errors));
                                    errors++;
                                }
                                if (errors == 3)
                                {
                                    threeErrors = true;
                                }
                            } while (!C1HVM.CreateStat(minDruidAttack, maxDruidAttack, statValue) && !threeErrors);
                        }
                        practicDruidAttack = statValue;
                        errors = 0;
                        Console.Clear();
                        if (!threeErrors)
                        {
                            do
                            {
                                Console.WriteLine(insertStat, statReduction, roleDruid, percentage_25, percentage_40);
                                statValue = Convert.ToInt32(Console.ReadLine());
                                if (!C1HVM.CreateStat(percentage_25, percentage_40, statValue))
                                {
                                    Console.WriteLine(mistakeDone + (2 - errors));
                                    errors++;
                                }
                                if (errors == 3)
                                {
                                    threeErrors = true;
                                }
                            } while (!C1HVM.CreateStat(percentage_25, percentage_40, statValue) && !threeErrors);
                        }
                        druidDefense = statValue;
                        errors = 0;
                        Console.Clear();

                      
                        if (!threeErrors)
                        {
                            do
                            {
                                Console.WriteLine(insertStat, statHealth, roleMonster, minMonsterHealth, maxMonsterHealth);
                                statValue = Convert.ToInt32(Console.ReadLine());
                                if (!C1HVM.CreateStat(minMonsterHealth, maxMonsterHealth, statValue))
                                {
                                    Console.WriteLine(mistakeDone + (2 - errors));
                                    errors++;
                                }
                                if (errors == 3)
                                {
                                    threeErrors = true;
                                }
                            } while (!C1HVM.CreateStat(minMonsterHealth, maxMonsterHealth, statValue) && !threeErrors);
                        }
                        practicMonsterHealth = statValue;
                        errors = 0;
                        Console.Clear();
                        if (!threeErrors)
                        {
                            do
                            {
                                Console.WriteLine(insertStat, statStrenght, roleMonster, minMonsterAttack, maxMonsterAttack);
                                statValue = Convert.ToInt32(Console.ReadLine());
                                if (!C1HVM.CreateStat(minMonsterAttack, maxMonsterAttack, statValue))
                                {
                                    Console.WriteLine(mistakeDone + (2 - errors));
                                    errors++;
                                }
                                if (errors == 3)
                                {
                                    threeErrors = true;
                                }
                            } while (!C1HVM.CreateStat(minMonsterAttack, maxMonsterAttack, statValue) && !threeErrors);
                        }
                        practicMonsterAttack = statValue;
                        errors = 0;
                        Console.Clear();
                        if (!threeErrors)
                        {
                            do
                            {
                                Console.WriteLine(insertStat, statReduction, roleMonster, percentage_20, percentage_30);
                                statValue = Convert.ToInt32(Console.ReadLine());
                                if (!C1HVM.CreateStat(percentage_20, percentage_30, statValue))
                                {
                                    Console.WriteLine(mistakeDone + (2 - errors));
                                    errors++;
                                }
                                if (errors == 3)
                                {
                                    threeErrors = true;
                                }
                            } while (!C1HVM.CreateStat(percentage_20, percentage_30, statValue) && !threeErrors);
                        }
                        monsterDefense = statValue;
                        errors = 0;
                        Console.Clear();
                    }
                    if (dificultySelector == 4)
                    {
                        practicArcherHealth = C1HVM.RandomStat(minArcherHealth, maxArcherHealth);
                        practicArcherAttack = C1HVM.RandomStat(minArcherAttack, maxArcherAttack);
                        archerDefense = C1HVM.RandomStat(percentage_25, percentage_35);
                        practicBarbarianHealth = C1HVM.RandomStat(minBarbarianHealth, maxBarbarianHealth);
                        practicBarbarianAttack = C1HVM.RandomStat(minBarbarianAttack, maxBarbarianAttack);
                        barbarianDefense = C1HVM.RandomStat(percentage_35, percentage_45);
                        practicWizardHealth = C1HVM.RandomStat(minWizardHealth, maxWizardHealth);
                        practicWizardAttack = C1HVM.RandomStat(minWizardAttack, maxWizardAttack);
                        wizardDefense = C1HVM.RandomStat(percentage_20, percentage_35);
                        practicDruidHealth = C1HVM.RandomStat(minDruidHealth, maxDruidHealth);
                        practicDruidAttack = C1HVM.RandomStat(minDruidAttack, maxDruidAttack);
                        druidDefense = C1HVM.RandomStat(percentage_25, percentage_40);

                        practicMonsterHealth = C1HVM.RandomStat(minMonsterHealth, maxMonsterHealth);
                        practicMonsterAttack = C1HVM.RandomStat(minMonsterAttack, maxMonsterAttack);
                        monsterDefense = C1HVM.RandomStat(percentage_20, percentage_30);
                    }
                    double totArcherHealth = practicArcherHealth;
                    double totBarbarianHealth = practicBarbarianHealth;
                    double totWizardHealth = practicWizardHealth;
                    double totDruidHealth = practicDruidHealth;
                    double totMonsterHealth = practicMonsterHealth;
                    if (!threeErrors)
                    {


                        Console.WriteLine(askChangeName);
                        validatorNameChange = Convert.ToInt16(Console.ReadLine());
                        if (validatorNameChange == 1)
                        {
                            Console.WriteLine(changeName);
                            newNames = Console.ReadLine() ?? "l'arquera, el barbar, la maga, el druida";
                            string[] characterNames = newNames.Split(", ");
                            roleArcher = characterNames[0];
                            roleBarbarian = characterNames[1];
                            roleWizard = characterNames[2];
                            roleDruid = characterNames[3];
                        }
                        Console.Clear();
                        Console.WriteLine(getReady);
                        Console.ReadKey();
                        Console.Clear();
                       
                        do
                        {
                            int[] turnsArray = C1HVM.turnCreator();

                            for (int i = 0; i < turnsArray.Length; i++)
                            {
                                Console.WriteLine();
                                string whoTurn = C1HVM.turnSelector(turnsArray[i]);
                                if (whoTurn == "A")
                                {
                                    if (practicMonsterHealth <= 0)
                                    {
                                       
                                    }
                                    else if (practicArcherHealth > 0)
                                    {


                                        do
                                        {
                                            validAnswer = false;
                                            Console.WriteLine(chooseAction, roleArcher);
                                            actionValidator = Convert.ToInt16(Console.ReadLine());
                                            Console.Clear();
                                            if (actionValidator == 1)
                                            {

                                                double dmg = C1HVM.Attack(practicArcherAttack, monsterDefense);
                                                practicMonsterHealth -= dmg;
                                                validAnswer = true;
                                                Console.WriteLine(attackMsg, roleArcher, roleMonster, dmg, practicMonsterHealth, totMonsterHealth);
                                            }
                                            if (actionValidator == 2)
                                            {
                                                Console.WriteLine(defense);
                                                archerDefense = C1HVM.Defense(archerDefense);
                                                validAnswer = true;
                                                archerHasDefensed = true;
                                            }
                                            if (actionValidator == 3)
                                            {
                                                if (C1HVM.checkUltCharge(counterArcherUlt))
                                                {
                                                    Console.WriteLine(msgArcherUlt, roleArcher);
                                                    archerUlt = true;
                                                    counterArcherUlt = 0;
                                                    stunCounter = 2;
                                                    validAnswer = true;
                                                }
                                                else if (!C1HVM.checkUltCharge(counterArcherUlt))
                                                {
                                                    validAnswer = false;
                                                    Console.WriteLine(ultNoReady + (5 - counterArcherUlt) + turns);
                                                }

                                            }
                                            if (!validAnswer)
                                            {
                                                errors++;
                                            }
                                        } while (!validAnswer);
                                    }
                                    else
                                    {
                                        Console.WriteLine(dead, roleArcher);
                                    }

                                }

                                if (whoTurn == "B")
                                {
                                    if (practicMonsterHealth <= 0)
                                    {
                                        
                                    }
                                    else if (practicBarbarianHealth > 0)
                                    {


                                        do
                                        {
                                            validAnswer = false;
                                            Console.WriteLine(chooseAction, roleBarbarian);
                                            actionValidator = Convert.ToInt16(Console.ReadLine());
                                            Console.Clear();
                                            if (actionValidator == 1)
                                            {

                                                double dmg = C1HVM.Attack(practicBarbarianAttack, monsterDefense);
                                                practicMonsterHealth -= dmg;
                                                validAnswer = true;
                                                Console.WriteLine(attackMsg, roleBarbarian, roleMonster, dmg, practicMonsterHealth, totMonsterHealth);
                                            }
                                            if (actionValidator == 2)
                                            {
                                                Console.WriteLine(defense);
                                                barbarianDefense = C1HVM.Defense(barbarianDefense);
                                                validAnswer = true;
                                                barbarianHasDefensed = true;
                                            }
                                            if (actionValidator == 3)
                                            {
                                                if (C1HVM.checkUltCharge(counterBarbarianUlt))
                                                {
                                                    Console.WriteLine(msgBarbarianUlt, roleBarbarian);
                                                    barbarianUlt = true;
                                                    counterBarbarianUlt = 0;
                                                    validAnswer = true;
                                                }
                                                else if (!C1HVM.checkUltCharge(counterBarbarianUlt))
                                                {
                                                    validAnswer = false;
                                                    Console.WriteLine(ultNoReady + (5 - counterBarbarianUlt) + turns);
                                                }

                                            }
                                            if (!validAnswer)
                                            {
                                                errors++;
                                            }
                                        } while (!validAnswer);
                                    }
                                    else
                                    {
                                        Console.WriteLine(dead, roleBarbarian);
                                    }
                                }
                                if (whoTurn == "M")
                                {
                                    if (practicMonsterHealth <= 0)
                                    {
                                        
                                    }
                                    else if (practicWizardHealth > 0)
                                    {


                                        do
                                        {
                                            validAnswer = false;
                                            Console.WriteLine(chooseAction, roleWizard);
                                            actionValidator = Convert.ToInt16(Console.ReadLine());
                                            Console.Clear();
                                            if (actionValidator == 1)
                                            {

                                                double dmg = C1HVM.Attack(practicWizardAttack, monsterDefense);
                                                practicMonsterHealth -= dmg;
                                                validAnswer = true;
                                                Console.WriteLine(attackMsg, roleWizard, roleMonster, dmg, practicMonsterHealth, totMonsterHealth);
                                            }
                                            if (actionValidator == 2)
                                            {
                                                Console.WriteLine(defense);
                                                wizardDefense = C1HVM.Defense(wizardDefense);
                                                validAnswer = true;
                                                wizardHasDefensed = true;
                                            }
                                            if (actionValidator == 3)
                                            {
                                                if (C1HVM.checkUltCharge(counterWizardUlt))
                                                {
                                                    Console.WriteLine(msgWizardUlt, roleWizard);
                                                    validAnswer = true;
                                                    double dmg = C1HVM.mageUlt(practicWizardAttack);
                                                    practicMonsterHealth -= dmg;
                                                    Console.WriteLine(attackMsg, roleWizard, roleMonster, dmg, practicMonsterHealth, totMonsterHealth);
                                                }
                                                else if (!C1HVM.checkUltCharge(counterWizardUlt))
                                                {
                                                    validAnswer = false;
                                                    Console.WriteLine(ultNoReady + (5 - counterWizardUlt) + turns);
                                                }

                                            }
                                            if (!validAnswer)
                                            {
                                                errors++;
                                            }
                                        } while (!validAnswer);
                                    }
                                    else
                                    {
                                        Console.WriteLine(dead, roleWizard);
                                    }
                                }
                                if (whoTurn == "D")
                                {
                                    if (practicMonsterHealth <= 0)
                                    {
                                        
                                    }
                                    else if (practicDruidHealth > 0)
                                    {


                                        do
                                        {
                                            validAnswer = false;
                                            Console.WriteLine(chooseAction, roleDruid);
                                            actionValidator = Convert.ToInt16(Console.ReadLine());
                                            Console.Clear();
                                            if (actionValidator == 1)
                                            {

                                                double dmg = C1HVM.Attack(practicDruidAttack, monsterDefense);
                                                practicMonsterHealth -= dmg;
                                                validAnswer = true;
                                                Console.WriteLine(attackMsg, roleDruid, roleMonster, dmg, practicMonsterHealth, totMonsterHealth);
                                            }
                                            if (actionValidator == 2)
                                            {
                                                Console.WriteLine(defense);
                                                druidDefense = C1HVM.Defense(druidDefense);
                                                validAnswer = true;
                                                druidHasDefensed = true;
                                            }
                                            if (actionValidator == 3)
                                            {
                                                if (C1HVM.checkUltCharge(counterDruidUlt))
                                                {
                                                    Console.WriteLine(msgDruidUlt, roleDruid);
                                                    counterDruidUlt = 0;
                                                    validAnswer = true;
                                                    practicArcherHealth = C1HVM.DruidUlt(practicArcherHealth, totArcherHealth);
                                                    practicBarbarianHealth = C1HVM.DruidUlt(practicBarbarianHealth, totBarbarianHealth);
                                                    practicWizardHealth = C1HVM.DruidUlt(practicWizardHealth, totWizardHealth);
                                                    practicDruidHealth = C1HVM.DruidUlt(practicDruidHealth, totDruidHealth);
                                                }
                                                else if (!C1HVM.checkUltCharge(counterWizardUlt))
                                                {
                                                    validAnswer = false;
                                                    Console.WriteLine(ultNoReady + (5 - counterDruidUlt) + turns);
                                                }
                                            }
                                            if (!validAnswer)
                                            {
                                                errors++;
                                            }
                                        } while (!validAnswer);
                                    }
                                    else
                                    {
                                        Console.WriteLine(dead, roleDruid);
                                    }

                                }
                            }
                            Console.WriteLine();
                            if (!archerUlt && practicMonsterHealth > 0)
                            {
                                if (practicArcherHealth > 0)
                                {
                                    monsterDmg = C1HVM.Attack(practicMonsterAttack, archerDefense);
                                    practicArcherHealth -= monsterDmg;
                                    Console.WriteLine(attackMsg, roleMonster, roleArcher, monsterDmg, practicArcherHealth, totArcherHealth);
                                }
                                Console.WriteLine();
                                if (practicBarbarianHealth > 0 && !barbarianUlt)
                                {
                                    monsterDmg = C1HVM.Attack(practicMonsterAttack, barbarianDefense);
                                    practicBarbarianHealth -= monsterDmg;
                                    Console.WriteLine(attackMsg, roleMonster, roleBarbarian, monsterDmg, practicBarbarianHealth, totBarbarianHealth);
                                }
                                else if (barbarianUlt)
                                {
                                    counterBarbarianUlt--;
                                    Console.WriteLine(barbarianHability);
                                }
                                Console.WriteLine();
                                if (practicWizardHealth > 0)
                                {
                                    monsterDmg = C1HVM.Attack(practicMonsterAttack, wizardDefense);
                                    practicWizardHealth -= monsterDmg;
                                    Console.WriteLine(attackMsg, roleMonster, roleWizard, monsterDmg, practicWizardHealth, totWizardHealth);
                                }
                                Console.WriteLine();
                                if (practicDruidHealth > 0)
                                {
                                    monsterDmg = C1HVM.Attack(practicMonsterAttack, druidDefense);
                                    practicDruidHealth -= monsterDmg;
                                    Console.WriteLine(attackMsg, roleMonster, roleDruid, monsterDmg, practicDruidHealth, totDruidHealth);
                                }
                                Console.WriteLine();
                            }
                            else if (archerUlt)
                            {
                                Console.WriteLine(stuned);
                                stunCounter--;
                            }
                            if (archerHasDefensed)
                            {
                                archerDefense /= 2;
                                archerHasDefensed = false;
                            }
                            if (barbarianHasDefensed)
                            {
                                barbarianDefense /= 2;
                                barbarianHasDefensed = false;
                            }
                            if (wizardHasDefensed)
                            {
                                wizardDefense /= 2;
                                wizardHasDefensed = false;
                            }
                            if (druidHasDefensed)
                            {
                                druidDefense /= 2;
                                druidHasDefensed = false;
                            }
                            if (stunCounter <= 0)
                            {
                                archerUlt = false;
                            }
                            if (counterBarbarianUlt <= 0)
                            {
                                barbarianUlt = false;
                            }
                            counterArcherUlt++;
                            counterBarbarianUlt++;
                            counterWizardUlt++;
                            counterDruidUlt++;
                        } while (practicMonsterHealth > 0 && (practicArcherHealth > 0 || practicBarbarianHealth > 0 || practicWizardHealth > 0 || practicDruidHealth > 0));

                        if (practicMonsterHealth <= 0)
                        {
                            Console.WriteLine(herosWin);
                        }
                        else
                        {
                            Console.WriteLine(monsterWin);
                        }
                    }

                    Console.WriteLine(replay);
                    replayValidator = Convert.ToInt16(Console.ReadLine());
                } while (replayValidator == 1);
            }
            else
            {
               
                Console.WriteLine("gracies per jugar");
            }

        }
    }
}