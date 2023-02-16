using System;
using System.Collections.Generic;

using SistemaVenta.BLL.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace SistemaVenta.BLL.Implementation
{
	public class UtilidadesService : IUtilidadesService
	{
		public UtilidadesService()
		{
		}

        public string GenerarClave()
        {
            string clave = Guid.NewGuid().ToString("N").Substring(0,6);
            return clave;
        }

        public string ConvertirSha256(string texto)
        {
            StringBuilder sb = new StringBuilder();

            using (SHA256 has = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;

                byte[] result = has.ComputeHash(enc.GetBytes(texto));

                foreach (byte b in result)
                {
                    sb.Append(b.ToString("x2"));
                }
            }
            return sb.ToString();
        }

       
    }
}

