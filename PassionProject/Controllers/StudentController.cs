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
    public class StudentController : Controller
    {
        private static readonly HttpClient client;
        private  JavaScriptSerializer jss = new JavaScriptSerializer();

        static StudentController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44302/api/");
        }

        // GET: Student/List
        public ActionResult List()
        {
            //to communicate with StudentData  api controller to access list of Students
            //curl https://localhost:44302/api/Studentdata/liststudents
            
            string url = "studentdata/liststudents";
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
            //to communicate with StudentData  api controller to access one Student
            //curl https://localhost:44302/api/Studentdata/findstudent/{id}

            string url = "studentdata/findstudent/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;


           StudentDto selectedstudent = response.Content.ReadAsAsync<StudentDto>().Result;
            //Debug.WriteLine("Students present:");
            //Debug.WriteLine(selectedstudent.FirstName);

           
            return View(selectedstudent);
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

            HttpResponseMessage response = client.PostAsync(url,content).Result;
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
           

            //to communicate with StudentData  api controller to access one Student
            //curl https://localhost:44302/api/Studentdata/editstudent/{id}

            string url = "studentdata/findstudent/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;


            StudentDto selectedStudent = response.Content.ReadAsAsync<StudentDto>().Result;
            //Debug.WriteLine("Students present:");
            //Debug.WriteLine(selectedstudent.FirstName);


            return View(selectedStudent);
        }


        // POST: Student/Update/5
        [HttpPost]
        public ActionResult Update(int id,Student student)
        {

            //to communicate with StudentData  api controller to access one Student
            //curl https://localhost:44302/api/Studentdata/updatestudent/{id}
            
            string url = "studentdata/updatestudent/" +id; ;


            string jsonpayload = jss.Serialize(student);

           // Debug.WriteLine(jsonpayload);
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

        // GET: Student/DeleteConfirm/5
        public ActionResult DeleteConfirm(int id)
        {

            //to communicate with StudentData  api controller to access one Student
            //curl https://localhost:44302/api/Studentdata/findstudent/{id}

            string url = "studentdata/findstudent/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;


            StudentDto selectedStudent = response.Content.ReadAsAsync<StudentDto>().Result;
            //Debug.WriteLine("Students present:");
            //Debug.WriteLine(selectedstudent.FirstName);


            return View(selectedStudent);

           
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            //Debug.WriteLine("jsonpayload is working");
            string url = "studentdata/deletestudent/"+id;

            HttpContent content = new StringContent("");
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
