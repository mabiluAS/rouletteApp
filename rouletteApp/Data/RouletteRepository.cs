using rouletteApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rouletteApp.Data
{
    public class RouletteRepository : IRouletteRepository
    {
        private IApplicationDbContext _dbContext { get; }
        private IApplicationReadDbConnection _readDbConnection { get; }
        private IApplicationWriteDbConnection _writeDbConnection { get; }

        public RouletteRepository(IApplicationDbContext dbContext, IApplicationReadDbConnection readDbConnection, IApplicationWriteDbConnection writeDbConnection) 
        {
            _dbContext = dbContext;
            _readDbConnection = readDbConnection;
            _writeDbConnection = writeDbConnection;
        }
        public async Task<List<Spin>> GetSpins()
        {
            string query = "SELECT * FROM Spins";
            var prevSpins = await _readDbConnection.QueryAsync<Spin>(query);
            return prevSpins.ToList();
        }

        public async Task<List<Bet>> PayoutBets(int winningNumber)
        {
            var payoutBetsQuery = $"UPDATE Bets SET Payout = Amount * NumberSelection WHERE NumberSelection = {winningNumber}";
            await _writeDbConnection.ExecuteAsync(payoutBetsQuery);

            string query = $"SELECT * FROM Bets WHERE NumberSelection = {winningNumber}";
            var winningBets = await _readDbConnection.QueryAsync<Bet>(query);
            return winningBets.ToList();
        }

        public async Task<Bet> PlaceBet(Bet bet)
        {
            var addBetQuery = $"INSERT INTO Bets(Amount, BetDate, NumberSelection, Payout ) VALUES('{bet.Amount}','{bet.BetDate}','{bet.NumberSelection}','{bet.Payout}');select last_insert_rowid();";
            var betId = await _writeDbConnection.QuerySingleAsync<int>(addBetQuery);

            if(betId == 0)
            {
                throw new Exception("Bet Failed!");
            }

            bet.Id = betId;

            return bet;
        }

        public async Task<int> Spin()
        {
            Random random = new Random();

            int spin = random.Next(0, 36);

            var addSpinQuery = $"INSERT INTO Spins(Number,TimeStamp) VALUES('{spin}','{DateTime.Now}')";
            await _writeDbConnection.ExecuteAsync(addSpinQuery);

            return spin;
        }
    }
}
