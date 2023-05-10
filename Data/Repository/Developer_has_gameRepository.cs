using LabWork.Data.Interfaces;
using LabWork.Data.Models;
using System.Collections.Generic;

namespace LabWork.Data.Repository
{
    public class Developer_has_gameRepository : IDeveloper_has_game
    {
        private readonly AppDBContent appDBContent;

        public Developer_has_gameRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public IEnumerable<Developer_has_game> developers_has_game => appDBContent.developer_has_game;
    }
}
