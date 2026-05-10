using System;
using System.ComponentModel;
using System.Windows;
using #5Z;
using #7hc;
using #8Cc;
using #eU;
using #oKe;
using #WG;
using #WI;
using StructurePoint.CoreAssets.AppManager.Column.Core;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.Products.Column.Services.API;
using StructurePoint.Products.Column.ViewModels.API.Definitions;

namespace #qJ
{
	// Token: 0x020002BA RID: 698
	internal sealed class #HO : NotifyPropertyChangedObjectBase, INotifyPropertyChanged, INotifyPropertyChanging, #XV
	{
		// Token: 0x0600183A RID: 6202 RVA: 0x000B5EF4 File Offset: 0x000B40F4
		public #HO(#bDc #DJ, #UV #ms, ICoreServices #0c, #nKe #JF, #0G #IO)
		{
			if (#DJ == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107404911));
			}
			this.#a = #DJ;
			if (#ms == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107405278));
			}
			this.#b = #ms;
			if (#0c == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107407561));
			}
			this.#c = #0c;
			if (#JF == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107404825));
			}
			this.#d = #JF;
			if (#IO == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107402028));
			}
			this.#e = #IO;
			#DJ.PropertyChanged += this.#7j;
			#ms.UnitSystemChanged += this.#EO;
			#ms.DesignCodeChanged += this.#EF;
		}

		// Token: 0x170008FD RID: 2301
		// (get) Token: 0x0600183B RID: 6203 RVA: 0x00018A52 File Offset: 0x00016C52
		// (set) Token: 0x0600183C RID: 6204 RVA: 0x00018A5E File Offset: 0x00016C5E
		public bool HasChanges
		{
			get
			{
				return this.#f;
			}
			private set
			{
				if (this.#f != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107402035));
					this.#f = value;
					base.RaisePropertyChanged(#Phc.#3hc(107402035));
				}
			}
		}

		// Token: 0x0600183D RID: 6205 RVA: 0x00018A9C File Offset: 0x00016C9C
		public void #DO()
		{
			this.#g = this.#a.UndoActions.Count;
			this.HasChanges = false;
		}

		// Token: 0x0600183E RID: 6206 RVA: 0x00018AC7 File Offset: 0x00016CC7
		public void #yJ()
		{
			this.#g = 0;
			this.HasChanges = false;
		}

		// Token: 0x0600183F RID: 6207 RVA: 0x000B5FC8 File Offset: 0x000B41C8
		private void #7j(object #Ge, PropertyChangedEventArgs #He)
		{
			#bDc #bDc = (#bDc)#Ge;
			#bDc #bDc2;
			if (!false)
			{
				#bDc2 = #bDc;
			}
			this.HasChanges = (#bDc2.UndoActions.Count != this.#g);
		}

		// Token: 0x06001840 RID: 6208 RVA: 0x00018AE3 File Offset: 0x00016CE3
		private void #EO(object #Ge, EventArgs #He)
		{
			this.#FO();
		}

		// Token: 0x06001841 RID: 6209 RVA: 0x00018AF3 File Offset: 0x00016CF3
		private void #EF(object #Ge, EventArgs #He)
		{
			this.#FO();
			this.#GO();
		}

		// Token: 0x06001842 RID: 6210 RVA: 0x000B6008 File Offset: 0x000B4208
		private void #FO()
		{
			#K2 #K = this.#c.Project.Model.MaterialProperties;
			bool flag = (#K.IsConcreteStandard && #K.IsSteelStandard) || #K.#J2(#K2.Empty);
			if (flag)
			{
				return;
			}
			string text = this.#d.AvailableDesignCodes[this.#c.Project.Model.Options.Code];
			string # = string.Format(#Phc.#3hc(107408730), Strings.StringTheCodeOrUnitHaveChanged.PadRight(1), Strings.StringVerifyTheNonStandardMaterialPropertiesForX.#D2d(new object[]
			{
				text
			}));
			Window #jA = this.#c.WindowLocator.#6();
			this.#c.DialogService.#1Sc(#jA, ColumnGlobalInfo.DefaultMessageBoxTitle, #, MessageBoxButton.OK, MessageBoxImage.Exclamation);
			this.#e.#Mq(DefinitionType.DefineConcreteMaterial);
		}

		// Token: 0x06001843 RID: 6211 RVA: 0x000B6100 File Offset: 0x000B4300
		private void #GO()
		{
			#k3 #k = this.#c.Project.Model.Options;
			if (!#k.#i3() || #k.ConfinementType != ConfinementType.Tied || #k.SectionType != SectionType.Irregular)
			{
				return;
			}
			string #SSc = string.Format(#Phc.#3hc(107408730), Strings.StringTheCodeHasChanged.#z2d(), Strings.StringVerifyTheIrregularSectionMinimumDimension.#z2d());
			Window #WSc = this.#c.WindowLocator.#6();
			this.#c.DialogService.#ZSc(#WSc, #SSc);
			this.#e.#Mq(DefinitionType.DefineReductionFactors);
		}

		// Token: 0x04000945 RID: 2373
		private readonly #bDc #a;

		// Token: 0x04000946 RID: 2374
		private readonly #UV #b;

		// Token: 0x04000947 RID: 2375
		private readonly ICoreServices #c;

		// Token: 0x04000948 RID: 2376
		private readonly #nKe #d;

		// Token: 0x04000949 RID: 2377
		private readonly #YI<DefinitionType> #e;

		// Token: 0x0400094A RID: 2378
		private bool #f;

		// Token: 0x0400094B RID: 2379
		private int #g;
	}
}
