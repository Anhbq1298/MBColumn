using System;
using System.Windows.Media;
using #u3d;
using Ab3d.Visuals;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Data
{
	// Token: 0x02000A0C RID: 2572
	public sealed class TextDrawingResult : DrawingResultBase, IDrawingResult, ITextDrawingResult
	{
		// Token: 0x060054C7 RID: 21703 RVA: 0x00046362 File Offset: 0x00044562
		public TextDrawingResult()
		{
			this.TextVisual = new TextVisual3D();
		}

		// Token: 0x17001864 RID: 6244
		// (get) Token: 0x060054C8 RID: 21704 RVA: 0x00046375 File Offset: 0x00044575
		// (set) Token: 0x060054C9 RID: 21705 RVA: 0x00046381 File Offset: 0x00044581
		internal TextVisual3D TextVisual { get; private set; }

		// Token: 0x17001865 RID: 6245
		// (get) Token: 0x060054CA RID: 21706 RVA: 0x00046392 File Offset: 0x00044592
		// (set) Token: 0x060054CB RID: 21707 RVA: 0x000463AB File Offset: 0x000445AB
		public string Text
		{
			get
			{
				return this.TextVisual.Text;
			}
			set
			{
				this.TextVisual.Text = value;
			}
		}

		// Token: 0x17001866 RID: 6246
		// (get) Token: 0x060054CC RID: 21708 RVA: 0x000463C5 File Offset: 0x000445C5
		// (set) Token: 0x060054CD RID: 21709 RVA: 0x000463E3 File Offset: 0x000445E3
		public Point3D Position
		{
			get
			{
				return this.TextVisual.Position.Convert();
			}
			set
			{
				this.TextVisual.Position = value.Convert();
			}
		}

		// Token: 0x17001867 RID: 6247
		// (get) Token: 0x060054CE RID: 21710 RVA: 0x00046402 File Offset: 0x00044602
		// (set) Token: 0x060054CF RID: 21711 RVA: 0x0004641B File Offset: 0x0004461B
		public Color TextColor
		{
			get
			{
				return this.TextVisual.TextColor;
			}
			set
			{
				this.TextVisual.TextColor = value;
			}
		}

		// Token: 0x17001868 RID: 6248
		// (get) Token: 0x060054D0 RID: 21712 RVA: 0x00046435 File Offset: 0x00044635
		// (set) Token: 0x060054D1 RID: 21713 RVA: 0x0004644E File Offset: 0x0004464E
		public double FontSize
		{
			get
			{
				return this.TextVisual.FontSize;
			}
			set
			{
				this.TextVisual.FontSize = value;
			}
		}

		// Token: 0x17001869 RID: 6249
		// (get) Token: 0x060054D2 RID: 21714 RVA: 0x00046468 File Offset: 0x00044668
		// (set) Token: 0x060054D3 RID: 21715 RVA: 0x00046486 File Offset: 0x00044686
		public #c4d UpDirection
		{
			get
			{
				return this.TextVisual.UpDirection.Convert();
			}
			set
			{
				this.TextVisual.UpDirection = value.Convert();
			}
		}

		// Token: 0x1700186A RID: 6250
		// (get) Token: 0x060054D4 RID: 21716 RVA: 0x000464A5 File Offset: 0x000446A5
		// (set) Token: 0x060054D5 RID: 21717 RVA: 0x000464C3 File Offset: 0x000446C3
		public #c4d TextDirection
		{
			get
			{
				return this.TextVisual.TextDirection.Convert();
			}
			set
			{
				this.TextVisual.TextDirection = value.Convert();
			}
		}

		// Token: 0x060054D6 RID: 21718 RVA: 0x000464E2 File Offset: 0x000446E2
		protected internal override object RetrieveDisplayedObject()
		{
			return this.TextVisual;
		}
	}
}
