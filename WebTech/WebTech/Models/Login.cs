using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebTech.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Tên tài khoản rỗng hoặc không đúng")]
        public string USERNAME { get; set; }
        [Required(ErrorMessage = "Mật khẩu rỗng hoặc không đúng")]
        [DataType("password")]
        public string PASSWORD { get; set; }
    }
}