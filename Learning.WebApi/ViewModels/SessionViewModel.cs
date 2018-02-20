using System;
using Learning.Models;

namespace Learning.WebApi.ViewModels
{
    public class SessionViewModel
    {
        public SessionViewModel(Session session)
        {
            UserId = session.UserId;
            Token = session.Token;
            LoginTime = session.LoginTime;
        }
        public int UserId { get; set; }
        public string Token { get; set; }
        public DateTime LoginTime { get; set; }
    }
}