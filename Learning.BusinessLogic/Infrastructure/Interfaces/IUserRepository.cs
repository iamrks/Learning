using Learning.Models;

namespace Learning.BusinessLogic.Infrastructure.Interfaces
{
    public interface IUserRepository: IRepository<User>
    {
        void DeleteToken(string token);
        User GetUserByName(string username);
        User GetUserByToken(string token);
        bool Login(string username, string password);
        Session SaveToken(int userId);
    }
}
