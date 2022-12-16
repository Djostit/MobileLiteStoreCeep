namespace MobileLiteStoreCeep.Assests
{
    public static class Global
    {
        public static User CurrentUser { get; set; } = new User();
        public static List<Game> Games { get; set; } = new List<Game>();
        public static Game CurrentGame { get; set; } = new Game();
        public static string Key { get; set; }
    }
}
