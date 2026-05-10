using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using #7hc;
using #eU;
using #hg;
using #RJb;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Tools;
using StructurePoint.Products.Column.Editor.Core.Tools;
using StructurePoint.Products.Column.Viewports.API;
using Telerik.Windows.Controls;
using Telerik.Windows.Data;

namespace #cMb
{
	// Token: 0x020004C5 RID: 1221
	internal class #6Nb : NotifyPropertyChangedObjectBase, INotifyPropertyChanged, #DNb
	{
		// Token: 0x06002CB7 RID: 11447 RVA: 0x000EC92C File Offset: 0x000EAB2C
		public #6Nb(#jg #ib, #UV #ms)
		{
			this.#g = #ms;
			this.#h = #ib;
			this.#j = new DelegateCommand(new Action<object>(this.#0Nb), new Predicate<object>(this.#1Nb));
		}

		// Token: 0x140000CA RID: 202
		// (add) Token: 0x06002CB8 RID: 11448 RVA: 0x000EC97C File Offset: 0x000EAB7C
		// (remove) Token: 0x06002CB9 RID: 11449 RVA: 0x000EC9C0 File Offset: 0x000EABC0
		public event EventHandler<#NNb> ToolActivated
		{
			[CompilerGenerated]
			add
			{
				EventHandler<#NNb> eventHandler = this.#e;
				EventHandler<#NNb> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#NNb> value2 = (EventHandler<#NNb>)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#NNb>>(ref this.#e, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<#NNb> eventHandler = this.#e;
				EventHandler<#NNb> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#NNb> value2 = (EventHandler<#NNb>)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#NNb>>(ref this.#e, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x140000CB RID: 203
		// (add) Token: 0x06002CBA RID: 11450 RVA: 0x000ECA04 File Offset: 0x000EAC04
		// (remove) Token: 0x06002CBB RID: 11451 RVA: 0x000ECA48 File Offset: 0x000EAC48
		public event EventHandler<#NNb> ToolDeactivated
		{
			[CompilerGenerated]
			add
			{
				EventHandler<#NNb> eventHandler = this.#f;
				EventHandler<#NNb> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#NNb> value2 = (EventHandler<#NNb>)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#NNb>>(ref this.#f, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<#NNb> eventHandler = this.#f;
				EventHandler<#NNb> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#NNb> value2 = (EventHandler<#NNb>)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#NNb>>(ref this.#f, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x17000F03 RID: 3843
		// (get) Token: 0x06002CBC RID: 11452 RVA: 0x000281D7 File Offset: 0x000263D7
		protected #UV MessageBus { get; }

		// Token: 0x17000F04 RID: 3844
		// (get) Token: 0x06002CBD RID: 11453 RVA: 0x000281E3 File Offset: 0x000263E3
		public #cLb Context
		{
			get
			{
				IModelEditorViewport modelEditorViewport = this.EditorViewport;
				if (modelEditorViewport == null)
				{
					return null;
				}
				return modelEditorViewport.EditorContext;
			}
		}

		// Token: 0x17000F05 RID: 3845
		// (get) Token: 0x06002CBE RID: 11454 RVA: 0x000281FE File Offset: 0x000263FE
		public #jg Viewports { get; }

		// Token: 0x17000F06 RID: 3846
		// (get) Token: 0x06002CBF RID: 11455 RVA: 0x0002820A File Offset: 0x0002640A
		public RadObservableCollection<#uNb> Tools { get; }

		// Token: 0x17000F07 RID: 3847
		// (get) Token: 0x06002CC0 RID: 11456 RVA: 0x00028216 File Offset: 0x00026416
		// (set) Token: 0x06002CC1 RID: 11457 RVA: 0x00028222 File Offset: 0x00026422
		public bool IsActive
		{
			get
			{
				return this.#a;
			}
			private set
			{
				if (this.#a != value)
				{
					this.#a = value;
					base.RaisePropertyChanged(#Phc.#3hc(107362485));
				}
			}
		}

		// Token: 0x17000F08 RID: 3848
		// (get) Token: 0x06002CC2 RID: 11458 RVA: 0x00028250 File Offset: 0x00026450
		public DelegateCommand ActivateToolCommand { get; }

		// Token: 0x17000F09 RID: 3849
		// (get) Token: 0x06002CC3 RID: 11459 RVA: 0x0002825C File Offset: 0x0002645C
		// (set) Token: 0x06002CC4 RID: 11460 RVA: 0x00028268 File Offset: 0x00026468
		public #cOb ActiveTool
		{
			get
			{
				return this.#d;
			}
			private set
			{
				if (this.#d != value)
				{
					this.#d = value;
					base.RaisePropertyChanged(#Phc.#3hc(107351866));
				}
			}
		}

		// Token: 0x17000F0A RID: 3850
		// (get) Token: 0x06002CC5 RID: 11461 RVA: 0x00028296 File Offset: 0x00026496
		// (set) Token: 0x06002CC6 RID: 11462 RVA: 0x000282A2 File Offset: 0x000264A2
		public bool IsInSelectMode
		{
			get
			{
				return this.#b;
			}
			private set
			{
				this.SetProperty<bool>(ref this.#b, value, #Phc.#3hc(107351817));
			}
		}

		// Token: 0x17000F0B RID: 3851
		// (get) Token: 0x06002CC7 RID: 11463 RVA: 0x000282C8 File Offset: 0x000264C8
		protected IModelEditorViewport EditorViewport
		{
			get
			{
				return this.Viewports.ActiveViewport as IModelEditorViewport;
			}
		}

		// Token: 0x06002CC8 RID: 11464 RVA: 0x000282E6 File Offset: 0x000264E6
		public virtual void #5b()
		{
			this.IsActive = true;
		}

		// Token: 0x06002CC9 RID: 11465 RVA: 0x000282F7 File Offset: 0x000264F7
		public void #CNb()
		{
			#cOb #cOb = this.ActiveTool;
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

		// Token: 0x06002CCA RID: 11466 RVA: 0x000ECA8C File Offset: 0x000EAC8C
		public virtual void #0kb()
		{
			this.IsActive = false;
			#cOb #cOb = this.ActiveTool;
			if (#cOb != null)
			{
				#uNb #uNb = #cOb.Tool;
				if (#uNb != null)
				{
					#uNb.#1kb();
				}
			}
			if (this.ActiveTool != null)
			{
				this.#tyb(this.ActiveTool);
			}
		}

		// Token: 0x06002CCB RID: 11467 RVA: 0x00009E6A File Offset: 0x0000806A
		protected virtual void #QNb(EyeshotEditorTool #RNb, EyeshotEditorTool #SNb)
		{
		}

		// Token: 0x06002CCC RID: 11468 RVA: 0x00009E6A File Offset: 0x0000806A
		protected virtual void #uyb()
		{
		}

		// Token: 0x06002CCD RID: 11469 RVA: 0x0002831B File Offset: 0x0002651B
		public void #8vb(#cOb #Ph)
		{
			this.#tyb(#Ph);
		}

		// Token: 0x06002CCE RID: 11470 RVA: 0x000ECADC File Offset: 0x000EACDC
		protected void #TNb(#cOb #Ph, IList<#cOb> #UNb, IList<#cOb> #VNb, #cOb #WNb)
		{
			#6Nb.#Jcc #Jcc = new #6Nb.#Jcc();
			#Jcc.#a = #Ph;
			if (#VNb.Any(new Func<#cOb, bool>(#Jcc.#Hcc)))
			{
				this.#4Nb(#VNb.Except(new #cOb[]
				{
					#Jcc.#a
				}).ToArray<#cOb>());
				if (#Jcc.#a.IsEnabled)
				{
					this.#2Nb(#Jcc.#a);
				}
				this.#uyb();
			}
			else
			{
				if (#UNb.Any(new Func<#cOb, bool>(#Jcc.#Icc)))
				{
					this.#c = #Jcc.#a;
				}
				this.#3Nb(#Jcc.#a);
			}
			#WNb = (this.#c ?? #WNb);
			if (this.IsActive && this.ActiveTool == null && ((#WNb != null) ? #WNb.Tool : null) != null)
			{
				this.#tyb(#WNb);
			}
		}

		// Token: 0x06002CCF RID: 11471 RVA: 0x00028330 File Offset: 0x00026530
		protected virtual void #tyb(object #Sb)
		{
			this.#3Nb(#Sb);
		}

		// Token: 0x06002CD0 RID: 11472 RVA: 0x000ECBCC File Offset: 0x000EADCC
		protected void #XNb(#cOb #YNb)
		{
			if (!#YNb.IsEnabled)
			{
				IChildColumnEditorTool childColumnEditorTool = #YNb.Tool as IChildColumnEditorTool;
				if (childColumnEditorTool != null)
				{
					childColumnEditorTool.IsEnabled = false;
				}
				#YNb.IsSelected = false;
			}
		}

		// Token: 0x06002CD1 RID: 11473 RVA: 0x00028345 File Offset: 0x00026545
		protected virtual void #ZNb(#NNb #He)
		{
			EventHandler<#NNb> eventHandler = this.#f;
			if (eventHandler == null)
			{
				return;
			}
			eventHandler(this, #He);
		}

		// Token: 0x06002CD2 RID: 11474 RVA: 0x00028365 File Offset: 0x00026565
		protected virtual void #syb(#NNb #He)
		{
			EventHandler<#NNb> eventHandler = this.#e;
			if (eventHandler == null)
			{
				return;
			}
			eventHandler(this, #He);
		}

		// Token: 0x06002CD3 RID: 11475 RVA: 0x000ECC0C File Offset: 0x000EAE0C
		private void #0Nb(object #Sb)
		{
			#cOb #cOb = #Sb as #cOb;
			if (#cOb != null && this.ActiveTool == #cOb && !#cOb.CanDeactivateFromUI)
			{
				return;
			}
			this.#tyb(#Sb);
		}

		// Token: 0x06002CD4 RID: 11476 RVA: 0x00003375 File Offset: 0x00001575
		private bool #1Nb(object #Sb)
		{
			return true;
		}

		// Token: 0x06002CD5 RID: 11477 RVA: 0x000ECC48 File Offset: 0x000EAE48
		private void #2Nb(#cOb #Ph)
		{
			#Ph.IsSelected = !#Ph.IsSelected;
			IChildColumnEditorTool childColumnEditorTool = #Ph.Tool as IChildColumnEditorTool;
			if (childColumnEditorTool != null)
			{
				childColumnEditorTool.IsEnabled = #Ph.IsSelected;
			}
		}

		// Token: 0x06002CD6 RID: 11478 RVA: 0x000ECC8C File Offset: 0x000EAE8C
		private void #3Nb(object #Sb)
		{
			#cOb #cOb = #Sb as #cOb;
			if (#cOb == null)
			{
				return;
			}
			if (this.EditorViewport == null)
			{
				return;
			}
			#cOb #cOb2 = this.ActiveTool;
			EyeshotEditorTool eyeshotEditorTool = ((#cOb2 != null) ? #cOb2.Tool : null) as EyeshotEditorTool;
			EyeshotEditorTool eyeshotEditorTool2 = #cOb.Tool as EyeshotEditorTool;
			if (eyeshotEditorTool2 == null)
			{
				return;
			}
			if (#cOb != this.ActiveTool)
			{
				if (eyeshotEditorTool != null)
				{
					this.EditorViewport.Editor.DeactivateTool(eyeshotEditorTool);
				}
				this.EditorViewport.Editor.ActivateTool(eyeshotEditorTool2);
				if (this.ActiveTool != null)
				{
					this.ActiveTool.IsSelected = false;
				}
				#cOb.IsSelected = true;
				this.ActiveTool = #cOb;
				this.EditorViewport.Editor.SetFocus(null);
				this.#syb(new #NNb(#cOb));
			}
			else
			{
				this.EditorViewport.Editor.DeactivateTool(eyeshotEditorTool2);
				#cOb.IsSelected = false;
				this.ActiveTool = null;
				this.#ZNb(new #NNb(#cOb));
			}
			this.#QNb(eyeshotEditorTool, eyeshotEditorTool2);
		}

		// Token: 0x06002CD7 RID: 11479 RVA: 0x000ECD98 File Offset: 0x000EAF98
		private void #4Nb(params #cOb[] #5Nb)
		{
			foreach (#cOb #cOb in #5Nb)
			{
				IChildColumnEditorTool childColumnEditorTool = #cOb.Tool as IChildColumnEditorTool;
				if (childColumnEditorTool != null && childColumnEditorTool.IsEnabled)
				{
					this.#tyb(#cOb);
				}
			}
		}

		// Token: 0x040011F0 RID: 4592
		private bool #a;

		// Token: 0x040011F1 RID: 4593
		private bool #b;

		// Token: 0x040011F2 RID: 4594
		private #cOb #c;

		// Token: 0x040011F3 RID: 4595
		private #cOb #d;

		// Token: 0x040011F4 RID: 4596
		[CompilerGenerated]
		private EventHandler<#NNb> #e;

		// Token: 0x040011F5 RID: 4597
		[CompilerGenerated]
		private EventHandler<#NNb> #f;

		// Token: 0x040011F6 RID: 4598
		[CompilerGenerated]
		private readonly #UV #g;

		// Token: 0x040011F7 RID: 4599
		[CompilerGenerated]
		private readonly #jg #h;

		// Token: 0x040011F8 RID: 4600
		[CompilerGenerated]
		private readonly RadObservableCollection<#uNb> #i = new RadObservableCollection<#uNb>();

		// Token: 0x040011F9 RID: 4601
		[CompilerGenerated]
		private readonly DelegateCommand #j;

		// Token: 0x020004C6 RID: 1222
		[CompilerGenerated]
		private sealed class #Jcc
		{
			// Token: 0x06002CD9 RID: 11481 RVA: 0x00028385 File Offset: 0x00026585
			internal bool #Hcc(#cOb #Rf)
			{
				return this.#a == #Rf;
			}

			// Token: 0x06002CDA RID: 11482 RVA: 0x00028398 File Offset: 0x00026598
			internal bool #Icc(#cOb #Rf)
			{
				return #Rf == this.#a;
			}

			// Token: 0x040011FA RID: 4602
			public #cOb #a;
		}
	}
}
