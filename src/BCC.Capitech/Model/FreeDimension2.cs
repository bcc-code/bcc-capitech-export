using Capitech.Client.Catalogue;
using Omu.ValueInjecter;
using System;
using System.Collections.Generic;
using System.Text;

namespace BCC.Capitech.Model
{
    public class FreeDimension2 : Entity
    {
        public FreeDimension2() { }
        public FreeDimension2(FreeDimension2Dto dto)
        {
            this.MapFromDto(dto);
            this.DateImported = DateTimeOffset.Now;
        }
        public int FreeDimension2Id { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public int UniqueId { get; set; }

        public override object[] GetPrimaryKey()
        {
            return new object[] { ClientId, FreeDimension2Id, UniqueId };
        }
    }
}