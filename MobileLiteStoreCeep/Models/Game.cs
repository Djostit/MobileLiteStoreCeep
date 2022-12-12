﻿namespace MobileLiteStoreCeep.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string DisplayedImage
        {
            get { return Path.GetFullPath(Path.Combine(FileSystem.Current.AppDataDirectory, Image)); }
        }
    }

}
