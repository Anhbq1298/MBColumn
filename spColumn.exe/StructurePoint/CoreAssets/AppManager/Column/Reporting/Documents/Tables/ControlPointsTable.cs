using System;
using System.Collections.Generic;
using System.Linq;
using #7hc;
using #FCd;
using #owe;
using #Rwe;
using #wdd;
using #Wse;
using Aspose.Words;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Output;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Model;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.GUI.DesktopControls;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Resources;
using StructurePoint.CoreAssets.Units;

namespace StructurePoint.CoreAssets.AppManager.Column.Reporting.Documents.Tables
{
	// Token: 0x020011A0 RID: 4512
	internal sealed class ControlPointsTable : #qwe
	{
		// Token: 0x0600990F RID: 39183 RVA: 0x00025CC1 File Offset: 0x00023EC1
		public ControlPointsTable(#lte model) : base(model)
		{
		}

		// Token: 0x06009910 RID: 39184 RVA: 0x00203BD8 File Offset: 0x00201DD8
		public override void #npb(#6Dd #opb)
		{
			IReadOnlyList<ControlPoint> readOnlyList = base.Model.Output.ControlPoints;
			Options options = base.Model.Input.Options;
			GeneralInformation generalInformation = base.Model.GeneralInfo;
			#aed #aed = new #aed(new double[]
			{
				3.0,
				19.0,
				12.0,
				12.0,
				12.0,
				8.0,
				9.0,
				9.0,
				7.0,
				2.0
			});
			if (!options.IsACI())
			{
				#aed = new #aed(new double[]
				{
					3.0,
					19.0,
					12.0,
					12.0,
					12.0,
					8.0,
					9.0,
					8.0,
					2.0
				});
			}
			readOnlyList = readOnlyList.GroupBy(new Func<ControlPoint, string>(ControlPointsTable.<>c.<>9.#qcf)).Select(new Func<IGrouping<string, ControlPoint>, IOrderedEnumerable<ControlPoint>>(ControlPointsTable.<>c.<>9.#rcf)).SelectMany(new Func<IOrderedEnumerable<ControlPoint>, IEnumerable<ControlPoint>>(ControlPointsTable.<>c.<>9.#tcf)).ToList<ControlPoint>();
			using (#5Dd #5Dd = #opb.#ul(2, #aed.#7dd()))
			{
				#5Dd.#VDd(ParagraphAlignment.Right, Array.Empty<int>());
				#5Dd.#VDd(ParagraphAlignment.Left, new int[]
				{
					0,
					1
				});
				#5Dd.#RDd(true, new int[]
				{
					1
				});
				#5Dd.#ODd(new string[]
				{
					Localization.StringAbout,
					Localization.StringPoint,
					#Phc.#3hc(107359852),
					Localization.StringXMoment,
					Localization.StringYMoment,
					Localization.StringNADepth,
					#Yxe.DtDepth,
					#Yxe.EpsT
				});
				if (options.IsACI())
				{
					#5Dd.#ODd(new string[]
					{
						#Yxe.Phi
					});
				}
				#5Dd.#ODd(new string[]
				{
					string.Empty
				});
				#5Dd.#ODd(new string[]
				{
					string.Empty,
					string.Empty,
					generalInformation.UnitStringF,
					generalInformation.UnitStringM,
					generalInformation.UnitStringM,
					generalInformation.UnitStringD,
					generalInformation.UnitStringD,
					string.Empty
				});
				if (options.IsACI())
				{
					#5Dd.#ODd(new string[]
					{
						string.Empty
					});
				}
				#5Dd.#ODd(new string[]
				{
					string.Empty
				});
				#5Dd.#VDd(ParagraphAlignment.Right, Array.Empty<int>());
				#5Dd.#VDd(ParagraphAlignment.Left, new int[]
				{
					1
				});
				string a = null;
				for (int i = 0; i < readOnlyList.Count; i++)
				{
					ControlPoint controlPoint = readOnlyList[i];
					string text = controlPoint.#j3e();
					bool flag = a != text;
					a = text;
					#5Dd.#QDd(new string[]
					{
						text
					});
					#5Dd.#QDd(new string[]
					{
						#Phc.#3hc(107286798) + this.#83c(controlPoint)
					});
					#5Dd.#QDd(new string[]
					{
						#ned.#qp(new float?(controlPoint.P), NativeNumberFormat.F12_1, #Phc.#3hc(107381628))
					});
					#5Dd.#QDd(new string[]
					{
						#ned.#qp(new float?(controlPoint.Xm), NativeNumberFormat.F12_2, #Phc.#3hc(107381628))
					});
					#5Dd.#QDd(new string[]
					{
						#ned.#qp(new float?(controlPoint.Ym), NativeNumberFormat.F12_2, #Phc.#3hc(107381628))
					});
					#5Dd.#QDd(new string[]
					{
						#ned.#qp(new float?(controlPoint.C), (options.Unit == UnitSystem.USCustomary) ? NativeNumberFormat.F8_2 : NativeNumberFormat.F8_0, #Phc.#3hc(107381628))
					});
					#5Dd.#QDd(new string[]
					{
						#ned.#qp(new float?(controlPoint.Dt), (options.Unit == UnitSystem.USCustomary) ? NativeNumberFormat.F8_2 : NativeNumberFormat.F8_0, #Phc.#3hc(107381628))
					});
					#5Dd.#QDd(new string[]
					{
						#ned.#qp(new float?(controlPoint.Eps), NativeNumberFormat.F8_5, #Phc.#3hc(107381628))
					});
					if (options.IsACI())
					{
						#5Dd.#QDd(new string[]
						{
							#ned.#qp(controlPoint.Phi, NativeNumberFormat.F8_5, #Phc.#3hc(107381628))
						});
					}
					#5Dd.#QDd(new string[]
					{
						controlPoint.HasPhiParadox ? #Phc.#3hc(107425009) : string.Empty
					});
					if (flag && i > 0)
					{
						#5Dd.Borders.BottomCellBorders.Add(i + 1);
					}
				}
			}
		}

		// Token: 0x06009911 RID: 39185 RVA: 0x00204064 File Offset: 0x00202264
		private string #83c(ControlPoint #Ng)
		{
			switch (#Ng.Type)
			{
			case ControlPoint.#uif.#a:
				return #Phc.#3hc(107286793);
			case ControlPoint.#uif.#b:
				return #Phc.#3hc(107286804);
			case ControlPoint.#uif.#c:
				return #Yxe.Fs + #Phc.#3hc(107286271);
			case ControlPoint.#uif.#d:
				return #Yxe.Fs + #Phc.#3hc(107286262) + #Yxe.Fy;
			case ControlPoint.#uif.#e:
				return #Phc.#3hc(107286217);
			case ControlPoint.#uif.#f:
				return #Yxe.EpsT + #Phc.#3hc(107359847) + #Yxe.EpsTy;
			case ControlPoint.#uif.#g:
				return #Phc.#3hc(107286228);
			case ControlPoint.#uif.#h:
				return #Phc.#3hc(107286207);
			case ControlPoint.#uif.#i:
				return #Phc.#3hc(107286158);
			default:
				return #Phc.#3hc(107381628);
			}
		}
	}
}
