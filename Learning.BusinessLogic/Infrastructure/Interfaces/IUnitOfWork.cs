using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.BusinessLogic.Infrastructure.Interfaces
{
    public interface IUnitOfWork
    {
        IStudentRepository StudentRepository { get; }
        IUserRepository UserRepository { get; }
        void SaveChanges();
    }
}
