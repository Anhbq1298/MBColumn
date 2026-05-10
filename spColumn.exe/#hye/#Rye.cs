using System;
using #7hc;
using #FCd;
using #hZe;
using #owe;
using #Rwe;
using #wdd;
using #Wse;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Model;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.GUI.DesktopControls;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Resources;

namespace #hye
{
	// Token: 0x020011B9 RID: 4537
	internal sealed class #Rye : #qwe
	{
		// Token: 0x0600995B RID: 39259 RVA: 0x00079DB9 File Offset: 0x00077FB9
		public #Rye(#lte #Od, double[] #Zpb = null) : base(#Od)
		{
			this.#a = #Zpb;
		}

		// Token: 0x0600995C RID: 39260 RVA: 0x00208598 File Offset: 0x00206798
		public override void #npb(#6Dd #opb)
		{
			GeneralInformation generalInformation = base.Model.GeneralInfo;
			Options options = base.Model.Input.Options;
			#x0e #x0e = base.Model.BasicProperties.GeomProperties;
			using (#5Dd #5Dd = #opb.#Xdd(this.#a))
			{
				#5Dd.#ODd(new string[]
				{
					Localization.StringType,
					#yhe.#Qwe(options.SectionType),
					string.Empty
				});
				float[] array = base.Model.#jte();
				if (options.SectionType == SectionType.Rectangle)
				{
					#5Dd.#ODd(new string[]
					{
						Localization.StringWidth,
						#ned.#qp(new float?(array[0]), NativeNumberFormat.G, #Phc.#3hc(107381628)),
						generalInformation.UnitStringD
					});
					#5Dd.#ODd(new string[]
					{
						Localization.StringDepth,
						#ned.#qp(new float?(array[1]), NativeNumberFormat.G, #Phc.#3hc(107381628)),
						generalInformation.UnitStringD
					});
				}
				else if (options.SectionType == SectionType.Circle)
				{
					#5Dd.#ODd(new string[]
					{
						Localization.StringDiameter,
						#ned.#qp(new float?(array[0]), NativeNumberFormat.G, #Phc.#3hc(107381628)),
						generalInformation.UnitStringD
					});
				}
				if (#x0e != null)
				{
					#5Dd.#ODd(new string[]
					{
						#Yxe.Ag,
						#ned.#qp(new float?(#x0e.Ag), NativeNumberFormat.G, #Phc.#3hc(107381628)),
						generalInformation.UnitStringD + #6xe.#4xe(#Phc.#3hc(107360074))
					});
					#5Dd.#ODd(new string[]
					{
						#Yxe.Ix,
						#ned.#qp(new float?(#x0e.SecondMomentOfInertia[0]), NativeNumberFormat.G, #Phc.#3hc(107381628)),
						generalInformation.UnitStringD + #6xe.#4xe(#Phc.#3hc(107421485))
					});
					#5Dd.#ODd(new string[]
					{
						#Yxe.Iy,
						#ned.#qp(new float?(#x0e.SecondMomentOfInertia[1]), NativeNumberFormat.G, #Phc.#3hc(107381628)),
						generalInformation.UnitStringD + #6xe.#4xe(#Phc.#3hc(107421485))
					});
					#5Dd.#ODd(new string[]
					{
						#Yxe.Rx,
						#ned.#qp(new float?(#x0e.RadiusOfGyration[0]), NativeNumberFormat.G, #Phc.#3hc(107381628)),
						generalInformation.UnitStringD
					});
					#5Dd.#ODd(new string[]
					{
						#Yxe.Ry,
						#ned.#qp(new float?(#x0e.RadiusOfGyration[1]), NativeNumberFormat.G, #Phc.#3hc(107381628)),
						generalInformation.UnitStringD
					});
					float value = ((double)Math.Abs(#x0e.Ybar[0]) < 0.0001) ? 0f : #x0e.Ybar[0];
					float value2 = ((double)Math.Abs(#x0e.Ybar[1]) < 0.0001) ? 0f : #x0e.Ybar[1];
					#5Dd.#ODd(new string[]
					{
						#Yxe.X0,
						#ned.#qp(new float?(value), NativeNumberFormat.G, #Phc.#3hc(107381628)),
						generalInformation.UnitStringD
					});
					#5Dd.#ODd(new string[]
					{
						#Yxe.Y0,
						#ned.#qp(new float?(value2), NativeNumberFormat.G, #Phc.#3hc(107381628)),
						generalInformation.UnitStringD
					});
				}
			}
		}

		// Token: 0x040041D7 RID: 16855
		private readonly double[] #a;
	}
}
