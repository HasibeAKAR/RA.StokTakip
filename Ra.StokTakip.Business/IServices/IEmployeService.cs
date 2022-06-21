using RA.StokTakip.Entities.Model;
using SharedLibrary.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ra.StokTakip.Business.IServices
{
    public interface IEmployeService
    {
        public Task<ReturnDto<Employe>> GetById(int id);
        public Task<ReturnDto<NoDataDto>> Create(Employe employe);
        public Task<ReturnDto<NoDataDto>> Update(Employe employe);
        public Task<ReturnDto<NoDataDto>> Delete(int id);   
        public Task<ReturnDto<List<Employe>>> GetAll();
    }
}
