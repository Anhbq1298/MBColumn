using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;
using #7hc;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Properties
{
	// Token: 0x0200089D RID: 2205
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal sealed class Resources
	{
		// Token: 0x06004577 RID: 17783 RVA: 0x000035C3 File Offset: 0x000017C3
		[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
		internal Resources()
		{
		}

		// Token: 0x17001441 RID: 5185
		// (get) Token: 0x06004578 RID: 17784 RVA: 0x00039EFF File Offset: 0x000380FF
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (Resources.resourceMan == null)
				{
					Resources.resourceMan = new ResourceManager(#Phc.#3hc(107454782), typeof(Resources).Assembly);
				}
				return Resources.resourceMan;
			}
		}

		// Token: 0x17001442 RID: 5186
		// (get) Token: 0x06004579 RID: 17785 RVA: 0x00039F3C File Offset: 0x0003813C
		// (set) Token: 0x0600457A RID: 17786 RVA: 0x00039F43 File Offset: 0x00038143
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

		// Token: 0x17001443 RID: 5187
		// (get) Token: 0x0600457B RID: 17787 RVA: 0x00039F4F File Offset: 0x0003814F
		internal static string StringNoComparableOutputFileTypesSelected
		{
			get
			{
				return Resources.ResourceManager.GetString(#Phc.#3hc(107454149), Resources.resourceCulture);
			}
		}

		// Token: 0x04001F8F RID: 8079
		private static ResourceManager resourceMan;

		// Token: 0x04001F90 RID: 8080
		private static CultureInfo resourceCulture;
	}
}
