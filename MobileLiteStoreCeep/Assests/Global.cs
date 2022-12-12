using Newtonsoft.Json;

namespace MobileLiteStoreCeep.Assests
{
    public static class Global
    {
        public static User CurrentUser { get; set; } = new User();
        public static List<Game> Games { get; set; } = new List<Game>();
    }
}
