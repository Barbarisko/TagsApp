using System;
using System.Collections.Generic;
using System.Text;

namespace TagsApp
{
    public static class PrintOut
    {
        public static void ShowTags(Field f)
        {
            Console.Write("|   |");

            for (int j = 1; j <= f.Length; j++)
            {
                Console.Write("{0, 3}|", j);// 0 - index in possible array j. but j is only value
                                            // 3 - space for a number
            }
            Console.Write("\n");

            for (int j = 1; j <= f.Length; j++)
            {
                Console.Write("+---");
            }
            Console.Write("+----\n");

            for (int i = 0; i < f.Width; i++)
            {
                Console.Write("|{0, 3}|", Utils.indexToChar(i));
                for (int j = 0; j < f.Length; j++)
                {
                    if (f.Tags[i, j].Name == Tag.Empty)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.Write("{0, 3}", f.Tags[i, j].Name);
                        Console.ResetColor();
                        Console.Write("|");
                        continue;
                    }
                    Console.Write("{0, 3}|", f.Tags[i, j].Name);

                }
                Console.Write("\n");
            }
        }

        public static void PrintMenu()
        {
            Console.WriteLine("There are 3 variants of gameplay: " +
                "\n1 - randomly mixed" +
                "\n2 - backward count" +
                "\n3 - hard mode" +
                "\n choose one:");
        }
        public static void CustomizeSizeW()
        {
            Console.WriteLine("You can customize the field size. "
                + "\n input width: ");
        }
        public static void CustomizeSizeL()
        {
            Console.WriteLine(" length:");
        }
        public static void ShowRules()
        {
            Console.WriteLine("You can move tags, cancel move or give up." +
                "\nIf you want to cancel, type 'cancel'." +
                "\nIf you want to give up, type 'give up'" +
                "\nIf you want to move tag, input coords в формате а1 б2: ");
        }
        public static void GetNumOfSwapsText()
        {
            Console.WriteLine("You are about to have a randomly mixed field. " +
                "\nThe more you input, the harder it will be to solve the game." +
                "\nInput a number of random swaps:  ");
        }
        public static void GetChanceOfRndcancelText()
        {
            Console.WriteLine("It's a hard mode. There's a chance your move will be randomly canceled. " +
                "\n The higher number you input, the higher chance it will get" +
                "\n input number:");
        }
        public static void Restart()
        {
            Console.WriteLine("Back to the main menu.");
            Console.WriteLine();
        }
        public static void Win()
        {
            Console.WriteLine("You have won!");
        }
    }
}
