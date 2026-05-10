using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Interop;
using #5Kd;
using #7hc;
using #BTd;
using #cYd;
using #ezc;
using #FTd;
using #hId;
using #LQc;
using #qPd;
using #sUd;
using Aspose.Words;
using StructurePoint.CoreAssets.GUI.Framework;
using StructurePoint.CoreAssets.GUI.Framework.Services;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Presentation;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Printing;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Printing.Presentation;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Resources;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Logger;
using Telerik.Windows.Controls;

namespace #uLd
{
	// Token: 0x02000DDF RID: 3551
	internal abstract class #JNd : PrintOptionsViewModelBase, INotifyPropertyChanged, #RBc<#6Kd>, IViewModel, #vPd
	{
		// Token: 0x06008068 RID: 32872 RVA: 0x001C0BF4 File Offset: 0x001BEDF4
		protected #JNd(#6Kd #Ee, #wUd #iw, ILogger #3x, #ATd #ry, #8Sc #ls) : base(#iw, #ry, #3x, #ls)
		{
			this.#a = #3x;
			this.View = #Ee;
			this.CancelCommand = new DelegateCommand(new Action<object>(this.#NWb));
			this.PrintCommand = new DelegateCommand(new Action<object>(this.#oMd), new Predicate<object>(this.#mLd));
			this.View.SetViewModel(this);
		}

		// Token: 0x17002659 RID: 9817
		// (get) Token: 0x06008069 RID: 32873 RVA: 0x000688B5 File Offset: 0x00066AB5
		// (set) Token: 0x0600806A RID: 32874 RVA: 0x000688C1 File Offset: 0x00066AC1
		public bool IsBusy
		{
			get
			{
				return this.#b;
			}
			set
			{
				if (this.#b != value)
				{
					this.#b = value;
					base.RaisePropertyChanged(#Phc.#3hc(107413161));
				}
			}
		}

		// Token: 0x1700265A RID: 9818
		// (get) Token: 0x0600806B RID: 32875 RVA: 0x000688EF File Offset: 0x00066AEF
		// (set) Token: 0x0600806C RID: 32876 RVA: 0x000688FB File Offset: 0x00066AFB
		public DelegateCommand PrintCommand { get; private set; }

		// Token: 0x1700265B RID: 9819
		// (get) Token: 0x0600806D RID: 32877 RVA: 0x0006890C File Offset: 0x00066B0C
		// (set) Token: 0x0600806E RID: 32878 RVA: 0x00068918 File Offset: 0x00066B18
		public DelegateCommand CancelCommand { get; private set; }

		// Token: 0x1700265C RID: 9820
		// (get) Token: 0x0600806F RID: 32879 RVA: 0x00068929 File Offset: 0x00066B29
		// (set) Token: 0x06008070 RID: 32880 RVA: 0x00068935 File Offset: 0x00066B35
		public #6Kd View { get; private set; }

		// Token: 0x1700265D RID: 9821
		// (get) Token: 0x06008071 RID: 32881 RVA: 0x00068946 File Offset: 0x00066B46
		// (set) Token: 0x06008072 RID: 32882 RVA: 0x00068952 File Offset: 0x00066B52
		public string ViewTitle { get; private set; }

		// Token: 0x06008073 RID: 32883 RVA: 0x001C0C64 File Offset: 0x001BEE64
		public void #od(IGenericLoaderWindow #th)
		{
			this.#ENd(#th);
			this.#FNd();
			if (!this.#2Jd().IsRealPrinterDevice)
			{
				if (this.View.AssociatedLoaderWindow != null)
				{
					this.View.AssociatedLoaderWindow.#Fgc();
				}
				base.DialogService.#od(StructurePoint.CoreAssets.GUI.Reporter.Core.Resources.Localization.StringNoPrinterInstalled.#z2d(), MessageBoxButton.OK, MessageBoxImage.Hand);
				return;
			}
			this.View.#TBc();
		}

		// Token: 0x06008074 RID: 32884 RVA: 0x00068963 File Offset: 0x00066B63
		protected override IntPtr #tJd()
		{
			return \u0082\u0005.\u001C\u000F(new WindowInteropHelper((Window)this.View));
		}

		// Token: 0x06008075 RID: 32885 RVA: 0x0000C78B File Offset: 0x0000A98B
		protected virtual bool #DNd()
		{
			return false;
		}

		// Token: 0x06008076 RID: 32886 RVA: 0x00009E6A File Offset: 0x0000806A
		protected virtual void #0x()
		{
		}

		// Token: 0x06008077 RID: 32887 RVA: 0x00003375 File Offset: 0x00001575
		protected virtual bool #mLd(object #Sb)
		{
			return true;
		}

		// Token: 0x06008078 RID: 32888
		protected abstract Document #bCd(#jJd #GFd);

		// Token: 0x06008079 RID: 32889 RVA: 0x0006898B File Offset: 0x00066B8B
		private void #Jh(object #Ge, EventArgs #He)
		{
			if (this.View.AssociatedLoaderWindow != null)
			{
				this.View.AssociatedLoaderWindow.#Fgc();
			}
		}

		// Token: 0x0600807A RID: 32890 RVA: 0x001C0CDC File Offset: 0x001BEEDC
		private void #ENd(IGenericLoaderWindow #th)
		{
			if (#th != null)
			{
				this.View.Activated -= this.#Jh;
				this.View.Activated += this.#Jh;
			}
			else
			{
				this.View.Activated -= this.#Jh;
			}
			this.View.AssociatedLoaderWindow = #th;
		}

		// Token: 0x0600807B RID: 32891 RVA: 0x000689B6 File Offset: 0x00066BB6
		private void #FNd()
		{
			if (!this.#mLd(null))
			{
				base.#uP(null);
				return;
			}
			this.#0x();
			base.#uP(new PrintOptionsSetup());
		}

		// Token: 0x0600807C RID: 32892 RVA: 0x001C0D4C File Offset: 0x001BEF4C
		private void #oMd(object #Sb)
		{
			#JNd.#8Vd #8Vd;
			#8Vd.#b = \u001B\u0006.\u001C\u0010();
			#8Vd.#c = this;
			#8Vd.#a = -1;
			#8Vd.#b.Start<#JNd.#8Vd>(ref #8Vd);
		}

		// Token: 0x0600807D RID: 32893 RVA: 0x000689E6 File Offset: 0x00066BE6
		private void #jgb()
		{
			\u0007.~\u000F(this.PrintCommand);
		}

		// Token: 0x0600807E RID: 32894 RVA: 0x001C0D94 File Offset: 0x001BEF94
		private void #GNd()
		{
			try
			{
				#jJd #jJd = this.#2Jd();
				base.SettingsManager.#mUd(#jJd, #NTd.#a);
				AsposeDocumentPrinter.#SHd(this.#bCd(#jJd), #jJd);
			}
			catch (Exception #ob)
			{
				this.#HNd(#ob);
			}
		}

		// Token: 0x0600807F RID: 32895 RVA: 0x00068A04 File Offset: 0x00066C04
		private void #HNd(Exception #ob)
		{
			this.#a.Log(LoggingLevel.Error, #ob);
			base.DialogService.#qn(#sYd.#oYd(#ob));
		}

		// Token: 0x06008080 RID: 32896 RVA: 0x00068A30 File Offset: 0x00066C30
		[CompilerGenerated]
		private void #NWb(object #gsb)
		{
			this.View.#Fgc();
		}

		// Token: 0x06008081 RID: 32897 RVA: 0x00068A49 File Offset: 0x00066C49
		[CompilerGenerated]
		private void #INd()
		{
			this.#GNd();
		}

		// Token: 0x040034AA RID: 13482
		private readonly ILogger #a;

		// Token: 0x040034AB RID: 13483
		private bool #b;

		// Token: 0x040034AC RID: 13484
		[CompilerGenerated]
		private DelegateCommand #c;

		// Token: 0x040034AD RID: 13485
		[CompilerGenerated]
		private DelegateCommand #d;

		// Token: 0x040034AE RID: 13486
		[CompilerGenerated]
		private #6Kd #e;

		// Token: 0x040034AF RID: 13487
		[CompilerGenerated]
		private string #f;
	}
}
