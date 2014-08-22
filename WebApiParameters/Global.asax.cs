using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WebApiParameters
{
	public class WebApiApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			// This is required if you use XML serialization
			var xml = GlobalConfiguration.Configuration.Formatters.XmlFormatter;
			xml.UseXmlSerializer = true;

			AreaRegistration.RegisterAllAreas();
			GlobalConfiguration.Configure(WebApiConfig.Register);
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
		}
	}
}
