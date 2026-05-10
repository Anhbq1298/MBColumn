using System;
using System.Drawing;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Graphics;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core.Entities
{
	// Token: 0x02000B24 RID: 2852
	public sealed class CustomRegion : devDept.Eyeshot.Entities.Region, IVisuallyOrderedEntity
	{
		// Token: 0x06005D8C RID: 23948 RVA: 0x0004DF35 File Offset: 0x0004C135
		public CustomRegion()
		{
		}

		// Token: 0x06005D8D RID: 23949 RVA: 0x0004DF53 File Offset: 0x0004C153
		public CustomRegion(devDept.Eyeshot.Entities.Region region) : base(region)
		{
		}

		// Token: 0x17001A9C RID: 6812
		// (get) Token: 0x06005D8E RID: 23950 RVA: 0x0004DF72 File Offset: 0x0004C172
		// (set) Token: 0x06005D8F RID: 23951 RVA: 0x0004DF7A File Offset: 0x0004C17A
		public Color EdgeColor { get; set; } = Color.Black;

		// Token: 0x17001A9D RID: 6813
		// (get) Token: 0x06005D90 RID: 23952 RVA: 0x0004DF83 File Offset: 0x0004C183
		// (set) Token: 0x06005D91 RID: 23953 RVA: 0x0004DF8B File Offset: 0x0004C18B
		public float LineSize { get; set; } = 1f;

		// Token: 0x17001A9E RID: 6814
		// (get) Token: 0x06005D92 RID: 23954 RVA: 0x0004DF94 File Offset: 0x0004C194
		// (set) Token: 0x06005D93 RID: 23955 RVA: 0x0004DF9C File Offset: 0x0004C19C
		public double VisualOrder { get; set; }

		// Token: 0x06005D94 RID: 23956 RVA: 0x0004DFA5 File Offset: 0x0004C1A5
		public override object Clone()
		{
			return new CustomRegion(this);
		}

		// Token: 0x06005D95 RID: 23957 RVA: 0x001759CC File Offset: 0x00173BCC
		protected override void Draw(DrawParams data)
		{
			data.RenderContext.PushBlendState();
			data.RenderContext.SetState(blendStateType.Blend);
			data.RenderContext.PushShader();
			data.RenderContext.SetShader(shaderType.NoLights, null, true);
			base.Draw(data);
			data.RenderContext.PopShader();
			data.RenderContext.PopBlendState();
		}

		// Token: 0x06005D96 RID: 23958 RVA: 0x00175A2C File Offset: 0x00173C2C
		protected override void DrawEdges(DrawParams data)
		{
			if (this.EdgeColor != Color.Transparent)
			{
				data.RenderContext.PushBlendState();
				data.RenderContext.SetState(blendStateType.Blend);
				data.RenderContext.SetColorWireframe(this.EdgeColor, false);
				data.RenderContext.SetLineSizeExt(this.LineSize);
				base.DrawEdges(data);
				data.RenderContext.PopBlendState();
			}
		}
	}
}
