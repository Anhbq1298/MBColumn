using System;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using #7hc;
using #8Cc;
using #jDc;
using StructurePoint.CoreAssets.GUI.Framework.Collections;

namespace #TCc
{
	// Token: 0x02000B62 RID: 2914
	internal sealed class #SCc : #YCc
	{
		// Token: 0x06005F1E RID: 24350 RVA: 0x001785A8 File Offset: 0x001767A8
		protected override void #OCc(object #Zr, object #0r, [CallerMemberName] string #em = null)
		{
			if (base.UndoManager == null)
			{
				goto IL_55;
			}
			if (2 == 0)
			{
				goto IL_34;
			}
			if (!base.UndoManager.CanPushMementoActions)
			{
				goto IL_55;
			}
			IL_18:
			if (!base.UndoEnabled)
			{
				goto IL_55;
			}
			IL_20:
			#cDc #cDc = base.UndoManager.Owner.#oi();
			#cDc #qi;
			if (-1 != 0)
			{
				#qi = #cDc;
			}
			IL_34:
			#xDc #xDc = new #xDc(base.UndoManager.Owner, #qi);
			#xDc #xDc2;
			if (!false)
			{
				#xDc2 = #xDc;
			}
			#bDc #bDc = base.UndoManager;
			#qDc #nd = #xDc2;
			if (!false)
			{
				#bDc.#xCc(#nd);
			}
			IL_55:
			if (false)
			{
				goto IL_18;
			}
			if (!false)
			{
				base.RaisePropertyChanging(#em);
			}
			if (5 != 0)
			{
				return;
			}
			goto IL_20;
		}

		// Token: 0x06005F1F RID: 24351 RVA: 0x0004EEBA File Offset: 0x0004D0BA
		protected override void #PCc(object #Zr, object #0r, [CallerMemberName] string #em = null)
		{
			if (!false)
			{
				base.RaisePropertyChanged(#em);
			}
		}

		// Token: 0x06005F20 RID: 24352 RVA: 0x0017862C File Offset: 0x0017682C
		protected override void #QCc<#Fu>(CustomObservableCollection<#Fu> #Du)
		{
			while (#Du != null)
			{
				NotifyCollectionChangedEventHandler #f = new NotifyCollectionChangedEventHandler(this.#RCc);
				if (!false)
				{
					#Du.CollectionChanging -= #f;
				}
				if (3 != 0)
				{
					NotifyCollectionChangedEventHandler #f2 = new NotifyCollectionChangedEventHandler(this.#RCc);
					if (!false)
					{
						#Du.CollectionChanging += #f2;
					}
					if (7 != 0)
					{
						return;
					}
				}
			}
			throw new ArgumentNullException(#Phc.#3hc(107420761));
		}

		// Token: 0x06005F21 RID: 24353 RVA: 0x00178684 File Offset: 0x00176884
		private void #RCc(object #Ge, NotifyCollectionChangedEventArgs #He)
		{
			if (base.UndoManager != null && base.UndoManager.CanPushMementoActions && base.UndoEnabled)
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
		}
	}
}
