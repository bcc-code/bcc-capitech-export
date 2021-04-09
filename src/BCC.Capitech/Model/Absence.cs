using Capitech.Client.Absence;
using Omu.ValueInjecter;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BCC.Capitech.Model
{
    public class Absence : Entity
    {
        public Absence()
        {
        }

        public Absence(AbsenceDto dto)
        {
            this.InjectFrom(dto);
            DateImported = DateTimeOffset.Now;
        }

        public int AbsenceId { get; set; }

        public int EmployeeId { get; set; }

        public string Employee { get; set; }

        public string AbsenceCode { get; set; }

        public string AbsenceDescription { get; set; }

        public int AbsenceType { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? EndDate { get; set; }

        public TimeSpan? StartTime { get; set; }

        public TimeSpan? EndTime { get; set; }

        public decimal? Hours { get; set; }

        public decimal? AbsencePercent { get; set; }

        public int? DepartmentId { get; set; }

        public string Department { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CreatedBy { get; set; }

        public DateTime UpdatedOn { get; set; }

        public string UpdatedBy { get; set; }

        public override object[] GetPrimaryKey()
        {
            return new object[] { ClientId, AbsenceId };
        }
    }
}