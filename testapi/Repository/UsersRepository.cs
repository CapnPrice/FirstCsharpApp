using testapi.Data;
using testapi.Interfaces;
using testapi.Models;

namespace testapi.Repository
{
    public class UsersRepository : IUserRepository
    {
         private readonly DataContext _context;

        public static User user = new User();

        public UsersRepository(DataContext context)
        {

            _context = context;
        }

        public ICollection<User> GetAllUsers() 
        {
            return _context.Users.OrderBy(user => user.Id).ToList();
        }

        public bool AddUser(UserRegisterModel requrst)
        {
            user.Name = requrst.Name;
            user.Email = requrst.Email;
            user.Password = requrst.Password;

            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return true;
            }
            catch (Exception error) 
            {
                throw;
            }
        }

    }
}
