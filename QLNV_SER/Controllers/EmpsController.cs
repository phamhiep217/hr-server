using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using QLNV_SER.Models;
using QLNV_SER.BUS;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Web;

namespace QLNV_SER.Controllers
{
    public class EmpsController : ApiController
    {
        private HumanResourceEntities db = new HumanResourceEntities();

        // GET: api/Emps
        public IQueryable<Emp> GetEmps()
        {
            return db.Emps.Where<Emp>(x => x.AAStatus == Util.strAAStatusActive);
        }

        // GET: api/Emps/5
        [ResponseType(typeof(Emp))]
        public IHttpActionResult GetEmp(int id)
        {
            Emp emp = db.Emps.Find(id);
            if (emp == null)
            {
                return NotFound();
            }

            return Ok(emp);
        }

        // PUT: api/Emps/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmp(int id, Emp emp)
        {
            if (id != emp.EmpID)
            {
                return BadRequest();
            }
            db.Entry(emp).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Emps
        [ResponseType(typeof(Emp))]
        public IHttpActionResult PostEmp(Emp emp)
        {

            db.Emps.Add(emp);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = emp.EmpID }, emp);
        }

        [HttpPost]
        [Route("api/UploadImage")]
        public HttpResponseMessage UploadImage()
        {
            string imageName = null;
            var httpRequest = HttpContext.Current.Request;
            var data = httpRequest["data"];
            var dataa = JObject.Parse(data);
            string a = dataa["EmpCode"].ToString();
            var postedFile = httpRequest.Files["image"];
            imageName = new String(Path.GetFileNameWithoutExtension(postedFile.FileName).Take(10).ToArray()).Replace(" ", ".");
            imageName = imageName + DateTime.Now.ToString("yymmssff") + Path.GetExtension(postedFile.FileName);
            var filePath = HttpContext.Current.Server.MapPath("~/Images/" + imageName);
            postedFile.SaveAs(filePath);
          //  emp.EmpPathImg = imageName;
          //  db.Entry(emp).State = EntityState.Modified;
            return Request.CreateResponse(HttpStatusCode.OK, data);

        }

        // DELETE: api/Emps/5
        [ResponseType(typeof(Emp))]
        public IHttpActionResult DeleteEmp(int id)
        {
            Emp emp = db.Emps.Find(id);
            if (emp == null)
            {
                return NotFound();
            }

            db.Emps.Remove(emp);
            db.SaveChanges();

            return Ok(emp);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmpExists(int id)
        {
            return db.Emps.Count(e => e.EmpID == id) > 0;
        }
    }
}