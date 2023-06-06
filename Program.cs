using System;
using System.Threading;
using System.Collections.Generic;
using System.Media;
using System.Timers;

namespace Project_1
{
    public class Game
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int health;
        public int experience;
        public int damage;
        public int healingslots;

        public int dodgecount;

        public int loopValue;
        public bool mcHit;

        public string enemyname;
        public int enemyhealth;
        public int enemydamage;
        public int enemysentimentality;
        public bool enemyHit;
        public int enemyHit2;
        
        public bool skipIntro;
        public bool mercyAvailable;

        public char defenseKey;
    }

    class Program
    {
        static Game character;
        static ConsoleKeyInfo info;
        static void Main(string[] args) // Hier werden nur Sachen eingestellt wie Name, Hintergrundgeschichte und so.
        {
            Intro();
            Console.WindowWidth = 120;
            Console.Clear();
            character = new Game();
            
            bool canContinue = false;
            bool canContinue2 = false;
            character.skipIntro = false;

            while (canContinue == false)
            {
                Console.Write("\nGib deinen Namen ein: ");
                character.Name = Console.ReadLine();
                if (character.Name == "")
                    {
                        Console.WriteLine("Ein leerer Name? Wie seltsam. Bitte gib einen Namen MIT Buchstaben ein.");
                    }
                else 
                {
                    canContinue = true;
                }
            }
            // Kampf();
            Console.WriteLine("Hallo, " + character.Name + ". Schön dich kennenzulernen. Ich habe eine Geschichte zu erzählen bevor du startest, willst du sie hören?");
            Console.WriteLine();

            while (canContinue2 == false)
            {
                Console.Write("1: Ja, 2: Nein -> ");
                try
                {
                    int answer = Convert.ToInt32(Console.ReadLine());
                    if (answer != 1 && answer != 2 && answer != 3)
                    {
                        Console.WriteLine("Dies ist keine gültige Antwort, bitte versuch es erneut.");
                    }
                    else
                    {
                        canContinue2 = true;
                        switch (answer)
                        {
                        case 1:
                        Geschichte();
                        break;

                        case 2:
                        Title();
                        break;

                        case 3:
                        CentralManagement(true);
                        break;
                        }   
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Dies ist keine gültige Antwort, bitte versuch es erneut.");
                }
            }

        }
 
        static void Kampf()
        {
            Console.Clear();
            Console.WindowWidth = 120;
            Console.WindowHeight = 30;
            
            character.health = 100; 
            character.damage = 0;
            character.healingslots = 4;
            
            character.enemyname = "Mavereh"; 
            character.enemyhealth = 100;
            character.enemydamage = 0;
            character.enemysentimentality = 0;
            character.enemyHit = false;
            character.enemyHit2 = 0;
            character.mercyAvailable = false;




            // int nameOnBox, string message, bool enemyPresence, bool onMenu
            if (character.skipIntro == false)
            {
            UI(0, "Du bist auf dem Schlachtfeld. Deine Kameraden kämpfen mit dir.", false, false);
            UI(0, "Einige deiner Freunde sind verletzt, manche tot. Du bist noch unverletzt.", false, false);
            UI(0, "Mit deinem Schwert siehst du dich als bereit, für dein Land zu kämpfen.", false, false);
            UI(1, "Es ist Zeit, diesem hier ein Ende zu setzen!", false, false);
            UI(0, "Du bist sehr motiviert, diesen Krieg zu gewinnen.", false, false);
            UI(0, "Ein Reh nähert sich, auch mit einem Schwert parat.", false, false);
            UI(0, "Mit einem bösen Lächeln begrüßt er dich:", false, false);
            UI(2, "Hallo. Ich bin Mavereh.", false, false);
            UI(2, "...", false, false);
            UI(2, "Du fragst dich bestimmt, warum ich mich überhaupt vorstelle.", false, false);
            UI(2, "Ich frag mich das auch, denn bald bist du kein ansprechbarer Elch mehr.", false, false);
            UI(2, "Wir sehen uns... In der Hölle.", false, false);
            UI(0, "Du weißt nicht recht, was du sagen sollst. Ihr beide zückt eure Schwerte raus.", false, false);
            UI(1, "Wir sehen uns... Aber ich sehe dich erst viel später.", false, false);
            UI(0, "Der Kampf möge beginnen.", true, false);
            }
            using (SoundPlayer player = new SoundPlayer("C:\\Users\\Mindroma\\Desktop\\Project 1\\giornostheme2.wav"))
            {
                player.Play();
            }
            Offensive();
            if (character.enemyhealth < 100)
            {
                UI(2, "Argh! Du hast mich getroffen, aber wart nur ab bis ich zurücktreffe!", true, false);
            }
            else 
            {
                UI(2, "...? Ich habe dich nichtmal getroffen. Jedenfalls, NOCH nicht!", true, false);
            }
            character.defenseKey = 'd';
            Timer();
            if (character.mcHit == true)
            {
                UI(0, character.enemyname + " lacht.", true, false);
                UI(2, "Da war jemand nicht schnell genug! Ahaha~", true, false);
                UI(2, "...", true, false);
                UI(2, "Hör mal zu.", true, false);
                UI(2, "In meiner Region sind wir nur dazu trainiert worden, mit dem Schwert umzugehen.", false, false);
                UI(2, "Aber sie vergessen eine wichtige Sache: Das Umgehen mit dem Gehirn.", false, false);
                UI(2, "Das praktische Denken. Wenn man in der Lage ist, praktisch denken und kämpfen zu können, wird man Erfolg haben.", false, false);
                UI(2, "...", false, false);
                UI(2, "Warte, warum gebe ich dir überhaupt Tipps? Was mache ich hier?", true, false);
                UI(2, "Bitte tu so, als ob das nie passiert wäre. Lass uns... äh, weiterkämpfen.", true, false);
                UI(1, "...", true, false);
                character.enemysentimentality++;
            }
            else
            {
                UI(2, "...!!! Was!?!? Wie??? Mein Plan war perfekt...", true, false);
                UI(2, "Das wird nur vorübergehend so sein! Ich werde dich besiegen!!", true, false);
            }
            Offensive();
            if (character.enemyHit == true)
            {
                UI(2, "Du dreckiger Mistkerl! Was ist heute mit mir los?!?!", true, false);
                UI(2, "Aber ein schlechter Start bedeutet die ein schlechtes Ende!", true, false);
            }
            else
            {
                if (character.enemyHit2 == 0)
                {
                    UI(2, "Hm.", true, false);
                    UI(2, "Ich bin nicht auf deiner Seite, aber wenn du eine Chance haben willst, zu gewinnen, musst du mal angreifen!", true, false);
                    UI(2, "Allerdings ist das ein Vorteil für mich, und ich kann es nutzen! Hahah!", true, false);
                }
                else
                {
                    if (character.health < 100)
                    {
                        UI(2, "Klever. Seehr klever. Heil ruhig weiter, aber ich kann dich schneller treffen als du dich heilen kannst.", true, false);
                        UI(2, "Nachdem du alles aufgebraucht hast, wirst du hilflos sein! Wie ein kleines Baby! Ahaha!", true, false);
                    }
                    else
                    {       
                        UI(2, "Klever. Seehr klever. Heil ruhig weiter, aber ich kann dich wieder treffen, ich bin nicht müde!", true, false);
                        if (character.mcHit == true)
                        {
                        UI(0, "Wusstest du, dass die Chance, diese Nachricht zu kriegen, 1 zu 20 ist? Da hat jemand echt Glück gehabt!", true, false);
                        }
                    }
                    
                }
            }
            character.defenseKey = 'f';
            Timer();
            Offensive();
            character.defenseKey = 'g';
            Timer();
            Offensive();
            character.defenseKey = 'h';
            Timer();
            Offensive();
            character.defenseKey = 'i';
            Timer();
            Offensive();
            character.defenseKey = 'j';
            Timer();
            Offensive();
            character.defenseKey = 'k';
            Timer();
            Offensive();
            character.defenseKey = 'l';
            Timer();
            Offensive();
            character.defenseKey = 'm';
            Timer();
            Offensive();
            character.defenseKey = 'n';
            Timer();

        }

            

        static void Offensive()
        {
            UI(0, "Attackieren: A | Heilen: H", true, true);

            info = Console.ReadKey(true);
            if (info.KeyChar == 'a')
            {
                Random random = new Random();
                character.damage = random.Next(10, 31);
                character.enemyhealth = character.enemyhealth - character.damage;
                character.enemyHit = true;
                character.enemyHit2++;
                UI(0, "Du hast " + character.enemyname + " mit deinem Schwert getroffen! Er hat " + character.damage + " Schaden erlitten.", true, true);
                
                
            }
            else if (info.KeyChar == 'h')
            {
                character.health = character.health + 10;
                if (character.health >= 100)
                {
                    character.health = 100;
                    UI(0, "Du hast die magische Elch-Bandage benutzt und dich vollständig geheilt!", true, true);
                }
                else
                {
                    UI(0, "Du hast die magische Elch-Bandage benutzt und 10 HP geheilt! Du hast nun " + character.health + " HP.", true, true);
                }
                character.enemyHit = false;
                
            }
            else if (info.KeyChar == 'f')
            {
                if (character.mercyAvailable == false)
                {
                    using (SoundPlayer player = new SoundPlayer("C:\\Users\\Mindroma\\Desktop\\Project 1\\creepysound.wav"))
                    {
                        player.Play();
                    }
                    UI(3, "etG ocnWewmm  GFafeauoh  g uwekyersaros", false, false);
                    UI(3, "ffeuougFm mn rertcdcgcd ic  rfkuyvl aei Nzlmeumrlmudugutl up", false, false);
                    UI(3, "  zeklloaeuyymkdrs.yrng u ", false, false);
                    UI(3, "ftneefuMmeum us l!seuugm aym", false, false);
                    UI(3, "kd  tl.sepwBe.BuFs dh lmmm fedl  phm gommgfey este", false, false);
                    UI(3, "mmmd fo eehrmdeolymfefwaf myey thcm.n", false, false);
                    UI(3, "a   msauetbuhue eof", false, false);
                    UI(3, "skmf  hp ueyplo   Wepfeya reru ", false, false);
                    UI(3, "la lmmu aftnC", false, false);
                    UI(3, "enufa cCa il", false, false);
                    UI(3, "d efumueooemgariub oo   unukeermeBt Ctlrnaeowu  u  mpr oalnylkidmodC r  ak", false, false);
                    UI(3, "vpmtFcdfm oiadkme m.amJie", false, false);
                    UI(3, " e wtcetCrFu", false, false);
                    UI(3, "mdeyF u ouUmTum Cz.GHk y osu hd k.ur bfhFyfz eoa", false, false);
                    UI(3, "fhwlupcc", false, false);
                    Environment.Exit(0);
                }
            }
            else
            {
                UI(0, "Bitte wähl eine gültige Antwort aus.", true, false);
                Offensive();
            }
            Console.ReadKey(true);
        }
    
            
        static System.Timers.Timer timer;
        static void Timer()
        {
            string uDefenseKey = Convert.ToString(character.defenseKey).ToUpper();
            character.loopValue = 500;
            character.dodgecount = 0;
            UI(0, "Du wirst von " + character.enemyname + " angegriffen! Um die Attacke abzuweichen, spam '" + uDefenseKey + "' mindestens 8 Mal in 2 Sekunden!", true, true);
            timer = new System.Timers.Timer(2000);
            timer.Elapsed += Timer_Elapsed;
            timer.AutoReset = false;
            timer.Start();
            
            for (int i = 0; i < character.loopValue; i++)
            {
            
            info = Console.ReadKey(true);
            if (info.KeyChar == character.defenseKey)
            {
            character.dodgecount++;
            }
            }
                
        }

        private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (character.dodgecount >= 8)
            {
                character.mcHit = false;
                UI(0, "Du hast die Attacke entwichen! ", true, true);
                Thread.Sleep(500);
                character.loopValue = 9;
            }
            else
            {
                character.mcHit = true;
                Random random = new Random();
                character.enemydamage = random.Next(10, 30);
                character.health = character.health - character.enemydamage;
                UI(0, "Du wurdest getroffen!", true, true);
                Thread.Sleep(500);
                character.loopValue = 1;
            }
        } 

        static void UI(int nameOnBox, string message, bool enemyPresence, bool onMenu)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("    " + character.Name + "                                                 " + character.experience + " XP" + "                                                 " + character.health + "/100 HP"); // Info-Bar. Sollte immer vorhanden sein.
            if (enemyPresence == true)
            {
                for (int x = 0; x < 11; x++)
                {   
                    Console.WriteLine();
                }
                Console.WriteLine("                                                                                          ______________________________");
                Console.WriteLine("                                                                                          |");
                Console.WriteLine("                                                                                          |  " + character.enemyname);
                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine("                                                                                          |");
                }
                Console.WriteLine("                                                                                          |  " + character.enemyhealth + "/100 HP");
                Console.WriteLine("                                                                                          |");
            } 
            else
            {
                for (int i = 0; i < 19; i++)
                {
                    Console.WriteLine();
                }   
            }
            switch (nameOnBox)
            {
                case 0:
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                break;

                case 1:
                Console.WriteLine("    " + character.Name);
                Console.ForegroundColor = ConsoleColor.Green;
                break;

                case 2:
                Console.WriteLine("    " + character.enemyname);
                Console.ForegroundColor = ConsoleColor.Red;
                break;

                case 3:
                Console.WriteLine("    " + @"TE(!!%§$=&*'YMEF²@IWAD(/${{³]²}§%$!§(%$BDWGAIAD--:::");
                Console.ForegroundColor = ConsoleColor.Red;
                break;
            }
            Console.WriteLine(@"________________________________________________________________________________________________________________________");
            for (int x = 0; x < 3; x++)
                {   
                    Console.WriteLine();
                }
            Console.WriteLine("    " + message);
            if (onMenu == false)
            {
                Console.ReadKey(true);
            }
            
        }

        
        static void CentralManagement(bool firstBoot)
        {
        if (firstBoot == true)
        {
            Console.WriteLine("\nCentral Management Method Program");
        }
        Console.WriteLine("\nMain - a - Intro, Geschichte und Parametergebung");
        Console.WriteLine("Kampf - b - Kampf, Name ist voreingestellt auf AZ und Kampfintro ist übersprungen");
        character.Name = "AZ";
        character.skipIntro = true;
        Console.Write("\nC:\\>");
        var input = Console.ReadLine();
        if (input == "a")
        {
            Main(null);
        }
        if (input == "b")
        {
            Kampf();
        }  
}

        static void Geschichte()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Eines Tages lebten Elche und Rehe friedlich zusammen in Harmonie auf einer von dem Rest des Planeten unbekannten Insel.");
            Thread.Sleep(6300);
            Console.WriteLine();
            Console.WriteLine("Die eng befreundeten Königreiche schienen und schienen, aber alles hell hat auch ein dunkel und so ging die Sonne der\ngoldenen Zeiten unter.");
            Thread.Sleep(6720);
            Console.WriteLine("Als Händler und Weltentdecker die Insel fanden, bevorzugten sie die Elche mehr als Rehe.");
            Thread.Sleep(4830);
            Console.WriteLine("Dies sorgte für eine Beneidung der Elche von den Rehen, denn die Elche waren die mit Abstand reichsten Wesen auf der\nInsel während die Rehe vergleichsweise arm waren.");
            Thread.Sleep(7370);
            Console.WriteLine("Aus diesem Grund wurde von den Rehen ein Attentat auf den Elchkönig geplant. Dies wäre nicht so schlimm gewesen, wenn\ndie Elche nicht dabei wären, eine Organisation zu gründen, wo die Rehe vom Einkommen der Elche etwas abbekommen könnten,aber sie waren dran.");
            Thread.Sleep(13830);
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("In einer Nacht schlichen sich eine Gruppe von Rehen ins Palast der Elche rein und");
            Thread.Sleep(4000);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" töteten den Elchkönig.");
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(3000);
            Console.WriteLine();
            Console.WriteLine("Am Morgen herrschte Chaos und Verzweiflung, aber durch Spurenmessung konnte man erkennen, dass dies Rehe gewesen sind.");
            Thread.Sleep(6000);
            Console.WriteLine("Aber als diese Entdeckung gemacht war, war es schon zu spät. ");
            Thread.Sleep(3450);
            Console.WriteLine("Die Rehe marschierten in großen Armeen in die Richtung der Elche.");
            Thread.Sleep(4000);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Es ist Zeit, zu kämpfen.");
            Thread.Sleep(3000);
            Console.ReadKey(true);
            Console.ForegroundColor = ConsoleColor.White;
            Title();
        }
        
        static void Title() // Ab hier beginnt das "Spiel", hier das Intro davon. Das ist die ineffizienteste Scheiße die ich je gemacht habe aber was solls ;-;
        {
            Console.WindowWidth = 122;
            Console.Clear();
            Console.WriteLine(@"
██████╗ 
╚════██╗
 █████╔╝
██╔═══╝ 
███████╗ ███████╗
╚══════╝ ╚══════╝");
            Thread.Sleep(10);
            Console.Clear();
            Console.WriteLine(@"

██████╗  ██████╗    
╚════██╗██╔════╝    
 █████╔╝███████╗    
██╔═══╝ ██╔═══██╗   
███████╗╚██████╔╝ ███████╗
╚══════╝ ╚═════╝  ╚══════╝");
            Thread.Sleep(10);
            Console.Clear();
            Console.WriteLine(@"

██████╗  ██████╗         
╚════██╗██╔════╝        
 █████╔╝███████╗           
██╔═══╝ ██╔═══██╗          
███████╗╚██████╔╝██╗ ███████╗       
╚══════╝ ╚═════╝ ╚═╝ ╚══════╝");
            Thread.Sleep(10);
            Console.Clear();
            Console.WriteLine(@"

██████╗  ██████╗         ██████╗     
╚════██╗██╔════╝        ██╔═══██╗   
 █████╔╝███████╗        ██║   ██║          
██╔═══╝ ██╔═══██╗       ██║   ██║           
███████╗╚██████╔╝██╗    ╚██████╔╝     
╚══════╝ ╚═════╝ ╚═╝     ╚═════╝");
            Thread.Sleep(10);
            Console.Clear();
            Console.WriteLine(@"

██████╗  ██████╗         ██████╗ ██╗  ██╗    
╚════██╗██╔════╝        ██╔═══██╗██║ ██╔╝   
 █████╔╝███████╗        ██║   ██║█████╔╝          
██╔═══╝ ██╔═══██╗       ██║   ██║██╔═██╗           
███████╗╚██████╔╝██╗    ╚██████╔╝██║  ██╗     
╚══════╝ ╚═════╝ ╚═╝     ╚═════╝ ╚═╝  ╚═╝");
            Thread.Sleep(10);
            Console.Clear();
            Console.WriteLine(@"

██████╗  ██████╗         ██████╗ ██╗  ██╗████████╗    
╚════██╗██╔════╝        ██╔═══██╗██║ ██╔╝╚══██╔══╝   
 █████╔╝███████╗        ██║   ██║█████╔╝    ██║       
██╔═══╝ ██╔═══██╗       ██║   ██║██╔═██╗    ██║         
███████╗╚██████╔╝██╗    ╚██████╔╝██║  ██╗   ██║   
╚══════╝ ╚═════╝ ╚═╝     ╚═════╝ ╚═╝  ╚═╝   ╚═╝");
            Thread.Sleep(10);
            Console.Clear();
            Console.WriteLine(@"

██████╗  ██████╗         ██████╗ ██╗  ██╗████████╗ ██████╗     
╚════██╗██╔════╝        ██╔═══██╗██║ ██╔╝╚══██╔══╝██╔═══██╗    
 █████╔╝███████╗        ██║   ██║█████╔╝    ██║   ██║   ██║    
██╔═══╝ ██╔═══██╗       ██║   ██║██╔═██╗    ██║   ██║   ██║      
███████╗╚██████╔╝██╗    ╚██████╔╝██║  ██╗   ██║   ╚██████╔╝ ███████╗ 
╚══════╝ ╚═════╝ ╚═╝     ╚═════╝ ╚═╝  ╚═╝   ╚═╝    ╚═════╝  ╚══════╝");
            Thread.Sleep(10);
            Console.Clear();
            Console.WriteLine(@"

██████╗  ██████╗         ██████╗ ██╗  ██╗████████╗ ██████╗ ██████╗     
╚════██╗██╔════╝        ██╔═══██╗██║ ██╔╝╚══██╔══╝██╔═══██╗██╔══██╗    
 █████╔╝███████╗        ██║   ██║█████╔╝    ██║   ██║   ██║██████╔╝     
██╔═══╝ ██╔═══██╗       ██║   ██║██╔═██╗    ██║   ██║   ██║██╔══██╗       
███████╗╚██████╔╝██╗    ╚██████╔╝██║  ██╗   ██║   ╚██████╔╝██████╔╝ ███████╗
╚══════╝ ╚═════╝ ╚═╝     ╚═════╝ ╚═╝  ╚═╝   ╚═╝    ╚═════╝ ╚═════╝  ╚══════╝");
            Thread.Sleep(10);
            Console.Clear();
            Console.WriteLine(@"

██████╗  ██████╗         ██████╗ ██╗  ██╗████████╗ ██████╗ ██████╗ ███████╗    
╚════██╗██╔════╝        ██╔═══██╗██║ ██╔╝╚══██╔══╝██╔═══██╗██╔══██╗██╔════╝    
 █████╔╝███████╗        ██║   ██║█████╔╝    ██║   ██║   ██║██████╔╝█████╗     
██╔═══╝ ██╔═══██╗       ██║   ██║██╔═██╗    ██║   ██║   ██║██╔══██╗██╔══╝        
███████╗╚██████╔╝██╗    ╚██████╔╝██║  ██╗   ██║   ╚██████╔╝██████╔╝███████╗ ███████╗  
╚══════╝ ╚═════╝ ╚═╝     ╚═════╝ ╚═╝  ╚═╝   ╚═╝    ╚═════╝ ╚═════╝ ╚══════╝ ╚══════╝");
            Thread.Sleep(10);
            Console.Clear();
            Console.WriteLine(@"

██████╗  ██████╗         ██████╗ ██╗  ██╗████████╗ ██████╗ ██████╗ ███████╗██████╗     
╚════██╗██╔════╝        ██╔═══██╗██║ ██╔╝╚══██╔══╝██╔═══██╗██╔══██╗██╔════╝██╔══██╗    
 █████╔╝███████╗        ██║   ██║█████╔╝    ██║   ██║   ██║██████╔╝█████╗  ██████╔╝    
██╔═══╝ ██╔═══██╗       ██║   ██║██╔═██╗    ██║   ██║   ██║██╔══██╗██╔══╝  ██╔══██╗      
███████╗╚██████╔╝██╗    ╚██████╔╝██║  ██╗   ██║   ╚██████╔╝██████╔╝███████╗██║  ██║    
╚══════╝ ╚═════╝ ╚═╝     ╚═════╝ ╚═╝  ╚═╝   ╚═╝    ╚═════╝ ╚═════╝ ╚══════╝╚═╝  ╚═╝");
            Thread.Sleep(10);
            Console.Clear();
            Console.WriteLine(@"

██████╗  ██████╗         ██████╗ ██╗  ██╗████████╗ ██████╗ ██████╗ ███████╗██████╗     ██████╗ 
╚════██╗██╔════╝        ██╔═══██╗██║ ██╔╝╚══██╔══╝██╔═══██╗██╔══██╗██╔════╝██╔══██╗    ╚════██╗
 █████╔╝███████╗        ██║   ██║█████╔╝    ██║   ██║   ██║██████╔╝█████╗  ██████╔╝     █████╔╝
██╔═══╝ ██╔═══██╗       ██║   ██║██╔═██╗    ██║   ██║   ██║██╔══██╗██╔══╝  ██╔══██╗    ██╔═══╝   
███████╗╚██████╔╝██╗    ╚██████╔╝██║  ██╗   ██║   ╚██████╔╝██████╔╝███████╗██║  ██║    ███████╗
╚══════╝ ╚═════╝ ╚═╝     ╚═════╝ ╚═╝  ╚═╝   ╚═╝    ╚═════╝ ╚═════╝ ╚══════╝╚═╝  ╚═╝    ╚══════╝");
            Thread.Sleep(10);
            Console.Clear();
            Console.WriteLine(@"

██████╗  ██████╗         ██████╗ ██╗  ██╗████████╗ ██████╗ ██████╗ ███████╗██████╗     ██████╗  ██████╗ 
╚════██╗██╔════╝        ██╔═══██╗██║ ██╔╝╚══██╔══╝██╔═══██╗██╔══██╗██╔════╝██╔══██╗    ╚════██╗██╔═████╗
 █████╔╝███████╗        ██║   ██║█████╔╝    ██║   ██║   ██║██████╔╝█████╗  ██████╔╝     █████╔╝██║██╔██║
██╔═══╝ ██╔═══██╗       ██║   ██║██╔═██╗    ██║   ██║   ██║██╔══██╗██╔══╝  ██╔══██╗    ██╔═══╝ ████╔╝██║  
███████╗╚██████╔╝██╗    ╚██████╔╝██║  ██╗   ██║   ╚██████╔╝██████╔╝███████╗██║  ██║    ███████╗╚██████╔╝
╚══════╝ ╚═════╝ ╚═╝     ╚═════╝ ╚═╝  ╚═╝   ╚═╝    ╚═════╝ ╚═════╝ ╚══════╝╚═╝  ╚═╝    ╚══════╝ ╚═════╝");
            Thread.Sleep(10);
            Console.Clear();
            Console.WriteLine(@"

██████╗  ██████╗         ██████╗ ██╗  ██╗████████╗ ██████╗ ██████╗ ███████╗██████╗     ██████╗  ██████╗ ██╗  ██╗
╚════██╗██╔════╝        ██╔═══██╗██║ ██╔╝╚══██╔══╝██╔═══██╗██╔══██╗██╔════╝██╔══██╗    ╚════██╗██╔═████╗╚██╗██╔╝
 █████╔╝███████╗        ██║   ██║█████╔╝    ██║   ██║   ██║██████╔╝█████╗  ██████╔╝     █████╔╝██║██╔██║ ╚███╔╝ 
██╔═══╝ ██╔═══██╗       ██║   ██║██╔═██╗    ██║   ██║   ██║██╔══██╗██╔══╝  ██╔══██╗    ██╔═══╝ ████╔╝██║ ██╔██╗  
███████╗╚██████╔╝██╗    ╚██████╔╝██║  ██╗   ██║   ╚██████╔╝██████╔╝███████╗██║  ██║    ███████╗╚██████╔╝██╔╝ ██╗ ███████╗
╚══════╝ ╚═════╝ ╚═╝     ╚═════╝ ╚═╝  ╚═╝   ╚═╝    ╚═════╝ ╚═════╝ ╚══════╝╚═╝  ╚═╝    ╚══════╝ ╚═════╝ ╚═╝  ╚═╝ ╚══════╝");
            Thread.Sleep(10);
            Console.Clear();
            Console.WriteLine(@"

██████╗  ██████╗         ██████╗ ██╗  ██╗████████╗ ██████╗ ██████╗ ███████╗██████╗     ██████╗  ██████╗ ██╗  ██╗██╗  ██╗
╚════██╗██╔════╝        ██╔═══██╗██║ ██╔╝╚══██╔══╝██╔═══██╗██╔══██╗██╔════╝██╔══██╗    ╚════██╗██╔═████╗╚██╗██╔╝╚██╗██╔╝
 █████╔╝███████╗        ██║   ██║█████╔╝    ██║   ██║   ██║██████╔╝█████╗  ██████╔╝     █████╔╝██║██╔██║ ╚███╔╝  ╚███╔╝ 
██╔═══╝ ██╔═══██╗       ██║   ██║██╔═██╗    ██║   ██║   ██║██╔══██╗██╔══╝  ██╔══██╗    ██╔═══╝ ████╔╝██║ ██╔██╗  ██╔██╗ 
███████╗╚██████╔╝██╗    ╚██████╔╝██║  ██╗   ██║   ╚██████╔╝██████╔╝███████╗██║  ██║    ███████╗╚██████╔╝██╔╝ ██╗██╔╝ ██╗
╚══════╝ ╚═════╝ ╚═╝     ╚═════╝ ╚═╝  ╚═╝   ╚═╝    ╚═════╝ ╚═════╝ ╚══════╝╚═╝  ╚═╝    ╚══════╝ ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═╝");
            Thread.Sleep(10);
            Console.ReadKey(true);
            Kampf();
        }

        static void Intro()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WindowWidth = 165;
            Console.WriteLine(@"
 █████╗ ███████╗███╗   ███╗██╗███╗   ██╗██████╗ ██████╗  ██████╗ ███╗   ███╗ █████╗     ██████╗ ██████╗ ███████╗███████╗███████╗███╗   ██╗████████╗███████╗         
██╔══██╗╚══███╔╝████╗ ████║██║████╗  ██║██╔══██╗██╔══██╗██╔═══██╗████╗ ████║██╔══██╗    ██╔══██╗██╔══██╗██╔════╝██╔════╝██╔════╝████╗  ██║╚══██╔══╝██╔════╝         
███████║  ███╔╝ ██╔████╔██║██║██╔██╗ ██║██║  ██║██████╔╝██║   ██║██╔████╔██║███████║    ██████╔╝██████╔╝█████╗  ███████╗█████╗  ██╔██╗ ██║   ██║   ███████╗         
██╔══██║ ███╔╝  ██║╚██╔╝██║██║██║╚██╗██║██║  ██║██╔══██╗██║   ██║██║╚██╔╝██║██╔══██║    ██╔═══╝ ██╔══██╗██╔══╝  ╚════██║██╔══╝  ██║╚██╗██║   ██║   ╚════██║         
██║  ██║███████╗██║ ╚═╝ ██║██║██║ ╚████║██████╔╝██║  ██║╚██████╔╝██║ ╚═╝ ██║██║  ██║    ██║     ██║  ██║███████╗███████║███████╗██║ ╚████║   ██║   ███████║██╗██╗██╗
╚═╝  ╚═╝╚══════╝╚═╝     ╚═╝╚═╝╚═╝  ╚═══╝╚═════╝ ╚═╝  ╚═╝ ╚═════╝ ╚═╝     ╚═╝╚═╝  ╚═╝    ╚═╝     ╚═╝  ╚═╝╚══════╝╚══════╝╚══════╝╚═╝  ╚═══╝   ╚═╝   ╚══════╝╚═╝╚═╝╚═╝");
            Thread.Sleep(1000);
            Console.WindowWidth = 170;
            Console.WriteLine(@"
████████╗██╗  ██╗███████╗    ███╗   ███╗ ██████╗  ██████╗ ███████╗███████╗    ██████╗ ███████╗ █████╗ ██████╗     ██╗    ██╗ █████╗ ██████╗     ██████╗ ██████╗  ██████╗ 
╚══██╔══╝██║  ██║██╔════╝    ████╗ ████║██╔═══██╗██╔═══██╗██╔════╝██╔════╝    ██╔══██╗██╔════╝██╔══██╗██╔══██╗    ██║    ██║██╔══██╗██╔══██╗    ██╔══██╗██╔══██╗██╔════╝ 
   ██║   ███████║█████╗      ██╔████╔██║██║   ██║██║   ██║███████╗█████╗█████╗██║  ██║█████╗  ███████║██████╔╝    ██║ █╗ ██║███████║██████╔╝    ██████╔╝██████╔╝██║  ███╗
   ██║   ██╔══██║██╔══╝      ██║╚██╔╝██║██║   ██║██║   ██║╚════██║██╔══╝╚════╝██║  ██║██╔══╝  ██╔══██║██╔══██╗    ██║███╗██║██╔══██║██╔══██╗    ██╔══██╗██╔═══╝ ██║   ██║
   ██║   ██║  ██║███████╗    ██║ ╚═╝ ██║╚██████╔╝╚██████╔╝███████║███████╗    ██████╔╝███████╗██║  ██║██║  ██║    ╚███╔███╔╝██║  ██║██║  ██║    ██║  ██║██║     ╚██████╔╝
   ╚═╝   ╚═╝  ╚═╝╚══════╝    ╚═╝     ╚═╝ ╚═════╝  ╚═════╝ ╚══════╝╚══════╝    ╚═════╝ ╚══════╝╚═╝  ╚═╝╚═╝  ╚═╝     ╚══╝╚══╝ ╚═╝  ╚═╝╚═╝  ╚═╝    ╚═╝  ╚═╝╚═╝      ╚═════╝");
            Console.WriteLine();
            Console.WriteLine("                                                                      PRESS ENTER TO START");
            Console.ReadKey(true);
        }

}
}
