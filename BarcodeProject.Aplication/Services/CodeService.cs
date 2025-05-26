using BarcodeProject.Aplication.Interfaces;
using BarcodeProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeProject.Aplication.Services
{
    public class CodeService
    {
        private readonly ICodeRepository _repository;

        public CodeService(ICodeRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Code>> GetAllAsync() => await _repository.GetAllAsync();
        public async Task<Code> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);

        #region Create

        public async Task<Code> GenerateNewCodeAsync()
        {
            string newCode;
            do
            {
                newCode = GenerateGs1Code();
            } while (await _repository.ExistsAsync(newCode));

            var code = new Code { Gs1Code = newCode };
            return await _repository.CreateAsync(code);
        }

        private string GenerateGs1Code()
        {
            var random = new Random();
            var base11 = random.NextInt64(10000000000, 99999999999).ToString();
            var checkDigit = CalculateChackDigit(base11);

            return base11 + checkDigit;

        }

        private int CalculateChackDigit(string code)
        {
            int sum = 0;
            for (int i = 0; i < code.Length; i++)
            {
                int digit = int.Parse(code[i].ToString());
                sum += (i % 2 == 0) ? digit * 3 : digit;
            }

            int mod = sum % 10;
            return (10 - mod) % 10;
        }
        #endregion



        public bool ValidateCode(string code)
        {

            if (code.Length != 12 || !code.All(char.IsDigit))
                return (false);

            var base11 = code.Substring(0, 11);
            var expectedChec = CalculateChackDigit(base11);
            var actualCheck = int.Parse(code[11].ToString());

            return expectedChec == actualCheck;
        }


    }
}
