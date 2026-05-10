using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using #7hc;
using #8Cc;
using #jDc;
using #UYd;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.Framework.Collections;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace #TCc
{
	// Token: 0x02000B68 RID: 2920
	internal abstract class #6Cc : NotifyPropertyChangedObjectBase, #9Cc
	{
		// Token: 0x06005F38 RID: 24376 RVA: 0x0004EFDF File Offset: 0x0004D1DF
		protected #6Cc(#bDc #DJ)
		{
			#X0d.#V0d(#DJ, #Phc.#3hc(107404911), Component.GUIFramework, #Phc.#3hc(107417317));
			this.UndoManager = #DJ;
		}

		// Token: 0x17001B03 RID: 6915
		// (get) Token: 0x06005F39 RID: 24377 RVA: 0x0004F00A File Offset: 0x0004D20A
		// (set) Token: 0x06005F3A RID: 24378 RVA: 0x0004F012 File Offset: 0x0004D212
		public bool UndoEnabled { get; set; }

		// Token: 0x17001B04 RID: 6916
		// (get) Token: 0x06005F3B RID: 24379 RVA: 0x0004F01B File Offset: 0x0004D21B
		public #bDc UndoManager { get; }

		// Token: 0x06005F3C RID: 24380 RVA: 0x0004EEF0 File Offset: 0x0004D0F0
		protected virtual void #OCc(object #Zr, object #0r, [CallerMemberName] string #em = null)
		{
			if (!false)
			{
				base.RaisePropertyChanging(#em);
			}
		}

		// Token: 0x06005F3D RID: 24381 RVA: 0x0004F023 File Offset: 0x0004D223
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

		// Token: 0x06005F3E RID: 24382 RVA: 0x001789C4 File Offset: 0x00176BC4
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

		// Token: 0x06005F3F RID: 24383 RVA: 0x0004F05F File Offset: 0x0004D25F
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

		// Token: 0x06005F40 RID: 24384 RVA: 0x00178A2C File Offset: 0x00176C2C
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

		// Token: 0x04002755 RID: 10069
		[CompilerGenerated]
		private bool #a;

		// Token: 0x04002756 RID: 10070
		[CompilerGenerated]
		private readonly #bDc #b;
	}
}
