using System;
using System.Runtime.CompilerServices;
using System.Windows;
using #0I;
using #5Z;
using #6s;
using #7hc;
using #BZ;
using #eU;
using #lH;
using #LQc;
using #n8;
using #npe;
using #oKe;
using #PI;
using #v1c;
using #vW;
using StructurePoint.CoreAssets.AppManager.Column.Core;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.Products.Column.Model;
using StructurePoint.Products.Column.Model.Entities;
using StructurePoint.Products.Column.Services.API;
using StructurePoint.Products.Column.ViewModels.API.Core;
using StructurePoint.Products.Column.ViewModels.Slenderness.Helpers;
using StructurePoint.Products.Column.Views.API.Slenderness;
using Telerik.Windows.Controls;

namespace #qr
{
	// Token: 0x02000155 RID: 341
	internal sealed class #ks : #TH, #q8<#N8>, #5I, #OI, IChangesInfo, #ct, #N8, ISlendernessOfDesignedColumn
	{
		// Token: 0x06000AC5 RID: 2757 RVA: 0x000991A8 File Offset: 0x000973A8
		public #ks(ICoreServices #0c, ModelAxis #sr, #8Sc #ls, #UV #ms, #oW #Yc, #AZ #ns, #wW #os, #nKe #ps, #ht #ur, #uW #qs, #at #rs, #iW #ss, #R2c #ts, Lazy<IDesignColumnPanelView> #Ee)
		{
			this.#w = #0c;
			this.#x = #sr;
			this.#a = #ls;
			this.#b = #ms;
			this.#c = #Yc;
			this.#d = #ns;
			this.#e = #os;
			this.#f = #ps;
			this.#g = #ur;
			this.#h = #qs;
			this.#i = #rs;
			this.#j = #ss;
			this.#k = #ts;
			this.#l = #Ee;
			this.#Xr();
			this.#y = new #X3();
			this.#z = new DelegateCommand(new Action<object>(this.#cs), new Predicate<object>(this.#bs));
		}

		// Token: 0x17000466 RID: 1126
		// (get) Token: 0x06000AC6 RID: 2758 RVA: 0x0000E180 File Offset: 0x0000C380
		// (set) Token: 0x06000AC7 RID: 2759 RVA: 0x0009925C File Offset: 0x0009745C
		public float Height
		{
			get
			{
				return this.#m;
			}
			set
			{
				#ks.#ZXb #ZXb = new #ks.#ZXb();
				#ZXb.#a = this;
				#ZXb.#b = value;
				base.#KH<float>(ref this.#m, #ZXb.#b, this.#d, new Action(#ZXb.#8Vb), #Phc.#3hc(107412672));
			}
		}

		// Token: 0x17000467 RID: 1127
		// (get) Token: 0x06000AC8 RID: 2760 RVA: 0x0000E18C File Offset: 0x0000C38C
		// (set) Token: 0x06000AC9 RID: 2761 RVA: 0x000992B8 File Offset: 0x000974B8
		public float Kbraced
		{
			get
			{
				return this.#n;
			}
			set
			{
				#ks.#yZb #yZb = new #ks.#yZb();
				#yZb.#a = this;
				#yZb.#b = value;
				base.#KH<float>(ref this.#n, #yZb.#b, this.#d, new Action(#yZb.#aWb), #Phc.#3hc(107412695));
			}
		}

		// Token: 0x17000468 RID: 1128
		// (get) Token: 0x06000ACA RID: 2762 RVA: 0x0000E198 File Offset: 0x0000C398
		// (set) Token: 0x06000ACB RID: 2763 RVA: 0x00099314 File Offset: 0x00097514
		public float Ksway
		{
			get
			{
				return this.#o;
			}
			set
			{
				#ks.#AZb #AZb = new #ks.#AZb();
				#AZb.#a = this;
				#AZb.#b = value;
				base.#KH<float>(ref this.#o, #AZb.#b, this.#d, new Action(#AZb.#bWb), #Phc.#3hc(107412650));
			}
		}

