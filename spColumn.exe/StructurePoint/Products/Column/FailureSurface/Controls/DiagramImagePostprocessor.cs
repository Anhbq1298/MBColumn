using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using #7hc;
using #Iub;
using #NHe;
using #rCe;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Diagrams;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using Telerik.Windows.Controls;

namespace StructurePoint.Products.Column.FailureSurface.Controls
{
	// Token: 0x02000488 RID: 1160
	internal sealed class DiagramImagePostprocessor
	{
		// Token: 0x06002AF4 RID: 10996 RVA: 0x000E8960 File Offset: 0x000E6B60
		public DiagramImagePostprocessor()
		{
			this.BaseFontSize = 20.0;
		}

		// Token: 0x17000E84 RID: 3716
		// (get) Token: 0x06002AF5 RID: 10997 RVA: 0x00026C7E File Offset: 0x00024E7E
		// (set) Token: 0x06002AF6 RID: 10998 RVA: 0x00026C97 File Offset: 0x00024E97
		public double BaseFontSize
		{
			get
			{
				return this.LabelsCreator.FontSize;
			}
			set
			{
				this.LabelsCreator.FontSize = value;
			}
		}

		// Token: 0x17000E85 RID: 3717
		// (get) Token: 0x06002AF7 RID: 10999 RVA: 0x00026CB1 File Offset: 0x00024EB1
		// (set) Token: 0x06002AF8 RID: 11000 RVA: 0x00026CCA File Offset: 0x00024ECA
		public double OriginalFontSize
		{
			get
			{
				return this.LabelsCreator.OriginalFontSize;
			}
			set
			{
				this.LabelsCreator.OriginalFontSize = value;
			}
		}

		// Token: 0x17000E86 RID: 3718
		// (get) Token: 0x06002AF9 RID: 11001 RVA: 0x00026CE4 File Offset: 0x00024EE4
		// (set) Token: 0x06002AFA RID: 11002 RVA: 0x00026CFD File Offset: 0x00024EFD
		public #zDe DrawingData
		{
			get
			{
				return this.LabelsCreator.Data;
			}
			set
			{
				this.LabelsCreator.Data = value;
			}
		}

		// Token: 0x17000E87 RID: 3719
		// (get) Token: 0x06002AFB RID: 11003 RVA: 0x00026D17 File Offset: 0x00024F17
		// (set) Token: 0x06002AFC RID: 11004 RVA: 0x00026D23 File Offset: 0x00024F23
		public #QCe DrawingResult { get; set; }

		// Token: 0x17000E88 RID: 3720
		// (get) Token: 0x06002AFD RID: 11005 RVA: 0x00026D34 File Offset: 0x00024F34
		public #vvb LabelsCreator { get; }

		// Token: 0x17000E89 RID: 3721
		// (get) Token: 0x06002AFE RID: 11006 RVA: 0x00026D40 File Offset: 0x00024F40
		public IList<PathMetadata> LoadPointLines
		{
			get
			{
				return this.#e;
			}
		}

		// Token: 0x17000E8A RID: 3722
		// (get) Token: 0x06002AFF RID: 11007 RVA: 0x00026D4C File Offset: 0x00024F4C
		public ICollection<TextBlockMetadata> TextBlocks
		{
			get
			{
				return this.#c.Values;
			}
		}

		// Token: 0x17000E8B RID: 3723
		// (get) Token: 0x06002B00 RID: 11008 RVA: 0x00026D61 File Offset: 0x00024F61
		public ICollection<EllipseMetadata> Ellipses
		{
			get
			{
				return this.#d.Values;
			}
		}

		// Token: 0x06002B01 RID: 11009 RVA: 0x000E89DC File Offset: 0x000E6BDC
		public void #dub(FrameworkElement #eub)
		{
			this.#a.Clear();
			this.#b.Clear();
			this.#c.Clear();
			this.#d.Clear();
			List<FrameworkElement> source = #eub.ChildrenOfType<FrameworkElement>().ToList<FrameworkElement>();
			this.#a.#pR(source.OfType<Path>(), new Func<Path, Path>(DiagramImagePostprocessor.<>c.<>9.#y7b), new Func<Path, PathMetadata>(DiagramImagePostprocessor.<>c.<>9.#z7b));
			this.#b.#pR(source.OfType<Polyline>(), new Func<Polyline, Polyline>(DiagramImagePostprocessor.<>c.<>9.#A7b), new Func<Polyline, PolylineMetadata>(DiagramImagePostprocessor.<>c.<>9.#B7b));
			this.#c.#pR(source.OfType<TextBlock>().OrderBy(new Func<TextBlock, string>(DiagramImagePostprocessor.<>c.<>9.#C7b)), new Func<TextBlock, TextBlock>(DiagramImagePostprocessor.<>c.<>9.#D7b), new Func<TextBlock, TextBlockMetadata>(this.#xub));
			this.#d.#pR(source.OfType<Ellipse>(), new Func<Ellipse, Ellipse>(DiagramImagePostprocessor.<>c.<>9.#E7b), new Func<Ellipse, EllipseMetadata>(DiagramImagePostprocessor.<>c.<>9.#F7b));
			this.#oub();
		}

