using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using #3Qb;
using #6re;
using #7hc;
using #eU;
using #lH;
using #RJb;
using StructurePoint.CoreAssets.AppManager.Column.Engineer;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.Products.Column.FailureSurface.Views;
using StructurePoint.Products.Column.Model.Entities;
using StructurePoint.Products.Column.Services.API;

namespace #Mbb
{
	// Token: 0x02000406 RID: 1030
	internal sealed class #9eb : #rH<IDisplayOptionsWindow>, INotifyPropertyChanged, #kH<IDisplayOptionsWindow>, IViewModel<IDisplayOptionsWindow>, IViewModel, #Vgb
	{
		// Token: 0x06002439 RID: 9273 RVA: 0x00022787 File Offset: 0x00020987
		public #9eb(IExtendedServices #0c, Lazy<IDisplayOptionsWindow> #Ee, #BLb #ql, #qW #1c) : base(#Ee, #0c, Strings.StringDisplayOptions)
		{
			this.#a = #1c;
			this.#s = #ql;
			this.#b = #0c.Settings;
		}

		// Token: 0x17000C62 RID: 3170
		// (get) Token: 0x0600243A RID: 9274 RVA: 0x000227B1 File Offset: 0x000209B1
		public #BLb ScopesManager { get; }

		// Token: 0x17000C63 RID: 3171
		// (get) Token: 0x0600243B RID: 9275 RVA: 0x000227BD File Offset: 0x000209BD
		// (set) Token: 0x0600243C RID: 9276 RVA: 0x000227C9 File Offset: 0x000209C9
		public bool AreViewControlsVisible
		{
			get
			{
				return this.#j;
			}
			set
			{
				if (this.#j != value)
				{
					this.#j = value;
					this.#4eb();
					base.RaisePropertyChanged(#Phc.#3hc(107362728));
				}
			}
		}

		// Token: 0x17000C64 RID: 3172
		// (get) Token: 0x0600243D RID: 9277 RVA: 0x000227FD File Offset: 0x000209FD
		// (set) Token: 0x0600243E RID: 9278 RVA: 0x00022809 File Offset: 0x00020A09
		public bool Diagram2DShowLoadPoints
		{
			get
			{
				return this.#c;
			}
			set
			{
				if (this.#c != value)
				{
					this.#c = value;
					this.#4eb();
					base.RaisePropertyChanged(#Phc.#3hc(107362695));
				}
			}
		}

		// Token: 0x17000C65 RID: 3173
		// (get) Token: 0x0600243F RID: 9279 RVA: 0x0002283D File Offset: 0x00020A3D
		// (set) Token: 0x06002440 RID: 9280 RVA: 0x00022849 File Offset: 0x00020A49
		public bool ShowNominalFailureSurface
		{
			get
			{
				return this.#d;
			}
			set
			{
				if (this.#d != value)
				{
					this.#d = value;
					this.#4eb();
					base.RaisePropertyChanged(#Phc.#3hc(107362662));
				}
			}
		}

		// Token: 0x17000C66 RID: 3174
		// (get) Token: 0x06002441 RID: 9281 RVA: 0x0002287D File Offset: 0x00020A7D
		// (set) Token: 0x06002442 RID: 9282 RVA: 0x00022889 File Offset: 0x00020A89
		public bool IsShowNominalFailureSurfaceEnabled
		{
			get
			{
				return this.#k;
			}
			set
			{
				if (this.#k != value)
				{
					this.#k = value;
					this.#4eb();
					base.RaisePropertyChanged(#Phc.#3hc(107362625));
				}
			}
		}

		// Token: 0x17000C67 RID: 3175
		// (get) Token: 0x06002443 RID: 9283 RVA: 0x000228BD File Offset: 0x00020ABD
		// (set) Token: 0x06002444 RID: 9284 RVA: 0x000228C9 File Offset: 0x00020AC9
		public bool ShowFactoredFailureSurface
		{
			get
			{
				return this.#e;
			}
			set
			{
				if (this.#e != value)
				{
					this.#e = value;
					this.#4eb();
					base.RaisePropertyChanged(#Phc.#3hc(107362608));
				}
			}
		}

		// Token: 0x17000C68 RID: 3176
		// (get) Token: 0x06002445 RID: 9285 RVA: 0x000228FD File Offset: 0x00020AFD
		// (set) Token: 0x06002446 RID: 9286 RVA: 0x00022909 File Offset: 0x00020B09
		public bool Diagram2DShowLoadPointLabels
		{
			get
			{
				return this.#f;
			}
			set
			{
				if (this.#f != value)
				{
					this.#f = value;
					this.#4eb();
					base.RaisePropertyChanged(#Phc.#3hc(107362027));
				}
			}
		}

		// Token: 0x17000C69 RID: 3177
		// (get) Token: 0x06002447 RID: 9287 RVA: 0x0002293D File Offset: 0x00020B3D
		// (set) Token: 0x06002448 RID: 9288 RVA: 0x00022949 File Offset: 0x00020B49
		public bool Diagram2DShowAxialLoadLabels
		{
			get
			{
				return this.#g;
			}
			set
			{
				if (this.#g != value)
				{
					this.#g = value;
					this.#4eb();
					base.RaisePropertyChanged(#Phc.#3hc(107361986));
				}
			}
		}

		// Token: 0x17000C6A RID: 3178
		// (get) Token: 0x06002449 RID: 9289 RVA: 0x0002297D File Offset: 0x00020B7D
		// (set) Token: 0x0600244A RID: 9290 RVA: 0x00022989 File Offset: 0x00020B89
		public bool Diagram2DShowSpliceLines
		{
			get
			{
				return this.#h;
			}
			set
			{
				if (this.#h != value)
				{
					this.#h = value;
					this.#4eb();
					base.RaisePropertyChanged(#Phc.#3hc(107361977));
				}
			}
		}

		// Token: 0x17000C6B RID: 3179
		// (get) Token: 0x0600244B RID: 9291 RVA: 0x000229BD File Offset: 0x00020BBD
		// (set) Token: 0x0600244C RID: 9292 RVA: 0x000229C9 File Offset: 0x00020BC9
		public bool Diagram2DShowFactoredDiagramTop
		{
			get
			{
				return this.#i;
			}
			set
			{
				if (this.#i != value)
				{
					this.#i = value;
					this.#4eb();
					base.RaisePropertyChanged(#Phc.#3hc(107361944));
				}
			}
		}

		// Token: 0x17000C6C RID: 3180
		// (get) Token: 0x0600244D RID: 9293 RVA: 0x000229FD File Offset: 0x00020BFD
		// (set) Token: 0x0600244E RID: 9294 RVA: 0x00022A09 File Offset: 0x00020C09
		public bool Diagram2DShowCapacityRatioPoints
		{
			get
			{
				return this.#l;
			}
			set
			{
				if (this.#l != value)
				{
					this.#l = value;
					this.#4eb();
					base.RaisePropertyChanged(#Phc.#3hc(107361867));
				}
			}
		}

		// Token: 0x17000C6D RID: 3181
		// (get) Token: 0x0600244F RID: 9295 RVA: 0x00022A3D File Offset: 0x00020C3D
		// (set) Token: 0x06002450 RID: 9296 RVA: 0x000CF248 File Offset: 0x000CD448
		public bool SectionAnnotationsVisibility
		{
			get
			{
				return this.#n;
			}
			set
			{
				if (this.#n != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107401955));
					this.#n = value;
					this.#4eb();
					base.RaisePropertyChanged(#Phc.#3hc(107401955));
				}
			}
		}

		// Token: 0x17000C6E RID: 3182
		// (get) Token: 0x06002451 RID: 9297 RVA: 0x00022A49 File Offset: 0x00020C49
		// (set) Token: 0x06002452 RID: 9298 RVA: 0x000CF298 File Offset: 0x000CD498
		public bool SectionCoverVisibility
		{
			get
			{
				return this.#m;
			}
			set
			{
				if (this.#m != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107361854));
					this.#m = value;
					this.#4eb();
					base.RaisePropertyChanged(#Phc.#3hc(107361854));
				}
			}
		}

		// Token: 0x17000C6F RID: 3183
		// (get) Token: 0x06002453 RID: 9299 RVA: 0x00022A55 File Offset: 0x00020C55
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x17000C70 RID: 3184
		// (get) Token: 0x06002454 RID: 9300 RVA: 0x00022A65 File Offset: 0x00020C65
		// (set) Token: 0x06002455 RID: 9301 RVA: 0x00022A71 File Offset: 0x00020C71
		public bool IsUniaxial
		{
			get
			{
				return this.#p;
			}
			set
			{
				this.SetProperty<bool>(ref this.#p, value, #Phc.#3hc(107361821));
			}
		}

		// Token: 0x17000C71 RID: 3185
		// (get) Token: 0x06002456 RID: 9302 RVA: 0x00022A97 File Offset: 0x00020C97
		// (set) Token: 0x06002457 RID: 9303 RVA: 0x00022AA3 File Offset: 0x00020CA3
		public bool HasAnyLoadPoints
		{
			get
			{
				return this.#q;
			}
			set
			{
				this.SetProperty<bool>(ref this.#q, value, #Phc.#3hc(107362284));
			}
		}

		// Token: 0x17000C72 RID: 3186
		// (get) Token: 0x06002458 RID: 9304 RVA: 0x00022AC9 File Offset: 0x00020CC9
		// (set) Token: 0x06002459 RID: 9305 RVA: 0x00022AD5 File Offset: 0x00020CD5
		public bool AreResultsAvailable
		{
			get
			{
				return this.#r;
			}
			set
			{
				this.SetProperty<bool>(ref this.#r, value, #Phc.#3hc(107362291));
			}
		}

		// Token: 0x0600245A RID: 9306 RVA: 0x00022AFB File Offset: 0x00020CFB
		protected override void #0l()
		{
			base.#0l();
			this.#hz(true);
		}

		// Token: 0x0600245B RID: 9307 RVA: 0x00022B16 File Offset: 0x00020D16
		private void #4eb()
		{
			if (this.#o)
			{
				return;
			}
			this.#6eb();
		}

		// Token: 0x0600245C RID: 9308 RVA: 0x00022B33 File Offset: 0x00020D33
		private void #4l(#qRb #5eb)
		{
			this.SectionAnnotationsVisibility = #5eb.SectionAnnotationsVisibility;
			this.SectionCoverVisibility = #5eb.CoverVisibility;
		}

		// Token: 0x0600245D RID: 9309 RVA: 0x000CF2E8 File Offset: 0x000CD4E8
		private void #6eb()
		{
			this.#b.ViewControlsPanelVisible = this.AreViewControlsVisible;
			this.#b.Diagram3DAreLoadPointsVisible = this.Diagram2DShowLoadPoints;
			#5re #5re = base.Services.ReporterSettings.#jJ();
			#5re.ShowLoadPoints = this.Diagram2DShowLoadPoints;
			#5re.ShowLoadPointsLabels = this.Diagram2DShowLoadPointLabels;
			#5re.ShowAxialLoadLabels = this.Diagram2DShowAxialLoadLabels;
			#5re.ShowSpliceLines = this.Diagram2DShowSpliceLines;
			#5re.ShowFactoredDiagramTop = this.Diagram2DShowFactoredDiagramTop;
			#5re.ShowCapacityRatioPoints = this.Diagram2DShowCapacityRatioPoints;
			base.Services.ReporterSettings.#iJ(#5re);
			this.#b.ShowNominal = this.ShowNominalFailureSurface;
			this.#b.ShowFactored = this.ShowFactoredFailureSurface;
			#qRb #qRb = base.Services.Settings.#ZN();
			#qRb.SectionAnnotationsVisibility = this.SectionAnnotationsVisibility;
			#qRb.CoverVisibility = this.SectionCoverVisibility;
			base.Services.Settings.#0N(#qRb);
			base.Services.MessageBus.#IV();
		}

		// Token: 0x0600245E RID: 9310 RVA: 0x000CF40C File Offset: 0x000CD60C
		private void #hz(bool #7eb)
		{
			this.#o = true;
			this.AreViewControlsVisible = this.#b.ViewControlsPanelVisible;
			#5re #5re = base.Services.ReporterSettings.#jJ();
			this.Diagram2DShowLoadPoints = #5re.ShowLoadPoints;
			this.Diagram2DShowLoadPointLabels = #5re.ShowLoadPointsLabels;
			this.Diagram2DShowAxialLoadLabels = #5re.ShowAxialLoadLabels;
			this.Diagram2DShowSpliceLines = #5re.ShowSpliceLines;
			this.Diagram2DShowFactoredDiagramTop = #5re.ShowFactoredDiagramTop;
			this.ShowNominalFailureSurface = this.#b.ShowNominal;
			this.ShowFactoredFailureSurface = this.#b.ShowFactored;
			this.Diagram2DShowCapacityRatioPoints = #5re.ShowCapacityRatioPoints;
			this.IsShowNominalFailureSurfaceEnabled = #7eb;
			this.#4l(base.Services.Settings.#ZN());
			this.IsUniaxial = (base.Project.Model.Options.ConsideredAxis != ConsideredAxis.Both);
			this.HasAnyLoadPoints = ((base.Project.Model.Options.ActiveLoad == LoadType.Factored && base.Project.Model.FactoredLoads.Any<FactoredLoad>()) || (base.Project.Model.Options.ActiveLoad == LoadType.Service && base.Project.Model.ServiceLoads.Any<ServiceLoad>()));
			DesignEngine designEngine = this.#a.DesignEngine;
			this.AreResultsAvailable = (((designEngine != null) ? designEngine.OutputModel : null) != null && this.#a.DesignEngine.OutputModel.SolveCompleted);
			this.#o = false;
		}

		// Token: 0x0600245F RID: 9311 RVA: 0x0000C67D File Offset: 0x0000A87D
		bool #kH<IDisplayOptionsWindow>.#8eb()
		{
			return base.IsValid;
		}

		// Token: 0x04000E6E RID: 3694
		private readonly #qW #a;

		// Token: 0x04000E6F RID: 3695
		private readonly ISettingsManager #b;

		// Token: 0x04000E70 RID: 3696
		private bool #c;

		// Token: 0x04000E71 RID: 3697
		private bool #d;

		// Token: 0x04000E72 RID: 3698
		private bool #e;

		// Token: 0x04000E73 RID: 3699
		private bool #f;

		// Token: 0x04000E74 RID: 3700
		private bool #g;

		// Token: 0x04000E75 RID: 3701
		private bool #h;

		// Token: 0x04000E76 RID: 3702
		private bool #i;

		// Token: 0x04000E77 RID: 3703
		private bool #j;

		// Token: 0x04000E78 RID: 3704
		private bool #k;

		// Token: 0x04000E79 RID: 3705
		private bool #l;

		// Token: 0x04000E7A RID: 3706
		private bool #m;

		// Token: 0x04000E7B RID: 3707
		private bool #n;

		// Token: 0x04000E7C RID: 3708
		private bool #o;

		// Token: 0x04000E7D RID: 3709
		private bool #p;

		// Token: 0x04000E7E RID: 3710
		private bool #q;

		// Token: 0x04000E7F RID: 3711
		private bool #r;

		// Token: 0x04000E80 RID: 3712
		[CompilerGenerated]
		private readonly #BLb #s;
	}
}
