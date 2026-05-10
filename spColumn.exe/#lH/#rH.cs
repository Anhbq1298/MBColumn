using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using #7hc;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.Products.Column.Services.API;
using StructurePoint.Products.Column.Viewports.API;

namespace #lH
{
	// Token: 0x02000104 RID: 260
	internal class #rH<#fx> : #HH<!0>, IViewModel<!0>, INotifyPropertyChanged, #kH<!0>, IViewModel where #fx : class, IView
	{
		// Token: 0x06000880 RID: 2176 RVA: 0x0000C6F5 File Offset: 0x0000A8F5
		public #rH(Lazy<#fx> #Ee, IExtendedServices #0c, string #sH) : base(#Ee, #0c)
		{
			this.#b = #0c;
			this.#c = #sH;
			base.SetBindingValidationErrorsAsHandled = true;
		}

		// Token: 0x14000022 RID: 34
		// (add) Token: 0x06000881 RID: 2177 RVA: 0x000932A0 File Offset: 0x000914A0
		// (remove) Token: 0x06000882 RID: 2178 RVA: 0x000932E4 File Offset: 0x000914E4
		public event EventHandler PopupClosed
		{
			[CompilerGenerated]
			add
			{
				EventHandler eventHandler = this.#d;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#d, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler eventHandler = this.#d;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#d, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x14000023 RID: 35
		// (add) Token: 0x06000883 RID: 2179 RVA: 0x00093328 File Offset: 0x00091528
		// (remove) Token: 0x06000884 RID: 2180 RVA: 0x0009336C File Offset: 0x0009156C
		public event EventHandler PopupOpened
		{
			[CompilerGenerated]
			add
			{
				EventHandler eventHandler = this.#e;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#e, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler eventHandler = this.#e;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#e, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x170003B9 RID: 953
		// (get) Token: 0x06000885 RID: 2181 RVA: 0x0000C714 File Offset: 0x0000A914
		// (set) Token: 0x06000886 RID: 2182 RVA: 0x000933B0 File Offset: 0x000915B0
		public bool IsOpened
		{
			get
			{
				return this.#a;
			}
			set
			{
				if (this.#a != value)
				{
					this.#a = value;
					if (value)
					{
						this.#0l();
					}
					else if (!this.#cm())
					{
						this.#1l();
					}
					else
					{
						this.#a = true;
					}
					base.RaisePropertyChanged(#Phc.#3hc(107408187));
				}
			}
		}

		// Token: 0x170003BA RID: 954
		// (get) Token: 0x06000887 RID: 2183 RVA: 0x0000C720 File Offset: 0x0000A920
		// (set) Token: 0x06000888 RID: 2184 RVA: 0x0000C72C File Offset: 0x0000A92C
		public string Title
		{
			get
			{
				return this.#c;
			}
			set
			{
				if (this.#c != value)
				{
					this.#c = value;
					base.RaisePropertyChanged(#Phc.#3hc(107408142));
				}
			}
		}

		// Token: 0x170003BB RID: 955
		// (get) Token: 0x06000889 RID: 2185 RVA: 0x0000C75F File Offset: 0x0000A95F
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x0600088A RID: 2186 RVA: 0x0000C76F File Offset: 0x0000A96F
		public void #jH()
		{
			this.IsOpened = false;
			this.IsOpened = true;
		}

		// Token: 0x0600088B RID: 2187 RVA: 0x0000C78B File Offset: 0x0000A98B
		public virtual bool #cm()
		{
			return false;
		}

		// Token: 0x0600088C RID: 2188 RVA: 0x0000C78E File Offset: 0x0000A98E
		protected void #mH()
		{
			LayoutHelper.BeginInvokeOnApplicationThread(new Action(this.#dwf));
		}

		// Token: 0x0600088D RID: 2189 RVA: 0x0000C7AA File Offset: 0x0000A9AA
		protected virtual void #0l()
		{
			this.#oH();
		}

		// Token: 0x0600088E RID: 2190 RVA: 0x0000C7BA File Offset: 0x0000A9BA
		protected virtual void #1l()
		{
			this.#nH();
		}

		// Token: 0x0600088F RID: 2191 RVA: 0x0000C7CA File Offset: 0x0000A9CA
		protected virtual void #nH()
		{
			EventHandler eventHandler = this.#d;
			if (eventHandler == null)
			{
				return;
			}
			eventHandler(this, EventArgs.Empty);
		}

		// Token: 0x06000890 RID: 2192 RVA: 0x0000C7EE File Offset: 0x0000A9EE
		protected virtual void #oH()
		{
			EventHandler eventHandler = this.#e;
			if (eventHandler == null)
			{
				return;
			}
			eventHandler(this, EventArgs.Empty);
		}

		// Token: 0x06000891 RID: 2193 RVA: 0x0000C67D File Offset: 0x0000A87D
		bool #kH<!0>.#pH()
		{
			return base.IsValid;
		}

		// Token: 0x06000892 RID: 2194 RVA: 0x0009340C File Offset: 0x0009160C
		[CompilerGenerated]
		private void #dwf()
		{
			IModelEditorViewport modelEditorViewport = this.#b.ViewportsManager.ActiveViewport as IModelEditorViewport;
			if (modelEditorViewport != null)
			{
				modelEditorViewport.Renderer.#cg();
				modelEditorViewport.Editor.SetFocusExt();
			}
		}

		// Token: 0x040002BC RID: 700
		private bool #a;

		// Token: 0x040002BD RID: 701
		private readonly IExtendedServices #b;

		// Token: 0x040002BE RID: 702
		private string #c;

		// Token: 0x040002BF RID: 703
		[CompilerGenerated]
		private EventHandler #d;

		// Token: 0x040002C0 RID: 704
		[CompilerGenerated]
		private EventHandler #e;
	}
}
