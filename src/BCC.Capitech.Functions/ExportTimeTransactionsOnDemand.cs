using System;
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
    public class ExportTimeTransactionsOnDemand
    {
        public ExportTimeTransactionsOnDemand(DataImportService importSvc)
        {
            ImportSvc = importSvc;
        }

        public DataImportService ImportSvc { get; }

        [FunctionName("ExportTimeTransactionsOnDemand")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            log.LogInformation("Starting export of time transactions to SQL.");
            var beginningOfYear = new DateTime(DateTime.Today.Year, 1, 1);
            var dateFrom = beginningOfYear;
            var dateTo = DateTime.Today.AddDays(1);
            await ImportSvc.ImportTimeTransactionsAsync(100, dateFrom, dateTo, null);
            await ImportSvc.ImportAbsencesAsync(100, dateFrom, dateTo);
            await ImportSvc.ImportAbsenceTransactionsAsync(100, dateFrom, dateTo);
            log.LogInformation("Completed export of time transactions.");

            return new OkResult();
        }
    }
}

