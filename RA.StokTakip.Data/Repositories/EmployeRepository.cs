using Microsoft.EntityFrameworkCore;
using RA.StokTakip.Data.IRepositories;
using RA.StokTakip.Entities.Model;
using SharedLibrary.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RA.StokTakip.Data.Repositories
{
    public class EmployeRepository : IEmployeRepository
    {

        public async Task<ReturnDto<NoDataDto>> Create(Employe employe)
        {
            try
            {
                using var context = new StokTakipDBContext();
                await context.Employe.AddAsync(employe);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return ReturnDto<NoDataDto>.Fail(ex.Message.ToString(), 500);
            }
            return ReturnDto<NoDataDto>.Success(200);

        }

        public async Task<ReturnDto<NoDataDto>> Delete(Employe employe)
        {
            try
            {
                using var context = new StokTakipDBContext();
                context.Employe.Remove(employe);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return ReturnDto<NoDataDto>.Fail(ex.Message.ToString(), 500);
            }
            return ReturnDto<NoDataDto>.Success(200);
        }


        public async Task<ReturnDto<List<Employe>>> GetAll()
        {
            try
            {
                using var context = new StokTakipDBContext();
                var data = await context.Employe.ToListAsync();
                return ReturnDto<List<Employe>>.Success(data, 200);
            }
            catch (Exception ex)
            {
                return ReturnDto<List<Employe>>.Fail(ex.Message.ToString(), 500);
            }
           
        }

        public async Task<ReturnDto<Employe>> GetById(int id)
        {
            try
            {
                using var context = new StokTakipDBContext();
                var data = await context.Employe.FindAsync(id);
                return ReturnDto<Employe>.Success(data, 200);
            }
            catch (Exception ex)
            {
                return ReturnDto<Employe>.Fail(ex.Message.ToString(), 500);
            }
        }

        public async Task<ReturnDto<NoDataDto>> Update(Employe employe)
        {
            try
            {
                using var context = new StokTakipDBContext();
                context.Employe.Update(employe);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return ReturnDto<NoDataDto>.Fail(ex.Message.ToString(), 500);
            }
            return ReturnDto<NoDataDto>.Success(200);
        }
    }
}
