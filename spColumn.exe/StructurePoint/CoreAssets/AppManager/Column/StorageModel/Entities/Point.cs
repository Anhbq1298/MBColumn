using System;
using System.Diagnostics;
using System.Runtime.Serialization;
using #9pe;
using StructurePoint.CoreAssets.AppManager.Column.Storage.Legacy.Entities;

namespace StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities
{
	// Token: 0x02001144 RID: 4420
	[DataContract(Name = "P", Namespace = "http://structurepoint.org/schemas/xml/spSPL/Column_1_0_0/")]
	[DebuggerDisplay("x: {X}, y: {Y}")]
	public sealed class Point : #mqe
	{
		// Token: 0x0600954C RID: 38220 RVA: 0x000035C3 File Offset: 0x000017C3
		public Point()
		{
		}

		// Token: 0x0600954D RID: 38221 RVA: 0x00077100 File Offset: 0x00075300
		public Point(float x, float y)
		{
			this.X = x;
			this.Y = y;
		}

		// Token: 0x0600954E RID: 38222 RVA: 0x00077116 File Offset: 0x00075316
		public Point(double x, double y)
		{
			this.X = (float)x;
			this.Y = (float)y;
		}

		// Token: 0x0600954F RID: 38223 RVA: 0x0007712E File Offset: 0x0007532E
		internal Point(FPOINT item)
		{
			this.X = item.#a;
			this.Y = item.#b;
		}

		// Token: 0x06009550 RID: 38224 RVA: 0x0007714E File Offset: 0x0007534E
		public Point(Point other)
		{
			this.X = other.X;
			this.Y = other.Y;
		}

		// Token: 0x17002B21 RID: 11041
		// (get) Token: 0x06009551 RID: 38225 RVA: 0x0007716E File Offset: 0x0007536E
		// (set) Token: 0x06009552 RID: 38226 RVA: 0x00077176 File Offset: 0x00075376
		[DataMember(Name = "X", Order = 10)]
		public float X { get; set; }

		// Token: 0x17002B22 RID: 11042
		// (get) Token: 0x06009553 RID: 38227 RVA: 0x0007717F File Offset: 0x0007537F
		// (set) Token: 0x06009554 RID: 38228 RVA: 0x00077187 File Offset: 0x00075387
		[DataMember(Name = "Y", Order = 20)]
		public float Y { get; set; }

		// Token: 0x06009555 RID: 38229 RVA: 0x00077190 File Offset: 0x00075390
		public bool AreEqualExact(Point other)
		{
			return other != null && this.X == other.X && this.Y == other.Y;
		}
	}
}
