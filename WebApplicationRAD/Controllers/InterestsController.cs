using Microsoft.AspNet.Identity;
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
using WebApplicationRAD.Models;

namespace WebApplicationRAD.Controllers
{
    public class InterestsController : ApiController
    {
        private InterestsContext db = new InterestsContext();

        // GET: api/Interests/ForCurrentUser
        [Authorize]
        [Route("api/Interests/ForCurrentUser")]
        public IQueryable<Interest> GetInterestsForCurrentUser()
        {
            string userId = User.Identity.GetUserId();
            return db.Interests.Where(interest => interest.UserId == userId);
        }


        // GET: api/Interests
        [Authorize]
        public IQueryable<Interest> GetInterests()
        {
            string userId = User.Identity.GetUserId();
            return db.Interests;
        }

        // GET: api/Interests/5
        [Authorize]
        [ResponseType(typeof(Interest))]
        public IHttpActionResult GetInterest(int id)
        {
            Interest interest = db.Interests.Find(id);
            if (interest == null)
            {
                return NotFound();
            }

            return Ok(interest);
        }

        // PUT: api/Interests/5
        [Authorize]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutInterest(int id, Interest interest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != interest.Id)
            {
                return BadRequest();
            }

            string userId = User.Identity.GetUserId();

            if (userId != interest.UserId)
            {
                return StatusCode(HttpStatusCode.Conflict);
            }

            db.Entry(interest).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InterestExists(id))
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

        // POST: api/Interests
        [Authorize]
        [ResponseType(typeof(Interest))]
        public IHttpActionResult PostInterest(Interest interest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            string userId = User.Identity.GetUserId();
            interest.UserId = userId;

            db.Interests.Add(interest);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = interest.Id }, interest);
        }

        // DELETE: api/Interests/5
        [Authorize]
        [ResponseType(typeof(Interest))]
        public IHttpActionResult DeleteInterest(int id)
        {
            Interest interest = db.Interests.Find(id);
            if (interest == null)
            {
                return NotFound();
            }
            string userId = User.Identity.GetUserId();
            if (userId != interest.UserId)
            {
                return StatusCode(HttpStatusCode.Conflict);
            }

            db.Interests.Remove(interest);
            db.SaveChanges();

            return Ok(interest);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InterestExists(int id)
        {
            return db.Interests.Count(e => e.Id == id) > 0;
        }
    }
}