using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;
using #7hc;

namespace StructurePoint.CoreAssets.Column.Core.Properties
{
	// Token: 0x02000824 RID: 2084
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal sealed class Resources
	{
		// Token: 0x060042BB RID: 17083 RVA: 0x000035C3 File Offset: 0x000017C3
		internal Resources()
		{
		}

		// Token: 0x170013B0 RID: 5040
		// (get) Token: 0x060042BC RID: 17084 RVA: 0x00038074 File Offset: 0x00036274
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (Resources.resourceMan == null)
				{
					Resources.resourceMan = new ResourceManager(#Phc.#3hc(107457340), typeof(Resources).Assembly);
				}
				return Resources.resourceMan;
			}
		}

		// Token: 0x170013B1 RID: 5041
		// (get) Token: 0x060042BD RID: 17085 RVA: 0x000380A5 File Offset: 0x000362A5
		// (set) Token: 0x060042BE RID: 17086 RVA: 0x000380AC File Offset: 0x000362AC
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return Resources.resourceCulture;
			}
			set
			{
				Resources.resourceCulture = value;
			}
		}

		// Token: 0x04001E0D RID: 7693
		private static ResourceManager resourceMan;

		// Token: 0x04001E0E RID: 7694
		private static CultureInfo resourceCulture;
	}
}
