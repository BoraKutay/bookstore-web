using AutoMapper;
using BookstoreWeb.Data.Abstract;
using BookstoreWeb.Entities.Concrete;
using BookstoreWeb.Entities.Dtos;
using BookstoreWeb.Services.Abstract;
using BookstoreWeb.Shared.Utilities.Results.Abstract;
using BookstoreWeb.Shared.Utilities.Results.ComplexTypes;
using BookstoreWeb.Shared.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreWeb.Services.Concrete
{
    public class CustomerFactory : ICustomerFactory
    {

        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;


        public CustomerFactory(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IResult> AddAsync(AddCustomerDto addCustomerDto)
        {
            var customer = this.mapper.Map<CustomerBase>(addCustomerDto);
            customer.CustomerID = 1;
            await this.unitOfWork.CustomerBases.AddASync(customer);
            await this.unitOfWork.SaveAsync();
            return new Result(ResultStatus.Success);
        }

        public async Task<IDataResult<int>> CountAsync()
        {
            var countCustomer = await this.unitOfWork.CustomerBases.CountAsync();

            if (countCustomer >= 0)
            {
                return new DataResult<int>(ResultStatus.Success, countCustomer);
            }
            return new DataResult<int>(ResultStatus.Error, countCustomer);
        }


        public async Task<IResult> DeleteAsync(int customerID)
        {
            var customer = await this.unitOfWork.CustomerBases.GetAsync(b => b.CustomerID == customerID);
         

            await this.unitOfWork.CustomerBases.UpdateAsync(customer);
            await this.unitOfWork.SaveAsync();
            return new Result(ResultStatus.Success);
        }

        public async Task<IDataResult<CustomerListDto>> GetAllAsync()
        {
            var customers = await this.unitOfWork.CustomerBases.GetAllAsync(null, b => b.CustomerID);

            if (customers.Count >= 0)
            {
                return new DataResult<CustomerListDto>(ResultStatus.Success, new CustomerListDto { Customers = customers, ResultStatus = ResultStatus.Success });
            }
            return new DataResult<CustomerListDto>(ResultStatus.Error, null);
        }

        public async Task<IDataResult<CustomerDto>> GetAsync(int customerID)
        {
            var customer = await this.unitOfWork.CustomerBases.GetAsync(b => b.CustomerID == customerID);

            if (customer != null)
            {
                return new DataResult<CustomerDto>(ResultStatus.Success, new CustomerDto { Customer = customer, ResultStatus = ResultStatus.Success });
            }
            return new DataResult<CustomerDto>(ResultStatus.Error, null);
        }

        public async Task<IResult> HardDeleteAsync(int customerID)
        {
            var res = await this.unitOfWork.CustomerBases.AnyAsync(b => b.CustomerID == customerID);
            if (res)
            {
                var customer = await this.unitOfWork.CustomerBases.GetAsync(b => b.CustomerID == customerID);
                await this.unitOfWork.CustomerBases.DeleteAsync(customer);
                await this.unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success);
            }
            return new Result(ResultStatus.Error);
        }

        public async Task<IResult> UpdateAsync(UpdateCustomerDto updateCustomerDto)
        {
            var customer = this.mapper.Map<CustomerBase>(updateCustomerDto);
            await this.unitOfWork.CustomerBases.UpdateAsync(customer);
            await this.unitOfWork.SaveAsync();
            return new Result(ResultStatus.Success);
        }
    }
    }
}
