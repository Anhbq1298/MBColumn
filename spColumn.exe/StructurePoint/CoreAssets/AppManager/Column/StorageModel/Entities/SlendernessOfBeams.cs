using System;
using System.Runtime.Serialization;
using StructurePoint.CoreAssets.AppManager.Column.Storage.Legacy.Entities;

namespace StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities
{
	// Token: 0x02001019 RID: 4121
	[DataContract(Name = "SlendernessOfBeams", Namespace = "http://structurepoint.org/schemas/xml/spSPL/Column_1_0_0/")]
	public sealed class SlendernessOfBeams
	{
		// Token: 0x06008DCE RID: 36302 RVA: 0x001E32F8 File Offset: 0x001E14F8
		internal SlendernessOfBeams(SLDBEAM item)
		{
			this.AboveLeft = new Beam(item.#a);
			this.AboveRight = new Beam(item.#b);
			this.BelowLeft = new Beam(item.#c);
			this.BelowRight = new Beam(item.#d);
		}

		// Token: 0x06008DCF RID: 36303 RVA: 0x0007301B File Offset: 0x0007121B
		public SlendernessOfBeams()
		{
			this.AboveLeft = new Beam();
			this.AboveRight = new Beam();
			this.BelowLeft = new Beam();
			this.BelowRight = new Beam();
		}

		// Token: 0x17002943 RID: 10563
		// (get) Token: 0x06008DD0 RID: 36304 RVA: 0x0007304F File Offset: 0x0007124F
		// (set) Token: 0x06008DD1 RID: 36305 RVA: 0x00073057 File Offset: 0x00071257
		[DataMember(Name = "AboveLeft", Order = 10)]
		public Beam AboveLeft { get; set; }

		// Token: 0x17002944 RID: 10564
		// (get) Token: 0x06008DD2 RID: 36306 RVA: 0x00073060 File Offset: 0x00071260
		// (set) Token: 0x06008DD3 RID: 36307 RVA: 0x00073068 File Offset: 0x00071268
		[DataMember(Name = "AboveRight", Order = 20)]
		public Beam AboveRight { get; set; }

		// Token: 0x17002945 RID: 10565
		// (get) Token: 0x06008DD4 RID: 36308 RVA: 0x00073071 File Offset: 0x00071271
		// (set) Token: 0x06008DD5 RID: 36309 RVA: 0x00073079 File Offset: 0x00071279
		[DataMember(Name = "BelowLeft", Order = 30)]
		public Beam BelowLeft { get; set; }

		// Token: 0x17002946 RID: 10566
		// (get) Token: 0x06008DD6 RID: 36310 RVA: 0x00073082 File Offset: 0x00071282
		// (set) Token: 0x06008DD7 RID: 36311 RVA: 0x0007308A File Offset: 0x0007128A
		[DataMember(Name = "BelowRight", Order = 40)]
		public Beam BelowRight { get; set; }
	}
}
