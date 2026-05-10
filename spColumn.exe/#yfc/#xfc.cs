using System;
using System.Runtime.InteropServices;
using #7hc;
using #Cfc;
using #Ddc;
using #Jfc;
using #zec;
using StructurePoint.CoreAssets.Licensing.Internals;

namespace #yfc
{
	// Token: 0x02000712 RID: 1810
	internal sealed class #xfc : #Sec
	{
		// Token: 0x06003BBF RID: 15295 RVA: 0x000339C4 File Offset: 0x00031BC4
		public #xfc(#dec A_1)
		{
			this.#a = A_1;
		}

		// Token: 0x06003BC0 RID: 15296 RVA: 0x000339D3 File Offset: 0x00031BD3
		public LicensingCode #eb()
		{
			#xfc.#gfc(0);
			return #xfc.#ffc();
		}

		// Token: 0x06003BC1 RID: 15297 RVA: 0x000339E9 File Offset: 0x00031BE9
		public LicensingCode #db(uint A_1)
		{
			return #xfc.#jfc(A_1, uint.MaxValue, IntPtr.Zero);
		}

		// Token: 0x06003BC2 RID: 15298 RVA: 0x000339FF File Offset: 0x00031BFF
		public LicensingCode #9ob()
		{
			return #xfc.#ifc();
		}

		// Token: 0x06003BC3 RID: 15299 RVA: 0x00033A0A File Offset: 0x00031C0A
		public LicensingCode #Bec(string A_1)
		{
			return #xfc.#kfc(A_1);
		}

		// Token: 0x06003BC4 RID: 15300 RVA: 0x00033A1A File Offset: 0x00031C1A
		public LicensingCode #Cec(string #Dec, string #Eec, out uint #Fec)
		{
			return #xfc.#lfc(#Dec, #Eec, out #Fec);
		}

		// Token: 0x06003BC5 RID: 15301 RVA: 0x00118B58 File Offset: 0x00116D58
		public LicensingCode #qec(string #oec, out #Qfc #6h)
		{
			LicensingCode licensingCode;
			while (2 != 0)
			{
				#zfc #zfc = default(#zfc);
				if (!false && !false)
				{
					licensingCode = #xfc.#bfc(#oec, ref #zfc, IntPtr.Zero, IntPtr.Zero);
					if (4 != 0)
					{
						#6h = ((licensingCode == LicensingCode.LS_SUCCESS) ? new #Qfc(#zfc) : null);
						break;
					}
				}
			}
			return licensingCode;
		}

		// Token: 0x06003BC6 RID: 15302 RVA: 0x00118BBC File Offset: 0x00116DBC
		public LicensingCode #sec(string #Dec, string #Eec, int #4jb, out #Efc #6h)
		{
			#6h = default(#Efc);
			#6h.#a = \u001F.\u0010\u0002(\u001E.\u000F\u0002(typeof(#Efc).TypeHandle));
			return #xfc.#mfc(#Dec, #Eec, #4jb, #Phc.#3hc(107381628), ref #6h);
		}

