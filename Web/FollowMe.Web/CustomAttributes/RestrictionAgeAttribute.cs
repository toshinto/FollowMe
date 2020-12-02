using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FollowMe.Web.CustomAttributes
{
    public class RestrictionAgeAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is DateTime dtvalue)
            {
                if (dtvalue.Year > DateTime.UtcNow.Year || dtvalue.Month > DateTime.UtcNow.Month || dtvalue.Day > DateTime.UtcNow.Day)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
