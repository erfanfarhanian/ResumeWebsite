using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Business.Security
{
	public static class PasswordHasher
	{
		public static string EncodePasswordMD5(this string pass)
		{
			Byte[] originalBytes;
			Byte[] encodedBytes;
			MD5 md5;

			md5 = new MD5CryptoServiceProvider();
			originalBytes = ASCIIEncoding.Default.GetBytes(pass);
			encodedBytes = md5.ComputeHash(originalBytes);

			return BitConverter.ToString(encodedBytes);
		}
	}
}
