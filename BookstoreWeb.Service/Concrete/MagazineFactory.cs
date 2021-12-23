using AutoMapper;
using bookstore.Models;
using BookstoreWeb.Data.Abstract;
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
    public class MagazineFactory : IMagazineFactory
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public MagazineFactory(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IResult> AddAsync(AddMagazineDto addMagazineDto, string createdByName)
        {
            var magazine = this.mapper.Map<Magazine>(addMagazineDto);
            magazine.CreatedByName = createdByName;
            magazine.ModifiedByName = createdByName;
            magazine.Id = 1;
            await this.unitOfWork.Magazines.AddASync(magazine);
            await this.unitOfWork.SaveAsync();
            return new Result(ResultStatus.Success);
        }

        public async Task<IDataResult<int>> CountAsync()
        {
            var countMagazine = await this.unitOfWork.Magazines.CountAsync();

            if (countMagazine >= 0)
            {
                return new DataResult<int>(ResultStatus.Success, countMagazine);
            }
            return new DataResult<int>(ResultStatus.Error, countMagazine);
        }

        public async Task<IDataResult<int>> CountByNonDeletedAsync()
        {
            var countMagazine = await this.unitOfWork.Magazines.CountAsync(b => !b.IsDeleted);

            if (countMagazine >= 0)
            {
                return new DataResult<int>(ResultStatus.Success, countMagazine);
            }
            return new DataResult<int>(ResultStatus.Error, countMagazine);
        }

        public async Task<IResult> DeleteAsync(int magazineId, string modifiedByName)
        {
            var magazine = await this.unitOfWork.Magazines.GetAsync(b => b.Id == magazineId);
            magazine.IsDeleted = true;
            magazine.ModifiedByName = modifiedByName;
            magazine.ModifiedDate = DateTime.Now;

            await this.unitOfWork.Magazines.UpdateAsync(magazine);
            await this.unitOfWork.SaveAsync();

            return new Result(ResultStatus.Success);
        }

        public async Task<IDataResult<MagazineListDto>> GetAllAsync()
        {
            var magazines = await this.unitOfWork.Magazines.GetAllAsync(null, b => b.Id);

            if (magazines.Count >= 0)
            {
                return new DataResult<MagazineListDto>(ResultStatus.Success, new MagazineListDto { Magazines = magazines, ResultStatus = ResultStatus.Success });
            }
            return new DataResult<MagazineListDto>(ResultStatus.Error, null);
        }

        public async Task<IDataResult<MagazineDto>> GetAsync(int magazineId)
        {
            var magazine = await this.unitOfWork.Magazines.GetAsync(b => b.Id == magazineId);

            if (magazine != null)
            {
                return new DataResult<MagazineDto>(ResultStatus.Success, new MagazineDto { Magazine = magazine, ResultStatus = ResultStatus.Success });
            }
            return new DataResult<MagazineDto>(ResultStatus.Error, null);
        }

        public async Task<IResult> HardDeleteAsync(int magazineId)
        {
            var res = await this.unitOfWork.Magazines.AnyAsync(b => b.Id == magazineId);
            if (res)
            {
                var magazine = await this.unitOfWork.Magazines.GetAsync(b => b.Id == magazineId);
                await this.unitOfWork.Magazines.DeleteAsync(magazine);
                await this.unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success);
            }
            return new Result(ResultStatus.Error);
        }

        public async Task<IResult> UpdateAsync(UpdateMagazineDto updateMagazineDto, string modifiedByName)
        {
            var magazine = this.mapper.Map<Magazine>(updateMagazineDto);
            magazine.ModifiedByName = modifiedByName;
            await this.unitOfWork.Magazines.UpdateAsync(magazine);
            await this.unitOfWork.SaveAsync();
            return new Result(ResultStatus.Success);
        }
    }
}
