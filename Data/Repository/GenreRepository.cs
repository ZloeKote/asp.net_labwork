using LabWork.Data.Interfaces;
using LabWork.Data.Models;
using System.Collections.Generic;

namespace LabWork.Data.Repository
{
    public class GenreRepository : IGenre
    {
        private readonly AppDBContent appDBContent;
        public GenreRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public IEnumerable<Genre> getGenres => appDBContent.Genre;
    }
}
