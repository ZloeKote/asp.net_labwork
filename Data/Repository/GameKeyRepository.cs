using LabWork.Data.Interfaces;
using LabWork.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LabWork.Data.Repository
{
    public class GameKeyRepository : IGameKey
    {
        private readonly AppDBContent appDBContent;

        public GameKeyRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public IEnumerable<GameKey> KeysByCopyNotActivated => appDBContent.gameKey.Where(p => p.IsActivated == false);

        public GameKey KeyById(int id)
        {
            return appDBContent.gameKey.FirstOrDefault(p => p.Id == id);
        }

        public int numKeysByDigitalId(int digitalId, int orderId)
        {
            IEnumerable<int> tempList = appDBContent.gameKey.Where(p => p.digitalCopyId == digitalId).Select(u => u.Id);
            return appDBContent.orderBasket.Where(p => p.orderId == orderId && tempList.Contains(p.keyId)).Count();
        }
    }
}
