using System;

namespace SlotMachineUltra
{
    public static class SlotMachineUI
    {
        public static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        public static BetChoice GetPlayerChoice()
        {
            Console.WriteLine(Messages.CHOOSE_BET_MESSAGE);
            foreach (var choice in Enum.GetValues(typeof(BetChoice)))
            {
                Console.WriteLine($"{(int)choice}. {choice}");
            }

            while (true)
            {
                Console.Write(Messages.ENTER_CHOICE_MESSAGE);
                string? input = Console.ReadLine();
                if (int.TryParse(input, out int selectedChoice) && Enum.IsDefined(typeof(BetChoice), selectedChoice))
                {
                    return (BetChoice)selectedChoice;
                }
                Console.WriteLine(Messages.INVALID_CHOICE_MESSAGE);
            }
        }

        public static int GetWagerPerLine()
        {
            while (true)
            {
                Console.Write(string.Format(Messages.ENTER_WAGER_MESSAGE, Constants.DEFAULT_WAGER));
                string? input = Console.ReadLine();
                if (int.TryParse(input, out int wagerPerLine) && wagerPerLine >= Constants.MIN_WAGER && wagerPerLine <= Constants.DEFAULT_WAGER)
                {
                    return wagerPerLine;
                }
                Console.WriteLine(Messages.INVALID_WAGER_MESSAGE);
            }
        }

        public static void DisplayResult(string[,] grid, int winnings, int totalWager, BetChoice betChoice)
        {
            Console.WriteLine(Messages.SLOT_GRID_MESSAGE);
            for (int i = 0; i < Constants.GRID_SIZE; i++)
            {
                for (int j = 0; j < Constants.GRID_SIZE; j++)
                {
                    Console.Write(grid[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine(string.Format(Messages.WINNINGS_MESSAGE, winnings, totalWager, betChoice));
        }

        public static void DisplayGameRulesAndPayouts()
        {
            Console.WriteLine(Messages.GAME_RULES_MESSAGE);
        }

        public static void DisplayGameOver()
        {
            Console.WriteLine(Messages.GAME_OVER_MESSAGE);
        }

        public static bool PlayAgain()
        {
            Console.Write(Messages.PLAY_AGAIN_MESSAGE);
            string? choice = Console.ReadLine()?.ToLower();
            return choice == Messages.PLAY_AGAIN_YES_SHORT || choice == Messages.PLAY_AGAIN_YES_LONG;
        }

        public static void DisplayGrid(string[,] grid)
        {
            for (int i = 0; i < Constants.GRID_SIZE; i++)
            {
                for (int j = 0; j < Constants.GRID_SIZE; j++)
                {
                    Console.Write(grid[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public static void DisplayCurrentMoney(int money)
        {
            Console.WriteLine(string.Format(Messages.CURRENT_MONEY_MESSAGE, money));
        }
    }
}
