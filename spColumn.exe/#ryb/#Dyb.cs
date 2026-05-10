using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using #cMb;
using #cwb;
using #eU;
using #hg;
using #LFb;
using #NDb;
using #o1d;
using #qzb;
using #RJb;
using #tFb;
using #v1c;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.Products.Column.Core.API;
using StructurePoint.Products.Column.Editor.Core.Selection;
using StructurePoint.Products.Column.Editor.Section.Irregular.Tools.API;
using StructurePoint.Products.Column.Model;
using StructurePoint.Products.Column.Viewports.API;
using Telerik.Windows.Controls;

namespace #ryb
{
	// Token: 0x020004CB RID: 1227
	internal sealed class #Dyb : #6Nb, INotifyPropertyChanged, #DNb, #qyb
	{
		// Token: 0x06002D09 RID: 11529 RVA: 0x000ED1B8 File Offset: 0x000EB3B8
		public #Dyb(#jg #ib, #UV #ms, #dU #5c, #dLb #Zc, IEditorService #wj, #UFb #Eyb, #Czb #Fyb, #RFb #Gyb, #pzb #Hyb, #XFb #Iyb, #KFb #Jyb, #3Fb #Kyb, #2Fb #Lyb, #4Fb #Myb, #5Fb #Nyb, #ZFb #Oyb, #TFb #Pyb, #SFb #Qyb, #0Fb #Ryb, #6Fb #Syb, #Gzb #Tyb, #FFb #Uyb, #xFb #Vyb, #CFb #Wyb, #sFb #Xyb, #wFb #Yyb, #DFb #Zyb, #iFb #0yb, #4zb #1yb, #R2c #ts) : base(#ib, #ms)
		{
			this.#a = #5c;
			this.#b = #Zc;
			this.#c = #wj;
			this.#d = #Eyb;
			this.#e = #Fyb;
			this.#f = #Hyb;
			this.#g = #Tyb;
			this.#h = #Uyb;
			this.#i = #Vyb;
			this.#j = #Wyb;
			this.#k = #Xyb;
			this.#l = #Yyb;
			this.#m = #Zyb;
			this.#y = #0yb;
			this.#z = #1yb;
			this.#A = #ts;
			this.#n = #Iyb;
			this.#o = #Jyb;
			this.#p = #Kyb;
			this.#q = #Lyb;
			this.#r = #Myb;
			this.#s = #Nyb;
			this.#t = #Oyb;
			this.#u = #Pyb;
			this.#v = #Qyb;
			this.#w = #Ryb;
			this.#x = #Syb;
			this.#C = new #cOb(#Iyb);
			this.#D = new #cOb(#Jyb);
			this.#N = new DelegateCommand(new Action<object>(this.#Ayb), new Predicate<object>(this.#zyb));
			this.#E = new #cOb(#Kyb);
			this.#J = new #cOb(#Lyb);
			this.#I = new #cOb(#Myb);
			this.#K = new #cOb(#Nyb);
			this.#F = new #cOb(#Oyb);
			this.#G = new #cOb(#Pyb);
			this.#H = new #cOb(#Qyb);
			this.#M = new #cOb(#Ryb);
			this.#L = new #cOb(#Syb);
			this.#Q = new #cOb(#Fyb);
			this.#S = new #cOb(#Hyb);
			this.#P = new #cOb(#Tyb);
			this.#R = new #cOb(#Gyb);
			#Gyb.Tools.#I1d(new Action<CircleToolViewModel>(this.#aWh));
			this.#T = #Gyb;
			this.#U = new #cOb(#Uyb);
			this.#W = new #cOb(#Xyb);
			this.#V = new #cOb(#Vyb);
			this.#X = new #cOb(#Wyb);
			this.#Y = new #cOb(#Yyb);
			this.#Z = new #cOb(#Zyb);
			this.#0 = new #cOb(#0yb);
			#ms.EditorSelectionChanged += this.#yyb;
			#ms.ToggleToolRequested += this.#xyb;
			#ms.ActiveScopeChanged += this.#wyb;
			#5c.PropertyChanged += this.#vyb;
			#ms.ProjectLoaded += this.#Gh;
			this.#pyb();
		}

