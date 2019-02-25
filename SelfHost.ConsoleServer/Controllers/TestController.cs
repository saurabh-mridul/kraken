using System.Collections.Generic;
using System.Web.Http;

namespace SelfHost.ConsoleServer.Controllers
{
    public class TestController : ApiController
    {
        [HttpGet]
        public IEnumerable<Test> GetTests()
        {
            return new List<Test> {
                new Test{ id=1, title="home", homeAddress="bangalore"},
                new Test{ id=2, title="home1", homeAddress="bangalore"},
                new Test{ id=3, title="home2", homeAddress="bangalore"},
                new Test{ id=4, title="home3", homeAddress="bangalore"}
            };
        }

        [HttpGet]
        public Test SetTest()
        {
            return new Test() { id = 10, title = "there there", homeAddress = "home" };
        }
    }


    public class Test
    {
        public int id { get; set; }
        public string title { get; set; }
        public string homeAddress { get; set; }
    }
}
