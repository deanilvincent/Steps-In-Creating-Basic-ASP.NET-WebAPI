using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using MyWebAPI.Models;

namespace MyWebAPI.Controllers
{
    public class UserDetailCredentialsAPIController : ApiController
    {
        private MySampDBContext db = new MySampDBContext();

        // GET: api/UserDetailCredentialsAPI
        public IQueryable<UserDetailCredentials> GetUserDetailCredentials()
        {
            return db.UserDetailCredentials;
        }

        // GET: api/UserDetailCredentialsAPI/5
        [ResponseType(typeof(UserDetailCredentials))]
        public async Task<IHttpActionResult> GetUserDetailCredentials(int id)
        {
            UserDetailCredentials userDetailCredentials = await db.UserDetailCredentials.FindAsync(id);
            if (userDetailCredentials == null)
            {
                return NotFound();
            }

            return Ok(userDetailCredentials);
        }

        // PUT: api/UserDetailCredentialsAPI/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUserDetailCredentials(int id, UserDetailCredentials userDetailCredentials)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userDetailCredentials.Id)
            {
                return BadRequest();
            }

            db.Entry(userDetailCredentials).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserDetailCredentialsExists(id))
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

        // POST: api/UserDetailCredentialsAPI
        [ResponseType(typeof(UserDetailCredentials))]
        public async Task<IHttpActionResult> PostUserDetailCredentials(UserDetailCredentials userDetailCredentials)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UserDetailCredentials.Add(userDetailCredentials);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = userDetailCredentials.Id }, userDetailCredentials);
        }

        // DELETE: api/UserDetailCredentialsAPI/5
        [ResponseType(typeof(UserDetailCredentials))]
        public async Task<IHttpActionResult> DeleteUserDetailCredentials(int id)
        {
            UserDetailCredentials userDetailCredentials = await db.UserDetailCredentials.FindAsync(id);
            if (userDetailCredentials == null)
            {
                return NotFound();
            }

            db.UserDetailCredentials.Remove(userDetailCredentials);
            await db.SaveChangesAsync();

            return Ok(userDetailCredentials);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserDetailCredentialsExists(int id)
        {
            return db.UserDetailCredentials.Count(e => e.Id == id) > 0;
        }
    }
}