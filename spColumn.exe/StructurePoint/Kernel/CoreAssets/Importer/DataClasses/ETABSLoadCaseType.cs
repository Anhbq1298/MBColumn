using System;

namespace StructurePoint.Kernel.CoreAssets.Importer.DataClasses
{
	// Token: 0x02000E50 RID: 3664
	public enum ETABSLoadCaseType
	{
		// Token: 0x040035F8 RID: 13816
		LinearStatic = 1,
		// Token: 0x040035F9 RID: 13817
		NonlinearStatic,
		// Token: 0x040035FA RID: 13818
		Modal,
		// Token: 0x040035FB RID: 13819
		ResponseSpectrum,
		// Token: 0x040035FC RID: 13820
		LinearHistory,
		// Token: 0x040035FD RID: 13821
		NonlinearHistory,
		// Token: 0x040035FE RID: 13822
		LinearDynamic,
		// Token: 0x040035FF RID: 13823
		NonlinearDynamic,
		// Token: 0x04003600 RID: 13824
		MovingLoad,
		// Token: 0x04003601 RID: 13825
		Buckling,
		// Token: 0x04003602 RID: 13826
		SteadyState,
		// Token: 0x04003603 RID: 13827
		PowerSpectralDensity,
		// Token: 0x04003604 RID: 13828
		LinearStaticMultiStep,
		// Token: 0x04003605 RID: 13829
		HyperStatic
	}
}
