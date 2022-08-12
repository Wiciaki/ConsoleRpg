namespace ProjektKD.Gui
{
    using System;
    using System.Collections.Generic;

    using ProjektKD.Entities.Heroes;

    public class ConsoleGui : GameGui
    {
        public ConsoleGui()
        {
            Console.Title = "Projekt RPG";
        }

        public override int ShowSelection(string title, string message, string[] options, Hero hero = null)
        {
            Console.Clear();

            if (hero != null)
            {
                Console.Write("\n\t" + "Health: ");
                PrintColoured($"{hero.Hp}/{hero.MaxHp}", ConsoleColor.Red);
                Console.Write("\t\tMana: ");
                PrintColoured($"{hero.Mana}/{hero.MaxMana}", ConsoleColor.DarkBlue);
            }

            PrintColoured("\n\n\t" + title + "\n\n", ConsoleColor.DarkYellow);
            
            if (message != null)
            {
                Console.WriteLine("\t" + message + "\n");
            }

            var keys = new List<ConsoleKey>();

            for (var i = 0; i < options.Length; i++)
            {
                Console.Write($"\t[{i + 1}] -> ");
                PrintColoured(options[i], ConsoleColor.Blue);
                Console.WriteLine();

                keys.Add((ConsoleKey)(i + 49));
            }

            ConsoleKey key;

            while (!keys.Contains(key = Console.ReadKey(true).Key))
            {
                PrintColoured("Niedozwolony znak!", ConsoleColor.Red);
                Console.WriteLine();
            }

            return (int)(key - 49);
        }

        private static void PrintColoured(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(message);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}