using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using System.Threading.Tasks;
using Learning.Models;
using Learning.WebApi.Filters;
using Learning.BusinessLogic.Infrastructure.Interfaces;

namespace Learning.WebApi.Controllers
{
    [CustomAuthorize]
    [RoutePrefix("api/students")]
    public class StudentController : ApiController
    {
        private IUnitOfWork _uow;
        public StudentController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [Route("")]
        [ResponseType(typeof(IEnumerable<Student>))]
        public IHttpActionResult Get()
        {
            return Ok(_uow.StudentRepository.GetAll().ToList());
        }

        [Route("{id}")]
        [ResponseType(typeof(Student))]
        public async Task<IHttpActionResult> Get(int id)
        {
            Student std = await _uow.StudentRepository.Get(id);
            return Ok(std);
        }
    }
}
