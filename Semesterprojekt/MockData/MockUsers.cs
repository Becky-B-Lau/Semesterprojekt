using Semesterprojekt.Models;
namespace Semesterprojekt.MockData
{
    public class MockUsers
    {
        public static List<User> users = new List<User>
        {
            new User("Maria", "Maria", "Maria Kjeldgaard Dybdahl", "mariadybdahl@hotmail.dk"),
            new User("Admin", "Admin", "Admin", "Admin@Admin.dk")
           
        };


        public static List<User> GetMockUser()
        {
            return users;
        }
    }
}
