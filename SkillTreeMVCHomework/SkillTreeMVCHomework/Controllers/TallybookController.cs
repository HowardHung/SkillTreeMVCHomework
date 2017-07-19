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
        private void PageOption()
        {
            ViewData["CategorySelectList"] = new List<SelectListItem>
                {
                    new SelectListItem() {Text="支出",Value="支出" } ,
                    new SelectListItem() {Text="收入",Value="收入" }
                };
        }
        // GET: Tally
        public ActionResult Index()
        {
            PageOption();
            return View();
        }

        [HttpPost]
        public ActionResult Index(Spending pageData)
        {
            //doSomething
            //xxxServices(pageData)
            PageOption();
            return View();
        }

        [ChildActionOnly]
        public ActionResult SpendingList()
        {
            Random rNumber = new Random();
            var result = new List<Spending>();

            for (int i = 0; i < 10; i++)
            {
                result.Add(new Spending
                {
                    Category = rNumber.Next(0, 2) == 0 ? "收入" : "支出",
                    Date = DateTime.Now.Date.AddDays(rNumber.Next(-7, -1)),
                    Money = rNumber.Next(5, 30)*100
                });
            }
            result = result.OrderBy(x => x.Date).ToList();
            return View(result);
        }
    }
}