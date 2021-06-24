using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FE2_BT_2406.Models
{
    public class DangKyMonHoc
    {
        [Key]
        public int MaDangKy { get; set; }
        [Required]
        public int MaMonHoc { get; set; }
        [Required]
        public string MaSinhVien { get; set; }
        [Required]
        public DateTime ThoiGianDangKy { get; set; }

        public SinhVien SinhVien { get; set; }
        public MonHoc MonHoc { get; set; }
    }
}