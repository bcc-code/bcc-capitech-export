using Capitech.Client.Employee;
using Omu.ValueInjecter;
using System;
using System.Collections.Generic;
using System.Text;

namespace BCC.Capitech.Model
{
    public class Employee : Entity
    {
        public Employee() { }
        public Employee(PersonalInformationDto dto)
        {
            this.MapFromDto(dto);
            DateImported = DateTimeOffset.Now;

        }

        public int EmployeeId { get; set; }

        public int? DepartmentId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        //public string Address1 { get; set; }

        //public string Address2 { get; set; }

        //public string CountryCode { get; set; }

        //public string ZipCode { get; set; }

        //public string PhoneNumber { get; set; }

        //public string CellPhoneNumber { get; set; }

        //public string EmailAddress { get; set; }

        //public bool IsTimeActive { get; set; }

        //public bool IsAbsenceActive { get; set; }

        //public bool IsPlanActive { get; set; }

        //public string PhoneNumber2 { get; set; }

        /// <summary>
        /// M = Male, K = Female
        /// </summary>
        public string Gender { get; set; }

        ///// <summary>
        ///// ddmmyy
        ///// </summary>
        //public string BirthDate { get; set; }

        public DateTime? EmployeeStartDate { get; set; }

        public DateTime? EmployeeEndDate { get; set; }

        public DateTime? EmployeeSeniorityDate { get; set; }

        public string ExternalId { get; set; }

        public int? WageGroupId { get; set; }

        public int? TaskId { get; set; }

        public int? ProjectId { get; set; }

        public int? SubProjectId { get; set; }

        public int? PhaseId { get; set; }

        public int? OrderId { get; set; }

        public int? FreeDimension1Id { get; set; }

        public int? FreeDimension2Id { get; set; }

        public decimal? CostCarrierId { get; set; }

        /// <summary>
        /// A = Arbeider, F = Funksjonær, null
        /// </summary>
        public string StatisticsGroupCode { get; set; }

        //public int? RegistrationAccess { get; set; }

        //public int? CardNumber { get; set; }

        //public string RFID { get; set; }

        //public string HMSCardId { get; set; }

        //public string AuthenticationId { get; set; }

        public override object[] GetPrimaryKey()
        {
            return new object[] { ClientId, EmployeeId };
        }
    }
}