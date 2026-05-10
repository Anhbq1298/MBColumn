using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;
using #7hc;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Properties
{
	// Token: 0x02000AE3 RID: 2787
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal sealed class Resources
	{
		// Token: 0x06005A9B RID: 23195 RVA: 0x000035C3 File Offset: 0x000017C3
		internal Resources()
		{
		}

		// Token: 0x1700198A RID: 6538
		// (get) Token: 0x06005A9C RID: 23196 RVA: 0x0004B64D File Offset: 0x0004984D
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (Resources.resourceMan == null)
				{
					Resources.resourceMan = new ResourceManager(#Phc.#3hc(107422931), typeof(Resources).Assembly);
				}
				return Resources.resourceMan;
			}
		}

		// Token: 0x1700198B RID: 6539
		// (get) Token: 0x06005A9D RID: 23197 RVA: 0x0004B67E File Offset: 0x0004987E
		// (set) Token: 0x06005A9E RID: 23198 RVA: 0x0004B685 File Offset: 0x00049885
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

		// Token: 0x040025DD RID: 9693
		private static ResourceManager resourceMan;

		// Token: 0x040025DE RID: 9694
		private static CultureInfo resourceCulture;
	}
}
