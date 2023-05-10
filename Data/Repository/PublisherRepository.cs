using LabWork.Data.Interfaces;
using LabWork.Data.Models;
using System.Collections.Generic;

namespace LabWork.Data.Repository
{
    public class PublisherRepository : IPublisher
    {
        private readonly AppDBContent appDBContent;

        public PublisherRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public IEnumerable<Publisher> publishers =>appDBContent.Publisher;
    }
}
