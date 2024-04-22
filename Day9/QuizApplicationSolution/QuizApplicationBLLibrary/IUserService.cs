using QuizApplicationModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApplicationBLLibrary
{
    public interface IUserService
    {
        User CreateUser(string username, string password, UserRole role);
        User GetUserById(int userId);
        bool ValidateUserCredentials(string username, string password);
    }
}
