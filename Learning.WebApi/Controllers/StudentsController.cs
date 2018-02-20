using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Learning.BusinessLogic.Infrastructure.Interfaces;
using Learning.Models;
using System.Web.Http.Description;

namespace Learning.WebApi.Controllers
{
    public class StudentsController : ApiController
    {
        private IUnitOfWork _uow;
        public StudentsController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [ResponseType(typeof(IEnumerable<Student>))]
        public IHttpActionResult Get()
        {
            return Ok(this._uow.StudentRepository.GetAll().ToList());
        }

        [ResponseType(typeof(Student))]
        public IHttpActionResult Get(int id)
        {
            return Ok(this._uow.StudentRepository.Get(id));
        }
    }
}
