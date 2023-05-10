using LabWork.Data.Models;
using System.Collections.Generic;

namespace LabWork.Data.Interfaces
{
    public interface IDeveloper_has_game
    {
        public IEnumerable<Developer_has_game> developers_has_game { get; }
    }
}
