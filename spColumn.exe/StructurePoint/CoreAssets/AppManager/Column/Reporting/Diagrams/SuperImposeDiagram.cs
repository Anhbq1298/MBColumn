using System;
using System.Windows.Media;
using #7hc;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using Svg;

namespace StructurePoint.CoreAssets.AppManager.Column.Reporting.Diagrams
{
	// Token: 0x0200120C RID: 4620
	public sealed class SuperImposeDiagram : NotifyPropertyChangedObjectBase
	{
		// Token: 0x17002CE2 RID: 11490
		// (get) Token: 0x06009AD7 RID: 39639 RVA: 0x0007A871 File Offset: 0x00078A71
		// (set) Token: 0x06009AD8 RID: 39640 RVA: 0x0007A879 File Offset: 0x00078A79
		public UniCurve[] UniCurve
		{
			get
			{
				return this.uniCurve;
			}
			set
			{
				this.SetProperty<UniCurve[]>(ref this.uniCurve, value, #Phc.#3hc(107283020));
			}
		}

		// Token: 0x17002CE3 RID: 11491
		// (get) Token: 0x06009AD9 RID: 39641 RVA: 0x0007A893 File Offset: 0x00078A93
		// (set) Token: 0x06009ADA RID: 39642 RVA: 0x0007A89B File Offset: 0x00078A9B
		public BiCurve BiCurve
		{
			get
			{
				return this.biCurve;
			}
			set
			{
				this.SetProperty<BiCurve>(ref this.biCurve, value, #Phc.#3hc(107283039));
			}
		}

		// Token: 0x17002CE4 RID: 11492
		// (get) Token: 0x06009ADB RID: 39643 RVA: 0x0007A8B5 File Offset: 0x00078AB5
		// (set) Token: 0x06009ADC RID: 39644 RVA: 0x0007A8BD File Offset: 0x00078ABD
		public BiCurve[] BiCurves
		{
			get
			{
				return this.biCurves;
			}
			set
			{
				this.SetProperty<BiCurve[]>(ref this.biCurves, value, #Phc.#3hc(107283026));
			}
		}

		// Token: 0x17002CE5 RID: 11493
		// (get) Token: 0x06009ADD RID: 39645 RVA: 0x0007A8D7 File Offset: 0x00078AD7
		// (set) Token: 0x06009ADE RID: 39646 RVA: 0x0007A8DF File Offset: 0x00078ADF
		public string Label
		{
			get
			{
				return this.label;
			}
			set
			{
				this.SetProperty<string>(ref this.label, value, #Phc.#3hc(107420885));
			}
		}

		// Token: 0x17002CE6 RID: 11494
		// (get) Token: 0x06009ADF RID: 39647 RVA: 0x0007A8F9 File Offset: 0x00078AF9
		// (set) Token: 0x06009AE0 RID: 39648 RVA: 0x0007A901 File Offset: 0x00078B01
		public SvgUnitCollection LineType
		{
			get
			{
				return this.lineType;
			}
			set
			{
				this.SetProperty<SvgUnitCollection>(ref this.lineType, value, #Phc.#3hc(107282981));
			}
		}

		// Token: 0x17002CE7 RID: 11495
		// (get) Token: 0x06009AE1 RID: 39649 RVA: 0x0007A91B File Offset: 0x00078B1B
		// (set) Token: 0x06009AE2 RID: 39650 RVA: 0x0007A923 File Offset: 0x00078B23
		public Color Color
		{
			get
			{
				return this.color;
			}
			set
			{
				this.SetProperty<Color>(ref this.color, value, #Phc.#3hc(107453335));
			}
		}

		// Token: 0x17002CE8 RID: 11496
		// (get) Token: 0x06009AE3 RID: 39651 RVA: 0x0007A93D File Offset: 0x00078B3D
		// (set) Token: 0x06009AE4 RID: 39652 RVA: 0x0007A945 File Offset: 0x00078B45
		public bool IsEnabled
		{
			get
			{
				return this.isEnabled;
			}
			set
			{
				this.SetProperty<bool>(ref this.isEnabled, value, #Phc.#3hc(107408148));
			}
		}

		// Token: 0x17002CE9 RID: 11497
		// (get) Token: 0x06009AE5 RID: 39653 RVA: 0x0007A95F File Offset: 0x00078B5F
		// (set) Token: 0x06009AE6 RID: 39654 RVA: 0x0007A967 File Offset: 0x00078B67
		public string FilePath { get; set; }

		// Token: 0x17002CEA RID: 11498
		// (get) Token: 0x06009AE7 RID: 39655 RVA: 0x0007A970 File Offset: 0x00078B70
		// (set) Token: 0x06009AE8 RID: 39656 RVA: 0x0007A978 File Offset: 0x00078B78
		public Action OnUpdatedCallback { get; set; }

		// Token: 0x06009AE9 RID: 39657 RVA: 0x0020E7A0 File Offset: 0x0020C9A0
		public SuperImposeDiagram Copy()
		{
			return new SuperImposeDiagram
			{
				UniCurve = this.UniCurve,
				BiCurve = this.BiCurve,
				BiCurves = this.BiCurves,
				Label = this.Label,
				LineType = this.LineType,
				Color = this.Color,
				IsEnabled = this.IsEnabled,
				FilePath = this.FilePath
			};
		}

		// Token: 0x06009AEA RID: 39658 RVA: 0x0020E814 File Offset: 0x0020CA14
		public bool Equals(SuperImposeDiagram other)
		{
			return string.Equals(this.Label, other.Label) && this.IsEnabled == other.IsEnabled && !(this.Color != other.Color) && this.LineType == other.LineType && this.UniCurve == other.UniCurve && this.BiCurve == other.BiCurve && this.BiCurves == other.BiCurves;
		}

		// Token: 0x040042AA RID: 17066
		private UniCurve[] uniCurve;

		// Token: 0x040042AB RID: 17067
		private BiCurve biCurve;

		// Token: 0x040042AC RID: 17068
		private BiCurve[] biCurves;

		// Token: 0x040042AD RID: 17069
		private string label;

		// Token: 0x040042AE RID: 17070
		private SvgUnitCollection lineType;

		// Token: 0x040042AF RID: 17071
		private Color color;

		// Token: 0x040042B0 RID: 17072
		private bool isEnabled;
	}
}
