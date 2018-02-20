using Learning.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Learning.BusinessLogic.Infrastructure.Interfaces
{
    public interface IStudentRepository: IRepository<Student>
    {
        Student GetStudentByUserName(string username);
    }
}
