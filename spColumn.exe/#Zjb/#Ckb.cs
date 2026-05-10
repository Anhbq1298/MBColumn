using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace #Zjb
{
	// Token: 0x02000429 RID: 1065
	internal sealed class #Ckb
	{
		// Token: 0x060026C9 RID: 9929 RVA: 0x000D6B10 File Offset: 0x000D4D10
		public #Ckb(Path #So)
		{
			this.#c = #So;
			this.#f = #So.StrokeThickness;
			PathGeometry pathGeometry = (PathGeometry)#So.Data;
			PathFigure pathFigure = pathGeometry.Figures.Single<PathFigure>();
			this.Start = pathFigure.StartPoint;
			this.End = ((LineSegment)pathFigure.Segments.Single<PathSegment>()).Point;
			this.#b = (Math.Abs(this.Start.X - this.End.X) < 0.001);
			if (this.IsVertical && this.Start.Y > this.End.Y)
			{
				this.#ykb();
				return;
			}
			if (!this.IsVertical && this.Start.X > this.End.X)
			{
				this.#ykb();
			}
		}

		// Token: 0x17000D20 RID: 3360
		// (get) Token: 0x060026CA RID: 9930 RVA: 0x000246EB File Offset: 0x000228EB
		public bool IsVertical { get; }

		// Token: 0x17000D21 RID: 3361
		// (get) Token: 0x060026CB RID: 9931 RVA: 0x000246F7 File Offset: 0x000228F7
		public Path Path { get; }

		// Token: 0x17000D22 RID: 3362
		// (get) Token: 0x060026CC RID: 9932 RVA: 0x00024703 File Offset: 0x00022903
		// (set) Token: 0x060026CD RID: 9933 RVA: 0x0002470F File Offset: 0x0002290F
		public Point Start { get; private set; }

		// Token: 0x17000D23 RID: 3363
		// (get) Token: 0x060026CE RID: 9934 RVA: 0x00024720 File Offset: 0x00022920
		// (set) Token: 0x060026CF RID: 9935 RVA: 0x0002472C File Offset: 0x0002292C
		public Point End { get; private set; }

		// Token: 0x17000D24 RID: 3364
		// (get) Token: 0x060026D0 RID: 9936 RVA: 0x0002473D File Offset: 0x0002293D
		public double StrokeThickness { get; }

		// Token: 0x060026D1 RID: 9937 RVA: 0x00024749 File Offset: 0x00022949
		public void #wkb()
		{
			this.Path.StrokeThickness = this.StrokeThickness;
			this.#zkb(this.Start, this.End);
		}

		// Token: 0x060026D2 RID: 9938 RVA: 0x000D6C04 File Offset: 0x000D4E04
		public void #xkb()
		{
			Point #Akb;
			Point #Bkb;
			if (this.IsVertical)
			{
				double num = Math.Abs(this.End.Y - this.Start.Y) * 0.25;
				#Akb = new Point(this.Start.X, this.Start.Y - num / 2.0);
				#Bkb = new Point(this.End.X, this.End.Y + num / 2.0);
			}
			else
			{
				double num2 = Math.Abs(this.End.X - this.Start.X) * 0.25;
				#Akb = new Point(this.Start.X - num2 / 2.0, this.End.Y);
				#Bkb = new Point(this.End.X + num2 / 2.0, this.End.Y);
			}
			this.#zkb(#Akb, #Bkb);
			this.Path.StrokeThickness = this.StrokeThickness * 2.0;
		}

		// Token: 0x060026D3 RID: 9939 RVA: 0x000D6D7C File Offset: 0x000D4F7C
		private void #ykb()
		{
			Point point = this.Start;
			this.Start = this.End;
			this.End = point;
		}

		// Token: 0x060026D4 RID: 9940 RVA: 0x000D6DB0 File Offset: 0x000D4FB0
		private void #zkb(Point #Akb, Point #Bkb)
		{
			PathGeometry pathGeometry = new PathGeometry();
			pathGeometry.Figures.Add(new PathFigure(#Akb, new PathSegment[]
			{
				new LineSegment(#Bkb, true)
			}, false));
			this.Path.Data = pathGeometry;
		}

		// Token: 0x04000F5E RID: 3934
		private const double #a = 0.25;

		// Token: 0x04000F5F RID: 3935
		[CompilerGenerated]
		private readonly bool #b;

		// Token: 0x04000F60 RID: 3936
		[CompilerGenerated]
		private readonly Path #c;

		// Token: 0x04000F61 RID: 3937
		[CompilerGenerated]
		private Point #d;

		// Token: 0x04000F62 RID: 3938
		[CompilerGenerated]
		private Point #e;

		// Token: 0x04000F63 RID: 3939
		[CompilerGenerated]
		private readonly double #f;
	}
}
