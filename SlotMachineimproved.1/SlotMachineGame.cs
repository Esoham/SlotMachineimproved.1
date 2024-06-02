using System;
using System.Collections.Generic;
namespace SlotMachineUltra
{
    public class SlotMachineGame
    {
        public int PlayerMoney { get; private set; }
        private string[,] grid;

        public SlotMachineGame()
        {
            PlayerMoney = Constants.STARTING_PLAYER_MONEY;
            grid = new string[Constants.GRID_SIZE, Constants.GRID_SIZE];
        }

        public void GenerateGrid()
        {
            Random random = new Random();
            for (int i = 0; i < Constants.GRID_SIZE; i++)
            {
                for (int j = 0; j < Constants.GRID_SIZE; j++)
                {
                    grid[i, j] = Constants.SYMBOLS[random.Next(Constants.SYMBOLS.Length)].ToString();
                }
            }
        }

        public int GetLinesToBet()
        {
            return Constants.GRID_SIZE;
        }

        public int CalculateWinnings(BetChoice betChoice, int wagerPerLine)
        {
            int matches = CheckMatches();
            return matches * wagerPerLine * Constants.WIN_MULTIPLIER;
        }

        private int CheckMatches()
        {
            int matches = 0;

            bool primaryDiagonalMatch = true;
            for (int i = 1; i < Constants.GRID_SIZE; i++)
            {
                if (grid[i, i] != grid[0, 0])
                {
                    primaryDiagonalMatch = false;
                    break;
                }
            }
            if (primaryDiagonalMatch)
            {
                matches++;
            }

            bool secondaryDiagonalMatch = true;
            for (int i = 1; i < Constants.GRID_SIZE; i++)
            {
                if (grid[i, Constants.GRID_SIZE - i - 1] != grid[0, Constants.GRID_SIZE - 1])
                {
                    secondaryDiagonalMatch = false;
                    break;
                }
            }
            if (secondaryDiagonalMatch)
            {
                matches++;
            }

            return matches;
        }

        public string[,] GetGrid()
        {
            return grid;
        }

        public void DeductWager(int totalWager)
        {
            PlayerMoney -= totalWager;
        }

        public void AddWinnings(int winnings)
        {
            PlayerMoney += winnings;
        }

        public bool IsPlayerOutOfMoney()
        {
            return PlayerMoney <= 0;
        }
    }
}
