using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList_App.Domain.Features.UserLogin;

public class UserLoginRequestModel
{

    public string Email { get; set; }
    public string Password { get; set; }    

}
