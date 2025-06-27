using AutoMapper;
using Finances_API.Controllers.Models;
using Finances_API.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace PersonalExpensesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private readonly IExpenseRepository _expenseRepository;
        private readonly IMapper _mapper;

        public ExpensesController(IExpenseRepository expenseRepository, IMapper mapper)
        {
            _expenseRepository = expenseRepository;
            _mapper = mapper;
        }

        // GET: api/Expenses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExpensesDTO>>> GetExpenses()
        {
            var expenses = await _expenseRepository.GetAllAsync();
            var expensesDTO = _mapper.Map<IEnumerable<ExpensesDTO>>(expenses);
            return Ok(expensesDTO);
        }

        // GET: api/Expenses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExpensesDTO>> GetExpense(int id)
        {
            var expense = await _expenseRepository.GetByIdAsync(id);
            if (expense == null)
            {
                return NotFound();
            }

            var expenseDTO = _mapper.Map<ExpensesDTO>(expense);
            return Ok(expenseDTO);
        }

        // POST: api/Expenses
        [HttpPost]
        public async Task<ActionResult<ExpensesDTO>> PostExpense(CreateExpenseDTO createDto)
        {
            var expense = _mapper.Map<Expense>(createDto);
            await _expenseRepository.AddAsync(expense);
            var resultDto = _mapper.Map<ExpensesDTO>(expense);

            return CreatedAtAction(nameof(GetExpense), new { id = resultDto.Id }, resultDto);
        }

        // PUT: api/Expenses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExpense(int id, UpdateExpenseDTO updateDto)
        {
            if (id != updateDto.Id)
            {
                return BadRequest("ID da URL e do corpo não coincidem.");
            }

            if (!await _expenseRepository.ExistsAsync(id))
            {
                return NotFound();
            }

            var expense = _mapper.Map<Expense>(updateDto);

            try
            {
                await _expenseRepository.UpdateAsync(expense);
            }
            catch
            {
                return StatusCode(500, "Erro ao atualizar a despesa.");
            }

            return NoContent();
        }

        // DELETE: api/Expenses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExpense(int id)
        {
            var existing = await _expenseRepository.GetByIdAsync(id);
            if (existing == null)
            {
                return NotFound();
            }

            await _expenseRepository.DeleteAsync(id);
            return NoContent();
        }

        // GET: api/Expenses/ByDateRange?startDate=2023-01-01&endDate=2023-01-31
        [HttpGet("ByDateRange")]
        public async Task<ActionResult<IEnumerable<ExpensesDTO>>> GetExpensesByDateRange(
            [FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var expenses = await _expenseRepository.GetByDateRangeAsync(startDate, endDate);
            var dtoList = _mapper.Map<IEnumerable<ExpensesDTO>>(expenses);
            return Ok(dtoList);
        }

        // GET: api/Expenses/ByCategory/5
        [HttpGet("ByCategory/{categoryId}")]
        public async Task<ActionResult<IEnumerable<ExpensesDTO>>> GetExpensesByCategory(int categoryId)
        {
            var expenses = await _expenseRepository.GetByCategoryAsync(categoryId);
            var dtoList = _mapper.Map<IEnumerable<ExpensesDTO>>(expenses);
            return Ok(dtoList);
        }
    }
}
