using Capitech.Client.Catalogue;
using Omu.ValueInjecter;
using System;
using System.Collections.Generic;
using System.Text;

namespace BCC.Capitech.Model
{
    public class DutyDefinition : Entity
    {
        public DutyDefinition() { }
        public DutyDefinition(DutyDefinitionDto dto)
        {
            this.MapFromDto(dto);
            this.Start = dto.Start?.AsTimeSpan();
            this.End = dto.End?.AsTimeSpan();
            this.BreakStart = dto.BreakStart?.AsTimeSpan();
            this.BreakEnd = dto.BreakEnd?.AsTimeSpan();
            this.DateImported = DateTimeOffset.Now;
        }

        public int DutyDefinitionId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public TimeSpan? Start { get; set; }

        public TimeSpan? End { get; set; }

        public TimeSpan? BreakStart { get; set; }

        public TimeSpan? BreakEnd { get; set; }

        public decimal? Hours { get; set; }

        public int? SortNumber { get; set; }

        public int? DutyTypeId { get; set; }

        public int? CompetenceId { get; set; }

        public override object[] GetPrimaryKey()
        {
            return new object[] { ClientId, DutyDefinitionId };
        }
    }
}