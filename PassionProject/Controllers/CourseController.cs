using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Diagnostics;
using PassionProject.Models;

namespace PassionProject.Controllers
{
    public class CourseController : Controller
    {
        // GET: Course/List
        public ActionResult List()
        {
            //to communicate with CourseData  api controller to access list of Courses
            //curl https://localhost:44302/api/Coursedata/listcourses

            HttpClient client = new HttpClient() { };
            string url = "https://localhost:44302/api/Coursedata/listCourses";
            HttpResponseMessage response = client.GetAsync(url).Result;

            Debug.WriteLine("the code is");
            Debug.WriteLine(response.StatusCode);

            IEnumerable<CourseDto> courses = response.Content.ReadAsAsync<IEnumerable<CourseDto>>().Result;
            Debug.WriteLine("Courses number:");
            Debug.WriteLine(courses.Count());

            return View(courses);
        }

        // GET: Course/Details/3
        public ActionResult Details(int id)
        {
            //to communicate with CourseData  api controller to access one of Courses
            //curl https://localhost:44302/api/Coursedata/findcourse/{id}

            HttpClient client = new HttpClient() { };
            string url = "https://localhost:44302/api/Coursedata/findcourse/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;

            Debug.WriteLine("the code is");
            Debug.WriteLine(response.StatusCode);

            CourseDto selectedcourse = response.Content.ReadAsAsync<CourseDto>().Result;
            Debug.WriteLine("Courses npresent:");
            Debug.WriteLine(selectedcourse.CourseName);


            return View(selectedcourse);
        }

        // GET: Course/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Course/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Course/Edit/3
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Course/Edit/3
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Course/Delete/3
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Course/Delete/3
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

