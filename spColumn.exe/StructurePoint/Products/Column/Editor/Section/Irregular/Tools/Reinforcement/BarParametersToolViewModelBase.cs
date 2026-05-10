using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using #7hc;
using #ABb;
using #ede;
using #eU;
using #lH;
using #tFb;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.CoreAssets.Units;
using StructurePoint.Products.Column.Editor.Section.Common;
using StructurePoint.Products.Column.Model.Entities;
using StructurePoint.Products.Column.Model.Entities.Units;
using StructurePoint.Products.Column.Services.API;
using Telerik.Windows.Data;

namespace StructurePoint.Products.Column.Editor.Section.Irregular.Tools.Reinforcement
{
	// Token: 0x0200053C RID: 1340
	internal class BarParametersToolViewModelBase : #HH<#IFb>, INotifyPropertyChanged, IViewModel, IViewModel<#IFb>, #HFb
	{
		// Token: 0x06002FD9 RID: 12249 RVA: 0x000F6ADC File Offset: 0x000F4CDC
		protected BarParametersToolViewModelBase(Lazy<#IFb> view, IExtendedServices services, #JFb parametersContext) : base(view, services)
		{
			this.#a = services;
			this.#b = parametersContext;
			this.#c = BarDimensionSpecifierType.Size;
			this.#g = new #MBb(base.Project);
			services.MessageBus.UnitSystemChanged += this.#EO;
			services.Project.ModelChanging += this.#5Eb;
			services.Project.ModelChanged += this.#cl;
			services.MessageBus.DefinitionChangesCommitted += this.#owb;
		}

		// Token: 0x17000F8E RID: 3982
		// (get) Token: 0x06002FDA RID: 12250 RVA: 0x0002A86A File Offset: 0x00028A6A
		// (set) Token: 0x06002FDB RID: 12251 RVA: 0x0002A876 File Offset: 0x00028A76
		public bool ApplySelectStyle
		{
			get
			{
				return this.#A;
			}
			set
			{
				this.SetProperty<bool>(ref this.#A, value, #Phc.#3hc(107355097));
			}
		}

		// Token: 0x17000F8F RID: 3983
		// (get) Token: 0x06002FDC RID: 12252 RVA: 0x0002A89C File Offset: 0x00028A9C
		// (set) Token: 0x06002FDD RID: 12253 RVA: 0x000F6C5C File Offset: 0x000F4E5C
		public string BarPlacementXLabel
		{
			get
			{
				return this.#n;
			}
			set
			{
				if (this.#n != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107355040));
					this.#n = value;
					base.RaisePropertyChanged(#Phc.#3hc(107355040));
				}
			}
		}

		// Token: 0x17000F90 RID: 3984
		// (get) Token: 0x06002FDE RID: 12254 RVA: 0x0002A8A8 File Offset: 0x00028AA8
		// (set) Token: 0x06002FDF RID: 12255 RVA: 0x000F6CAC File Offset: 0x000F4EAC
		public string BarPlacementYLabel
		{
			get
			{
				return this.#o;
			}
			set
			{
				if (this.#o != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107355015));
					this.#o = value;
					base.RaisePropertyChanged(#Phc.#3hc(107355015));
				}
			}
		}

		// Token: 0x17000F91 RID: 3985
		// (get) Token: 0x06002FE0 RID: 12256 RVA: 0x0002A8B4 File Offset: 0x00028AB4
		// (set) Token: 0x06002FE1 RID: 12257 RVA: 0x0002A8C0 File Offset: 0x00028AC0
		public Visibility ReinforcementPanelVisibility
		{
			get
			{
				return this.#z;
			}
			set
			{
				this.SetProperty<Visibility>(ref this.#z, value, #Phc.#3hc(107355187));
			}
		}

		// Token: 0x17000F92 RID: 3986
		// (get) Token: 0x06002FE2 RID: 12258 RVA: 0x0002A8E6 File Offset: 0x00028AE6
		// (set) Token: 0x06002FE3 RID: 12259 RVA: 0x0002A8F2 File Offset: 0x00028AF2
		public Visibility PlacementPanelVisibility
		{
			get
			{
				return this.#q;
			}
			set
			{
				if (this.#q != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107354990));
					this.#q = value;
					base.RaisePropertyChanged(#Phc.#3hc(107354990));
				}
			}
		}

		// Token: 0x17000F93 RID: 3987
		// (get) Token: 0x06002FE4 RID: 12260 RVA: 0x0002A930 File Offset: 0x00028B30
		// (set) Token: 0x06002FE5 RID: 12261 RVA: 0x000F6CFC File Offset: 0x000F4EFC
		public Visibility BarPlacementYVisibility
		{
			get
			{
				return this.#p;
			}
			set
			{
				if (this.#p != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107354957));
					this.#p = value;
					this.#aFb();
					base.RaisePropertyChanged(#Phc.#3hc(107354957));
				}
			}
		}

		// Token: 0x17000F94 RID: 3988
		// (get) Token: 0x06002FE6 RID: 12262 RVA: 0x0002A93C File Offset: 0x00028B3C
		// (set) Token: 0x06002FE7 RID: 12263 RVA: 0x000F6D4C File Offset: 0x000F4F4C
		public BarDimensionSpecifierType BarDimensionSpecifierType
		{
			get
			{
				return this.#c;
			}
			set
			{
				if (this.#c != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107354924));
					this.#c = value;
					this.#wP();
					base.RaisePropertyChanged(#Phc.#3hc(107354924));
				}
			}
		}

		// Token: 0x17000F95 RID: 3989
		// (get) Token: 0x06002FE8 RID: 12264 RVA: 0x0002A948 File Offset: 0x00028B48
		// (set) Token: 0x06002FE9 RID: 12265 RVA: 0x000F6D9C File Offset: 0x000F4F9C
		public BarPlacementType BarPlacementType
		{
			get
			{
				return this.#i;
			}
			set
			{
				if (this.#i != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107354887));
					this.#i = value;
					this.#aFb();
					base.RaisePropertyChanged(#Phc.#3hc(107354887));
				}
			}
		}

		// Token: 0x17000F96 RID: 3990
		// (get) Token: 0x06002FEA RID: 12266 RVA: 0x0002A954 File Offset: 0x00028B54
		// (set) Token: 0x06002FEB RID: 12267 RVA: 0x000F6DEC File Offset: 0x000F4FEC
		public double BarSpacingX
		{
			get
			{
				return this.#j;
			}
			set
			{
				if (this.#j != value)
				{
					string error;
					if (this.#g.#JBb(value, out error))
					{
						base.RaisePropertyChanging(#Phc.#3hc(107354350));
						this.#j = value;
						base.RaisePropertyChanged(#Phc.#3hc(107354350));
						base.RemoveError(#Phc.#3hc(107354350));
						return;
					}
					this.AddError(#Phc.#3hc(107354350), error);
				}
			}
		}

		// Token: 0x17000F97 RID: 3991
		// (get) Token: 0x06002FEC RID: 12268 RVA: 0x0002A960 File Offset: 0x00028B60
		// (set) Token: 0x06002FED RID: 12269 RVA: 0x000F6E68 File Offset: 0x000F5068
		public double BarSpacingY
		{
			get
			{
				return this.#k;
			}
			set
			{
				if (this.#k != value)
				{
					string error;
					if (this.#g.#JBb(value, out error))
					{
						base.RaisePropertyChanging(#Phc.#3hc(107354365));
						this.#k = value;
						base.RaisePropertyChanged(#Phc.#3hc(107354365));
						base.RemoveError(#Phc.#3hc(107354365));
						return;
					}
					this.AddError(#Phc.#3hc(107354365), error);
				}
			}
		}

		// Token: 0x17000F98 RID: 3992
		// (get) Token: 0x06002FEE RID: 12270 RVA: 0x0002A96C File Offset: 0x00028B6C
		// (set) Token: 0x06002FEF RID: 12271 RVA: 0x0002A978 File Offset: 0x00028B78
		public int NumberOfBarsMinimum
		{
			get
			{
				return this.#r;
			}
			set
			{
				if (this.#r != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107354316));
					this.#r = value;
					base.RaisePropertyChanged(#Phc.#3hc(107354316));
				}
			}
		}

		// Token: 0x17000F99 RID: 3993
		// (get) Token: 0x06002FF0 RID: 12272 RVA: 0x0002A9B6 File Offset: 0x00028BB6
		// (set) Token: 0x06002FF1 RID: 12273 RVA: 0x0002A9C2 File Offset: 0x00028BC2
		public int NumberOfBarsMaximum
		{
			get
			{
				return this.#s;
			}
			set
			{
				if (this.#s != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107354287));
					this.#s = value;
					base.RaisePropertyChanged(#Phc.#3hc(107354287));
				}
			}
		}

		// Token: 0x17000F9A RID: 3994
		// (get) Token: 0x06002FF2 RID: 12274 RVA: 0x0002AA00 File Offset: 0x00028C00
		// (set) Token: 0x06002FF3 RID: 12275 RVA: 0x0002AA0C File Offset: 0x00028C0C
		public int NumberOfBarsX
		{
			get
			{
				return this.#l;
			}
			set
			{
				if (this.#l != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107354290));
					this.#l = value;
					base.RaisePropertyChanged(#Phc.#3hc(107354290));
				}
			}
		}

		// Token: 0x17000F9B RID: 3995
		// (get) Token: 0x06002FF4 RID: 12276 RVA: 0x0002AA4A File Offset: 0x00028C4A
		// (set) Token: 0x06002FF5 RID: 12277 RVA: 0x0002AA56 File Offset: 0x00028C56
		public int NumberOfBarsY
		{
			get
			{
				return this.#m;
			}
			set
			{
				if (this.#m != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107354269));
					this.#m = value;
					base.RaisePropertyChanged(#Phc.#3hc(107354269));
				}
			}
		}

		// Token: 0x17000F9C RID: 3996
		// (get) Token: 0x06002FF6 RID: 12278 RVA: 0x0002AA94 File Offset: 0x00028C94
		// (set) Token: 0x06002FF7 RID: 12279 RVA: 0x000F6EE4 File Offset: 0x000F50E4
		public int BarSize
		{
			get
			{
				return this.#e;
			}
			set
			{
				BarParametersToolViewModelBase.#QTb #QTb = new BarParametersToolViewModelBase.#QTb();
				#QTb.#a = value;
				if (this.#e != #QTb.#a)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107398779));
					this.#e = #QTb.#a;
					StandardBar standardBar = base.Project.Model.Bars.FirstOrDefault(new Func<StandardBar, bool>(#QTb.#I9b));
					if (standardBar != null)
					{
						this.BarArea = (double)standardBar.Area;
						this.#t = new int?(standardBar.Size);
					}
					base.RaisePropertyChanged(#Phc.#3hc(107398779));
				}
			}
		}

		// Token: 0x17000F9D RID: 3997
		// (get) Token: 0x06002FF8 RID: 12280 RVA: 0x0002AAA0 File Offset: 0x00028CA0
		// (set) Token: 0x06002FF9 RID: 12281 RVA: 0x000F6F9C File Offset: 0x000F519C
		public double Cover
		{
			get
			{
				return this.#h;
			}
			set
			{
				if (this.#h == value)
				{
					return;
				}
				string error;
				if (this.#g.#IBb(value, out error))
				{
					base.RaisePropertyChanging(#Phc.#3hc(107354216));
					this.#h = value;
					this.#b.Cover = value;
					this.#wP();
					base.RaisePropertyChanged(#Phc.#3hc(107354216));
					base.RemoveErrorIfAny(#Phc.#3hc(107354216));
					return;
				}
				this.SetError(#Phc.#3hc(107354216), error);
			}
		}

		// Token: 0x17000F9E RID: 3998
		// (get) Token: 0x06002FFA RID: 12282 RVA: 0x0002AAAC File Offset: 0x00028CAC
		// (set) Token: 0x06002FFB RID: 12283 RVA: 0x000F7038 File Offset: 0x000F5238
		public double BarArea
		{
			get
			{
				return this.#d;
			}
			set
			{
				if (this.#d == value)
				{
					return;
				}
				string error;
				if (this.#g.#HBb(value, out error))
				{
					base.RemoveErrorIfAny(#Phc.#3hc(107398918));
					base.RaisePropertyChanging(#Phc.#3hc(107398918));
					this.#d = value;
					this.#wP();
					base.RaisePropertyChanged(#Phc.#3hc(107398918));
					return;
				}
				this.SetError(#Phc.#3hc(107398918), error);
			}
		}

		// Token: 0x17000F9F RID: 3999
		// (get) Token: 0x06002FFC RID: 12284 RVA: 0x0002AAB8 File Offset: 0x00028CB8
		// (set) Token: 0x06002FFD RID: 12285 RVA: 0x000F70BC File Offset: 0x000F52BC
		public #fU CoverType
		{
			get
			{
				return this.#v;
			}
			set
			{
				if (this.#v != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107354239));
					this.#v = value;
					this.#b.CoverType = value;
					this.#wP();
					base.RaisePropertyChanged(#Phc.#3hc(107354239));
				}
			}
		}

		// Token: 0x17000FA0 RID: 4000
		// (get) Token: 0x06002FFE RID: 12286 RVA: 0x0002AAC4 File Offset: 0x00028CC4
		public RadObservableCollection<ComboItem<BarDimensionSpecifierType>> BarDimensionSpecifierTypes { get; }

		// Token: 0x17000FA1 RID: 4001
		// (get) Token: 0x06002FFF RID: 12287 RVA: 0x0002AAD0 File Offset: 0x00028CD0
		public RadObservableCollection<ComboItem<#fU>> CoverTypes { get; }

		// Token: 0x17000FA2 RID: 4002
		// (get) Token: 0x06003000 RID: 12288 RVA: 0x0002AADC File Offset: 0x00028CDC
		public RadObservableCollection<ComboItem<BarPlacementType>> BarPlacementTypes { get; }

		// Token: 0x17000FA3 RID: 4003
		// (get) Token: 0x06003001 RID: 12289 RVA: 0x0002AAE8 File Offset: 0x00028CE8
		public RadObservableCollection<ComboItem<bool>> KeepEndBarsOptions { get; }

		// Token: 0x17000FA4 RID: 4004
		// (get) Token: 0x06003002 RID: 12290 RVA: 0x0002AAF4 File Offset: 0x00028CF4
		// (set) Token: 0x06003003 RID: 12291 RVA: 0x0002AB00 File Offset: 0x00028D00
		public bool KeepEndBars
		{
			get
			{
				return this.#x;
			}
			set
			{
				if (this.#x != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107354226));
					this.#x = value;
					base.RaisePropertyChanged(#Phc.#3hc(107354226));
				}
			}
		}

		// Token: 0x17000FA5 RID: 4005
		// (get) Token: 0x06003004 RID: 12292 RVA: 0x0002AB3E File Offset: 0x00028D3E
		// (set) Token: 0x06003005 RID: 12293 RVA: 0x0002AB4A File Offset: 0x00028D4A
		public Visibility IncludeEndBarsVisibility
		{
			get
			{
				return this.#y;
			}
			set
			{
				if (this.#y != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107354177));
					this.#y = value;
					base.RaisePropertyChanged(#Phc.#3hc(107354177));
				}
			}
		}

		// Token: 0x17000FA6 RID: 4006
		// (get) Token: 0x06003006 RID: 12294 RVA: 0x0002AB88 File Offset: 0x00028D88
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x06003007 RID: 12295 RVA: 0x000F7118 File Offset: 0x000F5318
		protected double #Pb<#06>(UnitValueGroups #3r, UnitValueGroups #4r, Func<UnitValueGroups, ColumnUnit<#06>> #Z6, double #c4) where #06 : struct, IComparable
		{
			ColumnUnit<#06> columnUnit = #Z6(#3r);
			ColumnUnit<#06> #b = #Z6(#4r);
			return columnUnit.#a4(#b, #c4);
		}

		// Token: 0x06003008 RID: 12296 RVA: 0x000F714C File Offset: 0x000F534C
		public virtual void #5b()
		{
			base.Services.MouseAndKeyboard.#F2c(base.View, true);
			if (this.#f)
			{
				this.#6Eb();
			}
			this.#4Eb(false);
			this.#u = new UnitSystem?(base.Project.Model.Options.Unit);
			this.#9Eb();
			this.#aFb();
			base.RaisePropertyChanged(#Phc.#3hc(107398779));
			base.RaisePropertyChanged(#Phc.#3hc(107398918));
			this.#wP();
		}

		// Token: 0x06003009 RID: 12297 RVA: 0x000F71F4 File Offset: 0x000F53F4
		public double? #3Eb()
		{
			BarDimensionSpecifierType barDimensionSpecifierType = this.BarDimensionSpecifierType;
			if (barDimensionSpecifierType == BarDimensionSpecifierType.Area)
			{
				return new double?(this.BarArea);
			}
			if (barDimensionSpecifierType != BarDimensionSpecifierType.Size)
			{
				throw new ArgumentOutOfRangeException();
			}
			StandardBar standardBar = base.Project.Model.Bars.FirstOrDefault(new Func<StandardBar, bool>(this.#fWh));
			float? num = (standardBar != null) ? new float?(standardBar.Area) : null;
			if (num == null)
			{
				return null;
			}
			return new double?((double)num.GetValueOrDefault());
		}

		// Token: 0x0600300A RID: 12298 RVA: 0x000F72A0 File Offset: 0x000F54A0
		protected virtual void #4Eb(bool #nz)
		{
			if (this.#f && !#nz)
			{
				return;
			}
			this.#f = true;
			this.#b.#eb(#nz);
			UnitSystem unitSystem = base.Project.Model.Options.Unit;
			StandardBar standardBar = base.Project.Model.Bars.FirstOrDefault<StandardBar>();
			this.BarSize = ((standardBar != null) ? standardBar.Size : -1);
			if (!base.Project.Model.Bars.Any<StandardBar>())
			{
				this.BarArea = (double)((unitSystem == UnitSystem.SIMetric) ? 25 : 1);
			}
			else if (this.BarSize >= 0)
			{
				StandardBar standardBar2 = base.Project.Model.Bars.FirstOrDefault(new Func<StandardBar, bool>(this.#gWh));
				if (standardBar2 != null)
				{
					this.BarArea = (double)standardBar2.Area;
				}
			}
			this.Cover = this.#b.Cover;
			this.CoverType = this.#b.CoverType;
			this.NumberOfBarsX = 7;
			this.NumberOfBarsY = 7;
			this.BarSpacingX = (double)((unitSystem == UnitSystem.SIMetric) ? 100 : 4);
			this.BarSpacingY = (double)((unitSystem == UnitSystem.SIMetric) ? 100 : 4);
			this.KeepEndBars = true;
		}

		// Token: 0x0600300B RID: 12299 RVA: 0x0002AB98 File Offset: 0x00028D98
		private void #owb(object #Ge, EventArgs #He)
		{
			this.#6Eb();
		}

		// Token: 0x0600300C RID: 12300 RVA: 0x000F73E4 File Offset: 0x000F55E4
		private void #cl(object #Ge, #7V #He)
		{
			BarParametersToolViewModelBase.#EVd #EVd = new BarParametersToolViewModelBase.#EVd();
			#EVd.#a = this;
			#EVd.#b = #He;
			bool #nz = !#EVd.#b.IsUndoRedo;
			this.#B = true;
			this.#4Eb(#nz);
			if (#EVd.#b.IsUndoRedo)
			{
				try
				{
					if (this.#u != null && this.#u.Value != #EVd.#b.NewModel.Options.Unit)
					{
						this.#EO(this, EventArgs.Empty);
					}
					this.#6Eb();
					return;
				}
				finally
				{
					this.#B = false;
				}
			}
			LayoutHelper.BeginInvokeOnApplicationThread(new Action(#EVd.#J9b));
		}

		// Token: 0x0600300D RID: 12301 RVA: 0x0002ABA8 File Offset: 0x00028DA8
		private void #5Eb(object #Ge, #7V #He)
		{
			this.#t = new int?(this.BarSize);
			this.#u = new UnitSystem?(base.Project.Model.Options.Unit);
		}

		// Token: 0x0600300E RID: 12302 RVA: 0x000F74BC File Offset: 0x000F56BC
		private void #EO(object #Ge, EventArgs #He)
		{
			UnitSystem unitSystem = base.Project.Model.Options.Unit;
			UnitValueGroups #3r = (unitSystem == UnitSystem.SIMetric) ? base.Project.Model.EnglishUnits : base.Project.Model.MetricUnits;
			UnitValueGroups #4r = (unitSystem == UnitSystem.SIMetric) ? base.Project.Model.MetricUnits : base.Project.Model.EnglishUnits;
			this.#8Eb(#3r, #4r);
		}

		// Token: 0x0600300F RID: 12303 RVA: 0x000F7548 File Offset: 0x000F5748
		private void #wP()
		{
			this.#7Eb();
			if (this.#w)
			{
				return;
			}
			if (!this.#B)
			{
				this.#a.SnappingCache.#wP(base.Project.Model);
			}
			this.#a.Renderer.#eg();
		}

		// Token: 0x06003010 RID: 12304 RVA: 0x000F75A4 File Offset: 0x000F57A4
		private void #6Eb()
		{
			if (this.#t != null)
			{
				StandardBar standardBar = this.#a.Project.Model.Bars.FirstOrDefault(new Func<StandardBar, bool>(this.#hWh));
				int num;
				if (standardBar == null)
				{
					StandardBar standardBar2 = this.#a.Project.Model.Bars.FirstOrDefault<StandardBar>();
					num = ((standardBar2 != null) ? standardBar2.Size : -1);
				}
				else
				{
					num = standardBar.Size;
				}
				this.#e = num;
			}
			else
			{
				StandardBar standardBar3 = this.#a.Project.Model.Bars.FirstOrDefault<StandardBar>();
				this.#e = ((standardBar3 != null) ? standardBar3.Size : -1);
			}
			base.RaisePropertyChanged(#Phc.#3hc(107398779));
		}

		// Token: 0x06003011 RID: 12305 RVA: 0x000F7678 File Offset: 0x000F5878
		private void #7Eb()
		{
			base.Services.Settings.RuntimeSettings.Cover = this.#h;
			double? num = this.#3Eb();
			base.Services.Settings.RuntimeSettings.BarRadius = ((num != null && num.Value > 0.0) ? CircleHelper.#wmc(num.Value) : 0.0);
			base.Services.Settings.RuntimeSettings.CoverType = this.CoverType;
		}

		// Token: 0x06003012 RID: 12306 RVA: 0x000F7728 File Offset: 0x000F5928
		private void #8Eb(UnitValueGroups #3r, UnitValueGroups #4r)
		{
			if (base.IsValid)
			{
				this.BarArea = this.#Pb<AreaUnit>(#3r, #4r, new Func<UnitValueGroups, ColumnUnit<AreaUnit>>(BarParametersToolViewModelBase.<>c.<>9.#K0h), this.BarArea);
				this.BarSpacingX = this.#Pb<LengthUnit>(#3r, #4r, new Func<UnitValueGroups, ColumnUnit<LengthUnit>>(BarParametersToolViewModelBase.<>c.<>9.#L0h), this.BarSpacingX);
				this.BarSpacingY = this.#Pb<LengthUnit>(#3r, #4r, new Func<UnitValueGroups, ColumnUnit<LengthUnit>>(BarParametersToolViewModelBase.<>c.<>9.#M0h), this.BarSpacingY);
				this.Cover = this.#b.Cover;
			}
			else
			{
				this.#4Eb(true);
			}
			this.#9Eb();
		}

		// Token: 0x06003013 RID: 12307 RVA: 0x000F7818 File Offset: 0x000F5A18
		private void #9Eb()
		{
			this.#h = this.#b.Cover;
			base.RaisePropertyChanged(#Phc.#3hc(107354216));
			this.#v = this.#b.CoverType;
			base.RaisePropertyChanged(#Phc.#3hc(107354239));
		}

		// Token: 0x06003014 RID: 12308 RVA: 0x000F7874 File Offset: 0x000F5A74
		private void #aFb()
		{
			if (this.BarPlacementYVisibility == Visibility.Collapsed)
			{
				BarPlacementType barPlacementType = this.BarPlacementType;
				if (barPlacementType == BarPlacementType.Numbers)
				{
					this.BarPlacementXLabel = Strings.StringNumberOfBars;
					return;
				}
				if (barPlacementType != BarPlacementType.Spacing)
				{
					throw new ArgumentOutOfRangeException();
				}
				this.BarPlacementXLabel = Strings.StringBarSpacing;
				return;
			}
			else
			{
				BarPlacementType barPlacementType2 = this.BarPlacementType;
				if (barPlacementType2 == BarPlacementType.Numbers)
				{
					this.BarPlacementXLabel = Strings.StringNoInXDirection;
					this.BarPlacementYLabel = Strings.StringNoInYDirection;
					return;
				}
				if (barPlacementType2 != BarPlacementType.Spacing)
				{
					throw new ArgumentOutOfRangeException();
				}
				this.BarPlacementXLabel = Strings.StringSpacingInXDirection;
				this.BarPlacementYLabel = Strings.StringSpacingInYDirection;
				return;
			}
		}

		// Token: 0x06003015 RID: 12309 RVA: 0x0002ABE7 File Offset: 0x00028DE7
		[CompilerGenerated]
		private bool #fWh(StandardBar #Rf)
		{
			return #Rf.Size == this.BarSize;
		}

		// Token: 0x06003016 RID: 12310 RVA: 0x0002ABE7 File Offset: 0x00028DE7
		[CompilerGenerated]
		private bool #gWh(StandardBar #Rf)
		{
			return #Rf.Size == this.BarSize;
		}

		// Token: 0x06003017 RID: 12311 RVA: 0x0002AC03 File Offset: 0x00028E03
		[CompilerGenerated]
		private bool #hWh(StandardBar #Rf)
		{
			return #Rf.Size == this.#t.Value;
		}

		// Token: 0x04001352 RID: 4946
		private readonly IExtendedServices #a;

		// Token: 0x04001353 RID: 4947
		private readonly #JFb #b;

		// Token: 0x04001354 RID: 4948
		private BarDimensionSpecifierType #c;

		// Token: 0x04001355 RID: 4949
		private double #d;

		// Token: 0x04001356 RID: 4950
		private int #e;

		// Token: 0x04001357 RID: 4951
		private bool #f;

		// Token: 0x04001358 RID: 4952
		private readonly #MBb #g;

		// Token: 0x04001359 RID: 4953
		private double #h;

		// Token: 0x0400135A RID: 4954
		private BarPlacementType #i;

		// Token: 0x0400135B RID: 4955
		private double #j;

		// Token: 0x0400135C RID: 4956
		private double #k;

		// Token: 0x0400135D RID: 4957
		private int #l;

		// Token: 0x0400135E RID: 4958
		private int #m;

		// Token: 0x0400135F RID: 4959
		private string #n;

		// Token: 0x04001360 RID: 4960
		private string #o;

		// Token: 0x04001361 RID: 4961
		private Visibility #p = Visibility.Collapsed;

		// Token: 0x04001362 RID: 4962
		private Visibility #q = Visibility.Collapsed;

		// Token: 0x04001363 RID: 4963
		private int #r = 2;

		// Token: 0x04001364 RID: 4964
		private int #s = #dde.Instance.BarsAtOnce;

		// Token: 0x04001365 RID: 4965
		private int? #t;

		// Token: 0x04001366 RID: 4966
		private UnitSystem? #u;

		// Token: 0x04001367 RID: 4967
		private #fU #v;

		// Token: 0x04001368 RID: 4968
		private bool #w;

		// Token: 0x04001369 RID: 4969
		private bool #x = true;

		// Token: 0x0400136A RID: 4970
		private Visibility #y = Visibility.Collapsed;

		// Token: 0x0400136B RID: 4971
		private Visibility #z;

		// Token: 0x0400136C RID: 4972
		private bool #A;

		// Token: 0x0400136D RID: 4973
		private bool #B;

		// Token: 0x0400136E RID: 4974
		[CompilerGenerated]
		private readonly RadObservableCollection<ComboItem<BarDimensionSpecifierType>> #C = new RadObservableCollection<ComboItem<BarDimensionSpecifierType>>
		{
			new ComboItem<BarDimensionSpecifierType>(BarDimensionSpecifierType.Size, Strings.StringSize),
			new ComboItem<BarDimensionSpecifierType>(BarDimensionSpecifierType.Area, Strings.StringArea)
		};

		// Token: 0x0400136F RID: 4975
		[CompilerGenerated]
		private readonly RadObservableCollection<ComboItem<#fU>> #D = new RadObservableCollection<ComboItem<#fU>>
		{
			new ComboItem<#fU>(#fU.#a, Strings.StringClear),
			new ComboItem<#fU>(#fU.#b, Strings.StringToBarCenter)
		};

		// Token: 0x04001370 RID: 4976
		[CompilerGenerated]
		private readonly RadObservableCollection<ComboItem<BarPlacementType>> #E = new RadObservableCollection<ComboItem<BarPlacementType>>
		{
			new ComboItem<BarPlacementType>(BarPlacementType.Numbers, Strings.StringNumbers),
			new ComboItem<BarPlacementType>(BarPlacementType.Spacing, Strings.StringSpacing)
		};

		// Token: 0x04001371 RID: 4977
		[CompilerGenerated]
		private readonly RadObservableCollection<ComboItem<bool>> #F = new RadObservableCollection<ComboItem<bool>>
		{
			new ComboItem<bool>(true, Strings.StringYes),
			new ComboItem<bool>(false, Strings.StringNo)
		};

		// Token: 0x0200053E RID: 1342
		[CompilerGenerated]
		private sealed class #EVd
		{
			// Token: 0x0600301E RID: 12318 RVA: 0x000F7918 File Offset: 0x000F5B18
			internal void #J9b()
			{
				try
				{
					this.#a.#w = true;
					this.#a.#u = new UnitSystem?(this.#b.NewModel.Options.Unit);
					this.#a.#t = new int?(this.#a.BarSize);
					this.#a.BarDimensionSpecifierType = BarDimensionSpecifierType.Size;
					this.#a.CoverType = #fU.#a;
					this.#a.BarPlacementType = BarPlacementType.Numbers;
				}
				finally
				{
					this.#a.#w = false;
					this.#a.#B = false;
				}
			}

			// Token: 0x04001376 RID: 4982
			public BarParametersToolViewModelBase #a;

			// Token: 0x04001377 RID: 4983
			public #7V #b;
		}

		// Token: 0x0200053F RID: 1343
		[CompilerGenerated]
		private sealed class #QTb
		{
			// Token: 0x06003020 RID: 12320 RVA: 0x0002AC34 File Offset: 0x00028E34
			internal bool #I9b(StandardBar #Rf)
			{
				return #Rf.Size == this.#a;
			}

			// Token: 0x04001378 RID: 4984
			public int #a;
		}
	}
}
