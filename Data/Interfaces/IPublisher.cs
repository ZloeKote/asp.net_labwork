using LabWork.Data.Models;
using System.Collections.Generic;

namespace LabWork.Data.Interfaces
{
    public interface IPublisher
    {
        public IEnumerable<Publisher> publishers { get; }
    }
}
