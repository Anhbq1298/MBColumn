using System;
using System.Drawing;
using devDept.Graphics;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core
{
	// Token: 0x02000B01 RID: 2817
	internal struct TextTextureItem : IDisposable
	{
		// Token: 0x06005BDA RID: 23514 RVA: 0x00170FAC File Offset: 0x0016F1AC
		public TextTextureItem(string text, string fontName, float textHeight, Color textColor, Color backgroundColor, RotateFlipType flipType, float angle = 0f)
		{
			this.Text = text;
			this.FontName = fontName;
			this.TextHeight = textHeight;
			this.TextColor = textColor;
			this.BackgroundColor = backgroundColor;
			this.FlipType = flipType;
			this.Angle = angle;
			this.Texture = null;
			this.hashCode = 0;
			this.hashCode = this.ComputeHashCode();
		}

		// Token: 0x17001A34 RID: 6708
		// (get) Token: 0x06005BDB RID: 23515 RVA: 0x0004CD30 File Offset: 0x0004AF30
		// (set) Token: 0x06005BDC RID: 23516 RVA: 0x0004CD38 File Offset: 0x0004AF38
		public TextureBase Texture { readonly get; set; }

		// Token: 0x17001A35 RID: 6709
		// (get) Token: 0x06005BDD RID: 23517 RVA: 0x0004CD41 File Offset: 0x0004AF41
		public readonly string Text { get; }

		// Token: 0x17001A36 RID: 6710
		// (get) Token: 0x06005BDE RID: 23518 RVA: 0x0004CD49 File Offset: 0x0004AF49
		public readonly string FontName { get; }

		// Token: 0x17001A37 RID: 6711
		// (get) Token: 0x06005BDF RID: 23519 RVA: 0x0004CD51 File Offset: 0x0004AF51
		public readonly float TextHeight { get; }

		// Token: 0x17001A38 RID: 6712
		// (get) Token: 0x06005BE0 RID: 23520 RVA: 0x0004CD59 File Offset: 0x0004AF59
		public readonly Color TextColor { get; }

		// Token: 0x17001A39 RID: 6713
		// (get) Token: 0x06005BE1 RID: 23521 RVA: 0x0004CD61 File Offset: 0x0004AF61
		public readonly Color BackgroundColor { get; }

		// Token: 0x17001A3A RID: 6714
		// (get) Token: 0x06005BE2 RID: 23522 RVA: 0x0004CD69 File Offset: 0x0004AF69
		public readonly RotateFlipType FlipType { get; }

		// Token: 0x17001A3B RID: 6715
		// (get) Token: 0x06005BE3 RID: 23523 RVA: 0x0004CD71 File Offset: 0x0004AF71
		public readonly float Angle { get; }

		// Token: 0x06005BE4 RID: 23524 RVA: 0x00171008 File Offset: 0x0016F208
		public override bool Equals(object obj)
		{
			if (obj is TextTextureItem)
			{
				TextTextureItem textTextureItem = (TextTextureItem)obj;
				return textTextureItem.hashCode == this.hashCode;
			}
			return false;
		}

		// Token: 0x06005BE5 RID: 23525 RVA: 0x0004CD79 File Offset: 0x0004AF79
		public override int GetHashCode()
		{
			return this.hashCode;
		}

		// Token: 0x06005BE6 RID: 23526 RVA: 0x0004CD81 File Offset: 0x0004AF81
		public void Dispose()
		{
			TextureBase texture = this.Texture;
			if (texture == null)
			{
				return;
			}
			texture.Dispose();
		}

		// Token: 0x06005BE7 RID: 23527 RVA: 0x00171034 File Offset: 0x0016F234
		private int ComputeHashCode()
		{
			string text = this.Text;
			int num = ((text != null) ? text.GetHashCode() : 0) * 397;
			string fontName = this.FontName;
			return (((((num ^ ((fontName != null) ? fontName.GetHashCode() : 0)) * 397 ^ this.TextHeight.GetHashCode()) * 397 ^ this.TextColor.GetHashCode()) * 397 ^ this.BackgroundColor.GetHashCode()) * 397 ^ (int)this.FlipType) * 397 ^ this.Angle.GetHashCode();
		}

		// Token: 0x0400262B RID: 9771
		private readonly int hashCode;
	}
}
