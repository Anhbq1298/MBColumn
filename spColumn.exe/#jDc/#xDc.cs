using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using #7hc;
using #8Cc;
using #UYd;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace #jDc
{
	// Token: 0x02000B70 RID: 2928
	internal sealed class #xDc : #qDc
	{
		// Token: 0x06005F57 RID: 24407 RVA: 0x00178D64 File Offset: 0x00176F64
		public #xDc(#dDc #yDc, #cDc #qi)
		{
			#X0d.#V0d(#yDc, #Phc.#3hc(107417586), Component.GUIFramework, #Phc.#3hc(107417537));
			#X0d.#V0d(#qi, #Phc.#3hc(107417484), Component.GUIFramework, #Phc.#3hc(107417503));
			this.MementoOwner = #yDc;
			this.Memento = #qi;
			this.Timestamp = DateTime.Now;
			this.Sequence = #iDc.#hDc();
		}

		// Token: 0x17001B0A RID: 6922
		// (get) Token: 0x06005F58 RID: 24408 RVA: 0x0004F164 File Offset: 0x0004D364
		// (set) Token: 0x06005F59 RID: 24409 RVA: 0x0004F16C File Offset: 0x0004D36C
		public #dDc MementoOwner { get; private set; }

		// Token: 0x17001B0B RID: 6923
		// (get) Token: 0x06005F5A RID: 24410 RVA: 0x0004F175 File Offset: 0x0004D375
		// (set) Token: 0x06005F5B RID: 24411 RVA: 0x0004F17D File Offset: 0x0004D37D
		public #cDc Memento { get; private set; }

		// Token: 0x17001B0C RID: 6924
		// (get) Token: 0x06005F5C RID: 24412 RVA: 0x0004F186 File Offset: 0x0004D386
		// (set) Token: 0x06005F5D RID: 24413 RVA: 0x0004F18E File Offset: 0x0004D38E
		public DateTime Timestamp { get; private set; }

		// Token: 0x17001B0D RID: 6925
		// (get) Token: 0x06005F5E RID: 24414 RVA: 0x0004F197 File Offset: 0x0004D397
		public long Sequence { get; }

		// Token: 0x06005F5F RID: 24415 RVA: 0x00178DD4 File Offset: 0x00176FD4
		public void #zCc()
		{
			if (4 != 0)
			{
				#cDc #cDc = this.Memento;
				#cDc #cDc2;
				if (!false)
				{
					#cDc2 = #cDc;
				}
				#cDc #f = this.MementoOwner.#oi();
				if (!false)
				{
					this.Memento = #f;
				}
				#dDc #dDc = this.MementoOwner;
				#cDc #qi = #cDc2;
				#aDc #ri = #aDc.#d;
				if (6 != 0)
				{
					#dDc.#pi(#qi, #ri);
				}
			}
		}

		// Token: 0x06005F60 RID: 24416 RVA: 0x00178E20 File Offset: 0x00177020
		public void #yCc(#aDc #ri)
		{
			if (4 != 0)
			{
				#cDc #cDc = this.Memento;
				#cDc #cDc2;
				if (!false)
				{
					#cDc2 = #cDc;
				}
				#cDc #f = this.MementoOwner.#oi();
				if (!false)
				{
					this.Memento = #f;
				}
				#dDc #dDc = this.MementoOwner;
				#cDc #qi = #cDc2;
				if (6 != 0)
				{
					#dDc.#pi(#qi, #ri);
				}
			}
		}

		// Token: 0x06005F61 RID: 24417 RVA: 0x0004F19F File Offset: 0x0004D39F
		public string #h()
		{
			return string.Format(CultureInfo.InvariantCulture, #Phc.#3hc(107417418), new object[]
			{
				this.Timestamp
			});
		}

		// Token: 0x04002762 RID: 10082
		[CompilerGenerated]
		private #dDc #a;

		// Token: 0x04002763 RID: 10083
		[CompilerGenerated]
		private #cDc #b;

		// Token: 0x04002764 RID: 10084
		[CompilerGenerated]
		private DateTime #c;

		// Token: 0x04002765 RID: 10085
		[CompilerGenerated]
		private readonly long #d;
	}
}
