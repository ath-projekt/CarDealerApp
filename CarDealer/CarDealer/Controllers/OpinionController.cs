using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarDealer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarDealer.Controllers
{

    [Authorize]
    public class OpinionController : Controller
    {
        private readonly IOpinionRepo _opinionRepo;

        public OpinionController(IOpinionRepo opinionRepo)
        {
            _opinionRepo = opinionRepo;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Opinion opinion)
        {
            if (ModelState.IsValid)
            {
                if (opinion.Id == 0)
                {
                    opinion.Id = _opinionRepo.GetNewOpinionId();
                }

                _opinionRepo.AddOpinion(opinion);
                return RedirectToAction("OpinionSent");
            }

            return View(opinion);
        }

        public IActionResult OpinionSent(Opinion opinion)
        {
            return View();
        }

    }






}