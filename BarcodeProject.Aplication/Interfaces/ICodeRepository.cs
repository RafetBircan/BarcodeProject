using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarcodeProject.Domain.Entities;

namespace BarcodeProject.Aplication.Interfaces
{
    public interface ICodeRepository
    {
        Task<IEnumerable<Code>> GetAllAsync();
        Task<Code> GetByIdAsync(int id);
        Task<Code> CreateAsync(Code code);
        Task<bool> ExistsAsync(string code);
    }
}
