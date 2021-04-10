using System;
using System.Threading.Tasks;
using BCC.Capitech.Services;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace BCC.Capitech.Functions
{
    public class ExportTimeTransactions
    {
        public ExportTimeTransactions(DataImportService importSvc)
        {
            ImportSvc = importSvc;
        }

        public DataImportService ImportSvc { get; }

        [FunctionName("ExportTimeTransactions")]
        public async Task Run([TimerTrigger("0 1 * * *" //Runs every day at 1am
        #if DEBUG
             , RunOnStartup= true
        #endif
            )]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation("Starting import of time transactions.");
            await ImportSvc.ImportTimeTransactionsAsync(100, DateTime.Today.AddMonths(-3), DateTime.Today.AddDays(1), null);
            log.LogInformation("Completed import of time transactions.");
        }
    }
}
