using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Diagnostics;
using PassionProject.Models;
using System.Web.Script.Serialization;
using PassionProject.Models.ViewModel;

namespace PassionProject.Controllers
{
    public class CourseController : Controller
    {
        private static readonly HttpClient client;
        private JavaScriptSerializer jss = new JavaScriptSerializer();

        static CourseController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44302/api/");
        }

        // GET: Course/List
        public ActionResult List()
        {
            //to communicate with CoursetData  api controller to access list of Courses
            //curl https://localhost:44302/api/Coursesdata/listcourses

            string url = "coursesdata/listcourses";
            HttpResponseMessage response = client.GetAsync(url).Result;

           // Debug.WriteLine("the code is");
            //Debug.WriteLine(response.StatusCode);

            IEnumerable<CourseDto> courses = response.Content.ReadAsAsync<IEnumerable<CourseDto>>().Result;
            
            return View(courses);
        }

        // GET: Course/Details/1
        public ActionResult Details(int id)
        {
            //to communicate with StudentData  api controller to access one Student
            //curl https://localhost:44302/api/Coursesdata/findcourse/{id}

            string url = "coursesdata/findcourse/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;


            CourseDto selectedcourse = response.Content.ReadAsAsync<CourseDto>().Result;
            //Debug.WriteLine("Students present:");
            //Debug.WriteLine(selectedstudent.FirstName);


            return View(selectedcourse);
        }

        public ActionResult Error()
        {
            return View();
        }
        // GET: Student/New
        public ActionResult New()
        {
            return View();
        }

        // POST: Course/Create
        [HttpPost]
        public ActionResult Create(Course course)
        {
            Debug.WriteLine("jsonpayload is working");

            //curl -H "Content-Type:application/json" -d @student.json https://localhost:44302/api/Coursesdata/addcourse
            string url = "coursesdata/addcourse";


            string jsonpayload = jss.Serialize(course);

            Debug.WriteLine(jsonpayload);
            HttpContent content = new StringContent(jsonpayload);
            content.Headers.ContentType.MediaType = "application/json";

            HttpResponseMessage response = client.PostAsync(url, content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("List");
            }
            else
            {
                return RedirectToAction("Error");
            }

        }

        // GET: Course/Edit/5
        public ActionResult Edit(int id)
        {
           

            string url = "coursesdata/findcourse/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;
            CourseDto selectedcourse = response.Content.ReadAsAsync<CourseDto>().Result;
          

            return View(selectedcourse);
        }


        // POST: Course/Update/5
        [HttpPost]
        public ActionResult Update(int id, Course course)
        {
            string url = "coursesdata/Updatecourse";


            string jsonpayload = jss.Serialize(course);

            Debug.WriteLine(jsonpayload);
            HttpContent content = new StringContent(jsonpayload);
            content.Headers.ContentType.MediaType = "application/json";

            HttpResponseMessage response = client.PostAsync(url, content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("List");
            }
            else
            {
                return RedirectToAction("Error");
            }

        }

        // GET: Course/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Course/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {

            string url = "coursesdata/Deletecourse";


            string jsonpayload = jss.Serialize("");

            Debug.WriteLine(jsonpayload);
            HttpContent content = new StringContent(jsonpayload);
            content.Headers.ContentType.MediaType = "application/json";

            HttpResponseMessage response = client.PostAsync(url, content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("List");
            }
            else
            {
                return RedirectToAction("Error");
            }

        }
    }
}
