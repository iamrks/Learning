using System;
using System.Linq;
using Learning.Models;
using Learning.BusinessLogic.Infrastructure.Interfaces;

namespace Learning.Data.Repositories
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(LearningContext ctx):base(ctx)
        {
        }

        public Student GetStudentByUserName(string username)
        {
            return _ctx.Students.Where(s => s.UserName == username).FirstOrDefault();
        }
    }
}
