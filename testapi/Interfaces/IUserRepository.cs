using testapi.Models;

namespace testapi.Interfaces
{
    public interface IUserRepository
    {

        ICollection<User> GetAllUsers();
        bool AddUser(UserRegisterModel request);

    }
}
