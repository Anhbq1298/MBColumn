using System;
using System.Drawing;
using System.Runtime.Serialization;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Labels;
using devDept.Geometry;
using devDept.Graphics;
using StructurePoint.CoreAssets.GUI.DesktopControls.Editor;

namespace StructurePoint.CoreAssets.Column.Core.Templates.Rendering
{
	// Token: 0x02000851 RID: 2129
	internal sealed class CustomLeaderAndText : LeaderAndText
	{
		// Token: 0x060043C7 RID: 17351 RVA: 0x00038B38 File Offset: 0x00036D38
		public CustomLeaderAndText(double x, double y, double z, string text, Font textFont, Color textColor, Vector2D offset) : base(x, y, z, text, textFont, textColor, offset)
		{
		}

		// Token: 0x060043C8 RID: 17352 RVA: 0x00038B4B File Offset: 0x00036D4B
		public CustomLeaderAndText(Point3D p, string text, Font textFont, Color textColor, Vector2D offset) : base(p, text, textFont, textColor, offset)
		{
		}

		// Token: 0x060043C9 RID: 17353 RVA: 0x00038B5A File Offset: 0x00036D5A
		public CustomLeaderAndText(Point3D p, string text, Font textFont, Color textColor, int offsetX, int offsetY) : base(p, text, textFont, textColor, offsetX, offsetY)
		{
		}

		// Token: 0x060043CA RID: 17354 RVA: 0x00038B6B File Offset: 0x00036D6B
		public CustomLeaderAndText(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}

		// Token: 0x060043CB RID: 17355 RVA: 0x00038B75 File Offset: 0x00036D75
		public CustomLeaderAndText(LeaderAndText another) : base(another)
		{
		}

		// Token: 0x170013F8 RID: 5112
		// (get) Token: 0x060043CC RID: 17356 RVA: 0x00038B7E File Offset: 0x00036D7E
		// (set) Token: 0x060043CD RID: 17357 RVA: 0x00038B86 File Offset: 0x00036D86
		public EyeshotEditor Editor { get; set; }

		// Token: 0x170013F9 RID: 5113
		// (get) Token: 0x060043CE RID: 17358 RVA: 0x00038B8F File Offset: 0x00036D8F
		// (set) Token: 0x060043CF RID: 17359 RVA: 0x00038B97 File Offset: 0x00036D97
		public Point3D TargetPosition { get; set; }

		// Token: 0x170013FA RID: 5114
		// (get) Token: 0x060043D0 RID: 17360 RVA: 0x00038BA0 File Offset: 0x00036DA0
		// (set) Token: 0x060043D1 RID: 17361 RVA: 0x00038BA8 File Offset: 0x00036DA8
		public Point3D BasePosition { get; set; }

		// Token: 0x170013FB RID: 5115
		// (get) Token: 0x060043D2 RID: 17362 RVA: 0x00038BB1 File Offset: 0x00036DB1
		// (set) Token: 0x060043D3 RID: 17363 RVA: 0x00038BB9 File Offset: 0x00036DB9
		public Point3D ShapePosition { get; set; }

		// Token: 0x170013FC RID: 5116
		// (get) Token: 0x060043D4 RID: 17364 RVA: 0x00038BC2 File Offset: 0x00036DC2
		// (set) Token: 0x060043D5 RID: 17365 RVA: 0x00038BCA File Offset: 0x00036DCA
		public double Margin { get; set; }

		// Token: 0x170013FD RID: 5117
		// (get) Token: 0x060043D6 RID: 17366 RVA: 0x00038BD3 File Offset: 0x00036DD3
		// (set) Token: 0x060043D7 RID: 17367 RVA: 0x00038BDB File Offset: 0x00036DDB
		public bool IsLeft { get; set; }

		// Token: 0x170013FE RID: 5118
		// (get) Token: 0x060043D8 RID: 17368 RVA: 0x00038BE4 File Offset: 0x00036DE4
		public override Point2D OnScreenPosition
		{
			get
			{
				return this.CalculateOnScreenPosition();
			}
		}

		// Token: 0x060043D9 RID: 17369 RVA: 0x00038BEC File Offset: 0x00036DEC
		public override void Draw(RenderContextBase renderContext)
		{
			if (this.labelFillColor != System.Drawing.Color.Empty)
			{
				renderContext.SetColorWireframe(this.labelFillColor, false);
			}
			else
			{
				renderContext.SetColorWireframe(this.labelColor, false);
			}
			this.DrawImpl(renderContext);
		}

		// Token: 0x060043DA RID: 17370 RVA: 0x001390F8 File Offset: 0x001372F8
		public void UpdateAnchorPoint()
		{
			Point2D onScreenPosition = this.OnScreenPosition;
			regenType regenMode = base.RegenMode;
			Point3D point3D;
			this.Editor.ScreenToPlane(new System.Drawing.Point((int)onScreenPosition.X, (int)onScreenPosition.Y), Plane.XY, out point3D);
			point3D = this.Editor.ScreenToWorld(new System.Drawing.Point((int)onScreenPosition.X, (int)onScreenPosition.Y));
			if (point3D != null)
			{
				base.AnchorPoint = point3D;
			}
			base.RegenMode = regenMode;
		}

		// Token: 0x060043DB RID: 17371 RVA: 0x00139170 File Offset: 0x00137370
		private Point3D CalculateOnScreenPosition()
		{
			Point3D a = this.Editor.WorldToScreen(this.ShapePosition);
			Vector3D vector3D = new Vector3D(this.BasePosition, this.TargetPosition);
			vector3D.Normalize();
			return a + vector3D * this.Margin;
		}

		// Token: 0x060043DC RID: 17372 RVA: 0x001391B8 File Offset: 0x001373B8
		private void DrawText(RenderContextBase context, float x, float y, float verticalOffset)
		{
			Point2D point2D = base.ComputePositions(x, y + verticalOffset);
			TextureBase texture = base.GetTexture(context);
			RectangleF rect = new RectangleF((float)((int)point2D.X), (float)((int)point2D.Y), (float)texture.BitmapSize.Width, (float)texture.BitmapSize.Height);
			if (rect.Width > 0f && rect.Height > 0f)
			{
				context.PushShader();
				context.SetShader(shaderType.NoLights, null, false);
				context.DrawLine(x, y, 0f, this.IsLeft ? (x - rect.Width) : (x + rect.Width), y, 0f);
				context.PopShader();
				base.DrawTexture(context, texture, rect, false);
			}
		}

		// Token: 0x060043DD RID: 17373 RVA: 0x0013927C File Offset: 0x0013747C
		private void DrawImpl(RenderContextBase context)
		{
			context.PushShader();
			context.SetShader(shaderType.NoLights, null, false);
			Point3D p = this.Editor.WorldToScreen(this.BasePosition);
			context.DrawLine(this.OnScreenPosition, p);
			context.PopShader();
			Point2D onScreenPosition = this.OnScreenPosition;
			this.DrawText(context, (float)onScreenPosition.X, (float)onScreenPosition.Y, 10f);
		}
	}
}
