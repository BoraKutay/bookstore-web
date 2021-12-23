using BookstoreWeb.Entities.Dtos;
using BookstoreWeb.Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreWeb.Services.Abstract
{
    public interface IMagazineFactory
    {
        Task<IDataResult<MagazineDto>> GetAsync(int magazineId);
        Task<IDataResult<MagazineListDto>> GetAllAsync();
        Task<IResult> AddAsync(AddMagazineDto addBookDto, string createdByName);
        Task<IResult> UpdateAsync(UpdateMagazineDto updateMagazineDto, string modifiedByName);
        Task<IResult> DeleteAsync(int magazineId, string modifiedByName);
        Task<IResult> HardDeleteAsync(int magazineId);
        Task<IDataResult<int>> CountAsync();
        Task<IDataResult<int>> CountByNonDeletedAsync();
    }
}
