using QuizApplicationDALLibrary;
using QuizApplicationModelLibrary;

namespace QuizApplicationBLLibrary
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService()
        {
            _userRepository = new UserRepository();
        }

        public User CreateUser(string username, string password, UserRole role)
        {
            // Check if user with the same username already exists
            foreach (var user in _userRepository.GetAll())
            {
                if (user.Username == username)
                {
                    throw new System.Exception("Username already exists.");
                }
            }

            var userToAdd = new User(username, password, role);
            return _userRepository.Add(userToAdd);
        }

        public User GetUserById(int userId)
        {
            foreach (var user in _userRepository.GetAll())
            {
                if (user.Id == userId)
                {
                    return user;
                }
            }
            throw new KeyNotFoundException($"User with id '{userId}' not found."); ; // User not found
        }

        public bool ValidateUserCredentials(string username, string password)
        {
            foreach (var user in _userRepository.GetAll())
            {
                if (user.Username == username && user.Password == password)
                {
                    return true; // Credentials are valid
                }
            }
            return false; // Credentials are invalid
        }
    }
}
