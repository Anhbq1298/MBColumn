using System;
using System.Drawing;
using #7hc;
using devDept.Eyeshot;
using devDept.Eyeshot.Labels;
using devDept.Geometry;
using devDept.Graphics;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core
{
	// Token: 0x02000AED RID: 2797
	internal sealed class CustomCoordinateSystemIcon : CoordinateSystemIcon
	{
		// Token: 0x06005B44 RID: 23364 RVA: 0x0004C66C File Offset: 0x0004A86C
		public CustomCoordinateSystemIcon()
		{
		}

		// Token: 0x06005B45 RID: 23365 RVA: 0x0016F554 File Offset: 0x0016D754
		public CustomCoordinateSystemIcon(Color labelColor, Color arrowColorX, Color arrowColorY, Color arrowColorZ, string labelOrigin, string labelAxisX, string labelAxisY, string labelAxisZ, bool visible, coordinateSystemPositionType position) : base(labelColor, arrowColorX, arrowColorY, arrowColorZ, labelOrigin, labelAxisX, labelAxisY, labelAxisZ, visible, position, 37, new Identity())
		{
		}

		// Token: 0x06005B46 RID: 23366 RVA: 0x0016F580 File Offset: 0x0016D780
		public CustomCoordinateSystemIcon(Color labelColor, Color arrowColorX, Color arrowColorY, Color arrowColorZ, string labelOrigin, string labelAxisX, string labelAxisY, string labelAxisZ, bool visible, coordinateSystemPositionType position, int size, Transformation transformation) : base(labelColor, arrowColorX, arrowColorY, arrowColorZ, labelOrigin, labelAxisX, labelAxisY, labelAxisZ, visible, position, size, transformation)
		{
		}

		// Token: 0x06005B47 RID: 23367 RVA: 0x0016F5A8 File Offset: 0x0016D7A8
		public CustomCoordinateSystemIcon(Font labelFont, Color labelColorName, Color labelColorX, Color labelColorY, Color labelColorZ, Color arrowColorX, Color arrowColorY, Color arrowColorZ, string labelOrigin, string labelAxisX, string labelAxisY, string labelAxisZ, bool visible, coordinateSystemPositionType position, int size, Transformation transformation, bool lighting) : base(labelFont, labelColorName, labelColorX, labelColorY, labelColorZ, arrowColorX, arrowColorY, arrowColorZ, labelOrigin, labelAxisX, labelAxisY, labelAxisZ, visible, position, size, transformation, lighting)
		{
		}

		// Token: 0x06005B48 RID: 23368 RVA: 0x0016F5DC File Offset: 0x0016D7DC
		public CustomCoordinateSystemIcon(Color labelColorName, Color labelColorX, Color labelColorY, Color labelColorZ, Color arrowColorX, Color arrowColorY, Color arrowColorZ, string labelOrigin, string labelAxisX, string labelAxisY, string labelAxisZ, bool visible, coordinateSystemPositionType position, int size, Transformation transformation, bool lighting) : base(labelColorName, labelColorX, labelColorY, labelColorZ, arrowColorX, arrowColorY, arrowColorZ, labelOrigin, labelAxisX, labelAxisY, labelAxisZ, visible, position, size, transformation, lighting)
		{
		}

		// Token: 0x06005B49 RID: 23369 RVA: 0x0016F60C File Offset: 0x0016D80C
		public CustomCoordinateSystemIcon(Color labelColorName, Color labelColorX, Color labelColorY, Color labelColorZ, Color arrowColorX, Color arrowColorY, Color arrowColorZ, string labelOrigin, string labelAxisX, string labelAxisY, string labelAxisZ, bool visible, coordinateSystemPositionType position, int size, bool lighting) : base(labelColorName, labelColorX, labelColorY, labelColorZ, arrowColorX, arrowColorY, arrowColorZ, labelOrigin, labelAxisX, labelAxisY, labelAxisZ, visible, position, size, lighting)
		{
		}

		// Token: 0x06005B4A RID: 23370 RVA: 0x0004C674 File Offset: 0x0004A874
		public CustomCoordinateSystemIcon(CoordinateSystemIcon other) : base(other)
		{
		}

		// Token: 0x06005B4B RID: 23371 RVA: 0x0016F63C File Offset: 0x0016D83C
		protected override void CreateLabels(RenderContextBase renderContext, Point3D posLabelAxisX, string textAxisX, Point3D posLabelAxisY, string textAxisY, Point3D posLabelAxisZ, string textAxisZ, Point3D posLabelOrigin, string textOrigin, Viewport viewport, ContentAlignment originNameAlignment = ContentAlignment.BottomLeft)
		{
			TextOnly osLabelAxisX = this.osLabelAxisX;
			if (osLabelAxisX != null)
			{
				osLabelAxisX.Dispose();
			}
			TextOnly osLabelAxisY = this.osLabelAxisY;
			if (osLabelAxisY != null)
			{
				osLabelAxisY.Dispose();
			}
			TextOnly osLabelAxisZ = this.osLabelAxisZ;
			if (osLabelAxisZ != null)
			{
				osLabelAxisZ.Dispose();
			}
			TextOnly osLabelOrigin = this.osLabelOrigin;
			if (osLabelOrigin != null)
			{
				osLabelOrigin.Dispose();
			}
			Font orCreate = FontsCache.GetOrCreate(#Phc.#3hc(107399885), 10f);
			Color black = Color.Black;
			this.UpdateLabelFont(this);
			this.osLabelAxisX = new TextOnly(posLabelAxisX, textAxisX, orCreate, black);
			this.osLabelAxisY = new TextOnly(posLabelAxisY, textAxisY, orCreate, black);
			this.osLabelAxisZ = new TextOnly(posLabelAxisZ, textAxisZ, orCreate, black);
			this.osLabelOrigin = new TextOnly(posLabelOrigin, textOrigin, orCreate, black);
			float drawScale = 1f / Utility.GetScalingLevel().Height;
			this.osLabelOrigin.Regen(renderContext, drawScale);
			this.osLabelAxisX.Regen(renderContext, drawScale);
			this.osLabelAxisY.Regen(renderContext, drawScale);
			this.osLabelAxisZ.Regen(renderContext, drawScale);
		}
	}
}
