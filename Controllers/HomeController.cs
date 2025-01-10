using AllTheBeansApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AllTheBeansApp.Controllers
{
    // Define HomeController - inherits from Controller
    public class HomeController : Controller
    {
        private readonly BeansRepository _beansRepository;

        // Constructor to initialise BeansRepository
        public HomeController()
        {
            _beansRepository = new BeansRepository();
        }

        // Index page - determine day of week
        public IActionResult Index(DayOfWeek? currentDay)
        {
            // Use today as Bean of the Day
            var day = currentDay ?? DateTime.Now.DayOfWeek;
            // Get bean of the day from the repository
            var beanOfTheDay = _beansRepository.GetBeanOfTheDay(day);
            // Pass bean of the day to the view
            return View(beanOfTheDay);
        }

        // use current day to get previous day (-1)
        public IActionResult PreviousDay(DayOfWeek currentDay)
        {
            var previousDay = (DayOfWeek)(((int)currentDay - 1 + 7) % 7);
            var beanOfTheDay = _beansRepository.GetBeanOfTheDay(previousDay);
            return View("Index", beanOfTheDay);
        }
        // use current day to get next day (+1)
        public IActionResult NextDay(DayOfWeek currentDay)
        {
            var nextDay = (DayOfWeek)(((int)currentDay + 1) % 7);
            var beanOfTheDay = _beansRepository.GetBeanOfTheDay(nextDay);
            return View("Index", beanOfTheDay);
        }
        // get all beans for Our Beans page
        public IActionResult AllBeans()
        {
            var allBeans = _beansRepository.GetAllBeans();
            return View(allBeans);
        }

        public IActionResult AboutUs()
        {
            return View();
        }
    }
}
