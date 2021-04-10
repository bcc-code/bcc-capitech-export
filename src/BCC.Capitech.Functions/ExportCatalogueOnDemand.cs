using System.IO;
using System.Net;
using System.Threading.Tasks;
using BCC.Capitech.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;

using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace BCC.Capitech.Functions
{
    public class ExportCatalogueOnDemand
    {
        public ExportCatalogueOnDemand(DataImportService importSvc)
        {
            ImportSvc = importSvc;
        }

        public DataImportService ImportSvc { get; }

        [FunctionName("ExportCatalogueOnDemand")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            log.LogInformation("Starting import of projects.");
            await ImportSvc.ImportCatalogueAsync(100);
            log.LogInformation("Completed import of projects.");

            return new OkResult();
        }
    }
}

