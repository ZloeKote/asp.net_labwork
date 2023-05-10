using LabWork.Data.Models;
using System.Collections.Generic;

namespace LabWork.Data.Interfaces
{
    public interface IDeveloper
    {
        public IEnumerable<Developer> developers { get; }
    }
}
