using System;
using System.Runtime.Serialization;
using #9pe;
using StructurePoint.CoreAssets.AppManager.Column.Storage.Legacy.Entities;

namespace StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities
{
	// Token: 0x0200114D RID: 4429
	[DataContract(Name = "SlendernessOfColumn", Namespace = "http://structurepoint.org/schemas/xml/spSPL/Column_1_0_0/")]
	public sealed class SlendernessOfColumn : #rqe
	{
		// Token: 0x060095B4 RID: 38324 RVA: 0x001FAE08 File Offset: 0x001F9008
		internal SlendernessOfColumn(SLDABVBLWCOL item)
		{
			this.Height = item.#b;
			this.Ec = item.#e;
			this.Fcp = item.#d;
			this.Width = item.#c[0];
			this.Depth = item.#c[1];
			this.SetSlendernessColumnType(item.#a);
		}

		// Token: 0x060095B5 RID: 38325 RVA: 0x000775F5 File Offset: 0x000757F5
		public SlendernessOfColumn(SlendernessColumnType type, float height, float width, float depth, float fcp, float ec)
		{
			this.Height = height;
			this.Width = width;
			this.Depth = depth;
			this.Fcp = fcp;
			this.Ec = ec;
			this.SlendernessColumnType = type;
		}

		// Token: 0x060095B6 RID: 38326 RVA: 0x0007762A File Offset: 0x0007582A
		public SlendernessOfColumn(short nocol, float height, float width, float depth, float fcp, float ec)
		{
			this.Height = height;
			this.Width = width;
			this.Depth = depth;
			this.Fcp = fcp;
			this.Ec = ec;
			this.SetSlendernessColumnType(nocol);
		}

		// Token: 0x060095B7 RID: 38327 RVA: 0x000035C3 File Offset: 0x000017C3
		public SlendernessOfColumn()
		{
		}

		// Token: 0x17002B46 RID: 11078
		// (get) Token: 0x060095B8 RID: 38328 RVA: 0x0007765F File Offset: 0x0007585F
		// (set) Token: 0x060095B9 RID: 38329 RVA: 0x00077667 File Offset: 0x00075867
		[DataMember(Name = "IsNoColumnPresent", Order = 10)]
		[Obsolete]
		public bool IsNoColumnPresent { get; set; }

		// Token: 0x17002B47 RID: 11079
		// (get) Token: 0x060095BA RID: 38330 RVA: 0x00077670 File Offset: 0x00075870
		// (set) Token: 0x060095BB RID: 38331 RVA: 0x00077678 File Offset: 0x00075878
		[DataMember(Name = "Height", Order = 20)]
		public float Height { get; set; }

		// Token: 0x17002B48 RID: 11080
		// (get) Token: 0x060095BC RID: 38332 RVA: 0x00077681 File Offset: 0x00075881
		// (set) Token: 0x060095BD RID: 38333 RVA: 0x00077689 File Offset: 0x00075889
		[DataMember(Name = "Width", Order = 30)]
		public float Width { get; set; }

		// Token: 0x17002B49 RID: 11081
		// (get) Token: 0x060095BE RID: 38334 RVA: 0x00077692 File Offset: 0x00075892
		// (set) Token: 0x060095BF RID: 38335 RVA: 0x0007769A File Offset: 0x0007589A
		[DataMember(Name = "Depth", Order = 40)]
		public float Depth { get; set; }

		// Token: 0x17002B4A RID: 11082
		// (get) Token: 0x060095C0 RID: 38336 RVA: 0x000776A3 File Offset: 0x000758A3
		// (set) Token: 0x060095C1 RID: 38337 RVA: 0x000776AB File Offset: 0x000758AB
		[DataMember(Name = "Fcp", Order = 50)]
		public float Fcp { get; set; }

		// Token: 0x17002B4B RID: 11083
		// (get) Token: 0x060095C2 RID: 38338 RVA: 0x000776B4 File Offset: 0x000758B4
		// (set) Token: 0x060095C3 RID: 38339 RVA: 0x000776BC File Offset: 0x000758BC
		[DataMember(Name = "Ec", Order = 60)]
		public float Ec { get; set; }

		// Token: 0x17002B4C RID: 11084
		// (get) Token: 0x060095C4 RID: 38340 RVA: 0x000776C5 File Offset: 0x000758C5
		// (set) Token: 0x060095C5 RID: 38341 RVA: 0x000776CD File Offset: 0x000758CD
		[DataMember(Name = "SlendernessColumnType", Order = 70)]
		public SlendernessColumnType SlendernessColumnType { get; set; }

		// Token: 0x17002B4D RID: 11085
		// (get) Token: 0x060095C6 RID: 38342 RVA: 0x000776D6 File Offset: 0x000758D6
		// (set) Token: 0x060095C7 RID: 38343 RVA: 0x000776DE File Offset: 0x000758DE
		[DataMember(Name = "IsConcreteStandard", Order = 80)]
		public bool IsConcreteStandard { get; set; }

		// Token: 0x060095C8 RID: 38344 RVA: 0x001FAE68 File Offset: 0x001F9068
		public void SetSlendernessColumnType(short nocol)
		{
			if (this.Width > 0f && this.Depth > 0f)
			{
				this.SlendernessColumnType = SlendernessColumnType.Rectangular;
			}
			else if (this.Width > 0f)
			{
				float depth = this.Depth;
				this.Depth = this.Width;
				this.Width = depth;
				this.SlendernessColumnType = SlendernessColumnType.Circular;
			}
			else
			{
				this.SlendernessColumnType = SlendernessColumnType.DesignCol;
			}
			if (nocol == 1)
			{
				this.SlendernessColumnType = SlendernessColumnType.None;
			}
		}
	}
}
