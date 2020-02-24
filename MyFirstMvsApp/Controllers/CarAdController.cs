namespace MyFirstMvsApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using MyFirstMvsApp.Models.CarAd;
    using MyFirstMvsApp.Services;

    public class CarAdController : Controller
    {
        private readonly IConfiguration configuration;
        private readonly ICounterService counterService;

        public CarAdController(IConfiguration configuration, ICounterService counterService)
        {
            this.configuration = configuration;
            this.counterService = counterService;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(CreateInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            return this.Json(input);
        }
    }
}
