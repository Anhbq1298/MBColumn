using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Runtime.CompilerServices;
using #7hc;
using #8Cc;
using #UYd;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace #jDc
{
	// Token: 0x02000B6E RID: 2926
	internal sealed class #oDc<#Fu> : #qDc where #Fu : class
	{
		// Token: 0x06005F4C RID: 24396 RVA: 0x00178A6C File Offset: 0x00176C6C
		public #oDc(#9Cc #pDc, IList<#Fu> #Du, NotifyCollectionChangedEventArgs #Lg)
		{
			#X0d.#V0d(#pDc, #Phc.#3hc(107417296), Component.GUIFramework, #Phc.#3hc(107417275));
			#X0d.#V0d(#Du, #Phc.#3hc(107420761), Component.GUIFramework, #Phc.#3hc(107417190));
			#X0d.#V0d(#Lg, #Phc.#3hc(107417169), Component.GUIFramework, #Phc.#3hc(107417128));
			this.Undoable = #pDc;
			this.Collection = #Du;
			this.Args = #Lg;
			this.Sequence = #iDc.#hDc();
		}

		// Token: 0x17001B05 RID: 6917
		// (get) Token: 0x06005F4D RID: 24397 RVA: 0x0004F115 File Offset: 0x0004D315
		public #9Cc Undoable { get; }

		// Token: 0x17001B06 RID: 6918
		// (get) Token: 0x06005F4E RID: 24398 RVA: 0x0004F11D File Offset: 0x0004D31D
		public IList<#Fu> Collection { get; }

		// Token: 0x17001B07 RID: 6919
		// (get) Token: 0x06005F4F RID: 24399 RVA: 0x0004F125 File Offset: 0x0004D325
		public NotifyCollectionChangedEventArgs Args { get; }

		// Token: 0x17001B08 RID: 6920
		// (get) Token: 0x06005F50 RID: 24400 RVA: 0x0004F12D File Offset: 0x0004D32D
		public long Sequence { get; }

		// Token: 0x06005F51 RID: 24401 RVA: 0x00178AF4 File Offset: 0x00176CF4
		public void #zCc()
		{
			#9Cc #9Cc = this.Undoable;
			bool #f = false;
			if (8 != 0)
			{
				#9Cc.UndoEnabled = #f;
			}
			if (this.Args.Action == NotifyCollectionChangedAction.Add)
			{
				int newStartingIndex = this.Args.NewStartingIndex;
				int num;
				if (!false)
				{
					num = newStartingIndex;
				}
				IEnumerator enumerator = this.Args.NewItems.GetEnumerator();
				IEnumerator enumerator2;
				if (!false)
				{
					enumerator2 = enumerator;
				}
				try
				{
					while (enumerator2.MoveNext())
					{
						object obj = enumerator2.Current;
						#Fu #Fu = (!0)((object)obj);
						#Fu #Fu2;
						if (5 != 0)
						{
							#Fu2 = #Fu;
						}
						IList<!0> list = this.Collection;
						int num2 = num;
						int num3 = num2 + 1;
						if (!false)
						{
							num = num3;
						}
						!0 item = #Fu2;
						if (4 != 0)
						{
							list.Insert(num2, item);
						}
					}
					goto IL_ED;
				}
				finally
				{
					IDisposable disposable = enumerator2 as IDisposable;
					if (disposable != null)
					{
						disposable.Dispose();
					}
				}
			}
			if (this.Args.Action == NotifyCollectionChangedAction.Remove)
			{
				using (IEnumerator enumerator2 = this.Args.OldItems.GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						if (!false)
						{
							#Fu item2 = (!0)((object)enumerator2.Current);
							this.Collection.Remove(item2);
						}
					}
				}
			}
			IL_ED:
			this.Undoable.UndoEnabled = true;
		}

		// Token: 0x06005F52 RID: 24402 RVA: 0x00178C2C File Offset: 0x00176E2C
		public void #yCc(#aDc #ri)
		{
			#9Cc #9Cc = this.Undoable;
			bool #f = false;
			if (!false)
			{
				#9Cc.UndoEnabled = #f;
			}
			IEnumerator enumerator2;
			if (this.Args.Action == NotifyCollectionChangedAction.Add)
			{
				IEnumerator enumerator = this.Args.NewItems.GetEnumerator();
				if (!false)
				{
					enumerator2 = enumerator;
				}
				try
				{
					for (;;)
					{
						#Fu item;
						if (2 != 0)
						{
							if (!enumerator2.MoveNext())
							{
								break;
							}
							#Fu #Fu = (!0)((object)enumerator2.Current);
							if (8 != 0)
							{
								item = #Fu;
							}
						}
						this.Collection.Remove(item);
					}
					goto IL_E8;
				}
				finally
				{
					IDisposable disposable = enumerator2 as IDisposable;
					if (disposable != null)
					{
						disposable.Dispose();
					}
				}
			}
			if (this.Args.Action == NotifyCollectionChangedAction.Remove)
			{
				int oldStartingIndex = this.Args.OldStartingIndex;
				int num;
				if (!false)
				{
					num = oldStartingIndex;
				}
				IEnumerator enumerator3 = this.Args.OldItems.GetEnumerator();
				if (!false)
				{
					enumerator2 = enumerator3;
				}
				try
				{
					while (enumerator2.MoveNext())
					{
						object obj = enumerator2.Current;
						#Fu #Fu2 = (!0)((object)obj);
						#Fu item2;
						if (4 != 0)
						{
							item2 = #Fu2;
						}
						this.Collection.Insert(num++, item2);
					}
				}
				finally
				{
					IDisposable disposable = enumerator2 as IDisposable;
					if (disposable != null)
					{
						disposable.Dispose();
					}
				}
			}
			IL_E8:
			this.Undoable.UndoEnabled = true;
		}

		// Token: 0x06005F53 RID: 24403 RVA: 0x0004F135 File Offset: 0x0004D335
		public string #h()
		{
			return string.Format(CultureInfo.InvariantCulture, #Phc.#3hc(107417107), new object[]
			{
				this.Args.Action
			});
		}

		// Token: 0x0400275E RID: 10078
		[CompilerGenerated]
		private readonly #9Cc #a;

		// Token: 0x0400275F RID: 10079
		[CompilerGenerated]
		private readonly IList<#Fu> #b;

		// Token: 0x04002760 RID: 10080
		[CompilerGenerated]
		private readonly NotifyCollectionChangedEventArgs #c;

		// Token: 0x04002761 RID: 10081
		[CompilerGenerated]
		private readonly long #d;
	}
}
