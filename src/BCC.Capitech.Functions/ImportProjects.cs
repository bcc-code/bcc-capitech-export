using System;
using System.Threading.Tasks;
using BCC.Capitech.Services;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace BCC.Capitech.Functions
{
    public class ImportProjects
    {
        public ImportProjects(DataImportService importSvc)
        {
            ImportSvc = importSvc;
        }

        public DataImportService ImportSvc { get; }

        [FunctionName("ImportProjects")]
        public async Task Run([TimerTrigger("* */4 * * *" 
        #if DEBUG
             , RunOnStartup= true
        #endif
            )]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation("Starting import of projects.");
            await ImportSvc.ImportProjectsAsync(100);
            log.LogInformation("Completed import of projects.");
        }
    }
}
