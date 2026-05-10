using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using #7hc;
using #Cfc;
using #Ddc;
using #Jfc;
using #ufc;
using #yfc;
using #zec;
using StructurePoint.CoreAssets.Licensing.Internals;

namespace StructurePoint.CoreAssets.Licensing
{
	// Token: 0x02000709 RID: 1801
	public sealed class LicenseProvider : IDisposable
	{
		// Token: 0x06003B78 RID: 15224 RVA: 0x00117548 File Offset: 0x00115748
		public LicenseProvider(string A_1, string A_2, #dec A_3)
		{
			if (string.IsNullOrWhiteSpace(A_1))
			{
				throw new ArgumentNullException(#Phc.#3hc(107380526));
			}
			if (string.IsNullOrWhiteSpace(A_2))
			{
				throw new ArgumentNullException(#Phc.#3hc(107380513));
			}
			if (A_3 == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107380532));
			}
			this.#a = A_3;
			this.#b = A_1.Trim();
			this.#c = A_2.Trim();
			#Sec #Sec2;
			if (!Environment.Is64BitProcess)
			{
				#Sec #Sec = new #tfc(A_3);
				#Sec2 = #Sec;
			}
			else
			{
				#Sec #Sec = new #xfc(A_3);
				#Sec2 = #Sec;
			}
			this.#e = #Sec2;
			string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), #Phc.#3hc(107403126), this.#b, this.#c);
			this.#g = Path.Combine(path, #Phc.#3hc(107380487));
			this.#h = Path.Combine(path, #Phc.#3hc(107380506));
			this.#i = new Timer(new TimerCallback(this.#mec), null, TimeSpan.FromSeconds(5.0), TimeSpan.FromSeconds(5.0));
		}

		// Token: 0x06003B79 RID: 15225 RVA: 0x00033833 File Offset: 0x00031A33
		public IReadOnlyList<#cec> #eec()
		{
			return this.#f;
		}

		// Token: 0x06003B7A RID: 15226 RVA: 0x00117678 File Offset: 0x00115878
		public void #eb()
		{
			if (4 != 0)
			{
				this.#e.#Qec(#Aec.#a, this.#h);
				if (!false)
				{
					this.#e.#eb();
					this.#iec();
				}
			}
		}

