using BookstoreWeb.Entities.Dtos;
using BookstoreWeb.Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreWeb.Services.Abstract
{
    public interface ICustomerFactory
    {

        Task<IDataResult<CustomerDto>> GetAsync(int customerID);
        Task<IDataResult<CustomerListDto>> GetAllAsync();
        Task<IResult> AddAsync(AddCustomerDto addCustomerDto);
        Task<IResult> UpdateAsync(UpdateCustomerDto updateCustomerDto);
        Task<IResult> DeleteAsync(int customerID);
        Task<IResult> HardDeleteAsync(int customerID);
        Task<IDataResult<int>> CountAsync();
    }
}
