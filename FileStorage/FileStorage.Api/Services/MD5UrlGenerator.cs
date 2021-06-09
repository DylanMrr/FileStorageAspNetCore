using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;

namespace FileStorage.Api.Services
{
    public class MD5UrlGenerator: IUrlGenerator
    {
        public string Generate()
        {
            var hash = MD5.Create()
                .ComputeHash(
                    Encoding.UTF8.GetBytes(
                        DateTime.UtcNow.Subtract(DateTime.UnixEpoch)
                        .TotalSeconds.ToString()));
            //return hash.ToString();
            return Convert.ToBase64String(hash).Replace("=", "").Replace("+", "");
        }
    }
}
