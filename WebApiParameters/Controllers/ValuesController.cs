using System.Collections.Generic;
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
			return "recieved: " + id;
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
		// Content-Type: application/x-www-form-urlencoded
		//
		// id1=1&id2=2&id3=3
		//
		// User-Agent: Fiddler
        // Content-Type: application/xml
        // Host: localhost:49407
        // Content-Length: 65
		//
		// <ParamsObject><Id1>7</Id1><Id2>8</Id2><Id3>9</Id3></ParamsObject>
		// http://localhost:49407/api/values/example5
		[Route("example5")]
		[HttpPost]
		public string GetWithBody([FromBody] ParamsObject paramsObject)
		{
			return "value:" + paramsObject.Id1;
		}

		[Route("example6")]
		[HttpPost]
		public string GetListWithBody([FromBody] List<int> paramsObject)
		{
			if (paramsObject != null && paramsObject.Count > 0)
			{
				return "recieved a list with length:" + paramsObject.Count;
			}

			return "NOTHING RECIEVED...";
		}

		// http://localhost:49407/api/values/example7?paramsObject=2,paramsObject=4,paramsObject=9
		[Route("example7")]
		[HttpGet]
		public string GetListFromUri([FromUri] List<int> paramsObject)
		{
			if (paramsObject != null)
			{
				return "recieved a list with length:" + paramsObject.Count;
			}

			return "NOTHING RECIEVED...";
		}

		// TODO List from ModelBinder
		// TODO List from AttributeActionFilter
	}
}
