using System;
using #7hc;
using Svg;

namespace #oFe
{
	// Token: 0x02001249 RID: 4681
	internal static class #1Ge
	{
		// Token: 0x06009CDE RID: 40158 RVA: 0x0007BAC5 File Offset: 0x00079CC5
		public static float #wae(float #f)
		{
			if (Math.Abs(#f) < 0.01f)
			{
				return 0f;
			}
			return (float)Math.Round((double)#f, 5);
		}

		// Token: 0x06009CDF RID: 40159 RVA: 0x0007BAE3 File Offset: 0x00079CE3
		public static SvgUnit #ZGe(SvgUnit #6jb)
		{
			return new SvgUnit(#6jb.Type, #1Ge.#wae(#6jb.Value));
		}

		// Token: 0x06009CE0 RID: 40160 RVA: 0x00214B00 File Offset: 0x00212D00
		public static SvgPointCollection #ZGe(this SvgPointCollection #Du)
		{
			if (#Du == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107420761));
			}
			for (int i = 0; i < #Du.Count; i++)
			{
				#Du[i] = #1Ge.#ZGe(#Du[i]);
			}
			return #Du;
		}

		// Token: 0x06009CE1 RID: 40161 RVA: 0x00214B48 File Offset: 0x00212D48
		public static SvgUnitCollection #ZGe(this SvgUnitCollection #Du)
		{
			if (#Du == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107420761));
			}
			for (int i = 0; i < #Du.Count; i++)
			{
				#Du[i] = #1Ge.#ZGe(#Du[i]);
			}
			return #Du;
		}

		// Token: 0x06009CE2 RID: 40162 RVA: 0x0007BAFD File Offset: 0x00079CFD
		public static SvgText #ZGe(this SvgText #hvb)
		{
			if (#hvb == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107453475));
			}
			#hvb.X = #hvb.X.#ZGe();
			#hvb.Y = #hvb.Y.#ZGe();
			return #hvb;
		}

		// Token: 0x06009CE3 RID: 40163 RVA: 0x00214B90 File Offset: 0x00212D90
		public static SvgLine #ZGe(this SvgLine #Ztc)
		{
			if (#Ztc == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107314247));
			}
			#Ztc.StartX = #1Ge.#ZGe(#Ztc.StartX);
			#Ztc.StartY = #1Ge.#ZGe(#Ztc.StartY);
			#Ztc.EndX = #1Ge.#ZGe(#Ztc.EndX);
			#Ztc.EndY = #1Ge.#ZGe(#Ztc.EndY);
			return #Ztc;
		}

		// Token: 0x06009CE4 RID: 40164 RVA: 0x00214BF8 File Offset: 0x00212DF8
		public static SvgUnitCollection #0Ge(this SvgUnitCollection #Du, float #RIc)
		{
			if (#Du == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107420761));
			}
			for (int i = 0; i < #Du.Count; i++)
			{
				#Du[i] = #Du[i].Value * #RIc;
			}
			return #Du;
		}

		// Token: 0x06009CE5 RID: 40165 RVA: 0x00214C48 File Offset: 0x00212E48
		public static SvgUnitCollection #ul(params SvgUnit[] #jUd)
		{
			SvgUnitCollection svgUnitCollection = new SvgUnitCollection();
			if (#jUd != null)
			{
				svgUnitCollection.AddRange(#jUd);
			}
			return svgUnitCollection;
		}

		// Token: 0x040043C5 RID: 17349
		private const float #a = 0.01f;
	}
}
