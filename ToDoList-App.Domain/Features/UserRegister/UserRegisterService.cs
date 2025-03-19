using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDoList_App.Database.AppDbContextModels;

namespace ToDoList_App.Domain.Features.UserRegister;

public class UserRegisterService
{
    private readonly AppDbContext _db;

    public UserRegisterService(AppDbContext db)
    {
        _db = db;
    }

  public async Task<UserRegisterResponseModel> Register (UserReigsterRequestModel requrestModel)
    {
        UserRegisterResponseModel model = new UserRegisterResponseModel();

       var existingUser = await _db.Users.Where(x => x.Email == requrestModel.Email).FirstOrDefaultAsync();
        if (existingUser != null)
        {
            model.IsSuccess = false;
            model.Message = "User already exists";
            return model;
        }
        string hashedPassword = HashPassword(requrestModel.Password);
        string otpCode = GenerateOTP();
        var item = new User()
        {
            Username = requrestModel.Username,
            Age = requrestModel.Age,
            Email = requrestModel.Email,
            Password = hashedPassword,
            Role = "user",
            Status = "N",
            OTP = otpCode,
            OTPExp = DateTime.Now.AddMinutes(5)

        };

        await _db.Users.AddAsync(item);
      var result =   await _db.SaveChangesAsync();

        if(result > 0)
        {
            bool isEmailSent = SendOTPEmail(requrestModel.Email, otpCode);
            if (isEmailSent)
            {
                model.IsSuccess = true;
                model.Message = "User registered successfully. Please check your email for OTP code.";
            }
            else
            {
                model.IsSuccess = false;
                model.Message = "User registered successfully. Failed to send OTP code to your email.";
            }
        }
        else
        {
            model.IsSuccess = false;
            model.Message = "Failed to register user";
        }

        return model;
    }


    private static string HashPassword(string password)
    {
        using SHA256 sha256 = SHA256.Create();
        var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        return Convert.ToBase64String(hashedBytes);
    }

    private static string GenerateOTP ()
    {
        Random random = new Random();
        return random.Next(100000, 999999).ToString();
    }

    private static bool SendOTPEmail(string toEmail, string otpCode)
    {
        try
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("nnyi37389@gmail.com");
            mail.To.Add(toEmail);
            mail.Subject = "Your OTP Code From ( Thar Nyi ) ";
            mail.Body = $"Your OTP code is: {otpCode}. It will expire in 5 minutes.";
            mail.IsBodyHtml = false;

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("nnyi37389@gmail.com", "jbrq aqmv ukix sfdv"),
                EnableSsl = true
            };

            smtpClient.Send(mail);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }


    public async Task<UserRegisterResponseModel> VerifyOTP(string email, string otp)
    {
        UserRegisterResponseModel model = new UserRegisterResponseModel();
        var user = await _db.Users.Where(u => u.Email == email)
            .OrderByDescending(u => u.OTPExp).FirstOrDefaultAsync();

        if (user is null || user.OTP != otp)
        {
            model.IsSuccess = false;
            model.Message = "Invalid OTP code";
            return model;
        }

        if (user.OTPExp < DateTime.Now)
        {
            model.IsSuccess = false;
            model.Message = "OTP code expired";
            return model;
        }

        user.Status = "Y";
        user.OTP = null;
        user.OTPExp = DateTime.Now;
        _db.Entry(user).State = EntityState.Modified;
       int result =  await _db.SaveChangesAsync();

        string message = result > 0 ? "OTP code verified successfully" : "Failed to verify OTP code";

        model.IsSuccess = result > 0;
        model.Message = message;

        return model;

    }

    }
