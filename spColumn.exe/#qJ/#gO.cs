using System;
using System.IO;
using System.Reflection;
using #5Z;
using #7hc;
using #c1d;
using #eU;
using Alphaleonis.Win32.Filesystem;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Units;

namespace #qJ
{
	// Token: 0x020002B5 RID: 693
	internal sealed class #gO : #yU
	{
		// Token: 0x0600180C RID: 6156 RVA: 0x00018886 File Offset: 0x00016A86
		public #gO(string #So)
		{
			if (string.IsNullOrWhiteSpace(#So))
			{
				#So = string.Empty;
			}
			this.#e = #So;
		}

		// Token: 0x0600180D RID: 6157 RVA: 0x000B5A38 File Offset: 0x000B3C38
		public Stream #aO(UnitSystem #Qg, DesignCodes #bO)
		{
			string path = this.#dO(#Qg, #bO);
			if (Alphaleonis.Win32.Filesystem.File.Exists(path))
			{
				return Alphaleonis.Win32.Filesystem.File.OpenRead(path);
			}
			string path2 = this.#dO(UnitSystem.USCustomary, DesignCodes.ACI19);
			if (!Alphaleonis.Win32.Filesystem.File.Exists(path2))
			{
				return null;
			}
			return Alphaleonis.Win32.Filesystem.File.OpenRead(path2);
		}

		// Token: 0x0600180E RID: 6158 RVA: 0x000188A4 File Offset: 0x00016AA4
		public string #cO(UnitSystem #Qg, DesignCodes #bO)
		{
			return this.#dO(#Qg, #bO);
		}

		// Token: 0x0600180F RID: 6159 RVA: 0x000B5A84 File Offset: 0x000B3C84
		private string #dO(UnitSystem #Qg, DesignCodes #bO)
		{
			string text = Alphaleonis.Win32.Filesystem.Path.Combine(new string[]
			{
				this.#e,
				#Phc.#3hc(107401750).#D2d(new object[]
				{
					this.#fO(#bO),
					this.#eO(#Qg),
					#b1d.CurrentExtension
				})
			});
			string[] array = new string[2];
			int num = 0;
			Assembly entryAssembly = Assembly.GetEntryAssembly();
			array[num] = Alphaleonis.Win32.Filesystem.Path.GetDirectoryName((entryAssembly != null) ? entryAssembly.Location : null);
			array[1] = text;
			return Alphaleonis.Win32.Filesystem.Path.Combine(array);
		}

		// Token: 0x06001810 RID: 6160 RVA: 0x000188BA File Offset: 0x00016ABA
		private string #eO(UnitSystem #Qg)
		{
			if (#Qg == UnitSystem.SIMetric)
			{
				return #Phc.#3hc(107402233);
			}
			return #Phc.#3hc(107402228);
		}

		// Token: 0x06001811 RID: 6161 RVA: 0x000B5B10 File Offset: 0x000B3D10
		private string #fO(DesignCodes #bO)
		{
			if (#k3.#g3(#bO))
			{
				return #Phc.#3hc(107402191) + #bO.ToString().Remove(0, 3);
			}
			return #Phc.#3hc(107402178) + #bO.ToString().Remove(0, 3);
		}

		// Token: 0x04000931 RID: 2353
		private const string #a = "US";

		// Token: 0x04000932 RID: 2354
		private const string #b = "SI";

		// Token: 0x04000933 RID: 2355
		private const string #c = "ACI 318-";

		// Token: 0x04000934 RID: 2356
		private const string #d = "CSA A23.3-";

		// Token: 0x04000935 RID: 2357
		private readonly string #e;
	}
}
