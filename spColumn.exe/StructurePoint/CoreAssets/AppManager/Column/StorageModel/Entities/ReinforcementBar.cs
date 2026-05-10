using System;
using System.Diagnostics;
using System.Runtime.Serialization;
using #9pe;
using StructurePoint.CoreAssets.AppManager.Column.Storage.Legacy.Entities;

namespace StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities
{
	// Token: 0x02001148 RID: 4424
	[DebuggerDisplay("X={X}, Y={Y}, Z={Z}")]
	[DataContract(Name = "ReinforcementBar", Namespace = "http://structurepoint.org/schemas/xml/spSPL/Column_1_0_0/")]
	public sealed class ReinforcementBar : #nqe, #mqe
	{
		// Token: 0x06009575 RID: 38261 RVA: 0x000035C3 File Offset: 0x000017C3
		public ReinforcementBar()
		{
		}

		// Token: 0x06009576 RID: 38262 RVA: 0x000772FE File Offset: 0x000754FE
		public ReinforcementBar(ReinforcementBar oldBar)
		{
			this.X = oldBar.X;
			this.Y = oldBar.Y;
			this.Z = oldBar.Z;
			this.Area = oldBar.Area;
		}

		// Token: 0x06009577 RID: 38263 RVA: 0x00077336 File Offset: 0x00075536
		public ReinforcementBar(float area, float x, float y, float z)
		{
			this.Area = area;
			this.X = x;
			this.Y = y;
			this.Z = z;
		}

		// Token: 0x06009578 RID: 38264 RVA: 0x0007735B File Offset: 0x0007555B
		internal ReinforcementBar(IRREG item) : this(item.#a, item.#b, item.#c, item.#d)
		{
		}

		// Token: 0x17002B2F RID: 11055
		// (get) Token: 0x06009579 RID: 38265 RVA: 0x0007737B File Offset: 0x0007557B
		// (set) Token: 0x0600957A RID: 38266 RVA: 0x00077383 File Offset: 0x00075583
		[DataMember(Name = "Area", Order = 10)]
		public float Area { get; set; }

		// Token: 0x17002B30 RID: 11056
		// (get) Token: 0x0600957B RID: 38267 RVA: 0x0007738C File Offset: 0x0007558C
		// (set) Token: 0x0600957C RID: 38268 RVA: 0x00077394 File Offset: 0x00075594
		[DataMember(Name = "X", Order = 20)]
		public float X { get; set; }

		// Token: 0x17002B31 RID: 11057
		// (get) Token: 0x0600957D RID: 38269 RVA: 0x0007739D File Offset: 0x0007559D
		// (set) Token: 0x0600957E RID: 38270 RVA: 0x000773A5 File Offset: 0x000755A5
		[DataMember(Name = "Y", Order = 30)]
		public float Y { get; set; }

		// Token: 0x17002B32 RID: 11058
		// (get) Token: 0x0600957F RID: 38271 RVA: 0x000773AE File Offset: 0x000755AE
		// (set) Token: 0x06009580 RID: 38272 RVA: 0x000773B6 File Offset: 0x000755B6
		[DataMember(Name = "Z", Order = 40)]
		public float Z { get; set; }
	}
}
