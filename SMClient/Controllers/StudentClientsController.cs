using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SMClient.Helper;
using SMClient.Models;
using SMClient.ServiceReference1;

namespace SMClient.Controllers
{
    public class StudentClientsController : Controller
    {
        

        // GET: StudentClients
        public ActionResult Index()
        {
            List<StudentClient> listStudent = new List<StudentClient>();
            ServiceClient serviceClient = new ServiceClient();
            var inDbListStd = serviceClient.GetListStudents();
            //convert to view model
            foreach (var std in inDbListStd)
            {
                var studentViewModel = ConvertTypeHelper.ConvertServiceStudentToViewStudent(std);
                listStudent.Add(studentViewModel);
            }
            serviceClient.Close();
            return View(listStudent);
            
        }
        public ActionResult Details(int id)
        {
            ServiceClient client = new ServiceClient();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentClient studentClient = ConvertTypeHelper.ConvertServiceStudentToViewStudent(client.GetStudentById(id));
            if (studentClient == null)
            {
                return HttpNotFound();
            }
            return View(studentClient);
        }

        // GET: StudentClients/Details/5


        // GET: StudentClients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentClients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StudentId,Name,Birthday,Gender,Email,Introduce")] StudentClient studentClient)
        {
            if (ModelState.IsValid)
            {
                ServiceClient client = new ServiceClient();
                //convert to servive student

                var inDatabaseStudent = ConvertTypeHelper.ConvertViewStudentToServiceStudent(studentClient);
                var res = client.AddStudent(inDatabaseStudent);
                if (res != null)
                {
                    return RedirectToAction("Index");
                }
                client.Close();
            }
            return View(studentClient);
        }
            // GET: StudentClients/Edit/5
            public ActionResult Edit(int id)
        {
                ServiceClient client = new ServiceClient();
                var serviceStd = client.GetStudentById(id);
                var viewStd = ConvertTypeHelper.ConvertServiceStudentToViewStudent(serviceStd);
                if (viewStd == null)
                {
                    return RedirectToAction("Index");
                }
                return View(viewStd);
            }

        // POST: StudentClients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StudentId,Name,Birthday,Gender,Email,Introduce")] StudentClient studentClient)
        {
            if (ModelState.IsValid)
            {
                ServiceClient client = new ServiceClient();
                client.UpdateStudent(studentClient.Id, ConvertTypeHelper.ConvertViewStudentToServiceStudent(studentClient));
                client.Close();
                return RedirectToAction("Index");

            }
            return View(studentClient);
        }

        // GET: StudentClients/Delete/5
        public ActionResult Delete(int id)
        {
            ServiceClient client = new ServiceClient();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentClient studentClient = ConvertTypeHelper.ConvertServiceStudentToViewStudent(client.GetStudentById(id));
            if (studentClient == null)
            {
                return HttpNotFound();
            }
            return View(studentClient);
        }

        // POST: StudentClients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ServiceClient client = new ServiceClient();
            client.DeleteStudent(id);
            client.Close();
            return RedirectToAction("Index");
        }

       
    }
}