		// Token: 0x17000469 RID: 1129
		// (get) Token: 0x06000ACC RID: 2764 RVA: 0x0000E1A4 File Offset: 0x0000C3A4
		// (set) Token: 0x06000ACD RID: 2765 RVA: 0x00099370 File Offset: 0x00097570
		public bool IsBraced
		{
			get
			{
				return this.#p;
			}
			set
			{
				#ks.#CZb #CZb = new #ks.#CZb();
				#CZb.#a = this;
				#CZb.#b = value;
				base.#KH<bool>(ref this.#p, #CZb.#b, this.#d, new Action(#CZb.#dWb), #Phc.#3hc(107412641));
				this.#xTh();
			}
		}

		// Token: 0x1700046A RID: 1130
		// (get) Token: 0x06000ACE RID: 2766 RVA: 0x0000E1B0 File Offset: 0x0000C3B0
		// (set) Token: 0x06000ACF RID: 2767 RVA: 0x000993D4 File Offset: 0x000975D4
		public bool CheckSwayAtEndsOnly
		{
			get
			{
				return this.#q;
			}
			set
			{
				#ks.#EZb #EZb = new #ks.#EZb();
				#EZb.#a = this;
				#EZb.#b = value;
				bool #Zr = this.#q;
				base.#KH<bool>(ref this.#q, #EZb.#b, this.#d, new Action(#EZb.#eWb), #Phc.#3hc(107412660));
				this.#Yr(#Zr, this.CheckSwayAtEndsOnly);
			}
		}

		// Token: 0x1700046B RID: 1131
		// (get) Token: 0x06000AD0 RID: 2768 RVA: 0x0000E1BC File Offset: 0x0000C3BC
		// (set) Token: 0x06000AD1 RID: 2769 RVA: 0x00099444 File Offset: 0x00097644
		public Kmode Kmode
		{
			get
			{
				return this.#r;
			}
			set
			{
				#ks.#0Ub #0Ub = new #ks.#0Ub();
				#0Ub.#a = this;
				#0Ub.#b = value;
				base.#KH<Kmode>(ref this.#r, #0Ub.#b, this.#d, new Action(#0Ub.#gWb), #Phc.#3hc(107412631));
				this.#1r();
			}
		}

		// Token: 0x1700046C RID: 1132
		// (get) Token: 0x06000AD2 RID: 2770 RVA: 0x0000E1C8 File Offset: 0x0000C3C8
		// (set) Token: 0x06000AD3 RID: 2771 RVA: 0x000994A8 File Offset: 0x000976A8
		public float SumPc
		{
			get
			{
				return this.#s;
			}
			set
			{
				#ks.#HZb #HZb = new #ks.#HZb();
				#HZb.#a = this;
				#HZb.#b = value;
				base.#KH<float>(ref this.#s, #HZb.#b, this.#d, new Action(#HZb.#iWb), #Phc.#3hc(107412590));
			}
		}

		// Token: 0x1700046D RID: 1133
		// (get) Token: 0x06000AD4 RID: 2772 RVA: 0x0000E1D4 File Offset: 0x0000C3D4
		// (set) Token: 0x06000AD5 RID: 2773 RVA: 0x00099504 File Offset: 0x00097704
		public float SumPu
		{
			get
			{
				return this.#t;
			}
			set
			{
				#ks.#JZb #JZb = new #ks.#JZb();
				#JZb.#a = this;
				#JZb.#b = value;
				base.#KH<float>(ref this.#t, #JZb.#b, this.#d, new Action(#JZb.#jWb), #Phc.#3hc(107412581));
			}
		}

