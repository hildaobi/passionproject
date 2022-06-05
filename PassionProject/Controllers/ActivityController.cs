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
    public class ActivityController : Controller
    {
        public ActionResult List()
        {
            //to communicate with ActitvityData  api controller to access list of Activities
            //curl https://localhost:44302/api/Activitydata/listActivities

            HttpClient client = new HttpClient() { };
            string url = "https://localhost:44302/api/Activitydata/listActivities";
            HttpResponseMessage response = client.GetAsync(url).Result;

            Debug.WriteLine("the code is");
            Debug.WriteLine(response.StatusCode);

            IEnumerable<ActivityDto> activities = response.Content.ReadAsAsync<IEnumerable<ActivityDto>>().Result;
            Debug.WriteLine("Activities number:");
            Debug.WriteLine(activities.Count());

            return View(activities);
        }

        // GET: Activity/Details/1
        public ActionResult Details(int id)
        {
            //to communicate with ActivityData  api controller to access one of Activities
            //curl https://localhost:44302/api/Activitydata/findActivity/{id}

            HttpClient client = new HttpClient() { };
            string url = "https://localhost:44302/api/Activitydata/findActivity/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;

            Debug.WriteLine("the code is");
            Debug.WriteLine(response.StatusCode);

            ActivityDto selectedactivity = response.Content.ReadAsAsync<ActivityDto>().Result;
            Debug.WriteLine("Activities npresent:");
            Debug.WriteLine(selectedactivity.Description);


            return View(selectedactivity);
        }

        // GET: Activity/Create
        [HttpPost]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Activity/Create
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

        // GET: Activity/Edit/1
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Activity/Edit/5
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

        // GET: Activity/Delete/1
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Activity/Delete/1
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
