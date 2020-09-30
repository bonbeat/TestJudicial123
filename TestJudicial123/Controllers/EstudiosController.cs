using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TestJudicial123.Models;

namespace TestJudicial123.Controllers
{
    public class EstudiosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Estudios      
        public ActionResult Index()
        {
            return View();
        }
            // GET: Estudios/Details/5
            public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstudiosJuridicos estudiosJuridicos = db.EstudiosJuridicos.Find(id);
            if (estudiosJuridicos == null)
            {
                return HttpNotFound();
            }
            return View(estudiosJuridicos);
        }

        // GET: Estudios/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Modal()
        {
            return View();
        }

        public ActionResult Error()
        {
            return View();
        }


        // POST: Estudios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Direccion,Telefono,Correo")] EstudiosJuridicos estudiosJuridicos)
        {
            //    
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:44371/Api/EstudiosJuridicos");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<EstudiosJuridicos>("EstudiosJuridicos", estudiosJuridicos);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Error de Servidor");

              return View(estudiosJuridicos);
        }

        // GET: Estudios/Edit/5
        public ActionResult Edit(int? id)
        {

            EstudiosJuridicos estudiosJuridicos = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:44371/Api/");
                //HTTP GET
                var responseTask = client.GetAsync("EstudiosJuridicos?id=" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<EstudiosJuridicos>();
                    readTask.Wait();

                    estudiosJuridicos = readTask.Result;
                }
            }

          
            return View(estudiosJuridicos);
        }

        // POST: Estudios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Direccion,Telefono,Correo")] EstudiosJuridicos estudiosJuridicos)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:44371/Api/EstudiosJuridicos");

                //HTTP POST
                var putTask = client.PutAsJsonAsync<EstudiosJuridicos>("EstudiosJuridicos", estudiosJuridicos);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }
            return View(estudiosJuridicos);
        }       

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
