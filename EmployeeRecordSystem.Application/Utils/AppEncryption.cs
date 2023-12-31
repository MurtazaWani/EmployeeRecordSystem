﻿using System.Security.Cryptography;
using System.Text;

namespace EmployeeRecordSystem.Application.Utils;
public class AppEncryption
{
    public static string GenerateSalt()
    {
        return Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));
    }

    public static string CreatePasswordHash(string password, string salt)
    {
        var sha = SHA256.Create();
        byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password + salt));
        return Convert.ToBase64String(bytes);
        //byte[] bytes = Encoding.UTF8.GetBytes(string.Concat(password, salt));
        //return Convert.ToBase64String(sha.ComputeHash(bytes));
    }

    public static bool ComparePassword(string hashPassword, string password, string salt)
    {
        return hashPassword == CreatePasswordHash(password, salt);

        //if(hashPassword == CreatePasswordHash(password, salt)) return true;
        //return false;

        //return hashPassword == CreatePasswordHash(password, salt) ? true : false;
    }
}
