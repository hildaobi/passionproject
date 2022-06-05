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
    public class StudentController : Controller
    {
        // GET: Student/List
        public ActionResult List()
        {
            //to communicate with StudentData  api controller to access list of Students
            //curl https://localhost:44302/api/Studentdata/liststudents
            
            HttpClient client = new HttpClient(){ };
            string url = "https://localhost:44302/api/Studentdata/liststudents";
            HttpResponseMessage response = client.GetAsync(url).Result;

            Debug.WriteLine("the code is");
            Debug.WriteLine(response.StatusCode);

            IEnumerable<StudentDto> students = response.Content.ReadAsAsync<IEnumerable<StudentDto>>().Result;
            Debug.WriteLine("Students number:");
            Debug.WriteLine(students.Count());

            return View(students);
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            //to communicate with StudentData  api controller to access one of Students
            //curl https://localhost:44302/api/Studentdata/findstudent/{id}

            HttpClient client = new HttpClient() { };
            string url = "https://localhost:44302/api/Studentdata/findstudent/"+id;
            HttpResponseMessage response = client.GetAsync(url).Result;

            Debug.WriteLine("the code is");
            Debug.WriteLine(response.StatusCode);

           StudentDto selectedstudent = response.Content.ReadAsAsync<StudentDto>().Result;
            Debug.WriteLine("Students npresent:");
            Debug.WriteLine(selectedstudent.FirstName);

           
            return View(selectedstudent);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
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

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Student/Edit/5
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

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Student/Delete/5
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
