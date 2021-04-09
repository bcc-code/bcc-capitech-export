using BCC.Capitech.Model;
using BCC.Capitech.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BCC.Capitech.Services
{
    public interface ICapitechDataService
    {
        ICapitechDataRepository<T> GetRepository<T>() where T : Entity;
    }
}