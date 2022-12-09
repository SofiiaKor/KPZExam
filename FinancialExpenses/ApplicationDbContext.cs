using System.Reflection;
using FinancialExpenses.Models;
using Microsoft.EntityFrameworkCore;

namespace FinancialExpenses
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}

		public DbSet<Expense> Expenses { get; set; }
	}
}