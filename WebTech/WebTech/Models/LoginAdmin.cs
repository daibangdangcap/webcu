using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebTech.Models
{
    public class LoginAdmin
    {
        [Required(ErrorMessage = "Tên đăng nhập không được để trống")]
        [MinLength(5, ErrorMessage = "Tên đăng nhập phải có độ dài từ 5-15 kí tự")]
        public string USER_AD { get; set; }
        
        [DataType("password")]
        public string PASSWORD_AD { get; set; }
    }
}