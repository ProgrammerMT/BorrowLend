﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using BorrowLend.Models;

namespace BorrowLend.Models.ViewModels
{
    public class ExpenseVM
    {
        public Expense Expense { get; set; }
        public IEnumerable<SelectListItem> TypeDropDown { get; set; }
    }
}