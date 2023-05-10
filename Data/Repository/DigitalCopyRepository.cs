using LabWork.Data.Interfaces;
using LabWork.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace LabWork.Data.Repository
{
    public class DigitalCopyRepository : IDigitalCopy
    {
        private readonly AppDBContent appDBContent;

        public DigitalCopyRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public IEnumerable<DigitalCopy> allCopies => appDBContent.DigitalCopy;

        public IEnumerable<DigitalCopy> CopiesByGameId(int gameId)
        {
            return appDBContent.DigitalCopy.Where(p => p.gameId == gameId);
        }

        public IEnumerable<DigitalCopy> CopiesByPlatform(string platform)
        {
            return appDBContent.DigitalCopy.Where(p => p.platform == platform);
        }

        public DigitalCopy CopyById(int id)
        {
            return appDBContent.DigitalCopy.Where(p => p.Id == id).FirstOrDefault();
        }
    }
}
