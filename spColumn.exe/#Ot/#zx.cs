using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using #0I;
using #36d;
using #45d;
using #kB;
using #Lx;
using #pc;
using #qJ;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.Products.Column.Core.API;
using StructurePoint.Products.Column.Services.API;
using StructurePoint.Products.Column.ViewModels.Core;
using StructurePoint.Products.Column.ViewModels.Settings.API;
using Telerik.Windows.Controls;

namespace #Ot
{
	// Token: 0x02000190 RID: 400
	internal sealed class #zx : WindowViewModelBase<SettingType, #zc>, INotifyPropertyChanged, IViewModel<IColumnWindow>, #6I<SettingType>, IViewModel, #Vx
	{
		// Token: 0x06000D3F RID: 3391 RVA: 0x0009DB60 File Offset: 0x0009BD60
		public #zx(Lazy<#zc> #Ee, ICoreServices #0c, #Tx #Ax, #Sx #Bx, #Ux #Cx, #Rx #Dx, #Qx #Ex, #Nx #Fx, #Mx #Gx, #Kx #Hx, #Px #Ix, #Ox #Jx, #jB #pl, #zJ #pj, IEditorService #wj) : base(#Ee, #0c, #pl, #pj, #wj)
		{
			base.UseUndoManager = false;
			base.NotifyDefinitionsChangedOnModelSave = false;
			this.#a = #Ax;
			this.#b = #Bx;
			this.#c = #Cx;
			this.#d = #Dx;
			this.#e = #Ex;
			this.#f = #Fx;
			this.#g = #Gx;
			this.#h = #Hx;
			this.#i = #Ix;
			this.#j = #Jx;
			this.#k = new DelegateCommand(new Action<object>(this.#qx));
			this.#l = new DelegateCommand(new Action<object>(this.#rx));
			base.CheckForChangesOnClosing = true;
			base.AskToSaveChangesBeforeClosingMessage = Strings.StringModifiedSettingsNotSaved.#z2d().#Tm() + Strings.StringWouldYouLikeToSaveThem.#J2d();
		}

		// Token: 0x17000545 RID: 1349
		// (get) Token: 0x06000D40 RID: 3392 RVA: 0x00010559 File Offset: 0x0000E759
		public DelegateCommand ResetCommand { get; }

		// Token: 0x17000546 RID: 1350
		// (get) Token: 0x06000D41 RID: 3393 RVA: 0x00010565 File Offset: 0x0000E765
		public DelegateCommand ApplyCommand { get; }

