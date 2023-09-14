// See https://aka.ms/new-console-template for more information
using Jungel;

#region deffinion
List<Player> player = new List<Player>(); 
List<Items> items = new List<Items>(); 
List<Effects> effects = new List<Effects>();
List<SpecialSkills> skills = new List<SpecialSkills>();
List<Enemies> enemies = new List<Enemies>();
bool playing = false;
#endregion

do
{
    items = Weapons();
    player = Akt();
    effects = EffectsDeff();
    skills = Skills();
    enemies = Enemey();
    bool correct = false;
    while (correct == false)
    {
        Console.WriteLine("Do you want to start playing?\n\tY [Yes]\tN [No]");
        string play = Console.ReadLine();
        if (play == "Y")
        {
            correct = true;
            Console.Clear();
            player[0].ItemIndex = WeaponPick(items);
            Console.Clear();
            bool round = false;
            do //Stage 1
            {
                player[0].Ap = 5;
                round = Stage1(enemies, skills, effects, items, player);
                if (player[0].Hp <= 0)
                {
                    Console.WriteLine("Thank you for playing!");
                    Console.ReadKey();
                }
                string answ = "";
                while (answ != "Y" || answ != "N")
                {
                    Console.WriteLine("Do you want to replay the stage?\n\tY [Yes]\tN [No]");
                    answ = Console.ReadLine();
                    if (answ == null)
                    {
                        Console.WriteLine("Wrong answer!");
                    }
                    else if (answ == "Y")
                    {
                        round = false;
                        Console.Clear();
                        break;
                    }
                    else if (answ == "N")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Wrong answer!");
                    }
                }
            } while (round == false);
            if (player[0].Hp <= 0)
            {
                playing = false;
                break;
            }
            round = false;
            Console.Clear();
            //do //Stage 2
            //{
            //    player[0].Ap = 5;
            //    round = Stage2(enemies, skills, effects, items, player);
            //    Console.WriteLine("Do you want to replay the stage?\n\tY [Yes]\tN [No]");
            //    string answ = Console.ReadLine();
            //    if (answ == null)
            //    {
            //        answ = "N";
            //    }
            //    else if (answ == "Y")
            //    {
            //        round = false;
            //        Console.Clear();
            //        break;
            //    }
            //    else if (answ == "N")
            //    {
            //        break;
            //    }
            //    else
            //    {
            //        Console.WriteLine("Wrong answer!");
            //    }
            //} while (round == false);
            //if (player[0].Hp <= 0)
            //{
            //    playing = false;
            //    break;
            //}
            //round = false;
            //Console.Clear();
            do //Stage 3
            {
                player[0].Ap = 5;
                round = Stage3(enemies, skills, effects, items, player);
                string answ = "";
                if (player[0].Hp <= 0)
                {
                    Console.WriteLine("Thank you for playing!");
                    Console.ReadKey();
                }
                while (answ != "Y" || answ != "N")
                {
                    Console.WriteLine("Do you want to replay the stage?\n\tY [Yes]\tN [No]");
                    answ = Console.ReadLine();
                    if (answ == null)
                    {
                        Console.WriteLine("Wrong answer!");
                    }
                    else if (answ == "Y")
                    {
                        round = false;
                        Console.Clear();
                        break;
                    }
                    else if (answ == "N")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Wrong answer!");
                    }
                }
            } while (round == false);
            if (player[0].Hp <= 0)
            {
                playing = false;
                break;
            }
            round = false;
            Console.Clear();
            do //Stage Final
            {
                player[0].Ap = 5;
                round = StageFinal(enemies, skills, effects, items, player);
                if (player[0].Hp <= 0)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Thank you for playing!");
                    break;
                }
                if (player[0].Hp > 0)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("You defeted the final boss!\nThank you for playing!");
                    playing = false;
                    break;
                }
            } while (round == false);
        }
        else if (play == "N")
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Thank you for playing!");
            correct = true;
        }
        else
        {
            Console.WriteLine("Wrong answer!");
        }
    }
    
} while (playing == true);

