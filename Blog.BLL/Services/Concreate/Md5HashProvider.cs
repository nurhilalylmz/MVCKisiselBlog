﻿using Blog.BLL.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BLL.Services.Concreate
{
    public class Md5HashProvider : IEncryptor
    {
        public string Hash(string plainText)
        {
            MD5CryptoServiceProvider myprovider = new MD5CryptoServiceProvider();

            byte[] data = myprovider.ComputeHash(Encoding.UTF8.GetBytes(plainText));

            StringBuilder s = new StringBuilder();

            foreach (var item in data)
            {
                //hexadecimal 16lık sayı sistemi
                s.Append(item.ToString("X2"));
            }

            return s.ToString();
        }
    }
}
