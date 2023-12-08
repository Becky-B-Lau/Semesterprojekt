namespace Semesterprojekt.Models
{
    public class User
    {
        public User()
        {
        }

        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public User(string userName, string password, string name, string email)
        {
            UserName = userName;
            Password = password;
            Name = name;
            Email = name;
        }
    }
}
