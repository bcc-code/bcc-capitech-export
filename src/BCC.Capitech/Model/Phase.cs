using Capitech.Client.Catalogue;
using Omu.ValueInjecter;
using System;
using System.Collections.Generic;
using System.Text;

namespace BCC.Capitech.Model
{
    public class Phase : Entity
    {
        public Phase() { }
        public Phase(PhaseDto dto)
        {
            this.InjectFrom(dto);
            this.DateImported = DateTimeOffset.Now;
        }

        public int PhaseId { get; set; }

        public int ProjectId { get; set; }

        public int SubProjectId { get; set; }

        public string Description { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? PlannedFinishDate { get; set; }

        public DateTime? FinishDate { get; set; }


        /// <summary>
        /// AK (active), PA (passive), AV (closed), IP (not started)
        /// </summary>
        public string Status { get; set; }

        public decimal? HourlyRate { get; set; }

        public decimal? PercentagePart { get; set; }

        public int UniqueId { get; set; }

        public string AlphanumericCode { get; set; }

        public string Description2 { get; set; }

        public override object[] GetPrimaryKey()
        {
            return new object[] { ClientId, ProjectId, UniqueId };
        }
    }
}