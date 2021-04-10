using Omu.ValueInjecter;
using System;
using System.Collections.Generic;
using System.Text;

namespace BCC.Capitech
{
    public static class DtoMappingExtensions
    {
        public static T MapFromDto<T>(this T obj, object dto)
        {
            obj.InjectFrom<DtoMapper>(dto); 
            return obj;
        }
    }
}
