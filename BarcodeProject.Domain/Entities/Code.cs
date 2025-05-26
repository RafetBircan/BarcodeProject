using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeProject.Domain.Entities
{
    public class Code
    {
        public int Id { get; set; }  
        public string Gs1Code { get; set; }    
        public DateTime CreateDate { get; set;} = DateTime.Now;    
    }
}
