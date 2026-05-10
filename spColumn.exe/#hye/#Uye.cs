using System;
using #12e;
using #7hc;
using #FCd;
using #npe;
using #owe;
using #Qcd;
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
	// Token: 0x020011BB RID: 4539
	internal sealed class #Uye : #qwe
	{
		// Token: 0x0600995F RID: 39263 RVA: 0x00025CC1 File Offset: 0x00023EC1
		public #Uye(#lte #Od) : base(#Od)
		{
		}

		// Token: 0x06009960 RID: 39264 RVA: 0x00208C68 File Offset: 0x00206E68
		public override void #npb(#6Dd #opb)
		{
			GeneralInformation generalInformation = base.Model.GeneralInfo;
			#aed #aed = new #aed(new double[]
			{
				7.0,
				4.0,
				8.0,
				10.0,
				10.0,
				12.0,
				8.0,
				12.0
			});
			EndConditionType endCondition = base.Model.Input.DesignedColumnX.EndCondition;
			EndConditionType endCondition2 = base.Model.Input.DesignedColumnY.EndCondition;
			using (#5Dd #5Dd = #opb.#ul(2, #aed.#7dd()))
			{
				#5Dd.#VDd(ParagraphAlignment.Right, Array.Empty<int>());
				#5Dd.#VDd(ParagraphAlignment.Left, new int[]
				{
					0,
					1
				});
				#5Dd.#ODd(new string[]
				{
					Localization.StringColumn,
					Localization.StringAxis,
					Localization.StringHeight,
					Localization.StringWidth,
					#Phc.#3hc(107286021),
					#Phc.#3hc(107286549),
					#Yxe.FPrimC,
					#Yxe.Ec
				});
				#5Dd.#ODd(new string[]
				{
					string.Empty,
					string.Empty,
					generalInformation.UnitStringL,
					generalInformation.UnitStringD,
					generalInformation.UnitStringD,
					generalInformation.UnitStringD + #6xe.#4xe(#Phc.#3hc(107421485)),
					generalInformation.UnitStringS,
					generalInformation.UnitStringS
				});
				for (int i = base.Model.Input.Options.AxisStart; i <= base.Model.Input.Options.AxisEnd; i++)
				{
					ConsideredAxis consideredAxis = (ConsideredAxis)i;
					SlendernessOfDesignedColumn slendernessOfDesignedColumn = (consideredAxis == ConsideredAxis.X) ? base.Model.Input.DesignedColumnX : base.Model.Input.DesignedColumnY;
					float value = base.Model.BasicProperties.GeomProperties.SecondMomentOfInertia[i];
					#5Dd.#QDd(new string[]
					{
						Localization.StringDesign
					});
					#5Dd.#QDd(new string[]
					{
						consideredAxis.ToString()
					});
					#5Dd.#QDd(new string[]
					{
						#ned.#qp(new float?(slendernessOfDesignedColumn.Height), NativeNumberFormat.G8, #Phc.#3hc(107381628))
					});
					if (base.Model.Input.Options.SectionType == SectionType.Circle)
					{
						#5Dd.#QDd(new string[]
						{
							#ned.#qp(new float?(base.Model.BasicProperties.DimensionA), NativeNumberFormat.G10, #Phc.#3hc(107381628))
						});
						#5Dd.#QDd(new string[]
						{
							#Phc.#3hc(107426661)
						});
					}
					else if (base.Model.Input.Options.SectionType == SectionType.Rectangle)
					{
						#5Dd.#QDd(new string[]
						{
							#ned.#qp(new float?(base.Model.BasicProperties.DimensionA), NativeNumberFormat.G10, #Phc.#3hc(107381628))
						});
						#5Dd.#QDd(new string[]
						{
							#ned.#qp(new float?(base.Model.BasicProperties.DimensionB), NativeNumberFormat.G10, #Phc.#3hc(107381628))
						});
					}
					else
					{
						#5Dd.#QDd(new string[]
						{
							#Phc.#3hc(107361293)
						});
						#5Dd.#QDd(new string[]
						{
							#Phc.#3hc(107361293)
						});
					}
					#5Dd.#QDd(new string[]
					{
						#ned.#qp(new float?(value), NativeNumberFormat.G12, #Phc.#3hc(107381628))
					});
					#5Dd.#QDd(new string[]
					{
						#ned.#qp(new float?(base.Model.Input.MaterialProperties.Fcp), NativeNumberFormat.G8, #Phc.#3hc(107381628))
					});
					#5Dd.#QDd(new string[]
					{
						#ned.#qp(new float?(base.Model.Input.MaterialProperties.Ec), NativeNumberFormat.G12, #Phc.#3hc(107381628))
					});
				}
				for (int j = 0; j < 2; j++)
				{
					bool flag = j == 0;
					SlendernessOfColumn slendernessOfColumn = flag ? base.Model.Input.ColumnAbove : base.Model.Input.ColumnBelow;
					for (int k = base.Model.Input.Options.AxisStart; k <= base.Model.Input.Options.AxisEnd; k++)
					{
						ConsideredAxis consideredAxis2 = (ConsideredAxis)k;
						EndConditionType #6r = (consideredAxis2 == ConsideredAxis.X) ? endCondition : endCondition2;
						#s5e #s5e = (consideredAxis2 == ConsideredAxis.X) ? base.Model.BasicProperties.SlendernessProperties.SlendernessX : base.Model.BasicProperties.SlendernessProperties.SlendernessY;
						float? #f = (j == 0) ? ((#s5e != null) ? new float?(#s5e.InertiaAbove) : null) : ((#s5e != null) ? new float?(#s5e.InertiaBelow) : null);
						#5Dd.#QDd(new string[]
						{
							(j == 0) ? Localization.StringAbove : Localization.StringBelow
						});
						#5Dd.#QDd(new string[]
						{
							consideredAxis2.ToString()
						});
						bool flag2 = flag && #Bpe.#ype(#6r);
						if (slendernessOfColumn.SlendernessColumnType == SlendernessColumnType.None || flag2)
						{
							#5Dd.#Fhd(6, new string[]
							{
								Localization.StringNoColumnSpecified
							});
						}
						else if (slendernessOfColumn.SlendernessColumnType == SlendernessColumnType.DesignCol)
						{
							#5Dd.#QDd(new string[]
							{
								#ned.#qp(new float?(slendernessOfColumn.Height), NativeNumberFormat.G8, #Phc.#3hc(107381628))
							});
							if (#5Dd.#Lcd())
							{
								#5Dd.#Fhd(3, new string[]
								{
									Strings.StringAsDesignCol_WRAPPED
								});
							}
							else
							{
								#5Dd.#QDd(new string[]
								{
									Strings.StringAsDesignCol_WRAPPED
								});
								#5Dd.#Fhd(2, new string[]
								{
									string.Empty
								});
							}
							#5Dd.#QDd(new string[]
							{
								#ned.#qp(new float?(slendernessOfColumn.Fcp), NativeNumberFormat.G8, #Phc.#3hc(107381628))
							});
							#5Dd.#QDd(new string[]
							{
								#ned.#qp(new float?(slendernessOfColumn.Ec), NativeNumberFormat.G12, #Phc.#3hc(107381628))
							});
						}
						else
						{
							#5Dd.#QDd(new string[]
							{
								#ned.#qp(new float?(slendernessOfColumn.Height), NativeNumberFormat.G8, #Phc.#3hc(107381628))
							});
							if (slendernessOfColumn.SlendernessColumnType == SlendernessColumnType.Circular)
							{
								#5Dd.#QDd(new string[]
								{
									#Phc.#3hc(107426661)
								});
							}
							else
							{
								#5Dd.#QDd(new string[]
								{
									#ned.#qp(new float?(slendernessOfColumn.Width), NativeNumberFormat.G10, #Phc.#3hc(107381628))
								});
							}
							#5Dd.#QDd(new string[]
							{
								#ned.#qp(new float?(slendernessOfColumn.Depth), NativeNumberFormat.G10, #Phc.#3hc(107381628))
							});
							#5Dd.#QDd(new string[]
							{
								#ned.#qp(#f, NativeNumberFormat.G12, #Phc.#3hc(107381628))
							});
							#5Dd.#QDd(new string[]
							{
								#ned.#qp(new float?(slendernessOfColumn.Fcp), NativeNumberFormat.G8, #Phc.#3hc(107381628))
							});
							#5Dd.#QDd(new string[]
							{
								#ned.#qp(new float?(slendernessOfColumn.Ec), NativeNumberFormat.G12, #Phc.#3hc(107381628))
							});
						}
					}
				}
			}
		}
	}
}
