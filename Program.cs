using System;
using System.IO;
using static System.Console;

namespace RuinsOfArkanar
{
    class Program
    {
        private static string appPath = AppDomain.CurrentDomain.BaseDirectory;

        static void Main(string[] args)
        {
            Title = "Start";
            ChooseLanguageMenu();
            SetColorConsts();
            SetTitle();
            SetNonFileConsts();
            SetColor();
            Game.Init();
            Game.Intro();
        }

        static void ChooseLanguageMenu()
        {
            WriteLine("Lang:");
            WriteLine();
            WriteLine("1. English");
            WriteLine("2. Nederlands");
            WriteLine("3. Deutsch");
            WriteLine();
            Write(">> ");
            string choice = ReadLine();

            switch(choice)
            {
                case "1":
                    Game.Language = "en-US";
                    break;
                case "2":
                    Game.Language = "nl-NL";
                    break;
                case "3":
                    Game.Language = "de-DE";
                    break;
                default:
                    WriteLine("???");
                    WriteLine();
                    Write("↵ ");
                    ReadLine();
                    Clear();
                    ChooseLanguageMenu();
                    break;
            }
        }

        static void SetColorConsts()
        {
            using(StreamReader sr = new StreamReader($"files/colors/{Game.Language}.txt"))
            {
                ColorConsts.Blue = sr.ReadLine();
                ColorConsts.Cyan = sr.ReadLine();
                ColorConsts.Green = sr.ReadLine();
                ColorConsts.Magenta = sr.ReadLine();
                ColorConsts.Red = sr.ReadLine();
                ColorConsts.Yellow = sr.ReadLine();
            }
        }

        static void SetNonFileConsts()
        {
            switch(Game.Language)
            {
                case "en-US":
                    Consts.GoOnWithReturn = "Go on with return key ";
                    Consts.InvalidOption = "Option {0} is invalid.";
                    Consts.PreStartMsg = "Before starting you can choose a different color for the text.";
                    Consts.PreStartMsg += Environment.NewLine;
                    Consts.PreStartMsg += "Default value is white (recommended).";
                    Consts.MakeChoice = "Make your choice: ";
                    Consts.SpeciesDragon = "dragon";
                    Consts.SpeciesElf = "elf";
                    Consts.SpeciesHuman = "human";
                    Consts.DirLeft = "left";
                    Consts.DirMiddle = "middle";
                    Consts.DirRight = "right";
                    Consts.First = "first";
                    Consts.Second = "second";
                    Consts.Third = "third";
                    Consts.ElementFire = "fire";
                    Consts.ElementElectric = "electricity";
                    Consts.ElementWater = "water";
                    Consts.ElementUltimate = "fire, electricity and water";
                    // back
                    Consts.ChoiceBack = "b";
                    // solve
                    Consts.ChoiceSolve = "s";
                    break;
                case "nl-NL":
                    Consts.GoOnWithReturn = "Ga verder met de Enter-toets ";
                    Consts.InvalidOption = "De optie {0} is ongeldig.";
                    Consts.PreStartMsg = "Voor de start mag een andere kleur voor de tekst kiezen.";
                    Consts.PreStartMsg += Environment.NewLine;
                    Consts.PreStartMsg += "Het standaard is wit (aanbevolen).";
                    Consts.MakeChoice = "Maak alsjeblieft een keuze: ";
                    Consts.SpeciesDragon = "draak";
                    Consts.SpeciesElf = "elf";
                    Consts.SpeciesHuman = "mens";
                    Consts.DirLeft = "linkse";
                    Consts.DirMiddle = "middelste";
                    Consts.DirRight = "rechte";
                    Consts.First = "eerste";
                    Consts.Second = "tweede";
                    Consts.Third = "derde";
                    Consts.ElementFire = "vuur";
                    Consts.ElementElectric = "electriciteit";
                    Consts.ElementUltimate = "vuur, electriciteit en water";
                    Consts.ElementWater = "water";
                    // terug
                    Consts.ChoiceBack = "t";
                    // oplossen
                    Consts.ChoiceSolve = "o";
                    break;
                case "de-DE":
                    Consts.GoOnWithReturn = "Weiter mit Enter-Taste ";
                    Consts.InvalidOption = "Die Option {0} ist ungültig.";
                    Consts.PreStartMsg = "Vor dem Start kann eine andere Farbe für den Text gewählt werden.";
                    Consts.PreStartMsg += Environment.NewLine;
                    Consts.PreStartMsg += "Der Standard ist weiß (empfohlen).";
                    Consts.MakeChoice = "Bitte eine Wahl treffen: ";
                    Consts.SpeciesDragon = "Drache";
                    Consts.SpeciesElf = "Elf";
                    Consts.SpeciesHuman = "Mensch";
                    Consts.DirLeft = "linken";
                    Consts.DirMiddle = "mittleren";
                    Consts.DirRight = "rechten";
                    Consts.First = "ersten";
                    Consts.Second = "zweiten";
                    Consts.Third = "dritten";
                    Consts.ElementFire = "Feuer";
                    Consts.ElementElectric = "Elektrizität";
                    Consts.ElementWater = "Wasser";
                    Consts.ElementUltimate = "Feuer, Elektrizität und Wasser";
                    // zurück
                    Consts.ChoiceBack = "z";
                    // lösen
                    Consts.ChoiceSolve = "l";
                    break;
            }
        }

        static void SetTitle()
        {
            switch(Game.Language)
            {
                case "en-US":
                    Title = "Ruins of Arkanar";
                    break;
                case "nl-NL":
                    Title = "Ruïnes van Arkanar";
                    break;
                case "de-DE":
                    Title = "Ruinen von Arkanar";
                    break;
            }
        }
        
        static void SetColor()
        {
            WriteLine(Consts.PreStartMsg);
            WriteLine();
            WriteLine($"1. {ColorConsts.Blue}");
            WriteLine($"2. {ColorConsts.Cyan}");
            WriteLine($"3. {ColorConsts.Green}");
            WriteLine($"4. {ColorConsts.Magenta}");
            WriteLine($"5. {ColorConsts.Red}");
            WriteLine($"6. {ColorConsts.Yellow}");
            WriteLine();
            Write(Consts.MakeChoice);
            string choice = ReadLine();

            switch(choice)
            {
                case "1":
                    ForegroundColor = ConsoleColor.Blue;
                    break;
                case "2":
                    ForegroundColor = ConsoleColor.Cyan;
                    break;
                case "3":
                    ForegroundColor = ConsoleColor.Green;
                    break;
                case "4":
                    ForegroundColor = ConsoleColor.Magenta;
                    break;
                case "5":
                    ForegroundColor = ConsoleColor.Red;
                    break;
                case "6":
                    ForegroundColor = ConsoleColor.Yellow;
                    break;
                default:
                    ForegroundColor = ConsoleColor.White;
                    break;
            }

            Clear();
        }
    }
}