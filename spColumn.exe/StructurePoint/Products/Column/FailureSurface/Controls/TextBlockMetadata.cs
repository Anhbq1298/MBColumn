using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using #7hc;
using #Iub;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Diagrams;

namespace StructurePoint.Products.Column.FailureSurface.Controls
{
	// Token: 0x02000493 RID: 1171
	[DebuggerDisplay("CanvasPos: {CanvasPosition}, Type: {LabelType}, ID: {UniqueId}, RelPos: {Position}")]
	internal sealed class TextBlockMetadata
	{
		// Token: 0x06002B7D RID: 11133 RVA: 0x000E9FD8 File Offset: 0x000E81D8
		public TextBlockMetadata(TextBlock textBlock, #Bvb calculator)
		{
			this.TextBlock = textBlock;
			this.#a = this.TextBlock.Foreground;
			this.Size = calculator.#zvb(textBlock.Text, textBlock.FontSize);
			this.CanvasPosition = new Point(Canvas.GetLeft(textBlock), Canvas.GetTop(textBlock));
			if (!string.IsNullOrWhiteSpace(textBlock.Text))
			{
				int num;
				int.TryParse(textBlock.Text, NumberStyles.Integer, CultureInfo.InvariantCulture, out num);
				this.TextAsInteger = num;
			}
			if (!string.IsNullOrWhiteSpace(textBlock.Name))
			{
				string[] array = textBlock.Name.Split(new char[]
				{
					'_'
				});
				if (array.Length != 8)
				{
					return;
				}
				string value = array[2];
				this.UniqueId = int.Parse(array[1], NumberStyles.Integer, CultureInfo.InvariantCulture);
				this.Position = (SvgLabelPosition)Enum.Parse(typeof(SvgLabelPosition), value, true);
				this.SourcePosition = new Point(this.#1vb(array[3]), this.#1vb(array[4]));
				this.InitialPosition = new Point(this.#1vb(array[5]), this.#1vb(array[6]));
				this.LabelType = (LabelType)Enum.Parse(typeof(LabelType), array[7], true);
				this.Valid = true;
			}
		}

		// Token: 0x17000EAD RID: 3757
		// (get) Token: 0x06002B7E RID: 11134 RVA: 0x000273E5 File Offset: 0x000255E5
		// (set) Token: 0x06002B7F RID: 11135 RVA: 0x000273F1 File Offset: 0x000255F1
		public int UniqueId { get; private set; }

		// Token: 0x17000EAE RID: 3758
		// (get) Token: 0x06002B80 RID: 11136 RVA: 0x00027402 File Offset: 0x00025602
		// (set) Token: 0x06002B81 RID: 11137 RVA: 0x0002740E File Offset: 0x0002560E
		public Size Size { get; private set; }

		// Token: 0x17000EAF RID: 3759
		// (get) Token: 0x06002B82 RID: 11138 RVA: 0x0002741F File Offset: 0x0002561F
		// (set) Token: 0x06002B83 RID: 11139 RVA: 0x0002742B File Offset: 0x0002562B
		public Point SourcePosition { get; private set; }

		// Token: 0x17000EB0 RID: 3760
		// (get) Token: 0x06002B84 RID: 11140 RVA: 0x0002743C File Offset: 0x0002563C
		// (set) Token: 0x06002B85 RID: 11141 RVA: 0x00027448 File Offset: 0x00025648
		public Point InitialPosition { get; private set; }

		// Token: 0x17000EB1 RID: 3761
		// (get) Token: 0x06002B86 RID: 11142 RVA: 0x00027459 File Offset: 0x00025659
		// (set) Token: 0x06002B87 RID: 11143 RVA: 0x00027465 File Offset: 0x00025665
		public SvgLabelPosition Position { get; private set; }

		// Token: 0x17000EB2 RID: 3762
		// (get) Token: 0x06002B88 RID: 11144 RVA: 0x00027476 File Offset: 0x00025676
		// (set) Token: 0x06002B89 RID: 11145 RVA: 0x00027482 File Offset: 0x00025682
		public bool Valid { get; private set; }

		// Token: 0x17000EB3 RID: 3763
		// (get) Token: 0x06002B8A RID: 11146 RVA: 0x00027493 File Offset: 0x00025693
		// (set) Token: 0x06002B8B RID: 11147 RVA: 0x0002749F File Offset: 0x0002569F
		public TextBlock TextBlock { get; private set; }

		// Token: 0x17000EB4 RID: 3764
		// (get) Token: 0x06002B8C RID: 11148 RVA: 0x000274B0 File Offset: 0x000256B0
		// (set) Token: 0x06002B8D RID: 11149 RVA: 0x000274BC File Offset: 0x000256BC
		public Point CanvasPosition { get; private set; }

		// Token: 0x17000EB5 RID: 3765
		// (get) Token: 0x06002B8E RID: 11150 RVA: 0x000274CD File Offset: 0x000256CD
		// (set) Token: 0x06002B8F RID: 11151 RVA: 0x000274D9 File Offset: 0x000256D9
		public LabelType LabelType { get; private set; }

		// Token: 0x17000EB6 RID: 3766
		// (get) Token: 0x06002B90 RID: 11152 RVA: 0x000274EA File Offset: 0x000256EA
		// (set) Token: 0x06002B91 RID: 11153 RVA: 0x000274F6 File Offset: 0x000256F6
		public int TextAsInteger { get; private set; }

		// Token: 0x06002B92 RID: 11154 RVA: 0x00027507 File Offset: 0x00025707
		public void #Zvb(Color #BR)
		{
			this.TextBlock.Foreground = new SolidColorBrush(#BR);
			this.TextBlock.Background = Brushes.White;
			Panel.SetZIndex(this.TextBlock, 1000);
		}

		// Token: 0x06002B93 RID: 11155 RVA: 0x000EA11C File Offset: 0x000E831C
		public void #0vb()
		{
			if (this.#a != null && this.TextBlock.Foreground != this.#a)
			{
				this.TextBlock.Foreground = this.#a;
				this.TextBlock.Background = Brushes.Transparent;
				Panel.SetZIndex(this.TextBlock, 0);
			}
		}

		// Token: 0x06002B94 RID: 11156 RVA: 0x000EA180 File Offset: 0x000E8380
		private double #1vb(string #f)
		{
			#f = #f.Replace(#Phc.#3hc(107359889), #Phc.#3hc(107408434)).Replace(#Phc.#3hc(107395517), #Phc.#3hc(107356879));
			return double.Parse(#f, NumberStyles.Any, CultureInfo.InvariantCulture);
		}

		// Token: 0x04001165 RID: 4453
		private readonly Brush #a;

		// Token: 0x04001166 RID: 4454
		[CompilerGenerated]
		private int #b;

		// Token: 0x04001167 RID: 4455
		[CompilerGenerated]
		private Size #c;

		// Token: 0x04001168 RID: 4456
		[CompilerGenerated]
		private Point #d;

		// Token: 0x04001169 RID: 4457
		[CompilerGenerated]
		private Point #e;

		// Token: 0x0400116A RID: 4458
		[CompilerGenerated]
		private SvgLabelPosition #f;

		// Token: 0x0400116B RID: 4459
		[CompilerGenerated]
		private bool #g;

		// Token: 0x0400116C RID: 4460
		[CompilerGenerated]
		private TextBlock #h;

		// Token: 0x0400116D RID: 4461
		[CompilerGenerated]
		private Point #i;

		// Token: 0x0400116E RID: 4462
		[CompilerGenerated]
		private LabelType #j;

		// Token: 0x0400116F RID: 4463
		[CompilerGenerated]
		private int #k;
	}
}