		// Token: 0x17000547 RID: 1351
		// (get) Token: 0x06000D42 RID: 3394 RVA: 0x00010571 File Offset: 0x0000E771
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x06000D43 RID: 3395 RVA: 0x0009DC34 File Offset: 0x0009BE34
		public override void #Mq(SettingType #kx)
		{
			if (base.ShowLock.#YXd())
			{
				try
				{
					this.#nx();
					base.#Mq(#kx);
				}
				finally
				{
					base.ShowLock.#ZXd();
				}
			}
		}

		// Token: 0x06000D44 RID: 3396 RVA: 0x00010581 File Offset: 0x0000E781
		protected override void #lx()
		{
			this.#ox();
			base.#lx();
		}

		// Token: 0x06000D45 RID: 3397 RVA: 0x0009DC88 File Offset: 0x0009BE88
		protected override void #mx(CancelEventArgs #Lg)
		{
			try
			{
				base.#mx(#Lg);
			}
			finally
			{
				this.#ox();
				if (this.#px())
				{
					base.Services.MessageBus.#GV();
				}
			}
		}

		// Token: 0x06000D46 RID: 3398 RVA: 0x0009DCDC File Offset: 0x0009BEDC
		public override IEnumerable<PanelItem> #Lq()
		{
			PanelItem panelItem = new PanelItem(Strings.StringGeneral);
			PanelItem panelItem2 = new PanelItem(Strings.StringSections);
			PanelItem panelItem3 = new PanelItem(Strings.String2DDiagrams);
			PanelItem panelItem4 = new PanelItem(Strings.String3DDiagrams);
			panelItem.Children.Add(new PanelItem(SettingType.GeneralOptions, Strings.StringOptions, this.#a, true));
			panelItem.Children.Add(new PanelItem(SettingType.GeneralReports, Strings.StringReports, this.#b, true));
			panelItem.Children.Add(new PanelItem(SettingType.GeneralStartupDefault, Strings.StringStartupDefaults_CAMEL, this.#c, true));
			panelItem2.Children.Add(new PanelItem(SettingType.SectionsOptions, Strings.StringOptions, this.#d, true));
			panelItem2.Children.Add(new PanelItem(SettingType.SectionsColors, Strings.StringColors, this.#e, true));
			panelItem3.Children.Add(new PanelItem(SettingType.Diagrams2dOptions, Strings.StringOptions, this.#f, true));
			panelItem3.Children.Add(new PanelItem(SettingType.Diagrams2dAxis, Strings.StringAxes, this.#g, true));
			panelItem3.Children.Add(new PanelItem(SettingType.Diagrams2dColors, Strings.StringColors, this.#h, true));
			panelItem4.Children.Add(new PanelItem(SettingType.Diagrams3dOptions, Strings.StringOptions, this.#i, true));
			panelItem4.Children.Add(new PanelItem(SettingType.Diagrams3dColors, Strings.StringColors, this.#j, true));
			return new List<PanelItem>
			{
				panelItem,
				panelItem2,
				panelItem3,
				panelItem4
			};
		}

		// Token: 0x06000D47 RID: 3399 RVA: 0x0001059B File Offset: 0x0000E79B
		private void #nx()
		{
			#zx.#WTh(base.Services.ReporterSettings.UserSettingProvider);
			#zx.#WTh(base.Services.Settings.UserSettingProvider);
		}

		// Token: 0x06000D48 RID: 3400 RVA: 0x000105D3 File Offset: 0x0000E7D3
		private void #ox()
		{
			#zx.#XTh(base.Services.ReporterSettings.UserSettingProvider);
			#zx.#XTh(base.Services.Settings.UserSettingProvider);
		}

		// Token: 0x06000D49 RID: 3401 RVA: 0x0009DEAC File Offset: 0x0009C0AC
		private bool #px()
		{
			bool flag = #zx.#YTh(base.Services.ReporterSettings.UserSettingProvider);
			bool flag2 = #zx.#YTh(base.Services.Settings.UserSettingProvider);
			return flag2 || flag;
		}

		// Token: 0x06000D4A RID: 3402 RVA: 0x0001060B File Offset: 0x0000E80B
		private void #qx(object #Sb)
		{
			PanelItem panelItem = base.ActiveItem;
			if (panelItem == null)
			{
				return;
			}
			panelItem.Panel.#qt();
		}

		// Token: 0x06000D4B RID: 3403 RVA: 0x0009DEF4 File Offset: 0x0009C0F4
		private void #rx(object #Sb)
		{
			if (base.ActiveItem == null)
			{
				return;
			}
			if (base.ActiveItem.Panel.HasAnyErrors)
			{
				this.#ux();
				return;
			}
			base.ActiveItem.Panel.Form.UpdateModel(base.Services.Project.Model);
			if (this.#px())
			{
				base.Services.MessageBus.#GV();
			}
		}

		// Token: 0x06000D4C RID: 3404 RVA: 0x0009DF6C File Offset: 0x0009C16C
		private void #ux()
		{
			Window #WSc = base.Services.WindowLocator.#6();
			string #SSc = base.Services.DialogService.#5Sc(Strings.StringInvalidDataSpecified.#z2d(), Strings.StringPleaseFixValidationErrorsBeforeApplyingValues.#z2d());
			base.Services.DialogService.#od(#WSc, #SSc, Strings.StringError, MessageBoxButton.OK, MessageBoxImage.Hand, MessageBoxResult.OK, MessageBoxOptions.None);
		}

		// Token: 0x06000D4D RID: 3405 RVA: 0x0009DFD8 File Offset: 0x0009C1D8
		[CompilerGenerated]
		internal static void #WTh(#55d #wx)
		{
			#86d #86d = #wx as #86d;
			if (#86d != null)
			{
				#86d.AutoFlush = false;
			}
		}

		// Token: 0x06000D4E RID: 3406 RVA: 0x0009E004 File Offset: 0x0009C204
		[CompilerGenerated]
		internal static void #XTh(#55d #wx)
		{
			#86d #86d = #wx as #86d;
			if (#86d != null)
			{
				#86d.AutoFlush = true;
			}
		}

		// Token: 0x06000D4F RID: 3407 RVA: 0x0009E030 File Offset: 0x0009C230
		[CompilerGenerated]
		internal static bool #YTh(#55d #wx)
		{
			#86d #86d = #wx as #86d;
			return #86d == null || #86d.#lGd();
		}

		// Token: 0x040004EB RID: 1259
		private readonly #Tx #a;

		// Token: 0x040004EC RID: 1260
		private readonly #Sx #b;

		// Token: 0x040004ED RID: 1261
		private readonly #Ux #c;

		// Token: 0x040004EE RID: 1262
		private readonly #Rx #d;

		// Token: 0x040004EF RID: 1263
		private readonly #Qx #e;

		// Token: 0x040004F0 RID: 1264
		private readonly #Nx #f;

		// Token: 0x040004F1 RID: 1265
		private readonly #Mx #g;

		// Token: 0x040004F2 RID: 1266
		private readonly #Kx #h;

		// Token: 0x040004F3 RID: 1267
		private readonly #Px #i;

		// Token: 0x040004F4 RID: 1268
		private readonly #Ox #j;

		// Token: 0x040004F5 RID: 1269
		[CompilerGenerated]
		private readonly DelegateCommand #k;

		// Token: 0x040004F6 RID: 1270
		[CompilerGenerated]
		private readonly DelegateCommand #l;
	}
}
