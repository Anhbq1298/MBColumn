using System;
using #7hc;
using #9pe;
using #lH;
using #M7;
using #n8;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.Products.Column.Model;
using StructurePoint.Products.Column.Model.Entities;
using StructurePoint.Products.Column.Model.Validation.API.Slenderness;
using StructurePoint.Products.Column.Services.API;
using StructurePoint.Products.Column.Services.API.Slenderness;
using StructurePoint.Products.Column.Views.Slenderness;
using Telerik.Windows.Data;

namespace StructurePoint.Products.Column.ViewModels.Slenderness.Modules
{
	// Token: 0x02000162 RID: 354
	internal sealed class TemporaryColumn : #HH<ColumnsAboveFormView>, #q8<#M8>, #M8, #rqe
	{
		// Token: 0x06000B39 RID: 2873 RVA: 0x0000E7A5 File Offset: 0x0000C9A5
		public TemporaryColumn(Lazy<ColumnsAboveFormView> view, ICoreServices services, IBeamsCalculator calculator, ISlendernessColumnsAboveBelowValidator validator) : base(view, services)
		{
			this.view = view;
			this.calculator = calculator;
			this.validator = validator;
			this.<LastValid>k__BackingField = new SlendernessOfColumn();
		}

		// Token: 0x1700048B RID: 1163
		// (get) Token: 0x06000B3A RID: 2874 RVA: 0x0000E7D0 File Offset: 0x0000C9D0
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x1700048C RID: 1164
		// (get) Token: 0x06000B3B RID: 2875 RVA: 0x0000E7E0 File Offset: 0x0000C9E0
		// (set) Token: 0x06000B3C RID: 2876 RVA: 0x0000E7EC File Offset: 0x0000C9EC
		public float Height
		{
			get
			{
				return this.height;
			}
			set
			{
				base.#KH<float>(ref this.height, value, this.validator, null, #Phc.#3hc(107412672));
				this.UpdateLastValid();
			}
		}

		// Token: 0x1700048D RID: 1165
		// (get) Token: 0x06000B3D RID: 2877 RVA: 0x0000E81F File Offset: 0x0000CA1F
		// (set) Token: 0x06000B3E RID: 2878 RVA: 0x0000E82B File Offset: 0x0000CA2B
		public float Width
		{
			get
			{
				return this.width;
			}
			set
			{
				base.#KH<float>(ref this.width, value, this.validator, null, #Phc.#3hc(107412974));
				this.UpdateLastValid();
			}
		}

		// Token: 0x1700048E RID: 1166
		// (get) Token: 0x06000B3F RID: 2879 RVA: 0x0000E85E File Offset: 0x0000CA5E
		// (set) Token: 0x06000B40 RID: 2880 RVA: 0x0000E86A File Offset: 0x0000CA6A
		public float Depth
		{
			get
			{
				return this.depth;
			}
			set
			{
				base.#KH<float>(ref this.depth, value, this.validator, null, #Phc.#3hc(107412965));
				this.UpdateLastValid();
			}
		}

		// Token: 0x1700048F RID: 1167
		// (get) Token: 0x06000B41 RID: 2881 RVA: 0x0000E89D File Offset: 0x0000CA9D
		// (set) Token: 0x06000B42 RID: 2882 RVA: 0x0000E8A9 File Offset: 0x0000CAA9
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

		// Token: 0x17000490 RID: 1168
		// (get) Token: 0x06000B43 RID: 2883 RVA: 0x0000E8E2 File Offset: 0x0000CAE2
		// (set) Token: 0x06000B44 RID: 2884 RVA: 0x0000E8EE File Offset: 0x0000CAEE
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

		// Token: 0x17000491 RID: 1169
		// (get) Token: 0x06000B45 RID: 2885 RVA: 0x0000E921 File Offset: 0x0000CB21
		// (set) Token: 0x06000B46 RID: 2886 RVA: 0x00099E88 File Offset: 0x00098088
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

		// Token: 0x17000492 RID: 1170
		// (get) Token: 0x06000B47 RID: 2887 RVA: 0x0000E92D File Offset: 0x0000CB2D
		// (set) Token: 0x06000B48 RID: 2888 RVA: 0x00099EE8 File Offset: 0x000980E8
		public SlendernessColumnType SlendernessColumnType
		{
			get
			{
				return this.slendernessColumnType;
			}
			set
			{
				SlendernessColumnType slendernessColumnType = this.SlendernessColumnType;
				base.#KH<SlendernessColumnType>(ref this.slendernessColumnType, value, this.validator, null, #Phc.#3hc(107412919));
				if (slendernessColumnType != value)
				{
					this.OnColumnTypeChanged(slendernessColumnType, value);
				}
			}
		}

		// Token: 0x17000493 RID: 1171
		// (get) Token: 0x06000B49 RID: 2889 RVA: 0x0000E939 File Offset: 0x0000CB39
		public SlendernessOfColumn LastValid { get; }

