using System;
using System.Runtime.CompilerServices;
using System.Threading;
using #7hc;
using #Zmb;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.Units.Formatters;
using StructurePoint.Products.Column.FailureSurface.Model;

namespace #vmb
{
	// Token: 0x02000440 RID: 1088
	internal sealed class #umb : NotifyPropertyChangedObjectBase, #3mb
	{
		// Token: 0x060027CB RID: 10187 RVA: 0x00024F89 File Offset: 0x00023189
		public #umb()
		{
			this.#l = new FloatingPointUnitValueFormatter(3);
			this.IsMouseCursorOnForcePoint = false;
			this.AreLoadPointsVisible = false;
		}

		// Token: 0x140000B6 RID: 182
		// (add) Token: 0x060027CC RID: 10188 RVA: 0x000DA168 File Offset: 0x000D8368
		// (remove) Token: 0x060027CD RID: 10189 RVA: 0x000DA1AC File Offset: 0x000D83AC
		public event EventHandler FailureSurfaceLoaded
		{
			[CompilerGenerated]
			add
			{
				EventHandler eventHandler = this.#b;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#b, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler eventHandler = this.#b;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#b, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x140000B7 RID: 183
		// (add) Token: 0x060027CE RID: 10190 RVA: 0x000DA1F0 File Offset: 0x000D83F0
		// (remove) Token: 0x060027CF RID: 10191 RVA: 0x000DA234 File Offset: 0x000D8434
		public event EventHandler ViewportCleaned
		{
			[CompilerGenerated]
			add
			{
				EventHandler eventHandler = this.#c;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#c, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler eventHandler = this.#c;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#c, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x140000B8 RID: 184
		// (add) Token: 0x060027D0 RID: 10192 RVA: 0x000DA278 File Offset: 0x000D8478
		// (remove) Token: 0x060027D1 RID: 10193 RVA: 0x000DA2BC File Offset: 0x000D84BC
		public event EventHandler ViewportPopulated
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

		// Token: 0x140000B9 RID: 185
		// (add) Token: 0x060027D2 RID: 10194 RVA: 0x000DA300 File Offset: 0x000D8500
		// (remove) Token: 0x060027D3 RID: 10195 RVA: 0x000DA344 File Offset: 0x000D8544
		public event EventHandler CursorEnteredLoadPoint
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

		// Token: 0x140000BA RID: 186
		// (add) Token: 0x060027D4 RID: 10196 RVA: 0x000DA388 File Offset: 0x000D8588
		// (remove) Token: 0x060027D5 RID: 10197 RVA: 0x000DA3CC File Offset: 0x000D85CC
		public event EventHandler CursorLeftLoadPoint
		{
			[CompilerGenerated]
			add
			{
				EventHandler eventHandler = this.#f;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#f, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler eventHandler = this.#f;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#f, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x140000BB RID: 187
		// (add) Token: 0x060027D6 RID: 10198 RVA: 0x000DA410 File Offset: 0x000D8610
		// (remove) Token: 0x060027D7 RID: 10199 RVA: 0x000DA454 File Offset: 0x000D8654
		public event EventHandler FailureSurfaceVisibilityChanged
		{
			[CompilerGenerated]
			add
			{
				EventHandler eventHandler = this.#g;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#g, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler eventHandler = this.#g;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#g, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x17000D47 RID: 3399
		// (get) Token: 0x060027D8 RID: 10200 RVA: 0x00024FAB File Offset: 0x000231AB
		// (set) Token: 0x060027D9 RID: 10201 RVA: 0x00024FB7 File Offset: 0x000231B7
		public FailureSurface FailureSurface
		{
			get
			{
				return this.#a;
			}
			set
			{
				if (this.#a != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107361453));
					this.#a = value;
					base.RaisePropertyChanged(#Phc.#3hc(107361453));
				}
			}
		}

		// Token: 0x17000D48 RID: 3400
		// (get) Token: 0x060027DA RID: 10202 RVA: 0x00024FF5 File Offset: 0x000231F5
		// (set) Token: 0x060027DB RID: 10203 RVA: 0x00025001 File Offset: 0x00023201
		public bool IsNominalSurfaceVisible { get; set; }

		// Token: 0x17000D49 RID: 3401
		// (get) Token: 0x060027DC RID: 10204 RVA: 0x00025012 File Offset: 0x00023212
		// (set) Token: 0x060027DD RID: 10205 RVA: 0x0002501E File Offset: 0x0002321E
		public bool IsFactoredSurfaceVisible { get; set; }

		// Token: 0x17000D4A RID: 3402
		// (get) Token: 0x060027DE RID: 10206 RVA: 0x0002502F File Offset: 0x0002322F
		// (set) Token: 0x060027DF RID: 10207 RVA: 0x0002503B File Offset: 0x0002323B
		public bool AreLoadPointsVisible { get; set; }

		// Token: 0x17000D4B RID: 3403
		// (get) Token: 0x060027E0 RID: 10208 RVA: 0x0002504C File Offset: 0x0002324C
		// (set) Token: 0x060027E1 RID: 10209 RVA: 0x00025058 File Offset: 0x00023258
		public IBoxDrawingResult TransparentBox { get; set; }

		// Token: 0x17000D4C RID: 3404
		// (get) Token: 0x060027E2 RID: 10210 RVA: 0x00025069 File Offset: 0x00023269
		public IUnitValueFormatter DefaultUnitValueFormatter { get; }

		// Token: 0x17000D4D RID: 3405
		// (get) Token: 0x060027E3 RID: 10211 RVA: 0x00025075 File Offset: 0x00023275
		// (set) Token: 0x060027E4 RID: 10212 RVA: 0x00025081 File Offset: 0x00023281
		public bool IsMouseCursorOnForcePoint { get; set; }

		// Token: 0x060027E5 RID: 10213 RVA: 0x000DA498 File Offset: 0x000D8698
		public void #omb(EventArgs #He)
		{
			EventHandler eventHandler = this.#b;
			if (eventHandler != null)
			{
				eventHandler(this, #He);
			}
		}

		// Token: 0x060027E6 RID: 10214 RVA: 0x000DA4C4 File Offset: 0x000D86C4
		public void #pmb(EventArgs #He)
		{
			EventHandler eventHandler = this.#c;
			if (eventHandler != null)
			{
				eventHandler(this, #He);
			}
		}

		// Token: 0x060027E7 RID: 10215 RVA: 0x000DA4F0 File Offset: 0x000D86F0
		public void #qmb(EventArgs #He)
		{
			EventHandler eventHandler = this.#d;
			if (eventHandler != null)
			{
				eventHandler(this, #He);
			}
		}

		// Token: 0x060027E8 RID: 10216 RVA: 0x000DA51C File Offset: 0x000D871C
		public void #rmb(EventArgs #He)
		{
			EventHandler eventHandler = this.#e;
			if (eventHandler != null)
			{
				eventHandler(this, #He);
			}
		}

		// Token: 0x060027E9 RID: 10217 RVA: 0x000DA548 File Offset: 0x000D8748
		public void #smb(EventArgs #He)
		{
			EventHandler eventHandler = this.#f;
			if (eventHandler != null)
			{
				eventHandler(this, #He);
			}
		}

		// Token: 0x060027EA RID: 10218 RVA: 0x000DA574 File Offset: 0x000D8774
		public void #tmb(EventArgs #He)
		{
			EventHandler eventHandler = this.#g;
			if (eventHandler != null)
			{
				eventHandler(this, #He);
			}
		}

		// Token: 0x04000FBC RID: 4028
		private FailureSurface #a;

		// Token: 0x04000FBD RID: 4029
		[CompilerGenerated]
		private EventHandler #b;

		// Token: 0x04000FBE RID: 4030
		[CompilerGenerated]
		private EventHandler #c;

		// Token: 0x04000FBF RID: 4031
		[CompilerGenerated]
		private EventHandler #d;

		// Token: 0x04000FC0 RID: 4032
		[CompilerGenerated]
		private EventHandler #e;

		// Token: 0x04000FC1 RID: 4033
		[CompilerGenerated]
		private EventHandler #f;

		// Token: 0x04000FC2 RID: 4034
		[CompilerGenerated]
		private EventHandler #g;

		// Token: 0x04000FC3 RID: 4035
		[CompilerGenerated]
		private bool #h;

		// Token: 0x04000FC4 RID: 4036
		[CompilerGenerated]
		private bool #i;

		// Token: 0x04000FC5 RID: 4037
		[CompilerGenerated]
		private bool #j;

		// Token: 0x04000FC6 RID: 4038
		[CompilerGenerated]
		private IBoxDrawingResult #k;

		// Token: 0x04000FC7 RID: 4039
		[CompilerGenerated]
		private readonly IUnitValueFormatter #l;

		// Token: 0x04000FC8 RID: 4040
		[CompilerGenerated]
		private bool #m;
	}
}
