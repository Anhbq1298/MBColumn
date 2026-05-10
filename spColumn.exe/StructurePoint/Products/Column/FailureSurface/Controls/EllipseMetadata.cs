using System;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace StructurePoint.Products.Column.FailureSurface.Controls
{
	// Token: 0x0200048B RID: 1163
	internal sealed class EllipseMetadata
	{
		// Token: 0x06002B24 RID: 11044 RVA: 0x000E943C File Offset: 0x000E763C
		public EllipseMetadata(Ellipse ellipse)
		{
			this.Ellipse = ellipse;
			this.Width = ellipse.Width;
			this.Height = ellipse.Height;
			this.#a = ellipse.Fill;
			this.Name = ellipse.Name;
			this.Center = new Point(Canvas.GetLeft(ellipse) + this.Width / 2.0, Canvas.GetTop(ellipse) + this.Height / 2.0);
		}

		// Token: 0x17000E8C RID: 3724
		// (get) Token: 0x06002B25 RID: 11045 RVA: 0x00026F3A File Offset: 0x0002513A
		// (set) Token: 0x06002B26 RID: 11046 RVA: 0x00026F46 File Offset: 0x00025146
		public double Width { get; private set; }

		// Token: 0x17000E8D RID: 3725
		// (get) Token: 0x06002B27 RID: 11047 RVA: 0x00026F57 File Offset: 0x00025157
		// (set) Token: 0x06002B28 RID: 11048 RVA: 0x00026F63 File Offset: 0x00025163
		public double Height { get; private set; }

		// Token: 0x17000E8E RID: 3726
		// (get) Token: 0x06002B29 RID: 11049 RVA: 0x00026F74 File Offset: 0x00025174
		// (set) Token: 0x06002B2A RID: 11050 RVA: 0x00026F80 File Offset: 0x00025180
		public Ellipse Ellipse { get; private set; }

		// Token: 0x17000E8F RID: 3727
		// (get) Token: 0x06002B2B RID: 11051 RVA: 0x00026F91 File Offset: 0x00025191
		// (set) Token: 0x06002B2C RID: 11052 RVA: 0x00026F9D File Offset: 0x0002519D
		public Point Center { get; private set; }

		// Token: 0x17000E90 RID: 3728
		// (get) Token: 0x06002B2D RID: 11053 RVA: 0x00026FAE File Offset: 0x000251AE
		// (set) Token: 0x06002B2E RID: 11054 RVA: 0x00026FBA File Offset: 0x000251BA
		public string Name { get; private set; }

		// Token: 0x06002B2F RID: 11055 RVA: 0x00026FCB File Offset: 0x000251CB
		public void #Fub(Color #BR)
		{
			this.Ellipse.Fill = new SolidColorBrush(#BR);
			Panel.SetZIndex(this.Ellipse, 999);
		}

		// Token: 0x06002B30 RID: 11056 RVA: 0x000E94C0 File Offset: 0x000E76C0
		public void #Gub()
		{
			if (this.#a != null && this.Ellipse.Fill != this.#a)
			{
				this.Ellipse.Fill = this.#a;
				Panel.SetZIndex(this.Ellipse, 0);
			}
		}

		// Token: 0x06002B31 RID: 11057 RVA: 0x000E9514 File Offset: 0x000E7714
		public void #fub(double #gub)
		{
			this.Ellipse.Width = this.Width / #gub;
			this.Ellipse.Height = this.Height / #gub;
			Canvas.SetLeft(this.Ellipse, this.Center.X - this.Ellipse.Width / 2.0);
			Canvas.SetTop(this.Ellipse, this.Center.Y - this.Ellipse.Height / 2.0);
		}

		// Token: 0x0400113A RID: 4410
		private readonly Brush #a;

		// Token: 0x0400113B RID: 4411
		[CompilerGenerated]
		private double #b;

		// Token: 0x0400113C RID: 4412
		[CompilerGenerated]
		private double #c;

		// Token: 0x0400113D RID: 4413
		[CompilerGenerated]
		private Ellipse #d;

		// Token: 0x0400113E RID: 4414
		[CompilerGenerated]
		private Point #e;

		// Token: 0x0400113F RID: 4415
		[CompilerGenerated]
		private string #f;
	}
}
