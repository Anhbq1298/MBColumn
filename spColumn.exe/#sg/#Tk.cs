using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using #1b;
using #3wb;
using #7hc;
using #eU;
using #HI;
using #Hl;
using #ID;
using #IDc;
using #IW;
using #lH;
using #OT;
using #Swb;
using #wD;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.Templates.Storage;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.Products.Column.Core.API;
using StructurePoint.Products.Column.Editor.Project;
using StructurePoint.Products.Column.Editor.Section;
using StructurePoint.Products.Column.Resources.Images;
using StructurePoint.Products.Column.Services.API;
using StructurePoint.Products.Column.ViewModels.Items;
using Telerik.Windows.Controls;
using Telerik.Windows.Data;

namespace #sg
{
	// Token: 0x020000EA RID: 234
	internal sealed class #Tk : #HH<#9b>, IViewModel<#9b>, INotifyPropertyChanged, IViewModel, #LI
	{
		// Token: 0x06000787 RID: 1927 RVA: 0x00091068 File Offset: 0x0008F268
		public #Tk(Lazy<#9b> #Ee, ICoreServices #0c, #JI #Uk, #NI #Vk, #vU #Wk, #7wb #Xk, IEditorService #wj, #KW #Cj, #nF #Yk, #2wb #yj, #Rwb #Zk, #CD #0k) : base(#Ee, #0c)
		{
			this.#a = #Vk;
			this.#b = #Wk;
			this.#c = #Xk;
			this.#d = #wj;
			this.#e = #Cj;
			this.#f = #Yk;
			this.#g = #yj;
			this.#h = #Zk;
			this.#i = #0k;
			if (#Uk == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107382619));
			}
			this.#j = #Uk;
			this.#m = new DelegateCommand(new Action<object>(this.#Nk));
			this.#n = new DelegateCommand(new Action<object>(this.#Ok));
			this.#o = new DelegateCommand(new Action<object>(this.#Mk));
			this.#p = new DelegateCommand(new Action<object>(this.#Lk));
			this.#q = new DelegateCommand(new Action<object>(this.#Kk));
			this.#r = new DelegateCommand(new Action<object>(this.#gTh), new Predicate<object>(this.#hTh));
			this.#s = new DelegateCommand(new Action<object>(this.#jh), new Predicate<object>(this.#Hk));
			this.#t = new DelegateCommand(new Action<object>(this.#Ik), new Predicate<object>(this.#Jk));
			this.LeftResourceLinks.#pR(new #Gl[]
			{
				new #Gl(this.OpenResourceLinkCommand, Strings.StringManual.#B2d(), #Phc.#3hc(107382590)),
				new #Gl(this.OpenResourceLinkCommand, Strings.StringDesignExamples.#B2d(), #Phc.#3hc(107381973)),
				new #Gl(this.OpenResourceLinkCommand, Strings.StringTutorialVideos.#B2d(), #Phc.#3hc(107381824), ColumnImages.TutorialVideos_114X80)
			});
			this.RightResourceLinks.#pR(new #Gl[]
			{
				new #Gl(this.OpenResourceLinkCommand, Strings.StringSpColumnInfo.#B2d(), #Phc.#3hc(107382219)),
				new #Gl(this.OpenResourceLinkCommand, Strings.StringSubmitAQuestion.#B2d(), #Phc.#3hc(107382142)),
				new #Gl(this.OpenResourceLinkCommand, Strings.StringCheckForUpdates.#B2d(), #Phc.#3hc(107382033)),
				new #Gl(this.OpenResourceLinkCommand, Strings.StringReleaseNotes.#B2d(), #Phc.#3hc(107381380)),
				new #Gl(this.OpenAboutCommand, Strings.StringAboutSpColumn)
			});
			base.Services.GuiController.PropertyChanged += this.#wk;
		}

		// Token: 0x06000788 RID: 1928 RVA: 0x0000BC01 File Offset: 0x00009E01
		private void #wk(object #Ge, PropertyChangedEventArgs #He)
		{
			this.#vh();
		}

		// Token: 0x17000332 RID: 818
		// (get) Token: 0x06000789 RID: 1929 RVA: 0x0000BC11 File Offset: 0x00009E11
		public #JI RecentProjectsManager { get; }

		// Token: 0x17000333 RID: 819
		// (get) Token: 0x0600078A RID: 1930 RVA: 0x0000BC1D File Offset: 0x00009E1D
		public RadObservableCollection<#Gl> LeftResourceLinks { get; }

		// Token: 0x17000334 RID: 820
		// (get) Token: 0x0600078B RID: 1931 RVA: 0x0000BC29 File Offset: 0x00009E29
		public RadObservableCollection<#Gl> RightResourceLinks { get; }

		// Token: 0x17000335 RID: 821
		// (get) Token: 0x0600078C RID: 1932 RVA: 0x0000BC35 File Offset: 0x00009E35
		public DelegateCommand OpenFileCommand { get; }

		// Token: 0x17000336 RID: 822
		// (get) Token: 0x0600078D RID: 1933 RVA: 0x0000BC41 File Offset: 0x00009E41
		public DelegateCommand BrowseDirectoryCommand { get; }

		// Token: 0x17000337 RID: 823
		// (get) Token: 0x0600078E RID: 1934 RVA: 0x0000BC4D File Offset: 0x00009E4D
		public DelegateCommand ClearHistoryCommand { get; }

		// Token: 0x17000338 RID: 824
		// (get) Token: 0x0600078F RID: 1935 RVA: 0x0000BC59 File Offset: 0x00009E59
		public DelegateCommand OpenResourceLinkCommand { get; }

		// Token: 0x17000339 RID: 825
		// (get) Token: 0x06000790 RID: 1936 RVA: 0x0000BC65 File Offset: 0x00009E65
		public DelegateCommand OpenAboutCommand { get; }

		// Token: 0x1700033A RID: 826
		// (get) Token: 0x06000791 RID: 1937 RVA: 0x0000BC71 File Offset: 0x00009E71
		public DelegateCommand DeleteFromListCommand { get; }

		// Token: 0x1700033B RID: 827
		// (get) Token: 0x06000792 RID: 1938 RVA: 0x0000BC7D File Offset: 0x00009E7D
		public DelegateCommand ImportLoadsCommand { get; }

		// Token: 0x1700033C RID: 828
		// (get) Token: 0x06000793 RID: 1939 RVA: 0x0000BC89 File Offset: 0x00009E89
		public DelegateCommand OpenTemplatesCommand { get; }

		// Token: 0x1700033D RID: 829
		// (get) Token: 0x06000794 RID: 1940 RVA: 0x0000BC95 File Offset: 0x00009E95
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x06000795 RID: 1941 RVA: 0x0000BCA5 File Offset: 0x00009EA5
		protected override void #uh(#9b #Ee)
		{
			base.#uh(#Ee);
			this.RecentProjectsManager.#eb();
		}

		// Token: 0x06000796 RID: 1942 RVA: 0x0000BCC5 File Offset: 0x00009EC5
		protected override void #vh()
		{
			base.#vh();
			this.OpenTemplatesCommand.InvalidateCanExecute();
			this.ImportLoadsCommand.InvalidateCanExecute();
		}

		// Token: 0x06000797 RID: 1943 RVA: 0x00091318 File Offset: 0x0008F518
		private void #gTh(object #Sb)
		{
			RecentDocumentListEntry recentDocumentListEntry = #Sb as RecentDocumentListEntry;
			if (recentDocumentListEntry != null)
			{
				this.RecentProjectsManager.#F7c(recentDocumentListEntry);
			}
		}

		// Token: 0x06000798 RID: 1944 RVA: 0x00003375 File Offset: 0x00001575
		private bool #hTh(object #Sb)
		{
			return true;
		}

		// Token: 0x06000799 RID: 1945 RVA: 0x00091348 File Offset: 0x0008F548
		private void #jh(object #Sb)
		{
			if (!base.DialogService.#ABf())
			{
				return;
			}
			if (base.Services.GuiController.IsStartupPageOpen)
			{
				#Tk.#oUb #oUb = new #Tk.#oUb();
				#oUb.#b = this;
				#oUb.#a = this.#f.#GD();
				if (#oUb.#a == null || !#oUb.#a.IsSuccess)
				{
					return;
				}
				this.#b.#DK(new Action(#oUb.#EUb));
				return;
			}
			else
			{
				#Tk.#2Wh #2Wh = new #Tk.#2Wh();
				#2Wh.#b = this;
				#2Wh.#a = this.#f.#GD();
				if (#2Wh.#a == null || !#2Wh.#a.IsSuccess)
				{
					return;
				}
				this.#d.#0Pb(new Action(#2Wh.#JUb));
				base.Services.GuiController.IsBackstageOpen = false;
				return;
			}
		}

		// Token: 0x0600079A RID: 1946 RVA: 0x0000BCEF File Offset: 0x00009EEF
		private bool #Hk(object #Sb)
		{
			return base.Services.GuiController.IsStartupPageOpen || !base.Project.Model.Options.ConsiderSlenderness;
		}

		// Token: 0x0600079B RID: 1947 RVA: 0x00091440 File Offset: 0x0008F640
		private void #Ik(object #Sb)
		{
			bool flag = base.Project.Model.#IY();
			if (base.Services.GuiController.IsStartupPageOpen)
			{
				#Tk.#qUb #qUb = new #Tk.#qUb();
				#qUb.#b = this;
				if (!this.#c.#6wb(out #qUb.#a) || #qUb.#a == null)
				{
					return;
				}
				this.#b.#DK(new Action(#qUb.#UUb));
				return;
			}
			else
			{
				if (base.Project.Model.Options.SectionType == SectionType.IrregularTemplate || flag)
				{
					LayoutHelper.BeginInvokeOnApplicationThread(new Action(this.#kTh));
					return;
				}
				#Tk.#U6b #U6b = new #Tk.#U6b();
				#U6b.#b = this;
				if (!this.#c.#6wb(out #U6b.#a) || #U6b.#a == null)
				{
					return;
				}
				this.#d.#0Pb(new Action(#U6b.#XUb));
				return;
			}
		}

		// Token: 0x0600079C RID: 1948 RVA: 0x0000BD29 File Offset: 0x00009F29
		private bool #Jk(object #Sb)
		{
			return base.Project.Model.Options.ProblemType == ProblemType.Investigation;
		}

		// Token: 0x0600079D RID: 1949 RVA: 0x0000BD4F File Offset: 0x00009F4F
		private void #Kk(object #Sb)
		{
			this.#a.#od();
		}

		// Token: 0x0600079E RID: 1950 RVA: 0x00091540 File Offset: 0x0008F740
		private void #Lk(object #Sb)
		{
			try
			{
				#Gl #Gl = #Sb as #Gl;
				if (#Gl != null && !string.IsNullOrWhiteSpace(#Gl.Url))
				{
					base.Services.FileSystem.#61c(#Gl.Url);
				}
			}
			catch (Exception #ob)
			{
				base.Services.ErrorsHandler.#bzc(Strings.StringCouldNotNavigateToTheResource.#z2d(), #ob, new #3Hc(base.Services.ApplicationInfo.ApplicationName));
			}
		}

		// Token: 0x0600079F RID: 1951 RVA: 0x0000BD64 File Offset: 0x00009F64
		private void #Mk(object #Sb)
		{
			this.RecentProjectsManager.#yl();
		}

		// Token: 0x060007A0 RID: 1952 RVA: 0x000915CC File Offset: 0x0008F7CC
		private void #Nk(object #Sb)
		{
			RecentDocumentListEntry recentDocumentListEntry = #Sb as RecentDocumentListEntry;
			if (recentDocumentListEntry != null)
			{
				base.Services.MessageBus.#wV(true, recentDocumentListEntry.FullPath);
			}
		}

		// Token: 0x060007A1 RID: 1953 RVA: 0x00091608 File Offset: 0x0008F808
		private void #Ok(object #Sb)
		{
			RecentDocumentListEntry recentDocumentListEntry = #Sb as RecentDocumentListEntry;
			if (recentDocumentListEntry != null)
			{
				base.Services.MessageBus.#wV(false, recentDocumentListEntry.DirectoryPath);
			}
		}

		// Token: 0x060007A2 RID: 1954 RVA: 0x0000BD7D File Offset: 0x00009F7D
		[CompilerGenerated]
		private void #iTh()
		{
			this.#i.#Mq();
		}

		// Token: 0x060007A3 RID: 1955 RVA: 0x0000BD7D File Offset: 0x00009F7D
		[CompilerGenerated]
		private void #jTh()
		{
			this.#i.#Mq();
		}

		// Token: 0x060007A4 RID: 1956 RVA: 0x00091644 File Offset: 0x0008F844
		[CompilerGenerated]
		private void #kTh()
		{
			base.Services.GuiController.IsBackstageOpen = false;
			base.Services.Commands.ActivateScopeWithParameters.Execute(new SectionScopeActivationParameters());
			LayoutHelper.BeginInvokeOnApplicationThread(new Action(this.#lTh));
		}

		// Token: 0x060007A5 RID: 1957 RVA: 0x0000BD92 File Offset: 0x00009F92
		[CompilerGenerated]
		private void #lTh()
		{
			base.Services.MessageBus.#TV();
		}

		// Token: 0x040001FF RID: 511
		private readonly #NI #a;

		// Token: 0x04000200 RID: 512
		private readonly #vU #b;

		// Token: 0x04000201 RID: 513
		private readonly #7wb #c;

		// Token: 0x04000202 RID: 514
		private readonly IEditorService #d;

		// Token: 0x04000203 RID: 515
		private readonly #KW #e;

		// Token: 0x04000204 RID: 516
		private readonly #nF #f;

		// Token: 0x04000205 RID: 517
		private readonly #2wb #g;

		// Token: 0x04000206 RID: 518
		private readonly #Rwb #h;

		// Token: 0x04000207 RID: 519
		private readonly #CD #i;

		// Token: 0x04000208 RID: 520
		[CompilerGenerated]
		private readonly #JI #j;

		// Token: 0x04000209 RID: 521
		[CompilerGenerated]
		private readonly RadObservableCollection<#Gl> #k = new RadObservableCollection<#Gl>();

		// Token: 0x0400020A RID: 522
		[CompilerGenerated]
		private readonly RadObservableCollection<#Gl> #l = new RadObservableCollection<#Gl>();

		// Token: 0x0400020B RID: 523
		[CompilerGenerated]
		private readonly DelegateCommand #m;

		// Token: 0x0400020C RID: 524
		[CompilerGenerated]
		private readonly DelegateCommand #n;

		// Token: 0x0400020D RID: 525
		[CompilerGenerated]
		private readonly DelegateCommand #o;

		// Token: 0x0400020E RID: 526
		[CompilerGenerated]
		private readonly DelegateCommand #p;

		// Token: 0x0400020F RID: 527
		[CompilerGenerated]
		private readonly DelegateCommand #q;

		// Token: 0x04000210 RID: 528
		[CompilerGenerated]
		private readonly DelegateCommand #r;

		// Token: 0x04000211 RID: 529
		[CompilerGenerated]
		private readonly DelegateCommand #s;

		// Token: 0x04000212 RID: 530
		[CompilerGenerated]
		private readonly DelegateCommand #t;

		// Token: 0x020000EB RID: 235
		[CompilerGenerated]
		private sealed class #oUb
		{
			// Token: 0x060007A7 RID: 1959 RVA: 0x0009169C File Offset: 0x0008F89C
			internal void #EUb()
			{
				Action action;
				if ((action = this.#c) == null)
				{
					action = (this.#c = new Action(this.#IUb));
				}
				LayoutHelper.BeginInvokeOnApplicationThread(action);
			}

			// Token: 0x060007A8 RID: 1960 RVA: 0x000916DC File Offset: 0x0008F8DC
			internal void #IUb()
			{
				this.#b.Project.Model.Options.InvestigationLoad = LoadType.Factored;
				this.#b.Project.Model.Options.InvestigationLoad = LoadType.Factored;
				this.#b.Project.Model.FactoredLoads.Clear();
				this.#b.Project.Model.FactoredLoads.AddRange(this.#a.ImportedFactoredLoads);
				this.#b.#b.#CK();
				if (this.#a.ImportedFactoredLoads.Count > 0)
				{
					LayoutHelper.BeginInvokeOnApplicationThread(new Action(this.#b.#iTh));
				}
			}

			// Token: 0x04000213 RID: 531
			public #TT #a;

			// Token: 0x04000214 RID: 532
			public #Tk #b;

			// Token: 0x04000215 RID: 533
			public Action #c;
		}

		// Token: 0x020000EC RID: 236
		[CompilerGenerated]
		private sealed class #2Wh
		{
			// Token: 0x060007AA RID: 1962 RVA: 0x000917B8 File Offset: 0x0008F9B8
			internal void #JUb()
			{
				this.#b.Project.Model.FactoredLoads.Clear();
				this.#b.Project.Model.FactoredLoads.AddRange(this.#a.ImportedFactoredLoads);
				this.#b.Project.Model.Options.InvestigationLoad = LoadType.Factored;
				this.#b.Project.Model.Options.DesignLoad = LoadType.Factored;
				if (this.#a.ImportedFactoredLoads.Count > 0)
				{
					LayoutHelper.BeginInvokeOnApplicationThread(new Action(this.#b.#jTh));
				}
			}

			// Token: 0x04000216 RID: 534
			public #TT #a;

			// Token: 0x04000217 RID: 535
			public #Tk #b;
		}

		// Token: 0x020000ED RID: 237
		[CompilerGenerated]
		private sealed class #qUb
		{
			// Token: 0x060007AC RID: 1964 RVA: 0x00091884 File Offset: 0x0008FA84
			internal void #UUb()
			{
				Action action;
				if ((action = this.#c) == null)
				{
					action = (this.#c = new Action(this.#VUb));
				}
				LayoutHelper.BeginInvokeOnApplicationThread(action);
			}

			// Token: 0x060007AD RID: 1965 RVA: 0x000918C4 File Offset: 0x0008FAC4
			internal void #VUb()
			{
				this.#b.Project.Model.Options.SectionType = SectionType.IrregularTemplate;
				this.#b.Project.Model.Options.InvestigationReinforcement = ReinforcementType.Irregular;
				this.#b.#h.#Owb(this.#a);
				this.#b.#b.#CK();
				this.#b.#g.#0wb(true);
				this.#b.Services.Commands.ActivateScopeWithParameters.Execute(new ProjectScopeActivationParameters());
			}

			// Token: 0x04000218 RID: 536
			public SectionTemplateDefinition #a;

			// Token: 0x04000219 RID: 537
			public #Tk #b;

			// Token: 0x0400021A RID: 538
			public Action #c;
		}

		// Token: 0x020000EE RID: 238
		[CompilerGenerated]
		private sealed class #U6b
		{
			// Token: 0x060007AF RID: 1967 RVA: 0x0009197C File Offset: 0x0008FB7C
			internal void #XUb()
			{
				this.#b.Project.Model.Options.ProblemType = ProblemType.Investigation;
				this.#b.Project.Model.Options.SectionType = SectionType.IrregularTemplate;
				this.#b.Project.Model.Options.InvestigationReinforcement = ReinforcementType.Irregular;
				this.#b.#e.#5T();
				this.#b.#h.#Owb(this.#a);
				this.#b.#g.#0wb(true);
				this.#b.Services.GuiController.IsBackstageOpen = false;
				this.#b.Services.Commands.ActivateScopeWithParameters.Execute(new SectionScopeActivationParameters());
			}

			// Token: 0x0400021B RID: 539
			public SectionTemplateDefinition #a;

			// Token: 0x0400021C RID: 540
			public #Tk #b;
		}
	}
}
