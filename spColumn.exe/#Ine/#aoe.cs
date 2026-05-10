using System;
using System.IO;
using System.Text;
using #7hc;
using StructurePoint.CoreAssets.AppManager.Column.Storage.Current.CTI;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;

namespace #Ine
{
	// Token: 0x020010FF RID: 4351
	internal sealed class #aoe
	{
		// Token: 0x060093A8 RID: 37800 RVA: 0x000762B9 File Offset: 0x000744B9
		public #aoe(ColumnStorageModel #Od)
		{
			this.#a = new CtiFormatSerialization(#Od);
		}

		// Token: 0x060093A9 RID: 37801 RVA: 0x001F7D50 File Offset: 0x001F5F50
		public void #npb(Stream #gp)
		{
			if (#gp == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107377314));
			}
			string s = this.#a.#y0d();
			byte[] bytes = Encoding.Default.GetBytes(s);
			#gp.Write(bytes, 0, bytes.Length);
		}

		// Token: 0x04003EE9 RID: 16105
		private readonly CtiFormatSerialization #a;
	}
}
