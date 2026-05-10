using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using #aHb;
using #cMb;
using #gOb;
using devDept.Eyeshot;
using devDept.Geometry;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.Products.Column.Editor.Section.Common;
using StructurePoint.Products.Column.Editor.Section.Irregular.Tools.Reinforcement;
using StructurePoint.Products.Column.Model.Entities;
using StructurePoint.Products.Column.Services.API;

namespace #NDb
{
	// Token: 0x0200059B RID: 1435
	internal sealed class #lFb : #tNb, #uNb, #iFb
	{
		// Token: 0x06003252 RID: 12882 RVA: 0x0002C89D File Offset: 0x0002AA9D
		public #lFb(IExtendedServices #0c, #UDb #mFb) : base(#0c)
		{
			this.#a = #mFb;
		}

		// Token: 0x17000FF9 RID: 4089
		// (get) Token: 0x06003253 RID: 12883 RVA: 0x0002C8B8 File Offset: 0x0002AAB8
		public override IView ParametersView
		{
			get
			{
				return this.#a.View;
			}
		}

		// Token: 0x06003254 RID: 12884 RVA: 0x0002C8CD File Offset: 0x0002AACD
		public bool #iWh()
		{
			return this.#a.HasErrors;
		}

		// Token: 0x06003255 RID: 12885 RVA: 0x000FF7DC File Offset: 0x000FD9DC
		public override void OnActivated()
		{
			base.OnActivated();
			this.#a.#twb();
			this.#a.PropertyChanged += this.#kFb;
			this.#a.View.ViewRequestedCancel += this.#jFb;
			base.Services.UndoManager.CompositeActionCompleted += this.#Lh;
			base.#vf();
		}

		// Token: 0x06003256 RID: 12886 RVA: 0x000FF85C File Offset: 0x000FDA5C
		public override void OnDeactivated()
		{
			this.#b.Clear();
			this.#a.PropertyChanged -= this.#kFb;
			this.#a.View.ViewRequestedCancel -= this.#jFb;
			base.Services.UndoManager.CompositeActionCompleted -= this.#Lh;
			this.#c = false;
			base.OnDeactivated();
		}

		// Token: 0x06003257 RID: 12887 RVA: 0x000FF8DC File Offset: 0x000FDADC
		public override void HandleDrawOverlay(devDept.Eyeshot.Environment.DrawSceneParams data, Point screenPosition, Point3D planePosition)
		{
			base.HandleDrawOverlay(data, screenPosition, planePosition);
			IrregularBar irregularBar = this.#a.SelectedItem;
			if (irregularBar != null && irregularBar.Area > 0f)
			{
				Point3D item = new Point3D((double)irregularBar.X, (double)irregularBar.Y);
				double num = Math.Round(CircleHelper.#wmc((double)irregularBar.Area), 3);
				if (num <= 0.001)
				{
					return;
				}
				ColumnShapesHelper.#HHb(new List<Point3D>
				{
					item
				}, num, base.EditorContext, #qHb.#f);
			}
			if (this.#b.Any<ReinforcementBar>())
			{
				ColumnShapesHelper.#HHb(this.#b, base.EditorContext, #qHb.#c, null);
			}
		}

		// Token: 0x06003258 RID: 12888 RVA: 0x000FF99C File Offset: 0x000FDB9C
		public override void HandleMouseMove(MouseEventArgs args, Point screenPosition, Point3D planePosition)
		{
			base.HandleMouseMove(args, screenPosition, planePosition);
			this.#b.Clear();
			if (planePosition != null)
			{
				#oOb #oOb = base.EditorContext.Selection.Selector.#TOb(planePosition);
				if (#oOb != null)
				{
					this.#b.AddRange(#oOb.Bars);
				}
			}
			base.#vf();
		}

		// Token: 0x06003259 RID: 12889 RVA: 0x0002C8E2 File Offset: 0x0002AAE2
		public override void HandleKeyDown(KeyEventArgs args)
		{
			base.HandleKeyDown(args);
			this.#c = (args.Key == Key.Escape);
		}

		// Token: 0x0600325A RID: 12890 RVA: 0x0002C907 File Offset: 0x0002AB07
		public override void HandleKeyUp(KeyEventArgs args)
		{
			base.HandleKeyUp(args);
			if (args.Key == Key.Escape && this.#c)
			{
				base.Services.MessageBus.#vV();
			}
		}

		// Token: 0x0600325B RID: 12891 RVA: 0x000FFA04 File Offset: 0x000FDC04
		public override void HandleMouseDown(MouseButtonEventArgs args, Point screenPosition, Point3D planePosition)
		{
			base.HandleMouseDown(args, screenPosition, planePosition);
			if (this.#hzb(args) || !base.#WMb(true))
			{
				return;
			}
			if (planePosition != null)
			{
				#lFb.#BUb #BUb = new #lFb.#BUb();
				#BUb.#a = base.EditorContext.Selection.Selector.#TOb(planePosition);
				if (#BUb.#a != null && #BUb.#a.Bars.Any<ReinforcementBar>())
				{
					IrregularBar irregularBar = this.#a.Items.FirstOrDefault(new Func<IrregularBar, bool>(#BUb.#Q9b));
					if (irregularBar != null)
					{
						this.#a.SelectedItem = irregularBar;
						this.#a.#zI(irregularBar);
					}
				}
			}
		}

		// Token: 0x0600325C RID: 12892 RVA: 0x0002C93E File Offset: 0x0002AB3E
		private void #jFb(object #Ge, EventArgs #He)
		{
			base.Services.MessageBus.#vV();
		}

		// Token: 0x0600325D RID: 12893 RVA: 0x0002C95C File Offset: 0x0002AB5C
		private void #Lh(object #Ge, EventArgs #He)
		{
			this.#b.Clear();
			base.#vf();
		}

		// Token: 0x0600325E RID: 12894 RVA: 0x0002C95C File Offset: 0x0002AB5C
		private void #kFb(object #Ge, PropertyChangedEventArgs #He)
		{
			this.#b.Clear();
			base.#vf();
		}

		// Token: 0x04001471 RID: 5233
		private readonly #UDb #a;

		// Token: 0x04001472 RID: 5234
		private readonly List<ReinforcementBar> #b = new List<ReinforcementBar>();

		// Token: 0x04001473 RID: 5235
		private bool #c;

		// Token: 0x0200059C RID: 1436
		[CompilerGenerated]
		private sealed class #BUb
		{
			// Token: 0x06003260 RID: 12896 RVA: 0x0002C97B File Offset: 0x0002AB7B
			internal bool #Q9b(IrregularBar #Rf)
			{
				return #Rf.OriginalBar == this.#a.Bars.First<ReinforcementBar>();
			}

			// Token: 0x04001474 RID: 5236
			public #oOb #a;
		}
	}
}
