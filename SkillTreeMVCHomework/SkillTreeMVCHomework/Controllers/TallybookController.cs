using SkillTreeMVCHomework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SkillTreeMVCHomework.Controllers
{
    public class TallybookController : Controller
    {
        // GET: Tallybook
        public ActionResult Index()
        {
            Random rNumber = new Random();
            var model = new TallybookViewModel();
            model.spendingList = new List<Spending>();
            for (int i = 0; i < 10; i++)
            {
                model.spendingList.Add(new Spending
                {
                    Category = rNumber.Next(0, 2) == 0 ? "收入" : "支出",
                    Date = DateTime.Now.Date.AddDays(rNumber.Next(-7, -1)),
                    Money = rNumber.Next(50, 300)*100
                });
            }
            model.spendingList = model.spendingList.OrderBy(x => x.Date).ToList();
            
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(TallybookViewModel pageData)
        {
            //新增資料

            return RedirectToAction("Index");
        }
    }
}