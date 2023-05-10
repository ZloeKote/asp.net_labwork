using LabWork.Data.Interfaces;
using LabWork.Data.Models;
using System.Collections.Generic;

namespace LabWork.Data.Repository
{
    public class DeveloperRepository : IDeveloper
    {
        private readonly AppDBContent appDBContent;

        public DeveloperRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public IEnumerable<Developer> developers => appDBContent.Developer;
    }
}
