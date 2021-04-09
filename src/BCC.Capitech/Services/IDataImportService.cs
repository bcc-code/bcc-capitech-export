using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Capitech;

namespace BCC.Capitech.Services
{
    public interface IDataImportService
    {
        CapitechClient Api { get; }
        ICapitechDataService Data { get; }

        Task<List<int>> GetClientIdsAsync();
        Task ImportAbsencesAsync(int clientId, DateTime from, DateTime to);
        Task ImportAbsencesAsync(int? clientId, DateTime from, DateTime to);
        Task ImportAllAsync(int clientId, DateTime from, DateTime to);
        Task ImportAllAsync(int? clientId, DateTime? from, DateTime? to);
        Task ImportCatalogueAsync(int clientId);
        Task ImportCatalogueAsync(int? clientId);
        Task ImportCompetencesAsync(int clientId);
        Task ImportDepartmentsAsync(int clientId);
        Task ImportDutyDefinitionsAsync(int clientId);
        Task ImportDutyTypesAsync(int clientId);
        Task ImportEmployeesAsync(int clientId);
        Task ImportEmployeesAsync(int? clientId);
        Task ImportFreeDimension1sAsync(int clientId);
        Task ImportFreeDimension2sAsync(int clientId);
        Task ImportOperationalPlansAsync(int clientId, DateTime from, DateTime to);
        Task ImportOperationalPlansAsync(int? clientId, DateTime from, DateTime to);
        Task ImportOrdersAsync(int clientId);
        Task ImportProjectsAsync(int clientId);
        Task ImportTasksAsync(int clientId);
        Task ImportTimeTransactionsAsync(int clientId, DateTime from, DateTime to, DateTime? updatedSince);
        Task ImportTimeTransactionsAsync(int? clientId, DateTime from, DateTime to, DateTime? updatedSince);
    }
}