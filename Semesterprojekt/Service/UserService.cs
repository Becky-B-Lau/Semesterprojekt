using Semesterprojekt.MockData;
using Semesterprojekt.Models;

namespace Semesterprojekt.Service
{
    public class UserService
    {
        public List<User> users { get; set; }


        public UserService()
        {
            users = MockUsers.GetMockUser();
        }



    }
}
