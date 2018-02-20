using Learning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Data
{
    public static class DbUtility
    {
        public static User GetUserByToken(string token)
        {
            using (var ctx = new LearningContext())
            {
                User user = (from s in ctx.Sessions
                             join u in ctx.Users on s.UserId equals u.Id
                             select u).FirstOrDefault();
                return user;
            }
        }
    }
}
