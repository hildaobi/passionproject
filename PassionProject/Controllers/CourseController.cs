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

        // GET: course/Details/1
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

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(Student student)
        {
            Debug.WriteLine("jsonpayload is working");

            //curl -H "Content-Type:application/json" -d @student.json https://localhost:44302/api/Studentdata/addstudent
            string url = "studentdata/addstudent";


            string jsonpayload = jss.Serialize(student);

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

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
           // UpdateStudent ViewModel = new UpdateStudent();

            string url = "studentdata/findstudent/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;
            StudentDto selectedStudent = response.Content.ReadAsAsync<StudentDto>().Result;
           // ViewModel.SelectedStudent = selectedStudent;

            url = "coursedata/listcourses/";
            response = client.GetAsync(url).Result;
            IEnumerable<CourseDto> CourseOption = response.Content.ReadAsAsync<IEnumerable<CourseDto>>().Result;

            //ViewModel.CourseOptions = CourseOption;

            return View(selectedStudent);
        }


        // POST: Student/Update/5
        [HttpPost]
        public ActionResult Update(int id, Student student)
        {
            string url = "studentdata/Updatestudent";


            string jsonpayload = jss.Serialize(student);

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

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {

            string url = "studentdata/Deletestudent";


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
