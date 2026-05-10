using System;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Media;
using #0I;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.Products.Column.Services.API;
using StructurePoint.Products.Column.ViewModels.API.Core;

namespace #lH
{
	// Token: 0x0200013D RID: 317
	internal abstract class #uH<#fx, #vH> : #HH<!0>, #1I<!1>, IPanel where #fx : class, IView where #vH : #5I
	{
		// Token: 0x06000A4E RID: 2638 RVA: 0x0000DDE2 File Offset: 0x0000BFE2
		protected #uH(Lazy<#fx> #Ee, ICoreServices #0c) : base(#Ee, #0c)
		{
		}

		// Token: 0x1700042F RID: 1071
		// (get) Token: 0x06000A4F RID: 2639 RVA: 0x0000DDEC File Offset: 0x0000BFEC
		public IView ViewObject
		{
			get
			{
				return base.View;
			}
		}

		// Token: 0x17000430 RID: 1072
		// (get) Token: 0x06000A50 RID: 2640 RVA: 0x0000DE01 File Offset: 0x0000C001
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors || this.HasAnyErrors;
			}
		}

		// Token: 0x17000431 RID: 1073
		// (get) Token: 0x06000A51 RID: 2641 RVA: 0x0000DE1F File Offset: 0x0000C01F
		#5I IPanel.Form
		{
			get
			{
				return this.Form;
			}
		}

		// Token: 0x17000432 RID: 1074
		// (get) Token: 0x06000A52 RID: 2642 RVA: 0x0000DE34 File Offset: 0x0000C034
		public virtual #vH Form { get; }

		// Token: 0x17000433 RID: 1075
		// (get) Token: 0x06000A53 RID: 2643 RVA: 0x00098DE0 File Offset: 0x00096FE0
		public virtual bool HasAnyErrors
		{
			get
			{
				#vH #vH = this.Form;
				return #vH.HasErrors;
			}
		}

		// Token: 0x17000434 RID: 1076
		// (get) Token: 0x06000A54 RID: 2644 RVA: 0x0000DE40 File Offset: 0x0000C040
		// (set) Token: 0x06000A55 RID: 2645 RVA: 0x0000DE4C File Offset: 0x0000C04C
		public virtual ImageSource Icon { get; set; }

		// Token: 0x17000435 RID: 1077
		// (get) Token: 0x06000A56 RID: 2646 RVA: 0x0000DE5D File Offset: 0x0000C05D
		// (set) Token: 0x06000A57 RID: 2647 RVA: 0x0000DE69 File Offset: 0x0000C069
		public virtual ImageSource Image { get; set; }

		// Token: 0x06000A58 RID: 2648 RVA: 0x00009E6A File Offset: 0x0000806A
		public virtual void #or()
		{
		}

		// Token: 0x06000A59 RID: 2649 RVA: 0x00009E6A File Offset: 0x0000806A
		public virtual void #dx()
		{
		}

		// Token: 0x06000A5A RID: 2650 RVA: 0x00009E6A File Offset: 0x0000806A
		public virtual void #qt()
		{
		}

		// Token: 0x06000A5B RID: 2651 RVA: 0x00098E10 File Offset: 0x00097010
		public override void HandleAddingBindingValidationError(string propertyName, ValidationErrorEventArgs e)
		{
			ValidationErrorEventAction action = e.Action;
			#vH #vH;
			if (action == ValidationErrorEventAction.Added)
			{
				#vH = this.Form;
				#vH.AddError(propertyName, NotifyPropertyChangedObjectWithValidation.MyPrepareErrorMessage(e.Error));
				return;
			}
			if (action != ValidationErrorEventAction.Removed)
			{
				return;
			}
			#vH = this.Form;
			#vH.#4I(propertyName);
		}

		// Token: 0x06000A5C RID: 2652 RVA: 0x00098E70 File Offset: 0x00097070
		protected override void #uh(#fx #Ee)
		{
			base.#uh(#Ee);
			#vH #vH = this.Form;
			#vH.#cD(#Ee);
		}

		// Token: 0x040003C6 RID: 966
		[CompilerGenerated]
		private readonly #vH #a;

		// Token: 0x040003C7 RID: 967
		[CompilerGenerated]
		private ImageSource #b;

		// Token: 0x040003C8 RID: 968
		[CompilerGenerated]
		private ImageSource #c;
	}
}
