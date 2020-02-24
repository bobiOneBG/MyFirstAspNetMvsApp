using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyFirstMvsApp.Filters;
using MyFirstMvsApp.Models;
using MyFirstMvsApp.Models.Home;
using MyFirstMvsApp.Services;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace MyFirstMvsApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUsersService usersServices;

        public HomeController(ILogger<HomeController> logger, IUsersService usersServices)
        {
            this._logger = logger;
            this.usersServices = usersServices;
        }

        public IActionResult Index()
        {
            // return this.Forbid();
            IEnumerable<string> usernames = this.usersServices.GetUsernames();

            IndexViewModel viewModel = new IndexViewModel { Usernames = usernames };

            return this.View(viewModel);
        }
        [ValidateModelStateFilter]
        public IActionResult AcceptForm(FormInputModel input)
        {            
            if (!ModelState.IsValid)
            {
                return this.Content("Not Ok!");
            }

            return this.Content("Ok!");
        }

        public IActionResult Errors(string code)
        {
            return this.Content(code);
        }
        [AddHeader("X-Debug", "Works")]
        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }

        public class FormInputModel
        {
            [Required]
            public string Search { get; set; }
        }
    }
}
