using System;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Media;
using #4vc;
using #7hc;
using #B5c;
using #EWc;
using #Fmc;
using #UYd;
using StructurePoint.CoreAssets.DataExchange.CSV;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace StructurePoint.CoreAssets.GUI.Framework.Model.Entities
{
	// Token: 0x02000C96 RID: 3222
	public sealed class GridLineDefinitionModel : NotifyPropertyChangedObjectBase, #JWc, #I5c
	{
		// Token: 0x0600683C RID: 26684 RVA: 0x000530CC File Offset: 0x000512CC
		public GridLineDefinitionModel(#ewc gridLineData, string label)
		{
			this.#a = gridLineData;
			this.#b = label;
			this.#CXc();
			this.#DXc();
		}

		// Token: 0x0600683D RID: 26685 RVA: 0x000530EE File Offset: 0x000512EE
		public GridLineDefinitionModel(#ewc gridLineData)
		{
			this.#a = gridLineData;
			this.#CXc();
			this.#DXc();
		}

		// Token: 0x17001CDC RID: 7388
		// (get) Token: 0x0600683E RID: 26686 RVA: 0x00053109 File Offset: 0x00051309
		// (set) Token: 0x0600683F RID: 26687 RVA: 0x001954A8 File Offset: 0x001936A8
		public string Label
		{
			get
			{
				return this.#b;
			}
			set
			{
				while (this.#b != value)
				{
					do
					{
						if (!false)
						{
							string propertyName = #Phc.#3hc(107420885);
							if (2 != 0)
							{
								base.RaisePropertyChanging(propertyName);
							}
						}
						this.#b = value;
					}
					while (false);
					if (!false)
					{
						this.#CXc();
					}
					if (!false)
					{
						string propertyName2 = #Phc.#3hc(107420885);
						if (false)
						{
							break;
						}
						base.RaisePropertyChanged(propertyName2);
						break;
					}
				}
			}
		}

		// Token: 0x17001CDD RID: 7389
		// (get) Token: 0x06006840 RID: 26688 RVA: 0x00053111 File Offset: 0x00051311
		// (set) Token: 0x06006841 RID: 26689 RVA: 0x00195510 File Offset: 0x00193710
		public Color Color
		{
			get
			{
				return this.#c;
			}
			set
			{
				while (this.#c != value)
				{
					do
					{
						if (!false)
						{
							string propertyName = #Phc.#3hc(107453335);
							if (2 != 0)
							{
								base.RaisePropertyChanging(propertyName);
							}
						}
						this.#c = value;
					}
					while (false);
					if (!false)
					{
						this.#CXc();
					}
					if (!false)
					{
						string propertyName2 = #Phc.#3hc(107453335);
						if (false)
						{
							break;
						}
						base.RaisePropertyChanged(propertyName2);
						break;
					}
				}
			}
		}

		// Token: 0x06006842 RID: 26690 RVA: 0x00195578 File Offset: 0x00193778
		public bool #J2(GridLineDefinitionModel #bsc)
		{
			string #R0d = #Phc.#3hc(107364483);
			Component #x6c = Component.GUIFramework;
			string #Qic = #Phc.#3hc(107438703);
			if (-1 != 0)
			{
				#X0d.#V0d(#bsc, #R0d, #x6c, #Qic);
			}
			return this == #bsc || (PointsConverter.#uC(this.GridLineData.Location, #bsc.GridLineData.Location) && (2 == 0 || PointsConverter.#qsc(this.Angle, #bsc.Angle))) || #Qsc.#Psc(this.GridLineData.LineSegment, #bsc.GridLineData.LineSegment);
		}

		// Token: 0x06006843 RID: 26691 RVA: 0x00053119 File Offset: 0x00051319
		public GridLineDefinitionModel #dwc(BoundingBoxData #nXc)
		{
			return new GridLineDefinitionModel(new #ewc(this.#a, #nXc), this.#b);
		}

		// Token: 0x17001CDE RID: 7390
		// (get) Token: 0x06006844 RID: 26692 RVA: 0x00053132 File Offset: 0x00051332
		// (set) Token: 0x06006845 RID: 26693 RVA: 0x00195600 File Offset: 0x00193800
		public #ewc GridLineData
		{
			get
			{
				return this.#a;
			}
			set
			{
				if (4 != 0)
				{
					string propertyName = #Phc.#3hc(107438682);
					if (6 != 0)
					{
						base.RaisePropertyChanging(propertyName);
					}
					do
					{
						this.#a = value;
						if (false)
						{
							return;
						}
						if (!false)
						{
							this.#CXc();
						}
					}
					while (3 == 0);
					string propertyName2 = #Phc.#3hc(107438682);
					if (!false)
					{
						base.RaisePropertyChanged(propertyName2);
					}
				}
			}
		}

		// Token: 0x17001CDF RID: 7391
		// (get) Token: 0x06006846 RID: 26694 RVA: 0x00195658 File Offset: 0x00193858
		// (set) Token: 0x06006847 RID: 26695 RVA: 0x00195680 File Offset: 0x00193880
		[CSVColumnName("X")]
		public double LogicalX
		{
			get
			{
				Point point = this.#a.Location;
				Point point2;
				if (7 != 0)
				{
					point2 = point;
				}
				return point2.X;
			}
			set
			{
				Point point = this.#a.Location;
				Point point2;
				if (!false)
				{
					point2 = point;
				}
				if (point2.X != value)
				{
					string propertyName = #Phc.#3hc(107438633);
					if (4 != 0)
					{
						base.RaisePropertyChanging(propertyName);
					}
					#ewc #ewc = this.#a;
					Point point3 = this.GridLineData.Location;
					if (!false)
					{
						point2 = point3;
					}
					Point #tEb = new Point(value, point2.Y);
					if (7 != 0)
					{
						#ewc.#dwc(#tEb);
					}
					if (-1 != 0)
					{
						this.#CXc();
					}
					string propertyName2 = #Phc.#3hc(107438633);
					if (!false)
					{
						base.RaisePropertyChanged(propertyName2);
					}
				}
			}
		}

		// Token: 0x17001CE0 RID: 7392
		// (get) Token: 0x06006848 RID: 26696 RVA: 0x00195714 File Offset: 0x00193914
		// (set) Token: 0x06006849 RID: 26697 RVA: 0x0019573C File Offset: 0x0019393C
		[CSVColumnName("Y")]
		public double LogicalY
		{
			get
			{
				Point point = this.#a.Location;
				Point point2;
				if (7 != 0)
				{
					point2 = point;
				}
				return point2.Y;
			}
			set
			{
				Point point = this.#a.Location;
				Point point2;
				if (!false)
				{
					point2 = point;
				}
				if (point2.Y != value)
				{
					string propertyName = #Phc.#3hc(107438652);
					if (4 != 0)
					{
						base.RaisePropertyChanging(propertyName);
					}
					#ewc #ewc = this.#a;
					Point point3 = this.GridLineData.Location;
					if (!false)
					{
						point2 = point3;
					}
					Point #tEb = new Point(point2.X, value);
					if (7 != 0)
					{
						#ewc.#dwc(#tEb);
					}
					if (-1 != 0)
					{
						this.#CXc();
					}
					string propertyName2 = #Phc.#3hc(107438652);
					if (!false)
					{
						base.RaisePropertyChanged(propertyName2);
					}
				}
			}
		}

		// Token: 0x17001CE1 RID: 7393
		// (get) Token: 0x0600684A RID: 26698 RVA: 0x0005313A File Offset: 0x0005133A
		// (set) Token: 0x0600684B RID: 26699 RVA: 0x001957D0 File Offset: 0x001939D0
		public double Angle
		{
			get
			{
				return this.#a.Angle;
			}
			set
			{
				while (this.#a.Angle != value)
				{
					if (!false)
					{
						string propertyName = #Phc.#3hc(107360678);
						if (!false)
						{
							base.RaisePropertyChanging(propertyName);
						}
						#ewc #ewc = this.#a;
						if (!false)
						{
							#ewc.#dwc(value);
						}
						if (!false)
						{
							this.#CXc();
						}
						do
						{
							if (!false)
							{
								this.#DXc();
							}
						}
						while (false);
						string propertyName2 = #Phc.#3hc(107360678);
						if (6 == 0)
						{
							break;
						}
						base.RaisePropertyChanged(propertyName2);
						break;
					}
				}
			}
		}

		// Token: 0x17001CE2 RID: 7394
		// (get) Token: 0x0600684C RID: 26700 RVA: 0x00053147 File Offset: 0x00051347
		// (set) Token: 0x0600684D RID: 26701 RVA: 0x0005314F File Offset: 0x0005134F
		public int CalculatedHashCode { get; private set; }

		// Token: 0x17001CE3 RID: 7395
		// (get) Token: 0x0600684E RID: 26702 RVA: 0x00053158 File Offset: 0x00051358
		// (set) Token: 0x0600684F RID: 26703 RVA: 0x00053160 File Offset: 0x00051360
		public bool IsDarker { get; set; }

		// Token: 0x17001CE4 RID: 7396
		// (get) Token: 0x06006850 RID: 26704 RVA: 0x00053169 File Offset: 0x00051369
		// (set) Token: 0x06006851 RID: 26705 RVA: 0x0019584C File Offset: 0x00193A4C
		public bool IsLogicalXEnabled
		{
			get
			{
				return this.#d;
			}
			set
			{
				for (;;)
				{
					if (this.#d == value)
					{
						goto IL_36;
					}
					string propertyName = #Phc.#3hc(107438607);
					if (5 != 0)
					{
						base.RaisePropertyChanging(propertyName);
					}
					IL_19:
					if (3 != 0)
					{
						if (false)
						{
							continue;
						}
						this.#d = value;
						string propertyName2 = #Phc.#3hc(107438607);
						if (!false)
						{
							base.RaisePropertyChanged(propertyName2);
						}
					}
					IL_36:
					if (true)
					{
						break;
					}
					goto IL_19;
				}
			}
		}

		// Token: 0x17001CE5 RID: 7397
		// (get) Token: 0x06006852 RID: 26706 RVA: 0x00053171 File Offset: 0x00051371
		// (set) Token: 0x06006853 RID: 26707 RVA: 0x001958A0 File Offset: 0x00193AA0
		public bool IsLogicalYEnabled
		{
			get
			{
				return this.#e;
			}
			set
			{
				for (;;)
				{
					if (this.#e == value)
					{
						goto IL_36;
					}
					string propertyName = #Phc.#3hc(107438614);
					if (5 != 0)
					{
						base.RaisePropertyChanging(propertyName);
					}
					IL_19:
					if (3 != 0)
					{
						if (false)
						{
							continue;
						}
						this.#e = value;
						string propertyName2 = #Phc.#3hc(107438614);
						if (!false)
						{
							base.RaisePropertyChanged(propertyName2);
						}
					}
					IL_36:
					if (true)
					{
						break;
					}
					goto IL_19;
				}
			}
		}

		// Token: 0x06006854 RID: 26708 RVA: 0x00053109 File Offset: 0x00051309
		public string #h()
		{
			return this.#b;
		}

		// Token: 0x06006855 RID: 26709 RVA: 0x001958F4 File Offset: 0x00193AF4
		private void #CXc()
		{
			StringBuilder stringBuilder = new StringBuilder();
			StringBuilder stringBuilder2;
			if (!false)
			{
				stringBuilder2 = stringBuilder;
			}
			if (!string.IsNullOrWhiteSpace(this.#b))
			{
				stringBuilder2.Append(this.#b.ToUpperInvariant());
			}
			stringBuilder2.Append(#Phc.#3hc(107378801));
			stringBuilder2.Append(this.#c);
			stringBuilder2.Append(#Phc.#3hc(107378801));
			stringBuilder2.Append(this.LogicalX);
			stringBuilder2.Append(#Phc.#3hc(107378801));
			stringBuilder2.Append(this.LogicalY);
			stringBuilder2.Append(#Phc.#3hc(107378801));
			stringBuilder2.Append(this.Angle);
			stringBuilder2.Append(#Phc.#3hc(107378801));
			stringBuilder2.Append(this.GridLineData.LineSegment.StartPoint);
			stringBuilder2.Append(#Phc.#3hc(107378801));
			stringBuilder2.Append(this.GridLineData.LineSegment.EndPoint);
			int hashCode = stringBuilder2.ToString().GetHashCode();
			if (!false)
			{
				this.CalculatedHashCode = hashCode;
			}
		}

		// Token: 0x06006856 RID: 26710 RVA: 0x00195A24 File Offset: 0x00193C24
		private void #DXc()
		{
			if (this.#a.Angle != 0.0)
			{
				if (false)
				{
					goto IL_20;
				}
				bool flag = true;
				if (false)
				{
					goto IL_32;
				}
				this.IsLogicalXEnabled = flag;
				goto IL_32;
			}
			IL_16:
			if (false)
			{
				goto IL_32;
			}
			bool flag2 = false;
			if (!false)
			{
				this.IsLogicalXEnabled = flag2;
			}
			IL_20:
			bool flag3 = true;
			if (!false)
			{
				this.IsLogicalYEnabled = flag3;
			}
			return;
			IL_32:
			bool flag4 = false;
			if (!false)
			{
				this.IsLogicalYEnabled = flag4;
			}
			if (!false)
			{
				return;
			}
			goto IL_16;
		}

		// Token: 0x04002AE0 RID: 10976
		private #ewc #a;

		// Token: 0x04002AE1 RID: 10977
		private string #b;

		// Token: 0x04002AE2 RID: 10978
		private Color #c;

		// Token: 0x04002AE3 RID: 10979
		private bool #d;

		// Token: 0x04002AE4 RID: 10980
		private bool #e;

		// Token: 0x04002AE5 RID: 10981
		[CompilerGenerated]
		private int #f;

		// Token: 0x04002AE6 RID: 10982
		[CompilerGenerated]
		private bool #g;
	}
}
