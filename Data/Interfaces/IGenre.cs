using LabWork.Data.Models;
using System.Collections.Generic;

namespace LabWork.Data.Interfaces
{
    public interface IGenre
    {
        public IEnumerable<Genre> getGenres { get; }
    }
}
