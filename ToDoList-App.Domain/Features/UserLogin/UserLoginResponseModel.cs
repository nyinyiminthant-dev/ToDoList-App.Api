using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList_App.Domain.Features.UserLogin;

public class UserLoginResponseModel
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
}
