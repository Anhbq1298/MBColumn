using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using #7hc;
using #Fmc;
using #NHe;
using StructurePoint.CoreAssets.GUI.DesktopControls.Visualization2D;
using Telerik.Windows.Controls;

namespace StructurePoint.Products.Column.FailureSurface.Controls
{
	// Token: 0x0200048D RID: 1165
	internal sealed class PathMetadata
	{
		// Token: 0x06002B37 RID: 11063 RVA: 0x00027043 File Offset: 0x00025243
		public PathMetadata(Path path)
		{
			this.Path = path;
			this.StrokeThickness = path.StrokeThickness;
			this.#a = path.Stroke;
			this.#1ub();
			this.#d = Panel.GetZIndex(path);
			this.#dub();
		}

		// Token: 0x17000E93 RID: 3731
		// (get) Token: 0x06002B38 RID: 11064 RVA: 0x00027082 File Offset: 0x00025282
		// (set) Token: 0x06002B39 RID: 11065 RVA: 0x0002708E File Offset: 0x0002528E
		public bool IsAxisTick { get; private set; }

		// Token: 0x17000E94 RID: 3732
		// (get) Token: 0x06002B3A RID: 11066 RVA: 0x0002709F File Offset: 0x0002529F
		// (set) Token: 0x06002B3B RID: 11067 RVA: 0x000270AB File Offset: 0x000252AB
		public Point StartPoint { get; private set; }

		// Token: 0x17000E95 RID: 3733
		// (get) Token: 0x06002B3C RID: 11068 RVA: 0x000270BC File Offset: 0x000252BC
		// (set) Token: 0x06002B3D RID: 11069 RVA: 0x000270C8 File Offset: 0x000252C8
		public Point EndPoint { get; private set; }

		// Token: 0x17000E96 RID: 3734
		// (get) Token: 0x06002B3E RID: 11070 RVA: 0x000270D9 File Offset: 0x000252D9
		// (set) Token: 0x06002B3F RID: 11071 RVA: 0x000270E5 File Offset: 0x000252E5
		public Point Center { get; private set; }

		// Token: 0x17000E97 RID: 3735
		// (get) Token: 0x06002B40 RID: 11072 RVA: 0x000270F6 File Offset: 0x000252F6
		// (set) Token: 0x06002B41 RID: 11073 RVA: 0x00027102 File Offset: 0x00025302
		public Path Path { get; private set; }

		// Token: 0x17000E98 RID: 3736
		// (get) Token: 0x06002B42 RID: 11074 RVA: 0x00027113 File Offset: 0x00025313
		// (set) Token: 0x06002B43 RID: 11075 RVA: 0x0002711F File Offset: 0x0002531F
		public double StrokeThickness { get; private set; }

		// Token: 0x17000E99 RID: 3737
		// (get) Token: 0x06002B44 RID: 11076 RVA: 0x00027130 File Offset: 0x00025330
		// (set) Token: 0x06002B45 RID: 11077 RVA: 0x0002713C File Offset: 0x0002533C
		public double LengthMagnificationFactor { get; set; }

		// Token: 0x17000E9A RID: 3738
		// (get) Token: 0x06002B46 RID: 11078 RVA: 0x0002714D File Offset: 0x0002534D
		// (set) Token: 0x06002B47 RID: 11079 RVA: 0x00027159 File Offset: 0x00025359
		public double StrokeMagnificationFactor { get; set; }

		// Token: 0x17000E9B RID: 3739
		// (get) Token: 0x06002B48 RID: 11080 RVA: 0x0002716A File Offset: 0x0002536A
		// (set) Token: 0x06002B49 RID: 11081 RVA: 0x00027176 File Offset: 0x00025376
		public string Name { get; private set; }

		// Token: 0x17000E9C RID: 3740
		// (get) Token: 0x06002B4A RID: 11082 RVA: 0x00027187 File Offset: 0x00025387
		// (set) Token: 0x06002B4B RID: 11083 RVA: 0x00027193 File Offset: 0x00025393
		public int LoadPointIndex { get; set; }

