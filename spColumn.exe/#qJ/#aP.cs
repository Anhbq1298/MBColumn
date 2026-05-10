using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using #7hc;
using #eU;
using #gfe;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.Templates.Engine.DTO;
using StructurePoint.CoreAssets.Column.Core.Templates.Rendering;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.Products.Column.Model;
using StructurePoint.Products.Column.Model.Entities;

namespace #qJ
{
	// Token: 0x020002BD RID: 701
	internal sealed class #aP : NotifyPropertyChangedObjectBase, #oW
	{
		// Token: 0x0600184A RID: 6218 RVA: 0x000B61B8 File Offset: 0x000B43B8
		public #aP(#9V #bP)
		{
			if (#bP == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107401986));
			}
			this.#a = #bP;
			this.Model = new ColumnModel();
		}

		// Token: 0x14000038 RID: 56
		// (add) Token: 0x0600184B RID: 6219 RVA: 0x000B6208 File Offset: 0x000B4408
		// (remove) Token: 0x0600184C RID: 6220 RVA: 0x000B624C File Offset: 0x000B444C
		public event EventHandler<#7V> ModelChanged
		{
			[CompilerGenerated]
			add
			{
				EventHandler<#7V> eventHandler = this.#e;
				EventHandler<#7V> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#7V> value2 = (EventHandler<#7V>)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#7V>>(ref this.#e, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<#7V> eventHandler = this.#e;
				EventHandler<#7V> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#7V> value2 = (EventHandler<#7V>)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#7V>>(ref this.#e, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x14000039 RID: 57
		// (add) Token: 0x0600184D RID: 6221 RVA: 0x000B6290 File Offset: 0x000B4490
		// (remove) Token: 0x0600184E RID: 6222 RVA: 0x000B62D4 File Offset: 0x000B44D4
		public event EventHandler<#7V> ModelChanging
		{
			[CompilerGenerated]
			add
			{
				EventHandler<#7V> eventHandler = this.#f;
				EventHandler<#7V> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#7V> value2 = (EventHandler<#7V>)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#7V>>(ref this.#f, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<#7V> eventHandler = this.#f;
				EventHandler<#7V> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#7V> value2 = (EventHandler<#7V>)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#7V>>(ref this.#f, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x17000900 RID: 2304
		// (get) Token: 0x0600184F RID: 6223 RVA: 0x00018B2A File Offset: 0x00016D2A
		// (set) Token: 0x06001850 RID: 6224 RVA: 0x000B6318 File Offset: 0x000B4518
		public ColumnModel Model
		{
			get
			{
				return this.#b;
			}
			private set
			{
				if (value == null)
				{
					throw new ArgumentNullException(#Phc.#3hc(107386484), #Phc.#3hc(107402005).#z2d());
				}
				if (this.#b != value)
				{
					this.#b = value;
					base.RaisePropertyChanged(#Phc.#3hc(107407457));
				}
			}
		}

		// Token: 0x17000901 RID: 2305
		// (get) Token: 0x06001851 RID: 6225 RVA: 0x00018B36 File Offset: 0x00016D36
		// (set) Token: 0x06001852 RID: 6226 RVA: 0x00018B42 File Offset: 0x00016D42
		public bool IsChangingModel
		{
			get
			{
				return this.#c;
			}
			private set
			{
				if (this.#c != value)
				{
					this.#c = value;
					base.RaisePropertyChanged(#Phc.#3hc(107401460));
				}
			}
		}

		// Token: 0x17000902 RID: 2306
		// (get) Token: 0x06001853 RID: 6227 RVA: 0x00018B70 File Offset: 0x00016D70
		// (set) Token: 0x06001854 RID: 6228 RVA: 0x00018B7C File Offset: 0x00016D7C
		public bool IsChangingModelExtended { get; set; }

		// Token: 0x17000903 RID: 2307
		// (get) Token: 0x06001855 RID: 6229 RVA: 0x00018B8D File Offset: 0x00016D8D
		// (set) Token: 0x06001856 RID: 6230 RVA: 0x00018B99 File Offset: 0x00016D99
		public string LoadedFilePath { get; set; }

		// Token: 0x17000904 RID: 2308
		// (get) Token: 0x06001857 RID: 6231 RVA: 0x00018BAA File Offset: 0x00016DAA
		// (set) Token: 0x06001858 RID: 6232 RVA: 0x000B6374 File Offset: 0x000B4574
		public string LoadedTemplateName
		{
			get
			{
				return this.#d;
			}
			set
			{
				if (this.#d != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107401439));
					this.#d = value;
					base.RaisePropertyChanged(#Phc.#3hc(107401439));
				}
			}
		}

		// Token: 0x17000905 RID: 2309
		// (get) Token: 0x06001859 RID: 6233 RVA: 0x00018BB6 File Offset: 0x00016DB6
		public #LO Metadata { get; }

		// Token: 0x17000906 RID: 2310
		// (get) Token: 0x0600185A RID: 6234 RVA: 0x00018BC2 File Offset: 0x00016DC2
		// (set) Token: 0x0600185B RID: 6235 RVA: 0x00018BCE File Offset: 0x00016DCE
		public TemplateExecutionResult TemplateExecutionResult { get; set; }

		// Token: 0x0600185C RID: 6236 RVA: 0x000B63C4 File Offset: 0x000B45C4
		public void #2O()
		{
			this.LoadedTemplateName = ((this.Model.Options.SectionType == SectionType.IrregularTemplate && this.#b.TemplateData.TemplateDefinition != null) ? this.#b.TemplateData.TemplateDefinition.DisplayName.#ofe(#Phc.#3hc(107401382)) : null);
		}

		// Token: 0x0600185D RID: 6237 RVA: 0x00018BDF File Offset: 0x00016DDF
		public void #1Uh(ShapeModel #rP)
		{
			this.Model.#1Uh(#rP);
		}

		// Token: 0x0600185E RID: 6238 RVA: 0x00018BF9 File Offset: 0x00016DF9
		public void #3O()
		{
			this.Model.#3O();
		}

		// Token: 0x17000907 RID: 2311
		// (get) Token: 0x0600185F RID: 6239 RVA: 0x00018C12 File Offset: 0x00016E12
		public List<ZoneInfo> TemplateZoneInfos { get; }

		// Token: 0x06001860 RID: 6240 RVA: 0x00018C1E File Offset: 0x00016E1E
		public bool #5O()
		{
			return this.IsChangingModel || this.IsChangingModelExtended;
		}

		// Token: 0x06001861 RID: 6241 RVA: 0x000B6430 File Offset: 0x000B4630
		public bool #6O(ColumnStorageModel #7O, bool #xi)
		{
			if (#7O == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107401405));
			}
			ColumnModel columnModel = this.Model;
			if (#xi && ColumnModelHelper.#uC(this.#a, columnModel, #7O))
			{
				return false;
			}
			ColumnModel #ui = this.#a.#Pb(#7O);
			this.IsChangingModel = true;
			try
			{
				this.#9O(new #7V(columnModel, #ui, #xi));
				this.Model = #ui;
				this.#8O(new #7V(columnModel, #ui, #xi));
			}
			finally
			{
				this.IsChangingModel = false;
			}
			return true;
		}

		// Token: 0x06001862 RID: 6242 RVA: 0x00018C3C File Offset: 0x00016E3C
		protected void #8O(#7V #He)
		{
			EventHandler<#7V> eventHandler = this.#e;
			if (eventHandler == null)
			{
				return;
			}
			eventHandler(this, #He);
		}

		// Token: 0x06001863 RID: 6243 RVA: 0x00018C5C File Offset: 0x00016E5C
		protected void #9O(#7V #He)
		{
			EventHandler<#7V> eventHandler = this.#f;
			if (eventHandler == null)
			{
				return;
			}
			eventHandler(this, #He);
		}

		// Token: 0x0400094D RID: 2381
		private readonly #9V #a;

		// Token: 0x0400094E RID: 2382
		private ColumnModel #b;

		// Token: 0x0400094F RID: 2383
		private bool #c;

		// Token: 0x04000950 RID: 2384
		private string #d;

		// Token: 0x04000951 RID: 2385
		[CompilerGenerated]
		private EventHandler<#7V> #e;

		// Token: 0x04000952 RID: 2386
		[CompilerGenerated]
		private EventHandler<#7V> #f;

		// Token: 0x04000953 RID: 2387
		[CompilerGenerated]
		private bool #g;

		// Token: 0x04000954 RID: 2388
		[CompilerGenerated]
		private string #h;

		// Token: 0x04000955 RID: 2389
		[CompilerGenerated]
		private readonly #LO #i = new #LO();

		// Token: 0x04000956 RID: 2390
		[CompilerGenerated]
		private TemplateExecutionResult #j;

		// Token: 0x04000957 RID: 2391
		[CompilerGenerated]
		private readonly List<ZoneInfo> #k = new List<ZoneInfo>();
	}
}
