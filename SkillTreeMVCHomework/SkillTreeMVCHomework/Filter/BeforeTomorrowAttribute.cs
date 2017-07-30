using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SkillTreeMVCHomework.Filter
{
    public sealed class BeforeTomorrowAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value != null && value is DateTime)
            {
                return (DateTime)value <= DateTime.Now.Date;
            }
            return false;
        }
    }
}