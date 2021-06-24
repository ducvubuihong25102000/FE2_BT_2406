using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FE2_BT_2406.Models
{
    public class SinhVien
    {
        [Key]
        public string MaSinhVien { get; set; }
        [Required]
        public string HoTen { get; set; }
        [Required]
        public bool GioiTinh { get; set; }
        [Required]
        public int MaChuyenNganh { get; set; }

        public ChuyenNganh ChuyenNganh1 { get; set; }

        public ICollection<DangKyMonHoc> DangKyMonHocs_SV { get; set; }
    }
}