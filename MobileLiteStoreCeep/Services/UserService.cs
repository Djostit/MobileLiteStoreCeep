using MobileLiteStoreCeep.Assests;
using Newtonsoft.Json;

namespace MobileLiteStoreCeep.Services
{
    public class UserService
    {
        public static List<User> Users { get; set; } = new List<User>();

        private const string PATH = "user.json";
        //System.IO.FileNotFoundException: 
        private static async Task ReadUsersAsync()
        {
            /* 
             * Для первого запуска
             * Если файла не существует
             * Он копирует файл и сохраняет
             * И дальше без потери производительности работает с ним
            */

            if (!File.Exists(Path.Combine(FileSystem.Current.AppDataDirectory, PATH)))
            {
                using var stream = await FileSystem.OpenAppPackageFileAsync("user.json");
                using var reader = new StreamReader(stream);

                var contents = await reader.ReadToEndAsync();

                Users = JsonConvert.DeserializeObject<List<User>>(contents);

                await SaveUserAsync();
            }
            else
            {
                string targetFile = Path.Combine(FileSystem.Current.AppDataDirectory, PATH);

                using FileStream outputStream = File.OpenRead(targetFile);
                using var reader = new StreamReader(outputStream);

                var contents = await reader.ReadToEndAsync();

                Users = JsonConvert.DeserializeObject<List<User>>(contents);
            }
        }
        private static async Task SaveUserAsync()
        {
            string targetFile = Path.Combine(FileSystem.Current.AppDataDirectory, PATH);

            using FileStream outputStream = File.OpenWrite(targetFile);
            using var streamWriter = new StreamWriter(outputStream);

            await streamWriter.WriteAsync(JsonConvert.SerializeObject(Users, Formatting.Indented));
        }

        public async Task CheckAllUsers()
        {
            if (Users.Count is 0)
                await ReadUsersAsync();

            foreach (var item in Users)
            {
                Debug.WriteLine(item.Username);
            }
        }

        public async Task<bool> AuthorizeUserAsync(string username, string password)
        {
            if (Users.Count is 0)
                await ReadUsersAsync();

            var user = Users.SingleOrDefault(u => u.Username.Equals(username));

            if (user is null)
                return false;

            Global.CurrentUser = user;

            return BCrypt.Net.BCrypt.Verify(password, user.Password);
        }

        public async Task AddUserAsync(string name, string lastName, string birthday, string country, string username, string password)
        {
            if (Users.Count is 0)
                await ReadUsersAsync();

            Users.Add(new User
            {
                Name = name,
                LastName = lastName,
                Birthday = birthday,
                Country = country,
                Username = username,
                Password = BCrypt.Net.BCrypt.HashPassword(password),
                Balance = 0
            });

            await SaveUserAsync();
        }

        public static async Task SaveCurrentUserAsync()
        {
            if (Global.CurrentUser.Username is null)
                return;

            int index = Users.FindIndex(u => u.Equals(Global.CurrentUser));
            Users[index] = Global.CurrentUser;
            await SaveUserAsync();
        }
    }
}
