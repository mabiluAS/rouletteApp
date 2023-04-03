using rouletteApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace rouletteApp.Data
{
    public interface IRouletteRepository
    {
        public Task<Bet> PlaceBet(Bet bet);

        public Task<int> Spin();

        public Task<List<Bet>> PayoutBets(int winningNumber);

        public Task<List<Spin>> GetSpins();
    }
}