		// Token: 0x06003B7B RID: 15227 RVA: 0x001176CC File Offset: 0x001158CC
		public void #fec(string A_1)
		{
			if (\u0003.\u0003(this.#g))
			{
				\u0004 u = \u0004.\u0006;
				string text = this.#g;
				if (!false)
				{
					u(text, A_1);
				}
			}
			this.#iec();
		}

		// Token: 0x06003B7C RID: 15228 RVA: 0x00117724 File Offset: 0x00115924
		public bool #gec(string A_1)
		{
			LicensingCode licensingCode;
			for (;;)
			{
				licensingCode = this.#e.#Rec(A_1);
				if (!false)
				{
					if (6 != 0)
					{
						this.#rec(\u0005.\u0007(#Phc.#3hc(107379949), #Phc.#3hc(107379964), licensingCode));
						break;
					}
					break;
				}
			}
			return licensingCode == LicensingCode.LS_SUCCESS;
		}

		// Token: 0x06003B7D RID: 15229 RVA: 0x0011779C File Offset: 0x0011599C
		public unsafe #Cdc #9(bool A_1, bool A_2)
		{
			void* ptr = stackalloc byte[6];
			#Cdc #Cdc = new #Cdc();
			LicensingCode licensingCode2;
			if (!false)
			{
				this.#f.Clear();
				*(byte*)(ptr + 4) = 0;
				LicensingCode licensingCode = (LicensingCode)4294967295U;
				if (4 != 0)
				{
					licensingCode2 = licensingCode;
				}
				*(int*)ptr = 0;
			}
			foreach (string text in this.#d)
			{
				((byte*)ptr)[5] = (\u0006.\u0008(text, #Phc.#3hc(107379935), StringComparison.Ordinal) ? 1 : 0);
				((byte*)ptr)[4] = (byte)(*(sbyte*)((byte*)ptr + 4) | *(sbyte*)((byte*)ptr + 5));
				if ((*(sbyte*)((byte*)ptr + 5) == 0 || A_1) && (*(sbyte*)((byte*)ptr + 5) != 0 || A_2))
				{
					licensingCode2 = this.#nec(text, out *(uint*)ptr);
					#Cdc.#Bdc((uint)licensingCode2);
					if (licensingCode2 == LicensingCode.LS_SUCCESS)
					{
						break;
					}
				}
			}
			if (A_1 && licensingCode2 != LicensingCode.LS_SUCCESS && *(sbyte*)((byte*)ptr + 4) == 0)
			{
				if (this.#d.Any(new Func<string, bool>(LicenseProvider.<>c.<>9.#Rfc)))
				{
					this.#a.#jb(#Phc.#3hc(107379926));
				}
				licensingCode2 = this.#nec(#Phc.#3hc(107379935), out *(uint*)ptr);
				#Cdc.#Bdc((uint)licensingCode2);
			}
			if (licensingCode2 == LicensingCode.LS_SUCCESS)
			{
				#cec #cec = this.#vec(false);
				#cec.#7dc(*(uint*)ptr);
				#cec.#Tdc(#cec.#ZP());
				#cec.#Pdc(new DateTime?(\u0008.\u008D()));
				this.#f.Add(#cec);
				#Cdc.#0P(#cec.#Sdc());
			}
			return #Cdc;
		}

		// Token: 0x06003B7E RID: 15230 RVA: 0x00117974 File Offset: 0x00115B74
		public unsafe #cec #hec()
		{
			void* ptr = stackalloc byte[2];
			*(byte*)ptr = 0;
			for (;;)
			{
				using (List<string>.Enumerator enumerator = this.#d.GetEnumerator())
				{
					IL_88:
					while (enumerator.MoveNext())
					{
						#cec #cec;
						do
						{
							string text = enumerator.Current;
							*(byte*)(ptr + 1) = (\u0006.\u0008(text, #Phc.#3hc(107379935), StringComparison.Ordinal) ? 1 : 0);
							*(byte*)ptr = (byte)(*(sbyte*)ptr | *(sbyte*)((byte*)ptr + 1));
							this.#e.#Bec(text);
							#cec = this.#vec(*(sbyte*)((byte*)ptr + 1) != 0);
							if (((#cec != null) ? #cec.#Idc() : null) == null)
							{
								goto IL_88;
							}
						}
						while (false);
						#cec result = #cec;
						goto IL_FB;
					}
				}
				if (*(sbyte*)ptr != 0)
				{
					goto IL_F9;
				}
				if (6 != 0)
				{
					break;
				}
				continue;
				IL_FB:
				if (7 != 0)
				{
					#cec result;
					return result;
				}
			}
			this.#e.#Bec(#Phc.#3hc(107379935));
			#cec #cec2 = this.#vec(true);
			if (((#cec2 != null) ? #cec2.#Idc() : null) != null)
			{
				return #cec2;
			}
			IL_F9:
			return null;
		}

		// Token: 0x06003B7F RID: 15231 RVA: 0x00117AB8 File Offset: 0x00115CB8
		public void #iec()
		{
			this.#d.Clear();
			while (\u0003.\u0003(this.#g))
			{
				if (-1 != 0)
				{
					this.#d.AddRange(\u000E.\u008F(this.#g).Where(new Func<string, bool>(LicenseProvider.<>c.<>9.#Sfc)));
					break;
				}
			}
		}

		// Token: 0x06003B80 RID: 15232 RVA: 0x00117B48 File Offset: 0x00115D48
		public unsafe string #jec()
		{
			void* ptr = stackalloc byte[8];
			string result = #Phc.#3hc(107379801);
			#Ffc #Iec;
			if (this.#e.#Gec(4U, out #Iec, out *(int*)ptr) == LicensingCode.LS_SUCCESS && this.#e.#Kec(#Iec, 4U, out *(uint*)(ptr + 4)) == LicensingCode.LS_SUCCESS)
			{
				*(int*)ptr = 4;
				result = \u0010.\u0092(((int*)ptr)->ToString(#Phc.#3hc(107408964)), #Phc.#3hc(107408434), \u000F.~\u0090(((uint*)((byte*)ptr + 4))->ToString(#Phc.#3hc(107408964)), 5, '0'));
			}
			return result;
		}

		// Token: 0x06003B81 RID: 15233 RVA: 0x00117C2C File Offset: 0x00115E2C
		public void #1()
		{
			for (;;)
			{
				int num = 0;
				for (;;)
				{
					int num3;
					int num2 = num3 = num;
					int num5;
					int num4 = num5 = this.#eec().Count;
					#cec #cec;
					if (4 != 0)
					{
						if (num2 >= num4)
						{
							goto IL_93;
						}
						if (4 == 0)
						{
							break;
						}
						#cec = this.#eec()[num];
						num3 = (int)#cec.#6dc();
						num5 = 0;
					}
					if (num3 > num5)
					{
						while (!false)
						{
							LicensingCode licensingCode = this.#e.#db(#cec.#6dc());
							if (7 != 0)
							{
								this.#rec(\u0005.\u0007(#Phc.#3hc(107379756), num + 1, licensingCode));
								goto IL_78;
							}
						}
						goto IL_93;
					}
					IL_78:
					int num7;
					int num6 = num7 = num;
					if (8 != 0)
					{
						num7 = num6 + 1;
					}
					num = num7;
				}
			}
			IL_93:
			this.#e.#9ob();
		}

		// Token: 0x06003B82 RID: 15234 RVA: 0x00117D1C File Offset: 0x00115F1C
		private static string #kec(#Efc A_0)
		{
			int num = A_0.#d;
			while (num == 0)
			{
				string text = A_0.#w;
				if (\u0011.~\u0094(text, #Phc.#3hc(107380207), StringComparison.OrdinalIgnoreCase) > -1)
				{
					text = \u0012.~\u0095(text, #Phc.#3hc(107380207), #Phc.#3hc(107399922));
					int num2 = num = \u0013.~\u0096(text, '|');
					if (false)
					{
						continue;
					}
					int num3 = num2;
					text = \u0014.~\u0098(text, num3 + 1);
				}
				else
				{
					text = #Phc.#3hc(107381628);
				}
				return text;
			}
			return string.Empty;
		}

		// Token: 0x06003B83 RID: 15235 RVA: 0x00117DF4 File Offset: 0x00115FF4
		private static string #lec(#Efc A_0)
		{
			int num2;
			int num = num2 = A_0.#d;
			string result;
			while (4 != 0)
			{
				if (num2 != 0)
				{
					string text = \u0015.\u009A(#Phc.#3hc(107380202), A_0.#e);
					if (!false)
					{
						result = text;
					}
				}
				else if (A_0.#B == 1)
				{
					int num3 = num2 = (num = 107380173);
					if (num3 != 0)
					{
						result = #Phc.#3hc(num3);
						num = A_0.#H;
						break;
					}
					continue;
				}
				else
				{
					result = \u0015.\u009A(#Phc.#3hc(107380155), A_0.#h);
				}
				return result;
			}
			if (num == 2)
			{
				return #Phc.#3hc(107380180);
			}
			return result;
		}

		// Token: 0x06003B84 RID: 15236 RVA: 0x00117EC8 File Offset: 0x001160C8
		private void #mec(object A_1)
		{
			try
			{
				foreach (#cec #cec in this.#f)
				{
					if (#cec.#6dc() != 0U)
					{
						DateTime? dateTime = #cec.#Odc();
						if (dateTime != null)
						{
							try
							{
								dateTime = #cec.#Mdc();
								DateTime? dateTime2 = (dateTime != null) ? dateTime : #cec.#Odc();
								if (dateTime2 != null)
								{
									if (\u0001.\u0001(\u0008.\u008D(), dateTime2.Value).TotalSeconds > 0.5 * (double)#cec.#Idc().#Hfc().#y)
									{
										int num = 0;
										for (;;)
										{
											IL_B9:
											int num2;
											for (int i = num; i < 5; i = num2 + 1)
											{
												LicensingCode licensingCode = this.#e.#uP(#cec.#6dc());
												if (licensingCode == LicensingCode.LS_SUCCESS)
												{
													#cec.#Ndc(new DateTime?(\u0008.\u008D()));
												}
												this.#rec(\u0016.\u009B(#Phc.#3hc(107380122), new object[]
												{
													#cec.#6dc(),
													#cec.#Idc().#Hfc().#b,
													\u0008.\u008D(),
													licensingCode
												}));
												if (licensingCode == LicensingCode.LS_SUCCESS || licensingCode != LicensingCode.VLS_RESOURCE_LOCK_FAILURE)
												{
													break;
												}
												#yec.#xec();
												num2 = (num = i);
												if (false)
												{
													goto IL_B9;
												}
											}
											break;
										}
									}
								}
							}
							catch (Exception)
							{
							}
						}
					}
				}
			}
			catch (Exception value)
			{
				Console.WriteLine(value);
				throw;
			}
		}

		// Token: 0x06003B85 RID: 15237 RVA: 0x00118100 File Offset: 0x00116300
		private LicensingCode #nec(string #oec, out uint #pec)
		{
			if (-1 == 0)
			{
				goto IL_72;
			}
			#pec = 0U;
			IL_0A:
			LicensingCode licensingCode;
			if (!false)
			{
				licensingCode = this.#e.#Bec(#oec);
			}
			this.#rec(\u0015.\u009A(#Phc.#3hc(107380041), licensingCode));
			if (false)
			{
				return licensingCode;
			}
			if (licensingCode != LicensingCode.LS_SUCCESS || false)
			{
				return licensingCode;
			}
			licensingCode = this.#e.#Cec(this.#b, this.#c, out #pec);
			IL_72:
			if (false)
			{
				goto IL_0A;
			}
			this.#rec(\u0015.\u009A(#Phc.#3hc(107380028), licensingCode));
			return licensingCode;
		}

		// Token: 0x06003B86 RID: 15238 RVA: 0x001181E8 File Offset: 0x001163E8
		private bool #qec(out #Qfc #6h)
		{
			LicensingCode licensingCode;
			do
			{
				if (!false)
				{
					licensingCode = this.#e.#qec(null, out #6h);
				}
				this.#rec(\u0005.\u0007(#Phc.#3hc(107379949), #Phc.#3hc(107379995), licensingCode));
			}
			while (false);
			return licensingCode == LicensingCode.LS_SUCCESS;
		}

		// Token: 0x06003B87 RID: 15239 RVA: 0x0003383F File Offset: 0x00031A3F
		private void #rec(string A_1)
		{
			this.#a.#kb(A_1);
		}

		// Token: 0x06003B88 RID: 15240 RVA: 0x0011825C File Offset: 0x0011645C
		private bool #sec(out #Efc #6h)
		{
			LicensingCode licensingCode = this.#e.#sec(this.#b, this.#c, 0, out #6h);
			do
			{
				this.#rec(\u0005.\u0007(#Phc.#3hc(107379949), #Phc.#3hc(107379430), licensingCode));
			}
			while (-1 == 0);
			return licensingCode == LicensingCode.LS_SUCCESS;
		}

		// Token: 0x06003B89 RID: 15241 RVA: 0x001182D8 File Offset: 0x001164D8
		private string #tec(#Efc A_1)
		{
			string text;
			while (A_1.#d == 0)
			{
				if (!false)
				{
					text = A_1.#w;
					int num = \u0013.~\u0097(text, '|');
					if (false)
					{
						goto IL_73;
					}
					if (num > -1)
					{
						text = \u0018.~\u0001\u0002(text, 0, num);
						goto IL_92;
					}
					if (A_1.#B != 1)
					{
						goto IL_73;
					}
					IL_6A:
					text = A_1.#x;
					goto IL_92;
					IL_73:
					if (false)
					{
						goto IL_6A;
					}
					\u0018 ~_u0001_u = \u0018.~\u0001\u0002;
					string #R = A_1.#R;
					int num2 = #R.IndexOf('$');
					text = ~_u0001_u(#R, 0, num2);
					IL_92:
					string text2 = this.#jec();
					num = \u0013.~\u0097(text2, '-');
					text = \u0019.\u0002\u0002(text, \u0014.~\u0098(text2, num));
					return text;
				}
			}
			string text3 = this.#jec();
			if (4 != 0)
			{
				text = text3;
			}
			return text;
		}

		// Token: 0x06003B8A RID: 15242 RVA: 0x001183E4 File Offset: 0x001165E4
		private #Hdc #uec(#Efc A_1)
		{
			if (A_1.#d != 0)
			{
				return #Hdc.#a;
			}
			if (A_1.#B != 1)
			{
				goto IL_2A;
			}
			IL_18:
			if (A_1.#H == 2)
			{
				if (4 != 0)
				{
					return #Hdc.#f;
				}
				goto IL_4C;
			}
			IL_2A:
			int #B = A_1.#g;
			int num = -1;
			IL_32:
			int num3;
			if (#B == num)
			{
				int num2 = num3 = A_1.#B;
				if (!false)
				{
					#Hdc result;
					if (num2 != 1)
					{
						result = #Hdc.#e;
					}
					else
					{
						if (false)
						{
							goto IL_18;
						}
						result = #Hdc.#d;
					}
					return result;
				}
				goto IL_60;
			}
			IL_4C:
			if (6 == 0)
			{
				goto IL_18;
			}
			int num4 = #B = A_1.#B;
			int num5 = num = 1;
			if (num5 == 0)
			{
				goto IL_32;
			}
			num3 = ((num4 == num5) ? 5 : 1);
			IL_60:
			#Hdc result2;
			if (!false)
			{
				result2 = (#Hdc)num3;
			}
			return result2;
		}

		// Token: 0x06003B8B RID: 15243 RVA: 0x0011847C File Offset: 0x0011667C
		private #cec #vec(bool A_1)
		{
			#cec #cec = new #cec();
			#Efc #Efc;
			#cec.#Jdc(this.#sec(out #Efc) ? new #Ifc(#Efc) : null);
			if (!A_1)
			{
				#Qfc #Qfc;
				#cec.#Ldc(this.#qec(out #Qfc) ? #Qfc : null);
				#cec.#Zdc(string.Format(#Phc.#3hc(107379441), (#Qfc != null) ? #Qfc.#Kfc() : 0, (#Qfc != null) ? #Qfc.#Mfc() : 0, (#Qfc != null) ? #Qfc.#Nfc() : 0));
			}
			if (#cec.#Idc() == null)
			{
				return #cec;
			}
			#cec.#5dc(#Efc.#hb == 2);
			#cec.#3dc(#Efc.#hb == 1);
			#cec.#9dc(#Efc.#e);
			#cec.#Rdc(LicenseProvider.#lec(#Efc));
			#cec.#Xdc(this.#tec(#Efc));
			#cec.#Vdc(LicenseProvider.#kec(#Efc));
			#cec.#0P(this.#uec(#Efc));
			TimeSpan timeSpan;
			do
			{
				#cec.#aQ(this.#jec());
				#cec.#1dc(new DateTime?(#Gdc.#Edc((long)#Efc.#g)));
				if (#Efc.#d == 0)
				{
					return #cec;
				}
				timeSpan = this.#wec(#Efc);
			}
			while (8 == 0);
			#cec.#1dc(new DateTime?(\u001B.\u0005\u0002(\u0008.\u008D(), timeSpan)));
			#cec.#bec(timeSpan);
			return #cec;
		}

		// Token: 0x06003B8C RID: 15244 RVA: 0x00118628 File Offset: 0x00116828
		private TimeSpan #wec(#Efc A_1)
		{
			if (A_1.#d != 0)
			{
				TimeSpan result;
				this.#e.#Nec(this.#b, this.#c, out result);
				return result;
			}
			if (A_1.#g == -1)
			{
				return \u001C.\u0006\u0002(-1.0);
			}
			long num = \u0008.\u008E().#Fdc();
			long num2 = (long)A_1.#g;
			while (num2 > num)
			{
				long num4;
				long num3 = num2 = (num4 = (long)A_1.#g);
				if (3 != 0)
				{
					if (6 != 0)
					{
						num4 = num3 - num;
					}
					num = num4;
					IL_82:
					return \u001C.\u0006\u0002((double)num);
				}
			}
			num = 0L;
			goto IL_82;
		}

		// Token: 0x04001978 RID: 6520
		private readonly #dec #a;

		// Token: 0x04001979 RID: 6521
		private readonly string #b;

		// Token: 0x0400197A RID: 6522
		private readonly string #c;

		// Token: 0x0400197B RID: 6523
		private readonly List<string> #d = new List<string>();

		// Token: 0x0400197C RID: 6524
		private readonly #Sec #e;

		// Token: 0x0400197D RID: 6525
		private readonly List<#cec> #f = new List<#cec>();

		// Token: 0x0400197E RID: 6526
		private readonly string #g;

		// Token: 0x0400197F RID: 6527
		private readonly string #h;

		// Token: 0x04001980 RID: 6528
		private readonly Timer #i;
	}
}