		// Token: 0x17000F25 RID: 3877
		// (get) Token: 0x06002D0A RID: 11530 RVA: 0x00028550 File Offset: 0x00026750
		public #cOb SelectWrapper { get; }

		// Token: 0x17000F26 RID: 3878
		// (get) Token: 0x06002D0B RID: 11531 RVA: 0x0002855C File Offset: 0x0002675C
		public #cOb MeasureWrapper { get; }

		// Token: 0x17000F27 RID: 3879
		// (get) Token: 0x06002D0C RID: 11532 RVA: 0x00028568 File Offset: 0x00026768
		public #cOb MoveWrapper { get; }

		// Token: 0x17000F28 RID: 3880
		// (get) Token: 0x06002D0D RID: 11533 RVA: 0x00028574 File Offset: 0x00026774
		public #cOb CopyWrapper { get; }

		// Token: 0x17000F29 RID: 3881
		// (get) Token: 0x06002D0E RID: 11534 RVA: 0x00028580 File Offset: 0x00026780
		public #cOb RotateWrapper { get; }

		// Token: 0x17000F2A RID: 3882
		// (get) Token: 0x06002D0F RID: 11535 RVA: 0x0002858C File Offset: 0x0002678C
		public #cOb MirrorWrapper { get; }

		// Token: 0x17000F2B RID: 3883
		// (get) Token: 0x06002D10 RID: 11536 RVA: 0x00028598 File Offset: 0x00026798
		public #cOb OffsetWrapper { get; }

		// Token: 0x17000F2C RID: 3884
		// (get) Token: 0x06002D11 RID: 11537 RVA: 0x000285A4 File Offset: 0x000267A4
		public #cOb MergeWrapper { get; }

		// Token: 0x17000F2D RID: 3885
		// (get) Token: 0x06002D12 RID: 11538 RVA: 0x000285B0 File Offset: 0x000267B0
		public #cOb SplitWrapper { get; }

		// Token: 0x17000F2E RID: 3886
		// (get) Token: 0x06002D13 RID: 11539 RVA: 0x000285BC File Offset: 0x000267BC
		public #cOb AlignVerticallyWrapper { get; }

		// Token: 0x17000F2F RID: 3887
		// (get) Token: 0x06002D14 RID: 11540 RVA: 0x000285C8 File Offset: 0x000267C8
		public #cOb AlignHorizontallyWrapper { get; }

		// Token: 0x17000F30 RID: 3888
		// (get) Token: 0x06002D15 RID: 11541 RVA: 0x000285D4 File Offset: 0x000267D4
		public DelegateCommand DeleteCommand { get; }

		// Token: 0x17000F31 RID: 3889
		// (get) Token: 0x06002D16 RID: 11542 RVA: 0x000285E0 File Offset: 0x000267E0
		public #cOb DeleteWrapper { get; }

		// Token: 0x17000F32 RID: 3890
		// (get) Token: 0x06002D17 RID: 11543 RVA: 0x000285EC File Offset: 0x000267EC
		public #cOb AddArcSlabWraper { get; }

		// Token: 0x17000F33 RID: 3891
		// (get) Token: 0x06002D18 RID: 11544 RVA: 0x000285F8 File Offset: 0x000267F8
		public #cOb AddRectangleSlabWrapper { get; }

		// Token: 0x17000F34 RID: 3892
		// (get) Token: 0x06002D19 RID: 11545 RVA: 0x00028604 File Offset: 0x00026804
		public #cOb AddCircleSlabWrapper { get; }

