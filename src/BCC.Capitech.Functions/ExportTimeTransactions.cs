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
        public async Task Run([TimerTrigger("0 * * * *" //Every hour
        #if DEBUG
             , RunOnStartup= true
        #endif
            )]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation("Starting import of time transactions.");
            var dateFrom = DateTime.Today.AddMonths(-3);
            var dateTo = DateTime.Today.AddDays(1);
            await ImportSvc.ImportTimeTransactionsAsync(100, dateFrom, dateTo, null);
            await ImportSvc.ImportAbsencesAsync(100, dateFrom, dateTo);
            await ImportSvc.ImportAbsenceTransactionsAsync(100, dateFrom, dateTo);
            log.LogInformation("Completed import of time transactions.");
        }
    }
}
