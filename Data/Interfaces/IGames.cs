using LabWork.Data.Models;
using System.Collections.Generic;

namespace LabWork.Data.Interfaces
{
    public interface IGames
    {
        IEnumerable<Game> allGames { get; }
        Game gameById(int id);
    }
}
