using LabWork.Data.Interfaces;
using LabWork.Data.Models;
using System.Collections.Generic;

namespace LabWork.Data.Mocks
{
    public class MockDigitalCopy : IDigitalCopy
    {
        public IEnumerable<DigitalCopy> allCopies 
        { 
            get 
            {
                return getCopies();
            } 
        }

        public IEnumerable<DigitalCopy> CopiesByGameId(int gameId)
        {
            return null;
        }

        public IEnumerable<DigitalCopy> CopiesByPlatform(string platform)
        {
            return null;
        }

        public DigitalCopy CopyById(int id)
        {
            var copies = getCopies();
            foreach (var copy in copies)
            {
                if (copy.Id == id)
                {
                    return copy;
                }
            }
            return null;
        }

        private List<DigitalCopy> getCopies()
        {
            return new List<DigitalCopy>
                {
                    new DigitalCopy
                    {
                        Id = 0,
                        price = 124.5,
                        platform = "Steam",
                        gameId = 0
                    },
                    new DigitalCopy
                    {
                        Id = 1,
                        price = 59,
                        platform = "GOG",
                        gameId = 1
                    },
                    new DigitalCopy
                    {
                        Id = 2,
                        price = 699,
                        platform = "GOG",
                        gameId = 2
                    },
                    new DigitalCopy
                    {
                        Id = 3,
                        price = 312,
                        platform = "Steam",
                        gameId = 2
                    },
                };
        }
    }
}
