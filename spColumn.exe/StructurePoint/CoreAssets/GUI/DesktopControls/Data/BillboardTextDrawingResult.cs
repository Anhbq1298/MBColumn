using System;
using System.Windows;
using System.Windows.Media;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.GUI.DesktopControls.Visuals;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Data
{
	// Token: 0x020009F4 RID: 2548
	public sealed class BillboardTextDrawingResult : DrawingResultBase, IDrawingResult, IBillboardTextDrawingResult
	{
		// Token: 0x0600537E RID: 21374 RVA: 0x00045244 File Offset: 0x00043444
		public BillboardTextDrawingResult()
		{
			this.BillboardTextVisual = new CustomBillboardTextVisual3D();
		}

		// Token: 0x170017D1 RID: 6097
		// (get) Token: 0x0600537F RID: 21375 RVA: 0x00045257 File Offset: 0x00043457
		// (set) Token: 0x06005380 RID: 21376 RVA: 0x00045263 File Offset: 0x00043463
		internal CustomBillboardTextVisual3D BillboardTextVisual { get; private set; }

		// Token: 0x170017D2 RID: 6098
		// (get) Token: 0x06005381 RID: 21377 RVA: 0x00045274 File Offset: 0x00043474
		// (set) Token: 0x06005382 RID: 21378 RVA: 0x0004528D File Offset: 0x0004348D
		public Thickness Margin
		{
			get
			{
				return this.BillboardTextVisual.Margin;
			}
			set
			{
				this.BillboardTextVisual.Margin = value;
			}
		}

		// Token: 0x170017D3 RID: 6099
		// (get) Token: 0x06005383 RID: 21379 RVA: 0x000452A7 File Offset: 0x000434A7
		public StructurePoint.CoreAssets.Infrastructure.Data.Size EffectiveSize
		{
			get
			{
				return this.BillboardTextVisual.EffectiveModelSize;
			}
		}

		// Token: 0x170017D4 RID: 6100
		// (get) Token: 0x06005384 RID: 21380 RVA: 0x000452C0 File Offset: 0x000434C0
		// (set) Token: 0x06005385 RID: 21381 RVA: 0x000452D9 File Offset: 0x000434D9
		public string Text
		{
			get
			{
				return this.BillboardTextVisual.Text;
			}
			set
			{
				this.BillboardTextVisual.Text = value;
			}
		}

		// Token: 0x170017D5 RID: 6101
		// (get) Token: 0x06005386 RID: 21382 RVA: 0x000452F3 File Offset: 0x000434F3
		// (set) Token: 0x06005387 RID: 21383 RVA: 0x00045311 File Offset: 0x00043511
		public Point3D Position
		{
			get
			{
				return this.BillboardTextVisual.Position.Convert();
			}
			set
			{
				this.BillboardTextVisual.Position = value.Convert();
			}
		}

		// Token: 0x170017D6 RID: 6102
		// (get) Token: 0x06005388 RID: 21384 RVA: 0x00045330 File Offset: 0x00043530
		// (set) Token: 0x06005389 RID: 21385 RVA: 0x00045349 File Offset: 0x00043549
		public FontFamily FontFamily
		{
			get
			{
				return this.BillboardTextVisual.FontFamily;
			}
			set
			{
				this.BillboardTextVisual.FontFamily = value;
			}
		}

		// Token: 0x170017D7 RID: 6103
		// (get) Token: 0x0600538A RID: 21386 RVA: 0x00045363 File Offset: 0x00043563
		// (set) Token: 0x0600538B RID: 21387 RVA: 0x0004537C File Offset: 0x0004357C
		public double FontSize
		{
			get
			{
				return this.BillboardTextVisual.FontSize;
			}
			set
			{
				this.BillboardTextVisual.FontSize = value;
			}
		}

		// Token: 0x170017D8 RID: 6104
		// (get) Token: 0x0600538C RID: 21388 RVA: 0x00045396 File Offset: 0x00043596
		// (set) Token: 0x0600538D RID: 21389 RVA: 0x000453AF File Offset: 0x000435AF
		public FontWeight FontWeight
		{
			get
			{
				return this.BillboardTextVisual.FontWeight;
			}
			set
			{
				this.BillboardTextVisual.FontWeight = value;
			}
		}

		// Token: 0x170017D9 RID: 6105
		// (get) Token: 0x0600538E RID: 21390 RVA: 0x000453C9 File Offset: 0x000435C9
		// (set) Token: 0x0600538F RID: 21391 RVA: 0x000453E2 File Offset: 0x000435E2
		public Brush Background
		{
			get
			{
				return this.BillboardTextVisual.Background;
			}
			set
			{
				this.BillboardTextVisual.Background = value;
			}
		}

		// Token: 0x170017DA RID: 6106
		// (get) Token: 0x06005390 RID: 21392 RVA: 0x000453FC File Offset: 0x000435FC
		// (set) Token: 0x06005391 RID: 21393 RVA: 0x00045415 File Offset: 0x00043615
		public Brush BorderBrush
		{
			get
			{
				return this.BillboardTextVisual.BorderBrush;
			}
			set
			{
				this.BillboardTextVisual.BorderBrush = value;
			}
		}

		// Token: 0x170017DB RID: 6107
		// (get) Token: 0x06005392 RID: 21394 RVA: 0x0004542F File Offset: 0x0004362F
		// (set) Token: 0x06005393 RID: 21395 RVA: 0x00045448 File Offset: 0x00043648
		public Thickness BorderThickness
		{
			get
			{
				return this.BillboardTextVisual.BorderThickness;
			}
			set
			{
				this.BillboardTextVisual.BorderThickness = value;
			}
		}

		// Token: 0x170017DC RID: 6108
		// (get) Token: 0x06005394 RID: 21396 RVA: 0x00045462 File Offset: 0x00043662
		// (set) Token: 0x06005395 RID: 21397 RVA: 0x0004547B File Offset: 0x0004367B
		public Brush Foreground
		{
			get
			{
				return this.BillboardTextVisual.Foreground;
			}
			set
			{
				this.BillboardTextVisual.Foreground = value;
			}
		}

		// Token: 0x170017DD RID: 6109
		// (get) Token: 0x06005396 RID: 21398 RVA: 0x00045495 File Offset: 0x00043695
		// (set) Token: 0x06005397 RID: 21399 RVA: 0x000454AE File Offset: 0x000436AE
		public double Height
		{
			get
			{
				return this.BillboardTextVisual.Height;
			}
			set
			{
				this.BillboardTextVisual.Height = value;
			}
		}

		// Token: 0x170017DE RID: 6110
		// (get) Token: 0x06005398 RID: 21400 RVA: 0x000454C8 File Offset: 0x000436C8
		// (set) Token: 0x06005399 RID: 21401 RVA: 0x000454E1 File Offset: 0x000436E1
		public double HeightFactor
		{
			get
			{
				return this.BillboardTextVisual.HeightFactor;
			}
			set
			{
				this.BillboardTextVisual.HeightFactor = value;
			}
		}

		// Token: 0x170017DF RID: 6111
		// (get) Token: 0x0600539A RID: 21402 RVA: 0x000454FB File Offset: 0x000436FB
		// (set) Token: 0x0600539B RID: 21403 RVA: 0x00045514 File Offset: 0x00043714
		public HorizontalAlignment HorizontalAlignment
		{
			get
			{
				return this.BillboardTextVisual.HorizontalAlignment;
			}
			set
			{
				this.BillboardTextVisual.HorizontalAlignment = value;
			}
		}

		// Token: 0x170017E0 RID: 6112
		// (get) Token: 0x0600539C RID: 21404 RVA: 0x0004552E File Offset: 0x0004372E
		// (set) Token: 0x0600539D RID: 21405 RVA: 0x00045547 File Offset: 0x00043747
		public Thickness Padding
		{
			get
			{
				return this.BillboardTextVisual.Padding;
			}
			set
			{
				this.BillboardTextVisual.Padding = value;
			}
		}

		// Token: 0x170017E1 RID: 6113
		// (get) Token: 0x0600539E RID: 21406 RVA: 0x00045561 File Offset: 0x00043761
		// (set) Token: 0x0600539F RID: 21407 RVA: 0x0004557A File Offset: 0x0004377A
		public VerticalAlignment VerticalAlignment
		{
			get
			{
				return this.BillboardTextVisual.VerticalAlignment;
			}
			set
			{
				this.BillboardTextVisual.VerticalAlignment = value;
			}
		}

		// Token: 0x170017E2 RID: 6114
		// (get) Token: 0x060053A0 RID: 21408 RVA: 0x00045594 File Offset: 0x00043794
		// (set) Token: 0x060053A1 RID: 21409 RVA: 0x000455AD File Offset: 0x000437AD
		public double Width
		{
			get
			{
				return this.BillboardTextVisual.Width;
			}
			set
			{
				this.BillboardTextVisual.Width = value;
			}
		}

		// Token: 0x060053A2 RID: 21410 RVA: 0x000455C7 File Offset: 0x000437C7
		public void BeginUpdate()
		{
			this.BillboardTextVisual.BeginUpdate();
		}

		// Token: 0x060053A3 RID: 21411 RVA: 0x000455E0 File Offset: 0x000437E0
		public void EndUpdate()
		{
			this.BillboardTextVisual.EndUpdate();
		}

		// Token: 0x060053A4 RID: 21412 RVA: 0x000455F9 File Offset: 0x000437F9
		protected internal override object RetrieveDisplayedObject()
		{
			return this.BillboardTextVisual;
		}

		// Token: 0x060053A5 RID: 21413 RVA: 0x0016438C File Offset: 0x0016258C
		public void UpdateBillboardText(TextItem item, Brush background, double fontSize, Thickness padding)
		{
			#X0d.#V0d(item, #Phc.#3hc(107398878), Component.DesktopControls, #Phc.#3hc(107462709));
			try
			{
				this.BillboardTextVisual.BeginUpdate();
				this.FontSize = fontSize;
				this.Position = item.Position.Convert();
				this.Text = item.Text;
				this.HorizontalAlignment = item.HorizontalAlignment;
				this.VerticalAlignment = item.VerticalAlignment;
				this.Foreground = Brushes.Black;
				this.Background = background;
				this.Padding = padding;
			}
			finally
			{
				this.BillboardTextVisual.EndUpdate();
			}
		}
	}
}
