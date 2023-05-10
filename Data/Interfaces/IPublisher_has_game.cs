using LabWork.Data.Models;
using System.Collections.Generic;

namespace LabWork.Data.Interfaces
{
    public interface IPublisher_has_game
    {
        public IEnumerable<Publisher_has_game> publishers_has_game { get; }
    }
}
