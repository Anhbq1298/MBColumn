using System;
using System.Windows;
using System.Windows.Media;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Data
{
	// Token: 0x020009F5 RID: 2549
	public interface IBillboardTextDrawingResult : IDrawingResult
	{
		// Token: 0x170017E3 RID: 6115
		// (get) Token: 0x060053A6 RID: 21414
		// (set) Token: 0x060053A7 RID: 21415
		string Text { get; set; }

		// Token: 0x170017E4 RID: 6116
		// (get) Token: 0x060053A8 RID: 21416
		// (set) Token: 0x060053A9 RID: 21417
		Point3D Position { get; set; }

		// Token: 0x170017E5 RID: 6117
		// (get) Token: 0x060053AA RID: 21418
		// (set) Token: 0x060053AB RID: 21419
		FontFamily FontFamily { get; set; }

		// Token: 0x170017E6 RID: 6118
		// (get) Token: 0x060053AC RID: 21420
		// (set) Token: 0x060053AD RID: 21421
		double FontSize { get; set; }

		// Token: 0x170017E7 RID: 6119
		// (get) Token: 0x060053AE RID: 21422
		// (set) Token: 0x060053AF RID: 21423
		FontWeight FontWeight { get; set; }

		// Token: 0x170017E8 RID: 6120
		// (get) Token: 0x060053B0 RID: 21424
		// (set) Token: 0x060053B1 RID: 21425
		Brush Background { get; set; }

		// Token: 0x170017E9 RID: 6121
		// (get) Token: 0x060053B2 RID: 21426
		// (set) Token: 0x060053B3 RID: 21427
		Brush BorderBrush { get; set; }

		// Token: 0x170017EA RID: 6122
		// (get) Token: 0x060053B4 RID: 21428
		// (set) Token: 0x060053B5 RID: 21429
		Thickness BorderThickness { get; set; }

		// Token: 0x170017EB RID: 6123
		// (get) Token: 0x060053B6 RID: 21430
		// (set) Token: 0x060053B7 RID: 21431
		Brush Foreground { get; set; }

		// Token: 0x170017EC RID: 6124
		// (get) Token: 0x060053B8 RID: 21432
		// (set) Token: 0x060053B9 RID: 21433
		double Height { get; set; }

		// Token: 0x170017ED RID: 6125
		// (get) Token: 0x060053BA RID: 21434
		// (set) Token: 0x060053BB RID: 21435
		double HeightFactor { get; set; }

		// Token: 0x170017EE RID: 6126
		// (get) Token: 0x060053BC RID: 21436
		// (set) Token: 0x060053BD RID: 21437
		HorizontalAlignment HorizontalAlignment { get; set; }

		// Token: 0x170017EF RID: 6127
		// (get) Token: 0x060053BE RID: 21438
		// (set) Token: 0x060053BF RID: 21439
		Thickness Padding { get; set; }

		// Token: 0x170017F0 RID: 6128
		// (get) Token: 0x060053C0 RID: 21440
		// (set) Token: 0x060053C1 RID: 21441
		VerticalAlignment VerticalAlignment { get; set; }

		// Token: 0x170017F1 RID: 6129
		// (get) Token: 0x060053C2 RID: 21442
		// (set) Token: 0x060053C3 RID: 21443
		double Width { get; set; }

		// Token: 0x170017F2 RID: 6130
		// (get) Token: 0x060053C4 RID: 21444
		StructurePoint.CoreAssets.Infrastructure.Data.Size EffectiveSize { get; }

		// Token: 0x170017F3 RID: 6131
		// (get) Token: 0x060053C5 RID: 21445
		// (set) Token: 0x060053C6 RID: 21446
		Thickness Margin { get; set; }

		// Token: 0x060053C7 RID: 21447
		void UpdateBillboardText(TextItem item, Brush background, double fontSize, Thickness padding);

		// Token: 0x060053C8 RID: 21448
		void BeginUpdate();

		// Token: 0x060053C9 RID: 21449
		void EndUpdate();
	}
}
