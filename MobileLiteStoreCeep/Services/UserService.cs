using MobileLiteStoreCeep.Assests;
using Newtonsoft.Json;
using System.Diagnostics;

namespace MobileLiteStoreCeep.Services
{
    public class UserService
    {
        public static List<User> Users { get; set; } = new List<User>();

        private const string PATH = "user.json";
        private static async Task ReadUsersAsync() => Users = JsonConvert.DeserializeObject<List<User>>(await File.ReadAllTextAsync(Path
            .Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), PATH)));
        private static async Task SaveUserAsync() => await File.WriteAllTextAsync(Path
            .Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), PATH), JsonConvert.SerializeObject(Users, Formatting.Indented));

        public async Task CheckAllUsers()
        {
            await ReadUsersAsync();

            foreach (var item in Users)
            {
                Debug.WriteLine(item.Username);
            }
        }

        public async Task<bool> AuthorizeUserAsync(string username, string password)
        {
            await ReadUsersAsync();

            var user = Users.SingleOrDefault(u => u.Username.Equals(username));

            if (user == null)
                return false;

            Global.CurrentUser = user;

            return BCrypt.Net.BCrypt.Verify(password, user.Password);
        }

        public async Task AddUserAsync(string name, string lastName, string birthday, string country, string username, string password)
        {
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
