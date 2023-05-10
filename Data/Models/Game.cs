using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabWork.Data.Models
{
    public class Game
    {
        public int id {  get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string releaseDate { get; set; }
        public float rating { get; set; }
        public string cover_img_path { get; set; }
        [NotMapped]
        public string genres { get; set; }
        [NotMapped]
        public string developers { get; set; }
        [NotMapped]
        public string publishers { get; set; }
        [NotMapped]
        public IEnumerable<DigitalCopy> digitalCopies { get; set; }
    }
}
