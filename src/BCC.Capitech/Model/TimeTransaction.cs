using Capitech.Client.Time;
using Omu.ValueInjecter;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace BCC.Capitech.Model
{
    public class TimeTransaction : Entity
    {
        private static CultureInfo NbNoCulture = new CultureInfo("nb-NO");
        public TimeTransaction() { }
        public TimeTransaction(TimeTransactionDto dto)
        {
            this.InjectFrom(dto);
            if (!string.IsNullOrEmpty(dto.ApprovedLevelOneOn) && DateTime.TryParseExact(dto.ApprovedLevelOneOn, "dd.MM.yyyy HH.mm.ss", NbNoCulture, DateTimeStyles.AssumeLocal, out DateTime date1))
            {
                this.ApprovedLevelOneOn = date1;
            }
            if (!string.IsNullOrEmpty(dto.ApprovedLevelTwoOn) && DateTime.TryParseExact(dto.ApprovedLevelTwoOn, "dd.MM.yyyy HH.mm.ss", NbNoCulture, DateTimeStyles.AssumeLocal, out DateTime date2))
            {
                this.ApprovedLevelTwoOn = date2;
            }
            if (!string.IsNullOrEmpty(dto.ApprovedLevelThreeOn) && DateTime.TryParseExact(dto.ApprovedLevelThreeOn, "dd.MM.yyyy HH.mm.ss", NbNoCulture, DateTimeStyles.AssumeLocal, out DateTime date3))
            {
                this.ApprovedLevelThreeOn = date3;
            }
            if (!string.IsNullOrEmpty(dto.ApprovedLevelFourOn) && DateTime.TryParseExact(dto.ApprovedLevelFourOn, "dd.MM.yyyy HH.mm.ss", NbNoCulture, DateTimeStyles.AssumeLocal, out DateTime date4))
            {
                this.ApprovedLevelFourOn = date4;
            }
            this.TimeCategoryId = dto.TimeCategoryId.GetValueOrDefault();
            DateImported = DateTimeOffset.Now;
        }

        public int Uid { get; set; }


        public int EmployeeId { get; set; }

        public string Employee { get; set; }

        public DateTime? DateIn { get; set; }

        public TimeSpan? TimeIn { get; set; }

        public DateTime? DateOut { get; set; }

        public TimeSpan? TimeOut { get; set; }

        public int? DepartmentId { get; set; }

        public string Department { get; set; }

        public int? TaskId { get; set; }

        public string Task { get; set; }

        public int? ClassicDutyId { get; set; }

        public string ClassicDutyCode { get; set; }

        public string ClassicDuty { get; set; }

        public int? OrderId { get; set; }

        public string Order { get; set; }

        public int? ProjectId { get; set; }

        public string Project { get; set; }

        public int? SubProjectId { get; set; }

        public string SubProject { get; set; }

        public int? ProjectPhaseId { get; set; }

        public string ProjectPhase { get; set; }

        public int? ShiftId { get; set; }

        public string Shift { get; set; }

        public int? FreeDimension1Id { get; set; }

        public string FreeDimension1 { get; set; }

        public int? FreeDimension2Id { get; set; }

        public string FreeDimension2 { get; set; }

        public string FreeText { get; set; }

        public int? ApprovedLevelOne { get; set; }

        public int? ApprovedLevelTwo { get; set; }

        public int? ApprovedLevelThree { get; set; }

        public int? ApprovedLevelFour { get; set; }

        public string ApprovedLevelOneBy { get; set; }

        public string ApprovedLevelTwoBy { get; set; }

        public string ApprovedLevelThreeBy { get; set; }

        public string ApprovedLevelFourBy { get; set; }

        public DateTime? ApprovedLevelOneOn { get; set; }

        public DateTime? ApprovedLevelTwoOn { get; set; }

        public DateTime? ApprovedLevelThreeOn { get; set; }

        public DateTime? ApprovedLevelFourOn { get; set; }

        public int TimeCategoryId { get; set; }

        public string TimeCategory { get; set; }

        public string TimeCategoryTypeId { get; set; }

        public string TimeCategoryType { get; set; }

        public bool? TimeCategoryPayable { get; set; }

        public decimal? Qty { get; set; }

        public int? ExternalStatusCode { get; set; }

        public DateTimeOffset? LastUpdatedOn { get; set; }

        public string RecordStateKey { get; set; }

        public override object[] GetPrimaryKey()
        {
            return new object[] { ClientId, Uid, TimeCategoryId };
        }

    }
}