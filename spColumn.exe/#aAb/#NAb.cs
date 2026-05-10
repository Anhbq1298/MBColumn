using System;
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
	// Token: 0x0200051D RID: 1309
	internal sealed class #NAb : #tNb, #uNb, IChildColumnEditorTool, #3Fb
	{
		// Token: 0x06002F48 RID: 12104 RVA: 0x00028AFF File Offset: 0x00026CFF
		public #NAb(IExtendedServices #pd) : base(#pd)
		{
		}

		// Token: 0x17000F7F RID: 3967
		// (get) Token: 0x06002F49 RID: 12105 RVA: 0x0002A3DB File Offset: 0x000285DB
		// (set) Token: 0x06002F4A RID: 12106 RVA: 0x000F4420 File Offset: 0x000F2620
		public bool IsEnabled
		{
			get
			{
				return this.#a;
			}
			set
			{
				if (this.#a != value)
				{
					this.#a = value;
					if (this.#a)
					{
						base.#KMb(Strings.StringSpecifyBasePoint, value, false, true);
						return;
					}
					this.#fAb(false);
					base.#JMb();
				}
			}
		}

		// Token: 0x06002F4B RID: 12107 RVA: 0x000F4470 File Offset: 0x000F2670
		public override void #1kb()
		{
			base.#1kb();
			bool #gAb = this.#e == #NAb.#s6b.#a;
			this.#fAb(#gAb);
		}

		// Token: 0x06002F4C RID: 12108 RVA: 0x000F44A0 File Offset: 0x000F26A0
		public override bool #fzb(devDept.Geometry.Point3D #Ng, bool #gzb = false)
		{
			if (!base.#WMb(true) || !this.#jAb())
			{
				return false;
			}
			if (this.#e == #NAb.#s6b.#a)
			{
				this.#b = #Ng;
				this.#c = #Ng;
				this.#e = #NAb.#s6b.#b;
				base.#fzb(#Ng, #gzb);
				base.#SMb(Strings.StringSpecifyTranslation, true, false, true);
				base.Editor.DynamicInput.HandleEditorMousePositionChanged(#Ng);
				return true;
			}
			return this.#iAb(#Ng, #gzb);
		}

		// Token: 0x06002F4D RID: 12109 RVA: 0x000289F9 File Offset: 0x00026BF9
		public override void HandleDynamicInputCoordinateCommited(DynamicInputCoordinateEventArgs args)
		{
			base.HandleDynamicInputCoordinateCommited(args);
			args.Handled = this.#fzb(args.Point, true);
		}

		// Token: 0x06002F4E RID: 12110 RVA: 0x000F451C File Offset: 0x000F271C
		public override void HandleDynamicInputCoordinateChange(DynamicInputCoordinateEventArgs args)
		{
			base.Editor.DynamicInput.ShouldFollowInsertionPoint = true;
			base.HandleDynamicInputCoordinateChange(args);
			this.#d = args.Point;
			base.#vf();
			this.#Bzb(args.Point);
		}

		// Token: 0x06002F4F RID: 12111 RVA: 0x0002A00D File Offset: 0x0002820D
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

		// Token: 0x06002F50 RID: 12112 RVA: 0x0002A3E7 File Offset: 0x000285E7
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

		// Token: 0x06002F51 RID: 12113 RVA: 0x000F456C File Offset: 0x000F276C
		public override void HandleMouseMove(MouseEventArgs args, System.Drawing.Point screenPosition, devDept.Geometry.Point3D planePosition)
		{
			base.HandleMouseMove(args, screenPosition, planePosition);
			this.#d = null;
			base.Editor.DynamicInput.ShouldFollowInsertionPoint = false;
			if (!base.#WMb(false))
			{
				return;
			}
			planePosition = base.#bNb(#LLb.#n, planePosition);
			this.#Bzb(planePosition);
		}

		// Token: 0x06002F52 RID: 12114 RVA: 0x00028A8D File Offset: 0x00026C8D
		public override void HandleDynamicInputCoordinateSnapRequested(DynamicInputCoordinateSnapEventArgs args)
		{
			args.SnappedPoint = base.#bNb(#LLb.#n, args.InputPoint);
			base.HandleDynamicInputCoordinateSnapRequested(args);
		}

		// Token: 0x06002F53 RID: 12115 RVA: 0x000F45C8 File Offset: 0x000F27C8
		public override void HandleDrawOverlay(devDept.Eyeshot.Environment.DrawSceneParams data, System.Drawing.Point screenPosition, devDept.Geometry.Point3D planePosition)
		{
			base.HandleDrawOverlay(data, screenPosition, planePosition);
			planePosition = base.#cNb(#LLb.#n, planePosition);
			base.Services.GuiController.EditorStatusBar.Section.#uP(planePosition);
			if (this.#e == #NAb.#s6b.#b)
			{
				devDept.Geometry.Point3D #qAb = (this.#d ?? planePosition) - this.#b;
				ColumnDisplayHelper.#nHb(base.EditorContext, base.Editor, #qAb);
				base.#8Mb(this.#b, this.#d ?? planePosition);
			}
			if (this.#d != null && this.#e == #NAb.#s6b.#a)
			{
				base.#9Mb(this.#d);
			}
		}

		// Token: 0x06002F54 RID: 12116 RVA: 0x000F2718 File Offset: 0x000F0918
		protected override bool #hzb(MouseButtonEventArgs #Lg)
		{
			bool result = base.#hzb(#Lg);
			#Lg.Handled = true;
			return result;
		}

		// Token: 0x06002F55 RID: 12117 RVA: 0x000F4690 File Offset: 0x000F2890
		private void #fAb(bool #gAb)
		{
			this.#e = #NAb.#s6b.#a;
			this.#d = null;
			base.Editor.DynamicInput.ShouldFollowInsertionPoint = false;
			base.#KMb(Strings.StringSpecifyBasePoint, true, false, true);
			base.Services.GuiController.MessageStatusBar.#uP(string.Empty);
			if (#gAb)
			{
				base.Services.MessageBus.#uV(this);
			}
			base.#vf();
		}

		// Token: 0x06002F56 RID: 12118 RVA: 0x0002A427 File Offset: 0x00028627
		private void #Bzb(devDept.Geometry.Point3D #Ng)
		{
			if (this.#e == #NAb.#s6b.#b)
			{
				this.#c = #Ng;
				base.Renderer.#cg();
			}
		}

		// Token: 0x06002F57 RID: 12119 RVA: 0x000F470C File Offset: 0x000F290C
		private bool #hAb(devDept.Geometry.Point3D #Ng, bool #gzb)
		{
			double #1Mb = #gzb ? 0.0 : base.EditorContext.Snapping.#NLb();
			return this.#e == #NAb.#s6b.#b && base.#4Mb(this.#b, #Ng, #1Mb);
		}

		// Token: 0x06002F58 RID: 12120 RVA: 0x000F4760 File Offset: 0x000F2960
		private bool #iAb(devDept.Geometry.Point3D #Ng, bool #gzb)
		{
			if (!this.#hAb(#Ng, #gzb))
			{
				return false;
			}
			base.Services.MouseAndKeyboard.#M2c();
			StructurePoint.CoreAssets.Infrastructure.Data.Point #qAb = (this.#c - this.#b).#QW();
			this.#c = #Ng;
			#RAb.#OAb(base.EditorContext, base.EditorContext.Selection.Shapes.SelectedObjects.ToList<ShapeModel>(), base.EditorContext.Selection.Bars.SelectedObjects.ToList<ReinforcementBar>(), #qAb);
			ColumnModelHelper.#VW(base.Project);
			base.EditorContext.Snapping.Cache.#uP(base.Project);
			this.#e = #NAb.#s6b.#a;
			base.Services.MessageBus.#tV();
			base.Renderer.#9f(false, false);
			this.#fAb(true);
			return true;
		}

		// Token: 0x06002F59 RID: 12121 RVA: 0x000F28A8 File Offset: 0x000F0AA8
		private bool #jAb()
		{
			#47c<ShapeModel> source = base.EditorContext.Selection.Shapes.SelectedObjects;
			#47c<ReinforcementBar> source2 = base.EditorContext.Selection.Bars.SelectedObjects;
			return source.Any<ShapeModel>() || source2.Any<ReinforcementBar>();
		}

		// Token: 0x0400130E RID: 4878
		private bool #a;

		// Token: 0x0400130F RID: 4879
		private devDept.Geometry.Point3D #b;

		// Token: 0x04001310 RID: 4880
		private devDept.Geometry.Point3D #c;

		// Token: 0x04001311 RID: 4881
		private devDept.Geometry.Point3D #d;

		// Token: 0x04001312 RID: 4882
		private #NAb.#s6b #e;

		// Token: 0x0200051E RID: 1310
		private enum #s6b
		{
			// Token: 0x04001314 RID: 4884
			#a,
			// Token: 0x04001315 RID: 4885
			#b
		}
	}
}
