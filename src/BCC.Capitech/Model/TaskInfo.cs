using Capitech.Client.Catalogue;
using Omu.ValueInjecter;
using System;
using System.Collections.Generic;
using System.Text;

namespace BCC.Capitech.Model
{
    public class TaskInfo : Entity
    {
        public TaskInfo() { }
        public TaskInfo(TaskDto dto)
        {
            this.InjectFrom(dto);
            this.DateImported = DateTimeOffset.Now;
        }

        public int TaskId { get; set; }

        public int? DepartmentId { get; set; }

        public string TaskDescription { get; set; }

        /// <summary>
        /// 1 = Active, 0 = Disabled
        /// </summary>
        public int TaskStatus { get; set; }

        public int? CostCarrierId { get; set; }

        public override object[] GetPrimaryKey()
        {
            return new object[] { ClientId, TaskId };
        }
    }
}