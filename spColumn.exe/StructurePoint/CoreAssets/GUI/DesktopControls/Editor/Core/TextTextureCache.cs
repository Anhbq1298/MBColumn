using System;
using System.Collections.Generic;
using System.Drawing;
using devDept.Graphics;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core
{
	// Token: 0x02000AFA RID: 2810
	internal sealed class TextTextureCache : IDisposable, ITextTextureCache
	{
		// Token: 0x06005B8F RID: 23439 RVA: 0x0016FED4 File Offset: 0x0016E0D4
		public void EmptyCache()
		{
			foreach (KeyValuePair<TextTextureItem, TextTextureItem> keyValuePair in this.cache)
			{
				try
				{
					keyValuePair.Value.Dispose();
				}
				catch
				{
				}
			}
			this.cache.Clear();
		}

		// Token: 0x06005B90 RID: 23440 RVA: 0x0016FF4C File Offset: 0x0016E14C
		public TextureBase CreateTexture(EyeshotEditor edit, string txt, Font font, Color foreground, Color background, ContentAlignment alignment, RotateFlipType rotate, float angle = 0f)
		{
			Bitmap textImageExt = edit.GetTextImageExt(txt, font, foreground, background, alignment, rotate, angle, true);
			TextureBase result = edit.renderContext.CreateTexture2D(textImageExt, textureFilteringFunctionType.Linear, textureFilteringFunctionType.Linear, true, true, true, true);
			textImageExt.Dispose();
			return result;
		}

		// Token: 0x06005B91 RID: 23441 RVA: 0x0016FF88 File Offset: 0x0016E188
		public TextureBase GetOrCreate(EyeshotEditor editor, string text, Font textFont, Color textColor, Color fillColor, ContentAlignment textAlign, RotateFlipType rotateFlip, float angle = 0f)
		{
			if (this.disposed || string.IsNullOrEmpty(text))
			{
				return null;
			}
			TextTextureItem textTextureItem = new TextTextureItem(text, textFont.OriginalFontName, textFont.Size, textColor, fillColor, rotateFlip, angle);
			TextTextureItem textTextureItem2;
			if (this.cache.Count > 1 && this.cache.TryGetValue(textTextureItem, out textTextureItem2) && textTextureItem2.Texture != null)
			{
				return textTextureItem2.Texture;
			}
			TextureBase textureBase = this.CreateTexture(editor, text, textFont, textColor, fillColor, textAlign, rotateFlip, angle);
			if (this.cache.Count <= 1)
			{
				textureBase = this.CreateTexture(editor, text, textFont, textColor, fillColor, textAlign, rotateFlip, angle);
			}
			textTextureItem.Texture = textureBase;
			this.cache[textTextureItem] = textTextureItem;
			return textureBase;
		}

		// Token: 0x06005B92 RID: 23442 RVA: 0x0004C9AA File Offset: 0x0004ABAA
		public void Dispose()
		{
			if (this.disposed)
			{
				return;
			}
			this.disposed = true;
			this.EmptyCache();
		}

		// Token: 0x04002619 RID: 9753
		private readonly Dictionary<TextTextureItem, TextTextureItem> cache = new Dictionary<TextTextureItem, TextTextureItem>();

		// Token: 0x0400261A RID: 9754
		private bool disposed;
	}
}
