using ActivityManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityManagement.Application.Constants
{
    public static class Messages
    {
        public static string UserAlreadyExist = "This user already exist";
        public static string SuccesfulRegistration = "registration was successful";
        public static string UserResgistered = "User has registered successfully";
        public static string UserLoggedin = "User has logged in successfully";

        public static string EmailHasNotFound = "This email has not found";
        public static string IncorrectPassword = "This password is incorrect";
    }
}
