using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace LabWork.Data.Models
{
    public class Game_has_genre
    {
        public int gameId { get; set; }
        public int genreId { get; set; }
    }
}
