﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BLL.Services.Abstracts
{
    public interface IEncryptor
    {
        string Hash(string plainText);
    }
}
