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

namespace QLNV_SER.Controllers
{
    public class DegreesController : ApiController
    {
        private HumanResourceEntities db = new HumanResourceEntities();

        // GET: api/Degrees
        public IQueryable<Degree> GetDegrees()
        {
            return db.Degrees.Where<Degree>(x => x.AAStatus == Util.strAAStatusActive);
        }

        // GET: api/Degrees/5
        [ResponseType(typeof(Degree))]
        public IHttpActionResult GetDegree(int id)
        {
            Degree degree = db.Degrees.Find(id);
            if (degree == null)
            {
                return NotFound();
            }

            return Ok(degree);
        }

       [Route("api/Degrees/LstDegreeByEmpID")]
        public HttpResponseMessage getLstDegreeByEmpID(int id)
        {
            var rs = db.Degrees.Where<Degree>(x => x.FK_EmpID == id).OrderByDescending(x => x.AAOrder);
            return Request.CreateResponse(HttpStatusCode.OK, rs);
        }

        // PUT: api/Degrees/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDegree(int id, Degree degree)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != degree.DegreeID)
            {
                return BadRequest();
            }

            db.Entry(degree).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DegreeExists(id))
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

        // POST: api/Degrees
        [ResponseType(typeof(Degree))]
        public IHttpActionResult PostDegree(Degree degree)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Degrees.Add(degree);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = degree.DegreeID }, degree);
        }

        // DELETE: api/Degrees/5
        [ResponseType(typeof(Degree))]
        public IHttpActionResult DeleteDegree(int id)
        {
            Degree degree = db.Degrees.Find(id);
            if (degree == null)
            {
                return NotFound();
            }

            db.Degrees.Remove(degree);
            db.SaveChanges();

            return Ok(degree);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DegreeExists(int id)
        {
            return db.Degrees.Count(e => e.DegreeID == id) > 0;
        }
    }
}