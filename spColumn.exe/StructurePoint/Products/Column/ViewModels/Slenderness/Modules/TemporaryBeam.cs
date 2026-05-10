using System;
using #7hc;
using #lH;
using #M7;
using #n8;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.Products.Column.Model.Entities;
using StructurePoint.Products.Column.Model.Validation.API.Slenderness;
using StructurePoint.Products.Column.Services.API;
using StructurePoint.Products.Column.Services.API.Slenderness;
using StructurePoint.Products.Column.Views.Slenderness;
using Telerik.Windows.Data;

namespace StructurePoint.Products.Column.ViewModels.Slenderness.Modules
{
	// Token: 0x0200015F RID: 351
	internal sealed class TemporaryBeam : #HH<BeamsFormView>, #q8<#o8>, #o8, IBeam
	{
		// Token: 0x06000B07 RID: 2823 RVA: 0x0000E47C File Offset: 0x0000C67C
		public TemporaryBeam(Lazy<BeamsFormView> view, ICoreServices services, IBeamsCalculator calculator, ISlendernessBeamsValidator validator, BeamFormProperties formProperties) : base(view, services)
		{
			this.view = view;
			this.calculator = calculator;
			this.validator = validator;
			this.<LastValid>k__BackingField = new StructurePoint.Products.Column.Model.Entities.Beam();
			this.<FormProperties>k__BackingField = formProperties;
		}

		// Token: 0x17000475 RID: 1141
		// (get) Token: 0x06000B08 RID: 2824 RVA: 0x0000E4AF File Offset: 0x0000C6AF
		// (set) Token: 0x06000B09 RID: 2825 RVA: 0x00099C2C File Offset: 0x00097E2C
		public BeamType BeamType
		{
			get
			{
				return this.beamType;
			}
			set
			{
				BeamType beamType = this.BeamType;
				base.#KH<BeamType>(ref this.beamType, value, this.validator, null, #Phc.#3hc(107412484));
				if (beamType != value)
				{
					this.OnBeamTypeChanged(beamType, value);
				}
			}
		}

		// Token: 0x17000476 RID: 1142
		// (get) Token: 0x06000B0A RID: 2826 RVA: 0x0000E4BB File Offset: 0x0000C6BB
		// (set) Token: 0x06000B0B RID: 2827 RVA: 0x0000E4C7 File Offset: 0x0000C6C7
		public float Length
		{
			get
			{
				return this.length;
			}
			set
			{
				base.#KH<float>(ref this.length, value, this.validator, null, #Phc.#3hc(107412503));
				this.UpdateLastValid();
			}
		}

		// Token: 0x17000477 RID: 1143
		// (get) Token: 0x06000B0C RID: 2828 RVA: 0x0000E4FA File Offset: 0x0000C6FA
		// (set) Token: 0x06000B0D RID: 2829 RVA: 0x0000E506 File Offset: 0x0000C706
		public float Width
		{
			get
			{
				return this.width;
			}
			set
			{
				base.#KH<float>(ref this.width, value, this.validator, null, #Phc.#3hc(107412974));
				this.CalculateInertiaIfNecessary();
				this.UpdateLastValid();
			}
		}

		// Token: 0x17000478 RID: 1144
		// (get) Token: 0x06000B0E RID: 2830 RVA: 0x0000E53F File Offset: 0x0000C73F
		// (set) Token: 0x06000B0F RID: 2831 RVA: 0x0000E54B File Offset: 0x0000C74B
		public float Depth
		{
			get
			{
				return this.depth;
			}
			set
			{
				base.#KH<float>(ref this.depth, value, this.validator, null, #Phc.#3hc(107412965));
				this.CalculateInertiaIfNecessary();
				this.UpdateLastValid();
			}
		}

		// Token: 0x17000479 RID: 1145
		// (get) Token: 0x06000B10 RID: 2832 RVA: 0x0000E584 File Offset: 0x0000C784
		// (set) Token: 0x06000B11 RID: 2833 RVA: 0x0000E590 File Offset: 0x0000C790
		public float MofI
		{
			get
			{
				return this.mofI;
			}
			set
			{
				base.#KH<float>(ref this.mofI, value, this.validator, null, #Phc.#3hc(107412988));
				this.UpdateLastValid();
			}
		}

