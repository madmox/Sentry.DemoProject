using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.IO.Compression;
using System.Threading.Tasks;

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
        public async Task<IActionResult> UnpackZipFile()
        {
            try
            {
                int entriesCount = 0;
                var buffer = new byte[1024];
                var re = 0;
                do
                {
                    re = await this.Request.Body.ReadAsync(buffer, 0, buffer.Length);
                } while (re > 0);
                this.Request.Body.Position = 0;

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
