using System;
using System.Windows;
using #EWc;
using #ezc;
using #LQc;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;

namespace #NWc
{
	// Token: 0x02000C8C RID: 3212
	internal sealed class #MWc : #OWc
	{
		// Token: 0x0600680C RID: 26636 RVA: 0x00052FF6 File Offset: 0x000511F6
		public #MWc(#8Sc #ls, #xAc #6x)
		{
			this.#a = #ls;
			this.#b = #6x;
		}

		// Token: 0x0600680D RID: 26637 RVA: 0x0005300C File Offset: 0x0005120C
		public #SJ #NRb()
		{
			#SJ #SJ = new #SJ();
			#IWc #f = #IWc.#a;
			if (2 != 0)
			{
				#SJ.Result = #f;
			}
			return #SJ;
		}

		// Token: 0x0600680E RID: 26638 RVA: 0x001953A0 File Offset: 0x001935A0
		public bool #KWc()
		{
			string #SSc;
			do
			{
				string text = Strings.StringDeletingTheseNodesWouldCreateInvalidShapesWhichWillBeRemoved.#z2d(true) + Strings.StringDoYouWantToContinue.#J2d();
				if (!false)
				{
					#SSc = text;
				}
			}
			while (false);
			return this.#a.#od(#SSc, MessageBoxButton.OKCancel, MessageBoxImage.Question, MessageBoxResult.OK, MessageBoxOptions.None) == MessageBoxResult.OK;
		}

		// Token: 0x0600680F RID: 26639 RVA: 0x0005300C File Offset: 0x0005120C
		public #SJ #LWc()
		{
			#SJ #SJ = new #SJ();
			#IWc #f = #IWc.#a;
			if (2 != 0)
			{
				#SJ.Result = #f;
			}
			return #SJ;
		}

		// Token: 0x04002AD8 RID: 10968
		private readonly #8Sc #a;

		// Token: 0x04002AD9 RID: 10969
		private readonly #xAc #b;
	}
}
