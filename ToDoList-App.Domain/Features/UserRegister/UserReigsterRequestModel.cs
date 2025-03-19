using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList_App.Domain.Features.UserRegister;

public class UserReigsterRequestModel
{
    public string Username { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }

    public string OTP { get; set; }
    public DateTime OTPExp { get; set; }

}
