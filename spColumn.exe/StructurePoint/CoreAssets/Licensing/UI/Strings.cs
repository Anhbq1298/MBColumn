using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;
using #7hc;

namespace StructurePoint.CoreAssets.Licensing.UI
{
	// Token: 0x0200071E RID: 1822
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	public sealed class Strings
	{
		// Token: 0x06003BF9 RID: 15353 RVA: 0x000035C3 File Offset: 0x000017C3
		internal Strings()
		{
		}

		// Token: 0x17001221 RID: 4641
		// (get) Token: 0x06003BFA RID: 15354 RVA: 0x001191E4 File Offset: 0x001173E4
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public static ResourceManager ResourceManager
		{
			get
			{
				do
				{
					if (5 != 0 && Strings.resourceMan == null)
					{
						Strings.resourceMan = new ResourceManager(#Phc.#3hc(107378764), \u0088.~\u008B\u0002(\u001E.\u000F\u0002(typeof(Strings).TypeHandle)));
					}
				}
				while (false);
				return Strings.resourceMan;
			}
		}

		// Token: 0x17001222 RID: 4642
		// (get) Token: 0x06003BFB RID: 15355 RVA: 0x00033C46 File Offset: 0x00031E46
		// (set) Token: 0x06003BFC RID: 15356 RVA: 0x00033C4D File Offset: 0x00031E4D
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public static CultureInfo Culture
		{
			get
			{
				return Strings.resourceCulture;
			}
			set
			{
				Strings.resourceCulture = value;
			}
		}

		// Token: 0x17001223 RID: 4643
		// (get) Token: 0x06003BFD RID: 15357 RVA: 0x00033C59 File Offset: 0x00031E59
		public static string StringAnErrorOccurredWhileActivatingTheSoftware
		{
			get
			{
				return \u0089.~\u008C\u0002(Strings.ResourceManager, #Phc.#3hc(107378699), Strings.resourceCulture);
			}
		}

		// Token: 0x17001224 RID: 4644
		// (get) Token: 0x06003BFE RID: 15358 RVA: 0x00033C85 File Offset: 0x00031E85
		public static string StringAnErrorOccurredWhileInitializingTrialLicense
		{
			get
			{
				return \u0089.~\u008C\u0002(Strings.ResourceManager, #Phc.#3hc(107379146), Strings.resourceCulture);
			}
		}

		// Token: 0x17001225 RID: 4645
		// (get) Token: 0x06003BFF RID: 15359 RVA: 0x00033CB1 File Offset: 0x00031EB1
		public static string StringAreSureYouWantToExit
		{
			get
			{
				return \u0089.~\u008C\u0002(Strings.ResourceManager, #Phc.#3hc(107379077), Strings.resourceCulture);
			}
		}

		// Token: 0x17001226 RID: 4646
		// (get) Token: 0x06003C00 RID: 15360 RVA: 0x00033CDD File Offset: 0x00031EDD
		public static string StringErrorCode
		{
			get
			{
				return \u0089.~\u008C\u0002(Strings.ResourceManager, #Phc.#3hc(107379040), Strings.resourceCulture);
			}
		}

		// Token: 0x17001227 RID: 4647
		// (get) Token: 0x06003C01 RID: 15361 RVA: 0x00033D09 File Offset: 0x00031F09
		public static string StringFailedToActivateTheSoftware
		{
			get
			{
				return \u0089.~\u008C\u0002(Strings.ResourceManager, #Phc.#3hc(107379019), Strings.resourceCulture);
			}
		}

		// Token: 0x17001228 RID: 4648
		// (get) Token: 0x06003C02 RID: 15362 RVA: 0x00033D35 File Offset: 0x00031F35
		public static string StringFailedToOpenURL0
		{
			get
			{
				return \u0089.~\u008C\u0002(Strings.ResourceManager, #Phc.#3hc(107379006), Strings.resourceCulture);
			}
		}

		// Token: 0x17001229 RID: 4649
		// (get) Token: 0x06003C03 RID: 15363 RVA: 0x00033D61 File Offset: 0x00031F61
		public static string StringWelcomeTo
		{
			get
			{
				return \u0089.~\u008C\u0002(Strings.ResourceManager, #Phc.#3hc(107378973), Strings.resourceCulture);
			}
		}

		// Token: 0x04001B21 RID: 6945
		private static ResourceManager resourceMan;

		// Token: 0x04001B22 RID: 6946
		private static CultureInfo resourceCulture;
	}
}
