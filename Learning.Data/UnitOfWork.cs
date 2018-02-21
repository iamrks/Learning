using System;
using Learning.BusinessLogic.Infrastructure.Interfaces;
using Learning.Data.Repositories;

namespace Learning.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private LearningContext _ctx;

        public UnitOfWork(LearningContext ctx)
        {
            _ctx = ctx;
        }

        private IStudentRepository _studentRepository;

        public IStudentRepository StudentRepository
        {
            get
            {
                if (_studentRepository == null)
                {
                    _studentRepository = new StudentRepository(_ctx);
                }
                return _studentRepository;
            }
        }

        private IUserRepository _userRepository;

        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_ctx);
                }
                return _userRepository;
            }
        }

        public void SaveChanges()
        {
            _ctx.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _ctx.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
