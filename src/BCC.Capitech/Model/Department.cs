using Capitech.Client.Catalogue;
using Omu.ValueInjecter;
using System;
using System.Collections.Generic;
using System.Text;

namespace BCC.Capitech.Model
{
    public class Department : Entity
    {
        public Department()
        {
        }

        public Department(DepartmentDto dto)
        {
            this.InjectFrom(dto);
            DateImported = DateTimeOffset.Now;
        }

        public int DepartmentId { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public override object[] GetPrimaryKey()
        {
            return new object[] { ClientId, DepartmentId };
        }
    }
}