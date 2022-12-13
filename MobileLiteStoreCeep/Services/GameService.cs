using MobileLiteStoreCeep.Assests;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileLiteStoreCeep.Services
{
    public class GameService
    {
        private const string PATH = "game.json";
        private static async Task ReadGamesAsync()
        {
            /* 
             * Для первого запуска
             * Если файла не существует
             * Он копирует файл и сохраняет
             * И дальше без потери производительности работает с ним
            */

            if (!File.Exists(Path.Combine(FileSystem.Current.AppDataDirectory, PATH)))
            {
                using var stream = await FileSystem.OpenAppPackageFileAsync("game.json");
                using var reader = new StreamReader(stream);

                var contents = await reader.ReadToEndAsync();

                Global.Games = JsonConvert.DeserializeObject<List<Game>>(contents);

                await SaveGameAsync();
            }
            else
            {
                string targetFile = Path.Combine(FileSystem.Current.AppDataDirectory, PATH);

                using FileStream outputStream = File.OpenRead(targetFile);
                using var reader = new StreamReader(outputStream);

                var contents = await reader.ReadToEndAsync();

                Global.Games = JsonConvert.DeserializeObject<List<Game>>(contents);
            }
        }
        private static async Task SaveGameAsync()
        {
            string targetFile = Path.Combine(FileSystem.Current.AppDataDirectory, PATH);

            using FileStream outputStream = File.OpenWrite(targetFile);
            using var streamWriter = new StreamWriter(outputStream);

            await streamWriter.WriteAsync(JsonConvert.SerializeObject(Global.Games, Formatting.Indented));
        }

        public async Task<List<Game>> GetListGame()
        {
            await ReadGamesAsync();
            return Global.Games;
        }
        public List<Game> GetLibrary(List<UserGames> ids)
        {
            var a = new List<Game>();

            for (int i = 0; i < ids.Count; i++)
            {
                var game = Global.Games.SingleOrDefault(g => g.Id.Equals(ids[i].Id));
                a.Add(game);
            }

            return a;
        }
    }
}
