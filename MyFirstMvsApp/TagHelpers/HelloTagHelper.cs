using Microsoft.AspNetCore.Razor.TagHelpers;
using MyFirstMvsApp.Services;

namespace MyFirstMvsApp.TagHelpers
{
    [HtmlTargetElement("h2")]
    [HtmlTargetElement("h3")]
    [HtmlTargetElement("h4", Attributes = "greeting-name")]
    public class HelloTagHelper: TagHelper
    {
        private readonly IUsersService usersService;

        public HelloTagHelper(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public string GreetingName { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.SetAttribute("Bobi", "Bingou");

            output.Content.SetContent("Changed from taghelper");

            output.PreElement.SetContent(this.GreetingName);

            output.PreContent.SetContent("Pre_");

            output.PostContent.SetContent("_" + this.usersService.Count());
        }
    }
}