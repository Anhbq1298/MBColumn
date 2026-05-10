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
	// Token: 0x02000107 RID: 263
	internal sealed class #gm : #rH<#Hb>, INotifyPropertyChanged, #kH<#Hb>, IViewModel<#Hb>, IViewModel, #Hm
	{
		// Token: 0x0600089E RID: 2206 RVA: 0x0000C812 File Offset: 0x0000AA12
		public #gm(Lazy<#Hb> #Ee, IExtendedServices #0c, #jB #pl, IEditorService #wj, #zJ #pj) : base(#Ee, #0c, Strings.StringDrawingGrid_CAMEL)
		{
			this.#a = #pl;
			this.#b = #wj;
			this.#c = #pj;
		}

		// Token: 0x170003C0 RID: 960
		// (get) Token: 0x0600089F RID: 2207 RVA: 0x0000C838 File Offset: 0x0000AA38
		// (set) Token: 0x060008A0 RID: 2208 RVA: 0x00093454 File Offset: 0x00091654
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

		// Token: 0x170003C1 RID: 961
		// (get) Token: 0x060008A1 RID: 2209 RVA: 0x0000C844 File Offset: 0x0000AA44
		// (set) Token: 0x060008A2 RID: 2210 RVA: 0x000934B8 File Offset: 0x000916B8
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

		// Token: 0x170003C2 RID: 962
		// (get) Token: 0x060008A3 RID: 2211 RVA: 0x0000C850 File Offset: 0x0000AA50
		// (set) Token: 0x060008A4 RID: 2212 RVA: 0x0009351C File Offset: 0x0009171C
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

		// Token: 0x170003C3 RID: 963
		// (get) Token: 0x060008A5 RID: 2213 RVA: 0x0000C85C File Offset: 0x0000AA5C
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x060008A6 RID: 2214 RVA: 0x0000C86C File Offset: 0x0000AA6C
		public override bool #cm()
		{
			return base.#cm() || !base.IsValid;
		}

		// Token: 0x060008A7 RID: 2215 RVA: 0x0000C88D File Offset: 0x0000AA8D
		protected override void #0l()
		{
			base.#0l();
			this.#4l(base.Services.Project.Model.DraftingSettings.DrawingGridSettings);
		}

		// Token: 0x060008A8 RID: 2216 RVA: 0x0000C8C1 File Offset: 0x0000AAC1
		protected override void #1l()
		{
			this.#2l();
			base.#mH();
			base.#1l();
		}

		// Token: 0x060008A9 RID: 2217 RVA: 0x0009356C File Offset: 0x0009176C
		private void #2l()
		{
			#gm.#wWb #wWb = new #gm.#wWb();
			#wWb.#b = this;
			#wWb.#a = base.Services.Project.Model.DraftingSettings.DrawingGridSettings;
			if (#wWb.#a.SpacingX == this.SpacingX && #wWb.#a.SpacingY == this.SpacingY && #wWb.#a.EqualXAndYSpacing == this.EqualXAndYSpacing)
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
			base.Services.Settings.DrawingGrid = #wWb.#a;
			base.Services.SnappingCache.#uP(base.Services.Project);
		}

		// Token: 0x060008AA RID: 2218 RVA: 0x000936A8 File Offset: 0x000918A8
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

		// Token: 0x060008AB RID: 2219 RVA: 0x000936FC File Offset: 0x000918FC
		private void #4l(#j7 #ng)
		{
			this.#f = false;
			this.SpacingX = #ng.SpacingX;
			this.SpacingY = #ng.SpacingY;
			this.EqualXAndYSpacing = #ng.EqualXAndYSpacing;
			base.RaisePropertyChanged(#Phc.#3hc(107380921));
		}

		// Token: 0x060008AC RID: 2220 RVA: 0x0000C67D File Offset: 0x0000A87D
		bool #kH<#Hb>.#fm()
		{
			return base.IsValid;
		}

		// Token: 0x040002C1 RID: 705
		private readonly #jB #a;

		// Token: 0x040002C2 RID: 706
		private readonly IEditorService #b;

		// Token: 0x040002C3 RID: 707
		private readonly #zJ #c;

		// Token: 0x040002C4 RID: 708
		private double #d;

		// Token: 0x040002C5 RID: 709
		private double #e;

		// Token: 0x040002C6 RID: 710
		private bool #f;

		// Token: 0x02000108 RID: 264
		[CompilerGenerated]
		private sealed class #wWb
		{
			// Token: 0x060008AE RID: 2222 RVA: 0x00093750 File Offset: 0x00091950
			internal void #5Ub()
			{
				this.#a.SpacingY = this.#b.SpacingY;
				this.#a.SpacingX = this.#b.SpacingX;
				this.#a.EqualXAndYSpacing = this.#b.EqualXAndYSpacing;
			}

			// Token: 0x040002C7 RID: 711
			public #j7 #a;

			// Token: 0x040002C8 RID: 712
			public #gm #b;
		}
	}
}
