namespace Finances_API.Controllers.Models
{
    public interface IExpenseRepository
    {
        Task<IEnumerable<Expense>> GetAllAsync();
        Task<Expense> GetByIdAsync(int id);
        Task AddAsync(Expense expense);
        Task UpdateAsync(Expense expense);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<IEnumerable<Expense>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<Expense>> GetByCategoryAsync(int categoryId);
    }
}
