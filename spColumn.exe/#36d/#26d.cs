using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security;
using #45d;
using #7hc;
using #cYd;
using #J6d;
using #UYd;
using #x5d;
using Microsoft.Win32;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;

namespace #36d
{
	// Token: 0x02000F43 RID: 3907
	internal sealed class #26d : IDisposable, #55d
	{
		// Token: 0x06008A30 RID: 35376 RVA: 0x001D71CC File Offset: 0x001D53CC
		public #26d(string #46d, #35d #56d)
		{
			#X0d.#V0d(#46d, #Phc.#3hc(107221854), Component.StorageFile, #Phc.#3hc(107221797));
			this.#a = #56d;
			this.SaveOnlyWhenChanged = false;
			this.#b = #I6d.#H6d(Registry.CurrentUser, #46d);
		}

		// Token: 0x06008A31 RID: 35377 RVA: 0x001D721C File Offset: 0x001D541C
		[SecuritySafeCritical]
		public bool #5cc(string #6cc, string #7cc, out string #f)
		{
			#26d.#dZb #dZb = new #26d.#dZb();
			#dZb.#a = #6cc;
			#X0d.#W0d(#dZb.#a, #Phc.#3hc(107221776), Component.StorageFile, #Phc.#3hc(107221227));
			if (string.IsNullOrEmpty(#7cc))
			{
				#7cc = string.Empty;
			}
			#f = #7cc;
			bool result;
			try
			{
				if (this.#a.#15d(#dZb.#a))
				{
					#f = this.#a.#05d(#dZb.#a);
					result = true;
				}
				else if (this.#b.GetValueNames().Any(new Func<string, bool>(#dZb.#B7d)))
				{
					#f = (this.#b.GetValue(#dZb.#a) as string);
					this.#a.#25d(#dZb.#a, #f);
					result = true;
				}
				else
				{
					this.#b.SetValue(#dZb.#a, #f, RegistryValueKind.String);
					this.#a.#25d(#dZb.#a, #f);
					result = false;
				}
			}
			catch (Exception #Uic)
			{
				throw new #w5d(Strings.StringTheSettingsRaisedAnException.#z2d(), #Phc.#3hc(107221206), Component.StorageFile, #IYd.#a, #Uic);
			}
			return result;
		}

		// Token: 0x06008A32 RID: 35378 RVA: 0x001D735C File Offset: 0x001D555C
		public void #zl(string #6cc, string #8cc)
		{
			#X0d.#W0d(#6cc, #Phc.#3hc(107221776), Component.StorageFile, #Phc.#3hc(107221121));
			try
			{
				bool flag = true;
				if (this.SaveOnlyWhenChanged && this.#a.#15d(#6cc))
				{
					flag = !string.Equals(this.#a.#05d(#6cc), #8cc, StringComparison.Ordinal);
				}
				if (flag)
				{
					this.#b.SetValue(#6cc, #8cc, RegistryValueKind.String);
					this.#a.#25d(#6cc, #8cc);
				}
			}
			catch (Exception #Uic)
			{
				throw new #w5d(Strings.StringTheSettingsRaisedAnException.#z2d(), #Phc.#3hc(107221068), Component.StorageFile, #IYd.#a, #Uic);
			}
		}

		// Token: 0x06008A33 RID: 35379 RVA: 0x000706EC File Offset: 0x0006E8EC
		public void #1()
		{
			this.#1(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x06008A34 RID: 35380 RVA: 0x00070707 File Offset: 0x0006E907
		protected void #1(bool #POb)
		{
			if (#POb && this.#b != null)
			{
				this.#b.Dispose();
			}
		}

		// Token: 0x170028A2 RID: 10402
		// (get) Token: 0x06008A35 RID: 35381 RVA: 0x0007072B File Offset: 0x0006E92B
		// (set) Token: 0x06008A36 RID: 35382 RVA: 0x00070737 File Offset: 0x0006E937
		public bool SaveOnlyWhenChanged { get; set; }

		// Token: 0x040038DD RID: 14557
		private readonly #35d #a;

		// Token: 0x040038DE RID: 14558
		private readonly RegistryKey #b;

		// Token: 0x040038DF RID: 14559
		[CompilerGenerated]
		private bool #c;

		// Token: 0x02000F44 RID: 3908
		[CompilerGenerated]
		private sealed class #dZb
		{
			// Token: 0x06008A38 RID: 35384 RVA: 0x00070748 File Offset: 0x0006E948
			internal bool #B7d(string #Rf)
			{
				return string.Equals(#Rf, this.#a, StringComparison.Ordinal);
			}

			// Token: 0x040038E0 RID: 14560
			public string #a;
		}
	}
}
