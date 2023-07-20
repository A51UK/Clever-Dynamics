using System.ComponentModel.DataAnnotations;

namespace Clever_Dynamics.Models
{
    public class LoginViewModel
    {
        [Required(AllowEmptyStrings = false,ErrorMessage = "User Name is Required")]
        [DataType(DataType.Text)]
        public string Username { get; set; } = string.Empty;

    }
}
