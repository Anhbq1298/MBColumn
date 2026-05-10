using System;
using System.Diagnostics.CodeAnalysis;
using #7hc;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Data
{
	// Token: 0x02000A2B RID: 2603
	public sealed class Position : NotifyPropertyChangedObjectBase
	{
		// Token: 0x0600563E RID: 22078 RVA: 0x0004774E File Offset: 0x0004594E
		[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "x")]
		[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "y")]
		[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "z")]
		public Position(double x, double y, double z) : this()
		{
			this.coordinateX = x;
			this.coordinateY = y;
			this.coordinateZ = z;
		}

		// Token: 0x0600563F RID: 22079 RVA: 0x0004776B File Offset: 0x0004596B
		public Position()
		{
			this.isEmpty = false;
		}

		// Token: 0x06005640 RID: 22080 RVA: 0x0004777A File Offset: 0x0004597A
		public Position(bool isEmpty)
		{
			this.isEmpty = isEmpty;
		}

		// Token: 0x06005641 RID: 22081 RVA: 0x00047789 File Offset: 0x00045989
		public void Update(Point point)
		{
			this.CoordinateX = point.X;
			this.CoordinateY = point.Y;
			this.IsEmpty = false;
		}

		// Token: 0x06005642 RID: 22082 RVA: 0x001658F4 File Offset: 0x00163AF4
		public void Update(Point? point)
		{
			if (point != null)
			{
				this.CoordinateX = point.Value.X;
				this.CoordinateY = point.Value.Y;
			}
			this.IsEmpty = (point == null);
		}

		// Token: 0x06005643 RID: 22083 RVA: 0x00165950 File Offset: 0x00163B50
		public void Update(Point3D? point3D)
		{
			if (point3D != null)
			{
				this.CoordinateX = point3D.Value.X;
				this.CoordinateY = point3D.Value.Y;
				this.CoordinateZ = point3D.Value.Z;
			}
			this.IsEmpty = (point3D == null);
		}

		// Token: 0x06005644 RID: 22084 RVA: 0x001659C4 File Offset: 0x00163BC4
		public void Clear()
		{
			this.Update(null);
		}

		// Token: 0x170018D9 RID: 6361
		// (get) Token: 0x06005645 RID: 22085 RVA: 0x000477B8 File Offset: 0x000459B8
		// (set) Token: 0x06005646 RID: 22086 RVA: 0x000477C4 File Offset: 0x000459C4
		public bool IsEmpty
		{
			get
			{
				return this.isEmpty;
			}
			set
			{
				if (this.isEmpty != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107429430));
					this.isEmpty = value;
					base.RaisePropertyChanged(#Phc.#3hc(107429430));
				}
			}
		}

		// Token: 0x170018DA RID: 6362
		// (get) Token: 0x06005647 RID: 22087 RVA: 0x00047802 File Offset: 0x00045A02
		// (set) Token: 0x06005648 RID: 22088 RVA: 0x0004780E File Offset: 0x00045A0E
		public double CoordinateY
		{
			get
			{
				return this.coordinateY;
			}
			set
			{
				if (this.coordinateY != value)
				{
					this.coordinateY = value;
					base.RaisePropertyChanged(#Phc.#3hc(107429385));
				}
			}
		}

		// Token: 0x170018DB RID: 6363
		// (get) Token: 0x06005649 RID: 22089 RVA: 0x0004783C File Offset: 0x00045A3C
		// (set) Token: 0x0600564A RID: 22090 RVA: 0x00047848 File Offset: 0x00045A48
		public double CoordinateZ
		{
			get
			{
				return this.coordinateZ;
			}
			set
			{
				if (this.coordinateZ != value)
				{
					this.coordinateZ = value;
					base.RaisePropertyChanged(#Phc.#3hc(107429400));
				}
			}
		}

		// Token: 0x170018DC RID: 6364
		// (get) Token: 0x0600564B RID: 22091 RVA: 0x00047876 File Offset: 0x00045A76
		// (set) Token: 0x0600564C RID: 22092 RVA: 0x00047882 File Offset: 0x00045A82
		public double CoordinateX
		{
			get
			{
				return this.coordinateX;
			}
			set
			{
				if (this.coordinateX != value)
				{
					this.coordinateX = value;
					base.RaisePropertyChanged(#Phc.#3hc(107429863));
				}
			}
		}

		// Token: 0x04002481 RID: 9345
		private double coordinateX;

		// Token: 0x04002482 RID: 9346
		private double coordinateY;

		// Token: 0x04002483 RID: 9347
		private double coordinateZ;

		// Token: 0x04002484 RID: 9348
		private bool isEmpty;
	}
}
