using System;
using System.Collections.Generic;
using System.Text;

namespace BCC.Capitech.Model
{
    public class Client : Entity
    {

        public string Name { get; set; }

        public override object[] GetPrimaryKey()
        {
            return new object[] { ClientId };
        }
    }
}