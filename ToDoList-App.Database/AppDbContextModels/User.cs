using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList_App.Database.AppDbContextModels;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public int Age { get; set; }
    public string Role { get; set; }
    public string Status { get; set; }
    public string OTP { get; set; }
    public DateTime Otp_Exp { get; set; }





}
