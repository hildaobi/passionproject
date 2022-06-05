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
using PassionProject.Models;

namespace PassionProject.Controllers
{
    public class ActivityDataController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET:
        // api/ActivityData/ListActivities
        [HttpGet]
        public IEnumerable<ActivityDto> ListActivities()
        {
           
             List<Activity> Activities = db.Activities.ToList();
             List<ActivityDto> ActivityDtos = new List<ActivityDto>();

            Activities.ForEach(a => ActivityDtos.Add(new ActivityDto()
            {
                ActivityId = a.ActivityId,
                StudentId = a.StudentId,
                CourseCode = a.CourseCode
                
            })); 
            return ActivityDtos;
        }

        // GET: api/ActivityData/FindActivity/1
        [ResponseType(typeof(Activity))]
        [HttpGet]
        public IHttpActionResult FindActivity(int id)
        {
            Activity Activity = db.Activities.Find(id);
            ActivityDto ActivityDto = new ActivityDto() 
            {
                ActivityId = Activity.ActivityId,
                StudentId = Activity.StudentId,
                CourseCode = Activity.CourseCode
            };
            if (Activity == null)
            {
                return NotFound();
            }

            return Ok(ActivityDto);
     }

        // POST: api/ActivityData/UpdateActivity/1
        [ResponseType(typeof(void))]
        [HttpPost]
        public IHttpActionResult UpdateActivity(int id, Activity activity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != activity.ActivityId)
            {
                return BadRequest();
            }

            db.Entry(activity).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActivityExists(id))
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

        // POST: api/ActivityData/AddActivity
        [ResponseType(typeof(Activity))]
        [HttpPost]
        public IHttpActionResult AddActivity(Activity activity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Activities.Add(activity);
            db.SaveChanges();
           
            

            return CreatedAtRoute("DefaultApi", new { id = activity.ActivityId }, activity);
        }
        
        // POST: api/ActivityData/DeleteActivity/1
        [ResponseType(typeof(Activity))]
        [HttpPost]
        public IHttpActionResult DeleteActivity(int id)
        {
            Activity activity = db.Activities.Find(id);
            if (activity == null)
            {
                return NotFound();
            }

            db.Activities.Remove(activity);
            db.SaveChanges();

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ActivityExists(int id)
        {
            return db.Activities.Count(e => e.ActivityId == id) > 0;
        }
    }
}