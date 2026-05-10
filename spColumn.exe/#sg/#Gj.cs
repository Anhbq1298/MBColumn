using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using #1b;
using #eU;
using #HI;
using #lH;
using #qJ;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.Products.Column.Services.API;
using Telerik.Windows.Controls;

namespace #sg
{
	// Token: 0x020000E5 RID: 229
	internal sealed class #Gj : #HH<#7b>, IViewModel<#7b>, INotifyPropertyChanged, IViewModel, #NI
	{
		// Token: 0x06000751 RID: 1873 RVA: 0x0000B88C File Offset: 0x00009A8C
		public #Gj(Lazy<#7b> #Ee, ICoreServices #0c, #rW #Hj) : base(#Ee, #0c)
		{
			this.#a = #Hj;
			this.#b = new DelegateCommand(new Action<object>(this.#Ug));
		}

		// Token: 0x17000314 RID: 788
		// (get) Token: 0x06000752 RID: 1874 RVA: 0x0000B8B4 File Offset: 0x00009AB4
		public #dQ AppData
		{
			get
			{
				return this.#a.ApplicationData;
			}
		}

		// Token: 0x17000315 RID: 789
		// (get) Token: 0x06000753 RID: 1875 RVA: 0x0000B8C9 File Offset: 0x00009AC9
		public string ProductInfo
		{
			get
			{
				return this.#a.ApplicationData.ApplicationVersion + this.#Fj();
			}
		}

		// Token: 0x17000316 RID: 790
		// (get) Token: 0x06000754 RID: 1876 RVA: 0x0000B8F2 File Offset: 0x00009AF2
		public DelegateCommand CloseCommand { get; }

		// Token: 0x17000317 RID: 791
		// (get) Token: 0x06000755 RID: 1877 RVA: 0x0000B8FE File Offset: 0x00009AFE
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x06000756 RID: 1878 RVA: 0x0000B90E File Offset: 0x00009B0E
		public void #od()
		{
			base.View.SetOwner(base.Services.WindowLocator.#VP());
			base.View.ShowDialog();
		}

		// Token: 0x06000757 RID: 1879 RVA: 0x0000A36A File Offset: 0x0000856A
		private string #Fj()
		{
			return string.Empty;
		}

		// Token: 0x06000758 RID: 1880 RVA: 0x0000B943 File Offset: 0x00009B43
		private void #Ug(object #Sb)
		{
			base.View.Close();
		}

		// Token: 0x040001E1 RID: 481
		private readonly #rW #a;

		// Token: 0x040001E2 RID: 482
		[CompilerGenerated]
		private readonly DelegateCommand #b;
	}
}
