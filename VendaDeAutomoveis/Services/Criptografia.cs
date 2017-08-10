using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace VendaDeAutomoveis.Services
{
    static class Criptografia
    {
        public static String CriptografaMd5(String senha)
        {
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(senha));

            String SenhaCriptografada = BitConverter.ToString(s).ToLower();

            return SenhaCriptografada;
        }
    }
}