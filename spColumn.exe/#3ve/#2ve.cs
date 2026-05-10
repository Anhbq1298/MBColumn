using System;
using #12e;
using #7hc;
using #hZe;
using StructurePoint.CoreAssets.AppManager.Column.Engineer;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.FailureSurface;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;

namespace #3ve
{
	// Token: 0x0200118F RID: 4495
	internal sealed class #2ve
	{
		// Token: 0x0600986A RID: 39018 RVA: 0x00202164 File Offset: 0x00200364
		public static #hwe #ul(ColumnStorageModel #X, DesignEngine #rj)
		{
			if (#X == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107289973));
			}
			#hwe #hwe = new #hwe();
			if (#X.Options.ConsideredAxis != ConsideredAxis.Both || #rj == null || !#rj.OutputModel.SolveCompleted)
			{
				return #hwe;
			}
			int num = 70;
			int num2 = 36;
			#l4e #l4e = #rj.OutputModel;
			#y0e #y0e = #l4e.FactoredInteractionDiagram;
			float val = #l4e.ReductionFactors.#E1e(#rj.InputModel, #rj.RuntimeModel, #rj.CodeExpert) * #y0e.BiCurve[0].AxialLoad;
			for (int i = 0; i < num; i++)
			{
				for (int j = 0; j < num2; j++)
				{
					FailureSurfaceData item = new FailureSurfaceData
					{
						AxialForce = Math.Min(val, #y0e.BiCurve[i].AxialLoad),
						AxialForceOriginal = #y0e.BiCurve[i].AxialLoad,
						MomentX = #y0e.BiCurve[i].MomentX[j],
						MomentY = #y0e.BiCurve[i].MomentY[j],
						NADepth = #y0e.BiCurve[i].DepthOfNeutralAxisC[j],
						NAAngle = #y0e.BiCurve[i].AngleOfNeutralAxisC[j],
						Dt = #y0e.BiCurve[i].Dt[j],
						Epst = #y0e.BiCurve[i].BarMaximumStrainEps[j],
						PhiFactor = #y0e.BiCurve[i].PhiFactor[j]
					};
					#hwe.FactoredFailureSurfaceData.Add(item);
				}
			}
			#y0e #y0e2 = #l4e.NominalInteractionDiagram;
			if (#y0e2 != null)
			{
				for (int k = 0; k < num; k++)
				{
					for (int l = 0; l < num2; l++)
					{
						FailureSurfaceData item2 = default(FailureSurfaceData);
						item2.AxialForce = #y0e2.BiCurve[k].AxialLoad;
						item2.AxialForceOriginal = item2.AxialForce;
						item2.MomentX = #y0e2.BiCurve[k].MomentX[l];
						item2.MomentY = #y0e2.BiCurve[k].MomentY[l];
						item2.NADepth = #y0e2.BiCurve[k].DepthOfNeutralAxisC[l];
						item2.NAAngle = #y0e2.BiCurve[k].AngleOfNeutralAxisC[l];
						item2.Dt = #y0e.BiCurve[k].Dt[l];
						item2.Epst = #y0e2.BiCurve[k].BarMaximumStrainEps[l];
						item2.PhiFactor = #y0e2.BiCurve[k].PhiFactor[l];
						#hwe.NominalFailureSurfaceData.Add(item2);
					}
				}
			}
			return #hwe;
		}
	}
}
