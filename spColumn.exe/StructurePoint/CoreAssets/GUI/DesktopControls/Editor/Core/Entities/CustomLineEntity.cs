using System;
using System.Runtime.Serialization;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using devDept.Graphics;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core.Entities
{
	// Token: 0x02000B22 RID: 2850
	[CLSCompliant(false)]
	public sealed class CustomLineEntity : Line, IVisuallyOrderedEntity
	{
		// Token: 0x06005D6A RID: 23914 RVA: 0x0004DDB7 File Offset: 0x0004BFB7
		public CustomLineEntity(double x1, double y1, double x2, double y2, ushort stipple) : base(x1, y1, x2, y2)
		{
			this.Stipple = stipple;
		}

		// Token: 0x06005D6B RID: 23915 RVA: 0x0004DDCC File Offset: 0x0004BFCC
		public CustomLineEntity(Plane sketchPlane, double x1, double y1, double x2, double y2, ushort stipple) : base(sketchPlane, x1, y1, x2, y2)
		{
			this.Stipple = stipple;
		}

		// Token: 0x06005D6C RID: 23916 RVA: 0x0004DDE3 File Offset: 0x0004BFE3
		public CustomLineEntity(Plane sketchPlane, Point2D startPoint, Point2D endPoint, ushort stipple) : base(sketchPlane, startPoint, endPoint)
		{
			this.Stipple = stipple;
		}

		// Token: 0x06005D6D RID: 23917 RVA: 0x0004DDF6 File Offset: 0x0004BFF6
		public CustomLineEntity(double x1, double y1, double z1, double x2, double y2, double z2, ushort stipple) : base(x1, y1, z1, x2, y2, z2)
		{
			this.Stipple = stipple;
		}

		// Token: 0x06005D6E RID: 23918 RVA: 0x0004DE0F File Offset: 0x0004C00F
		public CustomLineEntity(Point3D start, Point3D end, ushort stipple) : base(start, end)
		{
			this.Stipple = stipple;
		}

		// Token: 0x06005D6F RID: 23919 RVA: 0x0004DE20 File Offset: 0x0004C020
		public CustomLineEntity(Point3D start, Point3D end) : base(start, end)
		{
			this.Stipple = 0;
		}

		// Token: 0x06005D70 RID: 23920 RVA: 0x0004DE31 File Offset: 0x0004C031
		public CustomLineEntity(Segment2D seg, ushort stipple) : base(seg)
		{
			this.Stipple = stipple;
		}

		// Token: 0x06005D71 RID: 23921 RVA: 0x0004DE41 File Offset: 0x0004C041
		public CustomLineEntity(Segment3D seg, ushort stipple) : base(seg)
		{
			this.Stipple = stipple;
		}

		// Token: 0x06005D72 RID: 23922 RVA: 0x0004DE51 File Offset: 0x0004C051
		protected CustomLineEntity(Line another, ushort stipple) : base(another)
		{
			this.Stipple = stipple;
		}

		// Token: 0x06005D73 RID: 23923 RVA: 0x0004DE61 File Offset: 0x0004C061
		public CustomLineEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}

		// Token: 0x17001A95 RID: 6805
		// (get) Token: 0x06005D74 RID: 23924 RVA: 0x0004DE6B File Offset: 0x0004C06B
		// (set) Token: 0x06005D75 RID: 23925 RVA: 0x0004DE73 File Offset: 0x0004C073
		public ushort Stipple
		{
			get
			{
				return this.stipple;
			}
			set
			{
				if (this.stipple != value)
				{
					this.stipple = value;
					this.RegenMode = regenType.RegenAndCompile;
				}
			}
		}

		// Token: 0x17001A96 RID: 6806
		// (get) Token: 0x06005D76 RID: 23926 RVA: 0x0004DE8C File Offset: 0x0004C08C
		// (set) Token: 0x06005D77 RID: 23927 RVA: 0x0004DE94 File Offset: 0x0004C094
		public double VisualOrder { get; set; }

		// Token: 0x06005D78 RID: 23928 RVA: 0x00175850 File Offset: 0x00173A50
		protected override void Draw(DrawParams data)
		{
			bool flag = this.Stipple > 0;
			if (flag)
			{
				data.RenderContext.EndDrawBufferedLines();
				data.RenderContext.SetLineStipple(2, this.Stipple, data.Viewport.Camera);
				data.RenderContext.EnableLineStipple(true);
			}
			data.RenderContext.PushBlendState();
			data.RenderContext.SetState(blendStateType.Blend);
			base.Draw(data);
			if (flag)
			{
				data.RenderContext.EndDrawBufferedLines();
				data.RenderContext.EnableLineStipple(false);
			}
			data.RenderContext.PopBlendState();
		}

		// Token: 0x040026DC RID: 9948
		private ushort stipple;
	}
}
