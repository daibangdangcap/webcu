using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace WebTech.Models
{
    public class Register
    {
        
        public CUSTOMER cus { get; set; }
        
        
        [Required(ErrorMessage ="Họ và tên không được rỗng")]
        public string NAME_CUS { get; set; }

        [Required(ErrorMessage ="Địa chỉ không được rỗng")]
        public string ADDRESS { get; set; }
        public string EMAIL { get; set; }
        [Required(ErrorMessage ="SĐT không được rỗng")]
        [MaxLength(10,ErrorMessage ="SĐT không được vượt quá 10 chữ số")]
        public string SDT { get; set; }

        [Required(ErrorMessage ="Tên tài khoản không được rỗng")]
        public string USERNAME { get; set; }
        [Required(ErrorMessage ="Mật khẩu không được rỗng")]
        [DataType("password")]
        public string PASSWORD { get; set; }
    }
}