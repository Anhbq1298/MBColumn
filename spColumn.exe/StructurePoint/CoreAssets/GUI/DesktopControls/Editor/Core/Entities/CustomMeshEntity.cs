using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using devDept.Graphics;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core.Entities
{
	// Token: 0x02000B23 RID: 2851
	public sealed class CustomMeshEntity : Mesh, IVisuallyOrderedEntity
	{
		// Token: 0x06005D79 RID: 23929 RVA: 0x0004DE9D File Offset: 0x0004C09D
		public CustomMeshEntity()
		{
		}

		// Token: 0x06005D7A RID: 23930 RVA: 0x0004DEA5 File Offset: 0x0004C0A5
		public CustomMeshEntity(int numVertices, int numTriangles, Mesh.natureType meshNature) : base(numVertices, numTriangles, meshNature)
		{
		}

		// Token: 0x06005D7B RID: 23931 RVA: 0x0004DEB0 File Offset: 0x0004C0B0
		public CustomMeshEntity(Mesh.natureType meshNature) : base(meshNature)
		{
		}

		// Token: 0x06005D7C RID: 23932 RVA: 0x0004DEB9 File Offset: 0x0004C0B9
		public CustomMeshEntity(Mesh.natureType meshNature, Mesh.edgeStyleType edgeStyle) : base(meshNature, edgeStyle)
		{
		}

		// Token: 0x06005D7D RID: 23933 RVA: 0x0004DEC3 File Offset: 0x0004C0C3
		public CustomMeshEntity(IList<Point3D> vertices, IList<IndexTriangle> triangles) : base(vertices, triangles)
		{
		}

		// Token: 0x06005D7E RID: 23934 RVA: 0x0004DECD File Offset: 0x0004C0CD
		public CustomMeshEntity(Mesh another) : base(another)
		{
		}

		// Token: 0x06005D7F RID: 23935 RVA: 0x0004DED6 File Offset: 0x0004C0D6
		public CustomMeshEntity(SerializationInfo info, StreamingContext ctxt) : base(info, ctxt)
		{
		}

		// Token: 0x17001A97 RID: 6807
		// (get) Token: 0x06005D80 RID: 23936 RVA: 0x0004DEE0 File Offset: 0x0004C0E0
		// (set) Token: 0x06005D81 RID: 23937 RVA: 0x0004DEE8 File Offset: 0x0004C0E8
		public bool Blend { get; set; }

		// Token: 0x17001A98 RID: 6808
		// (get) Token: 0x06005D82 RID: 23938 RVA: 0x0004DEF1 File Offset: 0x0004C0F1
		// (set) Token: 0x06005D83 RID: 23939 RVA: 0x0004DEF9 File Offset: 0x0004C0F9
		public shaderType? ShaderType { get; set; }

		// Token: 0x17001A99 RID: 6809
		// (get) Token: 0x06005D84 RID: 23940 RVA: 0x0004DF02 File Offset: 0x0004C102
		// (set) Token: 0x06005D85 RID: 23941 RVA: 0x0004DF0A File Offset: 0x0004C10A
		public Color? WireframeColor { get; set; }

		// Token: 0x17001A9A RID: 6810
		// (get) Token: 0x06005D86 RID: 23942 RVA: 0x0004DF13 File Offset: 0x0004C113
		// (set) Token: 0x06005D87 RID: 23943 RVA: 0x0004DF1B File Offset: 0x0004C11B
		public Color? EdgesColor { get; set; }

		// Token: 0x17001A9B RID: 6811
		// (get) Token: 0x06005D88 RID: 23944 RVA: 0x0004DF24 File Offset: 0x0004C124
		// (set) Token: 0x06005D89 RID: 23945 RVA: 0x0004DF2C File Offset: 0x0004C12C
		public double VisualOrder { get; set; }

		// Token: 0x06005D8A RID: 23946 RVA: 0x001758E4 File Offset: 0x00173AE4
		protected override void DrawEdges(DrawParams data)
		{
			Color? edgesColor = this.EdgesColor;
			if (edgesColor != null)
			{
				data.RenderContext.SetColorWireframe(edgesColor.Value, false);
			}
			data.RenderContext.SetLineSize(this.LineWeight, true, false);
			base.DrawEdges(data);
		}

		// Token: 0x06005D8B RID: 23947 RVA: 0x00175930 File Offset: 0x00173B30
		protected override void DrawEntity(RenderContextBase context, object myParams)
		{
			bool blend = this.Blend;
			Color? wireframeColor = this.WireframeColor;
			if (this.ShaderType != null)
			{
				context.PushShader();
				context.SetShader(this.ShaderType.Value, null, true);
			}
			if (blend)
			{
				context.PushBlendState();
				context.SetState(blendStateType.Blend);
			}
			if (wireframeColor != null)
			{
				context.SetColorWireframe(wireframeColor.Value, false);
			}
			base.DrawEntity(context, myParams);
			if (blend)
			{
				context.PopBlendState();
			}
			if (this.ShaderType != null)
			{
				context.PopShader();
			}
		}
	}
}
