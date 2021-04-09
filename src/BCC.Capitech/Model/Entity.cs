using System;
using System.Collections.Generic;
using System.Text;

namespace BCC.Capitech.Model
{
    public abstract class Entity
    {
        public int ClientId { get; set; }

        public abstract object[] GetPrimaryKey();

        public DateTimeOffset DateImported { get; set; }
    }
}