using System;
using System.IO;
using static System.Console;

namespace RuinsOfArkanar
{
    public static class Game
    {
        public static string Language { get; set; }
        private static string PlayerName { get; set; }
        private static string PlayerRace { get; set; }
        private static int Tries { get; set; }
        private static int RiddlesSolved { get; set; } = 0;

        public static void Init()
        {
            // caves and corridors
            GetFileContent($"files/{Language}/intro1.txt", 1);
            GetFileContent($"files/{Language}/intro2.txt", 2);
            GetFileContent($"files/{Language}/outtro.txt", 3);
            GetFileContent($"files/{Language}/corridorNode.txt", 4);
            GetFileContent($"files/{Language}/corridorRiddle.txt", 5);
            GetFileContent($"files/{Language}/deadEnd.txt", 6);
            GetFileContent($"files/{Language}/entrance.txt", 7);
            GetFileContent($"files/{Language}/guardianIntro.txt", 8);
            GetFileContent($"files/{Language}/guardianMissingRiddles.txt", 9);
            GetFileContent($"files/{Language}/guardianUltimateRiddle.txt", 10);
            GetFileContent($"files/{Language}/guardianOuttro.txt", 11);
            GetFileContent($"files/{Language}/riddleIntro.txt", 12);
            GetFileContent($"files/{Language}/riddleCorrect.txt", 13);
            GetFileContent($"files/{Language}/riddleWrong.txt", 14);
            GetFileContent($"files/{Language}/nodeTwo.txt", 19);
            GetFileContent($"files/{Language}/nodeThree.txt", 20);
            GetFileContent($"files/{Language}/returnToLastNode.txt", 21);
            
            // riddles
            GetFileContent($"files/{Language}/riddles/fire.txt", 15);
            GetFileContent($"files/{Language}/riddles/electric.txt", 16);
            GetFileContent($"files/{Language}/riddles/water.txt", 17);
            GetFileContent($"files/{Language}/riddles/ultimate.txt", 18);
        }

        private static void GetFileContent(string filename, int constant)
        {
            using(StreamReader sr = new StreamReader(filename))
            {
                switch(constant)
                {
                    case 1:
                        Consts.IntroOne = sr.ReadToEnd().TrimEnd(Environment.NewLine.ToCharArray());
                        break;
                    case 2:
                        Consts.IntroTwo = sr.ReadToEnd().TrimEnd(Environment.NewLine.ToCharArray());
                        break;
                    case 3:
                        Consts.Outtro = sr.ReadToEnd().TrimEnd(Environment.NewLine.ToCharArray());
                        break;
                    case 4:
                        Consts.CorridorNode = sr.ReadToEnd().TrimEnd(Environment.NewLine.ToCharArray());
                        break;
                    case 5:
                        Consts.CorridorRiddle = sr.ReadToEnd().TrimEnd(Environment.NewLine.ToCharArray());
                        break;
                    case 6:
                        Consts.DeadEnd = sr.ReadToEnd().TrimEnd(Environment.NewLine.ToCharArray());
                        break;
                    case 7:
                        Consts.Entrance = sr.ReadToEnd().TrimEnd(Environment.NewLine.ToCharArray());
                        break;
                    case 8:
                        Consts.GuardianIntro = sr.ReadToEnd().TrimEnd(Environment.NewLine.ToCharArray());
                        break;
                    case 9:
                        Consts.GuardianMissingRiddle = sr.ReadToEnd().TrimEnd(Environment.NewLine.ToCharArray());
                        break;
                    case 10:
                        Consts.GuardianUltimateRiddle = sr.ReadToEnd().TrimEnd(Environment.NewLine.ToCharArray());
                        break;
                    case 11:
                        Consts.GuardianOuttro = sr.ReadToEnd().TrimEnd(Environment.NewLine.ToCharArray());
                        break;
                    case 12:
                        Consts.RiddleIntro = sr.ReadToEnd().TrimEnd(Environment.NewLine.ToCharArray());
                        break;
                    case 13:
                        Consts.RiddleCorrect = sr.ReadToEnd().TrimEnd(Environment.NewLine.ToCharArray());
                        break;
                    case 14:
                        Consts.RiddleWrong = sr.ReadToEnd().TrimEnd(Environment.NewLine.ToCharArray());
                        break;
                    case 15:
                        Riddles.Fire = sr.ReadToEnd().TrimEnd(Environment.NewLine.ToCharArray());
                        break;
                    case 16:
                        Riddles.Electricity = sr.ReadToEnd().TrimEnd(Environment.NewLine.ToCharArray());
                        break;
                    case 17:
                        Riddles.Water = sr.ReadToEnd().TrimEnd(Environment.NewLine.ToCharArray());
                        break;
                    case 18:
                        Riddles.Ultimate = sr.ReadToEnd().TrimEnd(Environment.NewLine.ToCharArray());
                        break;
                    case 19:
                        Consts.NodeTwo = sr.ReadToEnd().TrimEnd(Environment.NewLine.ToCharArray());
                        break;
                    case 20:
                        Consts.NodeThree = sr.ReadToEnd().TrimEnd(Environment.NewLine.ToCharArray());
                        break;
                    case 21:
                        Consts.ReturnToLastNode = sr.ReadToEnd().TrimEnd(Environment.NewLine.ToCharArray());
                        break;
                }
            }
        }

