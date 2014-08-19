using System.Web.Http;
using WebApiParameters.Models;

namespace WebApiParameters.Controllers
{
	[RoutePrefix("api/values")]
	public class ValuesController : ApiController
	{
		// http://localhost:49407/api/values/example1?id=2
		[Route("example1")]
		[HttpGet]
		public string Get(int id)
		{
			return "value";
		}

		// http://localhost:49407/api/values/example2?id1=1&id2=2&id3=3
		[Route("example2")]
		[HttpGet]
		public string GetWith3Parameters(int id1, long id2, double id3)
		{
			return "value";
		}

		// http://localhost:49407/api/values/example3/2/3/4
		[Route("example3/{id1}/{id2}/{id3}")]
		[HttpGet]
		public string GetWith3ParametersAttributeRouting(int id1, long id2, double id3)
		{
			return "value";
		}

		// http://localhost:49407/api/values/example4?id1=1&id2=2&id3=3
		[Route("example4")]
		[HttpGet]
		public string GetWithUri([FromUri] ParamsObject paramsObject)
		{
			return "value:" + paramsObject.Id1;
		}

		// User-Agent: Fiddler
		// Host: localhost:49407
		// Content-Length: 32
		// Content-Type: application/json
		//
		// { "Id1" : 2, "Id2": 2, "Id3": 3}
		//
		// OR
		// User-Agent: Fiddler
		// Host: localhost:49407
		// Content-Length: 32
		// Content-Type: application/json
		//
		// id1=1&id2=2&id3=3
		// http://localhost:49407/api/values/example5
		[Route("example5")]
		[HttpPost]
		public string GetWithBody([FromBody] ParamsObject paramsObject)
		{
			return "value:" + paramsObject.Id1;
		}

		

	}
}
