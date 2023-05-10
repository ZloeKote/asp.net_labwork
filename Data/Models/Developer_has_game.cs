using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabWork.Data.Models
{
    public class Developer_has_game
    {
        public int gameId { get; set; }
        public int developerId { get; set; }
    }
}
