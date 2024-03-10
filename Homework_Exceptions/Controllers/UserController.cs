using Homework_Exceptions.Helpers.Exceptions;
using Homework_Exceptions.Models;
using Homework_Exceptions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Exceptions.Controllers
{
    public class UserController
    {
        UserService userService;

        public UserController()
        {
            userService = new UserService();
        }
        public void GetAll()
        {
            var users = userService.GetAll();
            foreach (var user in users)
            {
                Console.WriteLine($"Id: {user.Id}, Email:{user.Email}, Password:{user.Password}");
            }
        }
        public void Login(string email, string password)
        {
            var users = userService.GetAll();
            try
            {
                foreach (var user in users)
                {
                    if(password.Length < 6)
                    {
                        throw new WrongPasswordFormatException("Wrong password format");
                    }
                    else if (user.Email != email || user.Password != password)
                    {
                        throw new LoginUnsuccessfull("Email or Password is wrong");
                    }
                    else
                    {
                        Console.WriteLine("Login successful");
                        break;
                    }
                }
            }
            catch (LoginUnsuccessfull ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(WrongPasswordFormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
