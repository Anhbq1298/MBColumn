using System;
using System.Drawing;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core
{
	// Token: 0x02000B1B RID: 2843
	public sealed class FontData
	{
		// Token: 0x06005D19 RID: 23833 RVA: 0x0004D9CD File Offset: 0x0004BBCD
		public FontData()
		{
			this.fontFamily = SystemFonts.DialogFont.FontFamily.Name;
			this.size = 10f;
			this.fontStyle = FontStyle.Regular;
			this.graphicsUnit = GraphicsUnit.Point;
			this.Rebuild();
		}

		// Token: 0x17001A83 RID: 6787
		// (get) Token: 0x06005D1A RID: 23834 RVA: 0x0004DA09 File Offset: 0x0004BC09
		// (set) Token: 0x06005D1B RID: 23835 RVA: 0x0004DA11 File Offset: 0x0004BC11
		public GraphicsUnit GraphicsUnit
		{
			get
			{
				return this.graphicsUnit;
			}
			set
			{
				if (this.graphicsUnit != value)
				{
					this.graphicsUnit = value;
					this.Rebuild();
				}
			}
		}

		// Token: 0x17001A84 RID: 6788
		// (get) Token: 0x06005D1C RID: 23836 RVA: 0x0004DA29 File Offset: 0x0004BC29
		// (set) Token: 0x06005D1D RID: 23837 RVA: 0x0004DA31 File Offset: 0x0004BC31
		public FontStyle FontStyle
		{
			get
			{
				return this.fontStyle;
			}
			set
			{
				if (this.fontStyle != value)
				{
					this.fontStyle = value;
					this.Rebuild();
				}
			}
		}

		// Token: 0x17001A85 RID: 6789
		// (get) Token: 0x06005D1E RID: 23838 RVA: 0x0004DA49 File Offset: 0x0004BC49
		// (set) Token: 0x06005D1F RID: 23839 RVA: 0x0004DA51 File Offset: 0x0004BC51
		public float Size
		{
			get
			{
				return this.size;
			}
			set
			{
				if ((double)Math.Abs(this.size - value) > 1E-05)
				{
					this.size = value;
					this.Rebuild();
				}
			}
		}

		// Token: 0x17001A86 RID: 6790
		// (get) Token: 0x06005D20 RID: 23840 RVA: 0x0004DA79 File Offset: 0x0004BC79
		// (set) Token: 0x06005D21 RID: 23841 RVA: 0x0004DA81 File Offset: 0x0004BC81
		public Font Font { get; private set; }

		// Token: 0x17001A87 RID: 6791
		// (get) Token: 0x06005D22 RID: 23842 RVA: 0x0004DA8A File Offset: 0x0004BC8A
		// (set) Token: 0x06005D23 RID: 23843 RVA: 0x0004DA92 File Offset: 0x0004BC92
		public string FontFamily
		{
			get
			{
				return this.fontFamily;
			}
			set
			{
				if (this.fontFamily != value)
				{
					this.fontFamily = value;
					this.Rebuild();
				}
			}
		}

		// Token: 0x06005D24 RID: 23844 RVA: 0x0004DAAF File Offset: 0x0004BCAF
		private void Rebuild()
		{
			this.Font = new Font(new FontFamily(this.fontFamily), this.Size, this.FontStyle, this.GraphicsUnit);
		}

		// Token: 0x040026CA RID: 9930
		private string fontFamily;

		// Token: 0x040026CB RID: 9931
		private float size;

		// Token: 0x040026CC RID: 9932
		private FontStyle fontStyle;

		// Token: 0x040026CD RID: 9933
		private GraphicsUnit graphicsUnit;
	}
}
