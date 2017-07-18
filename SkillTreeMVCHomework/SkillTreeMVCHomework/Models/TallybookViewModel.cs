using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SkillTreeMVCHomework.Models
{
    public class TallybookViewModel
    {
        public TallybookViewModel()
        {
            CategorySelectList = new List<SelectListItem>
                {
                    new SelectListItem() {Text="支出",Value="支出" } ,
                    new SelectListItem() {Text="收入",Value="收入" }
                };
        }
        public Spending newSpending { get; set; }

        public IList<Spending> spendingList { get; set; }

        public List<SelectListItem> CategorySelectList { get; set; }
    }
}