        public static void Intro()
        {
            Write(Consts.IntroOne);
            PlayerName = ReadLine();
            WriteLine();
            Write(Consts.IntroTwo, PlayerName);
            PlayerRace = ReadLine();

            switch(PlayerRace)
            {
                case "1":
                    PlayerRace = Consts.SpeciesDragon;
                    break;
                case "2":
                    PlayerRace = Consts.SpeciesElf;
                    break;
                default:
                    PlayerRace = Consts.SpeciesHuman;
                    break;
            }

            Entrance();
        }

        private static void Outtro()
        {
            WriteLine();
            WriteLine(Consts.Outtro, PlayerRace, PlayerName, Tries);
            WriteLine();
            WriteLine(Consts.GoOnWithReturn);
            ReadLine();
        }

        private static void Entrance()
        {
            Clear();
            WriteLine();
            Write(Consts.Entrance, PlayerName);
            int choice = int.Parse(ReadLine());

            switch(choice)
            {
                // left corridor
                case 1:
                    Corridor(Consts.DirLeft, false, 1);
                    break;
                // middle corridor
                case 2:
                    Corridor(Consts.DirMiddle, false, 1);
                    break;
                // right corridor
                case 3:
                    Corridor(Consts.DirRight, true, 1);
                    break;
                default:
                    WriteLine(Consts.InvalidOption, choice);
                    WriteLine();
                    Write(Consts.GoOnWithReturn);
                    ReadLine();
                    Entrance();
                    break;
            }
        }

        private static void Corridor(string dir, bool isDeadEnd, int node)
        {
            Clear();

            if(isDeadEnd)
            {
                Tries++;
                WriteLine(Consts.DeadEnd, dir);
                ReadLine();

                switch(node)
                {
                    case 1:
                        Entrance();
                        break;
                    case 3:
                        ThirdNode();
                        break;
                    default:
                        SecondNode();
                        break;
                }
            }

            switch(node)
            {
                case 1:
                    if(dir == Consts.DirLeft)
                    {
                        RiddleIntro(dir, 1, 1);
                    }
                    else
                    {
                        SecondNode();
                    }
                    break;
                case 2:
                    if(dir == Consts.DirLeft)
                    {
                        ThirdNode();
                    }
                    else
                    {
                        RiddleIntro(dir, 2, 2);
                    }
                    break;
                case 3:
                    if(dir == Consts.DirLeft)
                    {
                        RiddleIntro(dir, 3, 3);
                    }
                    else
                    {
                        Corridor(dir, false, 4);
                    }
                    break;
                default:
                    ConfrontWithGuardian();
                    break;
            }
        }

