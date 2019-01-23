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
    public class EthnicsController : ApiController
    {
        private HumanResourceEntities db = new HumanResourceEntities();

        // GET: api/Ethnics
        public IQueryable<Ethnic> GetEthnics()
        {
            return db.Ethnics.Where<Ethnic>(x => x.AAStatus == Util.strAAStatusActive);
        }

        // GET: api/Ethnics/5
        [ResponseType(typeof(Ethnic))]
        public IHttpActionResult GetEthnic(int id)
        {
            Ethnic ethnic = db.Ethnics.Find(id);
            if (ethnic == null)
            {
                return NotFound();
            }

            return Ok(ethnic);
        }

        // PUT: api/Ethnics/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEthnic(int id, Ethnic ethnic)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ethnic.EthnicID)
            {
                return BadRequest();
            }

            db.Entry(ethnic).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EthnicExists(id))
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

        // POST: api/Ethnics
        [ResponseType(typeof(Ethnic))]
        public IHttpActionResult PostEthnic(Ethnic ethnic)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Ethnics.Add(ethnic);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = ethnic.EthnicID }, ethnic);
        }

        // DELETE: api/Ethnics/5
        [ResponseType(typeof(Ethnic))]
        public IHttpActionResult DeleteEthnic(int id)
        {
            Ethnic ethnic = db.Ethnics.Find(id);
            if (ethnic == null)
            {
                return NotFound();
            }

            db.Ethnics.Remove(ethnic);
            db.SaveChanges();

            return Ok(ethnic);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EthnicExists(int id)
        {
            return db.Ethnics.Count(e => e.EthnicID == id) > 0;
        }
    }
}