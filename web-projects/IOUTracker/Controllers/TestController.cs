using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IOUTracker.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        public IDictionary<string,double> Index()
        {
            IDictionary<string, double> dict = new Dictionary<string, double>();
            dict.Add("Bob", 12.7);


            return dict;
        }
    }
}
