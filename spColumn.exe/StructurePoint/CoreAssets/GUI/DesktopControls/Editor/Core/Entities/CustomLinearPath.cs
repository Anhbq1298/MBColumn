using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using devDept.Graphics;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core.Entities
{
	// Token: 0x02000B1F RID: 2847
	public sealed class CustomLinearPath : LinearPath, IVisuallyOrderedEntity
	{
		// Token: 0x06005D41 RID: 23873 RVA: 0x0004DBF0 File Offset: 0x0004BDF0
		public CustomLinearPath(int numVertices) : base(numVertices)
		{
		}

		// Token: 0x06005D42 RID: 23874 RVA: 0x0004DBF9 File Offset: 0x0004BDF9
		public CustomLinearPath(ICollection<Point3D> points) : base(points)
		{
		}

		// Token: 0x06005D43 RID: 23875 RVA: 0x0004DC02 File Offset: 0x0004BE02
		public CustomLinearPath(params Point3D[] points) : base(points)
		{
		}

		// Token: 0x06005D44 RID: 23876 RVA: 0x0004DC0B File Offset: 0x0004BE0B
		public CustomLinearPath(Plane sketchPlane, params Point2D[] points) : base(sketchPlane, points)
		{
		}

		// Token: 0x06005D45 RID: 23877 RVA: 0x0004DC15 File Offset: 0x0004BE15
		public CustomLinearPath(double width, double height) : base(width, height)
		{
		}

		// Token: 0x06005D46 RID: 23878 RVA: 0x0004DC1F File Offset: 0x0004BE1F
		public CustomLinearPath(double x, double y, double width, double height) : base(x, y, width, height)
		{
		}

		// Token: 0x06005D47 RID: 23879 RVA: 0x0004DC2C File Offset: 0x0004BE2C
		protected CustomLinearPath(LinearPath another) : base(another)
		{
		}

		// Token: 0x06005D48 RID: 23880 RVA: 0x0004DC35 File Offset: 0x0004BE35
		public CustomLinearPath(SerializationInfo info, StreamingContext ctxt) : base(info, ctxt)
		{
		}

		// Token: 0x17001A8C RID: 6796
		// (get) Token: 0x06005D49 RID: 23881 RVA: 0x0004DC3F File Offset: 0x0004BE3F
		// (set) Token: 0x06005D4A RID: 23882 RVA: 0x0004DC47 File Offset: 0x0004BE47
		public double VisualOrder { get; set; }

		// Token: 0x17001A8D RID: 6797
		// (get) Token: 0x06005D4B RID: 23883 RVA: 0x0004DC50 File Offset: 0x0004BE50
		// (set) Token: 0x06005D4C RID: 23884 RVA: 0x0004DC58 File Offset: 0x0004BE58
		public ushort Stipple { get; set; }

		// Token: 0x06005D4D RID: 23885 RVA: 0x00175640 File Offset: 0x00173840
		protected override void Draw(DrawParams data)
		{
			data.RenderContext.SetLineSize(this.LineWeight, true, false);
			bool flag = this.Stipple > 0;
			data.RenderContext.PushShader();
			data.RenderContext.SetShader(shaderType.NoLights, null, true);
			data.RenderContext.PushBlendState();
			data.RenderContext.SetState(blendStateType.Blend);
			if (flag)
			{
				data.RenderContext.EndDrawBufferedLines();
				data.RenderContext.SetLineStipple(2, this.Stipple, data.Viewport.Camera);
				data.RenderContext.EnableLineStipple(true);
			}
			base.Draw(data);
			if (flag)
			{
				data.RenderContext.EndDrawBufferedLines();
				data.RenderContext.EnableLineStipple(false);
			}
			data.RenderContext.PopBlendState();
			data.RenderContext.PopShader();
		}
	}
}
