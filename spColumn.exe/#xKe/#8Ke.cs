using System;
using System.Collections.Generic;
using #7hc;
using #bne;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;

namespace #xKe
{
	// Token: 0x02001270 RID: 4720
	internal sealed class #8Ke
	{
		// Token: 0x06009E62 RID: 40546 RVA: 0x0007CB02 File Offset: 0x0007AD02
		public static IEnumerable<#yne> #3Ke(int? #1f, bool #kne, bool #lne)
		{
			if (#1f != null && !#kne && !#lne)
			{
				yield return new #yne(Strings.StringImportingSolidShapes.#u2d(true) + Strings.StringSolidsImported.#D2d(new object[]
				{
					#1f
				}));
				yield break;
			}
			string text = Strings.StringImportingSolidShapes.#u2d(true);
			if (#1f == null)
			{
				string #zne = Strings.StringXLayerNotFound.#D2d(new object[]
				{
					#Phc.#3hc(107348230)
				}).#z2d().#O2d() + Strings.StringNoSolidsWillBeImported.#z2d();
				yield return new #yne(text, #zne);
				yield break;
			}
			string # = text;
			if (#kne)
			{
				yield return new #yne(#, Strings.String0LayerContainsNoClosedPolyline.#D2d(new object[]
				{
					#Phc.#3hc(107348230).ToLower()
				}));
				# = #8Ke.#d;
			}
			if (#lne)
			{
				yield return new #yne(#, Strings.String0LayerMaximum1VerticesInPolylineHasBeenExceeded.#D2d(new object[]
				{
					#Phc.#3hc(107348230).ToLower(),
					10000
				}));
			}
			yield break;
		}

		// Token: 0x06009E63 RID: 40547 RVA: 0x0007CB20 File Offset: 0x0007AD20
		public static IEnumerable<#yne> #4Ke(int? #1f, bool #kne, bool #lne)
		{
			if (#1f != null && !#kne && !#lne)
			{
				yield return new #yne(Strings.StringImportingOpenings.#O2d() + Strings.StringOpeningsImported.#D2d(new object[]
				{
					#1f
				}));
				yield break;
			}
			string text = Strings.StringImportingOpenings.#O2d();
			if (#1f == null)
			{
				string #zne = Strings.StringXLayerNotFound.#D2d(new object[]
				{
					#Phc.#3hc(107348253)
				}).#z2d().#O2d() + Strings.StringNoOpeningsWillBeImported.#z2d();
				yield return new #yne(text, #zne);
				yield break;
			}
			string # = text;
			if (#kne)
			{
				yield return new #yne(#, Strings.String0LayerContainsNoClosedPolyline.#D2d(new object[]
				{
					#Phc.#3hc(107348253).ToLower()
				}));
				# = #8Ke.#d;
			}
			if (#lne)
			{
				yield return new #yne(#, Strings.String0LayerMaximum1VerticesInPolylineHasBeenExceeded.#D2d(new object[]
				{
					#Phc.#3hc(107348253).ToLower(),
					10000
				}));
			}
			yield break;
		}

		// Token: 0x06009E64 RID: 40548 RVA: 0x0007CB3E File Offset: 0x0007AD3E
		public static IEnumerable<#yne> #5Ke(int? #1f, bool #gne)
		{
			if (#1f != null && !#gne)
			{
				yield return new #yne(Strings.StringImportingBarsBarsImported.#D2d(new object[]
				{
					#1f
				}));
				yield break;
			}
			string # = Strings.StringImportingBars.#O2d();
			if (#1f == null)
			{
				string #zne = Strings.StringXLayerNotFound.#D2d(new object[]
				{
					#Phc.#3hc(107348240)
				}).#z2d().#O2d() + Strings.StringNoBarsWillBeImported.#z2d();
				yield return new #yne(#, #zne);
				yield break;
			}
			yield return new #yne(#, Strings.StringOnly0BarsWasImported.#D2d(new object[]
			{
				#1f
			}));
			yield return new #yne(#8Ke.#d, Strings.StringBarLayerContainsTooManyElements);
			yield break;
		}

		// Token: 0x06009E65 RID: 40549 RVA: 0x0007CB55 File Offset: 0x0007AD55
		public static bool #6Ke(int? #1f, bool #kne, bool #lne)
		{
			return #1f == null || #kne || #lne;
		}

		// Token: 0x06009E66 RID: 40550 RVA: 0x0007CB65 File Offset: 0x0007AD65
		public static bool #7Ke(int? #1f, bool #gne)
		{
			return #1f == null || #gne;
		}

		// Token: 0x04004471 RID: 17521
		public const string #a = "Solids";

		// Token: 0x04004472 RID: 17522
		public const string #b = "Openings";

		// Token: 0x04004473 RID: 17523
		public const string #c = "Bars";

		// Token: 0x04004474 RID: 17524
		private static readonly string #d = #Phc.#3hc(107313395);
	}
}
