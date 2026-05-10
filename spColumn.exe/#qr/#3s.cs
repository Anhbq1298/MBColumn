using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using #0I;
using #5Z;
using #6s;
using #7hc;
using #eU;
using #lH;
using #LQc;
using #n8;
using #npe;
using #PI;
using #vW;
using StructurePoint.CoreAssets.AppManager.Column.Core;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.Products.Column.Model;
using StructurePoint.Products.Column.Resources.Images;
using StructurePoint.Products.Column.Services.API;
using StructurePoint.Products.Column.ViewModels.API.Core;
using StructurePoint.Products.Column.ViewModels.Slenderness.Helpers;
using StructurePoint.Products.Column.ViewModels.Slenderness.Modules;
using Telerik.Windows.Controls;

namespace #qr
{
	// Token: 0x0200016F RID: 367
	internal sealed class #3s : #TH, #q8<#L8>, #5I, #9s, #OI, IChangesInfo
	{
		// Token: 0x06000B90 RID: 2960 RVA: 0x0009A328 File Offset: 0x00098528
		public #3s(ICoreServices #0c, ModelAxis #sr, #8Sc #ls, #uW #qs, #ht #ur, #5s #4s, #iW #ss)
		{
			this.#i = #0c;
			this.#j = #sr;
			this.#e = #ls;
			this.#f = #qs;
			this.#k = #ur;
			this.#g = #4s;
			this.#h = #ss;
			this.#Ks();
			this.#l = new DelegateCommand(new Action<object>(this.#Os), new Predicate<object>(this.#Ns));
			this.#m = new DelegateCommand(new Action<object>(this.#Qs), new Predicate<object>(this.#Ps));
			this.#n = new DelegateCommand(new Action<object>(this.#Ss), new Predicate<object>(this.#Rs));
			this.#o = new DelegateCommand(new Action<object>(this.#Us), new Predicate<object>(this.#Ts));
		}

		// Token: 0x170004AD RID: 1197
		// (get) Token: 0x06000B91 RID: 2961 RVA: 0x0000EC5E File Offset: 0x0000CE5E
		public ModelAxis ModelAxis { get; }

		// Token: 0x170004AE RID: 1198
		// (get) Token: 0x06000B92 RID: 2962 RVA: 0x0000EC6A File Offset: 0x0000CE6A
		public #ht SlendernessWindow { get; }

