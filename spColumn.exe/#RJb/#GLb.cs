using System;
using System.Runtime.CompilerServices;
using #7hc;
using #lH;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.Products.Column.Services.API;
using Telerik.Windows.Controls;

namespace #RJb
{
	// Token: 0x0200049E RID: 1182
	internal abstract class #GLb<#fx> : #HH<!0> where #fx : class, IView
	{
		// Token: 0x06002BF8 RID: 11256 RVA: 0x000EB1B8 File Offset: 0x000E93B8
		protected #GLb(Lazy<#fx> #Ee, ICoreServices #0c) : base(#Ee, #0c)
		{
			this.#b = new DelegateCommand(new Action<object>(this.#FLb), new Predicate<object>(this.#ELb));
			this.#c = new DelegateCommand(new Action<object>(this.#DLb), new Predicate<object>(this.#CLb));
		}

		// Token: 0x17000ED1 RID: 3793
		// (get) Token: 0x06002BF9 RID: 11257 RVA: 0x0000C75F File Offset: 0x0000A95F
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x17000ED2 RID: 3794
		// (get) Token: 0x06002BFA RID: 11258 RVA: 0x00027A7C File Offset: 0x00025C7C
		public DelegateCommand ExpandItemsCommand { get; }

		// Token: 0x17000ED3 RID: 3795
		// (get) Token: 0x06002BFB RID: 11259 RVA: 0x00027A88 File Offset: 0x00025C88
		public DelegateCommand CollapseItemsCommand { get; }

		// Token: 0x17000ED4 RID: 3796
		// (get) Token: 0x06002BFC RID: 11260 RVA: 0x00027A94 File Offset: 0x00025C94
		// (set) Token: 0x06002BFD RID: 11261 RVA: 0x00027AA0 File Offset: 0x00025CA0
		public bool IsToggleButtonChecked
		{
			get
			{
				return this.#a;
			}
			set
			{
				if (this.#a != value)
				{
					this.#a = value;
					base.RaisePropertyChanged(#Phc.#3hc(107351987));
				}
			}
		}

		// Token: 0x06002BFE RID: 11262 RVA: 0x00003375 File Offset: 0x00001575
		protected virtual bool #CLb(object #Sb)
		{
			return true;
		}

		// Token: 0x06002BFF RID: 11263 RVA: 0x00009E6A File Offset: 0x0000806A
		protected virtual void #DLb(object #Sb)
		{
		}

		// Token: 0x06002C00 RID: 11264 RVA: 0x00003375 File Offset: 0x00001575
		protected virtual bool #ELb(object #Sb)
		{
			return true;
		}

		// Token: 0x06002C01 RID: 11265 RVA: 0x00009E6A File Offset: 0x0000806A
		protected virtual void #FLb(object #Sb)
		{
		}

		// Token: 0x0400119E RID: 4510
		private bool #a;

		// Token: 0x0400119F RID: 4511
		[CompilerGenerated]
		private readonly DelegateCommand #b;

		// Token: 0x040011A0 RID: 4512
		[CompilerGenerated]
		private readonly DelegateCommand #c;
	}
}
