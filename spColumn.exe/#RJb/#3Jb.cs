using System;
using System.Runtime.CompilerServices;
using #6re;
using #8Cc;
using #eU;
using #o1d;
using devDept.Eyeshot;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.DesktopControls.Editor;
using StructurePoint.CoreAssets.GUI.DesktopControls.Editor.API;
using StructurePoint.CoreAssets.Logger;
using StructurePoint.Products.Column.Editor.Core;
using StructurePoint.Products.Column.Editor.Core.Selection;
using StructurePoint.Products.Column.Services.API;

namespace #RJb
{
	// Token: 0x02000663 RID: 1635
	internal sealed class #3Jb : NotifyPropertyChangedObjectBase, IDisposable, #cLb, IEyeshotToolContext
	{
		// Token: 0x06003701 RID: 14081 RVA: 0x0010C208 File Offset: 0x0010A408
		public #3Jb(ISettingsManager #ng, #oW #xn, #bDc #DJ, #0V #bL, #yse #tA, ILogger #3x, #dU #5c)
		{
			this.#a = #5c;
			this.#f = #ng;
			this.#h = #xn;
			this.#i = #DJ;
			this.#l = #bL;
			this.#g = #tA;
			this.#j = #3x;
			this.#m = new SelectionManager(new ObjectsSelector(this));
		}

		// Token: 0x17001109 RID: 4361
		// (get) Token: 0x06003702 RID: 14082 RVA: 0x0002FF44 File Offset: 0x0002E144
		public #8Jb RenderOptions { get; }

		// Token: 0x1700110A RID: 4362
		// (get) Token: 0x06003703 RID: 14083 RVA: 0x0002FF50 File Offset: 0x0002E150
		public #aMb ViewportOptions { get; }

		// Token: 0x1700110B RID: 4363
		// (get) Token: 0x06003704 RID: 14084 RVA: 0x0002FF5C File Offset: 0x0002E15C
		public ISettingsManager Settings { get; }

		// Token: 0x1700110C RID: 4364
		// (get) Token: 0x06003705 RID: 14085 RVA: 0x0002FF68 File Offset: 0x0002E168
		public #yse ReporterSettings { get; }

		// Token: 0x1700110D RID: 4365
		// (get) Token: 0x06003706 RID: 14086 RVA: 0x0002FF74 File Offset: 0x0002E174
		public #oW ProjectContext { get; }

		// Token: 0x1700110E RID: 4366
		// (get) Token: 0x06003707 RID: 14087 RVA: 0x0002FF80 File Offset: 0x0002E180
		public #bDc UndoManager { get; }

		// Token: 0x1700110F RID: 4367
		// (get) Token: 0x06003708 RID: 14088 RVA: 0x0002FF8C File Offset: 0x0002E18C
		public ILogger Logger { get; }

		// Token: 0x17001110 RID: 4368
		// (get) Token: 0x06003709 RID: 14089 RVA: 0x0002FF98 File Offset: 0x0002E198
		// (set) Token: 0x0600370A RID: 14090 RVA: 0x0002FFA4 File Offset: 0x0002E1A4
		public #2Lb Snapping { get; private set; }

		// Token: 0x17001111 RID: 4369
		// (get) Token: 0x0600370B RID: 14091 RVA: 0x0002FFB5 File Offset: 0x0002E1B5
		public #0V SnappingCache { get; }

		// Token: 0x17001112 RID: 4370
		// (get) Token: 0x0600370C RID: 14092 RVA: 0x0002FFC1 File Offset: 0x0002E1C1
		public SelectionManager Selection { get; }

		// Token: 0x17001113 RID: 4371
		// (get) Token: 0x0600370D RID: 14093 RVA: 0x0010C278 File Offset: 0x0010A478
		public EyeshotEditor Editor
		{
			get
			{
				if (this.#b == null)
				{
					#3Jb.#p6b #p6b = new #3Jb.#p6b();
					#3Jb.#p6b #p6b2;
					if (6 != 0)
					{
						#p6b2 = #p6b;
					}
					this.#b = new ColumnEditor();
					this.Snapping = new #2Lb(this.SnappingCache, this.Settings, this.#b);
					this.#b.#nR(this);
					if (this.#a != null)
					{
						this.#b.#nR(this.#a);
					}
					this.#c = new DrawingGrid(this.Settings, this.ProjectContext);
					this.#b.Viewports.#I1d(new Action<Viewport>(this.#2Jb));
					#p6b2.#a = new #KLb(this.Settings, this.ProjectContext);
					this.#b.Viewports.#I1d(new Action<Viewport>(#p6b2.#ecc));
				}
				return this.#b;
			}
		}

		// Token: 0x0600370E RID: 14094 RVA: 0x0002FFCD File Offset: 0x0002E1CD
		public void #1()
		{
			SelectionManager selectionManager = this.Selection;
			if (selectionManager != null)
			{
				selectionManager.#1();
			}
			ColumnEditor columnEditor = this.#b;
			if (columnEditor == null)
			{
				return;
			}
			columnEditor.Dispose();
		}

		// Token: 0x0600370F RID: 14095 RVA: 0x0002FFFC File Offset: 0x0002E1FC
		[CompilerGenerated]
		private void #2Jb(Viewport #pd)
		{
			#pd.Grids.Add(this.#c);
		}

		// Token: 0x040016EB RID: 5867
		private readonly #dU #a;

		// Token: 0x040016EC RID: 5868
		private ColumnEditor #b;

		// Token: 0x040016ED RID: 5869
		private DrawingGrid #c;

		// Token: 0x040016EE RID: 5870
		[CompilerGenerated]
		private readonly #8Jb #d = new #8Jb();

		// Token: 0x040016EF RID: 5871
		[CompilerGenerated]
		private readonly #aMb #e = new #aMb();

		// Token: 0x040016F0 RID: 5872
		[CompilerGenerated]
		private readonly ISettingsManager #f;

		// Token: 0x040016F1 RID: 5873
		[CompilerGenerated]
		private readonly #yse #g;

		// Token: 0x040016F2 RID: 5874
		[CompilerGenerated]
		private readonly #oW #h;

		// Token: 0x040016F3 RID: 5875
		[CompilerGenerated]
		private readonly #bDc #i;

		// Token: 0x040016F4 RID: 5876
		[CompilerGenerated]
		private readonly ILogger #j;

		// Token: 0x040016F5 RID: 5877
		[CompilerGenerated]
		private #2Lb #k;

		// Token: 0x040016F6 RID: 5878
		[CompilerGenerated]
		private readonly #0V #l;

		// Token: 0x040016F7 RID: 5879
		[CompilerGenerated]
		private readonly SelectionManager #m;

		// Token: 0x02000664 RID: 1636
		[CompilerGenerated]
		private sealed class #p6b
		{
			// Token: 0x06003711 RID: 14097 RVA: 0x0003001B File Offset: 0x0002E21B
			internal void #ecc(Viewport #pd)
			{
				#pd.Grids.Add(this.#a);
			}

			// Token: 0x040016F8 RID: 5880
			public #KLb #a;
		}
	}
}
