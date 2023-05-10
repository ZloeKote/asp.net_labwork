using LabWork.Data.Interfaces;
using LabWork.Data.Models;
using System.Collections.Generic;

namespace LabWork.Data.Mocks
{
    public class MockGameKey : IGameKey
    {

        public IEnumerable<GameKey> KeysByCopyNotActivated => throw new System.NotImplementedException();

        public GameKey KeyById(int id)
        {
            var keys = getKeys();
            foreach (var key in keys)
            {
                if (key.Id == id) return key;
            }
            return null;
        }

        public int numKeysByDigitalId(int digitalId, int orderId)
        {
            throw new System.NotImplementedException();
        }

        private IEnumerable<GameKey> getKeys()
        {
            return new List<GameKey>
                {
                    new GameKey
                    {
                        Id = 0,
                        gameKey = "ABCDE-FGHJK-LMNOP-Q7STU-VW4YZ",
                        expiredDate = "2024-06-02",
                        digitalCopyId = 0,
                        IsActivated = false
                    },
                    new GameKey
                    {
                        Id = 1,
                        gameKey = "12fxk6hg",
                        expiredDate = "2026-02-07",
                        digitalCopyId = 1,
                        IsActivated = false
                    },
                    new GameKey
                    {
                        Id = 2,
                        gameKey = "kcmxk8sm",
                        expiredDate = "2023-11-08",
                        digitalCopyId = 2,
                        IsActivated = false
                    },
                    new GameKey
                    {
                        Id = 3,
                        gameKey = "39RU5-K542G-0FM1N-8S4H2",
                        expiredDate = "2024-02-10",
                        digitalCopyId = 3,
                        IsActivated = false
                    },
                    new GameKey
                    {
                        Id = 4,
                        gameKey = "39RU5-K542G-092T1-6DT8N",
                        expiredDate = "2025-07-12",
                        digitalCopyId = 3,
                        IsActivated = false
                    }
                };
        }
    }
}
