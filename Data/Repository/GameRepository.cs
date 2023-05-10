using LabWork.Data.Interfaces;
using LabWork.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace LabWork.Data.Repository
{
    public class GameRepository : IGames
    {
        private readonly AppDBContent appDBContent;

        public GameRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public IEnumerable<Game> allGames => appDBContent.Game;

        public Game gameById(int id)
        {
            return appDBContent.Game.FirstOrDefault(p => p.id == id);
        }
    }
}
