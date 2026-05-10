using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;
using #7hc;

namespace #Bb
{
	// Token: 0x0200001C RID: 28
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal sealed class #Ab
	{
		// Token: 0x060000A0 RID: 160 RVA: 0x000035C3 File Offset: 0x000017C3
		internal #Ab()
		{
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x060000A1 RID: 161 RVA: 0x00085A50 File Offset: 0x00083C50
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (#Ab.#a == null)
				{
					ResourceManager resourceManager = new ResourceManager(#Phc.#3hc(107394772), typeof(#Ab).Assembly);
					#Ab.#a = resourceManager;
				}
				return #Ab.#a;
			}
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x060000A2 RID: 162 RVA: 0x0000372C File Offset: 0x0000192C
		// (set) Token: 0x060000A3 RID: 163 RVA: 0x00003733 File Offset: 0x00001933
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

		// Token: 0x0400003A RID: 58
		private static ResourceManager #a;

		// Token: 0x0400003B RID: 59
		private static CultureInfo #b;
	}
}
