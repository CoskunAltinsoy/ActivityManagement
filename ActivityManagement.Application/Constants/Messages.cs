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
        internal static readonly string categoryNotFound;
        public static string UserAlreadyExist = "This user already exist";
        public static string SuccesfulRegistration = "registration was successful";
        public static string UserResgistered = "User has registered successfully";
        public static string UserLoggedin = "User has logged in successfully";

        public static string EmailHasNotFound = "This email has not found";
        public static string IncorrectPassword = "This password is incorrect";

        public static string CategoryAdded =  "Category added";
        public static string CategoryDeleted = "Category deleted";
        public static string CategoryUpdated = "Category updated";
        public static string GetAllCategoryId = "Category id got";
        public static string GetCategoryId = "Category got";

        public static string CityAdded = "City added";
        public static string CityDeleted = "City Deleted";
        public static string CityUpdated = "City Updated";
        public static string CitiesGot = "City Got";
        public static string CityGot = "Cities Got";
        public static string CityNotFound;

        public static string ActivityAdded;
        public static string ActivityNotFound;
        public static string ActivityDeleted;
        public static string ActivityUpdated;
        public static string ActivityGot;
        internal static string ActivitiesGot;
    }
}
