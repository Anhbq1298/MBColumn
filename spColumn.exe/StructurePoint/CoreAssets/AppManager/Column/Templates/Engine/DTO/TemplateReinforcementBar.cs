using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using #9pe;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;

namespace StructurePoint.CoreAssets.AppManager.Column.Templates.Engine.DTO
{
	// Token: 0x0200109D RID: 4253
	public sealed class TemplateReinforcementBar : #nqe, #mqe
	{
		// Token: 0x0600911E RID: 37150 RVA: 0x000035C3 File Offset: 0x000017C3
		public TemplateReinforcementBar()
		{
		}

		// Token: 0x0600911F RID: 37151 RVA: 0x00074F7D File Offset: 0x0007317D
		public TemplateReinforcementBar(TemplateReinforcementBar oldBar)
		{
			this.X = oldBar.X;
			this.Y = oldBar.Y;
			this.Z = oldBar.Z;
			this.Area = oldBar.Area;
		}

		// Token: 0x06009120 RID: 37152 RVA: 0x00074FB5 File Offset: 0x000731B5
		public TemplateReinforcementBar(float area, float x, float y, float z, Color color)
		{
			this.Area = area;
			this.X = x;
			this.Y = y;
			this.Z = z;
			this.Color = color;
		}

		// Token: 0x17002A31 RID: 10801
		// (get) Token: 0x06009121 RID: 37153 RVA: 0x00074FE2 File Offset: 0x000731E2
		// (set) Token: 0x06009122 RID: 37154 RVA: 0x00074FEA File Offset: 0x000731EA
		public float Area { get; set; }

		// Token: 0x17002A32 RID: 10802
		// (get) Token: 0x06009123 RID: 37155 RVA: 0x00074FF3 File Offset: 0x000731F3
		// (set) Token: 0x06009124 RID: 37156 RVA: 0x00074FFB File Offset: 0x000731FB
		public float X { get; set; }

		// Token: 0x17002A33 RID: 10803
		// (get) Token: 0x06009125 RID: 37157 RVA: 0x00075004 File Offset: 0x00073204
		// (set) Token: 0x06009126 RID: 37158 RVA: 0x0007500C File Offset: 0x0007320C
		public float Y { get; set; }

		// Token: 0x17002A34 RID: 10804
		// (get) Token: 0x06009127 RID: 37159 RVA: 0x00075015 File Offset: 0x00073215
		// (set) Token: 0x06009128 RID: 37160 RVA: 0x0007501D File Offset: 0x0007321D
		public float Z { get; set; }

		// Token: 0x17002A35 RID: 10805
		// (get) Token: 0x06009129 RID: 37161 RVA: 0x00075026 File Offset: 0x00073226
		public Color Color { get; }

		// Token: 0x0600912A RID: 37162 RVA: 0x0007502E File Offset: 0x0007322E
		public ReinforcementBar #CY()
		{
			return new ReinforcementBar(this.Area, this.X, this.Y, this.Z);
		}

		// Token: 0x04003CFF RID: 15615
		[CompilerGenerated]
		private float #a;

		// Token: 0x04003D00 RID: 15616
		[CompilerGenerated]
		private float #b;

		// Token: 0x04003D01 RID: 15617
		[CompilerGenerated]
		private float #c;

		// Token: 0x04003D02 RID: 15618
		[CompilerGenerated]
		private float #d;

		// Token: 0x04003D03 RID: 15619
		[CompilerGenerated]
		private readonly Color #e;
	}
}
