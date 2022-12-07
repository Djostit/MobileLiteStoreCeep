namespace MobileLiteStoreCeep.Models
{
    public class Key
    {
        public string KEY { get; set; }
        public int ID { get; set; }
        public Status_key Status { get; set; }
        public enum Status_key
        {
            Not_activated,
            Actived
        }
    }
}
