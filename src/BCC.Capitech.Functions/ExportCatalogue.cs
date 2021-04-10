using System;
using System.Threading.Tasks;
using BCC.Capitech.Services;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace BCC.Capitech.Functions
{
    public class ExportCatalogue
    {
        public ExportCatalogue(DataImportService importSvc)
        {
            ImportSvc = importSvc;
        }

        public DataImportService ImportSvc { get; }

        [FunctionName("ExportCatalogue")]
        public async Task Run([TimerTrigger("0 0 * * *" // Runs every day at 1am
        #if DEBUG
             , RunOnStartup= true
        #endif
            )]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation("Starting import of catalogue (projects etc).");
            await ImportSvc.ImportCatalogueAsync(100);
            log.LogInformation("Completed import of catalogue.");
        }
    }
}
