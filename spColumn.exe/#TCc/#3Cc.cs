using System;
using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using #7hc;
using #8Cc;
using #jDc;
using #UYd;
using StructurePoint.CoreAssets.GUI.Framework.Collections;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace #TCc
{
	// Token: 0x02000B67 RID: 2919
	internal abstract class #3Cc : #6Cc
	{
		// Token: 0x06005F33 RID: 24371 RVA: 0x0004EFD6 File Offset: 0x0004D1D6
		protected #3Cc(#bDc #DJ) : base(#DJ)
		{
		}

		// Token: 0x06005F34 RID: 24372 RVA: 0x00178884 File Offset: 0x00176A84
		[SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed")]
		protected override void #OCc(object #Zr, object #0r, [CallerMemberName] string #em = null)
		{
			if (base.UndoManager.CanPushMementoActions && base.UndoEnabled)
			{
				#cDc #cDc = base.UndoManager.Owner.#oi();
				#cDc #qi;
				if (!false)
				{
					#qi = #cDc;
				}
				#xDc #xDc = new #xDc(base.UndoManager.Owner, #qi);
				#xDc #xDc2;
				if (!false)
				{
					#xDc2 = #xDc;
				}
				#bDc #bDc = base.UndoManager;
				#qDc #nd = #xDc2;
				if (7 != 0)
				{
					#bDc.#xCc(#nd);
				}
			}
			if (6 != 0)
			{
				base.RaisePropertyChanging(#em);
			}
		}

		// Token: 0x06005F35 RID: 24373 RVA: 0x0004EEBA File Offset: 0x0004D0BA
		[SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed")]
		protected override void #PCc(object #Zr, object #0r, [CallerMemberName] string #em = null)
		{
			if (!false)
			{
				base.RaisePropertyChanged(#em);
			}
		}

		// Token: 0x06005F36 RID: 24374 RVA: 0x001788F8 File Offset: 0x00176AF8
		protected override void #QCc<#Fu>(CustomObservableCollection<#Fu> #Du)
		{
			do
			{
				string #R0d = #Phc.#3hc(107420761);
				Component #x6c = Component.GUIFramework;
				string #Qic = #Phc.#3hc(107417914);
				if (!false)
				{
					#X0d.#V0d(#Du, #R0d, #x6c, #Qic);
				}
			}
			while (false);
			NotifyCollectionChangedEventHandler #f = new NotifyCollectionChangedEventHandler(this.#RCc);
			if (!false)
			{
				#Du.CollectionChanging -= #f;
			}
			NotifyCollectionChangedEventHandler #f2 = new NotifyCollectionChangedEventHandler(this.#RCc);
			if (3 != 0)
			{
				#Du.CollectionChanging += #f2;
			}
		}

		// Token: 0x06005F37 RID: 24375 RVA: 0x00178960 File Offset: 0x00176B60
		private void #RCc(object #Ge, NotifyCollectionChangedEventArgs #He)
		{
			if (base.UndoManager.CanPushMementoActions && base.UndoEnabled)
			{
				#cDc #cDc = base.UndoManager.Owner.#oi();
				#cDc #qi;
				if (!false)
				{
					#qi = #cDc;
				}
				#xDc #xDc = new #xDc(base.UndoManager.Owner, #qi);
				#xDc #xDc2;
				if (8 != 0)
				{
					#xDc2 = #xDc;
				}
				#bDc #bDc = base.UndoManager;
				#qDc #nd = #xDc2;
				if (!false)
				{
					#bDc.#xCc(#nd);
				}
			}
		}
	}
}