		// Token: 0x06002B02 RID: 11010 RVA: 0x000E8B94 File Offset: 0x000E6D94
		public void #fub(FrameworkElement #Ic, double #gub)
		{
			if (this.DrawingData == null)
			{
				return;
			}
			List<FrameworkElement> #qub = #Ic.ChildrenOfType<FrameworkElement>().ToList<FrameworkElement>();
			this.#wub(#qub, #gub);
			this.#sub(#gub, #qub);
			this.#pub(#gub, #qub);
			this.#rub(#gub, #qub);
		}

		// Token: 0x06002B03 RID: 11011 RVA: 0x000E8BE4 File Offset: 0x000E6DE4
		public void #hub(IList<Path> #iub, double #jub, double #kub, double #gub, Color #zcb)
		{
			HashSet<Path> hashSet = new HashSet<Path>(#iub);
			foreach (KeyValuePair<Path, PathMetadata> keyValuePair in this.#a)
			{
				if (hashSet.Contains(keyValuePair.Key))
				{
					keyValuePair.Value.StrokeMagnificationFactor = #jub;
					keyValuePair.Value.LengthMagnificationFactor = #kub;
					keyValuePair.Value.Path.Stroke = new SolidColorBrush(#zcb);
					keyValuePair.Value.#fub(#gub);
					Panel.SetZIndex(keyValuePair.Value.Path, 999);
				}
				else if (keyValuePair.Value.#0ub())
				{
					keyValuePair.Value.#Yub();
					keyValuePair.Value.#2ub();
					keyValuePair.Value.#1ub();
					keyValuePair.Value.#fub(#gub);
				}
			}
		}

		// Token: 0x06002B04 RID: 11012 RVA: 0x000E8D04 File Offset: 0x000E6F04
		public void #xcb(TextBlockMetadata #lub, Color #zcb)
		{
			foreach (KeyValuePair<TextBlock, TextBlockMetadata> keyValuePair in this.#c)
			{
				if (keyValuePair.Value == #lub)
				{
					#lub.#Zvb(#zcb);
				}
				else
				{
					keyValuePair.Value.#0vb();
				}
			}
		}

		// Token: 0x06002B05 RID: 11013 RVA: 0x000E8D7C File Offset: 0x000E6F7C
		public void #mub(IList<Ellipse> #nub, Color #zcb)
		{
			HashSet<Ellipse> hashSet = new HashSet<Ellipse>(#nub);
			foreach (KeyValuePair<Ellipse, EllipseMetadata> keyValuePair in this.#d)
			{
				if (hashSet.Contains(keyValuePair.Key))
				{
					keyValuePair.Value.#Fub(#zcb);
				}
				else
				{
					keyValuePair.Value.#Gub();
				}
			}
		}

		// Token: 0x06002B06 RID: 11014 RVA: 0x000E8E08 File Offset: 0x000E7008
		private void #oub()
		{
			DiagramImagePostprocessor.#aVb #aVb = new DiagramImagePostprocessor.#aVb();
			this.#e.Clear();
			HashSet<int> hashSet = new HashSet<int>();
			foreach (KeyValuePair<Path, PathMetadata> keyValuePair in this.#a)
			{
				PathMetadata value = keyValuePair.Value;
				if (!string.IsNullOrWhiteSpace(value.Name))
				{
					Match match = this.#f.Match(value.Name);
					if (match.Success)
					{
						int item = int.Parse(match.Groups[1].Value, NumberStyles.Integer, CultureInfo.InvariantCulture);
						value.LoadPointIndex = item;
						if (hashSet.Add(item))
						{
							this.#e.Add(value);
						}
					}
				}
			}
			#aVb.#a = this.#a.Values.FirstOrDefault(new Func<PathMetadata, bool>(DiagramImagePostprocessor.<>c.<>9.#G7b));
			if (#aVb.#a == null)
			{
				return;
			}
			List<KeyValuePair<Path, PathMetadata>> list = this.#a.Where(new Func<KeyValuePair<Path, PathMetadata>, bool>(DiagramImagePostprocessor.<>c.<>9.#H7b)).ToList<KeyValuePair<Path, PathMetadata>>();
			list.ForEach(new Action<KeyValuePair<Path, PathMetadata>>(#aVb.#M7b));
		}

		// Token: 0x06002B07 RID: 11015 RVA: 0x000E8F80 File Offset: 0x000E7180
		private void #pub(double #gub, List<FrameworkElement> #qub)
		{
			foreach (Polyline polyline in #qub.OfType<Polyline>())
			{
				PolylineMetadata polylineMetadata;
				if (this.#b.TryGetValue(polyline, out polylineMetadata))
				{
					polyline.StrokeThickness = polylineMetadata.StrokeThickness / #gub;
				}
			}
		}

		// Token: 0x06002B08 RID: 11016 RVA: 0x000E8FF0 File Offset: 0x000E71F0
		private void #rub(double #gub, List<FrameworkElement> #qub)
		{
			foreach (Ellipse key in #qub.OfType<Ellipse>())
			{
				EllipseMetadata ellipseMetadata;
				if (this.#d.TryGetValue(key, out ellipseMetadata))
				{
					ellipseMetadata.#fub(#gub);
				}
			}
		}

		// Token: 0x06002B09 RID: 11017 RVA: 0x000E905C File Offset: 0x000E725C
		private void #sub(double #gub, List<FrameworkElement> #qub)
		{
			foreach (Path key in #qub.OfType<Path>())
			{
				PathMetadata pathMetadata;
				if (this.#a.TryGetValue(key, out pathMetadata))
				{
					pathMetadata.#fub(#gub);
				}
			}
		}

		// Token: 0x06002B0A RID: 11018 RVA: 0x000E90C8 File Offset: 0x000E72C8
		private int #tub(TextBlockMetadata #3ab)
		{
			switch (#3ab.LabelType)
			{
			case LabelType.Regular:
				return 0;
			case LabelType.AxisHorizontalLeft:
				return 4;
			case LabelType.AxisHorizontalRight:
				return 3;
			case LabelType.AxisVertialTop:
				return 1;
			case LabelType.AxisVerticalBottom:
				return 2;
			case LabelType.LoadPoint:
				return -1;
			case LabelType.AxisTitle:
				return 3;
			case LabelType.SpliceLine:
				return 4;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}

		// Token: 0x06002B0B RID: 11019 RVA: 0x000E9128 File Offset: 0x000E7328
		private string #uub(TextBlockMetadata #3ab)
		{
			string text = #3ab.TextBlock.Text;
			if ((#3ab.LabelType == LabelType.AxisHorizontalLeft || #3ab.LabelType == LabelType.AxisHorizontalRight) && !string.IsNullOrWhiteSpace(text) && !text.StartsWith(#Phc.#3hc(107408434)))
			{
				text = #Phc.#3hc(107408434) + text;
			}
			return text;
		}

		// Token: 0x06002B0C RID: 11020 RVA: 0x00026D76 File Offset: 0x00024F76
		private long #vub(TextBlockMetadata #3ab)
		{
			if (#3ab.LabelType == LabelType.LoadPoint)
			{
				return (long)#3ab.UniqueId;
			}
			return long.MaxValue - (long)#3ab.UniqueId;
		}

		// Token: 0x06002B0D RID: 11021 RVA: 0x000E918C File Offset: 0x000E738C
		private void #wub(List<FrameworkElement> #qub, double #gub)
		{
			List<TextBlock> source = #qub.OfType<TextBlock>().OrderBy(new Func<TextBlock, string>(DiagramImagePostprocessor.<>c.<>9.#I7b)).ToList<TextBlock>();
			if (!source.Any<TextBlock>())
			{
				return;
			}
			TextBlock textBlock;
			if ((textBlock = source.FirstOrDefault(new Func<TextBlock, bool>(DiagramImagePostprocessor.<>c.<>9.#J7b))) == null)
			{
				textBlock = (source.FirstOrDefault(new Func<TextBlock, bool>(DiagramImagePostprocessor.<>c.<>9.#K7b)) ?? source.First<TextBlock>());
			}
			TextBlock textBlock2 = textBlock;
			TextBlockMetadata textBlockMetadata = this.#c.#F1d(textBlock2);
			if (textBlockMetadata == null)
			{
				return;
			}
			double fontSize = this.LabelsCreator.Calculator.#wvb(textBlock2.Text, textBlockMetadata.Size.Width / #gub);
			this.LabelsCreator.FontSize = fontSize;
			this.LabelsCreator.#yl();
			float num = (float)#gub;
			var list = source.Select(new Func<TextBlock, <>f__AnonymousType1<TextBlock, TextBlockMetadata>>(this.#yub)).Where(new Func<<>f__AnonymousType1<TextBlock, TextBlockMetadata>, bool>(DiagramImagePostprocessor.<>c.<>9.#L7b)).OrderByDescending(new Func<<>f__AnonymousType1<TextBlock, TextBlockMetadata>, int>(this.#zub)).ThenBy(new Func<<>f__AnonymousType1<TextBlock, TextBlockMetadata>, long>(this.#Aub)).ToList();
			foreach (var <>f__AnonymousType in list)
			{
				TextBlock textBlock3 = <>f__AnonymousType.TextBlock;
				textBlockMetadata = <>f__AnonymousType.Metadata;
				textBlock3.FontSize = fontSize;
				textBlock3.BaselineOffset = 0.0;
				string #hvb = this.#uub(textBlockMetadata);
				bool #lvb = #gub >= 1.0;
				#Hub #Hub = this.LabelsCreator.#gvb(#hvb, (double)((float)textBlockMetadata.SourcePosition.X), (double)((float)textBlockMetadata.SourcePosition.Y), textBlockMetadata.Position, (double)num, textBlockMetadata.LabelType, #lvb);
				textBlock3.Visibility = #Hub.Visibility;
				if (textBlock3.Visibility == Visibility.Visible)
				{
					Canvas.SetLeft(textBlock3, #Hub.Position.X);
					float num2 = (float)#Hub.Position.Y;
					num2 = #ZIe.#UIe(num2, this.DrawingData.DiagramBorderMinY, this.DrawingData.DiagramBorderMaxY);
					Canvas.SetTop(textBlock3, (double)num2);
				}
			}
		}

		// Token: 0x06002B0E RID: 11022 RVA: 0x00026DA6 File Offset: 0x00024FA6
		[CompilerGenerated]
		private TextBlockMetadata #xub(TextBlock #Rf)
		{
			return new TextBlockMetadata(#Rf, this.LabelsCreator.Calculator);
		}

		// Token: 0x06002B0F RID: 11023 RVA: 0x00026DC5 File Offset: 0x00024FC5
		[CompilerGenerated]
		private <>f__AnonymousType1<TextBlock, TextBlockMetadata> #yub(TextBlock #Rf)
		{
			return new
			{
				TextBlock = #Rf,
				Metadata = this.#c.#F1d(#Rf)
			};
		}

		// Token: 0x06002B10 RID: 11024 RVA: 0x00026DE5 File Offset: 0x00024FE5
		[CompilerGenerated]
		private int #zub(<>f__AnonymousType1<TextBlock, TextBlockMetadata> #Rf)
		{
			return this.#tub(#Rf.Metadata);
		}

		// Token: 0x06002B11 RID: 11025 RVA: 0x00026DFF File Offset: 0x00024FFF
		[CompilerGenerated]
		private long #Aub(<>f__AnonymousType1<TextBlock, TextBlockMetadata> #Rf)
		{
			return this.#vub(#Rf.Metadata);
		}

		// Token: 0x04001122 RID: 4386
		private readonly Dictionary<Path, PathMetadata> #a = new Dictionary<Path, PathMetadata>();

		// Token: 0x04001123 RID: 4387
		private readonly Dictionary<Polyline, PolylineMetadata> #b = new Dictionary<Polyline, PolylineMetadata>();

		// Token: 0x04001124 RID: 4388
		private readonly Dictionary<TextBlock, TextBlockMetadata> #c = new Dictionary<TextBlock, TextBlockMetadata>();

		// Token: 0x04001125 RID: 4389
		private readonly Dictionary<Ellipse, EllipseMetadata> #d = new Dictionary<Ellipse, EllipseMetadata>();

		// Token: 0x04001126 RID: 4390
		private readonly List<PathMetadata> #e = new List<PathMetadata>();

		// Token: 0x04001127 RID: 4391
		private readonly Regex #f = new Regex(#Phc.#3hc(107357539), RegexOptions.Compiled | RegexOptions.Singleline);

		// Token: 0x04001128 RID: 4392
		[CompilerGenerated]
		private #QCe #g;

		// Token: 0x04001129 RID: 4393
		[CompilerGenerated]
		private readonly #vvb #h = new #vvb();

		// Token: 0x0200048A RID: 1162
		[CompilerGenerated]
		private sealed class #aVb
		{
			// Token: 0x06002B23 RID: 11043 RVA: 0x00026F1A File Offset: 0x0002511A
			internal void #M7b(KeyValuePair<Path, PathMetadata> #Rf)
			{
				#Rf.Value.#3ub(this.#a);
			}

			// Token: 0x04001139 RID: 4409
			public PathMetadata #a;
		}
	}
}
