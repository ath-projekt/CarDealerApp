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
        private IHostingEnvironment _hostingEnvironment;

        public CarController(ICarRepo carRepo, IHostingEnvironment hostingEnvironment)
        {
            _carRepo = carRepo;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            var cars = _carRepo.GetCars();

            return View(cars);
        }

        public IActionResult Details(int id)
        {
            var car = _carRepo.GetCar(id);

            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        public IActionResult Create(string photoUrl)
        {
            if (!string.IsNullOrEmpty(photoUrl))
            {
                ViewBag.ImagePath = "/Images/" + photoUrl;
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

        public IActionResult Edit(int id, string photoUrl)
        {
            var car = _carRepo.GetCar(id);

            if (car == null)
            {
                return NotFound();
            }

            if (!string.IsNullOrEmpty(photoUrl))
            {
                ViewBag.ImagePath = "/Images/" + photoUrl;
            }
            else
            {
                ViewBag.ImagePath = car.PhotoUrl;
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

        public IActionResult Delete(int id)
        {
            var car = _carRepo.GetCar(id);

            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id, string photoUrl)
        {
            var car = _carRepo.GetCar(id);

            _carRepo.DeleteCar(car);

            if (photoUrl != null)
            {
                var webRoot = _hostingEnvironment.WebRootPath;
                var filePath = Path.Combine(webRoot.ToString() + photoUrl);
                System.IO.File.Delete(filePath);
            }

            return RedirectToAction("Index");
        }

        [HttpPost("uploadFile")]
        public async Task<IActionResult> UploadFile(IFormCollection form)
        {
            var webRoot = _hostingEnvironment.WebRootPath;
            var filePath = Path.Combine(webRoot.ToString() + @"\images\" + form.Files[0].FileName);

            if (form.Files[0].FileName.Length > 0)
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await form.Files[0].CopyToAsync(stream);
                }
            }

            if (Convert.ToString(form["Id"]) == string.Empty || Convert.ToString(form["Id"]) == "0")
            {
                return RedirectToAction(nameof(Create), new { FileName = Convert.ToString(form.Files[0].FileName) });
            }

            return RedirectToAction(nameof(Create), new { FileName = Convert.ToString(form.Files[0].FileName) });

        }
        


    }
}