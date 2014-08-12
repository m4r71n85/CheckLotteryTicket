using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace LotteryTicket.Helpers
{
    public class Lottery
    {
        private int[] lotteryNumbers;
        private int[][] userNumbers = new int[4][];
        private int[] winnings;

        public Lottery(string lotteryNumbers, string[] userNumbers)
        {
            this.lotteryNumbers = ExtractNumbersFromString(lotteryNumbers);
            for (int i = 0; i < 4; i++)
            {
                this.userNumbers[i] = ExtractNumbersFromString(userNumbers[i]);
            }
        }
        public int[] LotteryNumbers
        {
            get { return lotteryNumbers; }
        }
        public int[][] UserNumbers
        {
            get { return userNumbers; }
        }
        public int[] Winings
        {
            get
            {
                if (winnings == null)
                {
                    this.SetWinnings();
                }
                return winnings;
            }
        }

        private void SetWinnings()
        {
            int numbersMet;
            winnings = new int[7];

            for (int i = 0; i < 4; i++)
            {
                numbersMet = 0;
                for (int j = 0; j < userNumbers[i].Length; j++)
                {
                    if (lotteryNumbers.Contains(userNumbers[i][j]))
                    {
                        numbersMet += 1;
                    }
                }
                winnings[numbersMet] += 1;
            }
        }
        private int[] ExtractNumbersFromString(string text)
        {
            string[] lines = Regex.Split(text, @"\D+");
            int[] numbers = new int[lines.Length];
            for (int i = 0; i < lines.Length; i++)
            {
                int.TryParse(lines[i], out numbers[i]);
            }

            return numbers;
        }

    }
}