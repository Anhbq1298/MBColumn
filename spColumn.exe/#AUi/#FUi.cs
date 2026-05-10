using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using #v1c;
using #yUi;
using StructurePoint.Products.Column.BatchExecution;

namespace #AUi
{
	// Token: 0x020006EB RID: 1771
	internal sealed class #FUi
	{
		// Token: 0x06003AD4 RID: 15060 RVA: 0x000330B0 File Offset: 0x000312B0
		public #FUi(#v2c #4x)
		{
			this.#a = #4x;
		}

		// Token: 0x140000D8 RID: 216
		// (add) Token: 0x06003AD5 RID: 15061 RVA: 0x00115EFC File Offset: 0x001140FC
		// (remove) Token: 0x06003AD6 RID: 15062 RVA: 0x00115F40 File Offset: 0x00114140
		public event EventHandler<#TUi> Progress
		{
			[CompilerGenerated]
			add
			{
				EventHandler<#TUi> eventHandler = this.#c;
				EventHandler<#TUi> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#TUi> value2 = (EventHandler<#TUi>)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#TUi>>(ref this.#c, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<#TUi> eventHandler = this.#c;
				EventHandler<#TUi> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#TUi> value2 = (EventHandler<#TUi>)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#TUi>>(ref this.#c, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x06003AD7 RID: 15063 RVA: 0x00115F84 File Offset: 0x00114184
		public Task #0(IEnumerable<BatchItemViewModel> #vUi, #SUi #Pc)
		{
			#FUi.#XVi #XVi;
			#XVi.#b = AsyncTaskMethodBuilder.Create();
			#XVi.#d = this;
			#XVi.#e = #vUi;
			#XVi.#c = #Pc;
			#XVi.#a = -1;
			#XVi.#b.Start<#FUi.#XVi>(ref #XVi);
			return #XVi.#b.Task;
		}

		// Token: 0x06003AD8 RID: 15064 RVA: 0x000330CA File Offset: 0x000312CA
		protected void #DUi(#TUi #He)
		{
			EventHandler<#TUi> eventHandler = this.#c;
			if (eventHandler == null)
			{
				return;
			}
			eventHandler(this, #He);
		}

		// Token: 0x06003AD9 RID: 15065 RVA: 0x00115FE4 File Offset: 0x001141E4
		private void #EUi(#SUi #Pc)
		{
			if (!#Pc.CancellationTokenSource.IsCancellationRequested && this.#b.Any<BatchItemViewModel>() && !string.IsNullOrWhiteSpace(#Pc.SummaryPath))
			{
				#ep #ep = new #ep();
				#ep.BatchItems.AddRange(this.#b);
				using (Stream stream = this.#a.#T1c(#Pc.SummaryPath))
				{
					BatchSummaryWriter.#fp(#ep, stream);
				}
			}
		}

		// Token: 0x0400190B RID: 6411
		private readonly #v2c #a;

		// Token: 0x0400190C RID: 6412
		private readonly List<BatchItemViewModel> #b = new List<BatchItemViewModel>();

		// Token: 0x0400190D RID: 6413
		[CompilerGenerated]
		private EventHandler<#TUi> #c;

		// Token: 0x020006EC RID: 1772
		[CompilerGenerated]
		private sealed class #ITb
		{
			// Token: 0x06003ADB RID: 15067 RVA: 0x00116074 File Offset: 0x00114274
			internal void #bVb(BatchItemViewModel #Rf)
			{
				if (!#Rf.IsProcessed)
				{
					#Rf.#0(this.#a.ExecutionParameters);
					if (#Rf.IsProcessed)
					{
						Interlocked.Increment(ref this.#b);
					}
					this.#c.#DUi(new #TUi(this.#b, this.#c.#b.Count));
				}
			}

			// Token: 0x0400190E RID: 6414
			public #SUi #a;

			// Token: 0x0400190F RID: 6415
			public int #b;

			// Token: 0x04001910 RID: 6416
			public #FUi #c;
		}
	}
}
