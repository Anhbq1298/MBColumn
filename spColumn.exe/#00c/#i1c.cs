using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using #7hc;
using #Vjc;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;

namespace #00c
{
	// Token: 0x02000CB7 RID: 3255
	internal sealed class #i1c : NotifyPropertyChangedObjectBase
	{
		// Token: 0x17001D4C RID: 7500
		// (get) Token: 0x06006A3C RID: 27196 RVA: 0x00053ED8 File Offset: 0x000520D8
		// (set) Token: 0x06006A3D RID: 27197 RVA: 0x00053EE0 File Offset: 0x000520E0
		[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
		public string EntityType { get; set; }

		// Token: 0x17001D4D RID: 7501
		// (get) Token: 0x06006A3E RID: 27198 RVA: 0x00053EE9 File Offset: 0x000520E9
		// (set) Token: 0x06006A3F RID: 27199 RVA: 0x0019C538 File Offset: 0x0019A738
		public string LayerName
		{
			get
			{
				return this.#b;
			}
			set
			{
				if (this.#b != value)
				{
					string propertyName = #Phc.#3hc(107430968);
					if (!false)
					{
						base.RaisePropertyChanging(propertyName);
					}
					this.#b = value;
					string propertyName2 = #Phc.#3hc(107430968);
					if (!false)
					{
						base.RaisePropertyChanged(propertyName2);
					}
				}
			}
		}

		// Token: 0x17001D4E RID: 7502
		// (get) Token: 0x06006A40 RID: 27200 RVA: 0x00053EF1 File Offset: 0x000520F1
		// (set) Token: 0x06006A41 RID: 27201 RVA: 0x0019C588 File Offset: 0x0019A788
		public Color LayerColor
		{
			get
			{
				return this.#c;
			}
			set
			{
				if (this.#c != value)
				{
					string propertyName = #Phc.#3hc(107430923);
					if (!false)
					{
						base.RaisePropertyChanging(propertyName);
					}
					this.#c = value;
					string propertyName2 = #Phc.#3hc(107430923);
					if (!false)
					{
						base.RaisePropertyChanged(propertyName2);
					}
				}
			}
		}

		// Token: 0x17001D4F RID: 7503
		// (get) Token: 0x06006A42 RID: 27202 RVA: 0x00053EF9 File Offset: 0x000520F9
		// (set) Token: 0x06006A43 RID: 27203 RVA: 0x0019C5D8 File Offset: 0x0019A7D8
		public bool IsVisible
		{
			get
			{
				return this.#a;
			}
			set
			{
				for (;;)
				{
					if (this.#a == value)
					{
						goto IL_36;
					}
					string propertyName = #Phc.#3hc(107351275);
					if (5 != 0)
					{
						base.RaisePropertyChanging(propertyName);
					}
					IL_19:
					if (3 != 0)
					{
						if (false)
						{
							continue;
						}
						this.#a = value;
						string propertyName2 = #Phc.#3hc(107351275);
						if (!false)
						{
							base.RaisePropertyChanged(propertyName2);
						}
					}
					IL_36:
					if (true)
					{
						break;
					}
					goto IL_19;
				}
			}
		}

		// Token: 0x17001D50 RID: 7504
		// (get) Token: 0x06006A44 RID: 27204 RVA: 0x00053F01 File Offset: 0x00052101
		// (set) Token: 0x06006A45 RID: 27205 RVA: 0x0019C62C File Offset: 0x0019A82C
		public double LineThickness
		{
			get
			{
				return this.#d;
			}
			set
			{
				for (;;)
				{
					if (this.#d == value)
					{
						goto IL_36;
					}
					string propertyName = #Phc.#3hc(107430938);
					if (5 != 0)
					{
						base.RaisePropertyChanging(propertyName);
					}
					IL_19:
					if (3 != 0)
					{
						if (false)
						{
							continue;
						}
						this.#d = value;
						string propertyName2 = #Phc.#3hc(107430938);
						if (!false)
						{
							base.RaisePropertyChanged(propertyName2);
						}
					}
					IL_36:
					if (true)
					{
						break;
					}
					goto IL_19;
				}
			}
		}

		// Token: 0x06006A46 RID: 27206 RVA: 0x0019C680 File Offset: 0x0019A880
		public #fkc #h1c()
		{
			string #wy = this.LayerName;
			byte r = this.#c.R;
			Color color = this.LayerColor;
			Color color2;
			if (2 != 0)
			{
				color2 = color;
			}
			byte g = color2.G;
			Color color3 = this.LayerColor;
			if (!false)
			{
				color2 = color3;
			}
			return new #fkc(#wy, new #3jc(r, g, color2.B));
		}

		// Token: 0x04002B7C RID: 11132
		private bool #a;

		// Token: 0x04002B7D RID: 11133
		private string #b;

		// Token: 0x04002B7E RID: 11134
		private Color #c;

		// Token: 0x04002B7F RID: 11135
		private double #d;

		// Token: 0x04002B80 RID: 11136
		[CompilerGenerated]
		private string #e;
	}
}
