using System;
using System.Runtime.CompilerServices;
using System.Windows;
using #APb;
using #eU;
using #RJb;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.Products.Column.Editor.Diagrams;
using StructurePoint.Products.Column.FailureSurface.Views;

namespace #IJb
{
	// Token: 0x02000641 RID: 1601
	internal sealed class #HJb : #TKb, #zLb, #BPb
	{
		// Token: 0x060035E8 RID: 13800 RVA: 0x0002F33E File Offset: 0x0002D53E
		public #HJb(#DPb #cJb, #oW #xn, Lazy<ILeftPanelToolbarView> #JJb, #qW #1c) : base(Strings.StringDiagrams, #xn)
		{
			this.#e = #cJb;
			this.#a = #JJb;
			this.#b = #1c;
		}

		// Token: 0x170010CD RID: 4301
		// (get) Token: 0x060035E9 RID: 13801 RVA: 0x0002F362 File Offset: 0x0002D562
		public override Visibility ToolbarVisibility { get; }

		// Token: 0x170010CE RID: 4302
		// (get) Token: 0x060035EA RID: 13802 RVA: 0x0002F36E File Offset: 0x0002D56E
		public #DPb LeftPanel { get; }

		// Token: 0x170010CF RID: 4303
		// (get) Token: 0x060035EB RID: 13803 RVA: 0x0002F37A File Offset: 0x0002D57A
		public override IView ToolBarView
		{
			get
			{
				this.#a.Value.DataContext = this.LeftPanel;
				return this.#a.Value;
			}
		}

		// Token: 0x170010D0 RID: 4304
		// (get) Token: 0x060035EC RID: 13804 RVA: 0x0002F3A9 File Offset: 0x0002D5A9
		public override IView PanelView
		{
			get
			{
				return this.LeftPanel.View;
			}
		}

		// Token: 0x170010D1 RID: 4305
		// (get) Token: 0x060035ED RID: 13805 RVA: 0x0002F3C2 File Offset: 0x0002D5C2
		public override IViewModel PanelViewModel
		{
			get
			{
				return this.LeftPanel;
			}
		}

		// Token: 0x170010D2 RID: 4306
		// (get) Token: 0x060035EE RID: 13806 RVA: 0x0002F3D2 File Offset: 0x0002D5D2
		public override bool IsPanelViewCreated
		{
			get
			{
				return this.LeftPanel.IsViewCreated;
			}
		}

		// Token: 0x060035EF RID: 13807 RVA: 0x0002F3EB File Offset: 0x0002D5EB
		public override bool #LKb(#ALb #Pc)
		{
			return this.#b.#3Uh();
		}

		// Token: 0x060035F0 RID: 13808 RVA: 0x0002F400 File Offset: 0x0002D600
		public override void #5b(#ALb #Pc)
		{
			DiagramsScopeActivationParameters diagramsScopeActivationParameters;
			if ((diagramsScopeActivationParameters = (#Pc as DiagramsScopeActivationParameters)) == null)
			{
				diagramsScopeActivationParameters = this.#c;
			}
			this.#c = diagramsScopeActivationParameters;
			base.#5b(#Pc);
			this.LeftPanel.#5b();
		}

		// Token: 0x060035F1 RID: 13809 RVA: 0x0002F436 File Offset: 0x0002D636
		public override void #0kb()
		{
			base.#0kb();
			this.LeftPanel.#0kb();
		}

		// Token: 0x04001672 RID: 5746
		private readonly Lazy<ILeftPanelToolbarView> #a;

		// Token: 0x04001673 RID: 5747
		private readonly #qW #b;

		// Token: 0x04001674 RID: 5748
		private DiagramsScopeActivationParameters #c;

		// Token: 0x04001675 RID: 5749
		[CompilerGenerated]
		private readonly Visibility #d;

		// Token: 0x04001676 RID: 5750
		[CompilerGenerated]
		private readonly #DPb #e;
	}
}
