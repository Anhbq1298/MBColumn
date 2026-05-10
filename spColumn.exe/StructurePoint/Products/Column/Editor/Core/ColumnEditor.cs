using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using #7hc;
using #eU;
using #hR;
using #N7d;
using #RJb;
using devDept.Eyeshot;
using devDept.Geometry;
using devDept.Graphics;
using StructurePoint.CoreAssets.GUI.DesktopControls.Editor;
using StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core;
using StructurePoint.CoreAssets.Units;
using StructurePoint.CoreAssets.Units.UnitSets;
using StructurePoint.Products.Column.Services.Rendering;

namespace StructurePoint.Products.Column.Editor.Core
{
	// Token: 0x02000649 RID: 1609
	internal sealed class ColumnEditor : EyeshotEditor
	{
		// Token: 0x06003607 RID: 13831 RVA: 0x00109A4C File Offset: 0x00107C4C
		public ColumnEditor() : base(true)
		{
			this.#c = new DrawingHelper(this);
			this.#d = new #tS();
			this.#b = new #jR(this.CoreRendererModel);
			base.Camera.ProjectionMode = projectionType.Perspective;
			this.#e = new List<BaseCoreRenderer>
			{
				new #JT(this.CoreRendererModel),
				new #vS(this.CoreRendererModel),
				new #WR(this.CoreRendererModel),
				new #uS(this.CoreRendererModel),
				new #gR(this.CoreRendererModel),
				new #6Ti(this.CoreRendererModel),
				this.TemplatesCoreRenderer
			};
			base.ZoomFitMarginAddition = 5;
		}

		// Token: 0x170010DB RID: 4315
		// (get) Token: 0x06003608 RID: 13832 RVA: 0x0002F575 File Offset: 0x0002D775
		public #jR TemplatesCoreRenderer { get; }

		// Token: 0x170010DC RID: 4316
		// (get) Token: 0x06003609 RID: 13833 RVA: 0x0002F581 File Offset: 0x0002D781
		public DrawingHelper DrawingHelper { get; }

		// Token: 0x170010DD RID: 4317
		// (get) Token: 0x0600360A RID: 13834 RVA: 0x0002F58D File Offset: 0x0002D78D
		public #tS CoreRendererModel { get; }

		// Token: 0x170010DE RID: 4318
		// (get) Token: 0x0600360B RID: 13835 RVA: 0x0002F599 File Offset: 0x0002D799
		protected List<BaseCoreRenderer> CoreRenderers { get; }

		// Token: 0x0600360C RID: 13836 RVA: 0x00109B18 File Offset: 0x00107D18
		public void #WJb(IUnit #B6, IUnit #A6)
		{
			#M8d #M8d = new LengthConverter();
			LengthUnit #B7 = (LengthUnit)#B6.UnitCode;
			LengthUnit #K7d = (LengthUnit)#A6.UnitCode;
			Point3D location = base.Camera.Location;
			Point3D target = base.Camera.Target;
			Vector3D vector3D = new Vector3D(target, location);
			target.X = #M8d.#Pb(#K7d, #B7, target.X);
			target.Y = #M8d.#Pb(#K7d, #B7, target.Y);
			target.Z = #M8d.#Pb(#K7d, #B7, target.Z);
			Vector3D vector3D2 = new Vector3D();
			vector3D2.X = #M8d.#Pb(#K7d, #B7, vector3D.X);
			vector3D2.Y = #M8d.#Pb(#K7d, #B7, vector3D.Y);
			vector3D2.Z = #M8d.#Pb(#K7d, #B7, vector3D.Z);
			Point3D point3D = new Point3D();
			point3D.X = target.X + vector3D2.X;
			point3D.Y = target.Y + vector3D2.Y;
			point3D.Z = target.Z + vector3D2.Z;
			base.Camera.Location = point3D;
			base.AdjustNearAndFarPlanes();
			base.Entities.UpdateBoundingBox();
			base.Camera.UpdateLocation();
		}

