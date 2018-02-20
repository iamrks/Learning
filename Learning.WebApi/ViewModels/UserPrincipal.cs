using System;
using System.Security.Principal;

namespace Learning.ViewModels
{
    internal class UserPrincipal : IPrincipal
    {
        public IIdentity Identity { get; private set; }

        public UserModel Model { get; set; }

        public bool IsInRole(string role)
        {
            throw new NotImplementedException();
        }

        public UserPrincipal(UserModel model)
        {
            this.Model = model;
            this.Identity = new GenericIdentity(model.Username);
        }
    }


    class UserModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
    }
}