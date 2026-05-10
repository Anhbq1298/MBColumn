using System;
using System.Runtime.Serialization;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using devDept.Graphics;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core.Entities
{
	// Token: 0x02000B21 RID: 2849
	[CLSCompliant(false)]
	public sealed class CustomLinearDim : LinearDim, IVisuallyOrderedEntity
	{
		// Token: 0x06005D57 RID: 23895 RVA: 0x0004DCAB File Offset: 0x0004BEAB
		public CustomLinearDim(Plane dimPlane, Point3D extLine1, Point3D extLine2, Point3D dimLinePos, double textHeight) : base(dimPlane, extLine1, extLine2, dimLinePos, textHeight)
		{
		}

		// Token: 0x06005D58 RID: 23896 RVA: 0x0004DCD0 File Offset: 0x0004BED0
		public CustomLinearDim(Plane sketchPlane, Point2D extLine1, Point2D extLine2, Point2D dimLinePos, double textHeight) : base(sketchPlane, extLine1, extLine2, dimLinePos, textHeight)
		{
		}

		// Token: 0x06005D59 RID: 23897 RVA: 0x0004DCF5 File Offset: 0x0004BEF5
		protected CustomLinearDim(LinearDim another) : base(another)
		{
		}

		// Token: 0x06005D5A RID: 23898 RVA: 0x0004DD14 File Offset: 0x0004BF14
		public CustomLinearDim(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}

		// Token: 0x17001A8F RID: 6799
		// (get) Token: 0x06005D5B RID: 23899 RVA: 0x0004DD34 File Offset: 0x0004BF34
		// (set) Token: 0x06005D5C RID: 23900 RVA: 0x0004DD3C File Offset: 0x0004BF3C
		public ushort Stipple { get; set; }

		// Token: 0x17001A90 RID: 6800
		// (get) Token: 0x06005D5D RID: 23901 RVA: 0x0004DD45 File Offset: 0x0004BF45
		// (set) Token: 0x06005D5E RID: 23902 RVA: 0x0004DD4D File Offset: 0x0004BF4D
		public double TextRotation { get; set; }

		// Token: 0x17001A91 RID: 6801
		// (get) Token: 0x06005D5F RID: 23903 RVA: 0x0004DD56 File Offset: 0x0004BF56
		// (set) Token: 0x06005D60 RID: 23904 RVA: 0x0004DD5E File Offset: 0x0004BF5E
		public Vector3D TextRotationAxis { get; set; } = Vector3D.AxisZ;

		// Token: 0x17001A92 RID: 6802
		// (get) Token: 0x06005D61 RID: 23905 RVA: 0x0004DD67 File Offset: 0x0004BF67
		// (set) Token: 0x06005D62 RID: 23906 RVA: 0x0004DD6F File Offset: 0x0004BF6F
		public Point3D TextRotationCenter { get; set; } = new Point3D();

		// Token: 0x17001A93 RID: 6803
		// (get) Token: 0x06005D63 RID: 23907 RVA: 0x0004DD78 File Offset: 0x0004BF78
		// (set) Token: 0x06005D64 RID: 23908 RVA: 0x0004DD80 File Offset: 0x0004BF80
		public double VisualOrder { get; set; }

		// Token: 0x17001A94 RID: 6804
		// (get) Token: 0x06005D65 RID: 23909 RVA: 0x0004DD89 File Offset: 0x0004BF89
		// (set) Token: 0x06005D66 RID: 23910 RVA: 0x0004DD91 File Offset: 0x0004BF91
		public Text CustomText { get; set; }

		// Token: 0x06005D67 RID: 23911 RVA: 0x0004DD9A File Offset: 0x0004BF9A
		public void MarkForRegen()
		{
			this.RegenMode = regenType.RegenAndCompile;
			if (this.CustomText != null)
			{
				this.CustomText.RegenMode = regenType.RegenAndCompile;
			}
		}

		// Token: 0x06005D68 RID: 23912 RVA: 0x00175784 File Offset: 0x00173984
		protected override Transformation GetTextMatrix()
		{
			if (Math.Abs(this.TextRotation) > 0.001)
			{
				return base.GetTextMatrix() * new Rotation(this.TextRotation, this.TextRotationAxis, this.TextRotationCenter);
			}
			return base.GetTextMatrix();
		}

		// Token: 0x06005D69 RID: 23913 RVA: 0x001757D0 File Offset: 0x001739D0
		protected override void Draw(DrawParams data)
		{
			this.camera = data.Viewport.Camera;
			bool flag = this.Stipple > 0;
			RenderContextBase renderContext = data.RenderContext;
			if (flag)
			{
				renderContext.EndDrawBufferedLines();
				renderContext.SetLineStipple(1, this.Stipple, this.camera);
				renderContext.EnableLineStipple(true);
			}
			renderContext.PushBlendState();
			renderContext.SetState(blendStateType.Blend);
			base.Draw(data);
			if (flag)
			{
				renderContext.EndDrawBufferedLines();
				renderContext.EnableLineStipple(false);
			}
			renderContext.PopBlendState();
		}

		// Token: 0x040026D5 RID: 9941
		private Camera camera;
	}
}
