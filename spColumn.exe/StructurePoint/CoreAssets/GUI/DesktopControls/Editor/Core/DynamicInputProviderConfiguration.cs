using System;
using System.Windows;
using #7hc;
using devDept.Geometry;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.Units.Formatters;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core
{
	// Token: 0x02000B0C RID: 2828
	public sealed class DynamicInputProviderConfiguration : NotifyPropertyChangedObjectBase
	{
		// Token: 0x06005C74 RID: 23668 RVA: 0x00173DAC File Offset: 0x00171FAC
		public DynamicInputProviderConfiguration()
		{
			this.XValue.Label = #Phc.#3hc(107408964);
			this.YValue.Label = #Phc.#3hc(107408991);
		}

		// Token: 0x17001A59 RID: 6745
		// (get) Token: 0x06005C75 RID: 23669 RVA: 0x0004D235 File Offset: 0x0004B435
		// (set) Token: 0x06005C76 RID: 23670 RVA: 0x0004D23D File Offset: 0x0004B43D
		public bool Enabled { get; set; }

		// Token: 0x17001A5A RID: 6746
		// (get) Token: 0x06005C77 RID: 23671 RVA: 0x0004D246 File Offset: 0x0004B446
		// (set) Token: 0x06005C78 RID: 23672 RVA: 0x0004D24E File Offset: 0x0004B44E
		public bool DisableOverride { get; set; }

		// Token: 0x17001A5B RID: 6747
		// (get) Token: 0x06005C79 RID: 23673 RVA: 0x0004D257 File Offset: 0x0004B457
		// (set) Token: 0x06005C7A RID: 23674 RVA: 0x0004D25F File Offset: 0x0004B45F
		public bool ShowPrompt { get; set; }

		// Token: 0x17001A5C RID: 6748
		// (get) Token: 0x06005C7B RID: 23675 RVA: 0x0004D268 File Offset: 0x0004B468
		// (set) Token: 0x06005C7C RID: 23676 RVA: 0x0004D270 File Offset: 0x0004B470
		public bool ShowInputBoxes { get; set; }

		// Token: 0x17001A5D RID: 6749
		// (get) Token: 0x06005C7D RID: 23677 RVA: 0x0004D279 File Offset: 0x0004B479
		// (set) Token: 0x06005C7E RID: 23678 RVA: 0x0004D286 File Offset: 0x0004B486
		public int Precision
		{
			get
			{
				return this.CoordinateFormatter.Precision;
			}
			set
			{
				this.CoordinateFormatter.Precision = value;
			}
		}

		// Token: 0x17001A5E RID: 6750
		// (get) Token: 0x06005C7F RID: 23679 RVA: 0x0004D294 File Offset: 0x0004B494
		// (set) Token: 0x06005C80 RID: 23680 RVA: 0x0004D29C File Offset: 0x0004B49C
		public bool ShowInputBoxesOverride { get; set; }

		// Token: 0x17001A5F RID: 6751
		// (get) Token: 0x06005C81 RID: 23681 RVA: 0x0004D2A5 File Offset: 0x0004B4A5
		// (set) Token: 0x06005C82 RID: 23682 RVA: 0x0004D2AD File Offset: 0x0004B4AD
		public bool Active { get; set; }

		// Token: 0x17001A60 RID: 6752
		// (get) Token: 0x06005C83 RID: 23683 RVA: 0x0004D2B6 File Offset: 0x0004B4B6
		public bool EnabledAndActive
		{
			get
			{
				return this.Enabled && this.Active && !this.DisableOverride;
			}
		}

		// Token: 0x17001A61 RID: 6753
		// (get) Token: 0x06005C84 RID: 23684 RVA: 0x0004D2D3 File Offset: 0x0004B4D3
		public bool EnabledAndActiveOverride
		{
			get
			{
				return (this.Enabled || this.EnabledOverride) && this.Active && !this.DisableOverride;
			}
		}

		// Token: 0x17001A62 RID: 6754
		// (get) Token: 0x06005C85 RID: 23685 RVA: 0x0004D2F8 File Offset: 0x0004B4F8
		// (set) Token: 0x06005C86 RID: 23686 RVA: 0x0004D300 File Offset: 0x0004B500
		public bool EnabledOverride { get; set; }

		// Token: 0x17001A63 RID: 6755
		// (get) Token: 0x06005C87 RID: 23687 RVA: 0x0004D309 File Offset: 0x0004B509
		// (set) Token: 0x06005C88 RID: 23688 RVA: 0x0004D311 File Offset: 0x0004B511
		public string Prompt
		{
			get
			{
				return this.prompt;
			}
			set
			{
				if (this.prompt != value)
				{
					this.prompt = value;
					base.RaisePropertyChanged(#Phc.#3hc(107421464));
				}
			}
		}

		// Token: 0x17001A64 RID: 6756
		// (get) Token: 0x06005C89 RID: 23689 RVA: 0x0004D338 File Offset: 0x0004B538
		// (set) Token: 0x06005C8A RID: 23690 RVA: 0x0004D340 File Offset: 0x0004B540
		public bool EnableDisplayOnly { get; set; }

		// Token: 0x17001A65 RID: 6757
		// (get) Token: 0x06005C8B RID: 23691 RVA: 0x0004D349 File Offset: 0x0004B549
		// (set) Token: 0x06005C8C RID: 23692 RVA: 0x0004D351 File Offset: 0x0004B551
		public IUnitValueFormatter CoordinateFormatter
		{
			get
			{
				return this.coordinateFormatter;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException(#Phc.#3hc(107386484));
				}
				if (this.coordinateFormatter != value)
				{
					this.coordinateFormatter = value;
					base.RaisePropertyChanged(#Phc.#3hc(107420911));
				}
			}
		}

		// Token: 0x17001A66 RID: 6758
		// (get) Token: 0x06005C8D RID: 23693 RVA: 0x0004D386 File Offset: 0x0004B586
		public DynamicInputValueConfiguration XValue { get; } = new DynamicInputValueConfiguration();

		// Token: 0x17001A67 RID: 6759
		// (get) Token: 0x06005C8E RID: 23694 RVA: 0x0004D38E File Offset: 0x0004B58E
		public DynamicInputValueConfiguration YValue { get; } = new DynamicInputValueConfiguration();

		// Token: 0x17001A68 RID: 6760
		// (get) Token: 0x06005C8F RID: 23695 RVA: 0x0004D396 File Offset: 0x0004B596
		// (set) Token: 0x06005C90 RID: 23696 RVA: 0x0004D39E File Offset: 0x0004B59E
		public Point3D LastInputPoint
		{
			get
			{
				return this.lastInputPoint;
			}
			set
			{
				if (this.lastInputPoint != value)
				{
					this.lastInputPoint = value;
				}
			}
		}

		// Token: 0x17001A69 RID: 6761
		// (get) Token: 0x06005C91 RID: 23697 RVA: 0x0004D3B5 File Offset: 0x0004B5B5
		// (set) Token: 0x06005C92 RID: 23698 RVA: 0x0004D3BD File Offset: 0x0004B5BD
		public Point3D LastOriginPoint
		{
			get
			{
				return this.lastOriginPoint;
			}
			set
			{
				if (this.lastOriginPoint != value)
				{
					this.lastOriginPoint = value;
				}
			}
		}

		// Token: 0x17001A6A RID: 6762
		// (get) Token: 0x06005C93 RID: 23699 RVA: 0x0004D3D4 File Offset: 0x0004B5D4
		// (set) Token: 0x06005C94 RID: 23700 RVA: 0x00173E0C File Offset: 0x0017200C
		public DynamicInputMode Mode
		{
			get
			{
				return this.mode;
			}
			set
			{
				this.LastInputPoint = null;
				this.EnableDisplayOnly = false;
				switch (value)
				{
				case DynamicInputMode.Regular:
					this.XValue.Label = #Phc.#3hc(107408964);
					this.YValue.Label = #Phc.#3hc(107408991);
					this.XValue.Enabled = (this.YValue.Enabled = true);
					this.XValue.Visibility = (this.YValue.Visibility = Visibility.Visible);
					break;
				case DynamicInputMode.Relative:
					this.XValue.Label = #Phc.#3hc(107420914);
					this.YValue.Label = #Phc.#3hc(107420877);
					this.XValue.Enabled = (this.YValue.Enabled = true);
					this.XValue.Visibility = (this.YValue.Visibility = Visibility.Visible);
					break;
				case DynamicInputMode.RelativeRectangle:
					this.XValue.Label = #Phc.#3hc(107386856);
					this.YValue.Label = #Phc.#3hc(107420872);
					this.XValue.Enabled = (this.YValue.Enabled = true);
					this.XValue.Visibility = (this.YValue.Visibility = Visibility.Visible);
					break;
				case DynamicInputMode.RelativeRadius:
					this.XValue.Label = #Phc.#3hc(107369231);
					this.XValue.Enabled = true;
					this.YValue.Enabled = false;
					this.XValue.Visibility = Visibility.Visible;
					this.YValue.Visibility = Visibility.Collapsed;
					break;
				case DynamicInputMode.Angle:
				case DynamicInputMode.RelativeAngle:
					this.XValue.Label = #Phc.#3hc(107360678);
					this.XValue.Enabled = true;
					this.YValue.Enabled = false;
					this.XValue.Unit = #Phc.#3hc(107360221);
					this.XValue.Visibility = Visibility.Visible;
					this.YValue.Visibility = Visibility.Collapsed;
					break;
				case DynamicInputMode.Offset:
					this.XValue.Label = #Phc.#3hc(107420867);
					this.XValue.Enabled = true;
					this.YValue.Enabled = false;
					this.XValue.Visibility = Visibility.Visible;
					this.YValue.Visibility = Visibility.Collapsed;
					break;
				default:
					throw new ArgumentOutOfRangeException(#Phc.#3hc(107386484), value, null);
				}
				this.mode = value;
				base.RaisePropertyChanged(#Phc.#3hc(107420894));
			}
		}

		// Token: 0x17001A6B RID: 6763
		// (get) Token: 0x06005C95 RID: 23701 RVA: 0x0004D3DC File Offset: 0x0004B5DC
		// (set) Token: 0x06005C96 RID: 23702 RVA: 0x0004D3E4 File Offset: 0x0004B5E4
		public Func<double, double> AngleModifier { get; set; }

		// Token: 0x06005C97 RID: 23703 RVA: 0x0004D3ED File Offset: 0x0004B5ED
		public bool ShouldShowInputBoxes()
		{
			return this.ShowInputBoxes && this.ShowInputBoxesOverride;
		}

		// Token: 0x0400267B RID: 9851
		private string prompt;

		// Token: 0x0400267C RID: 9852
		private DynamicInputMode mode;

		// Token: 0x0400267D RID: 9853
		private IUnitValueFormatter coordinateFormatter = new FloatingPointUnitValueFormatter(2);

		// Token: 0x0400267E RID: 9854
		private Point3D lastInputPoint;

		// Token: 0x0400267F RID: 9855
		private Point3D lastOriginPoint;
	}
}
