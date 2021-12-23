using BookstoreWeb.Entities.Dtos;
using BookstoreWeb.Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreWeb.Services.Abstract
{
    public interface IMusicCdFactory
    {
        Task<IDataResult<MusicCdDto>> GetAsync(int musicCdId);
        Task<IDataResult<MusicCdListDto>> GetAllAsync();
        Task<IResult> AddAsync(AddMusicCdDto addMusicCdDto, string createdByName);
        Task<IResult> UpdateAsync(UpdateMusicCdDto updateMusicCdDto, string modifiedByName);
        Task<IResult> DeleteAsync(int musicCdId, string modifiedByName);
        Task<IResult> HardDeleteAsync(int musicCdId);
        Task<IDataResult<int>> CountAsync();
        Task<IDataResult<int>> CountByNonDeletedAsync();
    }
}
