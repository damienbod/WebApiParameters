using System.Web.Http;
using WebApiParameters.Models;

namespace WebApiParameters.Controllers
{
	[RoutePrefix("api/values")]
	public class ValuesController : ApiController
	{
		// http://localhost:49407/api/values/par1?id=2
		[Route("par1")]
		[HttpGet]
		public string Get(int id)
		{
			return "value";
		}

		// http://localhost:49407/api/values/par2?id1=1&id2=2&id3=3
		[Route("par2")]
		[HttpGet]
		public string GetWith3Parameters(int id1, long id2, double id3)
		{
			return "value";
		}

		// http://localhost:49407/api/values/par3/2/3/4
		[Route("par4/{id1}/{id2}/{id3}")]
		[HttpGet]
		public string GetWith3ParametersAttributeRouting(int id1, long id2, double id3)
		{
			return "value";
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
		// http://localhost:49407/api/values/par5
		[Route("par5")]
		[HttpPost]
		public string GetWithBody([FromBody] ParamsObject paramsObject)
		{
			return "value:" + paramsObject.Id1;
		}

		// http://localhost:49407/api/values/par6?id1=1&id2=2&id3=3
		[Route("par6")]
		[HttpGet]
		public string GetWithUri([FromUri] ParamsObject paramsObject)
		{
			return "value:" + paramsObject.Id1;
		}

	}
}
