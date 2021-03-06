﻿using SkillTreeMVCHomework.Filter;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SkillTreeMVCHomework.Models.ViewModel
{
    public class Spending
    {
        [Required(ErrorMessage = "*請選擇類別")]
        [Display(Name = "類別")]
        public string Category { get; set; }
        [Required(ErrorMessage = "*請輸入金額")]
        [Display(Name = "金額")]
        [Range(1, 2147483647)]
        [DataType(DataType.Currency)]
        public int Money { get; set; }
        [Required(ErrorMessage = "*請輸入日期")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        //[DataType(DataType.Date)]
        [Display(Name = "日期")]
        [BeforeTomorrow]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "*請輸入備註")]
        [StringLength(100)]
        [Display(Name = "備註")]
        public string Description { get; set; }
    }
}