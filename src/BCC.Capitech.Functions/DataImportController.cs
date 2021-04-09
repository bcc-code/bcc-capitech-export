//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using BCC.Capitech.Services;

//namespace BCC.Capitech.ImportApi.Controllers
//{
//    [Route("api/import")]
//    [Authorize(Policies.Execute)]
//    [ApiController]
//    public class DataImportController : ControllerBase
//    {
//        protected DataImportService ImportSvc { get; }

//        public DataImportController(DataImportService importSvc)
//        {
//            ImportSvc = importSvc;
//        }

//        [HttpGet]
//        [Route("all")]
//        public async Task<ActionResult> ImportAllAsync(int? clientId, DateTime? from, DateTime? to)
//        {
//            await ImportSvc.ImportAllAsync(clientId, from, to);
//            return Ok();
//        }

//        [HttpGet]
//        [Route("catalogue")]
//        public async Task<ActionResult> ImportCatalogueAsync(int? clientId)
//        {
//            await ImportSvc.ImportCatalogueAsync(clientId);
//            return Ok();
//        }

//        [HttpGet]
//        [Route("employees")]
//        public async Task<ActionResult> ImportEmployeesAsync(int? clientId)
//        {
//            await ImportSvc.ImportEmployeesAsync(clientId);
//            return Ok();
//        }

//        [HttpGet]
//        [Route("operational-plans")]
//        public async Task<ActionResult> ImportOperationalPlansAsync(int? clientId, DateTime? from, DateTime? to)
//        {
//            await ImportSvc.ImportOperationalPlansAsync(clientId, from.GetValueOrDefault(DataImportService.MIN_FROM_DATE), to.GetValueOrDefault(DateTime.Today.AddDays(1)));
//            return Ok();
//        }

//        [HttpGet]
//        [Route("absences")]
//        public async Task<ActionResult> ImportAbsencesAsync(int? clientId, DateTime? from, DateTime? to)
//        {
//            await ImportSvc.ImportAbsencesAsync(clientId, from.GetValueOrDefault(DataImportService.MIN_FROM_DATE), to.GetValueOrDefault(DateTime.Today.AddDays(1)));
//            return Ok();
//        }

//        [HttpGet]
//        [Route("absencetransactions")]
//        public async Task<ActionResult> ImportAbsenceTransactionsAsync(int? clientId, DateTime? from, DateTime? to)
//        {
//            await ImportSvc.ImportAbsenceTransactionsAsync(clientId, from.GetValueOrDefault(DataImportService.MIN_FROM_DATE), to.GetValueOrDefault(DateTime.Today.AddDays(1)));
//            return Ok();
//        }


//        /// <summary>
//        /// Adds, updates, removes times within the specified timerange. Incremental updates can be applied by specifying "updatedSince" - in this case no deletions will be performed.
//        /// </summary>
//        /// <param name="clientId"></param>
//        /// <param name="from"></param>
//        /// <param name="to"></param>
//        /// <param name="updatedSince"></param>
//        /// <returns></returns>
//        [HttpGet]
//        [Route("time-transactions")]
//        public async Task<ActionResult> ImportTimeTransactionsAsync(int? clientId, DateTime? from, DateTime? to, DateTime? updatedSince)
//        {

//            await ImportSvc.ImportTimeTransactionsAsync(clientId, from.GetValueOrDefault(DataImportService.MIN_FROM_DATE), to.GetValueOrDefault(DateTime.Today.AddDays(1)), updatedSince);
//            return Ok();
//        }
//    }
//}