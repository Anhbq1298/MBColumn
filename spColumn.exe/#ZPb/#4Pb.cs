using System;
using System.Linq;
using System.Windows;
using #7hc;
using #8Cc;
using #cYd;
using #eU;
using #ezc;
using #IDc;
using #LQc;
using StructurePoint.CoreAssets.GUI.Framework.UndoRedo;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.CoreAssets.Logger;
using StructurePoint.Products.Column.Core.API;

namespace #ZPb
{
	// Token: 0x020006AF RID: 1711
	internal sealed class #4Pb : IEditorService
	{
		// Token: 0x06003903 RID: 14595 RVA: 0x000318E5 File Offset: 0x0002FAE5
		public #4Pb(#bDc #DJ, #rBc #zq, ILogger #3x, #8Sc #ls, #xAc #Aq, #iW #ss)
		{
			this.#a = #DJ;
			this.#b = #zq;
			this.#c = #3x;
			this.#d = #ls;
			this.#e = #Aq;
			this.#f = #ss;
		}

		// Token: 0x06003904 RID: 14596 RVA: 0x00111038 File Offset: 0x0010F238
		public bool #0Pb(Action #nd)
		{
			if (#nd == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107351365));
			}
			try
			{
				UndoAction.#uRb(this.#a, #nd);
			}
			catch (Exception #ob)
			{
				this.#1Pb(#ob);
				return false;
			}
			return true;
		}

		// Token: 0x06003905 RID: 14597 RVA: 0x00111094 File Offset: 0x0010F294
		public bool #0Pb(Func<bool> #nd)
		{
			if (#nd == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107351365));
			}
			try
			{
				UndoAction.#uRb(this.#a, #nd);
			}
			catch (Exception #ob)
			{
				this.#1Pb(#ob);
				return false;
			}
			return true;
		}

		// Token: 0x06003906 RID: 14598 RVA: 0x0003191A File Offset: 0x0002FB1A
		public void #1Pb(Exception #ob)
		{
			if (!this.#2Pb(#ob))
			{
				this.#b.#bzc(#ob, #Phc.#3hc(107351388), new #3Hc(this.#e.ApplicationName));
			}
		}

		// Token: 0x06003907 RID: 14599 RVA: 0x001110F0 File Offset: 0x0010F2F0
		private bool #2Pb(Exception #ob)
		{
			#vYd #vYd = #ob as #vYd;
			if (#vYd == null)
			{
				#vYd = #sYd.#pYd(#ob).OfType<#vYd>().FirstOrDefault<#vYd>();
			}
			if (#vYd != null)
			{
				this.#2Pb(#vYd);
				return true;
			}
			return false;
		}

		// Token: 0x06003908 RID: 14600 RVA: 0x00111134 File Offset: 0x0010F334
		private void #2Pb(#vYd #3Pb)
		{
			this.#c.Log(LoggingLevel.Error, #3Pb);
			string #SSc = Strings.StringTheGeometryOperationResultIsNotValid.#z2d(true) + Strings.StringOperationHasBeenCanceled.#z2d();
			Window #WSc = this.#f.#6();
			this.#d.#od(#WSc, #SSc, this.#e.ApplicationName, MessageBoxButton.OK, MessageBoxImage.Hand, MessageBoxResult.OK, MessageBoxOptions.None);
		}

		// Token: 0x040017F5 RID: 6133
		private readonly #bDc #a;

		// Token: 0x040017F6 RID: 6134
		private readonly #rBc #b;

		// Token: 0x040017F7 RID: 6135
		private readonly ILogger #c;

		// Token: 0x040017F8 RID: 6136
		private readonly #8Sc #d;

		// Token: 0x040017F9 RID: 6137
		private readonly #xAc #e;

		// Token: 0x040017FA RID: 6138
		private readonly #iW #f;
	}
}
