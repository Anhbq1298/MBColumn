using System;
using System.Globalization;
using #5Fd;
using #7hc;
using #Wse;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Model;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Resources;

namespace #yze
{
	// Token: 0x020011F6 RID: 4598
	internal sealed class #Cze : #lHd
	{
		// Token: 0x06009A3D RID: 39485 RVA: 0x0007A2D7 File Offset: 0x000784D7
		public #Cze(int #mHd, #lte #Od) : base(#mHd)
		{
			this.#a = #Od;
		}

		// Token: 0x06009A3E RID: 39486 RVA: 0x0020CDB4 File Offset: 0x0020AFB4
		protected override void #eHd(int #fHd)
		{
			GeneralInformation generalInformation = this.#a.GeneralInfo;
			string text = #Phc.#3hc(107378408) + generalInformation.ProductAndVersion;
			string text2 = #fHd.ToString(CultureInfo.InvariantCulture);
			text2 = #Phc.#3hc(107283752).PadRight(8 - text2.Length) + text2;
			base.#cGd(text.PadRight(base.LineWidth - text2.Length) + text2, false);
			string text3 = string.Format(Localization.StringLicensedTo0LicenseID1, generalInformation.LicenseeName, generalInformation.LicenseId);
			if (generalInformation.IsTrial)
			{
				text3 = string.Format(#Phc.#3hc(107283775), generalInformation.LockingCode, generalInformation.LicenseeName);
			}
			string text4 = DateTime.Now.ToString(#Phc.#3hc(107420867), CultureInfo.CurrentCulture);
			base.#cGd(text3.PadRight(base.LineWidth - text4.Length) + text4, false);
			string text5 = DateTime.Now.ToString(#Phc.#3hc(107395512));
			base.#cGd(LayoutHelper.CompactPath(generalInformation.FileName, base.LineWidth - text5.Length - 2).PadRight(base.LineWidth - text5.Length) + text5, false);
			base.#eHd(#fHd);
		}

		// Token: 0x0400423A RID: 16954
		private readonly #lte #a;
	}
}
