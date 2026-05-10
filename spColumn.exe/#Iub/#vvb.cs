using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media;
using #7hc;
using #rCe;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Diagrams;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace #Iub
{
	// Token: 0x0200048F RID: 1167
	internal sealed class #vvb
	{
		// Token: 0x06002B62 RID: 11106 RVA: 0x000E9A30 File Offset: 0x000E7C30
		public #vvb()
		{
			this.FontSize = 20.0;
			this.#f = new #Bvb(new FontFamily(#Phc.#3hc(107356910)), 20.0);
		}

		// Token: 0x17000EA4 RID: 3748
		// (get) Token: 0x06002B63 RID: 11107 RVA: 0x000272E0 File Offset: 0x000254E0
		// (set) Token: 0x06002B64 RID: 11108 RVA: 0x000272EC File Offset: 0x000254EC
		public #zDe Data { get; set; }

		// Token: 0x17000EA5 RID: 3749
		// (get) Token: 0x06002B65 RID: 11109 RVA: 0x000272FD File Offset: 0x000254FD
		public #Bvb Calculator { get; }

		// Token: 0x17000EA6 RID: 3750
		// (get) Token: 0x06002B66 RID: 11110 RVA: 0x00027309 File Offset: 0x00025509
		// (set) Token: 0x06002B67 RID: 11111 RVA: 0x00027315 File Offset: 0x00025515
		public double FontSize { get; set; }

		// Token: 0x17000EA7 RID: 3751
		// (get) Token: 0x06002B68 RID: 11112 RVA: 0x00027326 File Offset: 0x00025526
		// (set) Token: 0x06002B69 RID: 11113 RVA: 0x00027332 File Offset: 0x00025532
		public double OriginalFontSize { get; set; }

		// Token: 0x06002B6A RID: 11114 RVA: 0x00027343 File Offset: 0x00025543
		public void #yl()
		{
			this.#b.Clear();
		}

		// Token: 0x06002B6B RID: 11115 RVA: 0x000E9AA0 File Offset: 0x000E7CA0
		public #Hub #gvb(string #hvb, double #cpb, double #ivb, SvgLabelPosition #0bb, double #jvb, LabelType #kvb, bool #lvb)
		{
			#Hub #Hub = new #Hub();
			System.Windows.Size size = this.Calculator.#zvb(#hvb, this.FontSize);
			this.#c = this.OriginalFontSize * 2.0 / 3.0;
			double num = this.#svb(#cpb, #0bb, #jvb, size, #kvb);
			double num2 = this.#tvb(#ivb, #0bb, #jvb, size, #kvb);
			System.Windows.Rect rect = new System.Windows.Rect(new System.Windows.Point(num, num2), size);
			this.#mvb(ref rect, #jvb);
			#Hub.Visibility = this.#ovb(rect, num, num2, size, #kvb, #lvb);
			if (#Hub.Visibility == Visibility.Visible)
			{
				this.#b.Add(rect);
			}
			#Hub.Position = new StructurePoint.CoreAssets.Infrastructure.Data.Point(num, num2);
			return #Hub;
		}

		// Token: 0x06002B6C RID: 11116 RVA: 0x000E9B74 File Offset: 0x000E7D74
		private void #mvb(ref System.Windows.Rect #nvb, double #jvb)
		{
			double num2;
			double num = num2 = 4.0 / #jvb;
			#nvb.Location = new System.Windows.Point(#nvb.Location.X - num2, #nvb.Location.Y - num);
			#nvb.Width += num2 * 2.0;
			#nvb.Height += num * 2.0;
		}

		// Token: 0x06002B6D RID: 11117 RVA: 0x000E9BF8 File Offset: 0x000E7DF8
		private Visibility #ovb(System.Windows.Rect #nvb, double #pvb, double #qvb, System.Windows.Size #mT, LabelType #kvb, bool #rvb)
		{
			#vvb.#CTb #CTb = new #vvb.#CTb();
			#CTb.#a = #nvb;
			bool flag = this.#b.Any(new Func<System.Windows.Rect, bool>(#CTb.#N7b));
			bool flag2 = #rvb && this.#uvb(#pvb, #qvb, #mT);
			if (#kvb != LabelType.LoadPoint && #kvb != LabelType.SpliceLine && (flag || flag2))
			{
				return Visibility.Hidden;
			}
			return Visibility.Visible;
		}

		// Token: 0x06002B6E RID: 11118 RVA: 0x000E9C5C File Offset: 0x000E7E5C
		private double #svb(double #cpb, SvgLabelPosition #0bb, double #jvb, System.Windows.Size #mT, LabelType #kvb)
		{
			switch (#0bb)
			{
			case SvgLabelPosition.Top:
			case SvgLabelPosition.Bottom:
				return #cpb - #mT.Width / 2.0;
			case SvgLabelPosition.Left:
			case SvgLabelPosition.TopLeft:
			case SvgLabelPosition.BotLeft:
				return #cpb - #mT.Width - this.#c / #jvb;
			case SvgLabelPosition.Right:
			case SvgLabelPosition.TopRight:
			case SvgLabelPosition.BotRight:
				if (#kvb == LabelType.LoadPoint)
				{
					return #cpb + this.#d * 3.0 / #jvb;
				}
				return #cpb + this.#c / #jvb;
			case SvgLabelPosition.FarLeft:
				return #cpb - #mT.Width * 2.0 - this.#c / #jvb;
			case SvgLabelPosition.FarRight:
				return #cpb + #mT.Width + this.#c / #jvb;
			case SvgLabelPosition.BotRightAligned:
			case SvgLabelPosition.TopRightAligned:
			case SvgLabelPosition.BotAlignedRightAligned:
			case SvgLabelPosition.TopAlignedRightAligned:
				return #cpb;
			}
			return #cpb - #mT.Width;
		}

		// Token: 0x06002B6F RID: 11119 RVA: 0x000E9D5C File Offset: 0x000E7F5C
		private double #tvb(double #ivb, SvgLabelPosition #0bb, double #jvb, System.Windows.Size #mT, LabelType #kvb)
		{
			if (#0bb == SvgLabelPosition.Left || #0bb == SvgLabelPosition.Right || #0bb == SvgLabelPosition.FarLeft || #0bb == SvgLabelPosition.FarRight)
			{
				return #ivb + #mT.Height / 2.0;
			}
			if (#kvb == LabelType.LoadPoint)
			{
				return #ivb + #mT.Height + this.#d / #jvb;
			}
			if (#0bb == SvgLabelPosition.Top || #0bb == SvgLabelPosition.TopLeft || #0bb == SvgLabelPosition.TopRight || #0bb == SvgLabelPosition.TopRightAligned || #0bb == SvgLabelPosition.TopLeftAligned)
			{
				return #ivb + #mT.Height + this.#c / #jvb;
			}
			if (#0bb == SvgLabelPosition.Bottom || #0bb == SvgLabelPosition.BotLeft || #0bb == SvgLabelPosition.BotRight || #0bb == SvgLabelPosition.BotRightAligned)
			{
				return #ivb - this.#c / #jvb;
			}
			if (#0bb == SvgLabelPosition.BotAlignedLeftAligned || #0bb == SvgLabelPosition.BotAlignedRightAligned)
			{
				return #ivb;
			}
			if (#0bb == SvgLabelPosition.TopAlignedLeftAligned || #0bb == SvgLabelPosition.TopAlignedRightAligned)
			{
				return #ivb + #mT.Height;
			}
			return #ivb;
		}

		// Token: 0x06002B70 RID: 11120 RVA: 0x000E9E2C File Offset: 0x000E802C
		private bool #uvb(double #pvb, double #qvb, System.Windows.Size #mT)
		{
			#zDe #zDe = this.Data;
			return #zDe == null || #pvb < (double)#zDe.BorderWithMarginsMinX || #pvb + #mT.Width > (double)#zDe.BorderWithMarginsMaxX || #qvb < (double)#zDe.BorderWithMarginsMinY || #qvb + #mT.Height > (double)#zDe.BorderWithMarginsMaxY;
		}

		// Token: 0x04001156 RID: 4438
		private const double #a = 4.0;

		// Token: 0x04001157 RID: 4439
		private readonly List<System.Windows.Rect> #b = new List<System.Windows.Rect>();

		// Token: 0x04001158 RID: 4440
		private double #c = 10.0;

		// Token: 0x04001159 RID: 4441
		private readonly double #d = 1.0;

		// Token: 0x0400115A RID: 4442
		[CompilerGenerated]
		private #zDe #e;

		// Token: 0x0400115B RID: 4443
		[CompilerGenerated]
		private readonly #Bvb #f;

		// Token: 0x0400115C RID: 4444
		[CompilerGenerated]
		private double #g;

		// Token: 0x0400115D RID: 4445
		[CompilerGenerated]
		private double #h;

		// Token: 0x02000490 RID: 1168
		[CompilerGenerated]
		private sealed class #CTb
		{
			// Token: 0x06002B72 RID: 11122 RVA: 0x00027358 File Offset: 0x00025558
			internal bool #N7b(System.Windows.Rect #Rf)
			{
				return #Rf.IntersectsWith(this.#a);
			}

			// Token: 0x0400115E RID: 4446
			public System.Windows.Rect #a;
		}
	}
}
