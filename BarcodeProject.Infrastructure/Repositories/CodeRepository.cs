using BarcodeProject.Aplication.Interfaces;
using BarcodeProject.Infrastructure.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarcodeProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BarcodeProject.Infrastructure.Repositories
{
    public class CodeRepository:ICodeRepository
    {
        private readonly AppDbContext _context;
        public CodeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Code>> GetAllAsync()
            => await _context.Codes.ToListAsync();

        public async Task<Code?> GetByIdAsync(int id)
            => await _context.Codes.FindAsync(id);

        public async Task<Code> CreateAsync(Code code)
        {
            _context.Codes.Add(code);
            await _context.SaveChangesAsync();
            return code;
        }

        public async Task<bool> ExistsAsync(string gs1Code)
            => await _context.Codes.AnyAsync(c => c.Gs1Code == gs1Code);
    }
}
