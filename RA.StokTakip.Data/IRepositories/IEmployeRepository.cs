using RA.StokTakip.Entities.Model;
using SharedLibrary.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RA.StokTakip.Data.IRepositories
{
    public interface IEmployeRepository
    {
        public Task<ReturnDto<Employe>> GetById(int id);
        public Task<ReturnDto<NoDataDto>> Create(Employe employe);
        public Task<ReturnDto<NoDataDto>> Update(Employe employe);
        public Task<ReturnDto<NoDataDto>> Delete(Employe employe);
        public Task<ReturnDto<List<Employe>>> GetAll();
    }
}
