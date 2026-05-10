using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using #hTb;

namespace #aic
{
	// Token: 0x0200074D RID: 1869
	internal static class #dic
	{
		// Token: 0x06003CC5 RID: 15557 RVA: 0x0011B08C File Offset: 0x0011928C
		private static ICryptoTransform #bic(byte[] A_0, byte[] A_1, bool A_2)
		{
			ICryptoTransform result;
			using (AesCryptoServiceProvider aesCryptoServiceProvider = new AesCryptoServiceProvider())
			{
				result = (A_2 ? aesCryptoServiceProvider.CreateDecryptor(A_0, A_1) : aesCryptoServiceProvider.CreateEncryptor(A_0, A_1));
			}
			return result;
		}

		// Token: 0x06003CC6 RID: 15558 RVA: 0x0011B0E0 File Offset: 0x001192E0
		public static byte[] #cic(byte[] A_0)
		{
			#dic.#Hic #Hic = new #dic.#Hic(A_0);
			byte[] array = new byte[0];
			int num = #Hic.#Gic();
			int num2 = num >> 24;
			if (num - (num2 << 24) == 8223355)
			{
				switch (num2)
				{
				case 1:
				{
					int num3 = #Hic.#Gic();
					array = new byte[num3];
					int num5;
					for (int i = 0; i < num3; i += num5)
					{
						int num4 = #Hic.#Gic();
						num5 = #Hic.#Gic();
						byte[] array2 = new byte[num4];
						#Hic.Read(array2, 0, array2.Length);
						new #dic.#hic(array2).#gic(array, i, num5);
					}
					goto IL_121;
				}
				case 3:
				{
					byte[] array3 = new byte[]
					{
						173,
						144,
						222,
						195,
						164,
						19,
						143,
						144,
						140,
						63,
						112,
						16,
						194,
						205,
						39,
						178
					};
					byte[] array4 = new byte[]
					{
						123,
						158,
						123,
						182,
						114,
						74,
						79,
						140,
						72,
						254,
						19,
						9,
						241,
						112,
						216,
						131
					};
					using (ICryptoTransform cryptoTransform = #dic.#bic(array3, array4, true))
					{
						array = #dic.#cic(cryptoTransform.TransformFinalBlock(A_0, 4, A_0.Length - 4));
						goto IL_121;
					}
					break;
				}
				}
				throw new ArgumentOutOfRangeException("version", num2, "Selected compression algorithm is not supported.");
				IL_121:
				#Hic.Close();
				#Hic = null;
				return array;
			}
			throw new FormatException("Unknown Header");
		}

		// Token: 0x0200074E RID: 1870
		internal sealed class #hic
		{
			// Token: 0x06003CC7 RID: 15559 RVA: 0x00034567 File Offset: 0x00032767
			public #hic(byte[] A_1)
			{
				this.#k = new #dic.#qic();
				this.#l = new #dic.#xic();
				this.#e = 2;
				this.#k.#pic(A_1, 0, A_1.Length);
			}

			// Token: 0x06003CC8 RID: 15560 RVA: 0x0011B240 File Offset: 0x00119440
			private bool #eic()
			{
				int num = this.#l.#uic();
				int i;
				if (!false)
				{
					i = num;
				}
				while (i >= 258)
				{
					int num2;
					switch (this.#e)
					{
					case 7:
						while (((num2 = this.#n.#yic(this.#k)) & -256) == 0)
						{
							this.#l.#npb(num2);
							if (--i < 258)
							{
								return true;
							}
						}
						if (num2 >= 257)
						{
							this.#g = #dic.#hic.#a[num2 - 257];
							this.#f = #dic.#hic.#b[num2 - 257];
							goto IL_BF;
						}
						if (num2 < 0)
						{
							return false;
						}
						this.#o = null;
						this.#n = null;
						this.#e = 2;
						return true;
					case 8:
						goto IL_BF;
					case 9:
						goto IL_10E;
					case 10:
						break;
					default:
						continue;
					}
					IL_140:
					if (this.#f > 0)
					{
						this.#e = 10;
						int num3 = this.#k.#iic(this.#f);
						if (num3 < 0)
						{
							return false;
						}
						this.#k.#jic(this.#f);
						this.#h += num3;
					}
					this.#l.#sic(this.#g, this.#h);
					i -= this.#g;
					this.#e = 7;
					continue;
					IL_10E:
					num2 = this.#o.#yic(this.#k);
					if (num2 < 0)
					{
						return false;
					}
					this.#h = #dic.#hic.#c[num2];
					this.#f = #dic.#hic.#d[num2];
					goto IL_140;
					IL_BF:
					if (this.#f > 0)
					{
						this.#e = 8;
						int num4 = this.#k.#iic(this.#f);
						if (num4 < 0)
						{
							return false;
						}
						this.#k.#jic(this.#f);
						this.#g += num4;
					}
					this.#e = 9;
					goto IL_10E;
				}
				return true;
			}

			// Token: 0x06003CC9 RID: 15561 RVA: 0x0011B424 File Offset: 0x00119624
			private bool #fic()
			{
				switch (this.#e)
				{
				case 2:
				{
					if (this.#j)
					{
						this.#e = 12;
						return false;
					}
					int num = this.#k.#iic(3);
					if (num < 0)
					{
						return false;
					}
					this.#k.#jic(3);
					if ((num & 1) != 0)
					{
						this.#j = true;
					}
					switch (num >> 1)
					{
					case 0:
						this.#k.#mic();
						this.#e = 3;
						break;
					case 1:
						this.#n = #dic.#zic.#b;
						this.#o = #dic.#zic.#c;
						this.#e = 7;
						break;
					case 2:
						this.#m = new #dic.#Cic();
						this.#e = 6;
						break;
					}
					return true;
				}
				case 3:
					if ((this.#i = this.#k.#iic(16)) < 0)
					{
						return false;
					}
					this.#k.#jic(16);
					this.#e = 4;
					break;
				case 4:
					break;
				case 5:
					goto IL_13D;
				case 6:
					if (!this.#m.#fic(this.#k))
					{
						return false;
					}
					this.#n = this.#m.#Aic();
					this.#o = this.#m.#Bic();
					this.#e = 7;
					goto IL_1C1;
				case 7:
				case 8:
				case 9:
				case 10:
					goto IL_1C1;
				case 11:
					return false;
				case 12:
					return false;
				default:
					return false;
				}
				if (this.#k.#iic(16) < 0)
				{
					return false;
				}
				this.#k.#jic(16);
				this.#e = 5;
				IL_13D:
				int num2 = this.#l.#tic(this.#k, this.#i);
				this.#i -= num2;
				if (this.#i == 0)
				{
					this.#e = 2;
					return true;
				}
				return !this.#k.#nic();
				IL_1C1:
				return this.#eic();
			}

			// Token: 0x06003CCA RID: 15562 RVA: 0x0011B610 File Offset: 0x00119810
			public int #gic(byte[] A_1, int A_2, int A_3)
			{
				int num = 0;
				for (;;)
				{
					if (this.#e != 11)
					{
						int num2 = this.#l.#wic(A_1, A_2, A_3);
						A_2 += num2;
						num += num2;
						A_3 -= num2;
						if (A_3 == 0)
						{
							break;
						}
					}
					if (!this.#fic() && (this.#l.#vic() <= 0 || this.#e == 11))
					{
						return num;
					}
				}
				return num;
			}

			// Token: 0x04001B7F RID: 7039
			private static readonly int[] #a = new int[]
			{
				3,
				4,
				5,
				6,
				7,
				8,
				9,
				10,
				11,
				13,
				15,
				17,
				19,
				23,
				27,
				31,
				35,
				43,
				51,
				59,
				67,
				83,
				99,
				115,
				131,
				163,
				195,
				227,
				258
			};

			// Token: 0x04001B80 RID: 7040
			private static readonly int[] #b = new int[]
			{
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				1,
				1,
				1,
				1,
				2,
				2,
				2,
				2,
				3,
				3,
				3,
				3,
				4,
				4,
				4,
				4,
				5,
				5,
				5,
				5,
				0
			};

			// Token: 0x04001B81 RID: 7041
			private static readonly int[] #c = new int[]
			{
				1,
				2,
				3,
				4,
				5,
				7,
				9,
				13,
				17,
				25,
				33,
				49,
				65,
				97,
				129,
				193,
				257,
				385,
				513,
				769,
				1025,
				1537,
				2049,
				3073,
				4097,
				6145,
				8193,
				12289,
				16385,
				24577
			};

			// Token: 0x04001B82 RID: 7042
			private static readonly int[] #d = new int[]
			{
				0,
				0,
				0,
				0,
				1,
				1,
				2,
				2,
				3,
				3,
				4,
				4,
				5,
				5,
				6,
				6,
				7,
				7,
				8,
				8,
				9,
				9,
				10,
				10,
				11,
				11,
				12,
				12,
				13,
				13
			};

			// Token: 0x04001B83 RID: 7043
			private int #e;

			// Token: 0x04001B84 RID: 7044
			private int #f;

			// Token: 0x04001B85 RID: 7045
			private int #g;

			// Token: 0x04001B86 RID: 7046
			private int #h;

			// Token: 0x04001B87 RID: 7047
			private int #i;

			// Token: 0x04001B88 RID: 7048
			private bool #j;

			// Token: 0x04001B89 RID: 7049
			private #dic.#qic #k;

			// Token: 0x04001B8A RID: 7050
			private #dic.#xic #l;

			// Token: 0x04001B8B RID: 7051
			private #dic.#Cic #m;

			// Token: 0x04001B8C RID: 7052
			private #dic.#zic #n;

			// Token: 0x04001B8D RID: 7053
			private #dic.#zic #o;
		}

		// Token: 0x0200074F RID: 1871
		internal sealed class #qic
		{
			// Token: 0x06003CCC RID: 15564 RVA: 0x0011B6F0 File Offset: 0x001198F0
			public int #iic(int A_1)
			{
				if (this.#e < A_1)
				{
					if (this.#b == this.#c)
					{
						return -1;
					}
					uint num = this.#d;
					byte[] array = this.#a;
					int num2 = this.#b;
					this.#b = num2 + 1;
					uint num3 = array[num2] & 255U;
					byte[] array2 = this.#a;
					num2 = this.#b;
					this.#b = num2 + 1;
					this.#d = (num | (num3 | (array2[num2] & 255U) << 8) << this.#e);
					this.#e += 16;
				}
				return (int)((ulong)this.#d & (ulong)((long)((1 << A_1) - 1)));
			}

			// Token: 0x06003CCD RID: 15565 RVA: 0x0003459C File Offset: 0x0003279C
			public void #jic(int A_1)
			{
				this.#d >>= (A_1 & 31);
				this.#e -= A_1;
			}

			// Token: 0x06003CCE RID: 15566 RVA: 0x000345C9 File Offset: 0x000327C9
			public int #kic()
			{
				return this.#e;
			}

			// Token: 0x06003CCF RID: 15567 RVA: 0x000345D5 File Offset: 0x000327D5
			public int #lic()
			{
				return this.#c - this.#b + (this.#e >> 3);
			}

			// Token: 0x06003CD0 RID: 15568 RVA: 0x000345F9 File Offset: 0x000327F9
			public void #mic()
			{
				this.#d >>= (this.#e & 7 & 31);
				this.#e &= -8;
			}

			// Token: 0x06003CD1 RID: 15569 RVA: 0x0003462E File Offset: 0x0003282E
			public bool #nic()
			{
				return this.#b == this.#c;
			}

			// Token: 0x06003CD2 RID: 15570 RVA: 0x0011B7AC File Offset: 0x001199AC
			public int #oic(byte[] A_1, int A_2, int A_3)
			{
				int num = 0;
				while (this.#e > 0 && A_3 > 0)
				{
					A_1[A_2++] = (byte)this.#d;
					this.#d >>= 8;
					this.#e -= 8;
					A_3--;
					num++;
				}
				if (A_3 == 0)
				{
					return num;
				}
				int num2 = this.#c - this.#b;
				if (A_3 > num2)
				{
					A_3 = num2;
				}
				Array.Copy(this.#a, this.#b, A_1, A_2, A_3);
				this.#b += A_3;
				if ((this.#b - this.#c & 1) != 0)
				{
					byte[] array = this.#a;
					int num3 = this.#b;
					this.#b = num3 + 1;
					this.#d = (array[num3] & 255U);
					this.#e = 8;
				}
				return num + A_3;
			}

			// Token: 0x06003CD3 RID: 15571 RVA: 0x0011B898 File Offset: 0x00119A98
			public void #pic(byte[] A_1, int A_2, int A_3)
			{
				if (this.#b < this.#c)
				{
					throw new InvalidOperationException();
				}
				int num = A_2 + A_3;
				if (0 > A_2 || A_2 > num || num > A_1.Length)
				{
					throw new ArgumentOutOfRangeException();
				}
				if ((A_3 & 1) != 0)
				{
					this.#d |= (uint)((uint)(A_1[A_2++] & byte.MaxValue) << this.#e);
					this.#e += 8;
				}
				this.#a = A_1;
				this.#b = A_2;
				this.#c = num;
			}

			// Token: 0x04001B8E RID: 7054
			private byte[] #a;

			// Token: 0x04001B8F RID: 7055
			private int #b;

			// Token: 0x04001B90 RID: 7056
			private int #c;

			// Token: 0x04001B91 RID: 7057
			private uint #d;

			// Token: 0x04001B92 RID: 7058
			private int #e;
		}

		// Token: 0x02000750 RID: 1872
		internal sealed class #xic
		{
			// Token: 0x06003CD5 RID: 15573 RVA: 0x0011B938 File Offset: 0x00119B38
			public void #npb(int A_1)
			{
				int num = this.#c;
				this.#c = num + 1;
				if (num == 32768)
				{
					throw new InvalidOperationException();
				}
				byte[] array = this.#a;
				num = this.#b;
				this.#b = num + 1;
				array[num] = (byte)A_1;
				this.#b &= 32767;
			}

			// Token: 0x06003CD6 RID: 15574 RVA: 0x0011B99C File Offset: 0x00119B9C
			private void #ric(int A_1, int A_2)
			{
				while (A_2-- > 0)
				{
					byte[] array = this.#a;
					int num = this.#b;
					this.#b = num + 1;
					array[num] = this.#a[A_1++];
					this.#b &= 32767;
					A_1 &= 32767;
				}
			}

			// Token: 0x06003CD7 RID: 15575 RVA: 0x0011BA00 File Offset: 0x00119C00
			public void #sic(int A_1, int A_2)
			{
				if ((this.#c += A_1) > 32768)
				{
					throw new InvalidOperationException();
				}
				int num = this.#b - A_2 & 32767;
				int num2 = 32768 - A_1;
				if (num > num2 || this.#b >= num2)
				{
					this.#ric(num, A_1);
					return;
				}
				if (A_1 <= A_2)
				{
					Array.Copy(this.#a, num, this.#a, this.#b, A_1);
					this.#b += A_1;
					return;
				}
				while (A_1-- > 0)
				{
					byte[] array = this.#a;
					int num3 = this.#b;
					this.#b = num3 + 1;
					array[num3] = this.#a[num++];
				}
			}

			// Token: 0x06003CD8 RID: 15576 RVA: 0x0011BAD0 File Offset: 0x00119CD0
			public int #tic(#dic.#qic A_1, int A_2)
			{
				A_2 = Math.Min(Math.Min(A_2, 32768 - this.#c), A_1.#lic());
				int num = 32768 - this.#b;
				int num2;
				if (A_2 > num)
				{
					num2 = A_1.#oic(this.#a, this.#b, num);
					if (num2 == num)
					{
						num2 += A_1.#oic(this.#a, 0, A_2 - num);
					}
				}
				else
				{
					num2 = A_1.#oic(this.#a, this.#b, A_2);
				}
				this.#b = (this.#b + num2 & 32767);
				this.#c += num2;
				return num2;
			}

			// Token: 0x06003CD9 RID: 15577 RVA: 0x00034646 File Offset: 0x00032846
			public int #uic()
			{
				return 32768 - this.#c;
			}

			// Token: 0x06003CDA RID: 15578 RVA: 0x00034658 File Offset: 0x00032858
			public int #vic()
			{
				return this.#c;
			}

			// Token: 0x06003CDB RID: 15579 RVA: 0x0011BB90 File Offset: 0x00119D90
			public int #wic(byte[] A_1, int A_2, int A_3)
			{
				int num = this.#b;
				if (A_3 > this.#c)
				{
					A_3 = this.#c;
				}
				else
				{
					num = (this.#b - this.#c + A_3 & 32767);
				}
				int num2 = A_3;
				int num3 = A_3 - num;
				if (num3 > 0)
				{
					Array.Copy(this.#a, 32768 - num3, A_1, A_2, num3);
					A_2 += num3;
					A_3 = num;
				}
				Array.Copy(this.#a, num - A_3, A_1, A_2, A_3);
				this.#c -= num2;
				if (this.#c < 0)
				{
					throw new InvalidOperationException();
				}
				return num2;
			}

			// Token: 0x04001B93 RID: 7059
			private byte[] #a = new byte[32768];

			// Token: 0x04001B94 RID: 7060
			private int #b;

			// Token: 0x04001B95 RID: 7061
			private int #c;
		}

		// Token: 0x02000751 RID: 1873
		internal sealed class #zic
		{
			// Token: 0x06003CDD RID: 15581 RVA: 0x0011BC44 File Offset: 0x00119E44
			static #zic()
			{
				byte[] array = new byte[288];
				int i = 0;
				while (i < 144)
				{
					array[i++] = 8;
				}
				while (i < 256)
				{
					array[i++] = 9;
				}
				while (i < 280)
				{
					array[i++] = 7;
				}
				while (i < 288)
				{
					array[i++] = 8;
				}
				#dic.#zic.#b = new #dic.#zic(array);
				array = new byte[32];
				i = 0;
				while (i < 32)
				{
					array[i++] = 5;
				}
				#dic.#zic.#c = new #dic.#zic(array);
			}

			// Token: 0x06003CDE RID: 15582 RVA: 0x0003467C File Offset: 0x0003287C
			public #zic(byte[] A_1)
			{
				this.#fI(A_1);
			}

			// Token: 0x06003CDF RID: 15583 RVA: 0x0011BCF4 File Offset: 0x00119EF4
			private void #fI(byte[] A_1)
			{
				int[] array = new int[16];
				int[] array2 = new int[16];
				foreach (int num in A_1)
				{
					if (num > 0)
					{
						array[num]++;
					}
				}
				int num2 = 0;
				int num3 = 512;
				for (int j = 1; j <= 15; j++)
				{
					array2[j] = num2;
					num2 += array[j] << 16 - j;
					if (j >= 10)
					{
						int num4 = array2[j] & 130944;
						int num5 = num2 & 130944;
						num3 += num5 - num4 >> 16 - j;
					}
				}
				this.#a = new short[num3];
				int num6 = 512;
				for (int k = 15; k >= 10; k--)
				{
					int num7 = num2 & 130944;
					num2 -= array[k] << 16 - k;
					for (int l = num2 & 130944; l < num7; l += 128)
					{
						this.#a[(int)#dic.#Eic.#Dic(l)] = (short)(-num6 << 4 | k);
						num6 += 1 << k - 9;
					}
				}
				for (int m = 0; m < A_1.Length; m++)
				{
					int num8 = (int)A_1[m];
					if (num8 != 0)
					{
						num2 = array2[num8];
						int num9 = (int)#dic.#Eic.#Dic(num2);
						if (num8 <= 9)
						{
							do
							{
								this.#a[num9] = (short)(m << 4 | num8);
								num9 += 1 << num8;
							}
							while (num9 < 512);
						}
						else
						{
							int num10 = (int)this.#a[num9 & 511];
							int num11 = 1 << (num10 & 15);
							num10 = -(num10 >> 4);
							do
							{
								this.#a[num10 | num9 >> 9] = (short)(m << 4 | num8);
								num9 += 1 << num8;
							}
							while (num9 < num11);
						}
						array2[num8] = num2 + (1 << 16 - num8);
					}
				}
			}

			// Token: 0x06003CE0 RID: 15584 RVA: 0x0011BEF0 File Offset: 0x0011A0F0
			public int #yic(#dic.#qic A_1)
			{
				int num;
				if ((num = A_1.#iic(9)) >= 0)
				{
					int num2;
					if ((num2 = (int)this.#a[num]) >= 0)
					{
						A_1.#jic(num2 & 15);
						return num2 >> 4;
					}
					int num3 = -(num2 >> 4);
					int num4 = num2 & 15;
					if ((num = A_1.#iic(num4)) >= 0)
					{
						num2 = (int)this.#a[num3 | num >> 9];
						A_1.#jic(num2 & 15);
						return num2 >> 4;
					}
					int num5 = A_1.#kic();
					num = A_1.#iic(num5);
					num2 = (int)this.#a[num3 | num >> 9];
					if ((num2 & 15) <= num5)
					{
						A_1.#jic(num2 & 15);
						return num2 >> 4;
					}
					return -1;
				}
				else
				{
					int num6 = A_1.#kic();
					num = A_1.#iic(num6);
					int num2 = (int)this.#a[num];
					if (num2 >= 0 && (num2 & 15) <= num6)
					{
						A_1.#jic(num2 & 15);
						return num2 >> 4;
					}
					return -1;
				}
			}

			// Token: 0x04001B96 RID: 7062
			private short[] #a;

			// Token: 0x04001B97 RID: 7063
			public static readonly #dic.#zic #b;

			// Token: 0x04001B98 RID: 7064
			public static readonly #dic.#zic #c;
		}

		// Token: 0x02000752 RID: 1874
		internal sealed class #Cic
		{
			// Token: 0x06003CE1 RID: 15585 RVA: 0x0011BFE4 File Offset: 0x0011A1E4
			public bool #fic(#dic.#qic A_1)
			{
				for (;;)
				{
					switch (this.#f)
					{
					case 0:
						this.#g = A_1.#iic(5);
						if (this.#g < 0)
						{
							return false;
						}
						this.#g += 257;
						A_1.#jic(5);
						this.#f = 1;
						goto IL_6B;
					case 1:
						goto IL_6B;
					case 2:
						goto IL_C3;
					case 3:
						break;
					case 4:
						goto IL_1B0;
					case 5:
						goto IL_1E6;
					default:
						continue;
					}
					IL_145:
					while (this.#m < this.#i)
					{
						int num = A_1.#iic(3);
						if (num < 0)
						{
							return false;
						}
						A_1.#jic(3);
						this.#c[#dic.#Cic.#n[this.#m]] = (byte)num;
						this.#m++;
					}
					this.#e = new #dic.#zic(this.#c);
					this.#c = null;
					this.#m = 0;
					this.#f = 4;
					IL_1B0:
					int num2;
					while (((num2 = this.#e.#yic(A_1)) & -16) == 0)
					{
						byte[] array = this.#d;
						int num3 = this.#m;
						this.#m = num3 + 1;
						array[num3] = (this.#l = (byte)num2);
						if (this.#m == this.#j)
						{
							return true;
						}
					}
					if (num2 < 0)
					{
						return false;
					}
					if (num2 >= 17)
					{
						this.#l = 0;
					}
					this.#k = num2 - 16;
					this.#f = 5;
					IL_1E6:
					int num4 = #dic.#Cic.#b[this.#k];
					int num5 = A_1.#iic(num4);
					if (num5 < 0)
					{
						return false;
					}
					A_1.#jic(num4);
					num5 += #dic.#Cic.#a[this.#k];
					while (num5-- > 0)
					{
						byte[] array2 = this.#d;
						int num3 = this.#m;
						this.#m = num3 + 1;
						array2[num3] = this.#l;
					}
					if (this.#m == this.#j)
					{
						return true;
					}
					this.#f = 4;
					continue;
					IL_C3:
					this.#i = A_1.#iic(4);
					if (this.#i < 0)
					{
						return false;
					}
					this.#i += 4;
					A_1.#jic(4);
					this.#c = new byte[19];
					this.#m = 0;
					this.#f = 3;
					goto IL_145;
					IL_6B:
					this.#h = A_1.#iic(5);
					if (this.#h < 0)
					{
						return false;
					}
					this.#h++;
					A_1.#jic(5);
					this.#j = this.#g + this.#h;
					this.#d = new byte[this.#j];
					this.#f = 2;
					goto IL_C3;
				}
				return false;
			}

			// Token: 0x06003CE2 RID: 15586 RVA: 0x0011C268 File Offset: 0x0011A468
			public #dic.#zic #Aic()
			{
				byte[] array = new byte[this.#g];
				Array.Copy(this.#d, 0, array, 0, this.#g);
				return new #dic.#zic(array);
			}

			// Token: 0x06003CE3 RID: 15587 RVA: 0x0011C2A8 File Offset: 0x0011A4A8
			public #dic.#zic #Bic()
			{
				byte[] array = new byte[this.#h];
				byte[] array2;
				if (!false)
				{
					array2 = array;
				}
				Array.Copy(this.#d, this.#g, array2, 0, this.#h);
				return new #dic.#zic(array2);
			}

			// Token: 0x06003CE5 RID: 15589 RVA: 0x0011C2F0 File Offset: 0x0011A4F0
			// Note: this type is marked as 'beforefieldinit'.
			static #Cic()
			{
				int[] array = new int[19];
				RuntimeFieldHandle fldHandle = fieldof(#Iic.#f).FieldHandle;
				if (!false)
				{
					RuntimeHelpers.InitializeArray(array, fldHandle);
				}
				#dic.#Cic.#n = array;
			}

			// Token: 0x04001B99 RID: 7065
			private static readonly int[] #a = new int[]
			{
				3,
				3,
				11
			};

			// Token: 0x04001B9A RID: 7066
			private static readonly int[] #b = new int[]
			{
				2,
				3,
				7
			};

			// Token: 0x04001B9B RID: 7067
			private byte[] #c;

			// Token: 0x04001B9C RID: 7068
			private byte[] #d;

			// Token: 0x04001B9D RID: 7069
			private #dic.#zic #e;

			// Token: 0x04001B9E RID: 7070
			private int #f;

			// Token: 0x04001B9F RID: 7071
			private int #g;

			// Token: 0x04001BA0 RID: 7072
			private int #h;

			// Token: 0x04001BA1 RID: 7073
			private int #i;

			// Token: 0x04001BA2 RID: 7074
			private int #j;

			// Token: 0x04001BA3 RID: 7075
			private int #k;

			// Token: 0x04001BA4 RID: 7076
			private byte #l;

			// Token: 0x04001BA5 RID: 7077
			private int #m;

			// Token: 0x04001BA6 RID: 7078
			private static readonly int[] #n;
		}

		// Token: 0x02000753 RID: 1875
		internal sealed class #Eic
		{
			// Token: 0x06003CE6 RID: 15590 RVA: 0x0011C350 File Offset: 0x0011A550
			public static short #Dic(int A_0)
			{
				return (short)((int)#dic.#Eic.#b[A_0 & 15] << 12 | (int)#dic.#Eic.#b[A_0 >> 4 & 15] << 8 | (int)#dic.#Eic.#b[A_0 >> 8 & 15] << 4 | (int)#dic.#Eic.#b[A_0 >> 12]);
			}

			// Token: 0x06003CE7 RID: 15591 RVA: 0x0011C3A0 File Offset: 0x0011A5A0
			static #Eic()
			{
				int num = 0;
				int i;
				if (!false)
				{
					i = num;
				}
				while (i < 144)
				{
					#dic.#Eic.#c[i] = #dic.#Eic.#Dic(48 + i << 8);
					#dic.#Eic.#d[i++] = 8;
				}
				while (i < 256)
				{
					#dic.#Eic.#c[i] = #dic.#Eic.#Dic(256 + i << 7);
					#dic.#Eic.#d[i++] = 9;
				}
				while (i < 280)
				{
					#dic.#Eic.#c[i] = #dic.#Eic.#Dic(-256 + i << 9);
					#dic.#Eic.#d[i++] = 7;
				}
				while (i < 286)
				{
					#dic.#Eic.#c[i] = #dic.#Eic.#Dic(-88 + i << 8);
					#dic.#Eic.#d[i++] = 8;
				}
				#dic.#Eic.#e = new short[30];
				#dic.#Eic.#f = new byte[30];
				for (i = 0; i < 30; i++)
				{
					#dic.#Eic.#e[i] = #dic.#Eic.#Dic(i << 11);
					#dic.#Eic.#f[i] = 5;
				}
			}

			// Token: 0x04001BA7 RID: 7079
			private static readonly int[] #a = new int[]
			{
				16,
				17,
				18,
				0,
				8,
				7,
				9,
				6,
				10,
				5,
				11,
				4,
				12,
				3,
				13,
				2,
				14,
				1,
				15
			};

			// Token: 0x04001BA8 RID: 7080
			private static readonly byte[] #b = new byte[]
			{
				0,
				8,
				4,
				12,
				2,
				10,
				6,
				14,
				1,
				9,
				5,
				13,
				3,
				11,
				7,
				15
			};

			// Token: 0x04001BA9 RID: 7081
			private static readonly short[] #c = new short[286];

			// Token: 0x04001BAA RID: 7082
			private static readonly byte[] #d = new byte[286];

			// Token: 0x04001BAB RID: 7083
			private static readonly short[] #e;

			// Token: 0x04001BAC RID: 7084
			private static readonly byte[] #f;
		}

		// Token: 0x02000754 RID: 1876
		internal sealed class #Hic : MemoryStream
		{
			// Token: 0x06003CE8 RID: 15592 RVA: 0x0003468B File Offset: 0x0003288B
			public int #Fic()
			{
				return this.ReadByte() | this.ReadByte() << 8;
			}

			// Token: 0x06003CE9 RID: 15593 RVA: 0x000346A8 File Offset: 0x000328A8
			public int #Gic()
			{
				return this.#Fic() | this.#Fic() << 16;
			}

			// Token: 0x06003CEA RID: 15594 RVA: 0x000346C6 File Offset: 0x000328C6
			public #Hic(byte[] A_1) : base(A_1, false)
			{
			}
		}
	}
}
