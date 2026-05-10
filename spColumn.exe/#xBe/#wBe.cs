using System;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.FailureSurface;

namespace #xBe
{
	// Token: 0x02001213 RID: 4627
	internal static class #wBe
	{
		// Token: 0x06009B25 RID: 39717 RVA: 0x0020F880 File Offset: 0x0020DA80
		public static BiCurve[] #uBe(FailureSurfaceData[] #vBe)
		{
			BiCurve[] array = new BiCurve[70];
			for (int i = 0; i < 70; i++)
			{
				BiCurve biCurve = new BiCurve();
				for (int j = 0; j < 36; j++)
				{
					int num = i * 36 + j;
					FailureSurfaceData failureSurfaceData = #vBe[num];
					biCurve.AxialLoad = failureSurfaceData.AxialForce;
					biCurve.MomentX[j] = failureSurfaceData.MomentX;
					biCurve.MomentY[j] = failureSurfaceData.MomentY;
					biCurve.DepthOfNeutralAxisC[j] = failureSurfaceData.NADepth;
					biCurve.AngleOfNeutralAxisC[j] = failureSurfaceData.NAAngle;
					biCurve.BarMaximumStrainEps[j] = failureSurfaceData.Epst;
					biCurve.Dt[j] = failureSurfaceData.Dt;
					biCurve.PhiFactor[j] = failureSurfaceData.PhiFactor;
				}
				array[i] = biCurve;
			}
			return array;
		}
	}
}
