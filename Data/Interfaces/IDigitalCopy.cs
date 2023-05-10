using LabWork.Data.Models;
using System.Collections.Generic;

namespace LabWork.Data.Interfaces
{
    public interface IDigitalCopy
    {
        IEnumerable<DigitalCopy> allCopies { get; }
        DigitalCopy CopyById(int id);
        IEnumerable<DigitalCopy> CopiesByGameId(int id);
        IEnumerable<DigitalCopy> CopiesByPlatform(string platform);
    }
}
