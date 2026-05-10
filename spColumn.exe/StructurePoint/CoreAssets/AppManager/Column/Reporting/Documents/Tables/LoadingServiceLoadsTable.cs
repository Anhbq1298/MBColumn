using System;
using System.Linq;
using #7hc;
using #FCd;
using #owe;
using #wdd;
using #Wse;
using Aspose.Words;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Model;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.GUI.DesktopControls;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Resources;
using StructurePoint.CoreAssets.Infrastructure.Extensions;

namespace StructurePoint.CoreAssets.AppManager.Column.Reporting.Documents.Tables
{
	// Token: 0x020011AA RID: 4522
	internal sealed class LoadingServiceLoadsTable : #qwe
	{
		// Token: 0x06009937 RID: 39223 RVA: 0x00025CC1 File Offset: 0x00023EC1
		public LoadingServiceLoadsTable(#lte model) : base(model)
		{
		}

		// Token: 0x06009938 RID: 39224 RVA: 0x00205BB0 File Offset: 0x00203DB0
		public override void #npb(#6Dd #opb)
		{
			GeneralInformation generalInformation = base.Model.GeneralInfo;
			double[] #Zpb = Enumerable.Range(1, 7).Select(new Func<int, double>(LoadingServiceLoadsTable.<>c.<>9.#qcf)).ToArray<double>();
			using (#5Dd #5Dd = #opb.#ul(2, #Zpb))
			{
				#5Dd.#VDd(ParagraphAlignment.Right, Array.Empty<int>());
				#5Dd.#ODd(new string[]
				{
					Localization.StringNo.#z2d(),
					Localization.StringLoadCase,
					Localization.StringAxialLoad,
					Localization.StringMxAtTop,
					Localization.StringMxAtBottom,
					Localization.StringMyAtTop,
					Localization.StringMyAtBottom
				});
				#5Dd.#ODd(new string[]
				{
					string.Empty,
					string.Empty,
					generalInformation.UnitStringF,
					generalInformation.UnitStringM,
					generalInformation.UnitStringM,
					generalInformation.UnitStringM,
					generalInformation.UnitStringM
				});
				int num = 1;
				NativeNumberFormat #cA = NativeNumberFormat.F10_2;
				foreach (ServiceLoad serviceLoad in base.Model.Input.ServiceLoads)
				{
					#5Dd.#QDd(new int?(num));
					#5Dd.#ODd(new string[]
					{
						Localization.StringDead
					});
					#5Dd.#QDd(new string[]
					{
						#ned.#qp(new float?(serviceLoad.Dead.AxialLoad), #cA, #Phc.#3hc(107381628))
					});
					#5Dd.#QDd(new string[]
					{
						#ned.#qp(new float?(serviceLoad.Dead.MomentXTop), #cA, #Phc.#3hc(107381628))
					});
					#5Dd.#QDd(new string[]
					{
						#ned.#qp(new float?(serviceLoad.Dead.MomentXBottom), #cA, #Phc.#3hc(107381628))
					});
					#5Dd.#QDd(new string[]
					{
						#ned.#qp(new float?(serviceLoad.Dead.MomentYTop), #cA, #Phc.#3hc(107381628))
					});
					#5Dd.#QDd(new string[]
					{
						#ned.#qp(new float?(serviceLoad.Dead.MomentYBottom), #cA, #Phc.#3hc(107381628))
					});
					#5Dd.#QDd(new int?(num));
					#5Dd.#ODd(new string[]
					{
						Localization.StringLive
					});
					#5Dd.#QDd(new string[]
					{
						#ned.#qp(new float?(serviceLoad.Live.AxialLoad), #cA, #Phc.#3hc(107381628))
					});
					#5Dd.#QDd(new string[]
					{
						#ned.#qp(new float?(serviceLoad.Live.MomentXTop), #cA, #Phc.#3hc(107381628))
					});
					#5Dd.#QDd(new string[]
					{
						#ned.#qp(new float?(serviceLoad.Live.MomentXBottom), #cA, #Phc.#3hc(107381628))
					});
					#5Dd.#QDd(new string[]
					{
						#ned.#qp(new float?(serviceLoad.Live.MomentYTop), #cA, #Phc.#3hc(107381628))
					});
					#5Dd.#QDd(new string[]
					{
						#ned.#qp(new float?(serviceLoad.Live.MomentYBottom), #cA, #Phc.#3hc(107381628))
					});
					#5Dd.#QDd(new int?(num));
					#5Dd.#ODd(new string[]
					{
						Localization.StringWind
					});
					#5Dd.#QDd(new string[]
					{
						#ned.#qp(new float?(serviceLoad.Wind.AxialLoad), #cA, #Phc.#3hc(107381628))
					});
					#5Dd.#QDd(new string[]
					{
						#ned.#qp(new float?(serviceLoad.Wind.MomentXTop), #cA, #Phc.#3hc(107381628))
					});
					#5Dd.#QDd(new string[]
					{
						#ned.#qp(new float?(serviceLoad.Wind.MomentXBottom), #cA, #Phc.#3hc(107381628))
					});
					#5Dd.#QDd(new string[]
					{
						#ned.#qp(new float?(serviceLoad.Wind.MomentYTop), #cA, #Phc.#3hc(107381628))
					});
					#5Dd.#QDd(new string[]
					{
						#ned.#qp(new float?(serviceLoad.Wind.MomentYBottom), #cA, #Phc.#3hc(107381628))
					});
					#5Dd.#QDd(new int?(num));
					#5Dd.#ODd(new string[]
					{
						Localization.StringEQ
					});
					#5Dd.#QDd(new string[]
					{
						#ned.#qp(new float?(serviceLoad.Earthquake.AxialLoad), #cA, #Phc.#3hc(107381628))
					});
					#5Dd.#QDd(new string[]
					{
						#ned.#qp(new float?(serviceLoad.Earthquake.MomentXTop), #cA, #Phc.#3hc(107381628))
					});
					#5Dd.#QDd(new string[]
					{
						#ned.#qp(new float?(serviceLoad.Earthquake.MomentXBottom), #cA, #Phc.#3hc(107381628))
					});
					#5Dd.#QDd(new string[]
					{
						#ned.#qp(new float?(serviceLoad.Earthquake.MomentYTop), #cA, #Phc.#3hc(107381628))
					});
					#5Dd.#QDd(new string[]
					{
						#ned.#qp(new float?(serviceLoad.Earthquake.MomentYBottom), #cA, #Phc.#3hc(107381628))
					});
					#5Dd.#QDd(new int?(num));
					#5Dd.#ODd(new string[]
					{
						Localization.StringSnow
					});
					#5Dd.#QDd(new string[]
					{
						#ned.#qp(new float?(serviceLoad.Snow.AxialLoad), #cA, #Phc.#3hc(107381628))
					});
					#5Dd.#QDd(new string[]
					{
						#ned.#qp(new float?(serviceLoad.Snow.MomentXTop), #cA, #Phc.#3hc(107381628))
					});
					#5Dd.#QDd(new string[]
					{
						#ned.#qp(new float?(serviceLoad.Snow.MomentXBottom), #cA, #Phc.#3hc(107381628))
					});
					#5Dd.#QDd(new string[]
					{
						#ned.#qp(new float?(serviceLoad.Snow.MomentYTop), #cA, #Phc.#3hc(107381628))
					});
					#5Dd.#QDd(new string[]
					{
						#ned.#qp(new float?(serviceLoad.Snow.MomentYBottom), #cA, #Phc.#3hc(107381628))
					});
					num++;
				}
			}
		}
	}
}
