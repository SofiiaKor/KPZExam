using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinancialExpenses.Interfaces;
using FinancialExpenses.Models;
using Microsoft.EntityFrameworkCore;

namespace FinancialExpenses.Services
{
	public class ExpenseService : IExpenseService
	{
		private readonly ApplicationDbContext _dbContext;

		public ExpenseService(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task AddAsync(AddExpenseModel request)
		{
			var exists = await ExistsAsync(request.Time);
			if (exists)
				throw new Exception("Already exists.");

			var expense = new Expense(request.Title, request.Price, request.Time, request.Category);

			await _dbContext.Expenses.AddAsync(expense);
			await _dbContext.SaveChangesAsync();
		}

		public async Task<List<Expense>> GetAllAsync()
		{
			var expenses = await _dbContext.Expenses.ToListAsync();

			return expenses;
		}

		private Task<bool> ExistsAsync(int id)
		{
			return _dbContext.Expenses.AnyAsync(o => o.Id == id);
		}

		private Task<bool> ExistsAsync(DateTime time)
		{
			return _dbContext.Expenses.AnyAsync(o => o.Time == time);
		}

		public async Task DeleteAsync(int id)
		{
			var exists = await ExistsAsync(id);
			if (!exists)
				throw new Exception("Not exists.");

			_dbContext.Expenses.Remove(await _dbContext.Expenses.FirstOrDefaultAsync(o => o.Id == id));
			await _dbContext.SaveChangesAsync();
		}

		public async Task UpdateAsync(Expense expense, int id)
		{
			var exists = await ExistsAsync(id);
			if (!exists)
				throw new Exception("Not exists.");

			var existingExpense = _dbContext.Expenses
				.FirstOrDefault(o => o.Id == id);

			existingExpense!.Title = expense.Title;
			existingExpense.Price = expense.Price;
			existingExpense.Time = expense.Time;
			existingExpense.Category = expense.Category;

			await _dbContext.SaveChangesAsync();
		}
	}
}
