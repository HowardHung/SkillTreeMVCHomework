using PagedList;
using ServiceLab.Repositories;
using SkillTreeMVCHomework.Models.ViewModel;
using SkillTreeMVCHomework.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SkillTreeMVCHomework.Enum;

namespace SkillTreeMVCHomework.Controllers
{
    public class TallybookController : Controller
    {
        private AccountBookService accountBookService;
        private IUnitOfWork _unitOfWork;
        public TallybookController()
        {
            _unitOfWork = new EFUnitOfWork();
            accountBookService = new AccountBookService(_unitOfWork);
        }
        private void PageOption()
        {
            ViewData["CategorySelectList"] = new List<SelectListItem>
                {
                    new SelectListItem() {Text="支出",Value=((int)CatrgoryEnum.支出).ToString() } ,
                    new SelectListItem() {Text="收入",Value=((int)CatrgoryEnum.收入).ToString() }
                };
        }

        private int padeData(int page = 1)
        {
            var currentPage = page < 1 ? 1 : page;
            ViewData["currentPage"] = currentPage;
            return currentPage;
        }
        // GET: Tally
        public ActionResult Index(int page = 1)
        {
            PageOption();
            padeData(page);
            return View();
        }

        //[HttpPost]
        //public ActionResult Index(Spending pageData)
        //{
        //    //doSomething
        //    //xxxServices(pageData)
        //    if (ModelState.IsValid)
        //    {
        //        accountBookService.Create(pageData);
        //        accountBookService.Commit();
        //    }
        //    PageOption();
        //    return View();
        //}

        [HttpPost]
        public ActionResult AjaxUpdate(Spending pageData, int page = 1)
        {
            //doSomething
            //xxxServices(pageData)
            if (ModelState.IsValid && Request.IsAjaxRequest())
            {
                accountBookService.Create(pageData);
                accountBookService.Commit();
                var result = accountBookService.GetAll().ToPagedList(padeData(page), 10);
                return View("SpendingList", result);
            }
            else
                return Content("您輸入的格式是錯誤，或非Ajax連線");
            
        }


        [ChildActionOnly]
        public ActionResult SpendingList(int page = 1)
        {
            //Random rNumber = new Random();
            //var result = new List<Spending>();
            //for (int i = 0; i < 10; i++)
            //{
            //    result.Add(new Spending
            //    {
            //        Category = rNumber.Next(0, 2) == 0 ? "收入" : "支出",
            //        Date = DateTime.Now.Date.AddDays(rNumber.Next(-7, -1)),
            //        Money = rNumber.Next(5, 30)*100
            //    });
            //}
            //result = result.OrderBy(x => x.Date).ToList();
            var result = accountBookService.GetAll().ToPagedList(padeData(page), 10);
            return PartialView(result);
        }
    }
}