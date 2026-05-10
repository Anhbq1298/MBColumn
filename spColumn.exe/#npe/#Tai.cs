using System;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;

namespace #npe
{
	// Token: 0x02001133 RID: 4403
	internal static class #Tai
	{
		// Token: 0x06009463 RID: 37987 RVA: 0x001FA574 File Offset: 0x001F8774
		public static IBeam #Sai()
		{
			return new Beam
			{
				BeamType = BeamType.Rigid,
				Length = 1f,
				Width = 0f,
				Depth = 0f,
				MofI = 1E+15f,
				Fcp = 1f,
				Ec = 1f,
				IsInertiaStandard = false,
				IsConcreteStandard = false
			};
		}
	}
}
