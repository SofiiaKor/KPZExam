using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinancialExpenses.Enums;

namespace FinancialExpenses.Models
{
	public class AddExpenseModel
	{
		public string Title { get; set; }

		public double Price { get; set; }

		public DateTime Time { get; set; }

		public ExpenseCategory Category { get; set; }
	}
}
