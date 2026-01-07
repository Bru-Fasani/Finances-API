using AutoMapper;
using Finances_API.DTOs;
using Finances_API.Controllers.Models;

namespace Finances_API.Controllers.Models
{
    public class ExpensesProfile : Profile
    {
        public ExpensesProfile()
        {
            CreateMap<Expense, ExpensesDTO>();
            CreateMap<CreateExpenseDTO, Expense>();
            CreateMap<UpdateExpenseDTO, Expense>();
        }
    }
    
}