		// Token: 0x170004AF RID: 1199
		// (get) Token: 0x06000B93 RID: 2963 RVA: 0x0000EC76 File Offset: 0x0000CE76
		// (set) Token: 0x06000B94 RID: 2964 RVA: 0x0000EC82 File Offset: 0x0000CE82
		public TemporaryBeam AboveLeft
		{
			get
			{
				return this.#a;
			}
			set
			{
				this.SetProperty<TemporaryBeam>(ref this.#a, value, #Phc.#3hc(107412750));
			}
		}

		// Token: 0x170004B0 RID: 1200
		// (get) Token: 0x06000B95 RID: 2965 RVA: 0x0000ECA8 File Offset: 0x0000CEA8
		// (set) Token: 0x06000B96 RID: 2966 RVA: 0x0000ECB4 File Offset: 0x0000CEB4
		public TemporaryBeam AboveRight
		{
			get
			{
				return this.#b;
			}
			set
			{
				this.SetProperty<TemporaryBeam>(ref this.#b, value, #Phc.#3hc(107412737));
			}
		}

		// Token: 0x170004B1 RID: 1201
		// (get) Token: 0x06000B97 RID: 2967 RVA: 0x0000ECDA File Offset: 0x0000CEDA
		// (set) Token: 0x06000B98 RID: 2968 RVA: 0x0000ECE6 File Offset: 0x0000CEE6
		public TemporaryBeam BelowLeft
		{
			get
			{
				return this.#c;
			}
			set
			{
				this.SetProperty<TemporaryBeam>(ref this.#c, value, #Phc.#3hc(107412752));
			}
		}

		// Token: 0x170004B2 RID: 1202
		// (get) Token: 0x06000B99 RID: 2969 RVA: 0x0000ED0C File Offset: 0x0000CF0C
		// (set) Token: 0x06000B9A RID: 2970 RVA: 0x0000ED18 File Offset: 0x0000CF18
		public TemporaryBeam BelowRight
		{
			get
			{
				return this.#d;
			}
			set
			{
				this.SetProperty<TemporaryBeam>(ref this.#d, value, #Phc.#3hc(107412195));
			}
		}

		// Token: 0x170004B3 RID: 1203
		// (get) Token: 0x06000B9B RID: 2971 RVA: 0x0009A404 File Offset: 0x00098604
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors || this.AboveLeft.HasErrors || this.AboveRight.HasErrors || this.BelowLeft.HasErrors || this.BelowRight.HasErrors;
			}
		}

		// Token: 0x170004B4 RID: 1204
		// (get) Token: 0x06000B9C RID: 2972 RVA: 0x0000ED3E File Offset: 0x0000CF3E
		public DelegateCommand CopyToMirroredAxisCommand { get; }

		// Token: 0x170004B5 RID: 1205
		// (get) Token: 0x06000B9D RID: 2973 RVA: 0x0000ED4A File Offset: 0x0000CF4A
		public DelegateCommand CopyToAllCommand { get; }

		// Token: 0x170004B6 RID: 1206
		// (get) Token: 0x06000B9E RID: 2974 RVA: 0x0000ED56 File Offset: 0x0000CF56
		public DelegateCommand CopyToNextCommand { get; }

		// Token: 0x170004B7 RID: 1207
		// (get) Token: 0x06000B9F RID: 2975 RVA: 0x0000ED62 File Offset: 0x0000CF62
		public DelegateCommand CopyToPreviousCommand { get; }

		// Token: 0x170004B8 RID: 1208
		// (get) Token: 0x06000BA0 RID: 2976 RVA: 0x0000ED6E File Offset: 0x0000CF6E
		public List<#o8> OrderedBeams
		{
			get
			{
				return this.#Ls();
			}
		}

		// Token: 0x06000BA1 RID: 2977 RVA: 0x0009A45C File Offset: 0x0009865C
		public bool GetHasChanges()
		{
			ColumnModel columnModel = this.#i.Project.Model;
			#W3 #W = (this.ModelAxis == ModelAxis.XAxisPanel) ? columnModel.BeamX : columnModel.BeamY;
			return !#Oai.#uC(this.AboveLeft, #W.AboveLeft) || !#Oai.#uC(this.BelowLeft, #W.BelowLeft) || !#Oai.#uC(this.AboveRight, #W.AboveRight) || !#Oai.#uC(this.BelowRight, this.BelowRight);
		}

		// Token: 0x06000BA2 RID: 2978 RVA: 0x0009A4FC File Offset: 0x000986FC
		public void CopyFrom(#L8 source)
		{
			this.AboveLeft.CopyFrom(source.AboveLeft);
			this.AboveRight.CopyFrom(source.AboveRight);
			this.BelowLeft.CopyFrom(source.BelowLeft);
			this.BelowRight.CopyFrom(source.BelowRight);
		}

		// Token: 0x06000BA3 RID: 2979 RVA: 0x0009A55C File Offset: 0x0009875C
		public void #Gr(#yTh #zTh, EndConditionType #6r)
		{
			if (#zTh == #yTh.#b)
			{
				switch (#6r)
				{
				case EndConditionType.Normal:
					break;
				case EndConditionType.NormalHinged:
					this.BelowLeft.BeamType = BeamType.None;
					this.BelowRight.BeamType = BeamType.None;
					return;
				case EndConditionType.NormalFixed:
					this.BelowLeft.BeamType = BeamType.Rigid;
					this.BelowRight.BeamType = BeamType.Rigid;
					return;
				case EndConditionType.FixedHinged:
					this.AboveLeft.BeamType = BeamType.Rigid;
					this.AboveRight.BeamType = BeamType.Rigid;
					this.BelowLeft.BeamType = BeamType.None;
					this.BelowRight.BeamType = BeamType.None;
					return;
				case EndConditionType.Fixed:
					this.AboveLeft.BeamType = BeamType.Rigid;
					this.AboveRight.BeamType = BeamType.Rigid;
					this.BelowLeft.BeamType = BeamType.Rigid;
					this.BelowRight.BeamType = BeamType.Rigid;
					return;
				case EndConditionType.FreeFixed:
					this.AboveLeft.BeamType = BeamType.None;
					this.AboveRight.BeamType = BeamType.None;
					this.BelowLeft.BeamType = BeamType.Rigid;
					this.BelowRight.BeamType = BeamType.Rigid;
					return;
				default:
					return;
				}
			}
			else
			{
				switch (#6r)
				{
				case EndConditionType.Normal:
					break;
				case EndConditionType.NormalHinged:
					this.BelowLeft.BeamType = BeamType.None;
					this.BelowRight.BeamType = BeamType.None;
					return;
				case EndConditionType.NormalFixed:
					this.BelowLeft.BeamType = BeamType.Rigid;
					this.BelowRight.BeamType = BeamType.Rigid;
					return;
				case EndConditionType.FixedHinged:
					this.AboveLeft.BeamType = BeamType.None;
					this.AboveRight.BeamType = BeamType.None;
					this.BelowLeft.BeamType = BeamType.None;
					this.BelowRight.BeamType = BeamType.None;
					return;
				case EndConditionType.Fixed:
					this.AboveLeft.BeamType = BeamType.None;
					this.AboveRight.BeamType = BeamType.None;
					this.BelowLeft.BeamType = BeamType.Rigid;
					this.BelowRight.BeamType = BeamType.Rigid;
					return;
				case EndConditionType.FreeFixed:
					this.AboveLeft.BeamType = BeamType.Rigid;
					this.AboveRight.BeamType = BeamType.Rigid;
					this.BelowLeft.BeamType = BeamType.Rigid;
					this.BelowRight.BeamType = BeamType.Rigid;
					break;
				default:
					return;
				}
			}
		}

		// Token: 0x06000BA4 RID: 2980 RVA: 0x0000ED7E File Offset: 0x0000CF7E
		public void #vh()
		{
			this.CopyToMirroredAxisCommand.InvalidateCanExecute();
			this.CopyToAllCommand.InvalidateCanExecute();
			this.CopyToNextCommand.InvalidateCanExecute();
			this.CopyToPreviousCommand.InvalidateCanExecute();
		}

		// Token: 0x06000BA5 RID: 2981 RVA: 0x0009A758 File Offset: 0x00098958
		public override void UpdateFromModel(ColumnModel model)
		{
			#W3 source = (this.ModelAxis == ModelAxis.XAxisPanel) ? model.BeamX : model.BeamY;
			this.#Ms();
			this.CopyFrom(source);
			this.#vh();
		}

		// Token: 0x06000BA6 RID: 2982 RVA: 0x0009A79C File Offset: 0x0009899C
		public override void UpdateModel(ColumnModel model)
		{
			#W3 #W = (this.ModelAxis == ModelAxis.XAxisPanel) ? model.BeamX : model.BeamY;
			#W.AboveLeft.CopyFrom(this.AboveLeft);
			#W.AboveRight.CopyFrom(this.AboveRight);
			#W.BelowLeft.CopyFrom(this.BelowLeft);
			#W.BelowRight.CopyFrom(this.BelowRight);
			model.SlendernessInputFlag |= ((this.ModelAxis == ModelAxis.XAxisPanel) ? #ppe.#e : #ppe.#f);
		}

		// Token: 0x06000BA7 RID: 2983 RVA: 0x0000EDB8 File Offset: 0x0000CFB8
		public void #or()
		{
			this.BelowRight.ValidateBeamOnPanelActivated();
			this.BelowLeft.ValidateBeamOnPanelActivated();
			this.AboveRight.ValidateBeamOnPanelActivated();
			this.AboveLeft.ValidateBeamOnPanelActivated();
		}

		// Token: 0x06000BA8 RID: 2984 RVA: 0x0000EDF2 File Offset: 0x0000CFF2
		private void #Ks()
		{
			if (this.ModelAxis == ModelAxis.XAxisPanel)
			{
				this.#f.BeamsXAxis = this;
				return;
			}
			this.#f.BeamsYAxis = this;
		}

		// Token: 0x06000BA9 RID: 2985 RVA: 0x0009A83C File Offset: 0x00098A3C
		private List<#o8> #Ls()
		{
			return new List<#o8>
			{
				this.AboveLeft,
				this.AboveRight,
				this.BelowRight,
				this.BelowLeft
			};
		}

		// Token: 0x06000BAA RID: 2986 RVA: 0x0009A88C File Offset: 0x00098A8C
		private void #Ms()
		{
			this.AboveLeft = this.#g.#ul(new BeamFormProperties
			{
				NextButtonImage = ColumnImages.Right_16X16,
				PreviousButtonImage = ColumnImages.Down_16X16,
				CopyButtonsAlignment = HorizontalAlignment.Left,
				CopyButtonsOrder = CopyButtonsOrder.PreviousFirst,
				CopyToAllCommand = this.CopyToAllCommand,
				CopyToNextCommand = this.CopyToNextCommand,
				CopyToPreviousCommand = this.CopyToPreviousCommand
			});
			this.AboveRight = this.#g.#ul(new BeamFormProperties
			{
				NextButtonImage = ColumnImages.Down_16X16,
				PreviousButtonImage = ColumnImages.Left_16X16,
				CopyButtonsAlignment = HorizontalAlignment.Right,
				CopyButtonsOrder = CopyButtonsOrder.NextFirst,
				CopyToAllCommand = this.CopyToAllCommand,
				CopyToNextCommand = this.CopyToNextCommand,
				CopyToPreviousCommand = this.CopyToPreviousCommand
			});
			this.BelowLeft = this.#g.#ul(new BeamFormProperties
			{
				NextButtonImage = ColumnImages.Top_16X16,
				PreviousButtonImage = ColumnImages.Right_16X16,
				CopyButtonsAlignment = HorizontalAlignment.Left,
				CopyButtonsOrder = CopyButtonsOrder.NextFirst,
				CopyToAllCommand = this.CopyToAllCommand,
				CopyToNextCommand = this.CopyToNextCommand,
				CopyToPreviousCommand = this.CopyToPreviousCommand
			});
			this.BelowRight = this.#g.#ul(new BeamFormProperties
			{
				NextButtonImage = ColumnImages.Left_16X16,
				PreviousButtonImage = ColumnImages.Top_16X16,
				CopyButtonsAlignment = HorizontalAlignment.Right,
				CopyButtonsOrder = CopyButtonsOrder.PreviousFirst,
				CopyToAllCommand = this.CopyToAllCommand,
				CopyToNextCommand = this.CopyToNextCommand,
				CopyToPreviousCommand = this.CopyToPreviousCommand
			});
		}

		// Token: 0x06000BAB RID: 2987 RVA: 0x0009AA30 File Offset: 0x00098C30
		private bool #Ns(object #Sb)
		{
			bool flag = (this.ModelAxis == ModelAxis.XAxisPanel) ? this.SlendernessWindow.#Oq() : this.SlendernessWindow.#Nq();
			return flag && this.SlendernessWindow.#Sq();
		}

		// Token: 0x06000BAC RID: 2988 RVA: 0x0009AA7C File Offset: 0x00098C7C
		private void #Os(object #Sb)
		{
			if (this.HasErrors)
			{
				this.#ds();
				return;
			}
			#9s #9s = this.#Vs(this);
			#9s.AboveLeft.CopyFrom(this.AboveLeft);
			#9s.AboveRight.CopyFrom(this.AboveRight);
			#9s.BelowLeft.CopyFrom(this.BelowLeft);
			#9s.BelowRight.CopyFrom(this.BelowRight);
		}

		// Token: 0x06000BAD RID: 2989 RVA: 0x0009AAF0 File Offset: 0x00098CF0
		private bool #Ps(object #Sb)
		{
			TemporaryBeam temporaryBeam = #Sb as TemporaryBeam;
			if (temporaryBeam != null)
			{
				bool flag = temporaryBeam == this.AboveLeft || temporaryBeam == this.AboveRight;
				bool flag2 = flag && this.#1s();
				return !flag2;
			}
			return true;
		}

		// Token: 0x06000BAE RID: 2990 RVA: 0x0009AB3C File Offset: 0x00098D3C
		private void #Qs(object #Sb)
		{
			TemporaryBeam temporaryBeam = #Sb as TemporaryBeam;
			TemporaryBeam temporaryBeam2;
			if (2 != 0)
			{
				temporaryBeam2 = temporaryBeam;
			}
			if (temporaryBeam2 != null && temporaryBeam2.IsValid)
			{
				IEnumerable<#o8> enumerable = this.#Xs(temporaryBeam2);
				foreach (#o8 #o in enumerable)
				{
					#o.CopyFrom(temporaryBeam2);
				}
				return;
			}
			this.#ds();
		}

		// Token: 0x06000BAF RID: 2991 RVA: 0x0009ABB4 File Offset: 0x00098DB4
		private bool #Rs(object #Sb)
		{
			TemporaryBeam temporaryBeam = #Sb as TemporaryBeam;
			if (temporaryBeam != null)
			{
				bool flag = temporaryBeam == this.AboveRight;
				bool flag2 = flag && this.#1s();
				return !flag2;
			}
			return true;
		}

		// Token: 0x06000BB0 RID: 2992 RVA: 0x0009ABF4 File Offset: 0x00098DF4
		private void #Ss(object #Sb)
		{
			TemporaryBeam temporaryBeam = #Sb as TemporaryBeam;
			if (temporaryBeam != null && temporaryBeam.IsValid)
			{
				#o8 #o = this.#Zs(temporaryBeam);
				#o.CopyFrom(temporaryBeam);
				return;
			}
			this.#ds();
		}

		// Token: 0x06000BB1 RID: 2993 RVA: 0x0009AC38 File Offset: 0x00098E38
		private bool #Ts(object #Sb)
		{
			TemporaryBeam temporaryBeam = #Sb as TemporaryBeam;
			if (temporaryBeam != null)
			{
				bool flag = temporaryBeam == this.AboveLeft;
				bool flag2 = flag && this.#1s();
				return !flag2;
			}
			return true;
		}

		// Token: 0x06000BB2 RID: 2994 RVA: 0x0009AC78 File Offset: 0x00098E78
		private void #Us(object #Sb)
		{
			TemporaryBeam temporaryBeam = #Sb as TemporaryBeam;
			if (temporaryBeam != null && temporaryBeam.IsValid)
			{
				#o8 #o = this.#0s(temporaryBeam);
				#o.CopyFrom(temporaryBeam);
				return;
			}
			this.#ds();
		}

		// Token: 0x06000BB3 RID: 2995 RVA: 0x0000EE21 File Offset: 0x0000D021
		private #9s #Vs(#9s #Ws)
		{
			if (#Ws != this.#f.BeamsXAxis)
			{
				return this.#f.BeamsXAxis;
			}
			return this.#f.BeamsYAxis;
		}

		// Token: 0x06000BB4 RID: 2996 RVA: 0x0009ACBC File Offset: 0x00098EBC
		private IEnumerable<#o8> #Xs(#o8 #Ys)
		{
			#3s.#K5b #K5b = new #3s.#K5b();
			#3s.#K5b #K5b2;
			if (!false)
			{
				#K5b2 = #K5b;
			}
			#K5b2.#a = #Ys;
			return this.OrderedBeams.Where(new Func<#o8, bool>(#K5b2.#sWb));
		}

		// Token: 0x06000BB5 RID: 2997 RVA: 0x0009AD00 File Offset: 0x00098F00
		private #o8 #Zs(#o8 #Ys)
		{
			List<#o8> list = this.OrderedBeams;
			int count = list.Count;
			int num = list.IndexOf(#Ys);
			int num2 = num + 1;
			if (num2 < count)
			{
				return list[num2];
			}
			return list[0];
		}

		// Token: 0x06000BB6 RID: 2998 RVA: 0x0009AD48 File Offset: 0x00098F48
		private #o8 #0s(#o8 #Ys)
		{
			List<#o8> list = this.OrderedBeams;
			int count = list.Count;
			int num = list.IndexOf(#Ys);
			int num2 = num - 1;
			if (num2 >= 0)
			{
				return list[num2];
			}
			return list[count - 1];
		}

		// Token: 0x06000BB7 RID: 2999 RVA: 0x0000EE54 File Offset: 0x0000D054
		private void #ds()
		{
			this.#ds(Strings.StringInvalidDataSpecified.#z2d() + Environment.NewLine.#W2d(2) + Strings.StringPleaseFixValidationErrorsBeforeCopyingValues);
		}

		// Token: 0x06000BB8 RID: 3000 RVA: 0x0009AD90 File Offset: 0x00098F90
		private void #ds(string #5)
		{
			Window window = this.#h.#6();
			Window #jA;
			if (!false)
			{
				#jA = window;
			}
			this.#e.#1Sc(#jA, ColumnGlobalInfo.DefaultMessageBoxTitle, #5, MessageBoxButton.OK, MessageBoxImage.Hand);
		}

		// Token: 0x06000BB9 RID: 3001 RVA: 0x0000EE87 File Offset: 0x0000D087
		private bool #1s()
		{
			if (this.ModelAxis != ModelAxis.XAxisPanel)
			{
				return this.#2s(this.SlendernessWindow.EndConditionY);
			}
			return this.#2s(this.SlendernessWindow.EndConditionX);
		}

		// Token: 0x06000BBA RID: 3002 RVA: 0x0000EEC0 File Offset: 0x0000D0C0
		private bool #2s(EndConditionType #6r)
		{
			return #6r > EndConditionType.Normal;
		}

		// Token: 0x06000BBB RID: 3003 RVA: 0x0000A950 File Offset: 0x00008B50
		void #5I.#Lr()
		{
			base.ClearErrors();
		}

		// Token: 0x06000BBC RID: 3004 RVA: 0x0000A960 File Offset: 0x00008B60
		void #5I.#Or(string #em)
		{
			base.RemoveError(#em);
		}

		// Token: 0x0400043F RID: 1087
		private TemporaryBeam #a;

		// Token: 0x04000440 RID: 1088
		private TemporaryBeam #b;

		// Token: 0x04000441 RID: 1089
		private TemporaryBeam #c;

		// Token: 0x04000442 RID: 1090
		private TemporaryBeam #d;

		// Token: 0x04000443 RID: 1091
		private readonly #8Sc #e;

		// Token: 0x04000444 RID: 1092
		private readonly #uW #f;

		// Token: 0x04000445 RID: 1093
		private readonly #5s #g;

		// Token: 0x04000446 RID: 1094
		private readonly #iW #h;

		// Token: 0x04000447 RID: 1095
		private readonly ICoreServices #i;

		// Token: 0x04000448 RID: 1096
		[CompilerGenerated]
		private readonly ModelAxis #j;

		// Token: 0x04000449 RID: 1097
		[CompilerGenerated]
		private readonly #ht #k;

		// Token: 0x0400044A RID: 1098
		[CompilerGenerated]
		private readonly DelegateCommand #l;

		// Token: 0x0400044B RID: 1099
		[CompilerGenerated]
		private readonly DelegateCommand #m;

		// Token: 0x0400044C RID: 1100
		[CompilerGenerated]
		private readonly DelegateCommand #n;

		// Token: 0x0400044D RID: 1101
		[CompilerGenerated]
		private readonly DelegateCommand #o;

		// Token: 0x02000170 RID: 368
		[CompilerGenerated]
		private sealed class #K5b
		{
			// Token: 0x06000BBE RID: 3006 RVA: 0x0000EECA File Offset: 0x0000D0CA
			internal bool #sWb(#o8 #6Gb)
			{
				return #6Gb != this.#a;
			}

			// Token: 0x0400044E RID: 1102
			public #o8 #a;
		}
	}
}
