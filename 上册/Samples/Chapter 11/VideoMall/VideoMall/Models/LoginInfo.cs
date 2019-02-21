using System.ComponentModel.DataAnnotations;
namespace Artech.VideoMall.Models
{
    public class LoginInfo
    {
        [Required(ErrorMessage = "请求输入用户名")]
        [Display(Name = "用户名")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "请求输入密码")]
        [Display(Name = "密码")]
        public string Password { get; set; }
    }
}