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
    public class UsersController : ApiController
    {
        private HumanResourceEntities db = new HumanResourceEntities();
        // GET: api/Users
        [Route("users/getuser")]
        public IQueryable<User> GetUsers()
        {
            return db.Users;
        }

        // GET: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUser(int id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUser(int id, User user)
        {
            if (id != user.UserID)
            {
                return BadRequest();
            }

            db.Entry(user).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/Users
        [ResponseType(typeof(User))]
        public IHttpActionResult PostUser(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = user.UserID }, user);
        }

        // POST: api/Users
        [Route("users/checklogin")]
        public HttpResponseMessage CheckLogin([FromBody]User user)
        {
            var rs = db.Users.FirstOrDefault(x => x.UserName == user.UserName && x.UserPass == user.UserPass);
            ChamCong TimeSheet = new ChamCong();
            TimeSheet.ImportAcToEmp();
            return Request.CreateResponse(HttpStatusCode.OK, rs);
        }

        [Route("users/loadrole")]
        public HttpResponseMessage Loadrole([FromBody]User user)
        {
            var rs = db.Users.FirstOrDefault(x => x.UserName == user.UserName && x.UserPass == user.UserPass);
            if (rs != null)
            {
                var roleList = db.Database.SqlQuery<RoleSub>("select * from RoleSub where FK_UserID = {0}", new object[] { rs.UserID }).FirstOrDefault();
                return Request.CreateResponse(HttpStatusCode.OK, roleList);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult DeleteUser(int id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            db.Users.Remove(user);
            db.SaveChanges();

            return Ok(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(string name, string pass)
        {
            return db.Users.Count(e => e.UserName == name && e.UserPass == pass) > 0;
        }

        private bool UserExists(int id)
        {
            return db.Users.Count(e => e.UserID == id) > 0;
        }
    }
}