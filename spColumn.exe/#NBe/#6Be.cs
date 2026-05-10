using System;
using System.Collections.Generic;
using System.IO;
using #v1c;
using #xBe;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;

namespace #NBe
{
	// Token: 0x0200121D RID: 4637
	internal sealed class #6Be
	{
		// Token: 0x06009B4F RID: 39759 RVA: 0x0007AD4E File Offset: 0x00078F4E
		public #6Be(#v2c #my)
		{
			this.#a = #my;
		}

		// Token: 0x06009B50 RID: 39760 RVA: 0x0020FF70 File Offset: 0x0020E170
		public void #3Be(List<#DBe> #Rfb, string #4Hc)
		{
			try
			{
				Stream #gp = this.#a.#U1c(#4Hc);
				#2Be #5Be = new #8Be().#Cjc(#gp);
				#DBe item = this.#4Be(#5Be, #4Hc);
				#Rfb.Add(item);
			}
			catch (Exception innerException)
			{
				throw new InvalidDataException(Strings.StringCannotImportIadFile.#z2d(), innerException);
			}
		}

		// Token: 0x06009B51 RID: 39761 RVA: 0x0020FFCC File Offset: 0x0020E1CC
		private #DBe #4Be(#2Be #5Be, string #4Hc)
		{
			ConsideredAxis consideredAxis = (ConsideredAxis)#5Be.ActiveAxis;
			UniCurve[] #f = #RBe.#Pb(#5Be.Data.#a);
			BiCurve[] #f2 = #RBe.#Pb(#5Be.Data.#b);
			if (consideredAxis <= ConsideredAxis.Y)
			{
				return new #DBe
				{
					FilePath = #4Hc,
					UniCurve = #f,
					RunAxis = consideredAxis
				};
			}
			if (consideredAxis != ConsideredAxis.Both)
			{
				return null;
			}
			return new #DBe
			{
				FilePath = #4Hc,
				BiCurves = #f2,
				RunAxis = consideredAxis
			};
		}

		// Token: 0x040042E8 RID: 17128
		private readonly #v2c #a;
	}
}
