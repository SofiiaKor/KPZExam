using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FinancialExpenses.Enums;

namespace FinancialExpenses.Models
{
	public class Expense
	{
		// Нам не потрібно використовувати атрибут [Key],
		// оскільки Code first автоматично створює ключ за полем з ім'ям Id
		public int Id { get; set; }

		public string Title { get; set; }

		public double Price { get; set; }

		public DateTime Time { get; set; }

		public ExpenseCategory Category { get; set; }

		public Expense(string title, double price, DateTime time, ExpenseCategory category)
		{
			Title = title;
			Price = price;
			Time = time;
			Category = category;
		}
	}
}
