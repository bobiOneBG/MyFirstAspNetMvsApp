namespace MyFirstMvsApp.ViewComponents
{
    using Microsoft.AspNetCore.Mvc;
    using MyFirstMvsApp.Services;
    using System.Collections.Generic;

    public class LastUserViewComponent : ViewComponent
    {
        private readonly IUsersService usersService;

        public LastUserViewComponent(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public IViewComponentResult Invoke()
        {
            var model = 
                new LastUserViewComponentViewModel 
                { Username = usersService.LatestUsername() };

            return View(model);
        }
    }

    public class LastUserViewComponentViewModel
    {
        public string Username { get; set; }
    }
}