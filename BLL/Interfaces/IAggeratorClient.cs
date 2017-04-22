﻿using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using BO;

namespace BLL.Interfaces
{
    public interface IAggeratorClient
    {
        Task<T> GetAggergatorResult<T>(string url, string location);
    }
}
