using Ra.StokTakip.Business.IServices;
using RA.StokTakip.Data.IRepositories;
using RA.StokTakip.Entities.Model;
using SharedLibrary.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ra.StokTakip.Business.Services
{

    public class EmployeService : IEmployeService
    {
        private readonly IEmployeRepository _employeRepository;

        public EmployeService(IEmployeRepository employeRepository)
        {
            _employeRepository = employeRepository;
        }

        public async Task<ReturnDto<NoDataDto>> Create(Employe employe)
        {
            var returnDto = await _employeRepository.Create(employe);
            return returnDto;
        }

        public async Task<ReturnDto<NoDataDto>> Delete(int id)
        {
            var employeDto = await _employeRepository.GetById(id);
            if (employeDto.StatusCode == 200)
            {
                var employe = employeDto.Data;
                var returnDto = await _employeRepository.Delete(employe);
                return returnDto;
            }
            else
                return ReturnDto<NoDataDto>.Fail(employeDto.Error, employeDto.StatusCode);
        }

        public async Task<ReturnDto<List<Employe>>> GetAll()
        {
            var returnDto = await _employeRepository.GetAll();
            return returnDto;
        }

        public async Task<ReturnDto<Employe>> GetById(int id)
        {
            var returnDto = await _employeRepository.GetById(id);
            return returnDto;
        }

        public async Task<ReturnDto<NoDataDto>> Update(Employe employe)
        {
            var returnDto = await _employeRepository.Update(employe);
            return returnDto;
        }
    }
}