		// Token: 0x06003BC7 RID: 15303 RVA: 0x00118C2C File Offset: 0x00116E2C
		public unsafe LicensingCode #Gec(uint #Hec, out #Ffc #Iec, out int #Jec)
		{
			void* ptr = stackalloc byte[8];
			#Iec = default(#Ffc);
			#Jec = 0;
			this.#rec(\u0015.\u009A(#Phc.#3hc(107379525), Marshal.SizeOf<#Ffc>(#Iec)));
			LicensingCode licensingCode = (LicensingCode)3355447311U;
			*(int*)ptr = 0;
			while (*(int*)ptr < 5)
			{
				licensingCode = #xfc.#4ec(ref #Iec);
				this.#rec(\u0005.\u0007(#Phc.#3hc(107379468), *(int*)ptr, licensingCode));
				if (licensingCode == LicensingCode.LS_SUCCESS || licensingCode != LicensingCode.VLS_RESOURCE_LOCK_FAILURE)
				{
					break;
				}
				#yec.#xec();
				*(int*)ptr = *(int*)ptr + 1;
			}
			*(int*)((byte*)ptr + 4) = 0;
			while (*(int*)((byte*)ptr + 4) < 5)
			{
				licensingCode = #xfc.#8ec(#Hec, ref #Iec, out #Jec);
				this.#rec(\u0016.\u009B(#Phc.#3hc(107378931), new object[]
				{
					*(int*)((byte*)ptr + 4),
					licensingCode,
					#Jec,
					#Iec.#c,
					#Iec.#m
				}));
				if (licensingCode == LicensingCode.LS_SUCCESS || licensingCode != LicensingCode.VLS_RESOURCE_LOCK_FAILURE)
				{
					break;
				}
				#yec.#xec();
				*(int*)((byte*)ptr + 4) = *(int*)((byte*)ptr + 4) + 1;
			}
			return licensingCode;
		}

		// Token: 0x06003BC8 RID: 15304 RVA: 0x00118DAC File Offset: 0x00116FAC
		public LicensingCode #Kec(#Ffc #Iec, uint #Lec, out uint #Mec)
		{
			LicensingCode licensingCode;
			if (!false)
			{
				licensingCode = (LicensingCode)3355447311U;
			}
			#Mec = 0U;
			for (;;)
			{
				IL_11:
				int num;
				if (!false)
				{
					num = 0;
					goto IL_15;
				}
				for (;;)
				{
					IL_7F:
					int num3;
					int num2;
					num = (num2 = num3);
					while (8 != 0)
					{
						if (num2 >= 5)
						{
							return licensingCode;
						}
						licensingCode = #xfc.#5ec(ref #Iec, #Lec, out #Mec);
						this.#rec(\u001A.\u0004\u0002(#Phc.#3hc(107379627), num3, licensingCode, #Mec));
						if (licensingCode == LicensingCode.LS_SUCCESS || licensingCode != LicensingCode.VLS_RESOURCE_LOCK_FAILURE)
						{
							return licensingCode;
						}
						#yec.#xec();
						if (false)
						{
							goto IL_11;
						}
						int num4 = num2 = (num = num3);
						if (5 != 0)
						{
							num3 = num4 + 1;
							goto IL_7F;
						}
					}
					break;
				}
				IL_15:
				if (!false)
				{
					int num3 = num;
				}
				goto IL_7F;
			}
			return licensingCode;
		}

		// Token: 0x06003BC9 RID: 15305 RVA: 0x00118E80 File Offset: 0x00117080
		public LicensingCode #Nec(string #Oec, string #Eec, out TimeSpan #Pec)
		{
			#Pec = TimeSpan.Zero;
			#Gfc #Gfc = default(#Gfc);
			#Gfc.#a = \u001F.\u0010\u0002(\u001E.\u000F\u0002(typeof(#Gfc).TypeHandle));
			LicensingCode licensingCode = #xfc.#Xec(#Oec, #Eec, 0, ref #Gfc);
			if (licensingCode == LicensingCode.LS_SUCCESS)
			{
				#Pec = \u001C.\u0008\u0002((double)#Gfc.#g);
			}
			return licensingCode;
		}

		// Token: 0x06003BCA RID: 15306 RVA: 0x00118F04 File Offset: 0x00117104
		public LicensingCode #uP(uint A_1)
		{
			#Bfc #Bfc = default(#Bfc);
			return #xfc.#0ec(A_1, uint.MaxValue, IntPtr.Zero, IntPtr.Zero, ref #Bfc);
		}

		// Token: 0x06003BCB RID: 15307 RVA: 0x00033A34 File Offset: 0x00031C34
		public LicensingCode #Qec(#Aec A_1, string A_2)
		{
			return #xfc.#Uec(A_1, A_2, #Phc.#3hc(107381628), 0U);
		}

		// Token: 0x06003BCC RID: 15308 RVA: 0x00033A58 File Offset: 0x00031C58
		public LicensingCode #Rec(string A_1)
		{
			return #xfc.#Tec(A_1, null, null, IntPtr.Zero);
		}

		// Token: 0x06003BCD RID: 15309
		[DllImport("lsapiw64.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "VLSaddFeatureToFile")]
		private static extern LicensingCode #Tec(string, string, string, IntPtr);

		// Token: 0x06003BCE RID: 15310
		[DllImport("lsapiw64.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "VLSsetFileName")]
		private static extern LicensingCode #Uec([MarshalAs(UnmanagedType.I4)] [In] #Aec #C, [In] string #bp, [In] string #Vec, [In] uint #Wec);

		// Token: 0x06003BCF RID: 15311
		[DllImport("lsapiw64.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "VLSgetTrialUsageInfo")]
		private static extern LicensingCode #Xec([In] string #Dec, string #Eec, [In] int #Yec, [In] [Out] ref #Gfc #Zec);

		// Token: 0x06003BD0 RID: 15312
		[DllImport("lsapiw64.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "LSUpdate")]
		[return: MarshalAs(UnmanagedType.I4)]
		private static extern LicensingCode #0ec(uint #Fec, uint #1ec, IntPtr #Wec, IntPtr #2ec, [In] [Out] ref #Bfc #3ec);

		// Token: 0x06003BD1 RID: 15313
		[DllImport("lsapiw64.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "VLSinitMachineID")]
		[return: MarshalAs(UnmanagedType.I4)]
		private static extern LicensingCode #4ec([In] [Out] ref #Ffc #Iec);

		// Token: 0x06003BD2 RID: 15314
		[DllImport("lsapiw64.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "VLSmachineIDtoLockCode")]
		[return: MarshalAs(UnmanagedType.I4)]
		private static extern LicensingCode #5ec([MarshalAs(UnmanagedType.Struct)] [In] [Out] ref #Ffc #6ec, uint #7ec, out uint #Mec);

		// Token: 0x06003BD3 RID: 15315
		[DllImport("lsapiw64.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "VLSgetMachineIDOld")]
		[return: MarshalAs(UnmanagedType.I4)]
		private static extern LicensingCode #8ec([In] uint #9ec, [In] [Out] ref #Ffc #6ec, out int #afc);

		// Token: 0x06003BD4 RID: 15316
		[DllImport("lsapiw64.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "VLSgetServInfo")]
		[return: MarshalAs(UnmanagedType.I4)]
		private static extern LicensingCode #bfc(string #cfc, ref #zfc #dfc, IntPtr #efc, IntPtr #Wec);

		// Token: 0x06003BD5 RID: 15317
		[DllImport("lsapiw64.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "VLSinitialize")]
		private static extern LicensingCode #ffc();

		// Token: 0x06003BD6 RID: 15318
		[DllImport("lsapiw64.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "VLSerrorHandle")]
		private static extern LicensingCode #gfc([MarshalAs(UnmanagedType.I4)] int #hfc);

		// Token: 0x06003BD7 RID: 15319
		[DllImport("lsapiw64.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "VLScleanup")]
		private static extern LicensingCode #ifc();

		// Token: 0x06003BD8 RID: 15320
		[DllImport("lsapiw64.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LSRelease")]
		private static extern LicensingCode #jfc(uint, uint, IntPtr);

		// Token: 0x06003BD9 RID: 15321
		[DllImport("lsapiw64.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "VLSsetContactServer")]
		private static extern LicensingCode #kfc([MarshalAs(UnmanagedType.AnsiBStr)] string #cfc);

		// Token: 0x06003BDA RID: 15322 RVA: 0x00033A6F File Offset: 0x00031C6F
		private static LicensingCode #lfc(string #Oec, string #Eec, out uint #Fec)
		{
			return #xfc.#nfc(IntPtr.Zero, #Phc.#3hc(107379578), #Oec, #Eec, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, out #Fec);
		}

		// Token: 0x06003BDB RID: 15323
		[DllImport("lsapiw64.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "VLSgetFeatureInfo")]
		private static extern LicensingCode #mfc([MarshalAs(UnmanagedType.AnsiBStr)] [In] string #Oec, [MarshalAs(UnmanagedType.AnsiBStr)] [In] string #Eec, [In] int #4jb, [MarshalAs(UnmanagedType.AnsiBStr)] [In] string #Vec, [In] [Out] ref #Efc #6h);

		// Token: 0x06003BDC RID: 15324
		[DllImport("lsapiw64.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LSRequest")]
		private static extern LicensingCode #nfc(IntPtr #ofc, [MarshalAs(UnmanagedType.AnsiBStr)] string #pfc, [MarshalAs(UnmanagedType.AnsiBStr)] string #Oec, [MarshalAs(UnmanagedType.AnsiBStr)] string #Eec, IntPtr #qfc, IntPtr #rfc, IntPtr #sfc, out uint #Fec);

		// Token: 0x06003BDD RID: 15325 RVA: 0x00033AAB File Offset: 0x00031CAB
		private void #rec(string A_1)
		{
			this.#a.#kb(A_1);
		}

		// Token: 0x04001A98 RID: 6808
		private readonly #dec #a;
	}
}
