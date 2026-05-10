using System;
using System.Runtime.InteropServices;
using #7hc;
using #Cfc;
using #Ddc;
using #Jfc;
using #zec;
using StructurePoint.CoreAssets.Licensing.Internals;

namespace #ufc
{
	// Token: 0x0200070F RID: 1807
	internal sealed class #tfc : #Sec
	{
		// Token: 0x06003BA0 RID: 15264 RVA: 0x000338C3 File Offset: 0x00031AC3
		public #tfc(#dec A_1)
		{
			this.#a = A_1;
		}

		// Token: 0x06003BA1 RID: 15265 RVA: 0x000338D2 File Offset: 0x00031AD2
		public LicensingCode #eb()
		{
			#tfc.#gfc(0);
			return #tfc.#ffc();
		}

		// Token: 0x06003BA2 RID: 15266 RVA: 0x000338E8 File Offset: 0x00031AE8
		public LicensingCode #db(uint A_1)
		{
			return #tfc.#jfc(A_1, uint.MaxValue, IntPtr.Zero);
		}

		// Token: 0x06003BA3 RID: 15267 RVA: 0x000338FE File Offset: 0x00031AFE
		public LicensingCode #9ob()
		{
			return #tfc.#ifc();
		}

		// Token: 0x06003BA4 RID: 15268 RVA: 0x00033909 File Offset: 0x00031B09
		public LicensingCode #Bec(string A_1)
		{
			return #tfc.#kfc(A_1);
		}

		// Token: 0x06003BA5 RID: 15269 RVA: 0x00033919 File Offset: 0x00031B19
		public LicensingCode #Cec(string #Dec, string #Eec, out uint #Fec)
		{
			return #tfc.#lfc(#Dec, #Eec, out #Fec);
		}

		// Token: 0x06003BA6 RID: 15270 RVA: 0x00118760 File Offset: 0x00116960
		public LicensingCode #qec(string #oec, out #Qfc #6h)
		{
			LicensingCode licensingCode;
			while (2 != 0)
			{
				#vfc #vfc = default(#vfc);
				if (!false && !false)
				{
					licensingCode = #tfc.#bfc(#oec, ref #vfc, IntPtr.Zero, IntPtr.Zero);
					if (4 != 0)
					{
						#6h = ((licensingCode == LicensingCode.LS_SUCCESS) ? new #Qfc(#vfc) : null);
						break;
					}
				}
			}
			return licensingCode;
		}

		// Token: 0x06003BA7 RID: 15271 RVA: 0x001187C4 File Offset: 0x001169C4
		public LicensingCode #sec(string #Dec, string #Eec, int #4jb, out #Efc #6h)
		{
			#6h = default(#Efc);
			#6h.#a = \u001F.\u0010\u0002(\u001E.\u000F\u0002(typeof(#Efc).TypeHandle));
			return #tfc.#mfc(#Dec, #Eec, #4jb, #Phc.#3hc(107381628), ref #6h);
		}

