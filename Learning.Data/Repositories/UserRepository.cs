using System;
using System.Linq;
using Learning.Models;
using Learning.BusinessLogic.Infrastructure.Interfaces;

namespace Learning.Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(LearningContext ctx):base(ctx)
        {
        }

        public void DeleteToken(string token)
        {
            Session existingSession = _ctx.Sessions.Where(s => s.Token == token).FirstOrDefault();
            if (existingSession != null)
            {
                _ctx.Sessions.Remove(existingSession);
                _ctx.SaveChanges();
            }
        }

        public User GetUserByName(string username)
        {
            return _ctx.Users.Where(s => s.Username == username).FirstOrDefault();
        }

        public User GetUserByToken(string token)
        {
            User user = (from s in _ctx.Sessions
                         join u in _ctx.Users on s.UserId equals u.Id
                         select u).FirstOrDefault();
            return user;
        }

        public bool Login(string username, string password)
        {
            User user = this.GetUserByName(username);
            if (user == null)
                return false;

            if (user.Password != password)
                return false;

            return true;
        }

        public Session SaveToken(int userId)
        {
            Session session = new Session()
            {
                UserId = userId,
                LoginTime = DateTime.Now,
                Token = Guid.NewGuid().ToString(),
            };

            _ctx.Sessions.Add(session);
            _ctx.SaveChanges();
            return session;
        }
    }
}
