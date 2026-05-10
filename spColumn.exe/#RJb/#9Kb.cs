using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using #7hc;
using #APb;
using #eU;
using #qPb;
using #Xc;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.Products.Column.Editor.Diagrams;
using StructurePoint.Products.Column.Editor.Project;
using StructurePoint.Products.Column.Editor.Section;
using StructurePoint.Products.Column.Viewports.API;

namespace #RJb
{
	// Token: 0x02000672 RID: 1650
	internal sealed class #9Kb : NotifyPropertyChangedObjectBase, INotifyPropertyChanged, #BLb
	{
		// Token: 0x06003779 RID: 14201 RVA: 0x0010D4F4 File Offset: 0x0010B6F4
		public #9Kb(#UV #ms, #BPb #aLb, #wU #Wmb, #SPb #bLb, #KPb #xn, #vd #mj, #AWh #eTh)
		{
			this.#a = #ms;
			this.#b = #mj;
			if (#aLb == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107352044));
			}
			this.#e = #aLb;
			if (#bLb == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107352063));
			}
			this.#f = #bLb;
			if (#xn == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107404877));
			}
			this.#g = #xn;
			#eTh.ProjectLeftPanelViewModel = (this.Project.PanelViewModel as #MPb);
			#eTh.SectionLeftPanelViewModel = (this.Section.PanelViewModel as #UPb);
			#eTh.ScopesManager = this;
			#Wmb.ActivateScopeWithParameters.SetCommand(new Action<object>(this.#4Kb), new Predicate<object>(this.#3Kb));
			#ms.CancelToolsRequested += this.#1Kb;
		}