        private static void ShowRiddle(int riddleId, int node)
        {
            /* riddleId's:
             * 1 = fire
             * 2 = electricity
             * 3 = water
             * 4 = ultimate riddle (contains all of them)
            */

            Tries++;
            Clear();

            switch(riddleId)
            {
                case 1:
                    RiddleOutput(riddleId, Consts.ElementFire, 1);
                    break;
                case 2:
                    RiddleOutput(riddleId, Consts.ElementElectric, 2);
                    break;
                default:
                    RiddleOutput(riddleId, Consts.ElementWater, 3);
                    break;
            }

            switch(node)
            {
                case 1:
                    SecondNode();
                    break;
                case 2:
                    ThirdNode();
                    break;
                default:
                    Corridor(Consts.DirLeft, false, 4);
                    break;
            }
        }

        private static void RiddleIntro(string dir, int node, int element)
        {
            Clear();
            Write(Consts.CorridorRiddle, dir);
            string choice = ReadLine().ToLower();

            if(choice == Consts.ChoiceBack)
            {
                switch(node)
                {
                    case 1:
                        // return to first node
                        Entrance();
                        break;
                    case 2:
                        // return to second node
                        SecondNode();
                        break;
                    default:
                        // return to third node
                        ThirdNode();
                        break;
                }
            }
            else if(choice == Consts.ChoiceSolve)
            {
                Clear();
                WriteLine();
                WriteLine(Consts.RiddleIntro);
                ReadLine();
                ShowRiddle(element, node);
            }
            else
            {
                WriteLine();
                WriteLine(Consts.InvalidOption, choice);
                WriteLine();
                WriteLine(Consts.GoOnWithReturn);
                ReadLine();
                RiddleIntro(dir, node, element);
            }
        }

        private static void RiddleOutput(int element, string correctAnswer, int node)
        {
            switch(element)
            {
                case 1:
                    Write(Riddles.Fire);
                    break;
                case 2:
                    Write(Riddles.Electricity);
                    break;
                case 3:
                    Write(Riddles.Water);
                    break;
                default:
                    Write(Riddles.Ultimate);
                    break;
            }
            
            string answer = ReadLine();

            if(answer == correctAnswer)
            {
                RiddlesSolved++;
                Clear();
                WriteLine(Consts.RiddleCorrect, answer);
                ReadLine();

                switch(node)
                {
                    case 1:
                        SecondNode();
                        break;
                    case 2:
                        ThirdNode();
                        break;
                    default:
                        Corridor(Consts.DirLeft, false, 4);
                        break;
                }
            }
            else
            {
                string returnToNode = Consts.First;

                if(node == 2)
                {
                    returnToNode = Consts.Second;
                }
                else if(node == 3)
                {
                    returnToNode = Consts.Third;
                }

                Clear();
                WriteLine(Consts.RiddleWrong, returnToNode);
                WriteLine();
                WriteLine(Consts.GoOnWithReturn);
                ReadLine();
                // return to last node ...

                switch(node)
                {
                    case 1:
                        Entrance();
                        break;
                    case 2:
                        SecondNode();
                        break;
                    default:
                        ThirdNode();
                        break;
                }
            }
        }

        private static void ConfrontWithGuardian()
        {
            Clear();
            WriteLine(Consts.GuardianIntro);
            WriteLine();
            Write(Consts.GoOnWithReturn);
            ReadLine();
            Clear();

            if(RiddlesSolved < 2)
            {
                int missing = 3 - RiddlesSolved;
                WriteLine(Consts.GuardianMissingRiddle, missing);
                WriteLine();
                Write(Consts.GoOnWithReturn);
                ReadLine();
                Entrance();
            }
            else if (RiddlesSolved == 2)
            {
                WriteLine(Consts.GuardianUltimateRiddle);
                WriteLine();
                WriteLine(Riddles.Ultimate);
                string answer = ReadLine();
                WriteLine();

                if(answer == Consts.ElementUltimate)
                {
                    Tries++;
                    Clear();
                    GuardianOuttro();
                }
                else
                {
                    string oldValue = GetOldValue();
                    string newValue = GetNewValue();
                    string value3 = GetValue3();

                    Clear();
                    WriteLine(Consts.RiddleWrong.Replace(oldValue, newValue).Replace(value3, ""), Consts.First);
                    ReadLine();
                    Entrance();
                }
            }
            else
            {
                Clear();
                GuardianOuttro();
            }
        }

