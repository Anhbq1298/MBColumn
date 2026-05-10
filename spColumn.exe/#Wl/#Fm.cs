using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using #7hc;
using #f7;
using #Gb;
using #kB;
using #lH;
using #qJ;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.Products.Column.Core.API;
using StructurePoint.Products.Column.Services.API;

namespace #Wl
{
	// Token: 0x02000111 RID: 273
	internal sealed class #Fm : #rH<#Kb>, INotifyPropertyChanged, #kH<#Kb>, IViewModel<#Kb>, IViewModel, #Km
	{
		// Token: 0x060008DB RID: 2267 RVA: 0x0000CCD8 File Offset: 0x0000AED8
		public #Fm(Lazy<#Kb> #Ee, IExtendedServices #0c, #jB #pl, IEditorService #wj, #zJ #pj) : base(#Ee, #0c, Strings.StringSnap)
		{
			this.#a = #pl;
			this.#b = #wj;
			this.#c = #pj;
		}

		// Token: 0x170003D1 RID: 977
		// (get) Token: 0x060008DC RID: 2268 RVA: 0x0000CCFE File Offset: 0x0000AEFE
		// (set) Token: 0x060008DD RID: 2269 RVA: 0x00093D24 File Offset: 0x00091F24
		public double SpacingX
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
					this.#dm(value, #Phc.#3hc(107380947));
					if (base.IsValid && this.EqualXAndYSpacing)
					{
						this.SpacingY = value;
					}
					base.RaisePropertyChanged(#Phc.#3hc(107380947));
				}
			}
		}

		// Token: 0x170003D2 RID: 978
		// (get) Token: 0x060008DE RID: 2270 RVA: 0x0000CD0A File Offset: 0x0000AF0A
		// (set) Token: 0x060008DF RID: 2271 RVA: 0x00093D88 File Offset: 0x00091F88
		public double SpacingY
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
					this.#dm(value, #Phc.#3hc(107380902));
					if (base.IsValid && this.EqualXAndYSpacing)
					{
						this.SpacingX = value;
					}
					base.RaisePropertyChanged(#Phc.#3hc(107380902));
				}
			}
		}

		// Token: 0x170003D3 RID: 979
		// (get) Token: 0x060008E0 RID: 2272 RVA: 0x0000CD16 File Offset: 0x0000AF16
		// (set) Token: 0x060008E1 RID: 2273 RVA: 0x00093DEC File Offset: 0x00091FEC
		public bool EqualXAndYSpacing
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
					if (base.IsValid && value)
					{
						this.SpacingY = this.SpacingX;
					}
					base.RaisePropertyChanged(#Phc.#3hc(107380921));
				}
			}
		}

		// Token: 0x170003D4 RID: 980
		// (get) Token: 0x060008E2 RID: 2274 RVA: 0x0000CD22 File Offset: 0x0000AF22
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x060008E3 RID: 2275 RVA: 0x0000CD32 File Offset: 0x0000AF32
		protected override void #0l()
		{
			base.#0l();
			this.#4l(base.Services.Project.Model.DraftingSettings.SnappingSettings);
		}

		// Token: 0x060008E4 RID: 2276 RVA: 0x0000CD66 File Offset: 0x0000AF66
		protected override void #1l()
		{
			this.#2l();
			base.#mH();
			base.#1l();
		}

		// Token: 0x060008E5 RID: 2277 RVA: 0x0000CD86 File Offset: 0x0000AF86
		public override bool #cm()
		{
			return base.#cm() || !base.IsValid;
		}

		// Token: 0x060008E6 RID: 2278 RVA: 0x00093E3C File Offset: 0x0009203C
		private void #2l()
		{
			#Fm.#wWb #wWb = new #Fm.#wWb();
			#wWb.#b = this;
			#wWb.#a = base.Services.Project.Model.DraftingSettings.SnappingSettings;
			if (#wWb.#a.SnapSpacingX == this.SpacingX && #wWb.#a.SnapSpacingY == this.SpacingY && #wWb.#a.EqualXAndYSpacing == this.EqualXAndYSpacing)
			{
				return;
			}
			using (this.#c.#AA())
			{
				using (this.#a.#AA())
				{
					this.#b.#0Pb(new Action(#wWb.#5Ub));
					this.#a.#DA();
				}
			}
			base.Services.Settings.SnappingSettings = #wWb.#a;
		}

		// Token: 0x060008E7 RID: 2279 RVA: 0x000936A8 File Offset: 0x000918A8
		private void #dm(double #f, [CallerMemberName] string #em = null)
		{
			if (#f <= 0.0)
			{
				this.AddError(#em, Strings.StringTheValueShallBeGreaterThanX.#D2d(new object[]
				{
					#Phc.#3hc(107380864)
				}));
				return;
			}
			base.RemoveError(#em);
		}

		// Token: 0x060008E8 RID: 2280 RVA: 0x00093F5C File Offset: 0x0009215C
		private void #4l(#z7 #ng)
		{
			this.#f = false;
			this.SpacingX = #ng.SnapSpacingX;
			this.SpacingY = #ng.SnapSpacingY;
			this.EqualXAndYSpacing = #ng.EqualXAndYSpacing;
			base.RaisePropertyChanged(#Phc.#3hc(107380921));
		}

		// Token: 0x060008E9 RID: 2281 RVA: 0x0000C67D File Offset: 0x0000A87D
		bool #kH<#Kb>.#Em()
		{
			return base.IsValid;
		}

		// Token: 0x040002E2 RID: 738
		private readonly #jB #a;

		// Token: 0x040002E3 RID: 739
		private readonly IEditorService #b;

		// Token: 0x040002E4 RID: 740
		private readonly #zJ #c;

		// Token: 0x040002E5 RID: 741
		private double #d;

		// Token: 0x040002E6 RID: 742
		private double #e;

		// Token: 0x040002E7 RID: 743
		private bool #f;

		// Token: 0x02000112 RID: 274
		[CompilerGenerated]
		private sealed class #wWb
		{
			// Token: 0x060008EB RID: 2283 RVA: 0x00093FB0 File Offset: 0x000921B0
			internal void #5Ub()
			{
				this.#a.SnapSpacingY = this.#b.SpacingY;
				this.#a.SnapSpacingX = this.#b.SpacingX;
				this.#a.EqualXAndYSpacing = this.#b.EqualXAndYSpacing;
			}

			// Token: 0x040002E8 RID: 744
			public #z7 #a;

			// Token: 0x040002E9 RID: 745
			public #Fm #b;
		}
	}
}