		// Token: 0x17000F35 RID: 3893
		// (get) Token: 0x06002D1A RID: 11546 RVA: 0x00028610 File Offset: 0x00026810
		public #cOb AddPolygonSlabWrapper { get; }

		// Token: 0x17000F36 RID: 3894
		// (get) Token: 0x06002D1B RID: 11547 RVA: 0x0002861C File Offset: 0x0002681C
		public #RFb CircleTool { get; }

		// Token: 0x17000F37 RID: 3895
		// (get) Token: 0x06002D1C RID: 11548 RVA: 0x00028628 File Offset: 0x00026828
		public #cOb AddSingleReinforcementBar { get; }

		// Token: 0x17000F38 RID: 3896
		// (get) Token: 0x06002D1D RID: 11549 RVA: 0x00028634 File Offset: 0x00026834
		public #cOb AddGridReinforcementBar { get; }

		// Token: 0x17000F39 RID: 3897
		// (get) Token: 0x06002D1E RID: 11550 RVA: 0x00028640 File Offset: 0x00026840
		public #cOb AddArcReinforcementBar { get; }

		// Token: 0x17000F3A RID: 3898
		// (get) Token: 0x06002D1F RID: 11551 RVA: 0x0002864C File Offset: 0x0002684C
		public #cOb AddLineReinforcementBar { get; }

		// Token: 0x17000F3B RID: 3899
		// (get) Token: 0x06002D20 RID: 11552 RVA: 0x00028658 File Offset: 0x00026858
		public #cOb AddCircleReinforcementBar { get; }

		// Token: 0x17000F3C RID: 3900
		// (get) Token: 0x06002D21 RID: 11553 RVA: 0x00028664 File Offset: 0x00026864
		public #cOb AddRectReinforcementBar { get; }

		// Token: 0x17000F3D RID: 3901
		// (get) Token: 0x06002D22 RID: 11554 RVA: 0x00028670 File Offset: 0x00026870
		public #cOb EditIrregularReinforcementBars { get; }

		// Token: 0x06002D23 RID: 11555 RVA: 0x0002867C File Offset: 0x0002687C
		public bool #9Vh()
		{
			return this.EditIrregularReinforcementBars.IsSelected && this.#y.#iWh();
		}

		// Token: 0x06002D24 RID: 11556 RVA: 0x000286A4 File Offset: 0x000268A4
		protected override void #syb(#NNb #He)
		{
			this.#b.UpdateSelectCheckState(this.SelectWrapper.IsSelected);
			base.#syb(#He);
		}