        private static void GuardianOuttro()
        {
            string race = PlayerRace;

            switch(Language)
            {
                case "de-DE":
                    if(race == "Drache")
                    {
                        race += "n";
                    }
                    else
                    {
                        race += "en";
                    }
                    break;
                default:
                    race = race.ToLower();
                    break;
            }

            WriteLine(Consts.GuardianOuttro, race, PlayerName);
            WriteLine();
            Write(Consts.GoOnWithReturn);
            ReadLine();
            Clear();
            Outtro();
            Environment.Exit(0);
        }

        private static void SecondNode()
        {
            Clear();
            Write(Consts.NodeTwo);
            int choice = int.Parse(ReadLine());

            switch (choice)
            {
                case 1:
                    // left corridor
                    Corridor(Consts.DirLeft, false, 2);
                    break;
                case 2:
                    // right corridor
                    Corridor(Consts.DirRight, false, 2);
                    break;
                case 3:
                    Clear();
                    WriteLine(Consts.ReturnToLastNode, Consts.First);
                    WriteLine();
                    Write(Consts.GoOnWithReturn);
                    ReadLine();
                    Entrance();
                    break;
                default:
                    WriteLine(Consts.InvalidOption, choice);
                    WriteLine();
                    Write(Consts.GoOnWithReturn);
                    ReadLine();
                    SecondNode();
                    break;
            }
        }

        private static void ThirdNode()
        {
            Clear();
            Write(Consts.NodeThree);
            int choice = int.Parse(ReadLine());

            switch (choice)
            {
                case 1:
                    // left node
                    Corridor(Consts.DirLeft, false, 3);
                    break;
                case 2:
                    // middle corridor
                    Corridor(Consts.DirMiddle, true, 3);
                    break;
                case 3:
                    // right corridor
                    Corridor(Consts.DirRight, false, 3);
                    break;
                case 4:
                    WriteLine();
                    WriteLine(Consts.ReturnToLastNode, Consts.Second);
                    WriteLine();
                    Write(Consts.GoOnWithReturn);
                    ReadLine();
                    Entrance();
                    break;
                default:
                    WriteLine(Consts.InvalidOption, choice);
                    WriteLine();
                    Write(Consts.GoOnWithReturn);
                    ReadLine();
                    ThirdNode();
                    break;
            }
        }

        private static string GetOldValue()
        {
            // DONE: add languages nl-NL & en-US

            switch(Language)
            {
                case "de-DE":
                    return "Die leuchtende Kugel";
                case "en-US":
                    return "The glowing orb";
                case "nl-NL":
                    return "De gloeiende bal";
                default:
                    return String.Empty;
            }
        }

        private static string GetNewValue()
        {
            // DONE: add languages nl-NL & en-US

            switch(Language)
            {
                case "de-DE":
                    return "Der Wächter";
                case "en-US":
                    return "The guardian";
                case "nl-NL":
                    return "De bewaker";
                default:
                    return String.Empty;
            }
        }

        private static string GetValue3()
        {
            // DONE: add languages nl-NL & en-US
            
            switch(Language)
            {
                case "de-DE":
                    return " Hinter dir wird der Gang verschüttet.";
                case "en-US":
                    return " Behind you, the passage is shaken.";
                case "nl-NL":
                    return " Achter je, de doorgang is begraven.";
                default:
                    return String.Empty;
            }
        }
    }
}