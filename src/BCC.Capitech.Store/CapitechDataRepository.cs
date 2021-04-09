using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using BCC.Capitech.Model;
using BCC.Capitech.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BCC.Capitech.Store
{
    public class CapitechDataRepository<T> : ICapitechDataRepository<T> where T : Entity
    {
        public CapitechDataRepository(CapitechDataContext db)
        {
            Db = db;
        }

        public CapitechDataContext Db { get; }

        public async Task<List<T>> AddAsync(IList<T> items)
        {
            var importDate = DateTimeOffset.Now;
            foreach (var item in items)
            {
                item.DateImported = importDate;
            }
            await Db.BulkInsertAsync<T>(items);
            return items?.ToList();
        }

        public Task<List<T>> GetAllAsync()
        {
            return Db.Set<T>().ToListAsync();
        }

        public Task<List<T>> GetAllAsync(int clientId)
        {
            return Db.Set<T>().Where(o => o.ClientId == clientId).ToListAsync();
        }

        public Task<List<T>> QueryAsync(int clientId, Expression<Func<T, bool>> query)
        {
            return Db.Set<T>().Where(o => o.ClientId == clientId).Where(query).ToListAsync();
        }

        public async Task<List<T>> RemoveAsync(IList<T> items)
        {
            //var itemsToRemove = new List<T>();
            //foreach (var item in items)
            //{
            //    var itemToRemove = await Db.Set<T>().FindAsync(item.GetPrimaryKey());
            //    if (itemToRemove != null)
            //    {
            //        itemsToRemove.Add(itemToRemove);
            //    }
            //}
            if (items.Count > 0)
            {
                await Db.BulkDeleteAsync(items);
                //Db.Set<T>().RemoveRange(itemsToRemove);
                //await Db.SaveChangesAsync();
            }
            return items?.ToList();
        }

        public async Task<List<T>> UpdateAsync(IList<T> items)
        {
            var importDate = DateTimeOffset.Now;
            // var itemsToUpdate = new List<T>();
            foreach (var item in items)
            {
                item.DateImported = importDate;
                //var itemToUpdate = await Db.Set<T>().FindAsync(item.GetPrimaryKey());
                //if (itemToUpdate != null)
                //{
                //    var entity = Db.Entry(itemToUpdate);
                //    entity.CurrentValues.SetValues(item);
                //    entity.State = EntityState.Modified;

                //    itemsToUpdate.Add(itemToUpdate);
                //}
            }
            if (items.Count > 0)
            {
                await Db.BulkUpdateAsync<T>(items);
            }
            return items?.ToList();
        }
    }
}