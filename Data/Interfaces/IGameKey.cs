using LabWork.Data.Models;
using System.Collections.Generic;

namespace LabWork.Data.Interfaces
{
    public interface IGameKey
    {
        GameKey KeyById(int id);
        IEnumerable<GameKey> KeysByCopyNotActivated { get; }
        int numKeysByDigitalId(int digitalId, int orderId);
    }
}
