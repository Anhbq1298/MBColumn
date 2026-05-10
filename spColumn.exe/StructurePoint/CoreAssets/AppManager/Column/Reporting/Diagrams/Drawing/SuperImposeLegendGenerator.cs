using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using #7hc;
using #NHe;
using #oFe;
using #Oze;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using Svg;

namespace StructurePoint.CoreAssets.AppManager.Column.Reporting.Diagrams.Drawing
{
	// Token: 0x02001246 RID: 4678
	public sealed class SuperImposeLegendGenerator
	{
		// Token: 0x17002D58 RID: 11608
		// (get) Token: 0x06009CB8 RID: 40120 RVA: 0x0007BA12 File Offset: 0x00079C12
		// (set) Token: 0x06009CB9 RID: 40121 RVA: 0x0007BA1A File Offset: 0x00079C1A
		public bool IncludeBaseDiagrams { get; set; } = true;

		// Token: 0x17002D59 RID: 11609
		// (get) Token: 0x06009CBA RID: 40122 RVA: 0x00058C6C File Offset: 0x00056E6C
		protected float LineWidth
		{
			get
			{
				return 40f;
			}
		}

		// Token: 0x17002D5A RID: 11610
		// (get) Token: 0x06009CBB RID: 40123 RVA: 0x0007BA23 File Offset: 0x00079C23
		protected float TextMargin
		{
			get
			{
				return 4f;
			}
		}

		// Token: 0x17002D5B RID: 11611
		// (get) Token: 0x06009CBC RID: 40124 RVA: 0x0007BA23 File Offset: 0x00079C23
		protected float LineMargin
		{
			get
			{
				return 4f;
			}
		}

		// Token: 0x06009CBD RID: 40125 RVA: 0x00213908 File Offset: 0x00211B08
		public SvgDocument #nGe(#mAe #6c, bool #oGe, bool #pGe, double #qGe, #ZIe #Lte)
		{
			this.#c = new SvgUnit(SvgUnitType.Pixel, (float)#qGe);
			#CJe #sGe = new #CJe(#Lte);
			SvgGroup svgGroup = new SvgGroup();
			List<SuperImposeDiagram> list = #6c.Diagrams.Where(new Func<SuperImposeDiagram, bool>(SuperImposeLegendGenerator.<>c.<>9.#zef)).ToList<SuperImposeDiagram>();
			StructurePoint.CoreAssets.Infrastructure.Data.Size size = this.#kue(#sGe, list);
			SvgDocument svgDocument = new SvgDocument
			{
				ViewBox = new SvgViewBox(0f, 0f, (float)size.Width, (float)size.Height)
			};
			svgDocument.Children.Add(svgGroup);
			svgDocument.Fill = new SvgColourServer(Color.Red);
			svgGroup.Fill = new SvgColourServer(Color.Red);
			svgGroup.Color = new SvgColourServer(Color.Red);
			svgDocument.Color = new SvgColourServer(Color.Red);
			float value = 1f;
			float value2 = 1f;
			int i;
			for (i = 0; i < list.Count; i++)
			{
				SuperImposeDiagram superImposeDiagram = list[i];
				this.#rGe(#Lte, #sGe, svgGroup, superImposeDiagram.Label, value, superImposeDiagram.LineType, new SvgColourServer(superImposeDiagram.Color.ToDrawingColor()), i);
			}
			if (this.IncludeBaseDiagrams)
			{
				if (#pGe)
				{
					this.#rGe(#Lte, #sGe, svgGroup, Strings.StringFactored, value2, #Lte.FactoredDiagramStrokeDashArray, #Lte.SuperImposeBaseStroke, i);
				}
				if (!#pGe)
				{
					i--;
				}
				if (#oGe)
				{
					this.#rGe(#Lte, #sGe, svgGroup, Strings.StringNominal, value, #Lte.NominalDiagramStrokeDashArray, #Lte.SuperImposeBaseStroke, i + 1);
				}
			}
			return svgDocument;
		}

		// Token: 0x06009CBE RID: 40126 RVA: 0x00213AAC File Offset: 0x00211CAC
		private void #rGe(#ZIe #Lte, #CJe #sGe, SvgGroup #Sue, string #oT, SvgUnit #tGe, SvgUnitCollection #GAe, SvgColourServer #uGe, int #4jb)
		{
			#oT = #oT.#Z2d(100);
			float num = (float)#sGe.#yJe(#oT, this.#c).Height;
			float num2 = num / 2f;
			float num3 = this.#vGe(#sGe);
			float num4 = num + num * (float)#4jb + this.LineMargin * (float)#4jb;
			SvgLine item = new SvgLine
			{
				StartX = new SvgUnit(num3),
				StartY = new SvgUnit(num4 - num2 / 2f),
				EndX = new SvgUnit(num3 + this.LineWidth),
				EndY = new SvgUnit(num4 - num2 / 2f),
				StrokeWidth = #tGe,
				StrokeDashArray = #GAe,
				Stroke = #uGe
			};
			SvgText item2 = new SvgText
			{
				FontSize = this.#c,
				FontFamily = #Lte.FontFamily,
				Fill = new SvgColourServer(Color.Black),
				Text = #oT,
				X = #1Ge.#ul(new SvgUnit[]
				{
					num3 + this.LineWidth + this.TextMargin
				}),
				Y = #1Ge.#ul(new SvgUnit[]
				{
					num4
				})
			};
			#Sue.Children.Add(item);
			#Sue.Children.Add(item2);
		}

		// Token: 0x06009CBF RID: 40127 RVA: 0x00213C10 File Offset: 0x00211E10
		private float #vGe(#CJe #sGe)
		{
			return (float)#sGe.#zvb(#Phc.#3hc(107314427), this.#c).Width;
		}

		// Token: 0x06009CC0 RID: 40128 RVA: 0x00213C44 File Offset: 0x00211E44
		private StructurePoint.CoreAssets.Infrastructure.Data.Size #kue(#CJe #sGe, IList<SuperImposeDiagram> #jEe)
		{
			float num = (float)#sGe.#yJe(#Phc.#3hc(107314427), this.#c).Height;
			int num2 = this.IncludeBaseDiagrams ? 2 : 0;
			int num3 = #jEe.Count + num2;
			List<string> list = #jEe.Select(new Func<SuperImposeDiagram, string>(SuperImposeLegendGenerator.<>c.<>9.#Aef)).ToList<string>();
			double num4 = double.MinValue;
			if (this.IncludeBaseDiagrams)
			{
				list.Add(Strings.StringNominal);
				list.Add(Strings.StringFactored);
			}
			if (!list.Any<string>())
			{
				num4 = 1000.0;
			}
			foreach (string #xvb in list)
			{
				num4 = Math.Max(#sGe.#yJe(#xvb, this.#c).Width, num4);
			}
			float num5 = num * (float)num3 + this.LineMargin * (float)num3;
			return new StructurePoint.CoreAssets.Infrastructure.Data.Size(num4 + (double)this.LineWidth + (double)this.#vGe(#sGe) + (double)this.TextMargin, (double)num5);
		}

		// Token: 0x040043B5 RID: 17333
		private const int #a = 100;

		// Token: 0x040043B6 RID: 17334
		private const string #b = "-500000";

		// Token: 0x040043B7 RID: 17335
		private SvgUnit #c = new SvgUnit(SvgUnitType.Pixel, 8f);

		// Token: 0x040043B8 RID: 17336
		[CompilerGenerated]
		private bool #d;
	}
}
