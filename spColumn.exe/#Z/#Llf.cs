using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media;
using #7hc;
using #Ddc;
using #eU;
using #Jfc;
using #qJ;
using #UYd;
using #Yfc;
using StructurePoint.CoreAssets.AppManager.Column.Core;
using StructurePoint.CoreAssets.Column.Core.Core.Diagnostics;
using StructurePoint.CoreAssets.GUI.Framework.Services;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Licensing;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.Products.Column.Resources;
using StructurePoint.Products.Column.Resources.Images;

namespace #Z
{
	// Token: 0x02000013 RID: 19
	internal sealed class #Llf : IDisposable, #dec
	{
		// Token: 0x0600005C RID: 92 RVA: 0x0000333A File Offset: 0x0000153A
		public #Llf(#Llf.#vTb #Pc)
		{
			if (#Pc == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107395311));
			}
			this.#a = #Pc;
			this.#b = new LicenseProvider(#Pc.Name, #Pc.Version, this);
		}

		// Token: 0x0600005D RID: 93 RVA: 0x00003375 File Offset: 0x00001575
		public bool #0()
		{
			return true;
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00003378 File Offset: 0x00001578
		public void #1()
		{
			LicenseProvider licenseProvider = this.#b;
			if (licenseProvider == null)
			{
				return;
			}
			licenseProvider.#1();
		}

		// Token: 0x0600005F RID: 95 RVA: 0x00003392 File Offset: 0x00001592
		public static void #2(int #3)
		{
			#Llf.#db();
			Environment.Exit(#3);
		}

		// Token: 0x06000060 RID: 96 RVA: 0x00085230 File Offset: 0x00083430
		private void #4(string #5)
		{
			Window window = this.#6();
			if (window != null)
			{
				MessageBox.Show(window, #5, this.#a.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
				return;
			}
			MessageBox.Show(#5, this.#a.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
		}

		// Token: 0x06000061 RID: 97 RVA: 0x00085280 File Offset: 0x00083480
		private Window #6()
		{
			if (Application.Current == null)
			{
				return null;
			}
			List<Window> source = Application.Current.Windows.OfType<Window>().ToList<Window>();
			return source.FirstOrDefault(new Func<Window, bool>(#Llf.<>c.<>9.#ATb)) ?? source.FirstOrDefault<Window>();
		}

		// Token: 0x06000062 RID: 98 RVA: 0x000852E8 File Offset: 0x000834E8
		private #Xfc #7(Func<uint?> #8)
		{
			#Xfc result;
			try
			{
				uint? #Zfc = #8();
				result = new #Xfc(#Zfc);
			}
			catch (Exception ex)
			{
				this.#nb(#Phc.#3hc(107395208), ex);
				result = new #Xfc(ex.Message);
			}
			return result;
		}

		// Token: 0x06000063 RID: 99 RVA: 0x00085344 File Offset: 0x00083544
		private uint? #9(bool #ab, bool #bb, params #Hdc[] #cb)
		{
			this.#c = (#cb.Length == 1 && #cb[0] == #Hdc.#a);
			#Cdc #Cdc = this.#b.#9(#ab, #bb);
			if (#Cdc.#Adc() != 0U)
			{
				return new uint?(#Cdc.#Adc());
			}
			if (!#cb.Contains(#Cdc.#ZP()))
			{
				return null;
			}
			return new uint?(#Cdc.#Adc());
		}

		// Token: 0x06000064 RID: 100 RVA: 0x000033AB File Offset: 0x000015AB
		public static void #db()
		{
			#Llf #Llf = #Llf.#d;
			if (#Llf == null)
			{
				return;
			}
			#Llf.#1();
		}

		// Token: 0x06000065 RID: 101 RVA: 0x000853B8 File Offset: 0x000835B8
		public static void #eb(bool #fb)
		{
			#Llf.#vTb #Pc = new #Llf.#vTb
			{
				Name = ColumnGlobalInfo.ShortName,
				Version = ColumnGlobalInfo.LicensedVersion,
				FullName = #Phc.#3hc(107395171),
				LockingCodeProgramVersion = #Phc.#3hc(107395138),
				Image = (#fb ? null : ColumnImages.ActivatorLogo_180X280),
				LicenseRequestUrl = #Phc.#3hc(107395117),
				ContactFormUrl = #Phc.#3hc(107395552),
				BatchMode = #fb,
				Copyright = ColumnGlobalInfo.Copyright
			};
			#Llf.#d = new #Llf(#Pc);
		}

		// Token: 0x06000066 RID: 102 RVA: 0x000033C0 File Offset: 0x000015C0
		public static bool #gb()
		{
			return #Llf.#d.#0();
		}

		// Token: 0x06000067 RID: 103 RVA: 0x0008545C File Offset: 0x0008365C
		public void #hb(#rW #ib)
		{
			#cec #cec = this.#b.#eec().FirstOrDefault<#cec>();
			if (#cec == null)
			{
				return;
			}
			#dQ #dQ = #ib.ApplicationData;
			#dQ.LicenseId = #cec.#Wdc();
			#dQ #dQ2 = #dQ;
			string[] array = new string[5];
			int num = 0;
			#Qfc #Qfc = #cec.#Kdc();
			array[num] = ((#Qfc != null) ? #Qfc.#x() : null);
			array[1] = #Phc.#3hc(107395499);
			int num2 = 2;
			#Qfc #Qfc2 = #cec.#Kdc();
			array[num2] = ((#Qfc2 != null) ? #Qfc2.#Ofc() : null);
			array[3] = #Phc.#3hc(107395494);
			array[4] = #cec.#Ydc();
			#dQ2.LicenseServer = string.Concat(array);
			#dQ.LicensedTo = (#cec.#2dc() ? Environment.UserName : #cec.#Udc());
			#dQ.LicenseType = #cec.#Qdc();
			#dQ.LockingCode = #cec.#9P();
			#dQ.IsTrial = (#cec.#Sdc() == #Hdc.#a);
			if (#cec.#Sdc() == #Hdc.#e || #cec.#Sdc() == #Hdc.#d)
			{
				#dQ.LicenseExpiration = Strings.StringNever;
				return;
			}
			#dQ #dQ3 = #dQ;
			DateTime? dateTime = #cec.#0dc();
			string str = (dateTime != null) ? dateTime.GetValueOrDefault().ToString(#Phc.#3hc(107395517)) : null;
			string str2 = string.Empty.#O2d();
			string str3 = Strings.StringAt.#O2d();
			dateTime = #cec.#0dc();
			#dQ3.LicenseExpiration = str + str2 + str3 + ((dateTime != null) ? dateTime.GetValueOrDefault().ToString(#Phc.#3hc(107395512)) : null);
		}

		// Token: 0x06000068 RID: 104 RVA: 0x000855E4 File Offset: 0x000837E4
		public void #jb(string #5)
		{
			if (this.#c)
			{
				return;
			}
			if (this.#a.BatchMode)
			{
				#TYd.#tn(#5, true);
				return;
			}
			Window window = this.#6();
			if (window != null)
			{
				MessageBox.Show(window, #5, this.#a.Name, MessageBoxButton.OK, MessageBoxImage.Exclamation);
				return;
			}
			MessageBox.Show(#5, this.#a.Name, MessageBoxButton.OK, MessageBoxImage.Exclamation);
		}

		// Token: 0x06000069 RID: 105 RVA: 0x000033D5 File Offset: 0x000015D5
		public void #kb(string #5)
		{
			this.#qb(#5, null);
		}

		// Token: 0x0600006A RID: 106 RVA: 0x000033EB File Offset: 0x000015EB
		private void #lb()
		{
			if (this.#a.BatchMode)
			{
				return;
			}
			#Llf.#e = ColumnResources.CreateSplashScreen();
			#Llf.#e.#od();
		}

		// Token: 0x0600006B RID: 107 RVA: 0x0000341B File Offset: 0x0000161B
		private void #mb()
		{
			if (this.#a.BatchMode)
			{
				return;
			}
			IGenericLoaderWindow genericLoaderWindow = #Llf.#e;
			if (genericLoaderWindow == null)
			{
				return;
			}
			genericLoaderWindow.#Fgc();
		}

		// Token: 0x0600006C RID: 108 RVA: 0x00003446 File Offset: 0x00001646
		private void #nb(string #5, Exception #ob)
		{
			Logger.Error(#5, #ob);
		}

		// Token: 0x0600006D RID: 109 RVA: 0x00085654 File Offset: 0x00083854
		private void #pb(string #5)
		{
			#Llf.#CTb #CTb = new #Llf.#CTb();
			#CTb.#a = #5;
			Logger.Info(new Func<string>(#CTb.#BTb));
		}

		// Token: 0x0600006E RID: 110 RVA: 0x0008568C File Offset: 0x0008388C
		private void #qb(string #5, Exception #ob)
		{
			#Llf.#ETb #ETb = new #Llf.#ETb();
			#ETb.#a = #5;
			Logger.Debug(new Func<string>(#ETb.#DTb), #ob);
		}

		// Token: 0x0600006F RID: 111 RVA: 0x0000345B File Offset: 0x0000165B
		[CompilerGenerated]
		private uint? #rb()
		{
			return this.#9(true, true, new #Hdc[]
			{
				#Hdc.#f,
				#Hdc.#e,
				#Hdc.#c,
				#Hdc.#g,
				#Hdc.#d,
				#Hdc.#a
			});
		}

		// Token: 0x06000070 RID: 112 RVA: 0x000856C4 File Offset: 0x000838C4
		[CompilerGenerated]
		private #Xfc #sb(string #tb)
		{
			#Llf.#xTb #xTb = new #Llf.#xTb();
			#Llf.#xTb #xTb2;
			if (!false)
			{
				#xTb2 = #xTb;
			}
			#xTb2.#b = this;
			#xTb2.#a = #tb;
			return this.#7(new Func<uint?>(#xTb2.#wTb));
		}

		// Token: 0x06000071 RID: 113 RVA: 0x00085708 File Offset: 0x00083908
		[CompilerGenerated]
		private #Xfc #ub(string #tb)
		{
			#Llf.#zTb #zTb = new #Llf.#zTb();
			#Llf.#zTb #zTb2;
			if (!false)
			{
				#zTb2 = #zTb;
			}
			#zTb2.#b = this;
			#zTb2.#a = #tb;
			return this.#7(new Func<uint?>(#zTb2.#yTb));
		}

		// Token: 0x06000072 RID: 114 RVA: 0x00003482 File Offset: 0x00001682
		[CompilerGenerated]
		private #Xfc #vb()
		{
			return this.#7(new Func<uint?>(this.#wb));
		}

		// Token: 0x06000073 RID: 115 RVA: 0x000034A2 File Offset: 0x000016A2
		[CompilerGenerated]
		private uint? #wb()
		{
			return this.#9(true, false, new #Hdc[]
			{
				#Hdc.#a
			});
		}

		// Token: 0x04000021 RID: 33
		private readonly #Llf.#vTb #a;

		// Token: 0x04000022 RID: 34
		private readonly LicenseProvider #b;

		// Token: 0x04000023 RID: 35
		private bool #c;

		// Token: 0x04000024 RID: 36
		internal static #Llf #d;

		// Token: 0x04000025 RID: 37
		private static IGenericLoaderWindow #e;

		// Token: 0x02000014 RID: 20
		internal sealed class #vTb
		{
			// Token: 0x1700001B RID: 27
			// (get) Token: 0x06000074 RID: 116 RVA: 0x000034BE File Offset: 0x000016BE
			// (set) Token: 0x06000075 RID: 117 RVA: 0x000034CA File Offset: 0x000016CA
			public bool BatchMode { get; set; }

			// Token: 0x1700001C RID: 28
			// (get) Token: 0x06000076 RID: 118 RVA: 0x000034DB File Offset: 0x000016DB
			// (set) Token: 0x06000077 RID: 119 RVA: 0x000034E7 File Offset: 0x000016E7
			public string Name { get; set; }

			// Token: 0x1700001D RID: 29
			// (get) Token: 0x06000078 RID: 120 RVA: 0x000034F8 File Offset: 0x000016F8
			// (set) Token: 0x06000079 RID: 121 RVA: 0x00003504 File Offset: 0x00001704
			public string Version { get; set; }

			// Token: 0x1700001E RID: 30
			// (get) Token: 0x0600007A RID: 122 RVA: 0x00003515 File Offset: 0x00001715
			// (set) Token: 0x0600007B RID: 123 RVA: 0x00003521 File Offset: 0x00001721
			public string Copyright { get; set; }

			// Token: 0x1700001F RID: 31
			// (get) Token: 0x0600007C RID: 124 RVA: 0x00003532 File Offset: 0x00001732
			// (set) Token: 0x0600007D RID: 125 RVA: 0x0000353E File Offset: 0x0000173E
			public string FullName { get; set; }

			// Token: 0x17000020 RID: 32
			// (get) Token: 0x0600007E RID: 126 RVA: 0x0000354F File Offset: 0x0000174F
			// (set) Token: 0x0600007F RID: 127 RVA: 0x0000355B File Offset: 0x0000175B
			public string LockingCodeProgramVersion { get; set; }

			// Token: 0x17000021 RID: 33
			// (get) Token: 0x06000080 RID: 128 RVA: 0x0000356C File Offset: 0x0000176C
			// (set) Token: 0x06000081 RID: 129 RVA: 0x00003578 File Offset: 0x00001778
			public ImageSource Image { get; set; }

			// Token: 0x17000022 RID: 34
			// (get) Token: 0x06000082 RID: 130 RVA: 0x00003589 File Offset: 0x00001789
			// (set) Token: 0x06000083 RID: 131 RVA: 0x00003595 File Offset: 0x00001795
			public string LicenseRequestUrl { get; set; }

			// Token: 0x17000023 RID: 35
			// (get) Token: 0x06000084 RID: 132 RVA: 0x000035A6 File Offset: 0x000017A6
			// (set) Token: 0x06000085 RID: 133 RVA: 0x000035B2 File Offset: 0x000017B2
			public string ContactFormUrl { get; set; }

			// Token: 0x04000026 RID: 38
			[CompilerGenerated]
			private bool #a;

			// Token: 0x04000027 RID: 39
			[CompilerGenerated]
			private string #b;

			// Token: 0x04000028 RID: 40
			[CompilerGenerated]
			private string #c;

			// Token: 0x04000029 RID: 41
			[CompilerGenerated]
			private string #d;

			// Token: 0x0400002A RID: 42
			[CompilerGenerated]
			private string #e;

			// Token: 0x0400002B RID: 43
			[CompilerGenerated]
			private string #f;

			// Token: 0x0400002C RID: 44
			[CompilerGenerated]
			private ImageSource #g;

			// Token: 0x0400002D RID: 45
			[CompilerGenerated]
			private string #h;

			// Token: 0x0400002E RID: 46
			[CompilerGenerated]
			private string #i;
		}

		// Token: 0x02000016 RID: 22
		[CompilerGenerated]
		private sealed class #CTb
		{
			// Token: 0x0600008B RID: 139 RVA: 0x000035EB File Offset: 0x000017EB
			internal string #BTb()
			{
				return this.#a;
			}

			// Token: 0x04000031 RID: 49
			public string #a;
		}

		// Token: 0x02000017 RID: 23
		[CompilerGenerated]
		private sealed class #ETb
		{
			// Token: 0x0600008D RID: 141 RVA: 0x000035F7 File Offset: 0x000017F7
			internal string #DTb()
			{
				return this.#a;
			}

			// Token: 0x04000032 RID: 50
			public string #a;
		}

		// Token: 0x02000018 RID: 24
		[CompilerGenerated]
		private sealed class #xTb
		{
			// Token: 0x0600008F RID: 143 RVA: 0x00003603 File Offset: 0x00001803
			internal uint? #wTb()
			{
				this.#b.#b.#gec(this.#a);
				return this.#b.#9(true, false, new #Hdc[]
				{
					#Hdc.#d,
					#Hdc.#g
				});
			}

			// Token: 0x04000033 RID: 51
			public string #a;

			// Token: 0x04000034 RID: 52
			public #Llf #b;
		}

		// Token: 0x02000019 RID: 25
		[CompilerGenerated]
		private sealed class #zTb
		{
			// Token: 0x06000091 RID: 145 RVA: 0x00003643 File Offset: 0x00001843
			internal uint? #yTb()
			{
				this.#b.#b.#fec(this.#a);
				return this.#b.#9(false, true, new #Hdc[]
				{
					#Hdc.#c,
					#Hdc.#e
				});
			}

			// Token: 0x04000035 RID: 53
			public string #a;

			// Token: 0x04000036 RID: 54
			public #Llf #b;
		}
	}
}
