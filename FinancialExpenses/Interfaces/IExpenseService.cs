using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinancialExpenses.Models;

namespace FinancialExpenses.Interfaces
{
	public interface IExpenseService
	{
		Task AddAsync(AddExpenseModel request);

		Task<List<Expense>> GetAllAsync();

		Task DeleteAsync(int id);

		Task UpdateAsync(Expense expense, int id);

	}
}
