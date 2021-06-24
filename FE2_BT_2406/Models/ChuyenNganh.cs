using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FE2_BT_2406.Models
{
    public class ChuyenNganh
    {
        [Key]
        public int MaChuyenNganh { get; set; }
        [Required]
        public string TenChuyenNganh { get; set; }
        

        public ICollection<SinhVien> SinhViens { get; set; }
        public ICollection<MonHoc> MonHocs { get; set; }
    }
}