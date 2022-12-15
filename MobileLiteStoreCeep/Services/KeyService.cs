using Newtonsoft.Json;

namespace MobileLiteStoreCeep.Services
{
    public class KeyService
    {
        public static List<Key> keys = new List<Key>();

        private static readonly Random rnd = new();

        private const string KEY_CHARS = "QWERTYUIOPASDFGHJKLZXCVBNM0123456789";

        private const string PATH = "key.json";
        private static async Task ReadKeysAsync()
        {
            /* 
             * Для первого запуска
             * Если файла не существует
             * Он копирует файл и сохраняет
             * И дальше без потери производительности работает с ним
            */

            if (!File.Exists(Path.Combine(FileSystem.Current.AppDataDirectory, PATH)))
            {
                using var stream = await FileSystem.OpenAppPackageFileAsync("key.json");
                using var reader = new StreamReader(stream);

                var contents = await reader.ReadToEndAsync();

                keys = JsonConvert.DeserializeObject<List<Key>>(contents);

                await SaveKeyAsync();
            }
            else
            {
                string targetFile = Path.Combine(FileSystem.Current.AppDataDirectory, PATH);

                using FileStream outputStream = File.OpenRead(targetFile);
                using var reader = new StreamReader(outputStream);

                var contents = await reader.ReadToEndAsync();

                keys = JsonConvert.DeserializeObject<List<Key>>(contents);
            }
        }
        private static async Task SaveKeyAsync()
        {
            string targetFile = Path.Combine(FileSystem.Current.AppDataDirectory, PATH);

            using FileStream outputStream = File.OpenWrite(targetFile);
            using var streamWriter = new StreamWriter(outputStream);

            await streamWriter.WriteAsync(JsonConvert.SerializeObject(keys, Formatting.Indented));
        }
        public async Task<string> CreateKey(int ID)
        {
            await ReadKeysAsync();

            string key = $"{CreateKeyPart(rnd)}-{CreateKeyPart(rnd)}-{CreateKeyPart(rnd)}-{CreateKeyPart(rnd)}-{CreateKeyPart(rnd)}";
            keys.Add(new Key
            {
                ID = ID,
                KEY = key,
                Status = Key.Status_key.Not_activated
            });
            await SaveKeyAsync();

            return key;
        }
        public async Task<int> FindIdGame(string key)
        {
            await ReadKeysAsync();
            return keys.SingleOrDefault(u => u.KEY.Equals(key)).ID;
        }

        private static string CreateKeyPart(Random rnd)
        {
            string value = string.Empty;
            for (int i = 0; i < 5; i++) { value += KEY_CHARS[rnd.Next(0, KEY_CHARS.Length)]; }
            return value;
        }

        public async Task<bool> ActivateKey(string key)
        {
            await ReadKeysAsync();

            int index = keys.FindIndex(k => k.KEY.Equals(key));

            if (keys.SingleOrDefault(u => u.KEY.Equals(key)) is null
                || keys.SingleOrDefault(u => u.KEY.Equals(key)).Status.Equals(Key.Status_key.Actived))
                return false;

            if (Global.CurrentUser.Games.SingleOrDefault(g => g.Id.Equals(keys[index].ID)) is not null)
                return false;


            keys[index].Status = Key.Status_key.Actived;
            await SaveKeyAsync();
            return true;
        }
    }
}
