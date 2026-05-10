using System;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows.Media;
using #7hc;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;

namespace #Hl
{
	// Token: 0x020000F9 RID: 249
	internal sealed class #Gl : NotifyPropertyChangedObjectBase
	{
		// Token: 0x060007E2 RID: 2018 RVA: 0x0000BFE3 File Offset: 0x0000A1E3
		public #Gl(ICommand #Th, string #Il, string #Jl, ImageSource #Kl) : this(#Th, #Il)
		{
			if (#Jl == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107381753));
			}
			this.#a = #Jl;
			this.Image = #Kl;
		}

		// Token: 0x060007E3 RID: 2019 RVA: 0x0000C010 File Offset: 0x0000A210
		public #Gl(ICommand #Th, string #Il, string #Jl) : this(#Th, #Il)
		{
			if (#Jl == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107381753));
			}
			this.#a = #Jl;
		}

		// Token: 0x060007E4 RID: 2020 RVA: 0x0000C035 File Offset: 0x0000A235
		public #Gl(ICommand #Th, string #Il)
		{
			if (#Il == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107381748));
			}
			this.#b = #Il;
			if (#Th == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107381699));
			}
			this.#c = #Th;
		}

		// Token: 0x1700034D RID: 845
		// (get) Token: 0x060007E5 RID: 2021 RVA: 0x0000C073 File Offset: 0x0000A273
		public string Url { get; }

		// Token: 0x1700034E RID: 846
		// (get) Token: 0x060007E6 RID: 2022 RVA: 0x0000C07F File Offset: 0x0000A27F
		public string DisplayValue { get; }

		// Token: 0x1700034F RID: 847
		// (get) Token: 0x060007E7 RID: 2023 RVA: 0x0000C08B File Offset: 0x0000A28B
		public ICommand Command { get; }

		// Token: 0x17000350 RID: 848
		// (get) Token: 0x060007E8 RID: 2024 RVA: 0x0000C097 File Offset: 0x0000A297
		// (set) Token: 0x060007E9 RID: 2025 RVA: 0x0000C0A3 File Offset: 0x0000A2A3
		public ImageSource Image { get; set; }

		// Token: 0x04000239 RID: 569
		[CompilerGenerated]
		private readonly string #a;

		// Token: 0x0400023A RID: 570
		[CompilerGenerated]
		private readonly string #b;

		// Token: 0x0400023B RID: 571
		[CompilerGenerated]
		private readonly ICommand #c;

		// Token: 0x0400023C RID: 572
		[CompilerGenerated]
		private ImageSource #d;
	}
}
