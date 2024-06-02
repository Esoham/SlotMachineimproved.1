using System;
namespace SlotMachineUltra
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Messages.WELCOME_MESSAGE);

            SlotMachineGame game = new SlotMachineGame();

            while (true)
            {
                SlotMachineUI.DisplayCurrentMoney(game.PlayerMoney);

                game.GenerateGrid();
                string[,] grid = game.GetGrid();
                SlotMachineUI.DisplayGrid(grid);

                int linesToBet = game.GetLinesToBet();

                int wagerPerLine = SlotMachineUI.GetWagerPerLine();
                int totalWager = wagerPerLine * linesToBet;

                if (totalWager > game.PlayerMoney)
                {
                    Console.WriteLine(Messages.INVALID_WAGER_MESSAGE);
                    continue;
                }

                game.DeductWager(totalWager);

                BetChoice betChoice = SlotMachineUI.GetPlayerChoice();

                int winnings = game.CalculateWinnings(betChoice, wagerPerLine);
                game.AddWinnings(winnings);

                SlotMachineUI.DisplayResult(grid, winnings, totalWager, betChoice);

                if (game.IsPlayerOutOfMoney())
                {
                    SlotMachineUI.DisplayGameOver();
                    break;
                }

                if (!SlotMachineUI.PlayAgain())
                {
                    break;
                }
            }
        }
    }
}
