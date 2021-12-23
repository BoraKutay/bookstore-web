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
    public class MusicCdFactory : IMusicCdFactory
    {

        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private object addBookDto;

        public MusicCdFactory(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<IResult> UpdateAsync(UpdateMusicCdDto updateMusicCdDto, string modifiedByName)
        {
            throw new NotImplementedException();
        }

        public async Task<IResult> AddAsync(AddMusicCdDto addMusicCdDto, string createdByName)
        {
            var musicCD = this.mapper.Map<MusicCD>(addMusicCdDto);
            musicCD.CreatedByName = createdByName;
            musicCD.ModifiedByName = createdByName;
            musicCD.Id = 1;
            await this.unitOfWork.MusicCDs.AddASync(musicCD);
            await this.unitOfWork.SaveAsync();
            return new Result(ResultStatus.Success);
        }

        public async Task<IDataResult<int>> CountAsync()
        {
            var countMusicCD = await this.unitOfWork.MusicCDs.CountAsync();

            if (countMusicCD >= 0)
            {
                return new DataResult<int>(ResultStatus.Success, countMusicCD);
            }
            return new DataResult<int>(ResultStatus.Error, countMusicCD);
        }

        public async Task<IDataResult<int>> CountByNonDeletedAsync()
        {
            var countMusicCD = await this.unitOfWork.MusicCDs.CountAsync(b => !b.IsDeleted);

            if (countMusicCD >= 0)
            {
                return new DataResult<int>(ResultStatus.Success, countMusicCD);
            }
            return new DataResult<int>(ResultStatus.Error, countMusicCD);
        }

        public async Task<IResult> DeleteAsync(int musicCdId, string modifiedByName)
        {
            var music = await this.unitOfWork.MusicCDs.GetAsync(b => b.Id == musicCdId);
            music.IsDeleted = true;
            music.ModifiedByName = modifiedByName;
            music.ModifiedDate = DateTime.Now;

            await this.unitOfWork.MusicCDs.UpdateAsync(music);
            await this.unitOfWork.SaveAsync();

            return new Result(ResultStatus.Success);
        }

        public async Task<IDataResult<MusicCdListDto>> GetAllAsync()
        {
            var musicCds = await this.unitOfWork.MusicCDs.GetAllAsync(null, b => b.Id);

            if (musicCds.Count >= 0)
            {
                return new DataResult<MusicCdListDto>(ResultStatus.Success, new MusicCdListDto { MusicCDs = musicCds, ResultStatus = ResultStatus.Success });
            }
            return new DataResult<MusicCdListDto>(ResultStatus.Error, null);
        }

        public async Task<IDataResult<MusicCdDto>> GetAsync(int musicCdId)
        {
            var musicCd = await this.unitOfWork.MusicCDs.GetAsync(b => b.Id == musicCdId);

            if (musicCd != null)
            {
                return new DataResult<MusicCdDto>(ResultStatus.Success, new MusicCdDto { MusicCD = musicCd, ResultStatus = ResultStatus.Success });
            }
            return new DataResult<MusicCdDto>(ResultStatus.Error, null);
        }

        public async Task<IResult> HardDeleteAsync(int musicCdId)
        {
            var res = await this.unitOfWork.MusicCDs.AnyAsync(b => b.Id == musicCdId);
            if (res)
            {
                var musicCd = await this.unitOfWork.Magazines.GetAsync(b => b.Id == musicCdId);
                await this.unitOfWork.Magazines.DeleteAsync(musicCd);
                await this.unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success);
            }
            return new Result(ResultStatus.Error);
        }
    }




}
    


