using API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using API.Services;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly OfxService _ofxService;

        public UploadController(OfxService ofxService) => _ofxService = ofxService;

        [HttpPost]
        public IActionResult Post()
        {
            IEnumerable<Transaction> transactions = null;
            foreach (var file in Request.Form.Files)
            {
                var fileStream = file.OpenReadStream();
                transactions = _ofxService.ImportFiles(fileStream);
            }

            return Created(nameof(Post), transactions.OrderBy(t => t.DatePosted));
        }
      
    }
}