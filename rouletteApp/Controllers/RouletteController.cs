using Microsoft.AspNetCore.Mvc;
using rouletteApp.Data;
using rouletteApp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace rouletteApp.Controllers
{
    [ApiController]
    public class RouletteController : ControllerBase
    {
        private readonly IRouletteRepository _repository;

        public RouletteController(IRouletteRepository rouletteRepository) 
        {
            _repository = rouletteRepository;
        }

        [Route("api/spins")]
        [HttpGet]
        public async Task<ActionResult<List<Spin>>> GetSpins() => await _repository.GetSpins();

        [Route("api/spin")]
        [HttpGet]
        public async Task<ActionResult<int>> Spin() => await _repository.Spin();

        [Route("api/bet")]
        [HttpPost]
        public async Task<ActionResult<Bet>> PlaceBet(Bet bet)
        {
            try
            {
               return await _repository.PlaceBet(bet);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }            
        }

        [Route("api/payout")]
        [HttpPatch]
        public async Task<ActionResult<List<Bet>>> PayoutBets(int winningNumber) => await _repository.PayoutBets(winningNumber);

    }
}
