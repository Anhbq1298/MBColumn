using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Threading;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace #ezc
{
	// Token: 0x02000B3C RID: 2876
	internal sealed class #6zc : IDisposable
	{
		// Token: 0x06005E03 RID: 24067 RVA: 0x00176618 File Offset: 0x00174818
		public #6zc(ApartmentState #7zc)
		{
			this.#a = new Thread(new ThreadStart(this.#5zc), 5242880);
			this.#a.SetApartmentState(#7zc);
			this.#b = new ManualResetEvent(false);
			this.#c = new ManualResetEvent(true);
		}

		// Token: 0x17001AC4 RID: 6852
		// (get) Token: 0x06005E04 RID: 24068 RVA: 0x0004E4F7 File Offset: 0x0004C6F7
		// (set) Token: 0x06005E05 RID: 24069 RVA: 0x0004E4FF File Offset: 0x0004C6FF
		public bool IsExecuting { get; private set; }

		// Token: 0x06005E06 RID: 24070 RVA: 0x0004E508 File Offset: 0x0004C708
		public void #Kn()
		{
			Thread thread = this.#a;
			if (!false)
			{
				thread.Start();
			}
		}

		// Token: 0x06005E07 RID: 24071 RVA: 0x0004E51B File Offset: 0x0004C71B
		public void #3zc()
		{
			Thread thread = this.#a;
			if (!false)
			{
				thread.Abort();
			}
		}

		// Token: 0x06005E08 RID: 24072 RVA: 0x0017666C File Offset: 0x0017486C
		public void #0(Action #nd)
		{
			string #R0d = #Phc.#3hc(107351365);
			Component #x6c = Component.Infrastructure;
			string #Qic = #Phc.#3hc(107420002);
			if (4 != 0)
			{
				#X0d.#V0d(#nd, #R0d, #x6c, #Qic);
			}
			if (this.IsExecuting)
			{
				throw new InvalidOperationException();
			}
			this.#d = #nd;
			this.#c.Reset();
			this.#b.Set();
		}

		// Token: 0x06005E09 RID: 24073 RVA: 0x0004E52E File Offset: 0x0004C72E
		public void #4zc()
		{
			this.#c.WaitOne();
		}

		// Token: 0x06005E0A RID: 24074 RVA: 0x001766CC File Offset: 0x001748CC
		private void #5zc()
		{
			for (;;)
			{
				bool flag = this.#b.WaitOne();
				if (8 != 0)
				{
					flag = false;
				}
				bool flag2 = flag;
				try
				{
					bool #f = true;
					if (5 != 0)
					{
						this.IsExecuting = #f;
					}
					Action action = this.#d;
					Action action2;
					if (true)
					{
						action2 = action;
					}
					if (action2 != null)
					{
						if (!false)
						{
							bool flag3 = true;
							if (!false)
							{
								flag2 = flag3;
							}
						}
						Action action3 = action2;
						if (!false)
						{
							action3();
						}
					}
				}
				finally
				{
					this.#b.Reset();
					this.IsExecuting = false;
					bool flag4 = flag2;
					while (flag4)
					{
						flag4 = this.#c.Set();
						if (5 != 0)
						{
							break;
						}
					}
				}
			}
		}

		// Token: 0x06005E0B RID: 24075 RVA: 0x00176758 File Offset: 0x00174958
		[SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
		protected void #1(bool #POb)
		{
			if (4 != 0 && #POb)
			{
				try
				{
					if (6 != 0)
					{
						this.#3zc();
					}
				}
				catch (Exception)
				{
				}
				if (!false)
				{
					WaitHandle waitHandle = this.#c;
					if (!false)
					{
						waitHandle.Dispose();
					}
					WaitHandle waitHandle2 = this.#b;
					if (!false)
					{
						waitHandle2.Dispose();
					}
				}
			}
		}

		// Token: 0x06005E0C RID: 24076 RVA: 0x0004E53C File Offset: 0x0004C73C
		public void #1()
		{
			bool #POb = true;
			if (!false)
			{
				this.#1(#POb);
			}
			if (!false)
			{
				GC.SuppressFinalize(this);
			}
		}

		// Token: 0x040026FD RID: 9981
		private readonly Thread #a;

		// Token: 0x040026FE RID: 9982
		private readonly ManualResetEvent #b;

		// Token: 0x040026FF RID: 9983
		private readonly ManualResetEvent #c;

		// Token: 0x04002700 RID: 9984
		private Action #d;

		// Token: 0x04002701 RID: 9985
		[CompilerGenerated]
		private bool #e;
	}
}
