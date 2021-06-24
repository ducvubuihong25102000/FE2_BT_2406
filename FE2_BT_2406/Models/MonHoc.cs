using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FE2_BT_2406.Models
{
    public class MonHoc
    {
        [Key]
        public int MaMonHoc { get; set; }
        [Required]
        public string TenMonHoc{ get; set; }
        [Required]
        public int MaChuyenNganh { get; set; }

        public ChuyenNganh ChuyenNganh { get; set; }

        public ICollection<DangKyMonHoc> DangKyMonHocs_MH { get; set; }
    }
}