using Capitech.Client.Catalogue;
using Omu.ValueInjecter;
using System;
using System.Collections.Generic;
using System.Text;

namespace BCC.Capitech.Model
{
    public class Order : Entity
    {
        public Order(){}
        public Order(OrderDto dto)
        {
            this.InjectFrom(dto);
            this.DateImported = DateTimeOffset.Now;
        }

        public int OrderId { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public override object[] GetPrimaryKey()
        {
            return new object[] { ClientId, OrderId };
        }
    }
}