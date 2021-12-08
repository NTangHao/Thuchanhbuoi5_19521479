using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dethicovid.Models
{
    public class Diemcachlymodel
    {
        [Key]
        public string MaDiemCachLy { get; set; }

        public string TenDiemCachLy { get; set; }
        public string   DiaChi { get; set; }
    }
}
