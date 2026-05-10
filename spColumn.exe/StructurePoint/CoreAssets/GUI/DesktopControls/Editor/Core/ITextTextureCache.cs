using System;
using System.Drawing;
using devDept.Graphics;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core
{
	// Token: 0x02000AF4 RID: 2804
	public interface ITextTextureCache : IDisposable
	{
		// Token: 0x06005B78 RID: 23416
		void EmptyCache();

		// Token: 0x06005B79 RID: 23417
		TextureBase CreateTexture(EyeshotEditor edit, string txt, Font font, Color foreground, Color background, ContentAlignment alignment, RotateFlipType rotate, float angle = 0f);

		// Token: 0x06005B7A RID: 23418
		TextureBase GetOrCreate(EyeshotEditor editor, string text, Font textFont, Color textColor, Color fillColor, ContentAlignment textAlign, RotateFlipType rotateFlip, float angle = 0f);
	}
}
