using System;
using #7hc;
using #FCd;
using #owe;
using #Rwe;
using #wdd;
using #Wse;
using Aspose.Words;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Model;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.GUI.DesktopControls;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Resources;
using StructurePoint.CoreAssets.Localizer;

namespace #hye
{
	// Token: 0x020011BA RID: 4538
	internal sealed class #Sye : #qwe
	{
		// Token: 0x0600995D RID: 39261 RVA: 0x00079DC9 File Offset: 0x00077FC9
		public #Sye(#lte #Od, ConsideredAxis #Tye) : base(#Od)
		{
			this.#a = #Tye;
		}

		// Token: 0x0600995E RID: 39262 RVA: 0x0020893C File Offset: 0x00206B3C
		public override void #npb(#6Dd #opb)
		{
			GeneralInformation generalInformation = base.Model.GeneralInfo;
			#aed #aed = new #aed(new double[]
			{
				11.0,
				8.0,
				10.0,
				10.0,
				12.0,
				8.0,
				12.0
			});
			using (#5Dd #5Dd = #opb.#ul(2, #aed.#7dd()))
			{
				#5Dd.#VDd(ParagraphAlignment.Right, Array.Empty<int>());
				#5Dd.#VDd(ParagraphAlignment.Left, new int[1]);
				#5Dd.#ODd(new string[]
				{
					Localization.StringBeam,
					Localization.StringLength,
					Localization.StringWidth,
					Localization.StringDepth,
					#Phc.#3hc(107286549),
					#Yxe.FPrimC,
					#Yxe.Ec
				});
				#5Dd.#ODd(new string[]
				{
					string.Empty,
					generalInformation.UnitStringL,
					generalInformation.UnitStringD,
					generalInformation.UnitStringD,
					generalInformation.UnitStringD + #6xe.#4xe(#Phc.#3hc(107421485)),
					generalInformation.UnitStringS,
					generalInformation.UnitStringS
				});
				SlendernessOfBeams slendernessOfBeams = (this.#a == ConsideredAxis.X) ? base.Model.Input.BeamX : base.Model.Input.BeamY;
				Beam[] array = new Beam[]
				{
					slendernessOfBeams.AboveLeft,
					slendernessOfBeams.AboveRight,
					slendernessOfBeams.BelowLeft,
					slendernessOfBeams.BelowRight
				};
				string[] array2 = new string[]
				{
					Localization.StringAboveLeft,
					Localization.StringAboveRight,
					Localization.StringBelowLeft,
					Localization.StringBelowRight
				};
				for (int i = 0; i < array.Length; i++)
				{
					#5Dd.#QDd(new string[]
					{
						array2[i]
					});
					Beam beam = array[i];
					if (beam.BeamType == BeamType.None)
					{
						#5Dd.#Fhd(6, new string[]
						{
							Localization.StringNoBeamSpecified
						});
					}
					else if (beam.BeamType == BeamType.Rigid)
					{
						#5Dd.#Fhd(6, new string[]
						{
							Strings.StringRigidBeam
						});
					}
					else
					{
						#5Dd.#QDd(new string[]
						{
							#ned.#qp(new float?(beam.Length), NativeNumberFormat.G8, #Phc.#3hc(107381628))
						});
						#5Dd.#QDd(new string[]
						{
							#ned.#qp(new float?(beam.Width), NativeNumberFormat.G10, #Phc.#3hc(107381628))
						});
						#5Dd.#QDd(new string[]
						{
							#ned.#qp(new float?(beam.Depth), NativeNumberFormat.G10, #Phc.#3hc(107381628))
						});
						#5Dd.#QDd(new string[]
						{
							#ned.#qp(new float?(beam.MofI), NativeNumberFormat.G12, #Phc.#3hc(107381628))
						});
						#5Dd.#QDd(new string[]
						{
							#ned.#qp(new float?(beam.Fcp), NativeNumberFormat.G8, #Phc.#3hc(107381628))
						});
						#5Dd.#QDd(new string[]
						{
							#ned.#qp(new float?(beam.Ec), NativeNumberFormat.G12, #Phc.#3hc(107381628))
						});
					}
				}
			}
		}

		// Token: 0x040041D8 RID: 16856
		private readonly ConsideredAxis #a;
	}
}
