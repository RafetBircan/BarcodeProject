using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeProject.Aplication.DTOs
{
    public class CodeDto
    {
        public int Id { get; set; }
        public string Gs1Code { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
