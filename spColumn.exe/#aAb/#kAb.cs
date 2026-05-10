using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Input;
using #cMb;
using #LFb;
using #N6c;
using #RJb;
using devDept.Eyeshot;
using devDept.Geometry;
using StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.Products.Column.Editor.Core.Tools;
using StructurePoint.Products.Column.Editor.Section.Common;
using StructurePoint.Products.Column.Model;
using StructurePoint.Products.Column.Model.Entities;
using StructurePoint.Products.Column.Services.API;

namespace #aAb
{
	// Token: 0x02000509 RID: 1289
	internal sealed class #kAb : #tNb, #uNb, IChildColumnEditorTool, #ZFb
	{
		// Token: 0x06002EE5 RID: 12005 RVA: 0x00029FAC File Offset: 0x000281AC
		public #kAb(IExtendedServices #pd, #UFb #bX, #1Fb #lAb) : base(#pd)
		{
			this.#a = #bX;
			this.#b = #lAb;
		}

		// Token: 0x17000F78 RID: 3960
		// (get) Token: 0x06002EE6 RID: 12006 RVA: 0x00029FC3 File Offset: 0x000281C3
		// (set) Token: 0x06002EE7 RID: 12007 RVA: 0x000F2404 File Offset: 0x000F0604
		public bool IsEnabled
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
					if (this.#c)
					{
						base.#KMb(Strings.StringSpecifyBasePoint, value, false, true);
						return;
					}
					this.#fAb(false);
					base.#JMb();
				}
			}
		}

		// Token: 0x06002EE8 RID: 12008 RVA: 0x000F2454 File Offset: 0x000F0654
		public bool #bAb(devDept.Geometry.Point3D #cAb, devDept.Geometry.Point3D #dAb, List<ReinforcementBar> #6W, List<ShapeModel> #eAb, bool #gzb)
		{
			#dAb = base.#bNb(#LLb.#n, #dAb);
			if (!this.#hAb(#cAb, #dAb, #gzb))
			{
				return false;
			}
			base.Services.MouseAndKeyboard.#M2c();
			StructurePoint.CoreAssets.Infrastructure.Data.Point #qAb = (#dAb - #cAb).#QW();
			#tAb.#mAb(base.Services.StorageModelConverter, base.EditorContext, #6W, #eAb, #qAb);
			this.#a.#cg(base.EditorContext, false);
			ColumnModelHelper.#VW(base.Project);
			base.EditorContext.SnappingCache.#uP(base.Project);
			base.Renderer.#9f(false, false);
			base.Services.MessageBus.#LV();
			base.Services.MessageBus.#KV();
			base.Services.MessageBus.#tV();
			base.Services.MessageBus.#MV();
			return true;
		}

		// Token: 0x06002EE9 RID: 12009 RVA: 0x000F2554 File Offset: 0x000F0754
		public override void #1kb()
		{
			base.#1kb();
			bool #gAb = this.#f == #kAb.#s6b.#a;
			this.#fAb(#gAb);
		}

		// Token: 0x06002EEA RID: 12010 RVA: 0x000F2584 File Offset: 0x000F0784
		public override bool #fzb(devDept.Geometry.Point3D #Ng, bool #gzb = false)
		{
			if (!base.#WMb(true) || !this.#jAb())
			{
				return false;
			}
			if (this.#f == #kAb.#s6b.#a)
			{
				this.#d = #Ng;
				this.#f = #kAb.#s6b.#b;
				base.#fzb(#Ng, #gzb);
				base.#SMb(Strings.StringSpecifyTranslation, true, false, true);
				base.Editor.DynamicInput.HandleEditorMousePositionChanged(#Ng);
				return true;
			}
			return this.#iAb(#Ng, #gzb);
		}

		// Token: 0x06002EEB RID: 12011 RVA: 0x000289F9 File Offset: 0x00026BF9
		public override void HandleDynamicInputCoordinateCommited(DynamicInputCoordinateEventArgs args)
		{
			base.HandleDynamicInputCoordinateCommited(args);
			args.Handled = this.#fzb(args.Point, true);
		}

		// Token: 0x06002EEC RID: 12012 RVA: 0x00029FCF File Offset: 0x000281CF
		public override void HandleDynamicInputCoordinateChange(DynamicInputCoordinateEventArgs args)
		{
			base.Editor.DynamicInput.ShouldFollowInsertionPoint = true;
			base.HandleDynamicInputCoordinateChange(args);
			this.#e = args.Point;
			base.#vf();
			this.#Bzb();
		}

		// Token: 0x06002EED RID: 12013 RVA: 0x0002A00D File Offset: 0x0002820D
		public override void HandleMouseDown(MouseButtonEventArgs args, System.Drawing.Point screenPosition, devDept.Geometry.Point3D planePosition)
		{
			base.HandleMouseDown(args, screenPosition, planePosition);
			if (this.#hzb(args))
			{
				return;
			}
			planePosition = base.#bNb(#LLb.#n, planePosition);
			this.#fzb(planePosition, false);
		}

		// Token: 0x06002EEE RID: 12014 RVA: 0x0002A045 File Offset: 0x00028245
		public override void HandleMouseUp(MouseButtonEventArgs args, System.Drawing.Point screenPosition, devDept.Geometry.Point3D planePosition)
		{
			base.HandleMouseUp(args, screenPosition, planePosition);
			if (!base.#WMb(true) || !this.#jAb())
			{
				return;
			}
			planePosition = base.#bNb(#LLb.#n, planePosition);
			this.#iAb(planePosition, false);
		}

		// Token: 0x06002EEF RID: 12015 RVA: 0x000F25F8 File Offset: 0x000F07F8
		public override void HandleMouseMove(MouseEventArgs args, System.Drawing.Point screenPosition, devDept.Geometry.Point3D planePosition)
		{
			base.HandleMouseMove(args, screenPosition, planePosition);
			this.#e = null;
			base.Editor.DynamicInput.ShouldFollowInsertionPoint = false;
			if (!base.#WMb(false))
			{
				return;
			}
			base.#bNb(#LLb.#n, planePosition);
			this.#Bzb();
		}

		// Token: 0x06002EF0 RID: 12016 RVA: 0x00028A8D File Offset: 0x00026C8D
		public override void HandleDynamicInputCoordinateSnapRequested(DynamicInputCoordinateSnapEventArgs args)
		{
			args.SnappedPoint = base.#bNb(#LLb.#n, args.InputPoint);
			base.HandleDynamicInputCoordinateSnapRequested(args);
		}

		// Token: 0x06002EF1 RID: 12017 RVA: 0x000F2650 File Offset: 0x000F0850
		public override void HandleDrawOverlay(devDept.Eyeshot.Environment.DrawSceneParams data, System.Drawing.Point screenPosition, devDept.Geometry.Point3D planePosition)
		{
			base.HandleDrawOverlay(data, screenPosition, planePosition);
			planePosition = base.#cNb(#LLb.#n, planePosition);
			base.Services.GuiController.EditorStatusBar.Section.#uP(planePosition);
			if (this.#f == #kAb.#s6b.#b)
			{
				devDept.Geometry.Point3D #qAb = (this.#e ?? planePosition) - this.#d;
				ColumnDisplayHelper.#nHb(base.EditorContext, base.Editor, #qAb);
				base.#8Mb(this.#d, this.#e ?? planePosition);
			}
			if (this.#e != null && this.#f == #kAb.#s6b.#a)
			{
				base.#9Mb(this.#e);
			}
		}

		// Token: 0x06002EF2 RID: 12018 RVA: 0x000F2718 File Offset: 0x000F0918
		protected override bool #hzb(MouseButtonEventArgs #Lg)
		{
			bool result = base.#hzb(#Lg);
			#Lg.Handled = true;
			return result;
		}

		// Token: 0x06002EF3 RID: 12019 RVA: 0x000F2744 File Offset: 0x000F0944
		private void #fAb(bool #gAb)
		{
			this.#f = #kAb.#s6b.#a;
			this.#e = null;
			base.Editor.DynamicInput.ShouldFollowInsertionPoint = false;
			base.#KMb(Strings.StringSpecifyBasePoint, true, false, true);
			if (#gAb)
			{
				base.Services.MessageBus.#uV(this);
			}
			base.#vf();
		}

		// Token: 0x06002EF4 RID: 12020 RVA: 0x0002A085 File Offset: 0x00028285
		private void #Bzb()
		{
			if (this.#f == #kAb.#s6b.#b)
			{
				base.Renderer.#cg();
			}
		}

		// Token: 0x06002EF5 RID: 12021 RVA: 0x000F27A4 File Offset: 0x000F09A4
		private bool #hAb(devDept.Geometry.Point3D #cAb, devDept.Geometry.Point3D #dAb, bool #gzb)
		{
			double #1Mb = #gzb ? 0.0 : base.EditorContext.Snapping.#NLb();
			return base.#4Mb(#cAb, #dAb, #1Mb);
		}

		// Token: 0x06002EF6 RID: 12022 RVA: 0x000F27E8 File Offset: 0x000F09E8
		private bool #iAb(devDept.Geometry.Point3D #dAb, bool #gzb)
		{
			if (this.#f != #kAb.#s6b.#b)
			{
				return false;
			}
			int count = base.EditorContext.Selection.Bars.SelectedObjects.Count;
			if (!this.#b.#wAb(count))
			{
				this.#fAb(true);
				return false;
			}
			if (!this.#bAb(this.#d, #dAb, base.EditorContext.Selection.Bars.SelectedObjects.ToList<ReinforcementBar>(), base.EditorContext.Selection.Shapes.SelectedObjects.ToList<ShapeModel>(), #gzb))
			{
				return false;
			}
			this.#f = #kAb.#s6b.#a;
			this.#fAb(true);
			return true;
		}

		// Token: 0x06002EF7 RID: 12023 RVA: 0x000F28A8 File Offset: 0x000F0AA8
		private bool #jAb()
		{
			#47c<ShapeModel> source = base.EditorContext.Selection.Shapes.SelectedObjects;
			#47c<ReinforcementBar> source2 = base.EditorContext.Selection.Bars.SelectedObjects;
			return source.Any<ShapeModel>() || source2.Any<ReinforcementBar>();
		}

		// Token: 0x040012CF RID: 4815
		private readonly #UFb #a;

		// Token: 0x040012D0 RID: 4816
		private readonly #1Fb #b;

		// Token: 0x040012D1 RID: 4817
		private bool #c;

		// Token: 0x040012D2 RID: 4818
		private devDept.Geometry.Point3D #d;

		// Token: 0x040012D3 RID: 4819
		private devDept.Geometry.Point3D #e;

		// Token: 0x040012D4 RID: 4820
		private #kAb.#s6b #f;

		// Token: 0x0200050A RID: 1290
		private enum #s6b
		{
			// Token: 0x040012D6 RID: 4822
			#a,
			// Token: 0x040012D7 RID: 4823
			#b
		}
	}
}
