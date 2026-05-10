using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using #7hc;
using #Fmc;
using #oFe;
using #rCe;
using #UYd;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Diagrams;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Settings;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using Svg;

namespace #NHe
{
	// Token: 0x0200125E RID: 4702
	internal sealed class #wJe
	{
		// Token: 0x06009DD5 RID: 40405 RVA: 0x0007C3D7 File Offset: 0x0007A5D7
		public #wJe(#ZIe #Lte, #zDe #Gfb)
		{
			#X0d.#V0d(#Gfb, #Phc.#3hc(107376321), Component.ColumnReporter, #Phc.#3hc(107314481));
			this.#d = #Gfb;
			this.#e = #Lte;
			this.#f = new #CJe(#Lte);
		}

		// Token: 0x06009DD6 RID: 40406 RVA: 0x0007C415 File Offset: 0x0007A615
		public static float #Toc(double #f, int #Uoc)
		{
			if (#f == 0.0)
			{
				return 0f;
			}
			return (float)#Voc.#Toc(#f, #Uoc);
		}

		// Token: 0x06009DD7 RID: 40407 RVA: 0x0021817C File Offset: 0x0021637C
		[MethodImpl(MethodImplOptions.NoOptimization)]
		public IEnumerable<SvgText> #lJe(ValuesOnAxesType #GFe)
		{
			List<SvgText> list = new List<SvgText>();
			for (float num = (float)#ZIe.#f - this.#d.AxisIntervalX; num >= this.#d.DiagramBorderMinX - 1f; num -= this.#d.AxisIntervalX)
			{
				string #hvb = #wJe.#Toc((double)(num / this.#d.MomentsScalingFactor), 2).ToString(#wJe.#b, CultureInfo.CurrentCulture);
				SvgText svgText = this.#pJe(#hvb, num, (float)#ZIe.#g, SvgLabelPosition.Bottom, LabelType.AxisHorizontalLeft);
				if (svgText != null)
				{
					list.Add(svgText);
				}
			}
			this.#rJe(list, #GFe);
			return list;
		}

		// Token: 0x06009DD8 RID: 40408 RVA: 0x00218214 File Offset: 0x00216414
		[MethodImpl(MethodImplOptions.NoOptimization)]
		public IEnumerable<SvgText> #mJe(ValuesOnAxesType #GFe)
		{
			List<SvgText> list = new List<SvgText>();
			for (float num = (float)#ZIe.#f + this.#d.AxisIntervalX; num <= this.#d.DiagramBorderMaxX + 1f; num += this.#d.AxisIntervalX)
			{
				string #hvb = #wJe.#Toc((double)(num / this.#d.MomentsScalingFactor), 2).ToString(#wJe.#b, CultureInfo.CurrentCulture);
				SvgText svgText = this.#pJe(#hvb, num, (float)#ZIe.#g, SvgLabelPosition.Bottom, LabelType.AxisHorizontalRight);
				if (svgText != null)
				{
					list.Add(svgText);
				}
			}
			this.#rJe(list, #GFe);
			return list;
		}

		// Token: 0x06009DD9 RID: 40409 RVA: 0x002182AC File Offset: 0x002164AC
		[MethodImpl(MethodImplOptions.NoOptimization)]
		public IEnumerable<SvgText> #nJe(SvgLabelPosition #0bb, ValuesOnAxesType #GFe)
		{
			List<SvgText> list = new List<SvgText>();
			for (float num = (float)#ZIe.#g - this.#d.AxisIntervalY; num >= this.#d.DiagramBorderMinY - 1f; num -= this.#d.AxisIntervalY)
			{
				SvgText svgText = this.#pJe(#wJe.#Toc((double)(num / this.#d.AxialLoadScalingFactor), 2).ToString(#wJe.#b, CultureInfo.CurrentCulture), (float)#ZIe.#f, num, #0bb, LabelType.AxisVerticalBottom);
				if (svgText != null)
				{
					list.Add(svgText);
				}
			}
			this.#rJe(list, #GFe);
			return list;
		}

		// Token: 0x06009DDA RID: 40410 RVA: 0x00218340 File Offset: 0x00216540
		[MethodImpl(MethodImplOptions.NoOptimization)]
		public IEnumerable<SvgText> #oJe(SvgLabelPosition #0bb, ValuesOnAxesType #GFe)
		{
			List<SvgText> list = new List<SvgText>();
			for (float num = (float)#ZIe.#g + this.#d.AxisIntervalY; num <= this.#d.DiagramBorderMaxY + 1f; num += this.#d.AxisIntervalY)
			{
				SvgText svgText = this.#pJe(#wJe.#Toc((double)(num / this.#d.AxialLoadScalingFactor), 2).ToString(#wJe.#b, CultureInfo.CurrentCulture), (float)#ZIe.#f, num, #0bb, LabelType.AxisVertialTop);
				if (svgText != null)
				{
					list.Add(svgText);
				}
			}
			this.#rJe(list, #GFe);
			return list;
		}

		// Token: 0x06009DDB RID: 40411 RVA: 0x002183D4 File Offset: 0x002165D4
		[MethodImpl(MethodImplOptions.NoOptimization)]
		public SvgText #pJe(string #hvb, float #cpb, float #ivb, SvgLabelPosition #0bb, LabelType #kvb = LabelType.Regular)
		{
			#X0d.#V0d(#hvb, #Phc.#3hc(107453475), Component.ColumnReporter, #Phc.#3hc(107313916));
			#X0d.#V0d(#0bb, #Phc.#3hc(107478158), Component.ColumnReporter, #Phc.#3hc(107313831));
			System.Windows.Size #mT = this.#f.#yJe(this.#qJe(#hvb));
			float num = (float)this.#svb(#cpb, #0bb, #mT, #kvb);
			float num2 = (float)this.#tvb(#ivb, #0bb, #mT, #kvb);
			if (num < this.#d.BorderWithMarginsMinX || num > this.#d.BorderWithMarginsMaxX || num2 < this.#d.BorderWithMarginsMinY || num2 > this.#d.BorderWithMarginsMaxY || (#kvb == LabelType.SpliceLine && (double)num + #mT.Width > (double)this.#d.BorderWithMarginsMaxX))
			{
				if (#kvb == LabelType.SpliceLine)
				{
					if (num < this.#d.BorderWithMarginsMinX)
					{
						num = this.#d.BorderWithMarginsMinX;
						#0bb = SvgLabelPosition.Top;
					}
					else
					{
						if (num <= this.#d.BorderWithMarginsMaxX && (double)num + #mT.Width <= (double)this.#d.BorderWithMarginsMaxX)
						{
							return null;
						}
						#0bb = SvgLabelPosition.Top;
						num = Math.Min(this.#d.BorderWithMarginsMaxX, num);
					}
				}
				else if (#kvb != LabelType.AxisTitle)
				{
					return null;
				}
			}
			SvgText svgText = this.#vJe(#hvb, num, num2);
			svgText.ID = this.#sJe(#cpb, #ivb, num, num2, #0bb, #kvb);
			return svgText;
		}

		// Token: 0x06009DDC RID: 40412 RVA: 0x0007C431 File Offset: 0x0007A631
		private string #qJe(string #hvb)
		{
			return #hvb.Split(new string[]
			{
				Environment.NewLine
			}, StringSplitOptions.RemoveEmptyEntries).FirstOrDefault<string>();
		}

		// Token: 0x06009DDD RID: 40413 RVA: 0x0007C44D File Offset: 0x0007A64D
		private void #rJe(List<SvgText> #8f, ValuesOnAxesType #GFe)
		{
			if (#GFe == ValuesOnAxesType.MaxOnly && #8f.Count > 1)
			{
				#8f.RemoveRange(0, #8f.Count - 1);
			}
		}

		// Token: 0x06009DDE RID: 40414 RVA: 0x00218530 File Offset: 0x00216730
		[MethodImpl(MethodImplOptions.NoOptimization)]
		private double #svb(float #cpb, SvgLabelPosition #0bb, System.Windows.Size #mT, LabelType #kvb)
		{
			double num = #mT.Height * 2.0 / 3.0;
			if (#0bb == SvgLabelPosition.Left || #0bb == SvgLabelPosition.TopLeft || #0bb == SvgLabelPosition.BotLeft)
			{
				return (double)#cpb - num - #mT.Width;
			}
			if (#0bb == SvgLabelPosition.FarLeft)
			{
				return (double)#cpb - num - #mT.Width * 2.0;
			}
			if (#kvb == LabelType.LoadPoint)
			{
				return (double)(#cpb + this.#e.LoadPointMargin);
			}
			if (#0bb == SvgLabelPosition.Right || #0bb == SvgLabelPosition.Right || #0bb == SvgLabelPosition.TopRight || #0bb == SvgLabelPosition.BotRight)
			{
				return (double)#cpb + num;
			}
			if (#0bb == SvgLabelPosition.FarRight)
			{
				return (double)#cpb + num + #mT.Width;
			}
			if (#0bb == SvgLabelPosition.BotRightAligned || #0bb == SvgLabelPosition.TopRightAligned)
			{
				return (double)#cpb;
			}
			if (#0bb == SvgLabelPosition.TopAlignedRightAligned || #0bb == SvgLabelPosition.BotAlignedRightAligned)
			{
				return (double)#cpb;
			}
			if (#0bb == SvgLabelPosition.TopAlignedLeftAligned || #0bb == SvgLabelPosition.BotAlignedLeftAligned)
			{
				return (double)#cpb - #mT.Width;
			}
			if (#0bb == SvgLabelPosition.TopLeftAligned)
			{
				return (double)#cpb - #mT.Width;
			}
			return (double)#cpb - #mT.Width / 2.0;
		}

		// Token: 0x06009DDF RID: 40415 RVA: 0x0021861C File Offset: 0x0021681C
		[MethodImpl(MethodImplOptions.NoOptimization)]
		private double #tvb(float #ivb, SvgLabelPosition #0bb, System.Windows.Size #mT, LabelType #kvb)
		{
			double num = (double)((float)#mT.Height) * 2.0 / 3.0;
			double num2 = (double)((float)#mT.Height) * 1.0 / 3.0;
			if (#0bb == SvgLabelPosition.Left || #0bb == SvgLabelPosition.Right || #0bb == SvgLabelPosition.FarLeft || #0bb == SvgLabelPosition.FarRight)
			{
				return (double)#ivb - #mT.Height / 3.0;
			}
			if (#kvb == LabelType.LoadPoint)
			{
				return (double)(#ivb + this.#e.LoadPointMargin);
			}
			if (#0bb == SvgLabelPosition.Top || #0bb == SvgLabelPosition.TopLeft || #0bb == SvgLabelPosition.TopRight || #0bb == SvgLabelPosition.TopRightAligned || #0bb == SvgLabelPosition.TopLeftAligned)
			{
				return (double)#ivb + num;
			}
			if (#0bb == SvgLabelPosition.TopAlignedRightAligned || #0bb == SvgLabelPosition.TopAlignedLeftAligned)
			{
				return (double)#ivb + num2;
			}
			if (#0bb == SvgLabelPosition.Bottom || #0bb == SvgLabelPosition.BotLeft || #0bb == SvgLabelPosition.BotRight || #0bb == SvgLabelPosition.BotRightAligned)
			{
				return (double)#ivb - #mT.Height - num;
			}
			if (#0bb == SvgLabelPosition.BotAlignedRightAligned || #0bb == SvgLabelPosition.BotAlignedLeftAligned)
			{
				return (double)#ivb - #mT.Height;
			}
			return (double)#ivb;
		}

		// Token: 0x06009DE0 RID: 40416 RVA: 0x00218700 File Offset: 0x00216900
		private string #sJe(float #tJe, float #uJe, float #pvb, float #qvb, SvgLabelPosition #0bb, LabelType #kvb)
		{
			return string.Format(#Phc.#3hc(107313810), new object[]
			{
				#wJe.#c++.ToString(#Phc.#3hc(107313733), CultureInfo.InvariantCulture),
				#0bb.ToString(),
				#tJe.ToString(#Phc.#3hc(107313756), CultureInfo.InvariantCulture),
				#uJe.ToString(#Phc.#3hc(107313756), CultureInfo.InvariantCulture),
				#pvb.ToString(#Phc.#3hc(107313756), CultureInfo.InvariantCulture),
				#qvb.ToString(#Phc.#3hc(107313756), CultureInfo.InvariantCulture),
				#kvb
			}).Replace(#Phc.#3hc(107356879), #Phc.#3hc(107395517)).Replace(#Phc.#3hc(107408434), #Phc.#3hc(107359889));
		}

		// Token: 0x06009DE1 RID: 40417 RVA: 0x002187FC File Offset: 0x002169FC
		private SvgText #vJe(string #hvb, float #pvb, float #qvb)
		{
			string[] array = #hvb.Split(new string[]
			{
				Environment.NewLine
			}, StringSplitOptions.None).Reverse<string>().ToArray<string>();
			SvgText svgText = new SvgText
			{
				FontSize = this.#e.DisplayFontSize,
				FontFamily = this.#e.FontFamily,
				Fill = new SvgColourServer(Color.Black),
				X = #1Ge.#ul(new SvgUnit[]
				{
					#pvb
				}),
				Y = #1Ge.#ul(new SvgUnit[]
				{
					#ZIe.#UIe(#qvb, this.#d.DiagramBorderMinY, this.#d.DiagramBorderMaxY)
				})
			};
			if (array.Length == 1)
			{
				svgText.Text = #hvb;
			}
			else if (array.Length != 0)
			{
				float num = 0f;
				for (int i = 0; i < array.Length; i++)
				{
					string text = array[i];
					svgText.Children.Add(new SvgTextSpan
					{
						FontSize = this.#e.DisplayFontSize,
						FontFamily = this.#e.FontFamily,
						Fill = new SvgColourServer(Color.Black),
						Text = text,
						Dy = #1Ge.#ul(new SvgUnit[]
						{
							this.#e.DisplayFontSize.Value * 0.9f - 2.2f * this.#e.DisplayFontSize.Value * (float)i
						}),
						Dx = #1Ge.#ul(new SvgUnit[]
						{
							-num
						})
					});
					num = (float)this.#f.#yJe(text).Width;
				}
			}
			return svgText;
		}

		// Token: 0x04004449 RID: 17481
		public const int #a = 2;

		// Token: 0x0400444A RID: 17482
		public static readonly string #b = #Phc.#3hc(107408848);

		// Token: 0x0400444B RID: 17483
		private static int #c;

		// Token: 0x0400444C RID: 17484
		private readonly #zDe #d;

		// Token: 0x0400444D RID: 17485
		private readonly #ZIe #e;

		// Token: 0x0400444E RID: 17486
		private readonly #CJe #f;
	}
}
