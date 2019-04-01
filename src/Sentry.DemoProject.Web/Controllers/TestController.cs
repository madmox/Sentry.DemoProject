using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.IO.Compression;

namespace Sentry.DemoProject.Web.Controllers
{
    [Route("api/test")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ILogger _logger;

        public TestController(ILogger<TestController> logger)
        {
            this._logger = logger;
        }

        [HttpPost]
        [Route(@"")]
        public IActionResult UnpackZipFile()
        {
            try
            {
                int entriesCount = 0;
                using (var zip = new ZipArchive(this.Request.Body))
                {
                    entriesCount = zip.Entries.Count;
                }
                return new OkObjectResult($"Found {entriesCount} entries in the ZIP file");
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, "Could not unpack zip file");
                return new BadRequestResult();
            }
        }
    }
}
