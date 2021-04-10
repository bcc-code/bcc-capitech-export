using Capitech.Client.Absence;
using Omu.ValueInjecter;
using System;
using System.Collections.Generic;
using System.Text;

namespace BCC.Capitech.Model
{
    public class AbsenceTransaction : Entity
    {
        public AbsenceTransaction()
        {
        }

        public AbsenceTransaction(AbsenceTransactionDto dto)
        {
            this.MapFromDto(dto);
            this.DayAbsencePercent = dto.DayAbsencePersent;
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

        public DateTime DayDate { get; set; }

        public TimeSpan? DayStartTime { get; set; }

        public TimeSpan? DayEndTime { get; set; }

        public int? DayTaskId { get; set; }

        public string DayTask { get; set; }

        public int? DayOrderId { get; set; }

        public string DayOrder { get; set; }

        public int? DayProjectNr { get; set; }

        public string DayProject { get; set; }

        public int? DaySubProjectId { get; set; }

        public string DaySubProject { get; set; }

        public int? DayPhaseId { get; set; }

        public string DayPhase { get; set; }

        public int? DayShiftId { get; set; }

        public int? DayFreeDimension1Id { get; set; }

        public string DayFreeDimension1 { get; set; }

        public int? DayFreeDimension2Id { get; set; }

        public string DayFreeDimension2 { get; set; }

        public int? DayClassicDutyId { get; set; }

        public int? DayAbsencePercent { get; set; }

        public bool? DaySelfDeclaration { get; set; }

        public int? DayTransactionStatus { get; set; }

        public int? DayTimeCategoryId { get; set; }

        public string DayTimeCategory { get; set; }

        public decimal? DayCalculatedHours { get; set; }

        public decimal? DayPaidHours { get; set; }

        public override object[] GetPrimaryKey()
        {
            return new object[] { ClientId, AbsenceId, DayDate };
        }
    }
}