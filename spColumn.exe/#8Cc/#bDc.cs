using System;
using System.ComponentModel;
using #gCc;
using #jDc;
using #N6c;

namespace #8Cc
{
	// Token: 0x02000B5A RID: 2906
	internal interface #bDc : INotifyPropertyChanged
	{
		// Token: 0x14000176 RID: 374
		// (add) Token: 0x06005ED8 RID: 24280
		// (remove) Token: 0x06005ED9 RID: 24281
		event EventHandler<#JCc> UndoStackChanged;

		// Token: 0x14000177 RID: 375
		// (add) Token: 0x06005EDA RID: 24282
		// (remove) Token: 0x06005EDB RID: 24283
		event EventHandler CompositeActionCompleted;

		// Token: 0x17001AE7 RID: 6887
		// (get) Token: 0x06005EDC RID: 24284
		// (set) Token: 0x06005EDD RID: 24285
		#dDc Owner { get; set; }

		// Token: 0x17001AE8 RID: 6888
		// (get) Token: 0x06005EDE RID: 24286
		bool CanUndo { get; }

		// Token: 0x17001AE9 RID: 6889
		// (get) Token: 0x06005EDF RID: 24287
		bool CanRedo { get; }

		// Token: 0x17001AEA RID: 6890
		// (get) Token: 0x06005EE0 RID: 24288
		#k8c<#qDc> UndoActions { get; }

		// Token: 0x17001AEB RID: 6891
		// (get) Token: 0x06005EE1 RID: 24289
		#k8c<#qDc> RedoActions { get; }

		// Token: 0x17001AEC RID: 6892
		// (get) Token: 0x06005EE2 RID: 24290
		// (set) Token: 0x06005EE3 RID: 24291
		bool IsEnabled { get; set; }

		// Token: 0x17001AED RID: 6893
		// (get) Token: 0x06005EE4 RID: 24292
		bool CanPushMementoActions { get; }

		// Token: 0x17001AEE RID: 6894
		// (get) Token: 0x06005EE5 RID: 24293
		long TransactionDepth { get; }

		// Token: 0x17001AEF RID: 6895
		// (get) Token: 0x06005EE6 RID: 24294
		#FCc TransactionInfo { get; }

		// Token: 0x06005EE7 RID: 24295
		void #yl();

		// Token: 0x06005EE8 RID: 24296
		void #uCc();

		// Token: 0x06005EE9 RID: 24297
		void #vCc();

		// Token: 0x06005EEA RID: 24298
		void #xCc(#qDc #nd);

		// Token: 0x06005EEB RID: 24299
		void #yCc(#aDc #ri = #aDc.#b);

		// Token: 0x06005EEC RID: 24300
		void #zCc();

		// Token: 0x06005EED RID: 24301
		void #yCc(bool #ACc);

		// Token: 0x06005EEE RID: 24302
		void #wCc();

		// Token: 0x06005EEF RID: 24303
		IDisposable #AA();
	}
}
