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
using System.Diagnostics;

namespace PassionProject.Controllers
{
    public class StudentDataController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/StudentData/ListStudents
        [HttpGet]
        public IEnumerable<StudentDto> ListStudents()
        {
            List<Student> Students = db.Students.ToList();
            List<StudentDto> StudentDtos = new List<StudentDto>();

            Students.ForEach(a => StudentDtos.Add(new StudentDto()
            {   
                StudentId = a.StudentId,
                FirstName = a.FirstName,
                LastName = a.LastName,
               // CourseName = a.Course.CourseName
            }));

            return StudentDtos;
        }

        // GET: api/StudentData/FindStudent/5
        [ResponseType(typeof(Student))]
        [HttpGet]
        public IHttpActionResult FindStudent(int id)
        {
            Student Student = db.Students.Find(id);
            StudentDto StudentDto = new StudentDto()
            {
                StudentId = Student.StudentId,
                FirstName = Student.FirstName,
                LastName = Student.LastName,

            };
            if (Student == null)
            {
                return NotFound();
            }

            return Ok(StudentDto);
        }

        // POST: api/StudentData/UpdateStudent/5
        [ResponseType(typeof(void))]
        [HttpPost]
        public IHttpActionResult UpdateStudent(int id, Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != student.StudentId)
            {
                return BadRequest();
            }

            db.Entry(student).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
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

        // POST: api/StudentData/AddStudent
        [ResponseType(typeof(Student))]
        [HttpPost]
        public IHttpActionResult AddStudent(Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Students.Add(student);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = student.StudentId }, student);
        }

        // POST: api/StudentData/DeleteStudent/5
        [ResponseType(typeof(Student))]
        [HttpPost]
        public IHttpActionResult DeleteStudent(int id)
        {
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }

            db.Students.Remove(student);
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

        private bool StudentExists(int id)
        {
            return db.Students.Count(e => e.StudentId == id) > 0;
        }
    }
}