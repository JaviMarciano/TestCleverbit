using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestCleverbit.Domain.Entities;
using TestCleverbit.Domain.Repositories;
using TestCleverbit.Domain.Services.Contracts;

namespace TestCleverbit.Domain.Services
{
    public class GameService : IGameService
    {
        private readonly IMatchRepository _matchRepository;
        private readonly IMatchItemRepository _matchItemRepository;

        public GameService(IMatchRepository matchRepository,
            IMatchItemRepository matchItemRepository)
        {
            _matchRepository = matchRepository;
            _matchItemRepository = matchItemRepository;
        }
        private async Task<Match> GetCurrentMatch()
        {
            var matches = await _matchRepository.GetAllAsync();
            var currentTime = DateTime.Now;
            return matches.ToList().OrderBy(x => x.Expiration).FirstOrDefault(x => x.Expiration > currentTime);
        }

        public async Task Play(int number, string currentUser)
        {
            var currentMatch = await GetCurrentMatch();
            if (currentMatch == null) throw new Exception("there is no available match");

            var matchItem = new MatchItem
            {
                MatchId = currentMatch.Id,
                email = currentUser,
                Number = number
            };

            await _matchItemRepository.AddAsync(matchItem);
        }

        public Task<List<Match>> GetAllMatches()
        {
            return _matchRepository.GetAllMatches();
        }
    }
}
