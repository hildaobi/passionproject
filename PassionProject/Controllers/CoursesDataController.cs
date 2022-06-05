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
    public class CoursesDataController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/CoursesData/ListCourses
        [HttpGet]
        public IEnumerable<CourseDto> ListCourses()
        {

            List<Course> Courses = db.Courses.ToList();
            List<CourseDto> CourseDtos = new List<CourseDto>();

            Courses.ForEach(a => CourseDtos.Add(new CourseDto()
            {
                CourseCode = a.CourseCode,
                CourseName = a.CourseName,
                
            }));
            
            return CourseDtos;
        }

        // GET: api/CoursesData/FindCourse/5
        [ResponseType(typeof(Course))]
        [HttpGet]
        public IHttpActionResult FindCourse(int id)
        {
            Course course = db.Courses.Find(id);
            CourseDto CourseDto = new CourseDto()
            {
                CourseCode = course.CourseCode,
                CourseName = course.CourseName,
            };
            if (course == null)
            {
                return NotFound();
            }

            return Ok(CourseDto);
        }

        // PUT: api/CoursesData/UpdateCourse/5
        [ResponseType(typeof(void))]
        [HttpPost]
        public IHttpActionResult UpdateCourse(int id, Course course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != course.CourseCode)
            {
                return BadRequest();
            }

            db.Entry(course).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseExists(id))
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

        // POST: api/CoursesData/AddCourse
        [ResponseType(typeof(Course))]
        [HttpPost]
        public IHttpActionResult AddCourse(Course course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Courses.Add(course);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = course.CourseCode }, course);
        }

        // POST: api/CoursesData/DeleteCourse/5
        [ResponseType(typeof(Course))]
        [HttpPost]
        public IHttpActionResult DeleteCourse(int id)
        {
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return NotFound();
            }

            db.Courses.Remove(course);
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

        private bool CourseExists(int id)
        {
            return db.Courses.Count(e => e.CourseCode == id) > 0;
        }
    }
}