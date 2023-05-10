using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace LabWork.Data.Models
{
    public class Publisher_has_game
    {
        public int gameId { get; set; }
        public int publisherId { get; set; }
    }
}