		// Token: 0x06003BA8 RID: 15272 RVA: 0x00118834 File Offset: 0x00116A34
		public unsafe LicensingCode #Gec(uint #Hec, out #Ffc #Iec, out int #Jec)
		{
			void* ptr = stackalloc byte[8];
			if (8 == 0)
			{
				goto IL_113;
			}
			#Iec = default(#Ffc);
			LicensingCode licensingCode;
			if (!false)
			{
				#Jec = 0;
				this.#rec(\u0015.\u009A(#Phc.#3hc(107379392), Marshal.SizeOf<#Ffc>(#Iec)));
				licensingCode = (LicensingCode)3355447311U;
				*(int*)ptr = 0;
				while (*(int*)ptr < 5)
				{
					licensingCode = #tfc.#4ec(ref #Iec);
					this.#rec(\u0005.\u0007(#Phc.#3hc(107379335), *(int*)ptr, licensingCode));
					if (licensingCode == LicensingCode.LS_SUCCESS || licensingCode != LicensingCode.VLS_RESOURCE_LOCK_FAILURE)
					{
						break;
					}
					#yec.#xec();
					*(int*)ptr = *(int*)ptr + 1;
				}
				*(int*)((byte*)ptr + 4) = 0;
				goto IL_12D;
			}
			IL_B4:
			licensingCode = #tfc.#8ec(#Hec, ref #Iec, out #Jec);
			this.#rec(\u0016.\u009B(#Phc.#3hc(107379278), new object[]
			{
				*(int*)((byte*)ptr + 4),
				licensingCode,
				#Jec,
				#Iec.#c,
				#Iec.#m
			}));
			IL_113:
			if (licensingCode == LicensingCode.LS_SUCCESS || licensingCode != LicensingCode.VLS_RESOURCE_LOCK_FAILURE)
			{
				goto IL_137;
			}
			#yec.#xec();
			*(int*)((byte*)ptr + 4) = *(int*)((byte*)ptr + 4) + 1;
			IL_12D:
			if (*(int*)((byte*)ptr + 4) < 5)
			{
				goto IL_B4;
			}
			IL_137:
			this.#rec(#Phc.#3hc(107379660));
			return licensingCode;
		}

		// Token: 0x06003BA9 RID: 15273 RVA: 0x001189D0 File Offset: 0x00116BD0
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
						licensingCode = #tfc.#5ec(ref #Iec, #Lec, out #Mec);
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

		// Token: 0x06003BAA RID: 15274 RVA: 0x00118AA4 File Offset: 0x00116CA4
		public LicensingCode #Nec(string #Oec, string #Eec, out TimeSpan #Pec)
		{
			#Pec = TimeSpan.Zero;
			#Gfc #Gfc = default(#Gfc);
			#Gfc.#a = \u001F.\u0010\u0002(\u001E.\u000F\u0002(typeof(#Gfc).TypeHandle));
			LicensingCode licensingCode = #tfc.#Xec(#Oec, #Eec, 0, ref #Gfc);
			if (licensingCode == LicensingCode.LS_SUCCESS)
			{
				#Pec = \u001C.\u0008\u0002((double)#Gfc.#g);
			}
			return licensingCode;
		}

		// Token: 0x06003BAB RID: 15275 RVA: 0x00118B28 File Offset: 0x00116D28
		public LicensingCode #uP(uint A_1)
		{
			#Bfc #Bfc = default(#Bfc);
			return #tfc.#0ec(A_1, uint.MaxValue, IntPtr.Zero, IntPtr.Zero, ref #Bfc);
		}

		// Token: 0x06003BAC RID: 15276 RVA: 0x00033933 File Offset: 0x00031B33
		public LicensingCode #Qec(#Aec A_1, string A_2)
		{
			return #tfc.#Uec(A_1, A_2, #Phc.#3hc(107381628), 0U);
		}

		// Token: 0x06003BAD RID: 15277 RVA: 0x00033957 File Offset: 0x00031B57
		public LicensingCode #Rec(string A_1)
		{
			return #tfc.#Tec(A_1, null, null, IntPtr.Zero);
		}

		// Token: 0x06003BAE RID: 15278
		[DllImport("lsapiw32.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "VLSaddFeatureToFile")]
		private static extern LicensingCode #Tec(string, string, string, IntPtr);

		// Token: 0x06003BAF RID: 15279
		[DllImport("lsapiw32.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "VLSsetFileName")]
		private static extern LicensingCode #Uec([MarshalAs(UnmanagedType.I4)] [In] #Aec #C, [In] string #bp, [In] string #Vec, [In] uint #Wec);

		// Token: 0x06003BB0 RID: 15280
		[DllImport("lsapiw32.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "VLSgetTrialUsageInfo")]
		private static extern LicensingCode #Xec([In] string #Dec, string #Eec, [In] int #Yec, [In] [Out] ref #Gfc #Zec);

		// Token: 0x06003BB1 RID: 15281
		[DllImport("lsapiw32.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "LSUpdate")]
		[return: MarshalAs(UnmanagedType.I4)]
		private static extern LicensingCode #0ec(uint #Fec, uint #1ec, IntPtr #Wec, IntPtr #2ec, [In] [Out] ref #Bfc #3ec);

		// Token: 0x06003BB2 RID: 15282
		[DllImport("lsapiw32.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "VLSinitMachineID")]
		[return: MarshalAs(UnmanagedType.I4)]
		private static extern LicensingCode #4ec([In] [Out] ref #Ffc #Iec);

		// Token: 0x06003BB3 RID: 15283
		[DllImport("lsapiw32.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "VLSmachineIDtoLockCode")]
		[return: MarshalAs(UnmanagedType.I4)]
		private static extern LicensingCode #5ec([MarshalAs(UnmanagedType.Struct)] [In] [Out] ref #Ffc #6ec, uint #7ec, out uint #Mec);

		// Token: 0x06003BB4 RID: 15284
		[DllImport("lsapiw32.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "VLSgetMachineIDOld")]
		[return: MarshalAs(UnmanagedType.I4)]
		private static extern LicensingCode #8ec([In] uint #9ec, [In] [Out] ref #Ffc #6ec, out int #afc);

		// Token: 0x06003BB5 RID: 15285
		[DllImport("lsapiw32.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "VLSgetServInfo")]
		[return: MarshalAs(UnmanagedType.I4)]
		private static extern LicensingCode #bfc(string #cfc, ref #vfc #dfc, IntPtr #efc, IntPtr #Wec);

		// Token: 0x06003BB6 RID: 15286
		[DllImport("lsapiw32.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "VLSinitialize")]
		private static extern LicensingCode #ffc();

		// Token: 0x06003BB7 RID: 15287
		[DllImport("lsapiw32.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "VLSerrorHandle")]
		private static extern LicensingCode #gfc([MarshalAs(UnmanagedType.I4)] int #hfc);

		// Token: 0x06003BB8 RID: 15288
		[DllImport("lsapiw32.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "VLScleanup")]
		private static extern LicensingCode #ifc();

		// Token: 0x06003BB9 RID: 15289
		[DllImport("lsapiw32.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LSRelease")]
		private static extern LicensingCode #jfc(uint, uint, IntPtr);

		// Token: 0x06003BBA RID: 15290
		[DllImport("lsapiw32.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "VLSsetContactServer")]
		private static extern LicensingCode #kfc([MarshalAs(UnmanagedType.AnsiBStr)] string #cfc);

		// Token: 0x06003BBB RID: 15291 RVA: 0x0003396E File Offset: 0x00031B6E
		private static LicensingCode #lfc(string #Oec, string #Eec, out uint #Fec)
		{
			return #tfc.#nfc(IntPtr.Zero, #Phc.#3hc(107379578), #Oec, #Eec, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, out #Fec);
		}

		// Token: 0x06003BBC RID: 15292
		[DllImport("lsapiw32.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "VLSgetFeatureInfo")]
		private static extern LicensingCode #mfc([MarshalAs(UnmanagedType.AnsiBStr)] [In] string #Oec, [MarshalAs(UnmanagedType.AnsiBStr)] [In] string #Eec, [In] int #4jb, [MarshalAs(UnmanagedType.AnsiBStr)] [In] string #Vec, [In] [Out] ref #Efc #6h);

		// Token: 0x06003BBD RID: 15293
		[DllImport("lsapiw32.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LSRequest")]
		private static extern LicensingCode #nfc(IntPtr #ofc, [MarshalAs(UnmanagedType.AnsiBStr)] string #pfc, [MarshalAs(UnmanagedType.AnsiBStr)] string #Oec, [MarshalAs(UnmanagedType.AnsiBStr)] string #Eec, IntPtr #qfc, IntPtr #rfc, IntPtr #sfc, out uint #Fec);

		// Token: 0x06003BBE RID: 15294 RVA: 0x000339AA File Offset: 0x00031BAA
		private void #rec(string A_1)
		{
			this.#a.#kb(A_1);
		}

		// Token: 0x04001A81 RID: 6785
		private readonly #dec #a;
	}
}
