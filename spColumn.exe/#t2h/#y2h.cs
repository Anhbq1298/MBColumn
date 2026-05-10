using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using #01h;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.DataExchange.DXF.Legacy;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace #t2h
{
	// Token: 0x0200079C RID: 1948
	internal abstract class #y2h
	{
		// Token: 0x06003E7D RID: 15997 RVA: 0x00121554 File Offset: 0x0011F754
		private #y2h()
		{
			this.Layer = #Phc.#3hc(107399922);
			this.LineType = #Phc.#3hc(107399922);
			this.#w2h();
			this.X = 0.0;
			this.Y = 0.0;
			this.Z = 0.0;
		}

		// Token: 0x06003E7E RID: 15998 RVA: 0x00035482 File Offset: 0x00033682
		protected #y2h(List<#Z1h> #6h) : this()
		{
			#X0d.#V0d(#6h, #Phc.#3hc(107372654), Component.DataExchange, #Phc.#3hc(107372645));
			this.#v2h(#6h);
		}

		// Token: 0x06003E7F RID: 15999 RVA: 0x001215BC File Offset: 0x0011F7BC
		protected void #v2h(List<#Z1h> #6h)
		{
			if (true)
			{
				this.#w2h();
			}
			int num = 0;
			int i;
			if (true)
			{
				i = num;
			}
			while (i < #6h.Count)
			{
				#Z1h #Z1h = #6h[i];
				#Z1h #Z1h2;
				if (5 != 0)
				{
					#Z1h2 = #Z1h;
				}
				if (false)
				{
					goto IL_CE;
				}
				int num2 = #Z1h2.GroupCode;
				int num3;
				if (!false)
				{
					num3 = num2;
				}
				switch (num3)
				{
				case 6:
				{
					string text = #Z1h2.#W1h();
					if (!false)
					{
						this.LineType = text;
					}
					goto IL_137;
				}
				case 7:
				case 9:
					goto IL_137;
				case 8:
					if (8 != 0)
					{
						string text2 = #Z1h2.#W1h();
						if (4 != 0)
						{
							this.Layer = text2;
						}
						goto IL_137;
					}
					break;
				case 10:
					if (false)
					{
						goto IL_ED;
					}
					this.X = DxfHelper.#e2h(#Z1h2.#W1h());
					if (this.X < this.MinX)
					{
						this.MinX = this.X;
					}
					if (this.X > this.MaxX)
					{
						goto IL_CE;
					}
					goto IL_137;
				default:
					if (num3 == 20)
					{
						this.Y = DxfHelper.#e2h(#Z1h2.#W1h());
						goto IL_ED;
					}
					break;
				}
				if (num3 != 30)
				{
					goto IL_137;
				}
				this.Z = DxfHelper.#e2h(#Z1h2.#W1h());
				goto IL_137;
				IL_ED:
				double num4 = this.Y;
				double num5 = this.MinY;
				double num6;
				double num7;
				do
				{
					if (num4 < num5)
					{
						this.MinY = this.Y;
					}
					num6 = (num4 = this.Y);
					num7 = (num5 = this.MaxY);
				}
				while (false);
				if (num6 > num7)
				{
					this.MaxY = this.Y;
				}
				IL_137:
				i++;
				continue;
				IL_CE:
				this.MaxX = this.X;
				goto IL_137;
			}
		}

		// Token: 0x06003E80 RID: 16000 RVA: 0x00121740 File Offset: 0x0011F940
		protected void #w2h()
		{
			if (8 != 0 && 5 != 0)
			{
				double minValue = double.MinValue;
				if (-1 != 0)
				{
					this.MinX = minValue;
				}
				double maxValue = double.MaxValue;
				if (2 != 0)
				{
					this.MaxX = maxValue;
				}
				if (2 != 0)
				{
					double minValue2 = double.MinValue;
					if (-1 != 0)
					{
						this.MinY = minValue2;
					}
				}
				double maxValue2 = double.MaxValue;
				if (4 != 0)
				{
					this.MaxY = maxValue2;
				}
			}
		}

		// Token: 0x06003E81 RID: 16001 RVA: 0x001217B0 File Offset: 0x0011F9B0
		protected void #x2h(double #9o, double #7W)
		{
			if (#9o < this.MinX && !false)
			{
				this.MinX = #9o;
			}
			for (;;)
			{
				double num = #9o;
				if (8 != 0)
				{
					if (#9o > this.MaxX && -1 != 0)
					{
						this.MaxX = #9o;
					}
					if (#7W < this.MinY)
					{
						goto IL_2C;
					}
					goto IL_33;
				}
				IL_34:
				if (num > this.MaxY)
				{
					if (false)
					{
						continue;
					}
					if (!false)
					{
						this.MaxY = #7W;
					}
				}
				if (!false)
				{
					break;
				}
				goto IL_2C;
				IL_33:
				num = #7W;
				goto IL_34;
				IL_2C:
				if (false)
				{
					goto IL_33;
				}
				this.MinY = #7W;
				goto IL_33;
			}
		}

		// Token: 0x170012F0 RID: 4848
		// (get) Token: 0x06003E82 RID: 16002 RVA: 0x000354AD File Offset: 0x000336AD
		// (set) Token: 0x06003E83 RID: 16003 RVA: 0x000354B5 File Offset: 0x000336B5
		public string Layer { get; set; }

		// Token: 0x170012F1 RID: 4849
		// (get) Token: 0x06003E84 RID: 16004 RVA: 0x000354BE File Offset: 0x000336BE
		// (set) Token: 0x06003E85 RID: 16005 RVA: 0x000354C6 File Offset: 0x000336C6
		public string LineType { get; set; }

		// Token: 0x170012F2 RID: 4850
		// (get) Token: 0x06003E86 RID: 16006 RVA: 0x000354CF File Offset: 0x000336CF
		// (set) Token: 0x06003E87 RID: 16007 RVA: 0x000354D7 File Offset: 0x000336D7
		public double X { get; set; }

		// Token: 0x170012F3 RID: 4851
		// (get) Token: 0x06003E88 RID: 16008 RVA: 0x000354E0 File Offset: 0x000336E0
		// (set) Token: 0x06003E89 RID: 16009 RVA: 0x000354E8 File Offset: 0x000336E8
		public double Y { get; set; }

		// Token: 0x170012F4 RID: 4852
		// (get) Token: 0x06003E8A RID: 16010 RVA: 0x000354F1 File Offset: 0x000336F1
		// (set) Token: 0x06003E8B RID: 16011 RVA: 0x000354F9 File Offset: 0x000336F9
		public double Z { get; set; }

		// Token: 0x170012F5 RID: 4853
		// (get) Token: 0x06003E8C RID: 16012 RVA: 0x00035502 File Offset: 0x00033702
		// (set) Token: 0x06003E8D RID: 16013 RVA: 0x0003550A File Offset: 0x0003370A
		public double MinX { get; set; }

		// Token: 0x170012F6 RID: 4854
		// (get) Token: 0x06003E8E RID: 16014 RVA: 0x00035513 File Offset: 0x00033713
		// (set) Token: 0x06003E8F RID: 16015 RVA: 0x0003551B File Offset: 0x0003371B
		public double MaxX { get; set; }

		// Token: 0x170012F7 RID: 4855
		// (get) Token: 0x06003E90 RID: 16016 RVA: 0x00035524 File Offset: 0x00033724
		// (set) Token: 0x06003E91 RID: 16017 RVA: 0x0003552C File Offset: 0x0003372C
		public double MinY { get; set; }

		// Token: 0x170012F8 RID: 4856
		// (get) Token: 0x06003E92 RID: 16018 RVA: 0x00035535 File Offset: 0x00033735
		// (set) Token: 0x06003E93 RID: 16019 RVA: 0x0003553D File Offset: 0x0003373D
		public double MaxY { get; set; }

		// Token: 0x04001C7C RID: 7292
		[CompilerGenerated]
		private string #a;

		// Token: 0x04001C7D RID: 7293
		[CompilerGenerated]
		private string #b;

		// Token: 0x04001C7E RID: 7294
		[CompilerGenerated]
		private double #c;

		// Token: 0x04001C7F RID: 7295
		[CompilerGenerated]
		private double #d;

		// Token: 0x04001C80 RID: 7296
		[CompilerGenerated]
		private double #e;

		// Token: 0x04001C81 RID: 7297
		[CompilerGenerated]
		private double #f;

		// Token: 0x04001C82 RID: 7298
		[CompilerGenerated]
		private double #g;

		// Token: 0x04001C83 RID: 7299
		[CompilerGenerated]
		private double #h;

		// Token: 0x04001C84 RID: 7300
		[CompilerGenerated]
		private double #i;
	}
}
