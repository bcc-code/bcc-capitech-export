using Capitech.Client.Catalogue;
using Omu.ValueInjecter;
using System;
using System.Collections.Generic;
using System.Text;

namespace BCC.Capitech.Model
{
    public class Competence : Entity
    {
        public Competence()
        {
        }
        public Competence(CompetenceDto dto)
        {
            this.InjectFrom(dto);
            DateImported = DateTimeOffset.Now;
        }

        public int CompetenceId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public int? SortNumber { get; set; }

        public override object[] GetPrimaryKey()
        {
            return new object[] { ClientId, CompetenceId };
        }
    }
}