using Omu.ValueInjecter.Injections;
using System;
using System.Reflection;

namespace BCC.Capitech
{
    public class DtoMapper : LoopInjection
    {
        protected override bool MatchTypes(Type source, Type target)
        {
            if ((source == typeof(DateTimeOffset) || source == typeof(DateTimeOffset?)) && 
                (target == typeof(DateTime) || target == typeof(DateTime?))
               )
            {
                return true;
            }

            return base.MatchTypes(source, target);
        }

        protected override void SetValue(object source, object target, PropertyInfo sp, PropertyInfo tp)
        {
            if ((sp.PropertyType == typeof(DateTimeOffset) || sp.PropertyType == typeof(DateTimeOffset?)) &&
                (tp.PropertyType == typeof(DateTime) || tp.PropertyType == typeof(DateTime?))
               )
            {
                if (source == null)
                {
                    if (tp.PropertyType == typeof(DateTime?))
                    {
                        tp.SetValue(target, null);
                    }
                    else
                    {
                        tp.SetValue(target, default(DateTime));
                    }
                }
                else
                {
                    tp.SetValue(target, ((DateTimeOffset)source).DateTime);
                }
            }

            base.SetValue(source, target, sp, tp);
        }
    }
}
