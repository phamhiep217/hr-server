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
    public class NationsController : ApiController
    {
        private HumanResourceEntities db = new HumanResourceEntities();

        // GET: api/Nations
        public IQueryable<Nation> GetNations()
        {
            return db.Nations.Where<Nation>(x => x.AAStatus == Util.strAAStatusActive);
        }

        // GET: api/Nations/5
        [ResponseType(typeof(Nation))]
        public IHttpActionResult GetNation(int id)
        {
            Nation nation = db.Nations.Find(id);
            if (nation == null)
            {
                return NotFound();
            }

            return Ok(nation);
        }

        // PUT: api/Nations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNation(int id, Nation nation)
        {

            if (id != nation.NationID)
            {
                return BadRequest();
            }

            db.Entry(nation).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NationExists(id))
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

        // POST: api/Nations
        [ResponseType(typeof(Nation))]
        public IHttpActionResult PostNation(Nation nation)
        {

            db.Nations.Add(nation);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = nation.NationID }, nation);
        }

        // DELETE: api/Nations/5
        [ResponseType(typeof(Nation))]
        public IHttpActionResult DeleteNation(int id)
        {
            Nation nation = db.Nations.Find(id);
            if (nation == null)
            {
                return NotFound();
            }

            db.Nations.Remove(nation);
            db.SaveChanges();

            return Ok(nation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NationExists(int id)
        {
            return db.Nations.Count(e => e.NationID == id) > 0;
        }
    }
}