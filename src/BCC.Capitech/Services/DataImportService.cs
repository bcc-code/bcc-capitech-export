using Capitech;
using BCC.Capitech.Extensions;
using BCC.Capitech.Model;
using BCC.Capitech.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BCC.Capitech.Services
{
    public class DataImportService : IDataImportService
    {
        public static DateTime MIN_FROM_DATE = new DateTime(2020, 1, 1);
        public DataImportService(CapitechClient api, ICapitechDataService data)
        {
            Api = api;
            Data = data;
        }

        public CapitechClient Api { get; }
        public ICapitechDataService Data { get; }

        public async Task<List<int>> GetClientIdsAsync()
        {
            return (await Data.GetRepository<Client>().GetAllAsync()).Select(c => c.ClientId).ToList();
        }

        public async Task ImportAllAsync(int? clientId, DateTime? from, DateTime? to)
        {
            if (clientId.HasValue)
            {
                await ImportAllAsync(clientId.Value, from.GetValueOrDefault(MIN_FROM_DATE), to.GetValueOrDefault(DateTime.Today.AddDays(1)));
            }
            else
            {
                foreach (var id in (await GetClientIdsAsync()))
                {
                    await ImportAllAsync(id, from.GetValueOrDefault(MIN_FROM_DATE), to.GetValueOrDefault(DateTime.Today.AddDays(1)));
                }
            }
        }

        public async Task ImportAllAsync(int clientId, DateTime from, DateTime to)
        {
            await ImportCatalogueAsync(clientId);
            await ImportEmployeesAsync(clientId);
            await ImportOperationalPlansAsync(clientId, from, to);
            await ImportAbsencesAsync(clientId, from, to);
            await ImportAbsenceTransactionsAsync(clientId, from, to);
            await ImportTimeTransactionsAsync(clientId, from, to, null);
        }

        public async Task ImportOperationalPlansAsync(int? clientId, DateTime from, DateTime to)
        {
            if (clientId.HasValue)
            {
                await ImportOperationalPlansAsync(clientId.Value, from, to);
            }
            else
            {
                foreach (var id in (await GetClientIdsAsync()))
                {
                    await ImportOperationalPlansAsync(id, from, to);
                }
            }
        }

        public async Task ImportOperationalPlansAsync(int clientId, DateTime from, DateTime to)
        {
            if (to > DateTime.Today.AddMonths(12))
            {
                to = DateTime.Today.AddMonths(12);
            }
            if (from < MIN_FROM_DATE)
            {
                from = MIN_FROM_DATE;
            }
            var updateWindowInMonths = 6; // Assume updates are never made to items more than 3 months old
            var minLocalFilterFrom = DateTime.Today.AddMonths(-updateWindowInMonths);
            var localFilterFrom = minLocalFilterFrom < from ? minLocalFilterFrom : from.AddMonths(-updateWindowInMonths);
            var localFilterTo = to.AddMonths(6); // Assume 

            var remoteItems = (await Api.OperationalPlan.GetOperationalPlanAsync(clientId, from.Date, to.Date)).Select(s => new OperationalPlan(s)).ToList();

            // Only remove items missing from within the date range
            await ImportItems(clientId, remoteItems,
                t => (t.Start.HasValue && t.Start.Value.Date >= from.Date && t.Start.Value.Date <= to.Date) || (t.NewStart.HasValue && t.NewStart.Value.Date >= from.Date && t.NewStart.Value.Date <= to.Date), // Only items within the date range should be deleted if missing
                t => t.Start.HasValue && t.Start >= localFilterFrom && t.Start <= localFilterTo // Limit number of local items to retreive to reasonable limits
            );
        }

        public async Task ImportAbsenceTransactionsAsync(int? clientId, DateTime from, DateTime to)
        {
            if (clientId.HasValue)
            {
                await ImportAbsenceTransactionsAsync(clientId.Value, from, to);
            }
            else
            {
                foreach (var id in (await GetClientIdsAsync()))
                {
                    await ImportAbsenceTransactionsAsync(id, from, to);
                }
            }
        }

        public async Task ImportAbsenceTransactionsAsync(int clientId, DateTime from, DateTime to)
        {
            if (to > DateTime.Today.AddDays(1))
            {
                to = DateTime.Today.AddDays(1);
            }
            if (from < MIN_FROM_DATE)
            {
                from = MIN_FROM_DATE;
            }
            var updateWindowInMonths = 6; // Assume updates are never made to items more than 3 months old
            var minLocalFilterFrom = DateTime.Today.AddMonths(-updateWindowInMonths);
            var localFilterFrom = minLocalFilterFrom < from ? minLocalFilterFrom : from.AddMonths(-updateWindowInMonths);
            var localFilterTo = DateTime.Today.AddDays(1); // Assume 

            var remoteItems = (await Api.Absence.GetAbsenceTransactionsAsync(clientId, from.Date, to.Date)).Select(s => new AbsenceTransaction(s)).ToList();

            // Only remove items missing from within the date range
            await ImportItems(clientId, remoteItems,
                t => (t.FromDate.HasValue && t.FromDate.Value.Date >= from.Date && t.FromDate.Value.Date <= to.Date) || (t.EndDate.HasValue && t.EndDate.Value.Date >= from.Date && t.EndDate.Value.Date <= to.Date), // Only items within the date range should be deleted if missing
                t => (t.FromDate.HasValue && t.FromDate >= localFilterFrom && t.FromDate <= localFilterTo) || (t.EndDate.HasValue && t.EndDate >= localFilterFrom && t.EndDate <= localFilterTo) // Limit number of local items to retreive to reasonable limits
            );
        }

        public async Task ImportAbsencesAsync(int? clientId, DateTime from, DateTime to)
        {
            if (clientId.HasValue)
            {
                await ImportAbsencesAsync(clientId.Value, from, to);
            }
            else
            {
                foreach (var id in (await GetClientIdsAsync()))
                {
                    await ImportAbsencesAsync(id, from, to);
                }
            }
        }

        public async Task ImportAbsencesAsync(int clientId, DateTime from, DateTime to)
        {
            if (to > DateTime.Today.AddDays(1))
            {
                to = DateTime.Today.AddDays(1);
            }
            if (from < MIN_FROM_DATE)
            {
                from = MIN_FROM_DATE;
            }
            var updateWindowInMonths = 6; // Assume updates are never made to items more than 3 months old
            var minLocalFilterFrom = DateTime.Today.AddMonths(-updateWindowInMonths);
            var localFilterFrom = minLocalFilterFrom < from ? minLocalFilterFrom : from.AddMonths(-updateWindowInMonths);
            var localFilterTo = DateTime.Today.AddDays(1); // Assume 

            var remoteItems = (await Api.Absence.GetAbsencesAsync(clientId, from.Date, to.Date)).Select(s => new Absence(s)).ToList();

            // Only remove items missing from within the date range
            await ImportItems(clientId, remoteItems,
                t => (t.FromDate.HasValue && t.FromDate.Value.Date >= from.Date && t.FromDate.Value.Date <= to.Date) || (t.EndDate.HasValue && t.EndDate.Value.Date >= from.Date && t.EndDate.Value.Date <= to.Date), // Only items within the date range should be deleted if missing
                t => (t.FromDate.HasValue && t.FromDate >= localFilterFrom && t.FromDate <= localFilterTo) || (t.EndDate.HasValue && t.EndDate >= localFilterFrom && t.EndDate <= localFilterTo) // Limit number of local items to retreive to reasonable limits
            );
        }

        public async Task ImportTimeTransactionsAsync(int? clientId, DateTime from, DateTime to, DateTime? updatedSince)
        {
            if (clientId.HasValue)
            {
                await ImportTimeTransactionsAsync(clientId.Value, from, to, updatedSince);
            }
            else
            {
                foreach (var id in (await GetClientIdsAsync()))
                {
                    await ImportTimeTransactionsAsync(id, from, to, updatedSince);
                }
            }
        }

        public async Task ImportTimeTransactionsAsync(int clientId, DateTime from, DateTime to, DateTime? updatedSince)
        {
            if (to > DateTime.Today.AddDays(1))
            {
                to = DateTime.Today.AddDays(1);
            }
            if (from < MIN_FROM_DATE)
            {
                from = MIN_FROM_DATE;
            }
            var updateWindowInMonths = 3; // Assume updates are never made to items more than 3 months old
            var minLocalFilterFrom = DateTime.Today.AddMonths(-updateWindowInMonths);
            var localFilterFrom = minLocalFilterFrom < from ? minLocalFilterFrom : from.AddMonths(-updateWindowInMonths);
            var localFilterTo = DateTime.Today.AddDays(1); // Assume 

            // Incremental updates
            if (updatedSince != null)
            {

                var remoteItems = (await Api.Time.GetTimeTransactionsUpdatedSinceAsync(clientId, from.Date, to.Date, updatedSince.Value)).Select(s => new TimeTransaction(s)).ToList();

                await ImportItems(clientId, remoteItems,
                    t => false, // Incremental updates should never delete records
                    t => t.DateIn.HasValue && t.DateIn >= localFilterFrom && t.DateIn <= localFilterTo // Limit number of local items to retreive to reasonable limits
                );
            }
            // Full update for date range
            else
            {
                var remoteItems = (await Api.Time.GetTimeTransactionsAsync(clientId, from.Date, to.Date)).Select(s => new TimeTransaction(s)).ToList();

                // Only remove items missing from within the date range
                await ImportItems(clientId, remoteItems,
                    t => t.DateIn.HasValue && t.DateIn.Value.Date >= from.Date && t.DateIn.Value.Date <= to.Date, // Only items within the date range should be deleted if missing
                    t => t.DateIn.HasValue && t.DateIn >= localFilterFrom && t.DateIn <= localFilterTo // Limit number of local items to retreive to reasonable limits
                );
            }
        }

        public async Task ImportEmployeesAsync(int? clientId)
        {
            if (clientId.HasValue)
            {
                await ImportEmployeesAsync(clientId.Value);
            }
            else
            {
                foreach (var id in (await GetClientIdsAsync()))
                {
                    await ImportEmployeesAsync(id);
                }
            }
        }

        public async Task ImportEmployeesAsync(int clientId)
        {
            var remoteItems = (await Api.Employee.GetPersonalInformationAsync(clientId)).Select(s => new Employee(s)).ToList();
            await ImportItems(clientId, remoteItems);
        }

        public async Task ImportCatalogueAsync(int? clientId)
        {
            if (clientId.HasValue)
            {
                await ImportCatalogueAsync(clientId.Value);
            }
            else
            {
                foreach (var id in (await GetClientIdsAsync()))
                {
                    await ImportCatalogueAsync(id);
                }
            }
        }

        public async Task ImportCatalogueAsync(int clientId)
        {

            await ImportCompetencesAsync(clientId);
            await ImportDepartmentsAsync(clientId);
            await ImportDutyTypesAsync(clientId);
            await ImportTasksAsync(clientId);
            await ImportDutyDefinitionsAsync(clientId);
            await ImportFreeDimension1sAsync(clientId);
            await ImportFreeDimension2sAsync(clientId);
            await ImportOrdersAsync(clientId);
            await ImportProjectsAsync(clientId);
        }

        public async Task ImportCompetencesAsync(int clientId)
        {
            var remoteItems = (await Api.Catalogue.GetCompetencesAsync(clientId)).Select(s => new Competence(s)).ToList();
            await ImportItems(clientId, remoteItems);
        }

        public async Task ImportDepartmentsAsync(int clientId)
        {
            var remoteItems = (await Api.Catalogue.GetDepartmentsAsync(clientId)).Select(s => new Department(s)).ToList();
            await ImportItems(clientId, remoteItems);
        }

        public async Task ImportDutyDefinitionsAsync(int clientId)
        {
            var remoteItems = (await Api.Catalogue.GetDutyDefinitionsAsync(clientId)).Select(s => new DutyDefinition(s)).ToList();
            await ImportItems(clientId, remoteItems);
        }

        public async Task ImportDutyTypesAsync(int clientId)
        {
            var remoteItems = (await Api.Catalogue.GetDutyTypesAsync(clientId)).Select(s => new DutyType(s)).ToList();
            await ImportItems(clientId, remoteItems);
        }

        public async Task ImportFreeDimension1sAsync(int clientId)
        {
            var remoteItems = (await Api.Catalogue.GetFreeDimension1sAsync(clientId)).Select(s => new FreeDimension1(s)).ToList();
            await ImportItems(clientId, remoteItems);
        }

        public async Task ImportFreeDimension2sAsync(int clientId)
        {
            var remoteItems = (await Api.Catalogue.GetFreeDimension2sAsync(clientId)).Select(s => new FreeDimension2(s)).ToList();
            await ImportItems(clientId, remoteItems);
        }

        public async Task ImportOrdersAsync(int clientId)
        {
            var remoteItems = (await Api.Catalogue.GetOrdersAsync(clientId)).Select(s => new Order(s)).ToList();
            await ImportItems(clientId, remoteItems);
        }

        public async Task ImportTasksAsync(int clientId)
        {
            var departments = await Api.Catalogue.GetDepartmentsAsync(clientId);
            var tasks = new List<TaskInfo>();
            foreach (var department in departments)
            {
                var tasksForDepartment = (await Api.Catalogue.GetTasksAsync(clientId, department.DepartmentId)).Select(t => new TaskInfo(t)).ToList();
                if (tasksForDepartment.Count > 0)
                {
                    tasks.AddRange(tasksForDepartment);
                }
            }

            await ImportItems(clientId, tasks);
        }

        public async Task ImportProjectsAsync(int clientId)
        {
            var projects = (await Api.Catalogue.GetProjectsAsync(clientId)).Select(p => new Project(p)).ToList();
            var subProjects = new List<SubProject>();
            var phases = new List<Phase>();
            foreach (var project in projects)
            {
                var subProjectsForProject = (await Api.Catalogue.GetSubProjectsAsync(clientId, project.ProjectId)).Select(p => new SubProject(p)).ToList();
                if (subProjectsForProject.Count > 0)
                {
                    subProjects.AddRange(subProjectsForProject);
                    foreach (var subProject in subProjectsForProject)
                    {
                        var phasesForSubProject = (await Api.Catalogue.GetPhasesAsync(clientId, project.ProjectId, subProject.SubProjectId)).Select(p => new Phase(p)).ToList();
                        if (phases.Count > 0)
                        {
                            phases.AddRange(phasesForSubProject);
                        }
                    }
                }
            }

            await ImportItems(clientId, projects);
            await ImportItems(clientId, subProjects);
            await ImportItems(clientId, phases);
        }

        protected async Task ImportItems<T>(int clientId, List<T> remoteItems, Func<T, bool> removeFilter = null, Expression<Func<T, bool>> localFilter = null) where T : Entity
        {
            var repository = Data.GetRepository<T>();
            var localItems = localFilter == null ? await repository.GetAllAsync(clientId) : await repository.QueryAsync(clientId, localFilter);
            var remoteItemLookup = GetLookup(remoteItems);
            var localItemLookup = GetLookup(localItems);

            var removedItems = localItemLookup.Keys.Where(k => !remoteItemLookup.ContainsKey(k)).Select(k => localItemLookup[k]).Where(r => removeFilter == null || removeFilter(r)).ToList();
            var newItems = new List<T>();
            var updatedItems = new List<T>();
            foreach (var remoteItem in remoteItems)
            {
                var remoteItemKey = KeyToString(remoteItem.GetPrimaryKey());
                if (!localItemLookup.ContainsKey(remoteItemKey))
                {
                    newItems.Add(remoteItem);
                }
                else
                {
                    var localItem = localItemLookup[remoteItemKey];
                    if (!PropertiesAreEqual(localItem, remoteItem))
                    {
                        updatedItems.Add(remoteItem);
                    }
                }
            }
            if (updatedItems.Count > 0)
            {
                await repository.UpdateAsync(updatedItems);
            }
            if (newItems.Count > 0)
            {
                await repository.AddAsync(newItems);
            }
            if (removedItems.Count > 0)
            {
                await repository.RemoveAsync(removedItems);
            }
        }

        private HashSet<string> _ignoreProperties;
        protected bool PropertiesAreEqual<T>(T item1, T item2) where T : Entity
        {
            _ignoreProperties = _ignoreProperties ?? new HashSet<string>(new[] { "DateImported" });
            return item1.EqualsByInterface(item2, _ignoreProperties);
        }

        protected bool KeysAreSame<T>(T item1, T item2) where T : Entity
        {
            if (item1 == null || item2 == null) return false;
            var key1 = item1.GetPrimaryKey();
            var key2 = item2.GetPrimaryKey();
            for (var i = 0; i < key1.Length; i++)
            {
                if (!(key1[i]?.Equals(key2[i])).GetValueOrDefault(false))
                {
                    return false;
                }
            }
            return true;
        }

        protected Dictionary<string, T> GetLookup<T>(IList<T> items) where T : Entity
        {
            var result = new Dictionary<string, T>();
            foreach (var item in items)
            {
                var key = KeyToString(item.GetPrimaryKey());
                if (!result.ContainsKey(key))
                {
                    result[key] = item;
                }
            }
            return result;
        }

        protected string KeyToString(object[] key)
        {
            return key.Select(s => s?.ToString() ?? "").Aggregate((c, n) => $"{c}_{n}");
        }
    }
}