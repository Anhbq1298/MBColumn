using System;
using System.Runtime.CompilerServices;
using System.Windows;
using #0I;
using #6s;
using #7hc;
using #cc;
using #lH;
using #npe;
using #PI;
using StructurePoint.CoreAssets.AppManager.Column.Core;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.Products.Column.Model;
using StructurePoint.Products.Column.Services.API;
using StructurePoint.Products.Column.ViewModels.API.Core;
using StructurePoint.Products.Column.ViewModels.Slenderness.Modules;
using Telerik.Windows.Controls;

namespace #qr
{
	// Token: 0x02000154 RID: 340
	internal sealed class #Pr : #TH, #5I, #OI, IChangesInfo, #at
	{
		// Token: 0x06000AB3 RID: 2739 RVA: 0x0000E02D File Offset: 0x0000C22D
		public #Pr(Lazy<#dc> #Ee, ICoreServices #0c, #7s #Qr)
		{
			this.#c = #Ee;
			this.#d = #0c;
			this.#e = #Qr;
			this.#g = new DelegateCommand(new Action<object>(this.#Jr));
		}

		// Token: 0x17000461 RID: 1121
		// (get) Token: 0x06000AB4 RID: 2740 RVA: 0x0000E061 File Offset: 0x0000C261
		// (set) Token: 0x06000AB5 RID: 2741 RVA: 0x0000E06D File Offset: 0x0000C26D
		public TemporaryColumn SlendernessOfColumnAbove
		{
			get
			{
				return this.#a;
			}
			set
			{
				this.SetProperty<TemporaryColumn>(ref this.#a, value, #Phc.#3hc(107413250));
			}
		}

		// Token: 0x17000462 RID: 1122
		// (get) Token: 0x06000AB6 RID: 2742 RVA: 0x0000E093 File Offset: 0x0000C293
		// (set) Token: 0x06000AB7 RID: 2743 RVA: 0x0000E09F File Offset: 0x0000C29F
		public TemporaryColumn SlendernessOfColumnBelow
		{
			get
			{
				return this.#b;
			}
			set
			{
				this.SetProperty<TemporaryColumn>(ref this.#b, value, #Phc.#3hc(107412705));
			}
		}

		// Token: 0x17000463 RID: 1123
		// (get) Token: 0x06000AB8 RID: 2744 RVA: 0x0000E0C5 File Offset: 0x0000C2C5
		// (set) Token: 0x06000AB9 RID: 2745 RVA: 0x0000E0D1 File Offset: 0x0000C2D1
		public #ht SlendernessWindow { get; set; }

		// Token: 0x17000464 RID: 1124
		// (get) Token: 0x06000ABA RID: 2746 RVA: 0x0000E0E2 File Offset: 0x0000C2E2
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors || this.SlendernessOfColumnAbove.HasErrors || this.SlendernessOfColumnBelow.HasErrors;
			}
		}

		// Token: 0x17000465 RID: 1125
		// (get) Token: 0x06000ABB RID: 2747 RVA: 0x0000E112 File Offset: 0x0000C312
		public DelegateCommand CopyToCommand { get; }

		// Token: 0x06000ABC RID: 2748 RVA: 0x00098FE4 File Offset: 0x000971E4
		public bool GetHasChanges()
		{
			ColumnModel columnModel = this.#d.Project.Model;
			return !#Oai.#uC(this.SlendernessOfColumnAbove, columnModel.ColumnAbove) || !#Oai.#uC(this.SlendernessOfColumnBelow, columnModel.ColumnBelow);
		}

		// Token: 0x06000ABD RID: 2749 RVA: 0x00099038 File Offset: 0x00097238
		public void #Gr(EndConditionType #Hr, EndConditionType #Ir)
		{
			if (!this.SlendernessWindow.#Rq())
			{
				this.SlendernessOfColumnAbove.SlendernessColumnType = SlendernessColumnType.None;
				this.SlendernessOfColumnBelow.SlendernessColumnType = SlendernessColumnType.None;
				return;
			}
			if (this.SlendernessWindow.IsAboveBelowWithoutBelow)
			{
				this.SlendernessOfColumnBelow.SlendernessColumnType = SlendernessColumnType.None;
			}
		}

		// Token: 0x06000ABE RID: 2750 RVA: 0x0000E11E File Offset: 0x0000C31E
		public void #or()
		{
			this.SlendernessOfColumnAbove.ValidateColumnOnPanelActivated();
			this.SlendernessOfColumnBelow.ValidateColumnOnPanelActivated();
		}

		// Token: 0x06000ABF RID: 2751 RVA: 0x00099090 File Offset: 0x00097290
		public override void UpdateFromModel(ColumnModel model)
		{
			this.SlendernessOfColumnAbove = this.#e.#ul();
			this.SlendernessOfColumnBelow = this.#e.#ul();
			this.SlendernessOfColumnAbove.CopyFrom(model.ColumnAbove);
			this.SlendernessOfColumnBelow.CopyFrom(model.ColumnBelow);
		}

		// Token: 0x06000AC0 RID: 2752 RVA: 0x0000E142 File Offset: 0x0000C342
		public override void UpdateModel(ColumnModel model)
		{
			model.ColumnAbove.CopyFrom(this.SlendernessOfColumnAbove);
			model.ColumnBelow.CopyFrom(this.SlendernessOfColumnBelow);
			model.SlendernessInputFlag |= #ppe.#d;
		}

		// Token: 0x06000AC1 RID: 2753 RVA: 0x000990F0 File Offset: 0x000972F0
		private void #Jr(object #Sb)
		{
			TemporaryColumn temporaryColumn = #Sb as TemporaryColumn;
			if (temporaryColumn != null && temporaryColumn.IsValid)
			{
				TemporaryColumn temporaryColumn2 = (#Sb == this.SlendernessOfColumnAbove) ? this.SlendernessOfColumnBelow : this.SlendernessOfColumnAbove;
				temporaryColumn2.CopyFrom(temporaryColumn);
				return;
			}
			this.#Kr();
		}

		// Token: 0x06000AC2 RID: 2754 RVA: 0x00099144 File Offset: 0x00097344
		private void #Kr()
		{
			Window #jA = this.#d.WindowLocator.#6();
			this.#d.DialogService.#1Sc(#jA, ColumnGlobalInfo.DefaultMessageBoxTitle, Strings.StringInvalidDataSpecified.#z2d() + Environment.NewLine.#W2d(2) + Strings.StringPleaseFixValidationErrorsBeforeCopyingValues, MessageBoxButton.OK, MessageBoxImage.Hand);
		}

		// Token: 0x06000AC3 RID: 2755 RVA: 0x0000A950 File Offset: 0x00008B50
		void #5I.#Lr()
		{
			base.ClearErrors();
		}

		// Token: 0x06000AC4 RID: 2756 RVA: 0x0000A960 File Offset: 0x00008B60
		void #5I.#Or(string #em)
		{
			base.RemoveError(#em);
		}

		// Token: 0x040003DC RID: 988
		private TemporaryColumn #a;

		// Token: 0x040003DD RID: 989
		private TemporaryColumn #b;

		// Token: 0x040003DE RID: 990
		private readonly Lazy<#dc> #c;

		// Token: 0x040003DF RID: 991
		private readonly ICoreServices #d;

		// Token: 0x040003E0 RID: 992
		private readonly #7s #e;

		// Token: 0x040003E1 RID: 993
		[CompilerGenerated]
		private #ht #f;

		// Token: 0x040003E2 RID: 994
		[CompilerGenerated]
		private readonly DelegateCommand #g;
	}
}
