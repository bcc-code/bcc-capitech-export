using Capitech.Client.Catalogue;
using Omu.ValueInjecter;
using System;
using System.Collections.Generic;
using System.Text;

namespace BCC.Capitech.Model
{
    public class FreeDimension1 : Entity
    {
        public FreeDimension1() { }
        public FreeDimension1(FreeDimension1Dto dto)
        {
            this.MapFromDto(dto);
            this.DateImported = DateTimeOffset.Now;
        }

        public int FreeDimension1Id { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public int UniqueId { get; set; }

        public override object[] GetPrimaryKey()
        {
            return new object[] { ClientId, FreeDimension1Id, UniqueId };
        }
    }
}