using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dojodachi.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace dojodachi.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            int? seshFull = HttpContext.Session.GetInt32("Fullness");
            if(seshFull == null)
            {
                HttpContext.Session.SetInt32("Fullness", 20);
            }
            ViewBag.Fullness = HttpContext.Session.GetInt32("Fullness");

            int? seshHappiness = HttpContext.Session.GetInt32("Happiness");
            if(seshFull == null)
            {
                HttpContext.Session.SetInt32("Happiness", 20);
            }
            ViewBag.Happiness = HttpContext.Session.GetInt32("Happiness");

            int? seshMeal = HttpContext.Session.GetInt32("Meal");
            if(seshFull == null)
            {
                HttpContext.Session.SetInt32("Meal", 3);
            }
            ViewBag.Meal = HttpContext.Session.GetInt32("Meal");

            int? seshEnergy = HttpContext.Session.GetInt32("Energy");
            if(seshFull == null)
            {
                HttpContext.Session.SetInt32("Energy", 50);
            }
            ViewBag.Energy = HttpContext.Session.GetInt32("Energy");

            if(HttpContext.Session.GetInt32("Happiness") == 0 || HttpContext.Session.GetInt32("Fullness") == 0)
            {
                ViewBag.Result = true;
                TempData["Message"] = "Dachi has died";
            }

            if(HttpContext.Session.GetInt32("Happiness") >= 100 && HttpContext.Session.GetInt32("Fullness") >= 100)
            {
                ViewBag.Result = true;
                TempData["Message"] = "You Won!";
            }

            return View();
        }

        [HttpGet("feed")]
        public IActionResult Feed()
        {
            Random rand = new Random();

            int? meal = HttpContext.Session.GetInt32("Meal");
            if(meal > 0)
            {
                meal -= 1;
                HttpContext.Session.SetInt32("Meal", (int)meal);
                ViewBag.Meal = HttpContext.Session.GetInt32("Meal");

                int chance = rand.Next(1,5);
                if(chance == 1)
                {
                    TempData["Message"] = "Your dojodachi did not like its food! :(";
                }
                else
                {
                    int? fullness = HttpContext.Session.GetInt32("Fullness");
                    fullness += rand.Next(5,11);
                    HttpContext.Session.SetInt32("Fullness", (int)fullness);
                    TempData["Message"] = "You fed your dachi, it's happy";
                }
                ViewBag.Fullness = HttpContext.Session.GetInt32("Fullness");
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Message"] = "You don't have enough meals";
                return RedirectToAction("Index");
            }
        }

        [HttpGet("play")]
        public IActionResult Play()
        {
            Random rand = new Random();

            int? energy = HttpContext.Session.GetInt32("Energy");
            energy -= 5;
            HttpContext.Session.SetInt32("Energy", (int)energy);
            ViewBag.Energy = HttpContext.Session.GetInt32("Energy");
           
            int chance = rand.Next(1,5);
            if(chance == 1)
            {
                TempData["Message"] = "Your dojodachi did not that! :(";
            }

            int? happiness = HttpContext.Session.GetInt32("Happiness");
            happiness += rand.Next(5,11);
            HttpContext.Session.SetInt32("Happiness", (int)happiness);
            ViewBag.Happiness = HttpContext.Session.GetInt32("Happiness");

            TempData["Message"] = "You played with your dojodachi, it's happy!";

            return RedirectToAction("Index");
        }

        [HttpGet("work")]
        public IActionResult Work()
        {
            Random rand = new Random();

            int? energy = HttpContext.Session.GetInt32("Energy");
            energy -= 5;
            HttpContext.Session.SetInt32("Energy", (int)energy);
            ViewBag.Energy = HttpContext.Session.GetInt32("Energy");

            int? meal = HttpContext.Session.GetInt32("Meal");
            meal += rand.Next(1,4);
            HttpContext.Session.SetInt32("Meal", (int)meal);
            ViewBag.Meal = HttpContext.Session.GetInt32("Meal");

            TempData["Message"] = "You worked and got more meals";

            return RedirectToAction("Index");
        }

        [HttpGet("sleep")]
        public IActionResult Sleep()
        {
            int? energy = HttpContext.Session.GetInt32("Energy");
            energy += 15;
            HttpContext.Session.SetInt32("Energy", (int)energy);
            ViewBag.Energy = HttpContext.Session.GetInt32("Energy");            

            int? fullness = HttpContext.Session.GetInt32("Fullness");
            fullness -= 5;
            HttpContext.Session.SetInt32("Fullness", (int)fullness);
            ViewBag.Fullness = HttpContext.Session.GetInt32("Fullness");

            int? happiness = HttpContext.Session.GetInt32("Happiness");
            happiness -= 5;
            HttpContext.Session.SetInt32("Happiness", (int)happiness);
            ViewBag.Happiness = HttpContext.Session.GetInt32("Happiness");

            TempData["Message"] = "Sleeping";

            return RedirectToAction("Index");
        }

        [HttpGet("reset")]
        public IActionResult Reset()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }


}
