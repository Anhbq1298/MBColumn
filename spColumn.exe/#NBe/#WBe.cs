using System;
using System.IO;
using #v1c;
using #xBe;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.FailureSurface;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;

namespace #NBe
{
	// Token: 0x0200121B RID: 4635
	internal sealed class #WBe
	{
		// Token: 0x06009B42 RID: 39746 RVA: 0x0007ACFA File Offset: 0x00078EFA
		public #WBe(#v2c #my)
		{
			this.#b = #my;
		}

		// Token: 0x06009B43 RID: 39747 RVA: 0x0020FE10 File Offset: 0x0020E010
		public bool #xRb(UniCurve[] #UAe, string #4Hc, ConsideredAxis #TBe)
		{
			bool result;
			try
			{
				#2Be #5Be = this.#VBe(#UAe, #TBe);
				Stream #gp = this.#b.#T1c(#4Hc);
				new #cCe().#npb(#gp, #5Be);
				result = true;
			}
			catch (Exception innerException)
			{
				throw new InvalidDataException(Strings.StringCannotWriteIadFile.#z2d(), innerException);
			}
			return result;
		}

		// Token: 0x06009B44 RID: 39748 RVA: 0x0020FE68 File Offset: 0x0020E068
		public bool #xRb(FailureSurfaceData[] #UBe, string #4Hc)
		{
			bool result;
			try
			{
				#2Be #5Be = this.#VBe(#UBe);
				Stream #gp = this.#b.#T1c(#4Hc);
				new #cCe().#npb(#gp, #5Be);
				result = true;
			}
			catch (Exception innerException)
			{
				throw new InvalidDataException(Strings.StringCannotWriteIadFile.#z2d(), innerException);
			}
			return result;
		}

		// Token: 0x06009B45 RID: 39749 RVA: 0x0020FEC0 File Offset: 0x0020E0C0
		private #2Be #VBe(FailureSurfaceData[] #UBe)
		{
			BiCurve[] #PBe = #wBe.#uBe(#UBe);
			short #f = 2;
			#SBe #f2 = new #SBe
			{
				#b = #RBe.#Pb(#PBe),
				#a = new #dCe[70]
			};
			return new #2Be
			{
				ActiveAxis = #f,
				FileFormatVersion = 10f,
				Data = #f2
			};
		}

		// Token: 0x06009B46 RID: 39750 RVA: 0x0020FF1C File Offset: 0x0020E11C
		private #2Be #VBe(UniCurve[] #UAe, ConsideredAxis #TBe)
		{
			short #f = (short)#TBe;
			#SBe #f2 = new #SBe
			{
				#a = #RBe.#Pb(#UAe),
				#b = new #MBe[70]
			};
			return new #2Be
			{
				ActiveAxis = #f,
				FileFormatVersion = 10f,
				Data = #f2
			};
		}

		// Token: 0x040042E2 RID: 17122
		private const float #a = 10f;

		// Token: 0x040042E3 RID: 17123
		private readonly #v2c #b;
	}
}
