using LabWork.Data.Interfaces;
using LabWork.Data.Models;
using System.Collections.Generic;

namespace LabWork.Data.Mocks
{
    public class MockGames : IGames
    {
        public IEnumerable<Game> allGames
        {
            get
            {
                return getGames();
            }
        }

        public Game gameById(int id)
        {
            var games = getGames();
            foreach (var game in games)
            {
                if (game.id == id) return game;
            }
            return null;
        }

        private List<Game> getGames()
        {
            return new List<Game>
                {
                    new Game
                    {
                        id = 0,
                        name = "The Witcher",
                        description = "Станьте Ґеральтом з Рівії, професійним мисливцем на чудовиськ, який опинився в павутині інтриг, сплетеній силами, що змагаються за панування над світом. Робіть непрості рішення та давайте раду наслідкам у грі, в якій вам випаде пережити надзвичайну історію.",
                        releaseDate = "2002-05-03",
                        cover_img_path = "/img/game_covers/cover_witcher.jpg",
                        genres =  "Action, RPG",
                        developers = "CD PROJECT RED",
                        publishers = "Ubisoft",
                        digitalCopies = new List<DigitalCopy>()

                    },
                    new Game
                    {
                        id = 1,
                        name = "The Witcher 2",
                        description = "Настав час невимовного хаосу. Могутні сили зіткнулися в невидимому протистоянні за владу і вплив. Північні королівства готуються до війни. Але військові походи не можуть завадити кривавій змові…",
                        releaseDate = "2008-03-06",
                        cover_img_path = "/img/game_covers/cover_witcher2.jpg",
                        genres = "Action",
                        developers = "CD PROJECT RED, Bethesda",
                        digitalCopies = new List<DigitalCopy>()
                    },
                    new Game
                    {
                        id = 2,
                        name = "The Witcher 3",
                        description = "Ви — Ґеральт із Рівії, найманий мисливець на чудовиськ. Перед вами цілий континент, просяклий війнами та заполонений різними потворами. Поточний контракт? Відшукайте Цірі — Дитя Пророцтва, живу зброю, що може докорінно змінити знаний світ.",
                        releaseDate = "2012-07-02",
                        cover_img_path = "/img/game_covers/cover_witcher3.jpg",
                        genres = "Action, RPG",
                        developers = "CD PROJECT RED, Bethesda",
                        publishers = "Ubisoft, EA Games",
                        digitalCopies = new List<DigitalCopy>()
                    }
                };
        }
    }
}