		// Token: 0x140000D1 RID: 209
		// (add) Token: 0x0600377A RID: 14202 RVA: 0x0010D5D4 File Offset: 0x0010B7D4
		// (remove) Token: 0x0600377B RID: 14203 RVA: 0x0010D618 File Offset: 0x0010B818
		public event EventHandler<#QJb> ActiveScopeChanged
		{
			[CompilerGenerated]
			add
			{
				EventHandler<#QJb> eventHandler = this.#d;
				EventHandler<#QJb> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#QJb> value2 = (EventHandler<#QJb>)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#QJb>>(ref this.#d, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<#QJb> eventHandler = this.#d;
				EventHandler<#QJb> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#QJb> value2 = (EventHandler<#QJb>)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#QJb>>(ref this.#d, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x1700112F RID: 4399
		// (get) Token: 0x0600377C RID: 14204 RVA: 0x000303FC File Offset: 0x0002E5FC
		public #BPb Diagrams { get; }

		// Token: 0x17001130 RID: 4400
		// (get) Token: 0x0600377D RID: 14205 RVA: 0x00030408 File Offset: 0x0002E608
		public #SPb Section { get; }

		// Token: 0x17001131 RID: 4401
		// (get) Token: 0x0600377E RID: 14206 RVA: 0x00030414 File Offset: 0x0002E614
		public #KPb Project { get; }

		// Token: 0x17001132 RID: 4402
		// (get) Token: 0x0600377F RID: 14207 RVA: 0x00030420 File Offset: 0x0002E620
		// (set) Token: 0x06003780 RID: 14208 RVA: 0x0010D65C File Offset: 0x0010B85C
		public #zLb ActiveScope
		{
			get
			{
				return this.#c;
			}
			private set
			{
				if (this.#c != value)
				{
					#zLb #SJb = this.#c;
					this.#c = value;
					this.#0Kb(new #QJb(#SJb, value));
					this.#a.#PV(new #QJb(#SJb, value));
					base.RaisePropertyChanged(#Phc.#3hc(107352050));
				}
			}
		}

		// Token: 0x06003781 RID: 14209 RVA: 0x0010D6BC File Offset: 0x0010B8BC
		public void #WKb()
		{
			#zLb #zLb = this.ActiveScope;
			object obj;
			if (#zLb == null)
			{
				obj = null;
			}
			else
			{
				IView view = #zLb.PanelView;
				obj = ((view != null) ? view.DataContext : null);
			}
			#yLb #yLb = obj as #yLb;
			if (#yLb != null)
			{
				#yLb.#mwb();
				#yLb.#mwb();
			}
		}

		// Token: 0x06003782 RID: 14210 RVA: 0x0003042C File Offset: 0x0002E62C
		public void #XKb(ProjectScopeActivationParameters #Pc)
		{
			this.#b.#jd();
			this.#5b(this.Project, #Pc);
		}

		// Token: 0x06003783 RID: 14211 RVA: 0x00030452 File Offset: 0x0002E652
		public void #YKb(DiagramsScopeActivationParameters #Pc)
		{
			this.#b.#kd();
			this.#5b(this.Diagrams, #Pc);
		}

		// Token: 0x06003784 RID: 14212 RVA: 0x00030478 File Offset: 0x0002E678
		public void #ZKb(SectionScopeActivationParameters #Pc)
		{
			this.#b.#jd();
			this.#5b(this.Section, #Pc);
		}

		// Token: 0x06003785 RID: 14213 RVA: 0x0003049E File Offset: 0x0002E69E
		protected void #0Kb(#QJb #He)
		{
			EventHandler<#QJb> eventHandler = this.#d;
			if (eventHandler == null)
			{
				return;
			}
			eventHandler(this, #He);
		}

		// Token: 0x06003786 RID: 14214 RVA: 0x000304BE File Offset: 0x0002E6BE
		private void #1Kb(object #Ge, EventArgs #He)
		{
			this.#WKb();
		}

		// Token: 0x06003787 RID: 14215 RVA: 0x0010D708 File Offset: 0x0010B908
		private #zLb #2Kb(object #Pc)
		{
			if (#Pc is DiagramsScopeActivationParameters)
			{
				return this.Diagrams;
			}
			if (#Pc is ProjectScopeActivationParameters)
			{
				return this.Project;
			}
			if (#Pc is SectionScopeActivationParameters)
			{
				return this.Section;
			}
			throw new InvalidOperationException(Strings.StringInvalidScopeParemeterType.#z2d());
		}

		// Token: 0x06003788 RID: 14216 RVA: 0x0010D760 File Offset: 0x0010B960
		private bool #3Kb(object #Vg)
		{
			#zLb #zLb = this.#2Kb(#Vg);
			return #zLb.#LKb((#ALb)#Vg);
		}

		// Token: 0x06003789 RID: 14217 RVA: 0x0010D790 File Offset: 0x0010B990
		private void #4Kb(object #Vg)
		{
			#zLb #zLb = this.#2Kb(#Vg);
			if (#zLb.#LKb((#ALb)#Vg))
			{
				this.#5b(#zLb, (#ALb)#Vg);
			}
		}

		// Token: 0x0600378A RID: 14218 RVA: 0x0010D7CC File Offset: 0x0010B9CC
		private void #5b(#zLb #5Kb, #ALb #Pc)
		{
			if (6 != 0)
			{
				this.#7Kb();
			}
			if (#5Kb == this.Diagrams)
			{
				if (this.#b.DiagramsViewports.ActiveViewport != null)
				{
					this.#b.DiagramsViewports.ActiveViewport.ScopeSettings.ActiveScope = #5Kb;
					this.#8Kb(#5Kb, this.#b.DiagramsViewports.ActiveViewport);
				}
				this.#b.#kd();
			}
			else
			{
				if (this.#b.EditorViewports.ActiveViewport != null)
				{
					this.#b.EditorViewports.ActiveViewport.ScopeSettings.ActiveScope = #5Kb;
					this.#8Kb(#5Kb, this.#b.EditorViewports.ActiveViewport);
				}
				this.#b.#jd();
			}
			this.ActiveScope = #5Kb;
			if (#5Kb != null)
			{
				#5Kb.#5b(#Pc);
			}
		}

		// Token: 0x0600378B RID: 14219 RVA: 0x000304CE File Offset: 0x0002E6CE
		private void #6Kb(#zLb #5Kb)
		{
			if (#5Kb != null)
			{
				#5Kb.#0kb();
			}
		}

		// Token: 0x0600378C RID: 14220 RVA: 0x0010D8BC File Offset: 0x0010BABC
		private void #7Kb()
		{
			#zLb #5Kb = this.ActiveScope;
			this.#6Kb(#5Kb);
		}

		// Token: 0x0600378D RID: 14221 RVA: 0x0010D8E4 File Offset: 0x0010BAE4
		private void #8Kb(#zLb #5Kb, IViewport #fe)
		{
			string value = #5Kb.#7vb(#fe);
			if (!string.IsNullOrWhiteSpace(value))
			{
				#fe.Host.Header = value;
			}
		}

		// Token: 0x04001721 RID: 5921
		private readonly #UV #a;

		// Token: 0x04001722 RID: 5922
		private readonly #vd #b;

		// Token: 0x04001723 RID: 5923
		private #zLb #c;

		// Token: 0x04001724 RID: 5924
		[CompilerGenerated]
		private EventHandler<#QJb> #d;

		// Token: 0x04001725 RID: 5925
		[CompilerGenerated]
		private readonly #BPb #e;

		// Token: 0x04001726 RID: 5926
		[CompilerGenerated]
		private readonly #SPb #f;

		// Token: 0x04001727 RID: 5927
		[CompilerGenerated]
		private readonly #KPb #g;
	}
}
