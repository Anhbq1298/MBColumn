using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using #coe;
using StructurePoint.CoreAssets.AppManager.Column.Storage.Core;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;

namespace #wje
{
	// Token: 0x020010BD RID: 4285
	internal sealed class #zke : ImportBase
	{
		// Token: 0x0600921A RID: 37402 RVA: 0x001F04CC File Offset: 0x001EE6CC
		public List<ReinforcementBar> #yke(Stream #gp)
		{
			if (#gp == null)
			{
				return null;
			}
			if (#gp.Length == 0L)
			{
				return new List<ReinforcementBar>();
			}
			this.#a = 0;
			#gp.Position = 0L;
			StreamReader #blc = new StreamReader(#gp);
			List<ReinforcementBar> list = new List<ReinforcementBar>();
			try
			{
				short num = this.#Fic(#blc);
				for (int i = 0; i < (int)num; i++)
				{
					string #ioe = base.#Vle(#blc);
					float[] array = base.#zuc(#ioe, 3).Select(new Func<string, float>(base.#d6d)).ToArray<float>();
					ReinforcementBar item = new ReinforcementBar(array[0], array[1], array[2], 0f);
					list.Add(item);
				}
			}
			catch (EndOfStreamException)
			{
				base.#ame(Strings.StringUnexpectedEndOfFile.#z2d());
			}
			return list;
		}

		// Token: 0x0600921B RID: 37403 RVA: 0x001F058C File Offset: 0x001EE78C
		private short #Fic(StreamReader #blc)
		{
			string #ioe = base.#Vle(#blc);
			short num = (short)base.#Gic(#ioe);
			if (num > 10000)
			{
				throw new #ooe(Strings.StringTheMaximumNumberOfReinforcingBarsIsExceeded.#D2d(new object[]
				{
					10000
				}).#z2d());
			}
			return num;
		}

		// Token: 0x04003D6F RID: 15727
		public new const int #a = 10000;
	}
}
