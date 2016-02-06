namespace BitCalculator.Areas.Help
{
    using System.Web.Mvc;

    public class HelpAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Help";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Help_default",
                "Help/{action}/{id}",
                defaults: new { controller = "Help", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}