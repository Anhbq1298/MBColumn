using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using #1b;
using #6s;
using #7hc;
using #HI;
using #lH;
using #Lx;
using #Mbb;
using #Mn;
using #Oze;
using #PI;
using #RJb;
using #S9;
using #wD;
using #WG;
using #WI;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.Products.Column.Services.API;
using StructurePoint.Products.Column.ViewModels.API.Definitions;
using StructurePoint.Products.Column.ViewModels.Settings.API;
using StructurePoint.Products.Column.ViewModels.Slenderness.Helpers;
using Telerik.Windows.Controls;

namespace #sg
{
	// Token: 0x020000E7 RID: 231
	internal sealed class #qk : #HH<#8b>, IViewModel<#8b>, INotifyPropertyChanged, IViewModel, #KI
	{
		// Token: 0x0600075A RID: 1882 RVA: 0x00090BD4 File Offset: 0x0008EDD4
		public #qk(Lazy<#8b> #Ee, IExtendedServices #0c, #LI #cj, #BLb #fj, #0G #rk, #ht #sk, #CD #tk, #Vx #ng, #vbb #kj, #Vgb #uk, #Ln #vk, #mAe #6c) : base(#Ee, #0c)
		{
			this.#a = #0c;
			this.#b = #vk;
			this.#e = #uk;
			this.#q = #cj;
			if (#rk == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107382689));
			}
			this.#r = #rk;
			if (#sk == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107382704));
			}
			this.#s = #sk;
			if (#tk == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107382687));
			}
			this.#t = #tk;
			if (#ng == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107382678));
			}
			this.#u = #ng;
			this.#v = #kj;
			this.#x = #6c;
			if (#fj == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107382952));
			}
			this.#w = #fj;
			this.#k = new DelegateCommand(new Action<object>(this.#nk));
			this.#l = new DelegateCommand(new Action<object>(this.#ek));
			this.#m = new DelegateCommand(new Action<object>(this.#hk));
			this.#n = new DelegateCommand(new Action<object>(this.#jk));
			this.#o = new DelegateCommand(new Action<object>(this.#lk));
			this.#p = new DelegateCommand(new Action<object>(this.#mk));
			this.#g = new DelegateCommand(new Action<object>(this.#pk));
			this.#f = new DelegateCommand(new Action<object>(this.#ok));
			this.#h = new DelegateCommand(new Action<object>(this.#dk));
			this.#i = new DelegateCommand(new Action<object>(this.#ck));
			this.#y = new DelegateCommand(new Action<object>(this.#bk));
			this.#j = new DelegateCommand(new Action<object>(this.#9j));
			this.#z = new DelegateCommand(new Action<object>(this.#8j));
			base.Services.Commands.OpenSettings.SetCommand(new Action<object>(this.#mk));
		}

		// Token: 0x17000318 RID: 792
		// (get) Token: 0x0600075B RID: 1883 RVA: 0x0000B95C File Offset: 0x00009B5C
		public #Vgb DisplayOptions { get; }

		// Token: 0x17000319 RID: 793
		// (get) Token: 0x0600075C RID: 1884 RVA: 0x0000B968 File Offset: 0x00009B68
		public DelegateCommand OpenNewViewportCommand { get; }

		// Token: 0x1700031A RID: 794
		// (get) Token: 0x0600075D RID: 1885 RVA: 0x0000B974 File Offset: 0x00009B74
		public DelegateCommand OpenQuadViewportsCommand { get; }

		// Token: 0x1700031B RID: 795
		// (get) Token: 0x0600075E RID: 1886 RVA: 0x0000B980 File Offset: 0x00009B80
		public DelegateCommand OpenDouble2D3DPMViewportsCommand { get; }

		// Token: 0x1700031C RID: 796
		// (get) Token: 0x0600075F RID: 1887 RVA: 0x0000B98C File Offset: 0x00009B8C
		public DelegateCommand OpenDouble2D3DMMViewportsCommand { get; }

		// Token: 0x1700031D RID: 797
		// (get) Token: 0x06000760 RID: 1888 RVA: 0x0000B998 File Offset: 0x00009B98
		public DelegateCommand OpenBatchProcessorCommand { get; }

		// Token: 0x1700031E RID: 798
		// (get) Token: 0x06000761 RID: 1889 RVA: 0x0000B9A4 File Offset: 0x00009BA4
		// (set) Token: 0x06000762 RID: 1890 RVA: 0x0000B9B0 File Offset: 0x00009BB0
		public bool IsRibbonMinimized
		{
			get
			{
				return this.#c;
			}
			private set
			{
				this.SetProperty<bool>(ref this.#c, value, #Phc.#3hc(107382633));
			}
		}

		// Token: 0x1700031F RID: 799
		// (get) Token: 0x06000763 RID: 1891 RVA: 0x0000B9D6 File Offset: 0x00009BD6
		public DelegateCommand RibbonMinimized { get; }

		// Token: 0x17000320 RID: 800
		// (get) Token: 0x06000764 RID: 1892 RVA: 0x0000B9E2 File Offset: 0x00009BE2
		public DelegateCommand GoBackCommand { get; }

		// Token: 0x17000321 RID: 801
		// (get) Token: 0x06000765 RID: 1893 RVA: 0x0000B9EE File Offset: 0x00009BEE
		public DelegateCommand OpenDefinitionsCommand { get; }

		// Token: 0x17000322 RID: 802
		// (get) Token: 0x06000766 RID: 1894 RVA: 0x0000B9FA File Offset: 0x00009BFA
		public DelegateCommand OpenSlendernessCommand { get; }

		// Token: 0x17000323 RID: 803
		// (get) Token: 0x06000767 RID: 1895 RVA: 0x0000BA06 File Offset: 0x00009C06
		public DelegateCommand OpenLoadsCommand { get; }

		// Token: 0x17000324 RID: 804
		// (get) Token: 0x06000768 RID: 1896 RVA: 0x0000BA12 File Offset: 0x00009C12
		public DelegateCommand OpenSettingsCommand { get; }

		// Token: 0x17000325 RID: 805
		// (get) Token: 0x06000769 RID: 1897 RVA: 0x0000BA1E File Offset: 0x00009C1E
		public #LI StartPage { get; }

		// Token: 0x17000326 RID: 806
		// (get) Token: 0x0600076A RID: 1898 RVA: 0x0000BA2A File Offset: 0x00009C2A
		public #YI<DefinitionType> Definitions { get; }

		// Token: 0x17000327 RID: 807
		// (get) Token: 0x0600076B RID: 1899 RVA: 0x0000BA36 File Offset: 0x00009C36
		public #RI<SlendernessPanelType> Slenderness { get; }

		// Token: 0x17000328 RID: 808
		// (get) Token: 0x0600076C RID: 1900 RVA: 0x0000BA42 File Offset: 0x00009C42
		public #CD Loads { get; }

		// Token: 0x17000329 RID: 809
		// (get) Token: 0x0600076D RID: 1901 RVA: 0x0000BA4E File Offset: 0x00009C4E
		public #Vx Settings { get; }

		// Token: 0x1700032A RID: 810
		// (get) Token: 0x0600076E RID: 1902 RVA: 0x0000BA5A File Offset: 0x00009C5A
		public #vbb DiagramsManager { get; }

		// Token: 0x1700032B RID: 811
		// (get) Token: 0x0600076F RID: 1903 RVA: 0x0000BA66 File Offset: 0x00009C66
		public #BLb EditorScopesManager { get; }

		// Token: 0x1700032C RID: 812
		// (get) Token: 0x06000770 RID: 1904 RVA: 0x0000BA72 File Offset: 0x00009C72
		public #mAe SuperImposeContext { get; }

		// Token: 0x1700032D RID: 813
		// (get) Token: 0x06000771 RID: 1905 RVA: 0x0000BA7E File Offset: 0x00009C7E
		public DelegateCommand OpenDouble2DPMMMViewportsCommand { get; }

		// Token: 0x1700032E RID: 814
		// (get) Token: 0x06000772 RID: 1906 RVA: 0x0000BA8A File Offset: 0x00009C8A
		// (set) Token: 0x06000773 RID: 1907 RVA: 0x00090DF0 File Offset: 0x0008EFF0
		public string UndoManagerInfo
		{
			get
			{
				return this.#d;
			}
			set
			{
				if (this.#d != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107382640));
					this.#d = value;
					base.RaisePropertyChanged(#Phc.#3hc(107382640));
				}
			}
		}

		// Token: 0x1700032F RID: 815
		// (get) Token: 0x06000774 RID: 1908 RVA: 0x0000BA96 File Offset: 0x00009C96
		public DelegateCommand HandleDropDownOpeningCommand { get; }

		// Token: 0x17000330 RID: 816
		// (get) Token: 0x06000775 RID: 1909 RVA: 0x0000BAA2 File Offset: 0x00009CA2
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x06000776 RID: 1910 RVA: 0x00009E6A File Offset: 0x0000806A
		private void #7j(object #Ge, PropertyChangedEventArgs #He)
		{
		}

		// Token: 0x06000777 RID: 1911 RVA: 0x0000BAB2 File Offset: 0x00009CB2
		private void #8j(object #Sb)
		{
			this.#a.Commands.#cg();
		}

		// Token: 0x06000778 RID: 1912 RVA: 0x0000BAD0 File Offset: 0x00009CD0
		private void #9j(object #Sb)
		{
			if (!base.DialogService.#ABf())
			{
				return;
			}
			this.#b.#Kn();
		}

		// Token: 0x06000779 RID: 1913 RVA: 0x00090E40 File Offset: 0x0008F040
		private void #bk(object #Sb)
		{
			try
			{
				if (base.DialogService.#ABf())
				{
					this.DiagramsManager.#Kc();
				}
			}
			catch (Exception #ob)
			{
				this.#a.ExceptionHandler.#3Ab(#ob);
			}
		}

		// Token: 0x0600077A RID: 1914 RVA: 0x00090E9C File Offset: 0x0008F09C
		private void #ck(object #Sb)
		{
			try
			{
				this.DiagramsManager.#Mc();
			}
			catch (Exception #ob)
			{
				this.#a.ExceptionHandler.#3Ab(#ob);
			}
		}

		// Token: 0x0600077B RID: 1915 RVA: 0x00090EE8 File Offset: 0x0008F0E8
		private void #dk(object #Sb)
		{
			try
			{
				this.DiagramsManager.#Lc();
			}
			catch (Exception #ob)
			{
				this.#a.ExceptionHandler.#3Ab(#ob);
			}
		}

		// Token: 0x0600077C RID: 1916 RVA: 0x0000BAF7 File Offset: 0x00009CF7
		private void #ek(object #Sb)
		{
			base.Services.GuiController.IsBackstageOpen = false;
		}

		// Token: 0x0600077D RID: 1917 RVA: 0x0000BB16 File Offset: 0x00009D16
		private void #hk(object #Sb)
		{
			if (!base.DialogService.#ABf())
			{
				return;
			}
			this.#a.MouseAndKeyboard.#M2c();
			this.Definitions.#Mq();
		}

		// Token: 0x0600077E RID: 1918 RVA: 0x0000BB4D File Offset: 0x00009D4D
		private void #jk(object #Sb)
		{
			if (!base.DialogService.#ABf())
			{
				return;
			}
			this.#a.MouseAndKeyboard.#M2c();
			this.Slenderness.#Mq();
		}

		// Token: 0x0600077F RID: 1919 RVA: 0x0000BB84 File Offset: 0x00009D84
		private void #lk(object #Sb)
		{
			if (!base.DialogService.#ABf())
			{
				return;
			}
			this.#a.MouseAndKeyboard.#M2c();
			this.Loads.#Mq();
		}

		// Token: 0x06000780 RID: 1920 RVA: 0x00090F34 File Offset: 0x0008F134
		private void #mk(object #Sb)
		{
			#qk.#Tbc #Tbc = new #qk.#Tbc();
			#Tbc.#a = this;
			if (!base.DialogService.#ABf())
			{
				return;
			}
			#Tbc.#b = (SettingType?)#Sb;
			this.#a.MouseAndKeyboard.#M2c();
			if (#Tbc.#b == null)
			{
				this.Settings.#Mq();
				return;
			}
			LayoutHelper.BeginInvokeOnApplicationThread(new Action(#Tbc.#QUb));
		}

		// Token: 0x06000781 RID: 1921 RVA: 0x0000BBBB File Offset: 0x00009DBB
		private void #nk(object #Sb)
		{
			this.IsRibbonMinimized = !this.IsRibbonMinimized;
		}

		// Token: 0x06000782 RID: 1922 RVA: 0x00090FB0 File Offset: 0x0008F1B0
		private void #ok(object #Sb)
		{
			try
			{
				if (base.DialogService.#ABf())
				{
					this.DiagramsManager.#xf();
				}
			}
			catch (Exception #ob)
			{
				base.Services.ExceptionHandler.#3Ab(#ob);
			}
		}

		// Token: 0x06000783 RID: 1923 RVA: 0x0009100C File Offset: 0x0008F20C
		private void #pk(object #Sb)
		{
			try
			{
				if (base.DialogService.#ABf())
				{
					this.DiagramsManager.#Nc();
				}
			}
			catch (Exception #ob)
			{
				base.Services.ExceptionHandler.#3Ab(#ob);
			}
		}

		// Token: 0x040001E3 RID: 483
		private readonly IExtendedServices #a;

		// Token: 0x040001E4 RID: 484
		private readonly #Ln #b;

		// Token: 0x040001E5 RID: 485
		private bool #c;

		// Token: 0x040001E6 RID: 486
		private string #d;

		// Token: 0x040001E7 RID: 487
		[CompilerGenerated]
		private readonly #Vgb #e;

		// Token: 0x040001E8 RID: 488
		[CompilerGenerated]
		private readonly DelegateCommand #f;

		// Token: 0x040001E9 RID: 489
		[CompilerGenerated]
		private readonly DelegateCommand #g;

		// Token: 0x040001EA RID: 490
		[CompilerGenerated]
		private readonly DelegateCommand #h;

		// Token: 0x040001EB RID: 491
		[CompilerGenerated]
		private readonly DelegateCommand #i;

		// Token: 0x040001EC RID: 492
		[CompilerGenerated]
		private readonly DelegateCommand #j;

		// Token: 0x040001ED RID: 493
		[CompilerGenerated]
		private readonly DelegateCommand #k;

		// Token: 0x040001EE RID: 494
		[CompilerGenerated]
		private readonly DelegateCommand #l;

		// Token: 0x040001EF RID: 495
		[CompilerGenerated]
		private readonly DelegateCommand #m;

		// Token: 0x040001F0 RID: 496
		[CompilerGenerated]
		private readonly DelegateCommand #n;

		// Token: 0x040001F1 RID: 497
		[CompilerGenerated]
		private readonly DelegateCommand #o;

		// Token: 0x040001F2 RID: 498
		[CompilerGenerated]
		private readonly DelegateCommand #p;

		// Token: 0x040001F3 RID: 499
		[CompilerGenerated]
		private readonly #LI #q;

		// Token: 0x040001F4 RID: 500
		[CompilerGenerated]
		private readonly #YI<DefinitionType> #r;

		// Token: 0x040001F5 RID: 501
		[CompilerGenerated]
		private readonly #RI<SlendernessPanelType> #s;

		// Token: 0x040001F6 RID: 502
		[CompilerGenerated]
		private readonly #CD #t;

		// Token: 0x040001F7 RID: 503
		[CompilerGenerated]
		private readonly #Vx #u;

		// Token: 0x040001F8 RID: 504
		[CompilerGenerated]
		private readonly #vbb #v;

		// Token: 0x040001F9 RID: 505
		[CompilerGenerated]
		private readonly #BLb #w;

		// Token: 0x040001FA RID: 506
		[CompilerGenerated]
		private readonly #mAe #x;

		// Token: 0x040001FB RID: 507
		[CompilerGenerated]
		private readonly DelegateCommand #y;

		// Token: 0x040001FC RID: 508
		[CompilerGenerated]
		private readonly DelegateCommand #z;

		// Token: 0x020000E8 RID: 232
		[CompilerGenerated]
		private sealed class #Tbc
		{
			// Token: 0x06000785 RID: 1925 RVA: 0x0000BBD8 File Offset: 0x00009DD8
			internal void #QUb()
			{
				this.#a.Settings.#Mq(this.#b.Value);
			}

			// Token: 0x040001FD RID: 509
			public #qk #a;

			// Token: 0x040001FE RID: 510
			public SettingType? #b;
		}
	}
}
