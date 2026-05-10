using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using #7hc;
using #8Cc;
using #jDc;
using #UYd;
using Newtonsoft.Json;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.Framework.Collections;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace #TCc
{
	// Token: 0x02000B63 RID: 2915
	internal class #YCc : NotifyPropertyChangedObjectBase, #9Cc
	{
		// Token: 0x17001AFE RID: 6910
		// (get) Token: 0x06005F23 RID: 24355 RVA: 0x0004EED2 File Offset: 0x0004D0D2
		// (set) Token: 0x06005F24 RID: 24356 RVA: 0x0004EEDA File Offset: 0x0004D0DA
		public bool UndoEnabled { get; set; }

		// Token: 0x17001AFF RID: 6911
		// (get) Token: 0x06005F25 RID: 24357 RVA: 0x0004EEE3 File Offset: 0x0004D0E3
		[JsonIgnore]
		public #bDc UndoManager
		{
			get
			{
				return #2Cc.#vZ(base.GetType());
			}
		}

		// Token: 0x06005F26 RID: 24358 RVA: 0x0004EEF0 File Offset: 0x0004D0F0
		protected virtual void #OCc(object #Zr, object #0r, [CallerMemberName] string #em = null)
		{
			if (!false)
			{
				base.RaisePropertyChanging(#em);
			}
		}

		// Token: 0x06005F27 RID: 24359 RVA: 0x0004EF00 File Offset: 0x0004D100
		protected virtual void #PCc(object #Zr, object #0r, [CallerMemberName] string #em = null)
		{
			do
			{
				if (this.UndoEnabled)
				{
					if (8 == 0)
					{
						continue;
					}
					#bDc #bDc = this.UndoManager;
					#qDc #nd = new #BDc(this, #em, #Zr, #0r);
					if (2 != 0)
					{
						#bDc.#xCc(#nd);
					}
				}
				do
				{
					if (true)
					{
						base.RaisePropertyChanged(#em);
					}
				}
				while (3 == 0);
			}
			while (false);
		}

		// Token: 0x06005F28 RID: 24360 RVA: 0x001786F0 File Offset: 0x001768F0
		protected virtual void #QCc<#Fu>(CustomObservableCollection<#Fu> #Du) where #Fu : class
		{
			do
			{
				string #R0d = #Phc.#3hc(107420761);
				Component #x6c = Component.GUIFramework;
				string #Qic = #Phc.#3hc(107418087);
				if (!false)
				{
					#X0d.#V0d(#Du, #R0d, #x6c, #Qic);
				}
			}
			while (false);
			NotifyCollectionChangedEventHandler #f = new NotifyCollectionChangedEventHandler(this.#XCc<#Fu>);
			if (!false)
			{
				#Du.CollectionChanged -= #f;
			}
			NotifyCollectionChangedEventHandler #f2 = new NotifyCollectionChangedEventHandler(this.#XCc<#Fu>);
			if (3 != 0)
			{
				#Du.CollectionChanged += #f2;
			}
		}

		// Token: 0x06005F29 RID: 24361 RVA: 0x0004EF3C File Offset: 0x0004D13C
		protected virtual void #WCc<#Fu>(CustomObservableCollection<#Fu> #Du) where #Fu : class
		{
			string #R0d = #Phc.#3hc(107420761);
			Component #x6c = Component.GUIFramework;
			string #Qic = #Phc.#3hc(107418066);
			if (8 != 0)
			{
				#X0d.#V0d(#Du, #R0d, #x6c, #Qic);
			}
			NotifyCollectionChangedEventHandler #f = new NotifyCollectionChangedEventHandler(this.#XCc<#Fu>);
			if (!false)
			{
				#Du.CollectionChanged -= #f;
			}
		}

		// Token: 0x06005F2A RID: 24362 RVA: 0x00178758 File Offset: 0x00176958
		private void #XCc<#Fu>(object #Ge, NotifyCollectionChangedEventArgs #He) where #Fu : class
		{
			if (4 != 0 && this.UndoEnabled)
			{
				#oDc<#Fu> #oDc = new #oDc<!!0>(this, #Ge as Collection<!!0>, #He);
				#oDc<#Fu> #oDc2;
				if (!false)
				{
					#oDc2 = #oDc;
				}
				#bDc #bDc = this.UndoManager;
				#qDc #nd = #oDc2;
				if (!false)
				{
					#bDc.#xCc(#nd);
				}
			}
		}

		// Token: 0x04002751 RID: 10065
		[CompilerGenerated]
		private bool #a;
	}
}
