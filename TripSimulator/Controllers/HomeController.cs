using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TripSimulator.Models;

namespace TripSimulator.Controllers
{
    public class HomeController : Controller
    {
        private readonly TripSimulatorContext _tripSimulatorDb;
        public HomeController(TripSimulatorContext tripContext)
        {
            _tripSimulatorDb = tripContext;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateCar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCar(Car car)
        {
            if (ModelState.IsValid)
            {
                _tripSimulatorDb.Add(car);
                _tripSimulatorDb.SaveChanges();
                return RedirectToAction("ViewCars");
            }
            else
            {
                return View();
            }
        }

        public IActionResult ViewCars()
        {
            List<Car> cars = _tripSimulatorDb.Cars.ToList();

            return View(cars);
        }
        public IActionResult UpdateCar(int carId)
        {
            Car car = _tripSimulatorDb.Cars.Find(carId);
            return View(car);
        }
        [HttpPost]
       public IActionResult UpdateCar(int carId, Car car)
        {
            Car updateCar = _tripSimulatorDb.Cars.Find(carId);
            updateCar.CarName = car.CarName;
            updateCar.Mpg = car.Mpg;
            updateCar.TankSize = car.TankSize;
            _tripSimulatorDb.Cars.Update(updateCar);
            _tripSimulatorDb.SaveChanges();
            return RedirectToAction("ViewCars");
        } 
        public IActionResult DeleteCar(int carId)
        {
            Car car = _tripSimulatorDb.Cars.Find(carId);
            _tripSimulatorDb.Cars.Remove(car);
            _tripSimulatorDb.SaveChanges();
            return RedirectToAction("ViewCars");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
