using System.Collections.Generic;
using System.Web.Http;

namespace SelfHost.ConsoleServer.Controllers
{
    public class TestController : ApiController
    {
        public IEnumerable<string> GetTests()
        {
            return new string[] { "Hello", "World" };
        }
    }
}
