using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarDealer.Models;
using CarDealer.ViewModels;

namespace CarDealer.Controllers
{
    public class HomeController : Controller
    {

        private readonly ICarRepo _carRepo;


        public HomeController(ICarRepo carRepo)
        {
            _carRepo = carRepo;            
        }

        public IActionResult Index()
        {
            var cars = _carRepo
                .GetCars()
                .Where(x => x != null && x.Description != null && x.Id != null && x.MiniaturePhotoUrl != null && x.PhotoUrl != null && x.Title != null)
                .ToList();

            var homeViewModel = new HomeViewModel()
            {
                Title = "Oferty sprzedaży samochodów",
                Cars = cars
            };

            return View(homeViewModel);
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




    }
}
