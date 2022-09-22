using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiForQuizApp.Models;

namespace WebApiForQuizApp.Controllers
{
    public class ExamController : ApiController
    {
        db_QUIZEntities db = new db_QUIZEntities();


        [HttpGet]
        public HttpResponseMessage GetAllExams(long id)
        {
            List<TBL_EXAM> li = db.TBL_EXAM.Where(x => x.exam_CreatedBy == id && x.exam_Status == true).ToList();

            return Request.CreateResponse(HttpStatusCode.OK, li);
        }
    }
}
