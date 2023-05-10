using LabWork.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace LabWork.Data
{
    public class DBObjects
    {
        //функція для підключення до БД
        public static void Initial(AppDBContent content)
        {
            //якщо не має жодної категорії, то додаємо категорії
            if (!content.DigitalCopy.Any())
            {
                content.DigitalCopy.AddRange(
                new DigitalCopy
                {
                    price = 124.5,
                    platform = "Steam",
                    gameId = 0
                },
                new DigitalCopy
                {
                    price = 59,
                    platform = "GOG",
                    gameId = 1
                },
                new DigitalCopy
                {
                    price = 699,
                    platform = "GOG",
                    gameId = 2
                },
                new DigitalCopy
                {
                    price = 312,
                    platform = "Steam",
                    gameId = 2
                });
            }
            //якщо не має жодного товару, то додаємо товар
            if (!content.Game.Any())
            {
                content.Game.AddRange(
                new Game
                {
                    name = "The Witcher",
                    description = "Станьте Ґеральтом з Рівії, професійним мисливцем на чудовиськ, який опинився в павутині інтриг, сплетеній силами, що змагаються за панування над світом. Робіть непрості рішення та давайте раду наслідкам у грі, в якій вам випаде пережити надзвичайну історію.",
                    releaseDate = "2002-05-03",
                    cover_img_path = "/img/game_covers/cover_witcher.jpg",
                },
                new Game
                {
                    name = "The Witcher 2",
                    description = "Настав час невимовного хаосу. Могутні сили зіткнулися в невидимому протистоянні за владу і вплив. Північні королівства готуються до війни. Але військові походи не можуть завадити кривавій змові…",
                    releaseDate = "2008-03-06",
                    cover_img_path = "/img/game_covers/cover_witcher2.jpg",
                },
                new Game
                {
                    name = "The Witcher 3",
                    description = "Ви — Ґеральт із Рівії, найманий мисливець на чудовиськ. Перед вами цілий континент, просяклий війнами та заполонений різними потворами. Поточний контракт? Відшукайте Цірі — Дитя Пророцтва, живу зброю, що може докорінно змінити знаний світ.",
                    releaseDate = "2012-07-02",
                    cover_img_path = "/img/game_covers/cover_witcher3.jpg",
                });
            }
            // Якщо немає жодного жанру в БД, то додаємо їх
            if (!content.Genre.Any())
            {
                content.Genre.AddRange(
                new Genre
                {
                    Name = "Action"
                },
                new Genre
                {
                    Name = "Adventure"
                },
                new Genre
                {
                    Name = "Fighting Games"
                },
                new Genre
                {
                    Name = "First-Person Shooter"
                },
                new Genre
                {
                    Name = "Flight/Flying"
                },
                new Genre
                {
                    Name = "Party"
                },
                new Genre
                {
                    Name = "Platformer"
                },
                new Genre
                {
                    Name = "Puzzle"
                },
                new Genre
                {
                    Name = "Racing"
                },
                new Genre
                {
                    Name = "Real-Time Strategy"
                },
                new Genre
                {
                    Name = "Role-Playing"
                },
                new Genre
                {
                    Name = "Simulation"
                },
                new Genre
                {
                    Name = "Sports"
                },
                new Genre
                {
                    Name = "Strategy"
                },
                new Genre
                {
                    Name = "Third-Person Shooter"
                },
                new Genre
                {
                    Name = "Turn-Based Strategy"
                },
                new Genre
                {
                    Name = "Wargames"
                },
                new Genre
                {
                    Name = "Wrestling"
                });
            }
            // Якщо немає жодного розробника в БД, то додаємо їх
            if (!content.Developer.Any())
            {
                content.Developer.AddRange(
                    new Developer
                    {
                        Name = "CD PROJECT RED"
                    },
                    new Developer
                    {
                        Name = "Bethesda"
                    }
                    );
            }
            // Якщо немає жодного видавця в БД, то додаємо їх
            if (!content.Publisher.Any())
            {
                content.Publisher.AddRange(
                    new Publisher
                    {
                        Name = "Ubisoft"
                    },
                    new Publisher
                    {
                        Name = "EA Games"
                    }
                    );
            }
            // Якщо жодна гра не має жодного жанру в БД, то додаємо їх
            if (!content.Game_has_genre.Any())
            {
                content.Game_has_genre.AddRange(
                    new Game_has_genre
                    {
                        gameId = 1,
                        genreId = 1
                    },
                    new Game_has_genre
                    {
                        gameId = 1,
                        genreId = 11
                    },
                    new Game_has_genre
                    {
                        gameId = 2,
                        genreId = 1
                    },
                    new Game_has_genre
                    {
                        gameId = 3,
                        genreId = 1
                    },
                    new Game_has_genre
                    {
                        gameId = 3,
                        genreId = 11
                    }
                    );
            }
            // Якщо в жодного розробника не має жодної гри в БД, то додаємо їх
            if (!content.developer_has_game.Any())
            {
                content.developer_has_game.AddRange(
                    new Developer_has_game
                    {
                        gameId = 1,
                        developerId = 1
                    },
                    new Developer_has_game
                    {
                        gameId = 2,
                        developerId = 1
                    },
                    new Developer_has_game
                    {
                        gameId = 1,
                        developerId = 2
                    },
                    new Developer_has_game
                    {
                        gameId = 3,
                        developerId = 1
                    },
                    new Developer_has_game
                    {
                        gameId = 3,
                        developerId = 2
                    }
                    );
            }
            // Якщо жодного видавця не має жодної гри в БД, то додаємо їх
            if (!content.publisher_has_game.Any())
            {
                content.publisher_has_game.AddRange(
                    new Publisher_has_game
                    {
                        gameId = 1,
                        publisherId = 1
                    },
                    new Publisher_has_game
                    {
                        gameId = 3,
                        publisherId = 1
                    },
                    new Publisher_has_game
                    {
                        gameId = 3,
                        publisherId = 2
                    }
                    );
            }
            // Якщо немає жодного ключа до жодної гри в БД, то додаємо їх
            if (!content.gameKey.Any())
            {
                content.gameKey.AddRange(
                    new GameKey
                    {
                        gameKey = "ABCDE-FGHJK-LMNOP-Q7STU-VW4YZ",
                        expiredDate = "2024-06-02",
                        digitalCopyId = 1,
                        IsActivated = true
                    },
                    new GameKey
                    {
                        gameKey = "12fxk6hg",
                        expiredDate = "2026-02-07",
                        digitalCopyId = 2,
                        IsActivated = true
                    },
                    new GameKey
                    {
                        gameKey = "kcmxk8sm",
                        expiredDate = "2023-11-08",
                        digitalCopyId = 3,
                        IsActivated = true
                    },
                    new GameKey
                    {
                        gameKey = "39RU5-K542G-0FM1N-8S4H2",
                        expiredDate = "2024-02-10",
                        digitalCopyId = 4,
                        IsActivated = true
                    },
                    new GameKey
                    {
                        gameKey = "39RU5-K542G-092T1-6DT8N",
                        expiredDate = "2025-07-12",
                        digitalCopyId = 4,
                        IsActivated = true
                    }
                    );
            }
            // Якщо немає жодного кошика замовлення в БД, то додаємо їх
            if (!content.orderBasket.Any())
            {
                content.orderBasket.AddRange(
                    new OrderBasket
                    {
                        orderId = 1,
                        keyId = 1,
                        price = 124.5
                    },
                    new OrderBasket
                    {
                        orderId = 2,
                        keyId = 2,
                        price = 59
                    },
                    new OrderBasket
                    {
                        orderId = 2,
                        keyId = 4,
                        price = 312
                    },
                    new OrderBasket
                    {
                        orderId = 3,
                        keyId = 3,
                        price = 699
                    },
                    new OrderBasket
                    {
                        orderId = 3,
                        keyId = 5,
                        price = 312
                    }
                    );
            }
            // Якщо немає жодного замовлення в БД, то додаємо їх
            if (!content.userOrder.Any())
            {
                content.userOrder.AddRange(
                    new UserOrder
                    {
                        createdTime = "2022-12-06 22:10:31",
                        price = 124.5,
                        Status = "Виконано",
                        customerId = "3"
                    },
                    new UserOrder
                    {
                        createdTime = "2022-12-08 10:02:57",
                        price = 371,
                        Status = "Виконано",
                        customerId = "3",
                        operatorId = "2"
                    },
                    new UserOrder
                    {
                        createdTime = "2023-01-03 06:46:51",
                        price = 1011,
                        Status = "Виконано",
                        customerId = "4"
                    });
            }
            
            content.SaveChanges();
        }
        private static Dictionary<string, DigitalCopy> digitalCopy;
        public static Dictionary<string, DigitalCopy> digitalCopies
        {
            get
            {
                if (digitalCopies == null)
                {
                    //створення інфомаціїї для занесення в БД
                    var list = new DigitalCopy[]
                    {
                        new DigitalCopy {price = 124.5,platform = "Steam",gameId = 1},
                        new DigitalCopy {price = 59,platform = "GOG",gameId = 2},
                        new DigitalCopy {price = 699,platform = "GOG",gameId = 3},
                        new DigitalCopy {price = 312,platform = "Steam",gameId = 4},
                    };

                    digitalCopy = new Dictionary<string, DigitalCopy>();
                    foreach (DigitalCopy el in list)
                    {
                        digitalCopy.Add(el.platform, el);
                    }
                }
                return digitalCopy;
            }
        }
    }
}