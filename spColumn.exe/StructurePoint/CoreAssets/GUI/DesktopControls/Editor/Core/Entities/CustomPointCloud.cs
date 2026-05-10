using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using devDept.Graphics;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core.Entities
{
	// Token: 0x02000B20 RID: 2848
	public sealed class CustomPointCloud : PointCloud, IVisuallyOrderedEntity
	{
		// Token: 0x06005D4E RID: 23886 RVA: 0x0004DC61 File Offset: 0x0004BE61
		protected CustomPointCloud()
		{
		}

		// Token: 0x06005D4F RID: 23887 RVA: 0x0004DC69 File Offset: 0x0004BE69
		public CustomPointCloud(IList<Point3D> points) : base(points)
		{
		}

		// Token: 0x06005D50 RID: 23888 RVA: 0x0004DC72 File Offset: 0x0004BE72
		public CustomPointCloud(IList<Point3D> points, float pointSize) : base(points, pointSize)
		{
		}

		// Token: 0x06005D51 RID: 23889 RVA: 0x0004DC7C File Offset: 0x0004BE7C
		public CustomPointCloud(int numPoints, float pointSize, PointCloud.natureType nature) : base(numPoints, pointSize, nature)
		{
		}

		// Token: 0x06005D52 RID: 23890 RVA: 0x0004DC87 File Offset: 0x0004BE87
		protected CustomPointCloud(PointCloud another) : base(another)
		{
		}

		// Token: 0x06005D53 RID: 23891 RVA: 0x0004DC90 File Offset: 0x0004BE90
		public CustomPointCloud(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}

		// Token: 0x17001A8E RID: 6798
		// (get) Token: 0x06005D54 RID: 23892 RVA: 0x0004DC9A File Offset: 0x0004BE9A
		// (set) Token: 0x06005D55 RID: 23893 RVA: 0x0004DCA2 File Offset: 0x0004BEA2
		public double VisualOrder { get; set; }

		// Token: 0x06005D56 RID: 23894 RVA: 0x00175710 File Offset: 0x00173910
		protected override void Draw(DrawParams data)
		{
			data.RenderContext.PushShader();
			data.RenderContext.SetShader(shaderType.NoLights, null, true);
			data.RenderContext.PushBlendState();
			data.RenderContext.SetState(blendStateType.Blend);
			data.RenderContext.SetColorWireframe(this.Color, false);
			base.Draw(data);
			data.RenderContext.PopBlendState();
			data.RenderContext.PopShader();
		}
	}
}
