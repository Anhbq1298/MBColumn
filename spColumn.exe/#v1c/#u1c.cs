using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using #7hc;

namespace #v1c
{
	// Token: 0x02000CBA RID: 3258
	internal sealed class #u1c : IDisposable
	{
		// Token: 0x06006A57 RID: 27223 RVA: 0x0019C870 File Offset: 0x0019AA70
		public #u1c(int #w1c, byte[] #x1c, byte[] #y1c)
		{
			if (#x1c == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107431286));
			}
			if (#y1c == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107431257));
			}
			this.#c = #w1c;
			this.#a = #x1c;
			this.#b = #y1c;
		}

		// Token: 0x06006A58 RID: 27224 RVA: 0x00053F5D File Offset: 0x0005215D
		public static byte[] #p1c<#q1c>(string #f) where #q1c : Encoding, new()
		{
			return Activator.CreateInstance<#q1c>().GetBytes(#f);
		}

		// Token: 0x06006A59 RID: 27225 RVA: 0x00053F6F File Offset: 0x0005216F
		public string #r1c(string #f, string #s1c)
		{
			return this.#r1c<AesManaged>(#f, #s1c);
		}

		// Token: 0x06006A5A RID: 27226 RVA: 0x0019C8C8 File Offset: 0x0019AAC8
		public string #r1c<#Fu>(string #f, string #s1c) where #Fu : SymmetricAlgorithm, new()
		{
			byte[] array = #u1c.#p1c<UTF8Encoding>(#f);
			byte[] array2;
			if (6 != 0)
			{
				array2 = array;
			}
			byte[] inArray;
			do
			{
				#Fu #Fu = Activator.CreateInstance<#Fu>();
				#Fu #Fu2;
				if (8 != 0)
				{
					#Fu2 = #Fu;
				}
				try
				{
					byte[] bytes = new Rfc2898DeriveBytes(#s1c, this.#b, this.#d).GetBytes(this.#c / 8);
					byte[] rgbKey;
					if (-1 != 0)
					{
						rgbKey = bytes;
					}
					if (true)
					{
						SymmetricAlgorithm symmetricAlgorithm = #Fu2;
						CipherMode mode = CipherMode.CBC;
						if (3 != 0)
						{
							symmetricAlgorithm.Mode = mode;
						}
						ICryptoTransform cryptoTransform = #Fu2.CreateEncryptor(rgbKey, this.#a);
						ICryptoTransform cryptoTransform2;
						if (!false)
						{
							cryptoTransform2 = cryptoTransform;
						}
						try
						{
							using (MemoryStream memoryStream = new MemoryStream())
							{
								using (CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoTransform2, CryptoStreamMode.Write))
								{
									Stream stream = cryptoStream;
									byte[] buffer = array2;
									int offset = 0;
									int count = array2.Length;
									if (!false)
									{
										stream.Write(buffer, offset, count);
									}
									do
									{
										cryptoStream.FlushFinalBlock();
									}
									while (7 == 0);
									inArray = memoryStream.ToArray();
								}
							}
						}
						finally
						{
							if (cryptoTransform2 != null)
							{
								cryptoTransform2.Dispose();
							}
						}
					}
					#Fu2.Clear();
				}
				finally
				{
					do
					{
						if (#Fu2 != null)
						{
							#Fu2.Dispose();
						}
					}
					while (8 == 0);
				}
			}
			while (false);
			return Convert.ToBase64String(inArray);
		}

		// Token: 0x06006A5B RID: 27227 RVA: 0x00053F79 File Offset: 0x00052179
		public string #t1c(string #f, string #s1c)
		{
			return this.#t1c<AesManaged>(#f, #s1c);
		}

		// Token: 0x06006A5C RID: 27228 RVA: 0x0019CA28 File Offset: 0x0019AC28
		public string #t1c<#Fu>(string #f, string #s1c) where #Fu : SymmetricAlgorithm, new()
		{
			byte[] array = Convert.FromBase64String(#f);
			byte[] array2;
			if (true)
			{
				array2 = array;
			}
			#Fu #Fu = Activator.CreateInstance<#Fu>();
			#Fu #Fu2;
			if (!false)
			{
				#Fu2 = #Fu;
			}
			byte[] array4;
			int count;
			try
			{
				byte[] bytes = new Rfc2898DeriveBytes(#s1c, this.#b, this.#d).GetBytes(this.#c / 8);
				byte[] rgbKey;
				if (4 != 0)
				{
					rgbKey = bytes;
				}
				SymmetricAlgorithm symmetricAlgorithm = #Fu2;
				CipherMode mode = CipherMode.CBC;
				if (!false)
				{
					symmetricAlgorithm.Mode = mode;
				}
				ICryptoTransform cryptoTransform = #Fu2.CreateDecryptor(rgbKey, this.#a);
				ICryptoTransform cryptoTransform2;
				if (true)
				{
					cryptoTransform2 = cryptoTransform;
				}
				try
				{
					using (MemoryStream memoryStream = new MemoryStream(array2))
					{
						using (CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoTransform2, CryptoStreamMode.Read))
						{
							byte[] array3 = new byte[array2.Length];
							if (2 != 0)
							{
								array4 = array3;
							}
							count = cryptoStream.Read(array4, 0, array4.Length);
						}
					}
				}
				finally
				{
					if (cryptoTransform2 != null)
					{
						cryptoTransform2.Dispose();
					}
				}
				#Fu2.Clear();
			}
			finally
			{
				if (#Fu2 != null)
				{
					#Fu2.Dispose();
				}
			}
			return Encoding.UTF8.GetString(array4, 0, count);
		}

		// Token: 0x06006A5D RID: 27229 RVA: 0x00053F83 File Offset: 0x00052183
		public void #1()
		{
			Array array = this.#b;
			int index = 0;
			int length = this.#b.Length;
			if (!false)
			{
				Array.Clear(array, index, length);
			}
			Array array2 = this.#a;
			int index2 = 0;
			int length2 = this.#a.Length;
			if (!false)
			{
				Array.Clear(array2, index2, length2);
			}
		}

		// Token: 0x04002B88 RID: 11144
		private readonly byte[] #a;

		// Token: 0x04002B89 RID: 11145
		private readonly byte[] #b;

		// Token: 0x04002B8A RID: 11146
		private readonly int #c;

		// Token: 0x04002B8B RID: 11147
		private readonly int #d = 10;
	}
}
