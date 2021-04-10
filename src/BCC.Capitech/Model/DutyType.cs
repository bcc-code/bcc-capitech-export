using Capitech.Client.Catalogue;
using Omu.ValueInjecter;
using System;
using System.Collections.Generic;
using System.Text;

namespace BCC.Capitech.Model
{
    public class DutyType : Entity
    {
        public DutyType() { }

        public DutyType(DutyTypeDto dto)
        {
            this.MapFromDto(dto);
            this.DateImported = DateTimeOffset.Now;
        }

        public int DutyTypeId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public int? SortNumber { get; set; }

        public override object[] GetPrimaryKey()
        {
            return new object[] { ClientId, DutyTypeId };
        }
    }
}