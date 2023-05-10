using LabWork.Data.Interfaces;
using LabWork.Data.Models;
using System.Collections.Generic;

namespace LabWork.Data.Repository
{
    public class Publisher_has_gameRepository : IPublisher_has_game
    {
        private readonly AppDBContent appDBContent;

        public Publisher_has_gameRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public IEnumerable<Publisher_has_game> publishers_has_game => appDBContent.publisher_has_game;
    }
}
