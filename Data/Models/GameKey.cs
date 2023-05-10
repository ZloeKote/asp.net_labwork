namespace LabWork.Data.Models
{
    public class GameKey
    {
        public int Id { get; set; }
        public string gameKey { get; set; }
        public string expiredDate { get; set; }
        public int digitalCopyId { get; set; }
        public bool IsActivated { get; set; }
    }
}