		// Token: 0x1700046E RID: 1134
		// (get) Token: 0x06000AD6 RID: 2774 RVA: 0x0000E1E0 File Offset: 0x0000C3E0
		// (set) Token: 0x06000AD7 RID: 2775 RVA: 0x0000E1EC File Offset: 0x0000C3EC
		public bool SecondOrderEffectsCheckboxVisible
		{
			get
			{
				return this.#u;
			}
			private set
			{
				this.SetProperty<bool>(ref this.#u, value, #Phc.#3hc(107412604));
			}
		}

		// Token: 0x1700046F RID: 1135
		// (get) Token: 0x06000AD8 RID: 2776 RVA: 0x0000E212 File Offset: 0x0000C412
		// (set) Token: 0x06000AD9 RID: 2777 RVA: 0x00099560 File Offset: 0x00097760
		public EndConditionType EndCondition
		{
			get
			{
				return this.#v;
			}
			set
			{
				#ks.#uUb #uUb = new #ks.#uUb();
				#uUb.#a = this;
				#uUb.#b = value;
				EndConditionType endCondition = this.EndCondition;
				base.#KH<EndConditionType>(ref this.#v, #uUb.#b, this.#d, new Action(#uUb.#lWb), #Phc.#3hc(107412527));
				this.#2r(endCondition, #uUb.#b);
			}
		}

		// Token: 0x17000470 RID: 1136
		// (get) Token: 0x06000ADA RID: 2778 RVA: 0x0000E21E File Offset: 0x0000C41E
		public ModelAxis ModelAxis { get; }

		// Token: 0x17000471 RID: 1137
		// (get) Token: 0x06000ADB RID: 2779 RVA: 0x0000E22A File Offset: 0x0000C42A
		public #X3 SlendernessOfDesignedColumn { get; }

		// Token: 0x17000472 RID: 1138
		// (get) Token: 0x06000ADC RID: 2780 RVA: 0x0000E236 File Offset: 0x0000C436
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors || this.SlendernessOfDesignedColumn.HasErrors;
			}
		}

		// Token: 0x17000473 RID: 1139
		// (get) Token: 0x06000ADD RID: 2781 RVA: 0x0000E259 File Offset: 0x0000C459
		public DelegateCommand CopyValuesToMirrorAxis { get; }

		// Token: 0x17000474 RID: 1140
		// (get) Token: 0x06000ADE RID: 2782 RVA: 0x0000E265 File Offset: 0x0000C465
		protected bool IsAxisX
		{
			get
			{
				return this.ModelAxis == ModelAxis.XAxisPanel;
			}
		}

		// Token: 0x06000ADF RID: 2783 RVA: 0x000995D0 File Offset: 0x000977D0
		public bool GetHasChanges()
		{
			ColumnModel columnModel = this.#w.Project.Model;
			#X3 #Hai = (this.ModelAxis == ModelAxis.XAxisPanel) ? columnModel.DesignedColumnX : columnModel.DesignedColumnY;
			return !#Oai.#uC(this, #Hai);
		}

