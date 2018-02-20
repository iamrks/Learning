using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using Learning.Models;
using Learning.BusinessLogic.Infrastructure.Interfaces;
using Learning.WebApi.ViewModels;
using Learning.ViewModels;
using Learning.WebApi.Filters;

namespace Learning.WebApi.Controllers
{
    [RoutePrefix("api/accounts")]
    public class AccountController : ApiController
    {
        private IUnitOfWork _uow;

        public AccountController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpPost]
        [Route("login")]
        public IHttpActionResult Login(LoginViewModel login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool isValid = _uow.UserRepository.Login(login.Username, login.Password);
            if (!isValid)
                return Unauthorized();

            Session session = _uow.UserRepository.SaveToken(_uow.UserRepository.GetUserByName(login.Username).Id);
            return Ok(new SessionViewModel(session));
        }

        [HttpGet]
        [Route("logout")]
        [CustomAuthorize]
        public IHttpActionResult Logout()
        {
            var user = ((UserPrincipal)HttpContext.Current.User).Model;
            _uow.UserRepository.DeleteToken(user.Token);
            return Ok();
        }

        [HttpPost]
        [ResponseType(typeof(User))]
        [Route("register")]
        public IHttpActionResult Register(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            User savedUser = _uow.UserRepository.Add(user);
            return Ok(savedUser);
        }
    }
}
