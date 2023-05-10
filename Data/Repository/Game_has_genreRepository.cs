using LabWork.Data.Interfaces;
using LabWork.Data.Models;
using System.Collections.Generic;

namespace LabWork.Data.Repository
{
    public class Game_has_genreRepository : IGame_has_genre
    {
        private readonly AppDBContent appDBContent;

        public Game_has_genreRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public IEnumerable<Game_has_genre> game_has_genres => appDBContent.Game_has_genre;
    }
}
