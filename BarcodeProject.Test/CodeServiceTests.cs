using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarcodeProject.Aplication.Services;

namespace BarcodeProject.Test
{
    public class CodeServiceTests
    {
        private readonly CodeService _service;

        public CodeServiceTests()
        {
            // ValidateGs1Code, repository'ye ihtiyaç duymuyor; bu yüzden null verebiliriz.
            _service = new CodeService(repository: null!);
        }

        [Theory]
        [InlineData("123", false)]                   // 3 haneli → false
        [InlineData("ABCDEFGHIJKL", false)]           // harf içeriyor → false
        [InlineData("12345678901A", false)]           // son karakter harf → false
        [InlineData("131681649636", true)]
        [InlineData("131681649638", false)]   // 12 rakam → true (checksum kontrolü basit)
        public void ValidateCodes_ReturnExp(string input, bool exception)
        {
            bool actual = _service.ValidateCode(input);
            Assert.Equal(exception,actual);
        }

    }
}