		// Token: 0x06000AE0 RID: 2784 RVA: 0x0009961C File Offset: 0x0009781C
		public void CopyFrom(#N8 source)
		{
			this.#r = source.Kmode;
			base.RaisePropertyChanged(#Phc.#3hc(107412631));
			this.#q = source.CheckSwayAtEndsOnly;
			this.#m = source.Height;
			this.#p = source.IsBraced;
			this.#r = source.Kmode;
			this.#n = source.Kbraced;
			this.#o = source.Ksway;
			this.#s = source.SumPc;
			this.#t = source.SumPu;
			this.#v = source.EndCondition;
			this.RefreshAllProperties();
			base.#PH<ISlendernessOfDesignedColumn>(this.#d, null);
			this.SlendernessOfDesignedColumn.CopyFrom(source);
		}

		// Token: 0x06000AE1 RID: 2785 RVA: 0x0000E278 File Offset: 0x0000C478
		public void #or()
		{
			base.#PH<ISlendernessOfDesignedColumn, IDesignColumnPanelView>(this.#d, this.#l, this.#k);
		}

		// Token: 0x06000AE2 RID: 2786 RVA: 0x000996F0 File Offset: 0x000978F0
		public override void UpdateFromModel(ColumnModel model)
		{
			#X3 source = (this.ModelAxis == ModelAxis.XAxisPanel) ? model.DesignedColumnX : model.DesignedColumnY;
			this.CopyFrom(source);
			this.SecondOrderEffectsCheckboxVisible = this.#js(model);
		}

		// Token: 0x06000AE3 RID: 2787 RVA: 0x00099734 File Offset: 0x00097934
		public override void UpdateModel(ColumnModel model)
		{
			#X3 #X = (this.ModelAxis == ModelAxis.XAxisPanel) ? model.DesignedColumnX : model.DesignedColumnY;
			#X.CopyFrom(this);
			#X.CheckSwayAtEndsOnly = this.CheckSwayAtEndsOnly;
			model.SlendernessInputFlag |= ((this.ModelAxis == ModelAxis.XAxisPanel) ? #ppe.#b : #ppe.#c);
		}

		// Token: 0x06000AE4 RID: 2788 RVA: 0x0000E29F File Offset: 0x0000C49F
		private void #Xr()
		{
			if (this.IsAxisX)
			{
				this.#e.DesignColumnXAxis = this;
				return;
			}
			this.#e.DesignColumnYAxis = this;
		}

		// Token: 0x06000AE5 RID: 2789 RVA: 0x00099790 File Offset: 0x00097990
		private void #Yr(bool #Zr, bool #0r)
		{
			if (#Zr || !#0r || !this.#c.Model.Options.#j3())
			{
				return;
			}
			this.#gs();
		}

		// Token: 0x06000AE6 RID: 2790 RVA: 0x0000E2CE File Offset: 0x0000C4CE
		private void #1r()
		{
			this.#b.#FV();
		}

		// Token: 0x06000AE7 RID: 2791 RVA: 0x000997D4 File Offset: 0x000979D4
		private void #xTh()
		{
			#at #8r = this.#i;
			#9s #9r = this.IsAxisX ? this.#h.BeamsXAxis : this.#h.BeamsYAxis;
			this.#as(#8r, #9r);
		}

		// Token: 0x06000AE8 RID: 2792 RVA: 0x00099820 File Offset: 0x00097A20
		private void #2r(EndConditionType #3r, EndConditionType #4r)
		{
			if (!#Bpe.#xpe(#3r))
			{
				this.#5r(#3r);
			}
			#at #8r = this.#i;
			#9s #9r = this.IsAxisX ? this.#h.BeamsXAxis : this.#h.BeamsYAxis;
			this.#7r(#8r, #9r);
			this.#as(#8r, #9r);
			this.#b.#FV();
		}

		// Token: 0x06000AE9 RID: 2793 RVA: 0x0009988C File Offset: 0x00097A8C
		private void #5r(EndConditionType #6r)
		{
			ColumnModel columnModel = this.#c.Model;
			#4Z #4Z = columnModel.EndConditionCache;
			#W3 #W = this.IsAxisX ? #4Z.BeamX : #4Z.BeamY;
			#9s #9s = this.IsAxisX ? this.#h.BeamsXAxis : this.#h.BeamsYAxis;
			StructurePoint.Products.Column.Model.Entities.SlendernessOfColumn slendernessOfColumn = #4Z.ColumnAbove;
			StructurePoint.Products.Column.Model.Entities.SlendernessOfColumn slendernessOfColumn2 = #4Z.ColumnBelow;
			#at #at = this.#i;
			#W.AboveLeft.CopyFrom(#9s.AboveLeft);
			#W.AboveRight.CopyFrom(#9s.AboveRight);
			slendernessOfColumn.CopyFrom(this.#i.SlendernessOfColumnAbove);
			if (#Bpe.#Ape(#6r))
			{
				return;
			}
			#W.BelowLeft.CopyFrom(#9s.BelowLeft);
			#W.BelowRight.CopyFrom(#9s.BelowRight);
			slendernessOfColumn2.CopyFrom(#at.SlendernessOfColumnBelow);
		}

		// Token: 0x06000AEA RID: 2794 RVA: 0x00099988 File Offset: 0x00097B88
		private void #7r(#at #8r, #9s #9r)
		{
			#4Z #4Z = this.#c.Model.EndConditionCache;
			#W3 source = this.IsAxisX ? #4Z.BeamX : #4Z.BeamY;
			#9r.CopyFrom(source);
			#8r.SlendernessOfColumnAbove.CopyFrom(#4Z.ColumnAbove);
			#8r.SlendernessOfColumnBelow.CopyFrom(#4Z.ColumnBelow);
		}

		// Token: 0x06000AEB RID: 2795 RVA: 0x000999F4 File Offset: 0x00097BF4
		private void #as(#at #8r, #9s #9r)
		{
			EndConditionType endCondition = this.#e.DesignColumnXAxis.EndCondition;
			EndConditionType endCondition2 = this.#e.DesignColumnYAxis.EndCondition;
			#yTh #zTh = this.IsBraced ? #yTh.#a : #yTh.#b;
			#9r.#Gr(#zTh, this.EndCondition);
			#8r.#Gr(endCondition, endCondition2);
		}

		// Token: 0x06000AEC RID: 2796 RVA: 0x0000E2E3 File Offset: 0x0000C4E3
		private bool #bs(object #Sb)
		{
			if (this.ModelAxis != ModelAxis.XAxisPanel)
			{
				return this.#g.#Pq();
			}
			return this.#g.#Qq();
		}

		// Token: 0x06000AED RID: 2797 RVA: 0x00099A54 File Offset: 0x00097C54
		private void #cs(object #Sb)
		{
			if (this.HasErrors)
			{
				this.#ds();
				return;
			}
			if (#Sb is ModelAxis)
			{
				ModelAxis #fs = (ModelAxis)#Sb;
				#N8 #N = this.#es(#fs);
				#N.CopyFrom(this);
				this.#b.#FV();
			}
		}

		// Token: 0x06000AEE RID: 2798 RVA: 0x00099AA8 File Offset: 0x00097CA8
		private void #ds()
		{
			Window #jA = this.#j.#6();
			this.#a.#1Sc(#jA, ColumnGlobalInfo.DefaultMessageBoxTitle, Strings.StringInvalidDataSpecified.#z2d() + Environment.NewLine.#W2d(2) + Strings.StringPleaseFixValidationErrorsBeforeCopyingValues, MessageBoxButton.OK, MessageBoxImage.Hand);
		}

		// Token: 0x06000AEF RID: 2799 RVA: 0x0000E310 File Offset: 0x0000C510
		private #N8 #es(ModelAxis #fs)
		{
			if (#fs != ModelAxis.XAxisPanel)
			{
				return this.#e.DesignColumnXAxis;
			}
			return this.#e.DesignColumnYAxis;
		}

		// Token: 0x06000AF0 RID: 2800 RVA: 0x00099B04 File Offset: 0x00097D04
		private void #gs()
		{
			string stringNotConsideringSecondOrderEffectsAlongLengthOfComparisonViolatesProvision = Strings.StringNotConsideringSecondOrderEffectsAlongLengthOfComparisonViolatesProvision;
			DesignCodes designCodes = this.#c.Model.Options.Code;
			string text = this.#hs(designCodes);
			string text2 = this.#f.AvailableDesignCodes[designCodes];
			string # = stringNotConsideringSecondOrderEffectsAlongLengthOfComparisonViolatesProvision.#D2d(new object[]
			{
				text,
				text2
			});
			Window #jA = this.#j.#6();
			this.#a.#1Sc(#jA, ColumnGlobalInfo.DefaultMessageBoxTitle, #, MessageBoxButton.OK, MessageBoxImage.Exclamation);
		}

		// Token: 0x06000AF1 RID: 2801 RVA: 0x00099B94 File Offset: 0x00097D94
		private string #hs(DesignCodes #is)
		{
			switch (#is)
			{
			case DesignCodes.ACI08:
				return #Phc.#3hc(107412542);
			case DesignCodes.ACI11:
				return #Phc.#3hc(107412542);
			case DesignCodes.ACI14:
			case DesignCodes.ACI19:
				return #Phc.#3hc(107412529);
			}
			return string.Empty;
		}

		// Token: 0x06000AF2 RID: 2802 RVA: 0x00099BF4 File Offset: 0x00097DF4
		private bool #js(ColumnModel #Od)
		{
			DesignCodes designCodes = #Od.Options.Code;
			return designCodes == DesignCodes.ACI08 || designCodes == DesignCodes.ACI11 || designCodes == DesignCodes.ACI14 || designCodes == DesignCodes.ACI19;
		}

		// Token: 0x06000AF3 RID: 2803 RVA: 0x0000A950 File Offset: 0x00008B50
		void #5I.#Lr()
		{
			base.ClearErrors();
		}

		// Token: 0x06000AF4 RID: 2804 RVA: 0x0000A960 File Offset: 0x00008B60
		void #5I.#Or(string #em)
		{
			base.RemoveError(#em);
		}

		// Token: 0x040003E3 RID: 995
		private readonly #8Sc #a;

		// Token: 0x040003E4 RID: 996
		private readonly #UV #b;

		// Token: 0x040003E5 RID: 997
		private readonly #oW #c;

		// Token: 0x040003E6 RID: 998
		private readonly #AZ #d;

		// Token: 0x040003E7 RID: 999
		private readonly #wW #e;

		// Token: 0x040003E8 RID: 1000
		private readonly #nKe #f;

		// Token: 0x040003E9 RID: 1001
		private readonly #ht #g;

		// Token: 0x040003EA RID: 1002
		private readonly #uW #h;

		// Token: 0x040003EB RID: 1003
		private readonly #at #i;

		// Token: 0x040003EC RID: 1004
		private readonly #iW #j;

		// Token: 0x040003ED RID: 1005
		private readonly #R2c #k;

		// Token: 0x040003EE RID: 1006
		private readonly Lazy<IDesignColumnPanelView> #l;

		// Token: 0x040003EF RID: 1007
		private float #m;

		// Token: 0x040003F0 RID: 1008
		private float #n;

		// Token: 0x040003F1 RID: 1009
		private float #o;

		// Token: 0x040003F2 RID: 1010
		private bool #p;

		// Token: 0x040003F3 RID: 1011
		private bool #q;

		// Token: 0x040003F4 RID: 1012
		private Kmode #r;

		// Token: 0x040003F5 RID: 1013
		private float #s;

		// Token: 0x040003F6 RID: 1014
		private float #t;

		// Token: 0x040003F7 RID: 1015
		private bool #u;

		// Token: 0x040003F8 RID: 1016
		private EndConditionType #v;

		// Token: 0x040003F9 RID: 1017
		private readonly ICoreServices #w;

		// Token: 0x040003FA RID: 1018
		[CompilerGenerated]
		private readonly ModelAxis #x;

		// Token: 0x040003FB RID: 1019
		[CompilerGenerated]
		private readonly #X3 #y;

		// Token: 0x040003FC RID: 1020
		[CompilerGenerated]
		private readonly DelegateCommand #z;

		// Token: 0x02000156 RID: 342
		[CompilerGenerated]
		private sealed class #ZXb
		{
			// Token: 0x06000AF6 RID: 2806 RVA: 0x0000E338 File Offset: 0x0000C538
			internal void #8Vb()
			{
				this.#a.SlendernessOfDesignedColumn.Height = this.#b;
			}

			// Token: 0x040003FD RID: 1021
			public #ks #a;

			// Token: 0x040003FE RID: 1022
			public float #b;
		}

		// Token: 0x02000157 RID: 343
		[CompilerGenerated]
		private sealed class #yZb
		{
			// Token: 0x06000AF8 RID: 2808 RVA: 0x0000E35C File Offset: 0x0000C55C
			internal void #aWb()
			{
				this.#a.SlendernessOfDesignedColumn.Kbraced = this.#b;
			}

			// Token: 0x040003FF RID: 1023
			public #ks #a;

			// Token: 0x04000400 RID: 1024
			public float #b;
		}

		// Token: 0x02000158 RID: 344
		[CompilerGenerated]
		private sealed class #AZb
		{
			// Token: 0x06000AFA RID: 2810 RVA: 0x0000E380 File Offset: 0x0000C580
			internal void #bWb()
			{
				this.#a.SlendernessOfDesignedColumn.Ksway = this.#b;
			}

			// Token: 0x04000401 RID: 1025
			public #ks #a;

			// Token: 0x04000402 RID: 1026
			public float #b;
		}

		// Token: 0x02000159 RID: 345
		[CompilerGenerated]
		private sealed class #CZb
		{
			// Token: 0x06000AFC RID: 2812 RVA: 0x0000E3A4 File Offset: 0x0000C5A4
			internal void #dWb()
			{
				this.#a.SlendernessOfDesignedColumn.IsBraced = this.#b;
			}

			// Token: 0x04000403 RID: 1027
			public #ks #a;

			// Token: 0x04000404 RID: 1028
			public bool #b;
		}

		// Token: 0x0200015A RID: 346
		[CompilerGenerated]
		private sealed class #EZb
		{
			// Token: 0x06000AFE RID: 2814 RVA: 0x0000E3C8 File Offset: 0x0000C5C8
			internal void #eWb()
			{
				this.#a.SlendernessOfDesignedColumn.CheckSwayAtEndsOnly = this.#b;
			}

			// Token: 0x04000405 RID: 1029
			public #ks #a;

			// Token: 0x04000406 RID: 1030
			public bool #b;
		}

		// Token: 0x0200015B RID: 347
		[CompilerGenerated]
		private sealed class #0Ub
		{
			// Token: 0x06000B00 RID: 2816 RVA: 0x0000E3EC File Offset: 0x0000C5EC
			internal void #gWb()
			{
				this.#a.SlendernessOfDesignedColumn.Kmode = this.#b;
			}

			// Token: 0x04000407 RID: 1031
			public #ks #a;

			// Token: 0x04000408 RID: 1032
			public Kmode #b;
		}

		// Token: 0x0200015C RID: 348
		[CompilerGenerated]
		private sealed class #HZb
		{
			// Token: 0x06000B02 RID: 2818 RVA: 0x0000E410 File Offset: 0x0000C610
			internal void #iWb()
			{
				this.#a.SlendernessOfDesignedColumn.SumPc = this.#b;
			}

			// Token: 0x04000409 RID: 1033
			public #ks #a;

			// Token: 0x0400040A RID: 1034
			public float #b;
		}

		// Token: 0x0200015D RID: 349
		[CompilerGenerated]
		private sealed class #JZb
		{
			// Token: 0x06000B04 RID: 2820 RVA: 0x0000E434 File Offset: 0x0000C634
			internal void #jWb()
			{
				this.#a.SlendernessOfDesignedColumn.SumPu = this.#b;
			}

			// Token: 0x0400040B RID: 1035
			public #ks #a;

			// Token: 0x0400040C RID: 1036
			public float #b;
		}

		// Token: 0x0200015E RID: 350
		[CompilerGenerated]
		private sealed class #uUb
		{
			// Token: 0x06000B06 RID: 2822 RVA: 0x0000E458 File Offset: 0x0000C658
			internal void #lWb()
			{
				this.#a.SlendernessOfDesignedColumn.EndCondition = this.#b;
			}

			// Token: 0x0400040D RID: 1037
			public #ks #a;

			// Token: 0x0400040E RID: 1038
			public EndConditionType #b;
		}
	}
}
