using System;

namespace rouletteApp.Models
{
    public class Bet
    {
        public int Id { get; set; }

        public double Amount { get; set; }

        public double Payout { get; set; }

        public DateTime BetDate { get; set; }

        public int NumberSelection { get; set;}
    }
}