		// Token: 0x17000E9D RID: 3741
		// (get) Token: 0x06002B4C RID: 11084 RVA: 0x000E95C4 File Offset: 0x000E77C4
		public double ActualLength
		{
			get
			{
				return (this.#Zub(this.#c.Point) - this.#Zub(this.#b.StartPoint)).Length;
			}
		}

		// Token: 0x06002B4D RID: 11085 RVA: 0x000271A4 File Offset: 0x000253A4
		public void #Yub()
		{
			Panel.SetZIndex(this.Path, this.#d);
		}

		// Token: 0x06002B4E RID: 11086 RVA: 0x000E960C File Offset: 0x000E780C
		public Point #Zub(Point #Ng)
		{
			GeneralTransform generalTransform = this.Path.TransformToAncestor(this.Path.ParentOfType<CustomSvgViewBox>().Child);
			return generalTransform.Transform(#Ng);
		}

		// Token: 0x06002B4F RID: 11087 RVA: 0x000271C3 File Offset: 0x000253C3
		public bool #0ub()
		{
			return this.StrokeMagnificationFactor != 1.0 || this.LengthMagnificationFactor != 1.0;
		}

		// Token: 0x06002B50 RID: 11088 RVA: 0x000E9648 File Offset: 0x000E7848
		public void #1ub()
		{
			this.StrokeMagnificationFactor = (this.LengthMagnificationFactor = 1.0);
		}

		// Token: 0x06002B51 RID: 11089 RVA: 0x000271F8 File Offset: 0x000253F8
		public void #2ub()
		{
			this.Path.Stroke = this.#a;
		}

		// Token: 0x06002B52 RID: 11090 RVA: 0x000E967C File Offset: 0x000E787C
		public void #fub(double #gub)
		{
			this.Path.StrokeThickness = this.StrokeThickness / #gub * this.StrokeMagnificationFactor;
			if (this.IsAxisTick || this.IsLoadPointLine)
			{
				Point point = this.Center + (this.EndPoint - this.Center) * 1.0 / #gub * this.LengthMagnificationFactor;
				Point startPoint = this.Center - (this.Center - this.StartPoint) * 1.0 / #gub * this.LengthMagnificationFactor;
				this.#b.StartPoint = startPoint;
				this.#c.Point = point;
			}
		}

		// Token: 0x06002B53 RID: 11091 RVA: 0x000E9764 File Offset: 0x000E7964
		public void #3ub(PathMetadata #4ub)
		{
			if (#4ub == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107357510));
			}
			if (!#4ub.IsVertical || #4ub.LoadPointIndex != this.LoadPointIndex)
			{
				throw new ArgumentException();
			}
			Point point = this.Center;
			Point point2 = #4ub.Center;
			if ((point - point2).Length > 0.05)
			{
				if (#Emc.#Amc(point2.X, this.StartPoint.X))
				{
					this.Center = this.StartPoint;
					return;
				}
				if (#Emc.#Amc(point2.X, this.EndPoint.X))
				{
					this.Center = this.EndPoint;
				}
			}
		}

		// Token: 0x17000E9E RID: 3742
		// (get) Token: 0x06002B54 RID: 11092 RVA: 0x00027217 File Offset: 0x00025417
		// (set) Token: 0x06002B55 RID: 11093 RVA: 0x00027223 File Offset: 0x00025423
		public bool IsHorizontal { get; private set; }

		// Token: 0x17000E9F RID: 3743
		// (get) Token: 0x06002B56 RID: 11094 RVA: 0x00027234 File Offset: 0x00025434
		// (set) Token: 0x06002B57 RID: 11095 RVA: 0x00027240 File Offset: 0x00025440
		public bool IsVertical { get; private set; }

		// Token: 0x17000EA0 RID: 3744
		// (get) Token: 0x06002B58 RID: 11096 RVA: 0x00027251 File Offset: 0x00025451
		// (set) Token: 0x06002B59 RID: 11097 RVA: 0x0002725D File Offset: 0x0002545D
		public bool IsLoadPointLine { get; private set; }

		// Token: 0x17000EA1 RID: 3745
		// (get) Token: 0x06002B5A RID: 11098 RVA: 0x0002726E File Offset: 0x0002546E
		// (set) Token: 0x06002B5B RID: 11099 RVA: 0x0002727A File Offset: 0x0002547A
		public bool IsMainGridLine { get; private set; }

		// Token: 0x06002B5C RID: 11100 RVA: 0x000E9838 File Offset: 0x000E7A38
		private void #dub()
		{
			if (string.IsNullOrWhiteSpace(this.Path.Name))
			{
				return;
			}
			this.Name = this.Path.Name;
			this.IsLoadPointLine = this.Name.StartsWith(#Phc.#3hc(107357481), StringComparison.Ordinal);
			this.IsAxisTick = (this.Name.StartsWith(#Phc.#3hc(107357492), StringComparison.Ordinal) || this.Name.StartsWith(#Phc.#3hc(107357471), StringComparison.Ordinal));
			this.IsMainGridLine = (string.Equals(#kJe.HorizontalMainGridLineId, this.Name, StringComparison.Ordinal) || string.Equals(#kJe.VerticalMainGridLineId, this.Name, StringComparison.Ordinal));
			if (!this.IsLoadPointLine && !this.IsAxisTick && !this.IsMainGridLine)
			{
				return;
			}
			PathGeometry pathGeometry = this.Path.Data as PathGeometry;
			if (pathGeometry == null || pathGeometry.Figures.Count != 1)
			{
				return;
			}
			this.#b = pathGeometry.Figures.First<PathFigure>();
			if (this.#b.Segments.Count != 1)
			{
				return;
			}
			this.#c = (this.#b.Segments[0] as LineSegment);
			if (this.#c == null)
			{
				return;
			}
			this.StartPoint = this.#b.StartPoint;
			this.EndPoint = this.#c.Point;
			this.Center = this.StartPoint + (this.EndPoint - this.StartPoint) / 2.0;
			this.IsHorizontal = #Emc.#Amc(this.StartPoint.Y, this.EndPoint.Y);
			this.IsVertical = #Emc.#Amc(this.StartPoint.X, this.EndPoint.X);
		}

		// Token: 0x04001142 RID: 4418
		private readonly Brush #a;

		// Token: 0x04001143 RID: 4419
		private PathFigure #b;

		// Token: 0x04001144 RID: 4420
		private LineSegment #c;

		// Token: 0x04001145 RID: 4421
		private readonly int #d;

		// Token: 0x04001146 RID: 4422
		[CompilerGenerated]
		private bool #e;

		// Token: 0x04001147 RID: 4423
		[CompilerGenerated]
		private Point #f;

		// Token: 0x04001148 RID: 4424
		[CompilerGenerated]
		private Point #g;

		// Token: 0x04001149 RID: 4425
		[CompilerGenerated]
		private Point #h;

		// Token: 0x0400114A RID: 4426
		[CompilerGenerated]
		private Path #i;

		// Token: 0x0400114B RID: 4427
		[CompilerGenerated]
		private double #j;

		// Token: 0x0400114C RID: 4428
		[CompilerGenerated]
		private double #k;

		// Token: 0x0400114D RID: 4429
		[CompilerGenerated]
		private double #l;

		// Token: 0x0400114E RID: 4430
		[CompilerGenerated]
		private string #m;

		// Token: 0x0400114F RID: 4431
		[CompilerGenerated]
		private int #n;

		// Token: 0x04001150 RID: 4432
		[CompilerGenerated]
		private bool #o;

		// Token: 0x04001151 RID: 4433
		[CompilerGenerated]
		private bool #p;

		// Token: 0x04001152 RID: 4434
		[CompilerGenerated]
		private bool #q;

		// Token: 0x04001153 RID: 4435
		[CompilerGenerated]
		private bool #r;
	}
}
