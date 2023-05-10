using LabWork.Data.Interfaces;
using LabWork.Data.Models;
using LabWork.Data.Repository;
using LabWork.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace LabWork.Controllers
{
    public class GamesController : Controller
    {
        private readonly IGames _allGames;
        private readonly IDigitalCopy _allCopies;
        private readonly IDeveloper _allDevs;
        private readonly IDeveloper_has_game _allDevs_has_game;
        private readonly IPublisher _allPubs;
        private readonly IPublisher_has_game _allPubs_has_game;
        private readonly IGenre _allGenres;
        private readonly IGame_has_genre _allGame_has_genres;

        public GamesController(IGames allGames, IDigitalCopy allCopies, IDeveloper allDevs, IDeveloper_has_game allDevs_has_game, 
            IPublisher allPubs, IPublisher_has_game allPubs_has_game, IGenre allGenres, IGame_has_genre allGame_has_genres) { 
            _allGames = allGames;
            _allCopies = allCopies;
            _allDevs = allDevs;
            _allPubs = allPubs;
            _allGenres = allGenres;
            _allDevs_has_game = allDevs_has_game;
            _allPubs_has_game = allPubs_has_game;
            _allGame_has_genres = allGame_has_genres;
        }

        public ViewResult List()
        {
            List<Game> games = _allGames.allGames.ToList();
            List<DigitalCopy> copies = _allCopies.allCopies.ToList();
            List<Developer> devs = _allDevs.developers.ToList();
            List<Publisher> pubs = _allPubs.publishers.ToList();
            List<Genre> genres = _allGenres.getGenres.ToList();
            List<Developer_has_game> devs_has_games = _allDevs_has_game.developers_has_game.ToList();
            List<Publisher_has_game> pubs_has_games = _allPubs_has_game.publishers_has_game.ToList();
            List<Game_has_genre> game_has_genres = _allGame_has_genres.game_has_genres.ToList();

            List<DigitalCopy> tempCopies;

            foreach (var game in games)
            {
                game.genres = getGenresByGameId(game_has_genres, genres, game.id);
                game.developers = getDevsByGameId(devs_has_games, devs, game.id);
                game.publishers = getPubsByGameId(pubs_has_games, pubs, game.id);

                tempCopies = new List<DigitalCopy>();
                foreach (var copy in copies)
                {
                    if (game.id == copy.gameId)
                    {
                        tempCopies.Add(copy);
                    }
                }
                game.digitalCopies = tempCopies;
            }
            GamesListViewModel obj = new GamesListViewModel();
            obj.allGames = games;
            return View(obj);
        }

        public string getGenresByGameId(List<Game_has_genre> game_has_genres, List<Genre> genres, int gameId)
        {
            string gameGenres = "";
            for (int i = 0; i < game_has_genres.Count; i++)
            {
                if (game_has_genres[i].gameId == gameId) gameGenres += (getGenreById(genres, game_has_genres[i].genreId)) + ", ";
            }
            gameGenres = gameGenres.Substring(0, gameGenres.Length - 2);
            return gameGenres;
        }
        public string getDevsByGameId(List<Developer_has_game> devs_has_game, List<Developer> devs, int gameId)
        {
            string gameDevs = "";
            foreach (var dev_has_game in devs_has_game)
            {
                if (dev_has_game.gameId == gameId) gameDevs += getDevById(devs, dev_has_game.developerId) + ", ";
            }
            gameDevs = gameDevs.Substring(0, gameDevs.Length - 2);
            return gameDevs;
        }
        public string getPubsByGameId(List<Publisher_has_game> pubs_has_game, List<Publisher> pubs, int gameId)
        {
            string gamePubs = "";
            foreach (var pub in pubs_has_game)
            {
                if (pub.gameId == gameId) gamePubs += getPubById(pubs, pub.publisherId) + ", ";
            }
            if (gamePubs != "") gamePubs = gamePubs.Substring(0, gamePubs.Length - 2);
            return gamePubs;
        }
        public string getGenreById(List<Genre> genres, int genreId)
        {
            foreach (var genre in genres)
            {
                if (genre.Id == genreId) return genre.Name;
            }
            return null;
        }
        public string getDevById(List<Developer> devs, int devId)
        {
            foreach (var dev in devs)
            {
                if (dev.Id == devId) return dev.Name;
            }
            return null;
        }
        public string getPubById(List<Publisher> pubs, int pubId)
        {
            foreach (var pub in pubs)
            {
                if (pub.Id == pubId) return pub.Name;
            }
            return null;
        }
        /*
        public IActionResult Index()
        {
            return View();
        }
        */
    }
}
