using System;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using Ab3d.Visuals;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Data
{
	// Token: 0x02000A10 RID: 2576
	public sealed class SphereDrawingResult : DrawingResultBase, IDrawingResult, ISphereDrawingResult
	{
		// Token: 0x060054F1 RID: 21745 RVA: 0x000465B3 File Offset: 0x000447B3
		public SphereDrawingResult()
		{
			this.SphereVisual = new SphereVisual3D();
		}

		// Token: 0x17001874 RID: 6260
		// (get) Token: 0x060054F2 RID: 21746 RVA: 0x000465C6 File Offset: 0x000447C6
		// (set) Token: 0x060054F3 RID: 21747 RVA: 0x000465D2 File Offset: 0x000447D2
		internal SphereVisual3D SphereVisual { get; private set; }

		// Token: 0x17001875 RID: 6261
		// (get) Token: 0x060054F4 RID: 21748 RVA: 0x000465E3 File Offset: 0x000447E3
		// (set) Token: 0x060054F5 RID: 21749 RVA: 0x00164C94 File Offset: 0x00162E94
		public Color Color
		{
			get
			{
				return this.color;
			}
			set
			{
				if (this.color != value)
				{
					this.color = value;
					DiffuseMaterial material = new DiffuseMaterial(new SolidColorBrush(value));
					this.SphereVisual.Material = material;
				}
			}
		}

		// Token: 0x17001876 RID: 6262
		// (get) Token: 0x060054F6 RID: 21750 RVA: 0x000465EF File Offset: 0x000447EF
		// (set) Token: 0x060054F7 RID: 21751 RVA: 0x0004660D File Offset: 0x0004480D
		public StructurePoint.CoreAssets.Infrastructure.Data.Point3D Center
		{
			get
			{
				return this.SphereVisual.CenterPosition.Convert();
			}
			set
			{
				this.SphereVisual.CenterPosition = value.Convert();
			}
		}

		// Token: 0x17001877 RID: 6263
		// (get) Token: 0x060054F8 RID: 21752 RVA: 0x0004662C File Offset: 0x0004482C
		// (set) Token: 0x060054F9 RID: 21753 RVA: 0x00046645 File Offset: 0x00044845
		public double Radius
		{
			get
			{
				return this.SphereVisual.Radius;
			}
			set
			{
				this.SphereVisual.Radius = value;
			}
		}

		// Token: 0x060054FA RID: 21754 RVA: 0x0004665F File Offset: 0x0004485F
		protected internal override object RetrieveDisplayedObject()
		{
			return this.SphereVisual;
		}

		// Token: 0x0400244C RID: 9292
		private Color color;
	}
}
