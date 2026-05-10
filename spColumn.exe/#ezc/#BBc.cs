using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.Framework;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.CoreAssets.Logger;

namespace #ezc
{
	// Token: 0x02000B4E RID: 2894
	internal abstract class #BBc<#fx> : NotifyPropertyChangedObjectWithValidation, INotifyPropertyChanged, #RBc<!0>, #Fzc<!0>, IViewModel where #fx : #QBc
	{
		// Token: 0x06005E6F RID: 24175 RVA: 0x00177984 File Offset: 0x00175B84
		protected #BBc(#GBc #2x, #fx #Ee, ILogger #3x)
		{
			#X0d.#V0d(#2x, #Phc.#3hc(107417812), StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUIFramework, #Phc.#3hc(107417787));
			this.DependencyResolver = #2x;
			this.View = #Ee;
			this.Logger = #3x;
			this.ApplicationInfoProvider = #2x.#vy<#xAc>();
		}

		// Token: 0x06005E70 RID: 24176 RVA: 0x0004E983 File Offset: 0x0004CB83
		protected #BBc(#fx #Ee)
		{
			this.View = #Ee;
		}

		// Token: 0x17001AC7 RID: 6855
		// (get) Token: 0x06005E71 RID: 24177 RVA: 0x0004E992 File Offset: 0x0004CB92
		// (set) Token: 0x06005E72 RID: 24178 RVA: 0x0004E99A File Offset: 0x0004CB9A
		public #xAc ApplicationInfoProvider { get; private set; }

		// Token: 0x17001AC8 RID: 6856
		// (get) Token: 0x06005E73 RID: 24179 RVA: 0x0004E9A3 File Offset: 0x0004CBA3
		// (set) Token: 0x06005E74 RID: 24180 RVA: 0x0004E9AB File Offset: 0x0004CBAB
		private protected #GBc DependencyResolver { protected get; private set; }

		// Token: 0x17001AC9 RID: 6857
		// (get) Token: 0x06005E75 RID: 24181 RVA: 0x0004E9B4 File Offset: 0x0004CBB4
		// (set) Token: 0x06005E76 RID: 24182 RVA: 0x0004E9BC File Offset: 0x0004CBBC
		public ILogger Logger { get; private set; }

		// Token: 0x17001ACA RID: 6858
		// (get) Token: 0x06005E77 RID: 24183 RVA: 0x0004E9C5 File Offset: 0x0004CBC5
		// (set) Token: 0x06005E78 RID: 24184 RVA: 0x0004E9CD File Offset: 0x0004CBCD
		public #fx View { get; private set; }

		// Token: 0x17001ACB RID: 6859
		// (get) Token: 0x06005E79 RID: 24185 RVA: 0x001779D4 File Offset: 0x00175BD4
		public virtual string ViewTitle
		{
			get
			{
				#fx #fx = this.View;
				#fx #fx2;
				if (7 != 0)
				{
					#fx2 = #fx;
				}
				return #fx2.Title;
			}
		}

		// Token: 0x06005E7A RID: 24186 RVA: 0x0004E9D6 File Offset: 0x0004CBD6
		bool #Fzc<!0>.#wBc()
		{
			return base.IsValid;
		}

		// Token: 0x06005E7B RID: 24187 RVA: 0x0004E9DE File Offset: 0x0004CBDE
		void #Fzc<!0>.#xBc()
		{
			if (6 != 0)
			{
				base.RefreshErrors();
			}
		}

		// Token: 0x06005E7C RID: 24188 RVA: 0x0004E9EC File Offset: 0x0004CBEC
		void #Fzc<!0>.#yBc(ValidationErrorEventArgs #He)
		{
			if (!false)
			{
				base.HandleBindingValidationError(#He);
			}
		}

		// Token: 0x06005E7D RID: 24189 RVA: 0x0004E9FC File Offset: 0x0004CBFC
		bool #Fzc<!0>.#zBc(string #em)
		{
			return base.CheckIfPropertyHasErrors(#em);
		}

		// Token: 0x06005E7E RID: 24190 RVA: 0x0004EA05 File Offset: 0x0004CC05
		void #Fzc<!0>.#ABc()
		{
			if (6 != 0)
			{
				base.ClearErrors();
			}
		}

		// Token: 0x04002721 RID: 10017
		[CompilerGenerated]
		private #xAc #a;

		// Token: 0x04002722 RID: 10018
		[CompilerGenerated]
		private #GBc #b;

		// Token: 0x04002723 RID: 10019
		[CompilerGenerated]
		private ILogger #c;

		// Token: 0x04002724 RID: 10020
		[CompilerGenerated]
		private #fx #d;
	}
}