#region game
static bool Stage1(List<Enemies> enemies, List<SpecialSkills> skills, List<Effects> effects, List<Items> items, List<Player> player)
{
    bool completed = false;
    bool playerTurn;
    int mosterHp = enemies.Find(x => x.Index == 1).Hp;
    //1 slime
    //menu
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine(@"
                           ██████████
                        ████▒▒▒▒░░░░░░████
                      ██▒▒▒▒░░░░░░      ░░██
                      ██▒▒▒▒░░░░░░░░    ░░██
                    ██▒▒▒▒▒▒░░░░░░░░░░░░░░▒▒██
                    ██▒▒▒▒▒▒▒▒░░░░░░░░░░░░▒▒██
                    ██▒▒▒▒▒▒▒▒▒▒░░░░░░░░▒▒▒▒██
                      ██▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒██
                        ██████████████████
");
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine(@"

            +=============================================+
    ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(@$"
											  
		     {"1 [Attack]"}	  {"2 [Special Attack]"}			  
											  
											  
		             {"3 [Player Status]"}									  
											  
    ");
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine(@"
            +=============================================+

    ");
    do
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("What are you going to do?");
        do
        {
            playerTurn = false;
            int.TryParse(Console.ReadLine(), out int what);
            if (what == 1)      //Regular Attack
            {
               mosterHp = RegualAttack(player, items, mosterHp, enemies, 1);
                playerTurn = true;
            }
            else if (what == 2)     //Special
            {
                string[] x = SpecialAttack(player, skills, mosterHp, enemies, 1);
                if (x[0] == "true")
                {
                    mosterHp = int.Parse(x[1]);
                    playerTurn = true;
                }
            }
            else if(what == 3) //player info status
            {
                string status = "none";
                if (player[0].StatusEffect != 0)
                {
                    status = effects.Find(x => x.Index == player[0].StatusEffect).Name;
                }
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine(@"
        +=============================================+
");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(@$"
											  
		   {"Weapon:" + items.Find(x => x.Index == player[0].ItemIndex).Name}			{"HP:" + player[0].Hp}			  
											  
											  
		   {"AP:" + player[0].Ap}			{"Status:" + status}			  
											  
");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine(@"
        +=============================================+

");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("What are you going to do?");
            }

        } while (playerTurn != true);
        //enemies turn
        if (mosterHp <= 0)
        {
            completed = true;
            if (LeveUp(player) == true)
            {
                if (player[0].Level != 5)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"You leveled up to {player[0].Level}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            break;
        }
        else if (EnemyAttack() == true)
        {
            player[0].Hp -= enemies.Find(x => x.Index == 1).Damage;
            Console.WriteLine($"{enemies.Find(x => x.Index == 1).Name} attacked!\nYour current HP{player[0].Hp}");
            if (player[0].Hp <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Oh no!\nLooks like your journe ends here!");
                completed = true;
                break;
            }
        }
        else
        {
            Console.WriteLine($"{enemies.Find(x => x.Index == 1).Name} missed!");
        }
    } while (completed != true);
    return completed;
}

static bool Stage2(List<Enemies> enemies, List<SpecialSkills> skills, List<Effects> effects, List<Items> items, List<Player> player)
{
    bool completed = false;
    bool playerTrun = false;
    int[] mosterHP = { enemies.Find(x => x.Index == 1).Hp, enemies.Find(x => x.Index == 1).Hp };
    //2 Slimes
    //R = 0 , L = 1
        //menu
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine(@"
                ██████████                          ██████████
            ████▒▒▒▒░░░░░░████                  ████▒▒▒▒░░░░░░████
          ██▒▒▒▒░░░░░░      ░░██              ██▒▒▒▒░░░░░░      ░░██
          ██▒▒▒▒░░░░░░░░    ░░██              ██▒▒▒▒░░░░░░░░    ░░██
        ██▒▒▒▒▒▒░░░░░░░░░░░░░░▒▒██          ██▒▒▒▒▒▒░░░░░░░░░░░░░░▒▒██
        ██▒▒▒▒▒▒▒▒░░░░░░░░░░░░▒▒██          ██▒▒▒▒▒▒▒▒░░░░░░░░░░░░▒▒██
        ██▒▒▒▒▒▒▒▒▒▒░░░░░░░░▒▒▒▒██          ██▒▒▒▒▒▒▒▒▒▒░░░░░░░░▒▒▒▒██
          ██▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒██              ██▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒██
            ██████████████████                  ██████████████████
");
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine(@"

             +=============================================+
");
        Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine(@$"
											  
											  
			      {"L [Left]"}			{"R [Rigth]"}								  
											  
											  
											  
");
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine(@"
            +=============================================+
");
        Console.ForegroundColor = ConsoleColor.White;
        string select = Console.ReadLine();
        if (select == null)
        {
            select = "R";
        }
    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.WriteLine(@"

            +=============================================+
    ");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine(@$"
											  
		     {"1 [Attack]"}	  {"2 [Special Attack]"}			  
											  
											  
		             {"3 [Player Status]"}									  
											  
    ");
    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.WriteLine(@"
            +=============================================+

    ");
    do
    {
        if (select == "R")
        {
            Console.WriteLine("What are you going to do?");
            do
            {
                playerTrun = false;
                int.TryParse(Console.ReadLine(), out int what);
                if (what == 1)      //Regular Attack
                {
                    RegualAttack(player, items, mosterHP[0], enemies, 1);
                    playerTrun = true;
                }
                else if (what == 2)     //Special
                {
                    string[] x = SpecialAttack(player, skills, mosterHP[0], enemies, 1);
                    if (x[0] == "true")
                    {
                        mosterHP[0] = int.Parse(x[1]);
                        playerTrun = true;
                    }
                }
                else if (what == 3) //player info status
                {
                    string status = "none";
                    if (player[0].StatusEffect != 0)
                    {
                        status = effects.Find(x => x.Index == player[0].StatusEffect).Name;
                    }
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine(@"
        +=============================================+
");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(@$"
											  
		   {"Weapon:" + items.Find(x => x.Index == player[0].ItemIndex)}			{"HP:" + player[0].Hp}			  
											  
											  
		   {"AP:" + player[0].Ap}			    {"Status:" + status}			  
											  
");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine(@"
        +=============================================+

");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("What are you going to do?");
                }
            } while (playerTrun != true);
        }
        else if (select == "L")
        {
            Console.WriteLine("What are you going to do?");
            do
            {
                playerTrun = false;
                int.TryParse(Console.ReadLine(), out int what);
                if (what == 1)      //Regular Attack
                {
                    RegualAttack(player, items, mosterHP[1], enemies, 1);
                    playerTrun = true;
                }
                else if (what == 2)     //Special
                {
                    string[] x = SpecialAttack(player, skills, mosterHP[1], enemies, 1);
                    if (x[0] == "true")
                    {
                        mosterHP[1] = int.Parse(x[1]);
                        playerTrun = true;
                    }
                }
                else if (what == 3) //player info status
                {
                    string status = "none";
                    if (player[0].StatusEffect != 0)
                    {
                        status = effects.Find(x => x.Index == player[0].StatusEffect).Name;
                    }
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine(@"
        +=============================================+
");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(@$"
											  
		   {"Weapon:" + items.Find(x => x.Index == player[0].ItemIndex).Name}			{"HP:" + player[0].Hp}			  
											  
											  
		   {"AP:" + player[0].Ap}			{"Status:" + status}			  
											  
");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine(@"
        +=============================================+

");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("What are you going to do?");
                }
            } while (playerTrun != true);
        }
        else
        {
            Console.WriteLine("Incorrect answer!");
        }
        //enemy turn
        for (int i = 0; i <= 1; i++)
        {
            if (EnemyAttack() == true)
            {
                player[0].Hp -= enemies.Find(x => x.Index == 1).Damage;
                Console.WriteLine($"{enemies.Find(x => x.Index == 1).Name} attacked!\nYour current HP{player[0].Hp}");
            }
            else if (player[0].Hp <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Oh no!\nLooks like your journe ends here!");
                completed = true;
            }
            if (mosterHP[0] <= 0 && mosterHP[1] <= 0)
            {
                completed = true;
            }
            else if (mosterHP[i] <= 0)
            {
                if (LeveUp(player) == true)
                {
                    if (player[0].Level != 5)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine($"You leveled up to {player[0].Level}");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
            }
            else
            {
                Console.WriteLine($"{enemies.Find(x => x.Index == 1).Name} missed!");
            }
        }
    } while (completed != true);
    return completed;
}

static bool Stage3(List<Enemies> enemies, List<SpecialSkills> skills, List<Effects> effects, List<Items> items, List<Player> player)
{
    bool completed = false;
    bool playerTurn;
    int mosterHp = enemies.Find(x => x.Index == 2).Hp;
    int effectTuns = 2;
    //1 ice fairy
    //menu
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine(@"
   
                   (\{\
                   { { \ ,~,
                  { {   \)))  *
                   { {  (((  /
                    {/{/; ,\/
                       (( '
                        \` \
                        (/  \
                        `)  `\
");
    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.WriteLine(@"

            +=============================================+
    ");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine(@$"
											  
		     {"1 [Attack]"}	  {"2 [Special Attack]"}			  
											  
											  
		             {"3 [Player Status]"}									  
											  
    ");
    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.WriteLine(@"
            +=============================================+

    ");
    Console.ForegroundColor = ConsoleColor.White;
    do
    {
        Console.WriteLine("What are you going to do?");
        do
        {
            playerTurn = false;
            int.TryParse(Console.ReadLine(), out int what);
            if (what == 1)      //Regular Attack
            {
                mosterHp = RegualAttack(player, items, mosterHp, enemies, 2);
                playerTurn = true;
            }
            else if (what == 2)     //Special
            {
                string[] x = SpecialAttack(player, skills, mosterHp, enemies, 1);
                if (x[0] == "true")
                {
                    mosterHp = int.Parse(x[1]);
                    playerTurn = true;
                }
            }
            else if (what == 3) //player info status
            {
                string status = "none";
                if (player[0].StatusEffect != 0)
                {
                    status = effects.Find(x => x.Index == player[0].StatusEffect).Name;
                }
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine(@"
        +=============================================+
");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(@$"
											  
		   {"Weapon:" + items.Find(x => x.Index == player[0].ItemIndex).Name}			{"HP:" + player[0].Hp}			  
											  
											  
		   {"AP:" + player[0].Ap}			{"Status:" + status}			  
											  
");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine(@"
        +=============================================+

");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("What are you going to do?");
            }

        } while (playerTurn != true);
        //enemies turn
        if (mosterHp <= 0)
        {
            if (LeveUp(player) == true)
            {
                if (player[0].Level != 5)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"You leveled up to {player[0].Level}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            completed = true;
            break;
        }
        else if (EnemyAttack() == true)
        {
            player[0].Hp -= enemies.Find(x => x.Index == 2).Damage;
            Console.WriteLine($"{enemies.Find(x => x.Index == 2).Name} attacked!\nYour current HP{player[0].Hp}");
            if (SpecialEffect() == true && player[0].StatusEffect == 0)
            {
                player[0].Hp -= effects.Find(x => x.Index == enemies.Find(y => y.Index == 2).Index).Boost;
                player[0].StatusEffect = 2;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{effects.Find(x => x.Index == 2).PlayerInfo} [this going to lats 2 rounds]");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (player[0].Hp <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Oh no!\nLooks like your journe ends here!");
                completed = true;
                break;
            }
        }
        else
        {
            Console.WriteLine($"{enemies.Find(x => x.Index == 2).Name} missed!");
        }
        if (effectTuns == 0)
        {
            effectTuns = 2;
            player[0].StatusEffect = 0;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{effects.Find(x => x.Index == 2).Name} is stoped");
            Console.ForegroundColor = ConsoleColor.White;
        }
        else if (player[0].StatusEffect == 2)
        {
            effectTuns--;
        }
    } while (completed != true);
    return completed;
}

static bool StageFinal(List<Enemies> enemies, List<SpecialSkills> skills, List<Effects> effects, List<Items> items, List<Player> player)
{
    bool completed = false;
    bool playerTurn;
    int mosterHp = enemies.Find(x => x.Index == 3).Hp;
    int effectTuns = 2;
    //1 dragon
    //menu
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(@"

         \****__              ____                                              
                 |    *****\_      --/ *\-__                                          
                 /_          (_    ./ ,/----'                                         
                   \__         (_./  /                                                
                      \__           \___----^__                                       
                       _/   _                  \                                      
                |    _/  __/ )\""\ _____         *\                                    
                |\__/   /    ^ ^       \____      )                                   
                 \___--""                    \_____ )                                  
                                                  ""
");
    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.WriteLine(@"

            +=============================================+
    ");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine(@$"
											  
		     {"1 [Attack]"}	  {"2 [Special Attack]"}			  
											  
											  
		             {"3 [Player Status]"}									  
											  
    ");
    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.WriteLine(@"
            +=============================================+

    ");
    Console.ForegroundColor = ConsoleColor.White;
    do
    {
        Console.WriteLine("What are you going to do?");
        do
        {
            playerTurn = false;
            int.TryParse(Console.ReadLine(), out int what);
            if (what == 1)      //Regular Attack
            {
                mosterHp = RegualAttack(player, items, mosterHp, enemies, 3);
                playerTurn = true;
            }
            else if (what == 2)     //Special
            {
                string[] x = SpecialAttack(player, skills, mosterHp, enemies, 1);
                if (x[0] == "true")
                {
                    mosterHp = int.Parse(x[1]);
                    playerTurn = true;
                }
            }
            else if (what == 3) //player info status
            {
                string status = "none";
                if (player[0].StatusEffect != 0)
                {
                    status = effects.Find(x => x.Index == player[0].StatusEffect).Name;
                }
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine(@"
        +=============================================+
");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(@$"
											  
		   {"Weapon:" + items.Find(x => x.Index == player[0].ItemIndex).Name}			{"HP:" + player[0].Hp}			  
											  
											  
		   {"AP:" + player[0].Ap}			{"Status:" + status}			  
											  
");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine(@"
        +=============================================+

");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("What are you going to do?");

            }

        } while (playerTurn != true);
        //enemies turn
        if (mosterHp <= 0)
        {
            if (LeveUp(player) == true)
            {
                if (player[0].Level != 5)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"You leveled up to {player[0].Level}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            completed = true;
            break;
        }
        else if (EnemyAttack() == true)
        {
            player[0].Hp -= enemies.Find(x => x.Index == 3).Damage;
            Console.WriteLine($"{enemies.Find(x => x.Index == 3).Name} attacked!\nYour current HP{player[0].Hp}");
            if (SpecialEffect() == true && player[0].StatusEffect == 0)
            {
                player[0].Hp -= effects.Find(x => x.Index == enemies.Find(y => y.Index == 3).Index).Boost;
                player[0].StatusEffect = 3;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{effects.Find(x => x.Index == 3).PlayerInfo} [this going to lats 2 rounds]");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (player[0].Hp <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Oh no!\nLooks like your journe ends here!");
                completed = true;
                break;
            }
        }
        else
        {
            Console.WriteLine($"{enemies.Find(x => x.Index == 3).Name} missed!");
        }
        if (effectTuns == 0)
        {
            effectTuns = 2;
            player[0].StatusEffect = 0;
            Console.ForegroundColor= ConsoleColor.Yellow;
            Console.WriteLine($"{effects.Find(x => x.Index == 3).Name} is stoped");
            Console.ForegroundColor = ConsoleColor.White;
        }
        else if (player[0].StatusEffect == 3)
        {
            effectTuns--;
        }
    } while (completed != true);
    return completed;
}
#endregion

#region mechanic
static bool SpecialEffect()
{
    bool playing = false;
    Random random = new Random();
    int a = random.Next(0, 10);
    int b = random.Next(0, 10);
    if(a == b)
    {
        playing = true;
    }
    return playing;
}

static bool AttackSuccess()
{
    bool attack = true;
    Random random = new Random();
    int a = random.Next(0, 5);
    int b = random.Next(0, 5);
    if(a == b)
    {
        attack = false;
    }
    return attack;
}

static int RegualAttack(List<Player> player, List<Items> items, int mosterHp, List<Enemies> enemies, int mosterIndex)
{
    int playerItem = player[0].ItemIndex;
    int attackN = items.Find(x => x.Index == playerItem).Damage;
    if (AttackSuccess() == true)
    {
        mosterHp -= attackN;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"You did {attackN} damage to the {enemies.First(x => x.Index == mosterIndex).Name}!");
        Console.ForegroundColor = ConsoleColor.White;
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("You missed your attack!");
        Console.ForegroundColor = ConsoleColor.White;
    }
    return mosterHp;
}

static string[] SpecialAttack(List<Player> player, List<SpecialSkills> skills, int mosterHp, List<Enemies> enemies, int mosterIndex)
{
    //menu
    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.WriteLine(@"
        +=============================================+
");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine(@$"
											  
		   {"1 [Healing]"}			{"2 [Magic]"}			  
											  
											  
		   {"3 [Remove Status]"}		{"9 [Exit]"}			  
											  
");
    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.WriteLine(@"
        +=============================================+

");
    Console.ForegroundColor = ConsoleColor.White;
    string[] chooseAttack = {"true" , "0"};
    Console.WriteLine("What are you going to do?");
    int.TryParse(Console.ReadLine(), out int choose);
    if (choose == 1)    //healing
    {
        int ackHp = player[0].Hp;
        if (player[0].Ap > skills.Find(x => x.Index == choose).Ap)
        {
            //base on level your max hp
            switch (player[0].Level)
            {
                case 1:
                    if (ackHp == 100)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("You already at max health!");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        player[0].Hp += skills.Find(x => x.Index == choose).Done;
                        player[0].Ap += skills.Find(x => x.Index == choose).Ap;
                        Console.WriteLine($"{skills.Find(x => x.Index == choose).sceern} remaining AP: {player[0].Ap}");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    break;

                case 2:
                    if (ackHp == 120)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("You already at max health!");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        player[0].Hp += skills.Find(x => x.Index == choose).Done * 2;
                        player[0].Ap += skills.Find(x => x.Index == choose).Ap;
                        Console.WriteLine($"{skills.Find(x => x.Index == choose).sceern} remaining AP: {player[0].Ap}");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    break;
                case 3:
                    if (ackHp == 140)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("You already at max health!");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        player[0].Hp += skills.Find(x => x.Index == choose).Done * 3;
                        player[0].Ap += skills.Find(x => x.Index == choose).Ap;
                        Console.WriteLine($"{skills.Find(x => x.Index == choose).sceern} remaining AP: {player[0].Ap}");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    break;
                case 4:
                    if (ackHp == 160)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("You already at max health!");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        player[0].Hp += skills.Find(x => x.Index == choose).Done * 4;
                        player[0].Ap += skills.Find(x => x.Index == choose).Ap;
                        Console.WriteLine($"{skills.Find(x => x.Index == choose).sceern} remaining AP: {player[0].Ap}");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    break;
                case 5:
                    if (ackHp > 180)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("You already at max health!");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        player[0].Hp += skills.Find(x => x.Index == choose).Done * 5;
                        player[0].Ap += skills.Find(x => x.Index == choose).Ap;
                        Console.WriteLine($"{skills.Find(x => x.Index == choose).sceern} remaining AP: {player[0].Ap}");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    break;
                default:
                    Console.WriteLine();
                    break;
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("You don't have enought AP!");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
    else if (choose == 2)   //magic
    {
        if (player[0].Ap > skills.Find(x => x.Index == choose).Ap)
        {
            mosterHp -= skills.First(x => x.Index == choose).Done;
            chooseAttack[1] = mosterHp.ToString();
            player[0].Ap += skills.Find(x => x.Index == choose).Ap;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{skills.Find(x => x.Index == choose).sceern} remaining AP: {player[0].Ap}");
            Console.ForegroundColor = ConsoleColor.White;

        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("You don't have enought AP!");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
    else if (choose == 3)    //Status remove
    {
        if (player[0].Ap > skills.Find(x => x.Index == choose).Ap)
        {
            player[0].StatusEffect = skills.Find(x => x.Index == choose).Done;
            player[0].Ap += skills.Find(x => x.Index == choose).Ap;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{skills.Find(x => x.Index == choose).sceern} remaining AP: {player[0].Ap}");
            Console.ForegroundColor = ConsoleColor.White;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("You don't have enought AP!");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
    else if (choose == 9)
    {
        Console.WriteLine("You didn't use special attack!");
        chooseAttack[0] = "false";
    }
    return chooseAttack;
}

static bool EnemyAttack()
{
    bool success = true;
    Random random = new Random();
    int a = random.Next(0, 5);
    int b = random.Next(0, 5);
    if (a == b)
    {
        success = false;
    }
    return success;
}

static bool LeveUp(List<Player> player)
{
    bool success = false;
    Random random = new Random();
    switch (player[0].Level)
    {
        case 1:
            int a = random.Next(1, 2);
            int b = random.Next(1,2);
            if (a == b)
            {
                success = true;
                player[0].Level++;
            }
            break;
        case 2:
            int c = random.Next(1, 3);
            int d = random.Next(1, 3);
            if (c == d)
            {
                player[0].Level++;
                success = true;
            }
            break;
        case 3:
            int e = random.Next(1, 4);
            int f = random.Next(1, 4);
            if (e == f)
            {
                player[0].Level++;
                success = true;
            }
            break;
        case 4:
            int g = random.Next(1, 5);
            int h = random.Next(1, 5);
            if (g == h)
            {
                player[0].Level++;
                success = true;
            }
            break;
        default:
            Console.WriteLine("You already reach the max level!");
            break;
    }
    return success;
}

static int WeaponPick(List<Items> items)
{
    int index = 0;
    //menu
    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.WriteLine(@"

            +=============================================+
    ");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine(@$"
											  
		     {"1 [Sword]"}       {"2 [Bow]"}			  
	      {"Attack power: " + items.Find(x => x.Index == 1).Damage}      {"Attack power: " + items.Find(x => x.Index == 2).Damage}						  
											  
		             {"3 [Spear]"}									  
				{"Attack power: " + items.Find(x => x.Index == 3).Damage}						  
    ");
    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.WriteLine(@"
            +=============================================+

    ");
    Console.ForegroundColor = ConsoleColor.White;
    do
    {
        Console.WriteLine("Please choose your weapon!");
        int.TryParse(Console.ReadLine(), out index);
        switch (index)
        {
            case 1:
                //sword
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"You choose {items.Find(x => x.Index == index).Name} as your weapon");
                Console.ForegroundColor= ConsoleColor.White;
                break;
            case 2:
                //bow
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"You choose {items.Find(x => x.Index == index).Name} as your weapon");
                Console.ForegroundColor = ConsoleColor.White;
                break;
            case 3:
                //spear
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"You choose {items.Find(x => x.Index == index).Name} as your weapon");
                Console.ForegroundColor = ConsoleColor.White;
                break;
            default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Incorrect input!");
                Console.ForegroundColor = ConsoleColor.White;
                index = 0;
                break;
        }
    } while (index == 0);
    return index;
}

#endregion

#region start
    static List<Items> Weapons()
    {
        List<Items> list = new List<Items>();
        string[] deff = {"1;sword;5", "2;bow;3", "3;Spear;4" };
        string[] a;
        for (int i = 0; i <=  2; i++)
        {
            a = deff[i].Split(';');
            Items b = new Items(a[1], int.Parse(a[0]), int.Parse(a[2]));
            list.Add(b);
        }
        return list;
    }

    static List<Player> Akt()
    {
        List<Player> players = new List<Player>();
        int[] deff = {1, 0, 0, 100, 5 };
        Player a = new Player(deff[0], deff[1], deff[2], deff[3], deff[4]);
        players.Add(a);
        return players;
    }

    static List<Effects> EffectsDeff()
    {
        List<Effects> list = new List<Effects>();
        string[] deff = { "2;Freezing;3;You're freezing", "3;Burning;3;You're burning", "1;Healing;5;Your wouns were healed"};
        string[] a;
        for (int i = 0; i <= deff.Length - 1; i++)
        {
            a = deff[i].Split(';');
            Effects b = new Effects(int.Parse(a[0]), a[1], int.Parse(a[2]), a[3]);
            list.Add(b);
        }
        return list;
    }

    static List<SpecialSkills> Skills()
    {
        List<SpecialSkills> list = new List<SpecialSkills> ();
        string[] deff = { "1;Healing;5;You heald yourself;-1", "2;Magic;10;You used magic;-2", "3;Remove;0;All status effect have been removed;-1"};
        string[] a;
        for(int i = 0; i <= deff.Length - 1; i++)
        {
            a = deff[i].Split(';');
            SpecialSkills b = new SpecialSkills(int.Parse(a[0]), a[1], int.Parse(a[2]), a[3], int.Parse(a[4]));
            list.Add(b);
        }
        return list;
    }

    static List<Enemies> Enemey()
    {
        List<Enemies> enemies = new List<Enemies>();
        string[] deff = { "1;Slime;9;2" , "2;Ice Fairy;17;3" , "3;Dragon;22;4"};
        string[] a;
        for (int i = 0; i <= deff.Length - 1; i++)
        {
            a = deff[i].Split(';');
            Enemies b = new Enemies(int.Parse(a[0]), a[1], int.Parse(a[2]), int.Parse(a[3]));
            enemies.Add(b);
        }
    return enemies;
    }
    #endregion