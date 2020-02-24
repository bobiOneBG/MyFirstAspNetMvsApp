namespace MyFirstMvsApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class OtherController:Controller
    {
        public IActionResult Index()
        {
            return this.Content("Index");
        }
    }
}
