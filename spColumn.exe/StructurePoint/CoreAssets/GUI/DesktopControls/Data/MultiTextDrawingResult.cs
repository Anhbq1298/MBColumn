using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using HelixToolkit.Wpf;
using StructurePoint.CoreAssets.GUI.DesktopControls.Visuals;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Data
{
	// Token: 0x020009ED RID: 2541
	public sealed class MultiTextDrawingResult : DrawingResultBase, IMultiTextDrawingResult, IDrawingResult
	{
		// Token: 0x0600534C RID: 21324 RVA: 0x0016411C File Offset: 0x0016231C
		public MultiTextDrawingResult()
		{
			this.textGroupVisual = new CustomBillboardTextGroupVisual3D
			{
				BorderThickness = default(Thickness),
				BorderBrush = null
			};
		}

		// Token: 0x170017C2 RID: 6082
		// (get) Token: 0x0600534D RID: 21325 RVA: 0x00044F99 File Offset: 0x00043199
		// (set) Token: 0x0600534E RID: 21326 RVA: 0x00044FA5 File Offset: 0x000431A5
		public Thickness Padding { get; private set; }

		// Token: 0x170017C3 RID: 6083
		// (get) Token: 0x0600534F RID: 21327 RVA: 0x00044FB6 File Offset: 0x000431B6
		// (set) Token: 0x06005350 RID: 21328 RVA: 0x00044FC2 File Offset: 0x000431C2
		public Brush Background { get; private set; }

		// Token: 0x170017C4 RID: 6084
		// (get) Token: 0x06005351 RID: 21329 RVA: 0x00044FD3 File Offset: 0x000431D3
		// (set) Token: 0x06005352 RID: 21330 RVA: 0x00044FDF File Offset: 0x000431DF
		public Brush Foreground { get; private set; }

		// Token: 0x170017C5 RID: 6085
		// (get) Token: 0x06005353 RID: 21331 RVA: 0x00044FF0 File Offset: 0x000431F0
		// (set) Token: 0x06005354 RID: 21332 RVA: 0x00044FFC File Offset: 0x000431FC
		public double FontSize { get; private set; }

		// Token: 0x170017C6 RID: 6086
		// (get) Token: 0x06005355 RID: 21333 RVA: 0x0004500D File Offset: 0x0004320D
		// (set) Token: 0x06005356 RID: 21334 RVA: 0x00045019 File Offset: 0x00043219
		public IList<TextItem> Items { get; private set; }

		// Token: 0x06005357 RID: 21335 RVA: 0x00164150 File Offset: 0x00162350
		public void Update(IList<TextItem> items, Brush foreground, Brush background, Thickness padding, double newFontSize)
		{
			if (6 != 0)
			{
				this.Foreground = foreground;
			}
			this.Background = background;
			this.Padding = padding;
			this.FontSize = newFontSize;
			this.Items = items;
			this.textGroupVisual.Items = null;
			if (items != null && items.Any<TextItem>())
			{
				this.textGroupVisual.Foreground = foreground;
				this.textGroupVisual.Background = background;
				this.textGroupVisual.Padding = padding;
				this.textGroupVisual.FontSize = newFontSize;
				this.textGroupVisual.HeightFactor = 1.0;
				this.textGroupVisual.Items = (from item in items
				select item.ConvertToBillboardTextItem()).ToList<BillboardTextItem>();
			}
		}

		// Token: 0x06005358 RID: 21336 RVA: 0x0004502A File Offset: 0x0004322A
		protected internal override object RetrieveDisplayedObject()
		{
			return this.textGroupVisual;
		}

		// Token: 0x04002416 RID: 9238
		private readonly CustomBillboardTextGroupVisual3D textGroupVisual;
	}
}
