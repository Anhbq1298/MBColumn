using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;
using #7hc;

namespace #jgc
{
	// Token: 0x02000723 RID: 1827
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal sealed class #Ab
	{
		// Token: 0x06003C2F RID: 15407 RVA: 0x000035C3 File Offset: 0x000017C3
		internal #Ab()
		{
		}

		// Token: 0x1700123E RID: 4670
		// (get) Token: 0x06003C30 RID: 15408 RVA: 0x001192A8 File Offset: 0x001174A8
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				do
				{
					if (5 != 0 && #Ab.#a == null)
					{
						#Ab.#a = new ResourceManager(#Phc.#3hc(107378345), \u0088.~\u008B\u0002(\u001E.\u000F\u0002(typeof(#Ab).TypeHandle)));
					}
				}
				while (false);
				return #Ab.#a;
			}
		}

		// Token: 0x1700123F RID: 4671
		// (get) Token: 0x06003C31 RID: 15409 RVA: 0x00034024 File Offset: 0x00032224
		// (set) Token: 0x06003C32 RID: 15410 RVA: 0x0003402B File Offset: 0x0003222B
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return #Ab.#b;
			}
			set
			{
				#Ab.#b = value;
			}
		}

		// Token: 0x04001B3A RID: 6970
		private static ResourceManager #a;

		// Token: 0x04001B3B RID: 6971
		private static CultureInfo #b;
	}
}
