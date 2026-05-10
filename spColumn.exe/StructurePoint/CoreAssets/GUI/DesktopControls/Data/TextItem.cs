using System;
using System.Windows;
using System.Windows.Media.Media3D;
using HelixToolkit.Wpf;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Data
{
	// Token: 0x020009F1 RID: 2545
	public sealed class TextItem
	{
		// Token: 0x06005363 RID: 21347 RVA: 0x00045076 File Offset: 0x00043276
		public TextItem(Point3D position, string text)
		{
			this.Position = position;
			this.Text = text;
		}

		// Token: 0x06005364 RID: 21348 RVA: 0x0004508C File Offset: 0x0004328C
		public TextItem(Point3D position, string text, HorizontalAlignment horizontalAlignment, VerticalAlignment verticalAlignment, Vector3D textDirection, Vector3D upperDirection)
		{
			this.Text = text;
			this.HorizontalAlignment = horizontalAlignment;
			this.Position = position;
			this.VerticalAlignment = verticalAlignment;
			this.TextDirection = textDirection;
			this.UpperDirection = upperDirection;
		}

		// Token: 0x170017C7 RID: 6087
		// (get) Token: 0x06005365 RID: 21349 RVA: 0x000450C1 File Offset: 0x000432C1
		// (set) Token: 0x06005366 RID: 21350 RVA: 0x000450CD File Offset: 0x000432CD
		public string Text { get; set; }

		// Token: 0x170017C8 RID: 6088
		// (get) Token: 0x06005367 RID: 21351 RVA: 0x000450DE File Offset: 0x000432DE
		// (set) Token: 0x06005368 RID: 21352 RVA: 0x000450EA File Offset: 0x000432EA
		public HorizontalAlignment HorizontalAlignment { get; set; }

		// Token: 0x170017C9 RID: 6089
		// (get) Token: 0x06005369 RID: 21353 RVA: 0x000450FB File Offset: 0x000432FB
		// (set) Token: 0x0600536A RID: 21354 RVA: 0x00045107 File Offset: 0x00043307
		public Point3D Position { get; set; }

		// Token: 0x170017CA RID: 6090
		// (get) Token: 0x0600536B RID: 21355 RVA: 0x00045118 File Offset: 0x00043318
		// (set) Token: 0x0600536C RID: 21356 RVA: 0x00045124 File Offset: 0x00043324
		public VerticalAlignment VerticalAlignment { get; set; }

		// Token: 0x170017CB RID: 6091
		// (get) Token: 0x0600536D RID: 21357 RVA: 0x00045135 File Offset: 0x00043335
		// (set) Token: 0x0600536E RID: 21358 RVA: 0x00045141 File Offset: 0x00043341
		public Vector3D TextDirection { get; set; }

		// Token: 0x170017CC RID: 6092
		// (get) Token: 0x0600536F RID: 21359 RVA: 0x00045152 File Offset: 0x00043352
		// (set) Token: 0x06005370 RID: 21360 RVA: 0x0004515E File Offset: 0x0004335E
		public Vector3D UpperDirection { get; set; }

		// Token: 0x06005371 RID: 21361 RVA: 0x0016426C File Offset: 0x0016246C
		internal SpatialTextItem ConvertToSpatialTextItem()
		{
			return new SpatialTextItem
			{
				Text = this.Text,
				HorizontalAlignment = this.HorizontalAlignment,
				Position = this.Position,
				TextDirection = this.TextDirection,
				UpDirection = this.UpperDirection
			};
		}

		// Token: 0x06005372 RID: 21362 RVA: 0x001642C8 File Offset: 0x001624C8
		internal BillboardTextItem ConvertToBillboardTextItem()
		{
			return new BillboardTextItem
			{
				HorizontalAlignment = this.HorizontalAlignment,
				Position = this.Position,
				Text = this.Text,
				VerticalAlignment = this.VerticalAlignment
			};
		}
	}
}
