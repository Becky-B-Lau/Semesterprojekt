using Semesterprojekt.Models;
namespace Semesterprojekt.MockData
{
    public class MockUsers
    {
        public static List<User> users = new List<User>
        {
            new User("Maria", "Maria", "Maria Kjeldgaard Dybdahl"),
            new User("Maria2", "Maria2", "Maria2"),
        };


        public static List<User> GetMockUser()
        {
            return users;
        }
    }
}
