using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;
using #7hc;

namespace #3Je
{
	// Token: 0x02001266 RID: 4710
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal sealed class #Ab
	{
		// Token: 0x06009E15 RID: 40469 RVA: 0x000035C3 File Offset: 0x000017C3
		internal #Ab()
		{
		}

		// Token: 0x17002D90 RID: 11664
		// (get) Token: 0x06009E16 RID: 40470 RVA: 0x0007C6D0 File Offset: 0x0007A8D0
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (#Ab.#a == null)
				{
					#Ab.#a = new ResourceManager(#Phc.#3hc(107313751), typeof(#Ab).Assembly);
				}
				return #Ab.#a;
			}
		}

		// Token: 0x17002D91 RID: 11665
		// (get) Token: 0x06009E17 RID: 40471 RVA: 0x0007C701 File Offset: 0x0007A901
		// (set) Token: 0x06009E18 RID: 40472 RVA: 0x0007C708 File Offset: 0x0007A908
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

		// Token: 0x04004462 RID: 17506
		private static ResourceManager #a;

		// Token: 0x04004463 RID: 17507
		private static CultureInfo #b;
	}
}
