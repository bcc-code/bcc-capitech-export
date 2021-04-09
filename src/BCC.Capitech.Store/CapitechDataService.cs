using BCC.Capitech.Model;
using BCC.Capitech.Repositories;
using BCC.Capitech.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace BCC.Capitech.Store
{
    public class CapitechDataService : ICapitechDataService
    {
        public CapitechDataService(CapitechDataContext db)
        {
            Db = db;
        }

        protected CapitechDataContext Db { get; }

        public ICapitechDataRepository<T> GetRepository<T>() where T : Entity
        {
            return new CapitechDataRepository<T>(Db);
        }
    }
}