		// Token: 0x1700047A RID: 1146
		// (get) Token: 0x06000B12 RID: 2834 RVA: 0x0000E5C3 File Offset: 0x0000C7C3
		// (set) Token: 0x06000B13 RID: 2835 RVA: 0x0000E5CF File Offset: 0x0000C7CF
		public float Fcp
		{
			get
			{
				return this.fcp;
			}
			set
			{
				base.#KH<float>(ref this.fcp, value, this.validator, null, #Phc.#3hc(107412979));
				this.CalculateElasticityIfNecessary();
				this.UpdateLastValid();
			}
		}

		// Token: 0x1700047B RID: 1147
		// (get) Token: 0x06000B14 RID: 2836 RVA: 0x0000E608 File Offset: 0x0000C808
		// (set) Token: 0x06000B15 RID: 2837 RVA: 0x0000E614 File Offset: 0x0000C814
		public float Ec
		{
			get
			{
				return this.ec;
			}
			set
			{
				base.#KH<float>(ref this.ec, value, this.validator, null, #Phc.#3hc(107412942));
				this.UpdateLastValid();
			}
		}

		// Token: 0x1700047C RID: 1148
		// (get) Token: 0x06000B16 RID: 2838 RVA: 0x0000E647 File Offset: 0x0000C847
		// (set) Token: 0x06000B17 RID: 2839 RVA: 0x00099C78 File Offset: 0x00097E78
		public bool IsConcreteStandard
		{
			get
			{
				return this.isConcreteStandard;
			}
			set
			{
				if (base.#KH<bool>(ref this.isConcreteStandard, value, this.validator, null, #Phc.#3hc(107412937)))
				{
					base.#NH(this.validator, new string[]
					{
						#Phc.#3hc(107412979)
					});
				}
				this.CalculateElasticityIfNecessary();
			}
		}

		// Token: 0x1700047D RID: 1149
		// (get) Token: 0x06000B18 RID: 2840 RVA: 0x0000E653 File Offset: 0x0000C853
		// (set) Token: 0x06000B19 RID: 2841 RVA: 0x0000E65F File Offset: 0x0000C85F
		public bool IsInertiaStandard
		{
			get
			{
				return this.isInertiaStandard;
			}
			set
			{
				base.#KH<bool>(ref this.isInertiaStandard, value, this.validator, null, #Phc.#3hc(107412944));
				this.CalculateInertiaIfNecessary();
			}
		}

		// Token: 0x1700047E RID: 1150
		// (get) Token: 0x06000B1A RID: 2842 RVA: 0x0000E692 File Offset: 0x0000C892
		public StructurePoint.Products.Column.Model.Entities.Beam LastValid { get; }

		// Token: 0x1700047F RID: 1151
		// (get) Token: 0x06000B1B RID: 2843 RVA: 0x0000E69E File Offset: 0x0000C89E
		public BeamFormProperties FormProperties { get; }

		// Token: 0x17000480 RID: 1152
		// (get) Token: 0x06000B1C RID: 2844 RVA: 0x0000E6AA File Offset: 0x0000C8AA
		public static RadObservableCollection<ComboItem<BeamType>> AvailableBeamModes { get; } = new RadObservableCollection<ComboItem<BeamType>>
		{
			new ComboItem<BeamType>(BeamType.None, Strings.StringNone),
			new ComboItem<BeamType>(BeamType.Rectangular, Strings.StringRectangular),
			new ComboItem<BeamType>(BeamType.Rigid, Strings.StringRigid)
		};

