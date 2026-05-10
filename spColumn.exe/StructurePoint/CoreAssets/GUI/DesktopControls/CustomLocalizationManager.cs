using System;
using System.Globalization;
using System.Resources;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using Telerik.Windows.Controls;

namespace StructurePoint.CoreAssets.GUI.DesktopControls
{
	// Token: 0x02000896 RID: 2198
	public sealed class CustomLocalizationManager : LocalizationManager
	{
		// Token: 0x0600455B RID: 17755 RVA: 0x00039DE6 File Offset: 0x00037FE6
		public CustomLocalizationManager(ResourceManager resourceManager)
		{
			#X0d.#V0d(resourceManager, #Phc.#3hc(107454488), Component.DesktopControls, #Phc.#3hc(107454947));
			this.resourceManager = resourceManager;
		}

		// Token: 0x0600455C RID: 17756 RVA: 0x0013CE04 File Offset: 0x0013B004
		public override string GetStringOverride(string key)
		{
			string text = this.resourceManager.GetString(key, CultureInfo.CurrentCulture);
			if (text == null)
			{
				text = base.GetStringOverride(key);
			}
			return text;
		}

		// Token: 0x04001F89 RID: 8073
		private readonly ResourceManager resourceManager;
	}
}
