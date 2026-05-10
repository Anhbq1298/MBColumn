using System;
using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;
using #7hc;
using #8Cc;
using #UYd;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace #jDc
{
	// Token: 0x02000B71 RID: 2929
	internal sealed class #BDc : #qDc
	{
		// Token: 0x06005F62 RID: 24418 RVA: 0x00178E6C File Offset: 0x0017706C
		public #BDc(#9Cc #CDc, string #em, object #Zr, object #0r)
		{
			#X0d.#V0d(#CDc, #Phc.#3hc(107417385), Component.GUIFramework, #Phc.#3hc(107417404));
			#X0d.#W0d(#em, #Phc.#3hc(107451548), Component.GUIFramework, #Phc.#3hc(107416807));
			this.Undoable = #CDc;
			this.PropertyName = #em;
			this.OldValue = #Zr;
			this.NewValue = #0r;
			this.Sequence = #iDc.#hDc();
		}

		// Token: 0x17001B0E RID: 6926
		// (get) Token: 0x06005F63 RID: 24419 RVA: 0x0004F1C9 File Offset: 0x0004D3C9
		public #9Cc Undoable { get; }

		// Token: 0x17001B0F RID: 6927
		// (get) Token: 0x06005F64 RID: 24420 RVA: 0x0004F1D1 File Offset: 0x0004D3D1
		public string PropertyName { get; }

		// Token: 0x17001B10 RID: 6928
		// (get) Token: 0x06005F65 RID: 24421 RVA: 0x0004F1D9 File Offset: 0x0004D3D9
		public object OldValue { get; }

		// Token: 0x17001B11 RID: 6929
		// (get) Token: 0x06005F66 RID: 24422 RVA: 0x0004F1E1 File Offset: 0x0004D3E1
		public object NewValue { get; }

		// Token: 0x17001B12 RID: 6930
		// (get) Token: 0x06005F67 RID: 24423 RVA: 0x0004F1E9 File Offset: 0x0004D3E9
		public long Sequence { get; }

		// Token: 0x06005F68 RID: 24424 RVA: 0x0004F1F1 File Offset: 0x0004D3F1
		public void #zCc()
		{
			object #f = this.NewValue;
			if (2 != 0)
			{
				this.#ADc(#f);
			}
		}

		// Token: 0x06005F69 RID: 24425 RVA: 0x0004F206 File Offset: 0x0004D406
		public void #yCc(#aDc #ri)
		{
			object #f = this.OldValue;
			if (2 != 0)
			{
				this.#ADc(#f);
			}
		}

		// Token: 0x06005F6A RID: 24426 RVA: 0x0004F21B File Offset: 0x0004D41B
		public string #h()
		{
			return string.Format(CultureInfo.InvariantCulture, #Phc.#3hc(107416786), new object[]
			{
				this.PropertyName,
				this.OldValue,
				this.NewValue
			});
		}

		// Token: 0x06005F6B RID: 24427 RVA: 0x00178EE0 File Offset: 0x001770E0
		private void #ADc(object #f)
		{
			#9Cc #9Cc = this.Undoable;
			bool #f2 = false;
			if (3 != 0)
			{
				#9Cc.UndoEnabled = #f2;
			}
			PropertyInfo property = this.Undoable.GetType().GetProperty(this.PropertyName);
			if (property == null)
			{
				throw new InvalidOperationException(#Phc.#3hc(107416733) + this.PropertyName + #Phc.#3hc(107416684));
			}
			object obj = this.Undoable;
			object[] index = null;
			if (!false)
			{
				property.SetValue(obj, #f, index);
			}
			#9Cc #9Cc2 = this.Undoable;
			bool #f3 = true;
			if (3 != 0)
			{
				#9Cc2.UndoEnabled = #f3;
			}
		}

		// Token: 0x04002766 RID: 10086
		[CompilerGenerated]
		private readonly #9Cc #a;

		// Token: 0x04002767 RID: 10087
		[CompilerGenerated]
		private readonly string #b;

		// Token: 0x04002768 RID: 10088
		[CompilerGenerated]
		private readonly object #c;

		// Token: 0x04002769 RID: 10089
		[CompilerGenerated]
		private readonly object #d;

		// Token: 0x0400276A RID: 10090
		[CompilerGenerated]
		private readonly long #e;
	}
}
