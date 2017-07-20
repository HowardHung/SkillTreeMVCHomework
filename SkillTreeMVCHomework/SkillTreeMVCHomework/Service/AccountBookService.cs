using ServiceLab.Repositories;
using SkillTreeMVCHomework.Models;
using SkillTreeMVCHomework.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SkillTreeMVCHomework.Service
{
    public class AccountBookService
    {
        private readonly IRepository<AccountBook> _accountBookRep;
        private readonly IUnitOfWork _unitOfWork;
        public AccountBookService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _accountBookRep = new Repository<AccountBook>(unitOfWork);
        }
        public IQueryable<Spending> GetAll()
        {
            var result = _accountBookRep.LookupAll().Select(x => new Spending
            {
                Category = x.Categoryyy.ToString(),
                Date = x.Dateee,
                Description = x.Remarkkk,
                Money = x.Amounttt
            }).OrderBy(x=>x.Date);
            return result;
        }
        public void Create(Spending spending)
        {
            int categoryValue = 0;
            int.TryParse(spending.Category, out categoryValue);
            _accountBookRep.Create(new AccountBook
            {
                Amounttt = spending.Money,
                Dateee = spending.Date,
                Id = Guid.NewGuid(),
                Remarkkk = spending.Description,
                Categoryyy = categoryValue
            });
        }
        public void Commit()
        {
            _accountBookRep.Commit();
        }
    }
}