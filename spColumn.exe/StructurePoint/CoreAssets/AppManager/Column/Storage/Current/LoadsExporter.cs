using System;
using System.IO;
using System.Linq;
using #7hc;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;

namespace StructurePoint.CoreAssets.AppManager.Column.Storage.Current
{
	// Token: 0x020010E2 RID: 4322
	public sealed class LoadsExporter
	{
		// Token: 0x060092E3 RID: 37603 RVA: 0x00075D89 File Offset: 0x00073F89
		public LoadsExporter(ColumnStorageModel model, LoadType loadType, Stream stream)
		{
			this.#a = model;
			this.#b = loadType;
			this.#c = stream;
		}

		// Token: 0x060092E4 RID: 37604 RVA: 0x001F2FE0 File Offset: 0x001F11E0
		public void #xRb()
		{
			switch (this.#b)
			{
			case LoadType.Undefined:
			case LoadType.Axial:
			case LoadType.NoLoads:
				return;
			case LoadType.Factored:
				this.#5me();
				return;
			case LoadType.Service:
				this.#3me();
				return;
			}
			throw new ArgumentOutOfRangeException(#Phc.#3hc(107289954), this.#b, null);
		}

		// Token: 0x060092E5 RID: 37605 RVA: 0x001F3040 File Offset: 0x001F1240
		private void #3me()
		{
			StreamWriter streamWriter = new StreamWriter(this.#c);
			streamWriter.AutoFlush = true;
			streamWriter.WriteLine(#Phc.#3hc(107290003));
			streamWriter.WriteLine(this.#a.ServiceLoads.Count);
			foreach (ServiceLoad serviceLoad in this.#a.ServiceLoads)
			{
				streamWriter.WriteLine(this.#4me(serviceLoad.Dead));
				streamWriter.WriteLine(this.#4me(serviceLoad.Live));
				streamWriter.WriteLine(this.#4me(serviceLoad.Wind));
				streamWriter.WriteLine(this.#4me(serviceLoad.Earthquake));
				streamWriter.WriteLine(this.#4me(serviceLoad.Snow));
			}
			this.#c.Seek(0L, SeekOrigin.Begin);
		}

		// Token: 0x060092E6 RID: 37606 RVA: 0x001F3134 File Offset: 0x001F1334
		private string #4me(ServiceLoadCaseData #Gfb)
		{
			float[] array = new float[5];
			#Gfb.ToArray(array, 0);
			return string.Join(#Phc.#3hc(107399922), this.#6me(array));
		}

		// Token: 0x060092E7 RID: 37607 RVA: 0x001F3168 File Offset: 0x001F1368
		private void #5me()
		{
			StreamWriter streamWriter = new StreamWriter(this.#c);
			streamWriter.AutoFlush = true;
			streamWriter.WriteLine(#Phc.#3hc(107289992));
			streamWriter.WriteLine(this.#a.FactoredLoads.Count);
			foreach (FactoredLoad factoredLoad in this.#a.FactoredLoads)
			{
				float[] #7me = new float[]
				{
					factoredLoad.AxialLoad,
					factoredLoad.MomentX,
					factoredLoad.MomentY
				};
				string value = string.Join(#Phc.#3hc(107399922), this.#6me(#7me));
				streamWriter.WriteLine(value);
			}
			this.#c.Seek(0L, SeekOrigin.Begin);
		}

		// Token: 0x060092E8 RID: 37608 RVA: 0x00075DA6 File Offset: 0x00073FA6
		private string[] #6me(float[] #7me)
		{
			return #7me.Select(new Func<float, string>(LoadsExporter.<>c.<>9.#4af)).ToArray<string>();
		}

		// Token: 0x04003E6F RID: 15983
		private readonly ColumnStorageModel #a;

		// Token: 0x04003E70 RID: 15984
		private readonly LoadType #b;

		// Token: 0x04003E71 RID: 15985
		private readonly Stream #c;
	}
}
