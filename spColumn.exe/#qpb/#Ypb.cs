using System;
using #12e;
using #7hc;
using #FCd;
using #owe;
using #Rwe;
using #wdd;
using #Wse;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.GUI.DesktopControls;
using StructurePoint.CoreAssets.Localizer;

namespace #qpb
{
	// Token: 0x02000467 RID: 1127
	internal sealed class #Ypb : #qwe
	{
		// Token: 0x06002962 RID: 10594 RVA: 0x00025EBB File Offset: 0x000240BB
		public #Ypb(#lte #Od, double[] #Zpb = null) : base(#Od)
		{
			this.#a = #Zpb;
		}

		// Token: 0x06002963 RID: 10595 RVA: 0x000DF318 File Offset: 0x000DD518
		public override void #npb(#6Dd #opb)
		{
			Options options = base.Model.Input.Options;
			if (options.ConsiderSlenderness)
			{
				using (#5Dd #5Dd = #opb.#Xdd(this.#a))
				{
					#2dd.#Vdd(#5Dd);
					if (options.ConsiderXAxis())
					{
						#l4e #l4e = base.Model.Output;
						float? num;
						if (#l4e == null)
						{
							num = null;
						}
						else
						{
							#K3e #K3e = #l4e.Slenderness;
							if (#K3e == null)
							{
								num = null;
							}
							else
							{
								#s5e #s5e = #K3e.SlendernessX;
								num = ((#s5e != null) ? new float?(#s5e.Klur) : null);
							}
						}
						float? #f = num;
						string text = (#f != null) ? #ned.#qp(#f, NativeNumberFormat.F10_2, #Phc.#3hc(107381628)) : #Phc.#3hc(107408434);
						#5Dd.#ODd(new string[]
						{
							#Yxe.Klur + #Phc.#3hc(107399922) + Strings.StringX_Axis_Parentheses,
							text,
							string.Empty
						});
					}
					if (options.ConsiderYAxis())
					{
						#l4e #l4e2 = base.Model.Output;
						float? num2;
						if (#l4e2 == null)
						{
							num2 = null;
						}
						else
						{
							#K3e #K3e2 = #l4e2.Slenderness;
							if (#K3e2 == null)
							{
								num2 = null;
							}
							else
							{
								#s5e #s5e2 = #K3e2.SlendernessY;
								num2 = ((#s5e2 != null) ? new float?(#s5e2.Klur) : null);
							}
						}
						float? #f2 = num2;
						string text2 = (#f2 != null) ? #ned.#qp(#f2, NativeNumberFormat.F10_2, #Phc.#3hc(107381628)) : #Phc.#3hc(107408434);
						#5Dd.#ODd(new string[]
						{
							#Yxe.Klur + #Phc.#3hc(107399922) + Strings.StringY_Axis_Parentheses,
							text2,
							string.Empty
						});
					}
				}
			}
		}

		// Token: 0x04001089 RID: 4233
		private readonly double[] #a;
	}
}
