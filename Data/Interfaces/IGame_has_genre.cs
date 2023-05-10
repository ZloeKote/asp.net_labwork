using LabWork.Data.Models;
using System.Collections.Generic;

namespace LabWork.Data.Interfaces
{
    public interface IGame_has_genre
    {
        public IEnumerable<Game_has_genre> game_has_genres { get; }
    }
}