		// Token: 0x17000481 RID: 1153
		// (get) Token: 0x06000B1D RID: 2845 RVA: 0x0000E6B1 File Offset: 0x0000C8B1
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x06000B1E RID: 2846 RVA: 0x00099CD8 File Offset: 0x00097ED8
		public void CopyFrom(#o8 source)
		{
			this.beamType = source.BeamType;
			this.length = source.Length;
			this.width = source.Width;
			this.depth = source.Depth;
			this.mofI = source.MofI;
			this.fcp = source.Fcp;
			this.ec = source.Ec;
			this.isConcreteStandard = source.IsConcreteStandard;
			this.isInertiaStandard = source.IsInertiaStandard;
			this.CalculateElasticityIfNecessary();
			this.CalculateInertiaIfNecessary();
			base.RefreshInterfaceProperties<IBeam>();
			base.#PH<IBeam>(this.validator, null);
		}

		// Token: 0x06000B1F RID: 2847 RVA: 0x0000E6C1 File Offset: 0x0000C8C1
		public void ValidateBeam()
		{
			base.#PH<IBeam>(this.validator, null);
		}

		// Token: 0x06000B20 RID: 2848 RVA: 0x0000E6DD File Offset: 0x0000C8DD
		public void ValidateBeamOnPanelActivated()
		{
			base.#PH<IBeam, BeamsFormView>(this.validator, this.view, base.Services.MouseAndKeyboard);
		}

		// Token: 0x06000B21 RID: 2849 RVA: 0x00099D90 File Offset: 0x00097F90
		private void OnBeamTypeChanged(BeamType oldValue, BeamType currentValue)
		{
			StructurePoint.Products.Column.Model.Entities.Beam defaultBeamValue = this.GetDefaultBeamValue(currentValue);
			this.CopyFrom(defaultBeamValue);
		}

		// Token: 0x06000B22 RID: 2850 RVA: 0x0000E709 File Offset: 0x0000C909
		private StructurePoint.Products.Column.Model.Entities.Beam GetDefaultBeamValue(BeamType beamType)
		{
			if (beamType == BeamType.Rectangular)
			{
				return #d8.#87(base.Services.Project.Model);
			}
			if (beamType != BeamType.Rigid)
			{
				return #d8.#77();
			}
			return #d8.#97();
		}

		// Token: 0x06000B23 RID: 2851 RVA: 0x0000E742 File Offset: 0x0000C942
		private void CalculateElasticityIfNecessary()
		{
			if (!this.IsConcreteStandard || base.CheckIfPropertyHasErrors(#Phc.#3hc(107412979)))
			{
				return;
			}
			this.Ec = this.calculator.#2Q(this.Fcp);
		}

		// Token: 0x06000B24 RID: 2852 RVA: 0x00099DB8 File Offset: 0x00097FB8
		private void CalculateInertiaIfNecessary()
		{
			bool flag = base.CheckIfPropertyHasErrors(#Phc.#3hc(107412965)) || base.CheckIfPropertyHasErrors(#Phc.#3hc(107412974));
			if (this.BeamType == BeamType.None || !this.IsInertiaStandard || flag)
			{
				return;
			}
			this.MofI = this.calculator.#4Q(this.Depth, this.Width);
		}

		// Token: 0x06000B25 RID: 2853 RVA: 0x0000E782 File Offset: 0x0000C982
		private void UpdateLastValid()
		{
			if (this.HasErrors)
			{
				return;
			}
			this.LastValid.CopyFrom(this);
		}

		// Token: 0x0400040F RID: 1039
		private BeamType beamType;

		// Token: 0x04000410 RID: 1040
		private float length;

		// Token: 0x04000411 RID: 1041
		private float width;

		// Token: 0x04000412 RID: 1042
		private float depth;

		// Token: 0x04000413 RID: 1043
		private float mofI;

		// Token: 0x04000414 RID: 1044
		private float fcp;

		// Token: 0x04000415 RID: 1045
		private float ec;

		// Token: 0x04000416 RID: 1046
		private bool isConcreteStandard;

		// Token: 0x04000417 RID: 1047
		private bool isInertiaStandard;

		// Token: 0x04000418 RID: 1048
		private readonly Lazy<BeamsFormView> view;

		// Token: 0x04000419 RID: 1049
		private readonly IBeamsCalculator calculator;

		// Token: 0x0400041A RID: 1050
		private readonly ISlendernessBeamsValidator validator;
	}
}
