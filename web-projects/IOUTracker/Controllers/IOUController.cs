using IOUTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IOUTracker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IOUController : Controller
    {
        ITrackerRepository repository;
        ILogger<IOUController> logger;

        public IOUController(ITrackerRepository repository, ILogger<IOUController> logger)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.logger = logger ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpPost]
        public async Task<ActionResult<IOU>> Grant(IOUCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var iou = model.CreateIOU();
            await repository.CreateIOUAsync(iou);

            return iou;
        }
    }
}