		// Token: 0x06002D25 RID: 11557 RVA: 0x000ED470 File Offset: 0x000EB670
		protected override void #tyb(object #Sb)
		{
			#Dyb.#Ywf #Ywf = new #Dyb.#Ywf();
			#Ywf.#a = (#Sb as #cOb);
			if (#Ywf.#a == null)
			{
				return;
			}
			#R2c #R2c = this.#A;
			#cOb #cOb = base.ActiveTool;
			object #G2c;
			if (#cOb == null)
			{
				#G2c = null;
			}
			else
			{
				#uNb #uNb = #cOb.Tool;
				#G2c = ((#uNb != null) ? #uNb.ParametersView : null);
			}
			#R2c.#F2c(#G2c, true);
			if (#Ywf.#a == this.EditIrregularReinforcementBars && base.ActiveTool == this.EditIrregularReinforcementBars)
			{
				#Ywf.#a = (this.#B ?? this.SelectWrapper);
			}
			if (#Ywf.#a != this.EditIrregularReinforcementBars)
			{
				this.#B = #Ywf.#a;
			}
			#cOb[] #VNb = new #cOb[]
			{
				this.MoveWrapper,
				this.SplitWrapper,
				this.CopyWrapper,
				this.RotateWrapper,
				this.MirrorWrapper,
				this.OffsetWrapper,
				this.MergeWrapper,
				this.AlignVerticallyWrapper,
				this.AlignHorizontallyWrapper
			};
			List<#cOb> list = new #cOb[]
			{
				this.MeasureWrapper,
				this.AddArcSlabWraper,
				this.AddRectangleSlabWrapper,
				this.AddCircleSlabWrapper,
				this.AddPolygonSlabWrapper,
				this.AddSingleReinforcementBar,
				this.AddGridReinforcementBar,
				this.AddArcReinforcementBar,
				this.AddLineReinforcementBar,
				this.AddCircleReinforcementBar,
				this.AddRectReinforcementBar,
				this.EditIrregularReinforcementBars
			}.ToList<#cOb>();
			base.#TNb(#Ywf.#a, list, #VNb, this.SelectWrapper);
			if (list.Any(new Func<#cOb, bool>(#Ywf.#o8b)))
			{
				base.EditorViewport.Editor.Focus();
			}
		}

		// Token: 0x06002D26 RID: 11558 RVA: 0x000286CF File Offset: 0x000268CF
		public void #pyb()
		{
			this.DeleteCommand.InvalidateCanExecute();
			this.#uyb();
		}

		// Token: 0x06002D27 RID: 11559 RVA: 0x000286EE File Offset: 0x000268EE
		public override void #5b()
		{
			this.#pyb();
			base.#5b();
			this.#z.#5b();
			this.#tyb(this.SelectWrapper);
		}

		// Token: 0x06002D28 RID: 11560 RVA: 0x0002871F File Offset: 0x0002691F
		public override void #0kb()
		{
			this.#B = null;
			base.#0kb();
		}

		// Token: 0x06002D29 RID: 11561 RVA: 0x000ED63C File Offset: 0x000EB83C
		protected override void #uyb()
		{
			bool flag = base.EditorViewport != null && base.EditorViewport.EditorContext.Selection.State.AnyObjectSelected;
			IModelEditorViewport modelEditorViewport = base.EditorViewport;
			Type left;
			if (modelEditorViewport == null)
			{
				left = null;
			}
			else
			{
				#zLb #zLb = modelEditorViewport.ScopeSettings.ActiveScope;
				left = ((#zLb != null) ? #zLb.GetType() : null);
			}
			bool flag2 = left == typeof(#bwb) && !this.#a.ToolsBlockedByPropertiesPanel;
			bool flag3 = base.Context != null && base.Context.ProjectContext.Model.Options.SectionType == SectionType.Irregular && flag2;
			bool flag4 = base.Context != null;
			#cLb #cLb = base.Context;
			SelectionManager selectionManager = (#cLb != null) ? #cLb.Selection : null;
			bool flag5 = flag4 && selectionManager.Shapes.Any;
			bool flag6 = flag4 && selectionManager.Shapes.NoOfSelectedObjects > 1;
			bool flag7 = flag4 && selectionManager.Bars.NoOfSelectedObjects > 0;
			this.SelectWrapper.IsEnabled = flag3;
			this.MeasureWrapper.IsEnabled = flag3;
			this.MoveWrapper.IsEnabled = (flag3 && flag);
			this.CopyWrapper.IsEnabled = (flag3 && flag);
			this.RotateWrapper.IsEnabled = (flag3 && flag);
			this.MirrorWrapper.IsEnabled = (flag3 && flag);
			this.OffsetWrapper.IsEnabled = (flag3 && flag5 && selectionManager.Shapes.SelectedObjects.Count == 1);
			this.MergeWrapper.IsEnabled = (flag3 && flag6);
			this.SplitWrapper.IsEnabled = (flag3 && flag5);
			this.AlignVerticallyWrapper.IsEnabled = (flag3 && (flag7 || flag5));
			this.AlignHorizontallyWrapper.IsEnabled = ((flag3 && flag7) || flag5);
			this.DeleteWrapper.IsEnabled = (flag3 && flag);
			this.AddArcSlabWraper.IsEnabled = flag3;
			this.AddRectangleSlabWrapper.IsEnabled = flag3;
			this.AddCircleSlabWrapper.IsEnabled = flag3;
			this.AddPolygonSlabWrapper.IsEnabled = flag3;
			this.AddSingleReinforcementBar.IsEnabled = flag3;
			this.AddGridReinforcementBar.IsEnabled = flag3;
			this.AddArcReinforcementBar.IsEnabled = flag3;
			this.AddLineReinforcementBar.IsEnabled = flag3;
			this.AddCircleReinforcementBar.IsEnabled = flag3;
			this.AddRectReinforcementBar.IsEnabled = flag3;
			this.EditIrregularReinforcementBars.IsEnabled = flag3;
			base.#uyb();
		}

		// Token: 0x06002D2A RID: 11562 RVA: 0x0002873A File Offset: 0x0002693A
		private void #Gh(object #Ge, #cW #He)
		{
			if (!#He.IsInternalChange || #He.IsNewProject)
			{
				this.CircleTool.#cWh();
			}
		}

		// Token: 0x06002D2B RID: 11563 RVA: 0x00028763 File Offset: 0x00026963
		private void #vyb(object #Ge, PropertyChangedEventArgs #He)
		{
			this.#pyb();
		}

		// Token: 0x06002D2C RID: 11564 RVA: 0x00028763 File Offset: 0x00026963
		private void #wyb(object #Ge, #QJb #He)
		{
			this.#pyb();
		}

		// Token: 0x06002D2D RID: 11565 RVA: 0x000ED8B4 File Offset: 0x000EBAB4
		private void #xyb(object #Ge, #BU #He)
		{
			if (#He.Tool == this.#x)
			{
				this.#tyb(this.AlignVerticallyWrapper);
				return;
			}
			if (#He.Tool == this.#w)
			{
				this.#tyb(this.AlignHorizontallyWrapper);
				return;
			}
			if (#He.Tool == this.#q)
			{
				this.#tyb(this.MergeWrapper);
				return;
			}
			if (#He.Tool == this.#r)
			{
				this.#tyb(this.OffsetWrapper);
				return;
			}
			if (#He.Tool == this.#s)
			{
				this.#tyb(this.SplitWrapper);
				return;
			}
			if (#He.Tool == this.#o)
			{
				this.#tyb(this.MeasureWrapper);
				return;
			}
			if (#He.Tool == this.#p)
			{
				this.#tyb(this.MoveWrapper);
				return;
			}
			if (#He.Tool == this.#t)
			{
				this.#tyb(this.CopyWrapper);
				return;
			}
			if (#He.Tool == this.#u)
			{
				this.#tyb(this.RotateWrapper);
				return;
			}
			if (#He.Tool == this.#v)
			{
				this.#tyb(this.MirrorWrapper);
				return;
			}
			if (#He.Tool == this.#e)
			{
				this.#tyb(this.AddRectangleSlabWrapper);
				return;
			}
			if (#He.Tool == this.CircleTool)
			{
				this.#tyb(this.AddCircleSlabWrapper);
				return;
			}
			if (#He.Tool == this.#f)
			{
				this.#tyb(this.AddPolygonSlabWrapper);
				return;
			}
			if (#He.Tool == this.#g)
			{
				this.#tyb(this.AddArcSlabWraper);
				return;
			}
			if (#He.Tool == this.#h)
			{
				this.#tyb(this.AddSingleReinforcementBar);
				return;
			}
			if (#He.Tool == this.#k)
			{
				this.#tyb(this.AddArcReinforcementBar);
				return;
			}
			if (#He.Tool == this.#j)
			{
				this.#tyb(this.AddLineReinforcementBar);
				return;
			}
			if (#He.Tool == this.#l)
			{
				this.#tyb(this.AddCircleReinforcementBar);
				return;
			}
			if (#He.Tool == this.#m)
			{
				this.#tyb(this.AddRectReinforcementBar);
				return;
			}
			if (#He.Tool == this.#i)
			{
				this.#tyb(this.AddGridReinforcementBar);
				return;
			}
			if (#He.Tool == this.#y)
			{
				this.#tyb(this.EditIrregularReinforcementBars);
			}
		}

		// Token: 0x06002D2E RID: 11566 RVA: 0x00028763 File Offset: 0x00026963
		private void #yyb(object #Ge, EventArgs #He)
		{
			this.#pyb();
		}

		// Token: 0x06002D2F RID: 11567 RVA: 0x00028773 File Offset: 0x00026973
		private bool #zyb(object #Sb)
		{
			return base.Context.Selection.#jAb();
		}

		// Token: 0x06002D30 RID: 11568 RVA: 0x000EDB18 File Offset: 0x000EBD18
		private void #Ayb(object #Sb)
		{
			if (!base.Context.Selection.#jAb())
			{
				return;
			}
			#cOb #cOb = base.ActiveTool;
			#XFb #XFb = ((#cOb != null) ? #cOb.Tool : null) as #XFb;
			if (#XFb != null && #XFb.IsChildWorking)
			{
				base.#CNb();
			}
			this.#c.#0Pb(new Action(this.#bWh));
			base.Viewports.Renderer.#9f(false, false);
			this.#pyb();
			base.MessageBus.#KV();
			base.MessageBus.#tV();
			base.MessageBus.#MV();
		}

		// Token: 0x06002D31 RID: 11569 RVA: 0x00028791 File Offset: 0x00026991
		[CompilerGenerated]
		private void #aWh(CircleToolViewModel #Rf)
		{
			#Rf.Tool.Toolbar = this;
			#Rf.Tool.Wrapper = this.AddCircleSlabWrapper;
		}

		// Token: 0x06002D32 RID: 11570 RVA: 0x000287BC File Offset: 0x000269BC
		[CompilerGenerated]
		private void #bWh()
		{
			ColumnModelHelper.#aX(base.Context, this.#d);
			#cOb #cOb = base.ActiveTool;
			if (#cOb == null)
			{
				return;
			}
			#uNb #uNb = #cOb.Tool;
			if (#uNb == null)
			{
				return;
			}
			#uNb.#1kb();
		}

		// Token: 0x04001209 RID: 4617
		private readonly #dU #a;

		// Token: 0x0400120A RID: 4618
		private readonly #dLb #b;

		// Token: 0x0400120B RID: 4619
		private readonly IEditorService #c;

		// Token: 0x0400120C RID: 4620
		private readonly #UFb #d;

		// Token: 0x0400120D RID: 4621
		private readonly #Czb #e;

		// Token: 0x0400120E RID: 4622
		private readonly #pzb #f;

		// Token: 0x0400120F RID: 4623
		private readonly #Gzb #g;

		// Token: 0x04001210 RID: 4624
		private readonly #FFb #h;

		// Token: 0x04001211 RID: 4625
		private readonly #xFb #i;

		// Token: 0x04001212 RID: 4626
		private readonly #CFb #j;

		// Token: 0x04001213 RID: 4627
		private readonly #sFb #k;

		// Token: 0x04001214 RID: 4628
		private readonly #wFb #l;

		// Token: 0x04001215 RID: 4629
		private readonly #DFb #m;

		// Token: 0x04001216 RID: 4630
		private readonly #XFb #n;

		// Token: 0x04001217 RID: 4631
		private readonly #KFb #o;

		// Token: 0x04001218 RID: 4632
		private readonly #3Fb #p;

		// Token: 0x04001219 RID: 4633
		private readonly #2Fb #q;

		// Token: 0x0400121A RID: 4634
		private readonly #4Fb #r;

		// Token: 0x0400121B RID: 4635
		private readonly #5Fb #s;

		// Token: 0x0400121C RID: 4636
		private readonly #ZFb #t;

		// Token: 0x0400121D RID: 4637
		private readonly #TFb #u;

		// Token: 0x0400121E RID: 4638
		private readonly #SFb #v;

		// Token: 0x0400121F RID: 4639
		private readonly #0Fb #w;

		// Token: 0x04001220 RID: 4640
		private readonly #6Fb #x;

		// Token: 0x04001221 RID: 4641
		private readonly #iFb #y;

		// Token: 0x04001222 RID: 4642
		private readonly #4zb #z;

		// Token: 0x04001223 RID: 4643
		private readonly #R2c #A;

		// Token: 0x04001224 RID: 4644
		private #cOb #B;

		// Token: 0x04001225 RID: 4645
		[CompilerGenerated]
		private readonly #cOb #C;

		// Token: 0x04001226 RID: 4646
		[CompilerGenerated]
		private readonly #cOb #D;

		// Token: 0x04001227 RID: 4647
		[CompilerGenerated]
		private readonly #cOb #E;

		// Token: 0x04001228 RID: 4648
		[CompilerGenerated]
		private readonly #cOb #F;

		// Token: 0x04001229 RID: 4649
		[CompilerGenerated]
		private readonly #cOb #G;

		// Token: 0x0400122A RID: 4650
		[CompilerGenerated]
		private readonly #cOb #H;

		// Token: 0x0400122B RID: 4651
		[CompilerGenerated]
		private readonly #cOb #I;

		// Token: 0x0400122C RID: 4652
		[CompilerGenerated]
		private readonly #cOb #J;

		// Token: 0x0400122D RID: 4653
		[CompilerGenerated]
		private readonly #cOb #K;

		// Token: 0x0400122E RID: 4654
		[CompilerGenerated]
		private readonly #cOb #L;

		// Token: 0x0400122F RID: 4655
		[CompilerGenerated]
		private readonly #cOb #M;

		// Token: 0x04001230 RID: 4656
		[CompilerGenerated]
		private readonly DelegateCommand #N;

		// Token: 0x04001231 RID: 4657
		[CompilerGenerated]
		private readonly #cOb #O = new #cOb();

		// Token: 0x04001232 RID: 4658
		[CompilerGenerated]
		private readonly #cOb #P;

		// Token: 0x04001233 RID: 4659
		[CompilerGenerated]
		private readonly #cOb #Q;

		// Token: 0x04001234 RID: 4660
		[CompilerGenerated]
		private readonly #cOb #R;

		// Token: 0x04001235 RID: 4661
		[CompilerGenerated]
		private readonly #cOb #S;

		// Token: 0x04001236 RID: 4662
		[CompilerGenerated]
		private readonly #RFb #T;

		// Token: 0x04001237 RID: 4663
		[CompilerGenerated]
		private readonly #cOb #U;

		// Token: 0x04001238 RID: 4664
		[CompilerGenerated]
		private readonly #cOb #V;

		// Token: 0x04001239 RID: 4665
		[CompilerGenerated]
		private readonly #cOb #W;

		// Token: 0x0400123A RID: 4666
		[CompilerGenerated]
		private readonly #cOb #X;

		// Token: 0x0400123B RID: 4667
		[CompilerGenerated]
		private readonly #cOb #Y;

		// Token: 0x0400123C RID: 4668
		[CompilerGenerated]
		private readonly #cOb #Z;

		// Token: 0x0400123D RID: 4669
		[CompilerGenerated]
		private readonly #cOb #0;

		// Token: 0x020004CC RID: 1228
		[CompilerGenerated]
		private sealed class #Ywf
		{
			// Token: 0x06002D34 RID: 11572 RVA: 0x000287F5 File Offset: 0x000269F5
			internal bool #o8b(#cOb #Rf)
			{
				return #Rf == this.#a;
			}

			// Token: 0x0400123E RID: 4670
			public #cOb #a;
		}
	}
}