		// Token: 0x0600360D RID: 13837 RVA: 0x0002F5A5 File Offset: 0x0002D7A5
		public void #nR(#dU #ib)
		{
			if (#ib == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107400797));
			}
			this.#f = #ib;
		}

		// Token: 0x0600360E RID: 13838 RVA: 0x00109C84 File Offset: 0x00107E84
		public void #nR(#cLb #ib)
		{
			ColumnEditor.#DUb #DUb = new ColumnEditor.#DUb();
			#DUb.#a = #ib;
			#cLb #cLb = #DUb.#a;
			if (#cLb == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107400797));
			}
			this.#a = #cLb;
			this.CoreRendererModel.ShowCoordinateSign = #DUb.#a.Settings.ShowCoordinateSystemSign;
			this.CoreRendererModel.ShowCentroid = #DUb.#a.Settings.ObjectCentroid;
			this.CoreRenderers.ForEach(new Action<BaseCoreRenderer>(#DUb.#ccc));
			base.Logger = #DUb.#a.Logger;
		}

		// Token: 0x0600360F RID: 13839 RVA: 0x00109D3C File Offset: 0x00107F3C
		protected override void DrawOverlay(devDept.Eyeshot.Environment.DrawSceneParams data)
		{
			if (this.CoreRendererModel.ShowCoordinateSign)
			{
				this.DrawingHelper.DrawCoordinateOrigin();
			}
			this.CoreRenderers.ForEach(new Action<BaseCoreRenderer>(ColumnEditor.<>c.<>9.#dcc));
			base.DrawOverlay(data);
		}

		// Token: 0x06003610 RID: 13840 RVA: 0x0002F5CE File Offset: 0x0002D7CE
		protected override bool ShouldDrawDynamicInput()
		{
			#dU #dU = this.#f;
			if (#dU == null)
			{
				return base.ShouldDrawDynamicInput();
			}
			return !#dU.ToolsBlockedByPropertiesPanel;
		}

		// Token: 0x06003611 RID: 13841 RVA: 0x0002F5F5 File Offset: 0x0002D7F5
		protected void #XJb(devDept.Eyeshot.Environment.DrawSceneParams #Gfb)
		{
			base.renderContext.ClearColor(Color.White);
		}

		// Token: 0x06003612 RID: 13842 RVA: 0x00109DA0 File Offset: 0x00107FA0
		protected override void RecalculateZoomFitMargin()
		{
			double actualWidth = base.ActualWidth;
			double actualHeight = base.ActualHeight;
			if (actualWidth > 0.0 && actualHeight > 0.0)
			{
				double num = (actualWidth + actualHeight) / 2.0;
				base.Zoom.FitMargin = (int)(0.05 * num) + base.ZoomFitMarginAddition;
				return;
			}
			if (base.ZoomFitMarginAddition > 0)
			{
				base.Zoom.FitMargin = base.ZoomFitMarginAddition;
			}
		}

		// Token: 0x0400167F RID: 5759
		private #cLb #a;

		// Token: 0x04001680 RID: 5760
		[CompilerGenerated]
		private readonly #jR #b;

		// Token: 0x04001681 RID: 5761
		[CompilerGenerated]
		private readonly DrawingHelper #c;

		// Token: 0x04001682 RID: 5762
		[CompilerGenerated]
		private readonly #tS #d;

		// Token: 0x04001683 RID: 5763
		[CompilerGenerated]
		private readonly List<BaseCoreRenderer> #e;

		// Token: 0x04001684 RID: 5764
		private #dU #f;

		// Token: 0x0200064B RID: 1611
		[CompilerGenerated]
		private sealed class #DUb
		{
			// Token: 0x06003617 RID: 13847 RVA: 0x0002F633 File Offset: 0x0002D833
			internal void #ccc(BaseCoreRenderer #Rf)
			{
				#Rf.#nR(this.#a);
			}

			// Token: 0x04001687 RID: 5767
			public #cLb #a;
		}
	}
}
