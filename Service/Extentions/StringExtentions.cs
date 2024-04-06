﻿using System;
using System.Text.RegularExpressions;

namespace Service.Extentions
{
	public  static class StringExtentions
	{
        public static bool CheckFullname(this string fullname)
        {
            string[] namesArr = fullname.Split(' ');

            if (namesArr.Length == 2)
            {
                for (int i = 0; i < 2; i++)
                {
                    if (String.IsNullOrWhiteSpace(namesArr[i]) || !CheckIsLetter(namesArr[i]) || namesArr[i].Length < 3)
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }
        public static bool CheckIsLetter(this string name)
        {
            for (int i = 0; i < name.Length; i++)
            {
                if (!char.IsLetter(name[i])) return false;

            }
            return true;

        }


        public static bool isEmailValid(this string email)
        {
            string emailPattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";

            bool isValid = Regex.IsMatch(email, emailPattern);

            if (isValid)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public static string ChangeToCaptalize(this string fullname)
        {

            string[] parts = fullname.Split(' ');
            string part0 = parts[0][0].ToString().ToUpper() + parts[0].Substring(1).ToLower();
            string part1 = parts[1][0].ToString().ToUpper() + parts[1].Substring(1).ToLower();
            return part0 + " " + part1;

        }
    }
}

