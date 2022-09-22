using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiForQuizApp.Models
{
    public class Utility
    {
        private static Random random = new Random();

        public static string RandomString (int lenght)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, lenght)
            .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}