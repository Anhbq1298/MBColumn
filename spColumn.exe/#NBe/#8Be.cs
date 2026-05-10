using System;
using System.IO;
using #7hc;
using #wje;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;

namespace #NBe
{
	// Token: 0x0200121E RID: 4638
	internal sealed class #8Be
	{
		// Token: 0x06009B52 RID: 39762 RVA: 0x00210044 File Offset: 0x0020E244
		public #2Be #Cjc(Stream #gp)
		{
			#2Be result;
			try
			{
				result = this.#7Be(#gp);
			}
			catch (Exception innerException)
			{
				throw new InvalidDataException(Strings.StringCannotReadIadFile.#z2d(), innerException);
			}
			return result;
		}

		// Token: 0x06009B53 RID: 39763 RVA: 0x00210080 File Offset: 0x0020E280
		private #2Be #7Be(Stream #gp)
		{
			#2Be #2Be = new #2Be();
			string empty = string.Empty;
			#gp.#IAc(#Phc.#3hc(107283381).Length, ref empty);
			if (!string.Equals(empty, #Phc.#3hc(107283381)))
			{
				throw new InvalidDataException(Strings.StringCannotReadIadFile);
			}
			float #f = #gp.#d6d();
			short #f2 = #gp.#Fic();
			#SBe #f3;
			#gp.#Cke(out #f3, 0);
			#2Be.FileFormatVersion = #f;
			#2Be.ActiveAxis = #f2;
			#2Be.Data = #f3;
			return #2Be;
		}
	}
}
