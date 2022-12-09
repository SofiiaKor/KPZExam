using System;
using System.Threading.Tasks;
using FinancialExpenses.Interfaces;
using FinancialExpenses.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinancialExpenses.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ExpenseController : ControllerBase
	{
		private readonly IExpenseService _expenseService;

		public ExpenseController(IExpenseService expenseService)
		{
			_expenseService = expenseService;
		}

		[HttpPost]
		public async Task<IActionResult> AddAsync(AddExpenseModel request)
		{

			await _expenseService.AddAsync(request);

			return Ok("Added Successfully");
		}

		[HttpGet]
		public async Task<IActionResult> GetAllAsync()
		{
			var expenses = await _expenseService.GetAllAsync();

			return Ok(expenses);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteAsync(int id)
		{
			await _expenseService.DeleteAsync(id);

			return Ok("Deleted Successfully");
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateAsync(Expense expense, int id)
		{
			await _expenseService.UpdateAsync(expense, id);

			return Ok("Updated Successfully");
		}
	}
}