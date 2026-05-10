using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using #0I;
using #6re;
using #7hc;
using #Lx;
using #oKe;
using #Ot;
using #pc;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Settings;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.Products.Column.Model;
using StructurePoint.Products.Column.Services.API;
using StructurePoint.Products.Column.ViewModels.API.Core;
using Telerik.Windows.Data;

namespace StructurePoint.Products.Column.ViewModels.Settings
{
	// Token: 0x02000171 RID: 369
	internal sealed class Diagrams2dAxisViewModel : #ex<#qc>, #5I, IPanel, IChangesInfo, #Mx
	{
		// Token: 0x06000BBF RID: 3007 RVA: 0x0009ADD0 File Offset: 0x00098FD0
		public Diagrams2dAxisViewModel(Lazy<#qc> view, ICoreServices services, #nKe localizationService, #yse reporterSettingsManager) : base(view, services)
		{
			this.#a = localizationService;
			this.#b = reporterSettingsManager;
			this.AxisValuesSource.AddRange(this.#a.AvailableDiagram2DValuesOnAxesType.Select(new Func<KeyValuePair<ValuesOnAxesType, string>, ComboItem<ValuesOnAxesType>>(Diagrams2dAxisViewModel.<>c.<>9.#uWb)));
		}

		// Token: 0x170004B9 RID: 1209
		// (get) Token: 0x06000BC0 RID: 3008 RVA: 0x0000EEE0 File Offset: 0x0000D0E0
		public RadObservableCollection<ComboItem<ValuesOnAxesType>> AxisValuesSource { get; }

		// Token: 0x170004BA RID: 1210
		// (get) Token: 0x06000BC1 RID: 3009 RVA: 0x0000EEEC File Offset: 0x0000D0EC
		// (set) Token: 0x06000BC2 RID: 3010 RVA: 0x0000EEF8 File Offset: 0x0000D0F8
		public ComboItem<ValuesOnAxesType> SelectedAxisValues
		{
			get
			{
				return this.#e;
			}
			set
			{
				this.SetProperty<ComboItem<ValuesOnAxesType>>(ref this.#e, value, #Phc.#3hc(107412210));
			}
		}

		// Token: 0x170004BB RID: 1211
		// (get) Token: 0x06000BC3 RID: 3011 RVA: 0x0000EF1E File Offset: 0x0000D11E
		// (set) Token: 0x06000BC4 RID: 3012 RVA: 0x0000EF2A File Offset: 0x0000D12A
		public bool UniformAxisValuesForMMDiagrams
		{
			get
			{
				return this.#d;
			}
			set
			{
				this.SetProperty<bool>(ref this.#d, value, #Phc.#3hc(107412185));
			}
		}

		// Token: 0x170004BC RID: 1212
		// (get) Token: 0x06000BC5 RID: 3013 RVA: 0x0000EF50 File Offset: 0x0000D150
		// (set) Token: 0x06000BC6 RID: 3014 RVA: 0x0000EF5C File Offset: 0x0000D15C
		public bool UniformAxisValuesForPMDiagrams
		{
			get
			{
				return this.#c;
			}
			set
			{
				this.SetProperty<bool>(ref this.#c, value, #Phc.#3hc(107412144));
			}
		}

		// Token: 0x170004BD RID: 1213
		// (get) Token: 0x06000BC7 RID: 3015 RVA: 0x0000EF82 File Offset: 0x0000D182
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x06000BC8 RID: 3016 RVA: 0x0009AE3C File Offset: 0x0009903C
		public bool GetHasChanges()
		{
			#5re #5re = this.#b.#jJ();
			return #5re.ValuesOnAxes != this.SelectedAxisValues.Value || #5re.UniformScaleForMMDiagrams != this.UniformAxisValuesForMMDiagrams || #5re.UniformScaleForPMDiagrams != this.UniformAxisValuesForPMDiagrams;
		}

		// Token: 0x06000BC9 RID: 3017 RVA: 0x0009AE98 File Offset: 0x00099098
		public override void UpdateFromModel(ColumnModel model)
		{
			#5re #st = this.#b.#jJ();
			this.#rt(#st);
		}

		// Token: 0x06000BCA RID: 3018 RVA: 0x0009AEC4 File Offset: 0x000990C4
		public override void UpdateModel(ColumnModel model)
		{
			#5re #5re = this.#b.#jJ();
			#5re.ValuesOnAxes = this.SelectedAxisValues.Value;
			#5re.UniformScaleForMMDiagrams = this.UniformAxisValuesForMMDiagrams;
			#5re.UniformScaleForPMDiagrams = this.UniformAxisValuesForPMDiagrams;
			this.#b.#iJ(#5re);
		}

		// Token: 0x06000BCB RID: 3019 RVA: 0x0009AF20 File Offset: 0x00099120
		public override void #qt()
		{
			#5re #st = #5re.Default;
			this.#rt(#st);
		}

		// Token: 0x06000BCC RID: 3020 RVA: 0x0009AF48 File Offset: 0x00099148
		private void #rt(#5re #st)
		{
			Diagrams2dAxisViewModel.#ETb #ETb = new Diagrams2dAxisViewModel.#ETb();
			#ETb.#a = #st;
			this.SelectedAxisValues = this.AxisValuesSource.Single(new Func<ComboItem<ValuesOnAxesType>, bool>(#ETb.#vWb));
			this.UniformAxisValuesForMMDiagrams = #ETb.#a.UniformScaleForMMDiagrams;
			this.UniformAxisValuesForPMDiagrams = #ETb.#a.UniformScaleForPMDiagrams;
		}

		// Token: 0x06000BCD RID: 3021 RVA: 0x0000A950 File Offset: 0x00008B50
		void #5I.#Lr()
		{
			base.ClearErrors();
		}

		// Token: 0x06000BCE RID: 3022 RVA: 0x0000A960 File Offset: 0x00008B60
		void #5I.#Or(string #em)
		{
			base.RemoveError(#em);
		}

		// Token: 0x0400044F RID: 1103
		private readonly #nKe #a;

		// Token: 0x04000450 RID: 1104
		private readonly #yse #b;

		// Token: 0x04000451 RID: 1105
		private bool #c;

		// Token: 0x04000452 RID: 1106
		private bool #d;

		// Token: 0x04000453 RID: 1107
		private ComboItem<ValuesOnAxesType> #e;

		// Token: 0x04000454 RID: 1108
		[CompilerGenerated]
		private readonly RadObservableCollection<ComboItem<ValuesOnAxesType>> #f = new RadObservableCollection<ComboItem<ValuesOnAxesType>>();

		// Token: 0x02000173 RID: 371
		[CompilerGenerated]
		private sealed class #ETb
		{
			// Token: 0x06000BD3 RID: 3027 RVA: 0x0009AFB0 File Offset: 0x000991B0
			internal bool #vWb(ComboItem<ValuesOnAxesType> #9o)
			{
				return #9o.Value.Equals(this.#a.ValuesOnAxes);
			}

			// Token: 0x04000457 RID: 1111
			public #5re #a;
		}
	}
}
