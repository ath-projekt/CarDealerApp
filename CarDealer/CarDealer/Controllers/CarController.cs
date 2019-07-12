using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CarDealer.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace CarDealer.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarRepo _carRepo;
        private IHostingEnvironment _env;



        public CarController(ICarRepo carRepo, IHostingEnvironment env)
        {
            _carRepo = carRepo;
            _env = env;
        }


        // GET: /<controller>/
        public IActionResult Index()
        {
            var samochody = _carRepo.GetCars();

            return View(samochody);
        }

        public IActionResult Details(int id)
        {
            var samochod = _carRepo.GetCar(id);

            if (samochod == null)
                return NotFound();

            return View(samochod);
        }


        public IActionResult Create(string FileName)
        {
            if (!string.IsNullOrEmpty(FileName))
            {
                ViewBag.ImgPath = "/Images/" + FileName;
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Car car)
        {
            if (ModelState.IsValid)
            {
                _carRepo.AddCar(car);
                return RedirectToAction("Index");
            }
            return View(car);
        }


        public IActionResult Edit(int Id, string FileName)
        {
            var car = _carRepo.GetCar(Id);

            if (car == null)
                return NotFound();

            if (!string.IsNullOrEmpty(FileName))
            {
                ViewBag.ImgPath = "/Images/" + FileName;
            }
            else
            {
                ViewBag.ImgPath = car.PhotoUrl;
            }

            return View(car);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Car car)
        {
            if (ModelState.IsValid)
            {
                _carRepo.EditCar(car);
                return RedirectToAction("Index");
            }
            return View(car);
        }


        public IActionResult Delete(int Id)
        {
            var car = _carRepo.GetCar(Id);

            if (car == null)
                return NotFound();

            return View(car);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id, string photoUrl)
        {
            var car = _carRepo.GetCar(id);
            _carRepo.DeleteCar(car);

            //usuwaniue pliku

            if (photoUrl != null)
            {
                var webRoot = _env.WebRootPath;
                var filePath = Path.Combine(webRoot.ToString() + photoUrl);
                System.IO.File.Delete(filePath);
            }

            return RedirectToAction("Index");
        }

        [HttpPost("uploadFile")]
        public async Task<IActionResult> uploadFile(IFormCollection form)
        {
            var webRoot = _env.WebRootPath;
            var filePath = Path.Combine(webRoot.ToString() + "\\images\\" + form.Files[0].FileName);

            if (form.Files[0].FileName.Length > 0)
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await form.Files[0].CopyToAsync(stream);
                }
            }

            if (Convert.ToString(form["Id"]) == string.Empty || Convert.ToString(form["Id"]) == "0")
                return RedirectToAction(nameof(Create), new { FileName = Convert.ToString(form.Files[0].FileName) });

            return RedirectToAction(nameof(Edit), new
            {
                FileName = Convert.ToString(form.Files[0].FileName),
                id = Convert.ToString(form["Id"])
            });

        }

    }
}
