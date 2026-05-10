using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Management;
using System.Runtime.CompilerServices;
using #7hc;
using #ezc;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Resources;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Logger;

namespace #hId
{
	// Token: 0x02000DA7 RID: 3495
	internal static class #OId
	{
		// Token: 0x06007E52 RID: 32338 RVA: 0x001BC3D0 File Offset: 0x001BA5D0
		public static #GId #HId(string #wy)
		{
			#OId.#GTb #GTb = new #OId.#GTb();
			#GTb.#b = #wy;
			#GTb.#a = false;
			Ignore.#14d<Exception>(new Action(#GTb.#jVd), null);
			if (!#GTb.#a)
			{
				return #GId.#d;
			}
			#GTb.#c = false;
			Ignore.#14d<Exception>(new Action(#GTb.#mVd), null);
			if (!#GTb.#c)
			{
				return #GId.#b;
			}
			if (!Ignore.#14d<Exception>(new Action(#GTb.#nVd), null))
			{
				return #GId.#c;
			}
			return #GId.#a;
		}

		// Token: 0x06007E53 RID: 32339 RVA: 0x001BC460 File Offset: 0x001BA660
		public static IReadOnlyList<string> #IId()
		{
			List<string> list = new List<string>();
			try
			{
				list.AddRange(PrinterSettings.InstalledPrinters.OfType<string>());
			}
			catch
			{
			}
			return list;
		}

		// Token: 0x06007E54 RID: 32340 RVA: 0x001BC4A8 File Offset: 0x001BA6A8
		public static string #JId(#GId #KId)
		{
			switch (#KId)
			{
			case #GId.#a:
				return Localization.StringReady;
			case #GId.#b:
				return Localization.StringOffline;
			case #GId.#c:
				return Localization.StringError;
			case #GId.#d:
				return Localization.StringUnknownPrinter;
			default:
				throw new ArgumentOutOfRangeException(#Phc.#3hc(107281280), #KId, null);
			}
		}

		// Token: 0x06007E55 RID: 32341 RVA: 0x001BC508 File Offset: 0x001BA708
		public static string #LId()
		{
			ManagementObjectCollection.ManagementObjectEnumerator managementObjectEnumerator = \u0012\u0005.~\u0001\u000F(\u0011\u0005.~\u009F\u000E(new ManagementObjectSearcher(new ObjectQuery(#Phc.#3hc(107281303)))));
			try
			{
				while (\u0010\u0002.~\u001C\u0004(managementObjectEnumerator))
				{
					ManagementBaseObject managementBaseObject = \u0013\u0005.~\u0002\u000F(managementObjectEnumerator);
					if (((bool?)\u0014\u0005.~\u0003\u000F(managementBaseObject, #Phc.#3hc(107281266))).GetValueOrDefault())
					{
						return \u0014\u0005.~\u0003\u000F(managementBaseObject, #Phc.#3hc(107409209)) as string;
					}
				}
			}
			finally
			{
				if (managementObjectEnumerator != null)
				{
					\u0007.~\u000E(managementObjectEnumerator);
				}
			}
			return null;
		}

		// Token: 0x06007E56 RID: 32342 RVA: 0x001BC5DC File Offset: 0x001BA7DC
		private static void #MId(string #NId)
		{
			PrinterSettings printerSettings = new PrinterSettings();
			printerSettings.PrinterName = #NId;
			if (!printerSettings.PaperSizes.OfType<PaperSize>().Any<PaperSize>())
			{
				throw new Exception(#Phc.#3hc(107281221).#z2d());
			}
			PageSettings defaultPageSettings = printerSettings.DefaultPageSettings;
			if (defaultPageSettings == null)
			{
				throw new Exception(#Phc.#3hc(107281188).#z2d());
			}
			if (defaultPageSettings.PaperSize == null)
			{
				throw new Exception(#Phc.#3hc(107281171).#z2d());
			}
		}

		// Token: 0x02000DA8 RID: 3496
		[CompilerGenerated]
		private sealed class #GTb
		{
			// Token: 0x06007E58 RID: 32344 RVA: 0x001BC664 File Offset: 0x001BA864
			internal void #jVd()
			{
				IEnumerable<string> source = #OId.#IId();
				Func<string, bool> predicate;
				if ((predicate = this.#d) == null)
				{
					predicate = (this.#d = new Func<string, bool>(this.#kVd));
				}
				this.#a = source.Any(predicate);
			}

			// Token: 0x06007E59 RID: 32345 RVA: 0x00066E66 File Offset: 0x00065066
			internal bool #kVd(string #lVd)
			{
				return \u0093.\u0017\u0003(#lVd, this.#b);
			}

			// Token: 0x06007E5A RID: 32346 RVA: 0x00066E85 File Offset: 0x00065085
			internal void #mVd()
			{
				this.#c = #0zc.#Lzc(this.#b);
			}

			// Token: 0x06007E5B RID: 32347 RVA: 0x00066EA4 File Offset: 0x000650A4
			internal void #nVd()
			{
				#OId.#MId(this.#b);
			}

			// Token: 0x040033C5 RID: 13253
			public bool #a;

			// Token: 0x040033C6 RID: 13254
			public string #b;

			// Token: 0x040033C7 RID: 13255
			public bool #c;

			// Token: 0x040033C8 RID: 13256
			public Func<string, bool> #d;
		}
	}
}
