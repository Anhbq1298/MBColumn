using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using #7hc;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;

namespace StructurePoint.CoreAssets.AppManager.Column.Storage.Current
{
	// Token: 0x020010DC RID: 4316
	internal sealed class SectionExporter
	{
		// Token: 0x060092B7 RID: 37559 RVA: 0x00075C15 File Offset: 0x00073E15
		public void #xRb(Stream #gp, ColumnStorageModel #Od)
		{
			new StreamWriter(#gp).AutoFlush = true;
			this.#Mme(#gp, #Od.Polygons);
			this.#Nme(#gp, #Od.ReinforcementBars);
			#gp.Seek(0L, SeekOrigin.Begin);
		}

		// Token: 0x060092B8 RID: 37560 RVA: 0x001F2574 File Offset: 0x001F0774
		public void #Mme(Stream #gp, List<SectionPolygon> #yP)
		{
			StreamWriter streamWriter = new StreamWriter(#gp);
			streamWriter.AutoFlush = true;
			streamWriter.WriteLine(#Phc.#3hc(107290072));
			List<SectionPolygon> #yP2 = #yP.Where(new Func<SectionPolygon, bool>(SectionExporter.<>c.<>9.#2af)).ToList<SectionPolygon>();
			this.#Ome(streamWriter, #yP2);
			streamWriter.WriteLine(#Phc.#3hc(107290031));
			List<SectionPolygon> #yP3 = #yP.Where(new Func<SectionPolygon, bool>(SectionExporter.<>c.<>9.#3af)).ToList<SectionPolygon>();
			this.#Ome(streamWriter, #yP3);
		}

		// Token: 0x060092B9 RID: 37561 RVA: 0x001F2618 File Offset: 0x001F0818
		public void #Nme(Stream #gp, List<ReinforcementBar> #KJ)
		{
			StreamWriter streamWriter = new StreamWriter(#gp);
			streamWriter.AutoFlush = true;
			streamWriter.WriteLine(#Phc.#3hc(107290018));
			this.#Pme(streamWriter, #KJ);
		}

		// Token: 0x060092BA RID: 37562 RVA: 0x001F264C File Offset: 0x001F084C
		private void #Ome(StreamWriter #Ipb, List<SectionPolygon> #yP)
		{
			#Ipb.WriteLine(#yP.Count);
			foreach (SectionPolygon sectionPolygon in #yP)
			{
				#Ipb.WriteLine(sectionPolygon.Points.Count);
				foreach (Point point in sectionPolygon.Points)
				{
					#Ipb.WriteLine(this.#Qme(point.X) + #Phc.#3hc(107399922) + this.#Qme(point.Y));
				}
			}
		}

		// Token: 0x060092BB RID: 37563 RVA: 0x001F271C File Offset: 0x001F091C
		private void #Pme(StreamWriter #Ipb, List<ReinforcementBar> #KJ)
		{
			#Ipb.WriteLine(#KJ.Count);
			foreach (ReinforcementBar reinforcementBar in #KJ)
			{
				#Ipb.WriteLine(string.Concat(new string[]
				{
					this.#Qme(reinforcementBar.Area),
					#Phc.#3hc(107399922),
					this.#Qme(reinforcementBar.X),
					#Phc.#3hc(107399922),
					this.#Qme(reinforcementBar.Y)
				}));
			}
		}

		// Token: 0x060092BC RID: 37564 RVA: 0x00075C47 File Offset: 0x00073E47
		private string #Qme(float #FI)
		{
			return #FI.ToString(#Phc.#3hc(107289997), CultureInfo.InvariantCulture);
		}

		// Token: 0x04003E65 RID: 15973
		private const string #a = " ";
	}
}