		// Token: 0x17000494 RID: 1172
		// (get) Token: 0x06000B4A RID: 2890 RVA: 0x0000E945 File Offset: 0x0000CB45
		public static RadObservableCollection<ComboItem<SlendernessColumnType>> SlendernessColumnTypeCollection { get; } = new RadObservableCollection<ComboItem<SlendernessColumnType>>
		{
			new ComboItem<SlendernessColumnType>(SlendernessColumnType.None, Strings.StringNone),
			new ComboItem<SlendernessColumnType>(SlendernessColumnType.Circular, Strings.StringCircular),
			new ComboItem<SlendernessColumnType>(SlendernessColumnType.Rectangular, Strings.StringRectangular),
			new ComboItem<SlendernessColumnType>(SlendernessColumnType.DesignCol, Strings.StringAsDesignCol)
		};

		// Token: 0x06000B4B RID: 2891 RVA: 0x00099F34 File Offset: 0x00098134
		public void CopyFrom(#M8 source)
		{
			this.SlendernessColumnType = source.SlendernessColumnType;
			this.Height = source.Height;
			this.Width = source.Width;
			this.Depth = source.Depth;
			this.Fcp = source.Fcp;
			this.Ec = source.Ec;
			this.IsConcreteStandard = source.IsConcreteStandard;
			this.CalculateElasticityIfNecessary();
			base.#PH<#rqe>(this.validator, null);
		}

		// Token: 0x06000B4C RID: 2892 RVA: 0x0000E94C File Offset: 0x0000CB4C
		public void ValidateColumn()
		{
			base.#PH<#rqe>(this.validator, null);
		}

		// Token: 0x06000B4D RID: 2893 RVA: 0x0000E968 File Offset: 0x0000CB68
		public void ValidateColumnOnPanelActivated()
		{
			base.#PH<#rqe, ColumnsAboveFormView>(this.validator, this.view, base.Services.MouseAndKeyboard);
		}

		// Token: 0x06000B4E RID: 2894 RVA: 0x00099FB8 File Offset: 0x000981B8
		private void OnColumnTypeChanged(SlendernessColumnType oldType, SlendernessColumnType newType)
		{
			ColumnModel #Od = base.Services.Project.Model;
			SlendernessOfColumn slendernessOfColumn = #d8.#b8(#Od, newType);
			if (oldType != SlendernessColumnType.None && newType != SlendernessColumnType.None)
			{
				this.CopyNonZeroesBetweenColumns(this, slendernessOfColumn);
			}
			this.CopyFrom(slendernessOfColumn);
			this.UpdateLastValid();
		}

		// Token: 0x06000B4F RID: 2895 RVA: 0x0000E994 File Offset: 0x0000CB94
		private void CalculateElasticityIfNecessary()
		{
			if (!this.IsConcreteStandard || base.CheckIfPropertyHasErrors(#Phc.#3hc(107412979)))
			{
				return;
			}
			this.Ec = this.calculator.#2Q(this.Fcp);
		}

		// Token: 0x06000B50 RID: 2896 RVA: 0x0000E9D4 File Offset: 0x0000CBD4
		private void UpdateLastValid()
		{
			if (this.HasErrors)
			{
				return;
			}
			this.LastValid.CopyFrom(this);
		}

		// Token: 0x06000B51 RID: 2897 RVA: 0x0009A008 File Offset: 0x00098208
		private void CopyNonZeroesBetweenColumns(#M8 source, #M8 destination)
		{
			if (this.IsNonZero(source.Width))
			{
				destination.Width = source.Width;
			}
			if (this.IsNonZero(source.Height))
			{
				destination.Height = source.Height;
			}
			if (this.IsNonZero(source.Fcp))
			{
				destination.Fcp = source.Fcp;
			}
			if (this.IsNonZero(source.Depth))
			{
				destination.Depth = source.Depth;
			}
			if (this.IsNonZero(source.Ec))
			{
				destination.Ec = source.Ec;
			}
		}

		// Token: 0x06000B52 RID: 2898 RVA: 0x0000E9F7 File Offset: 0x0000CBF7
		private bool IsNonZero(float value)
		{
			return Math.Abs(value) >= 0.001f;
		}

		// Token: 0x0400041E RID: 1054
		private float height;

		// Token: 0x0400041F RID: 1055
		private float width;

		// Token: 0x04000420 RID: 1056
		private float depth;

		// Token: 0x04000421 RID: 1057
		private float fcp;

		// Token: 0x04000422 RID: 1058
		private float ec;

		// Token: 0x04000423 RID: 1059
		private bool isConcreteStandard;

		// Token: 0x04000424 RID: 1060
		private SlendernessColumnType slendernessColumnType;

		// Token: 0x04000425 RID: 1061
		private readonly Lazy<ColumnsAboveFormView> view;

		// Token: 0x04000426 RID: 1062
		private readonly IBeamsCalculator calculator;

		// Token: 0x04000427 RID: 1063
		private readonly ISlendernessColumnsAboveBelowValidator validator;
	}
}
