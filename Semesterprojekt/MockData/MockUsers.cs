using Semesterprojekt.Models;
namespace Semesterprojekt.MockData
{
    public class MockUsers
    {
        public static List<User> users = new List<User>
        {
            new User("Maria", "Maria", "Maria Kjeldgaard Dybdahl", "mariadybdahl@hotmail.dk"),
            new User("Maria2", "Maria2", "Maria2", "maria2@maria2.dk"),
            new User("Maria Kjeldgaard Dybdahl", "M", "Maria", "mariadybdahl@hotmail.dk")
        };


        public static List<User> GetMockUser()
        {
            return users;
        }
    }
}
